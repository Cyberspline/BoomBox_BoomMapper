﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class NotePlacement : PlacementController<BeatmapNote, BeatmapNoteContainer, NotesContainer>,
    CMInput.INotePlacementActions
{
    private const int upKey = 0;
    private const int leftKey = 1;
    private const int downKey = 2;
    private const int rightKey = 3;

    [FormerlySerializedAs("noteAppearanceSO")] [SerializeField] private NoteAppearanceSO noteAppearanceSo;
    [SerializeField] private DeleteToolController deleteToolController;
    [SerializeField] private PrecisionPlacementGridController precisionPlacement;
    [SerializeField] private LaserSpeedController laserSpeedController;
    [SerializeField] private BeatmapNoteInputController beatmapNoteInputController;
    [SerializeField] private ColorPicker colorPicker;
    [SerializeField] private ToggleColourDropdown dropdown;
    [SerializeField] private BeatmapNoteContainer placementAreaPrefab;
    [SerializeField] private RadialIndexTable radialIndexTable;

    // TODO: Perhaps move this into Settings as a user-configurable option
    private readonly float
        diagonalStickMAXTime = 0.3f; // This controls the maximum time that a note will stay a diagonal

    // REVIEW: Perhaps partner with Obama to turn this list of bools
    // into some binary shifting goodness
    private readonly List<bool> heldKeys = new List<bool> { false, false, false, false };

    private bool diagonal;
    private bool flagDirectionsUpdate;

    public override int PlacementXMin => base.PlacementXMax * -1;

    internal override void Start()
    {
        var cachedNote = new BeatmapNote();

        for (var i = 0; i < radialIndexTable.NotePlacements; i++)
        {
            cachedNote.RadialIndex = i;

            var note = Instantiate(placementAreaPrefab,
                radialIndexTable.GetNotePlacement(i), Quaternion.Euler(BeatmapNoteContainer.Directionalize(cachedNote)),
                ParentTrack);
            
            note.Setup();

            // Ensure our intersection collider is on the right layer for placement
            note.GetComponent<IntersectionCollider>().CollisionLayer = 11;

            note.SetColor(Color.gray);
            note.SetAlpha(0.3f, true);
        }

        base.Start();
    }

    private void LateUpdate()
    {
        if (flagDirectionsUpdate)
        {
            HandleDirectionValues();
            flagDirectionsUpdate = false;
        }
    }

    //TODO perhaps make a helper function to deal with the context.performed and context.canceled checks
    public void OnDownNote(InputAction.CallbackContext context) => HandleKeyUpdate(context, downKey);

    public void OnLeftNote(InputAction.CallbackContext context) => HandleKeyUpdate(context, leftKey);

    public void OnUpNote(InputAction.CallbackContext context) => HandleKeyUpdate(context, upKey);

    public void OnRightNote(InputAction.CallbackContext context) => HandleKeyUpdate(context, rightKey);

    public void OnDotNote(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        deleteToolController.UpdateDeletion(false);
        UpdateCut(BeatmapNote.NoteCutDirectionAny);
    }

    public void OnUpLeftNote(InputAction.CallbackContext context)
    {
        if (context.performed && !laserSpeedController.Activated)
            UpdateCut(BeatmapNote.NoteCutDirectionUpLeft);
    }

    public void OnUpRightNote(InputAction.CallbackContext context)
    {
        if (context.performed && !laserSpeedController.Activated)
            UpdateCut(BeatmapNote.NoteCutDirectionUpRight);
    }

    public void OnDownRightNote(InputAction.CallbackContext context)
    {
        if (context.performed && !laserSpeedController.Activated)
            UpdateCut(BeatmapNote.NoteCutDirectionDownRight);
    }

    public void OnDownLeftNote(InputAction.CallbackContext context)
    {
        if (context.performed && !laserSpeedController.Activated)
            UpdateCut(BeatmapNote.NoteCutDirectionDownLeft);
    }

    public override BeatmapAction GenerateAction(BeatmapObject spawned, IEnumerable<BeatmapObject> container) =>
        new BeatmapObjectPlacementAction(spawned, container, "Placed a note.");

    public override BeatmapNote GenerateOriginalData() =>
        new BeatmapNote(0, 0, 0, BeatmapNote.NoteTypeA, BeatmapNote.NoteCutDirectionDown);

    public override void OnPhysicsRaycast(Intersections.IntersectionHit hit, Vector3 _)
    {
        var roundedHit = ParentTrack.InverseTransformPoint(hit.Point);
        roundedHit.z = RoundedTime * EditorScaleController.EditorScale;

        queuedData.LineIndex = Mathf.RoundToInt(instantiatedContainer.transform.localPosition.x + 1.5f);
        queuedData.LineLayer = Mathf.RoundToInt(instantiatedContainer.transform.localPosition.y - 0.5f);

        UpdateAppearance();
    }

    public void UpdateCut(int value)
    {
        queuedData.CutDirection = value;
        if (DraggedObjectContainer != null && DraggedObjectContainer.MapNoteData != null)
        {
            DraggedObjectContainer.MapNoteData.CutDirection = value;
            noteAppearanceSo.SetNoteAppearance(DraggedObjectContainer);
        }
        else if (beatmapNoteInputController.QuickModificationActive && Settings.Instance.QuickNoteEditing)
        {
            var note = ObjectUnderCursor();
            if (note != null && note.ObjectData is BeatmapNote noteData)
            {
                var newData = BeatmapObject.GenerateCopy(noteData);
                newData.CutDirection = value;

                BeatmapActionContainer.AddAction(
                    new BeatmapObjectModifiedAction(newData, noteData, noteData, "Quick edit"), true);
            }
        }

        UpdateAppearance();
    }

    public void UpdateType(int type)
    {
        queuedData.Type = type;
        UpdateAppearance();
    }

    private void UpdateAppearance()
    {
        if (instantiatedContainer is null) return;
        instantiatedContainer.MapNoteData = queuedData;
        noteAppearanceSo.SetNoteAppearance(instantiatedContainer);
        instantiatedContainer.MaterialPropertyBlock.SetFloat("_AlwaysTranslucent", 1);
        instantiatedContainer.UpdateMaterials();
        instantiatedContainer.transform.localEulerAngles = BeatmapNoteContainer.Directionalize(queuedData);
    }

    public override void TransferQueuedToDraggedObject(ref BeatmapNote dragged, BeatmapNote queued)
    {
        dragged.Time = queued.Time;
        dragged.LineIndex = queued.LineIndex;
        dragged.LineLayer = queued.LineLayer;
        dragged.CutDirection = queued.CutDirection;
        if (DraggedObjectContainer != null)
            DraggedObjectContainer.transform.localEulerAngles = BeatmapNoteContainer.Directionalize(dragged);
        noteAppearanceSo.SetNoteAppearance(DraggedObjectContainer);
    }

    private void HandleKeyUpdate(InputAction.CallbackContext context, int id)
    {
        if (context.performed ^ heldKeys[id]) flagDirectionsUpdate = true;
        heldKeys[id] = context.performed;
    }

    private void HandleDirectionValues()
    {
        deleteToolController.UpdateDeletion(false);

        var upNote = heldKeys[upKey];
        var downNote = heldKeys[downKey];
        var leftNote = heldKeys[leftKey];
        var rightNote = heldKeys[rightKey];
        var previousDiagonalState = diagonal;

        var handleUpDownNotes = upNote ^ downNote; // XOR: True if the values are different, false if the same
        var handleLeftRightNotes = leftNote ^ rightNote;

        diagonal = handleUpDownNotes && handleLeftRightNotes;

        if (previousDiagonalState && diagonal == false)
        {
            StartCoroutine(CheckForDiagonalUpdate());
            return;
        }

        if (handleUpDownNotes && !handleLeftRightNotes) // We handle simple up/down notes
        {
            if (upNote) UpdateCut(BeatmapNote.NoteCutDirectionUp);
            else UpdateCut(BeatmapNote.NoteCutDirectionDown);
        }
        else if (!handleUpDownNotes && handleLeftRightNotes) // We handle simple left/right notes
        {
            if (leftNote) UpdateCut(BeatmapNote.NoteCutDirectionLeft);
            else UpdateCut(BeatmapNote.NoteCutDirectionRight);
        }
        else if (diagonal) //We need to do a diagonal
        {
            if (leftNote)
            {
                if (upNote) UpdateCut(BeatmapNote.NoteCutDirectionUpLeft);
                else UpdateCut(BeatmapNote.NoteCutDirectionDownLeft);
            }
            else
            {
                if (upNote) UpdateCut(BeatmapNote.NoteCutDirectionUpRight);
                else UpdateCut(BeatmapNote.NoteCutDirectionDownRight);
            }
        }
    }

    private IEnumerator CheckForDiagonalUpdate()
    {
        var previousHeldKeys = new List<bool>(heldKeys);
        yield return new WaitForSeconds(diagonalStickMAXTime);
        // Weird way of saying "Are the keys being held right now the same as before"
        if (!previousHeldKeys.Except(heldKeys).Any()) flagDirectionsUpdate = true;
    }
}
