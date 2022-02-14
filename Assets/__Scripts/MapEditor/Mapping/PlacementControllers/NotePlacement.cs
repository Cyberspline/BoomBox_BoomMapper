using System.Collections;
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

    // Dictionary of one/two held keys (^^^) to their assigned radial index.
    private static readonly Dictionary<(int, int?), int> keyToRadialIndexMap = new Dictionary<(int, int?), int>()
    {
        { (rightKey, downKey), 0 },
        { (downKey, rightKey), 1 },
        { (downKey, null), 2 },
        { (downKey, leftKey), 3 },
        { (leftKey, downKey), 4 },
        { (leftKey, upKey), 5 },
        { (upKey, leftKey), 6 },
        { (upKey, null), 7 },
        { (upKey, rightKey), 8 },
        { (rightKey, upKey), 9 },
        { (rightKey, null), 10 },
        { (leftKey, null), 11 },
    };

    [FormerlySerializedAs("noteAppearanceSO")] [SerializeField] private NoteAppearanceSO noteAppearanceSo;
    [SerializeField] private DeleteToolController deleteToolController;
    [SerializeField] private BeatmapNoteInputController beatmapNoteInputController;
    [SerializeField] private BeatmapNoteContainer placementAreaPrefab;
    [SerializeField] private RadialIndexTable radialIndexTable;

    // TODO: Perhaps move this into Settings as a user-configurable option
    // This controls the maximum time that a note will stay a diagonal
    private readonly float diagonalStickMAXTime = 0.3f;

    private int? firstHeldKey = null;
    private int? secondHeldKey = null;

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

            // Ensure our intersection collider is on the right layer for placement
            var collider = note.GetComponent<IntersectionCollider>();
            Intersections.UnregisterColliderFromGroups(collider);
            collider.CollisionLayer = note.gameObject.layer = 11;
            Intersections.RegisterColliderToGroups(collider);

            note.Setup();

            note.SetColor(Color.gray);
            note.SetAlpha(0.3f, true);

            var radialIndexContainer = note.gameObject.AddComponent<PlacementRadialIndexContainer>();
            radialIndexContainer.RadialIndex = i;
            radialIndexContainer.Owner = this;
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

    public void OnDownNote(InputAction.CallbackContext context) => HandleKeyUpdate(context, downKey);

    public void OnLeftNote(InputAction.CallbackContext context) => HandleKeyUpdate(context, leftKey);

    public void OnUpNote(InputAction.CallbackContext context) => HandleKeyUpdate(context, upKey);

    public void OnRightNote(InputAction.CallbackContext context) => HandleKeyUpdate(context, rightKey);

    public void OnDotNote(InputAction.CallbackContext context)
    {
    }

    public void OnUpLeftNote(InputAction.CallbackContext context)
    {
    }

    public void OnUpRightNote(InputAction.CallbackContext context)
    {
    }

    public void OnDownRightNote(InputAction.CallbackContext context)
    {
    }

    public void OnDownLeftNote(InputAction.CallbackContext context)
    {
    }

    public override BeatmapAction GenerateAction(BeatmapObject spawned, IEnumerable<BeatmapObject> container) =>
        new BeatmapObjectPlacementAction(spawned, container, "Placed a note.");

    public override BeatmapNote GenerateOriginalData() =>
        new BeatmapNote(0, 0, 0, 1, BeatmapNote.NoteCutDirectionDown);

    public override void OnPhysicsRaycast(Intersections.IntersectionHit hit, Vector3 _)
    {
        if (firstHeldKey != null)
        {
            instantiatedContainer.UpdateGridPosition();
            instantiatedContainer.transform.localEulerAngles = BeatmapNoteContainer.Directionalize(queuedData);

            return;
        }

        if (hit.GameObject.TryGetComponent<PlacementRadialIndexContainer>(out var radialIndexContainer))
        {
            UpdateRadialIndex(radialIndexContainer.RadialIndex);
        }
        else
        {
            SendMessage("ColliderExit");
        }
    }

    public void UpdateRadialIndex(int radialIndex)
    {
        queuedData.RadialIndex = radialIndex;

        if (instantiatedContainer == null) return;

        instantiatedContainer.UpdateGridPosition();
        instantiatedContainer.transform.localEulerAngles = BeatmapNoteContainer.Directionalize(queuedData);

        UpdateAppearance();
    }

    public void UpdateType(int type)
    {
        // dirty conversion from beat saber to boombox types
        queuedData.Hand = type + 1;
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
        dragged.RadialIndex = queued.RadialIndex;
        if (DraggedObjectContainer != null)
            DraggedObjectContainer.transform.localEulerAngles = BeatmapNoteContainer.Directionalize(dragged);
        noteAppearanceSo.SetNoteAppearance(DraggedObjectContainer);
    }

    private void HandleKeyUpdate(InputAction.CallbackContext context, int id)
    {
        if (context.performed)
        {
            if (firstHeldKey == null)
            {
                firstHeldKey = id;
            }
            else
            {
                secondHeldKey = id;
            }

            flagDirectionsUpdate = true;
        }
        else if (context.canceled)
        {
            if (firstHeldKey == id)
            {
                firstHeldKey = secondHeldKey;
                secondHeldKey = null;
            }
            else if (secondHeldKey == id)
            {
                secondHeldKey = null;
            }

            flagDirectionsUpdate = true;
        }
    }

    private void HandleDirectionValues()
    {
        deleteToolController.UpdateDeletion(false);

        var previousDiagonalState = diagonal;
        diagonal = secondHeldKey != null;

        if (previousDiagonalState && diagonal == false)
        {
            StartCoroutine(CheckForDiagonalUpdate());
            return;
        }

        if (firstHeldKey != null && 
            keyToRadialIndexMap.TryGetValue((firstHeldKey.Value, secondHeldKey), out var radialIndex))
        {
            UpdateRadialIndex(radialIndex);
        }
    }

    private IEnumerator CheckForDiagonalUpdate()
    {
        var previousKeys = (firstHeldKey, secondHeldKey);

        yield return new WaitForSeconds(diagonalStickMAXTime);

        // Weird way of saying "Are the keys being held right now the same as before"
        if (previousKeys.firstHeldKey == firstHeldKey && previousKeys.secondHeldKey == secondHeldKey)
        {
            flagDirectionsUpdate = true;
        }
    }
}
