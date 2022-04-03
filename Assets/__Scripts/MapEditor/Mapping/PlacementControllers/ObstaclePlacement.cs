using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ObstaclePlacement : PlacementController<BeatmapObstacle, BeatmapObstacleContainer, ObstaclesContainer>
{
    [SerializeField] private GameObject placementAreaPrefab;
    [SerializeField] private RadialIndexTable radialIndexTable;

    public static bool IsPlacing { get; private set; }

    public override int PlacementXMin => base.PlacementXMax * -1;

    public override BeatmapAction GenerateAction(BeatmapObject spawned, IEnumerable<BeatmapObject> container) =>
        new BeatmapObjectPlacementAction(spawned, container, "Place a Wall.");

    public override BeatmapObstacle GenerateOriginalData() =>
        new BeatmapObstacle(0, 0, BeatmapObstacle.ValueFullBarrier, 0, 1);

    public override bool IsValid => base.IsValid || IsPlacing;

    internal override void Start()
    {
        for (var i = 0; i < radialIndexTable.ObstaclePlacements; i++)
        {
            var dot = Instantiate(placementAreaPrefab, radialIndexTable.GetObstaclePlacement(i),
                Quaternion.identity, ParentTrack);

            dot.name = "Radial Index " + i;

            var radialIndexContainer = dot.AddComponent<PlacementRadialIndexContainer>();
            radialIndexContainer.RadialIndex = i;
            radialIndexContainer.Owner = this;
        }

        base.Start();
    }

    public override void OnPhysicsRaycast(Intersections.IntersectionHit hit, Vector3 transformedPoint)
    {
        if (hit.GameObject.TryGetComponent<PlacementRadialIndexContainer>(out var radialIndexContainer))
        {
            var radialIndex = radialIndexContainer.RadialIndex;

            queuedData.B.StartTime = queuedData.A.StartTime = Atsc.CurrentSeconds * 1000;

            if (IsPlacing && radialIndex != queuedData.A.RadialIndex)
            {
                queuedData.B.RadialIndex = radialIndex;

                instantiatedContainer.UpdateGridPosition();
            }
            else
            {
                queuedData.A.RadialIndex = radialIndex;

                instantiatedContainer.transform.position = radialIndexTable.GetObstaclePlacement(radialIndex);
                instantiatedContainer.transform.localEulerAngles = Vector3.zero;
                instantiatedContainer.SetScale(new Vector3(0.5f, 0.3f, 0.3f));
            }
        }
        else
        {
            SendMessage("ColliderExit");
        }
    }

    internal override void ApplyToMap()
    {
        if (IsPlacing && queuedData.A.RadialIndex != queuedData.B.RadialIndex)
        {
            IsPlacing = false;

            objectContainerCollection.SpawnObject(queuedData, out var conflicting);
            BeatmapActionContainer.AddAction(GenerateAction(queuedData, conflicting));
            queuedData = GenerateOriginalData();
            instantiatedContainer.ObstacleData = queuedData;
        }
        else
        {
            IsPlacing = true;
        }
    }

    public override void TransferQueuedToDraggedObject(ref BeatmapObstacle dragged, BeatmapObstacle queued)
    {
        dragged.Time = queued.Time;

        // TODO: Figure out elegant solution to dragging points. Nearest point is dragged?
    }

    public override void CancelPlacement()
    {
        if (IsPlacing)
        {
            IsPlacing = false;
            queuedData = GenerateOriginalData();
            instantiatedContainer.ObstacleData = queuedData;
            instantiatedContainer.transform.localScale = new Vector3(
                1, instantiatedContainer.transform.localPosition.y == 0 ? 3.5f : 2, 0);
        }
    }
}
