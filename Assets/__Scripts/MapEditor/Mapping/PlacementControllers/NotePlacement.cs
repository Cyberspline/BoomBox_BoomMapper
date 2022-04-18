using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class NotePlacement : PlacementController<BeatmapNote, BeatmapNoteContainer, NotesContainer>
{
    [FormerlySerializedAs("noteAppearanceSO")] [SerializeField] private NoteAppearanceSO noteAppearanceSo;
    [SerializeField] private DeleteToolController deleteToolController;
    [SerializeField] private BeatmapNoteContainer placementAreaPrefab;
    [SerializeField] private RadialIndexTable radialIndexTable;

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

    public override BeatmapAction GenerateAction(BeatmapObject spawned, IEnumerable<BeatmapObject> container) =>
        new BeatmapObjectPlacementAction(spawned, container, "Placed a note.");

    public override BeatmapNote GenerateOriginalData() =>
        new BeatmapNote(0, 0, 0, 1, BeatmapNote.NoteCutDirectionDown);

    public override void OnPhysicsRaycast(Intersections.IntersectionHit hit, Vector3 _)
    {
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
}
