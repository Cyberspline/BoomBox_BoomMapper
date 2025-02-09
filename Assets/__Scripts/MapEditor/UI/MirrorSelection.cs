﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MirrorSelection : MonoBehaviour
{
    public void MirrorTime()
    {
        if (!SelectionController.HasSelectedObjects())
        {
            return;
        }

        var ordered = SelectionController.SelectedObjects.OrderByDescending(x => x.Time);
        var end = ordered.First().Time;
        var start = ordered.Last().Time;
        var allActions = new List<BeatmapAction>();
        foreach (var con in SelectionController.SelectedObjects)
        {
            var edited = BeatmapObject.GenerateCopy(con);
            edited.Time = start + (end - con.Time);
            allActions.Add(new BeatmapObjectModifiedAction(edited, con, con, "e", true));
        }

        var actionCollection =
            new ActionCollectionAction(allActions, true, true, "Mirrored a selection of objects in time.");
        BeatmapActionContainer.AddAction(actionCollection, true);
    }

    public void Mirror(bool horizontal) => Mirror(horizontal, !horizontal);

    public void Mirror(bool horizontal = false, bool vertical = false)
    {
        if (!SelectionController.HasSelectedObjects())
        {
            return;
        }

        var allActions = new List<BeatmapAction>();

        foreach (var con in SelectionController.SelectedObjects)
        {
            var original = BeatmapObject.GenerateCopy(con);

            if (con is BeatmapObstacle obstacle)
            {
                obstacle.A.RadialIndex = RadialIndexTable.Instance.GetMirroredObstacleRadialIndex(obstacle.A.RadialIndex, horizontal, vertical);
                obstacle.B.RadialIndex = RadialIndexTable.Instance.GetMirroredObstacleRadialIndex(obstacle.B.RadialIndex, horizontal, vertical);
            }
            else if (con is BeatmapNote note)
            {
                note.RadialIndex = RadialIndexTable.Instance.GetMirroredNoteRadialIndex(note.RadialIndex, horizontal, vertical);
            }

            allActions.Add(new BeatmapObjectModifiedAction(con, con, original, "e", true));
        }

        foreach (var unique in SelectionController.SelectedObjects.DistinctBy(x => x.BeatmapType))
            BeatmapObjectContainerCollection.GetCollectionForType(unique.BeatmapType).RefreshPool(true);
        BeatmapActionContainer.AddAction(new ActionCollectionAction(allActions, true, true,
            "Mirrored a selection of objects."));
    }

    public void MirrorColors()
    {
        if (!SelectionController.HasSelectedObjects())
        {
            return;
        }

        var allActions = new List<BeatmapAction>();
        foreach (var con in SelectionController.SelectedObjects)
        {
            var original = BeatmapObject.GenerateCopy(con);

            if (con is BeatmapNote note)
            {
                //flip colors
                if (note.Hand != BeatmapNote.NoteTypeBomb)
                {
                    note.Hand = note.Hand == BeatmapNote.HandRight
                        ? BeatmapNote.HandLeft
                        : BeatmapNote.HandRight;
                }
            }

            allActions.Add(new BeatmapObjectModifiedAction(con, con, original, "e", true));
        }

        foreach (var unique in SelectionController.SelectedObjects.DistinctBy(x => x.BeatmapType))
            BeatmapObjectContainerCollection.GetCollectionForType(unique.BeatmapType).RefreshPool(true);
        BeatmapActionContainer.AddAction(new ActionCollectionAction(allActions, true, true,
            "Mirrored a selection of objects."));
    }
}
