using System.Collections.Generic;
using UnityEngine;

// TODO: Remove
public class BombPlacement : PlacementController<BeatmapNote, BeatmapNoteContainer, NotesContainer>
{

    public override int PlacementXMin => base.PlacementXMax * -1;

    public override BeatmapAction GenerateAction(BeatmapObject spawned, IEnumerable<BeatmapObject> container) =>
        new BeatmapObjectPlacementAction(spawned, container, "Placed a Bomb.");

    public override BeatmapNote GenerateOriginalData() =>
        new BeatmapNote(0, 0, 0, BeatmapNote.NoteTypeBomb, BeatmapNote.NoteCutDirectionDown);

    public override void OnPhysicsRaycast(Intersections.IntersectionHit hit, Vector3 _)
    {

        instantiatedContainer.MaterialPropertyBlock.SetFloat("_AlwaysTranslucent", 1);
        instantiatedContainer.UpdateMaterials();
    }

    public override void TransferQueuedToDraggedObject(ref BeatmapNote dragged, BeatmapNote queued)
    {
        dragged.Time = queued.Time;
        dragged.LineIndex = queued.LineIndex;
        dragged.LineLayer = queued.LineLayer;
    }
}
