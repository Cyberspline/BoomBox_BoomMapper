using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class ObstaclePlacement : PlacementController<BeatmapObstacle, BeatmapObstacleContainer, ObstaclesContainer>
{
    [FormerlySerializedAs("obstacleAppearanceSO")] [SerializeField] private ObstacleAppearanceSO obstacleAppearanceSo;
    [SerializeField] private PrecisionPlacementGridController precisionPlacement;
    [SerializeField] private ColorPicker colorPicker;
    [SerializeField] private ToggleColourDropdown dropdown;
    [SerializeField] private GameObject placementAreaPrefab;
    [SerializeField] private RadialIndexTable radialIndexTable;

    private int originIndex;

    private float startTime;

    public static bool IsPlacing { get; private set; }

    public override int PlacementXMin => base.PlacementXMax * -1;

    private float SmallestRankableWallDuration => Atsc.GetBeatFromSeconds(0.016f);

    public override BeatmapAction GenerateAction(BeatmapObject spawned, IEnumerable<BeatmapObject> container) =>
        new BeatmapObjectPlacementAction(spawned, container, "Place a Wall.");

    public override BeatmapObstacle GenerateOriginalData() =>
        new BeatmapObstacle(0, 0, BeatmapObstacle.ValueFullBarrier, 0, 1);

    internal override void Start()
    {
        for (var i = 0; i < radialIndexTable.ObstaclePlacements; i++)
        {
            Instantiate(placementAreaPrefab,
                radialIndexTable.GetObstaclePlacement(i), Quaternion.identity, ParentTrack);
        }

        base.Start();
    }

    public override void OnPhysicsRaycast(Intersections.IntersectionHit hit, Vector3 transformedPoint)
    {
        Bounds = default;
        TestForType<ObstaclePlacement>(hit, BeatmapObject.ObjectType.Obstacle);

        instantiatedContainer.ObstacleData = queuedData;
        instantiatedContainer.ObstacleData.Duration = RoundedTime - startTime;
        obstacleAppearanceSo.SetObstacleAppearance(instantiatedContainer);
        var roundedHit = ParentTrack.InverseTransformPoint(hit.Point);


        var wallTransform = instantiatedContainer.transform;

        if (IsPlacing)
        {
            roundedHit = new Vector3(
                Mathf.Ceil(Math.Min(Math.Max(roundedHit.x, Bounds.min.x + 0.01f), Bounds.max.x)),
                Mathf.Ceil(Math.Min(Math.Max(roundedHit.y, 0.01f), 3f)),
                RoundedTime * EditorScaleController.EditorScale
            );

            wallTransform.localPosition = new Vector3(
                originIndex - 2, queuedData.Type == BeatmapObstacle.ValueFullBarrier ? 0 : 1.5f,
                startTime * EditorScaleController.EditorScale);
            queuedData.Width = Mathf.CeilToInt(roundedHit.x + 2) - originIndex;

            instantiatedContainer.SetScale(new Vector3(queuedData.Width,
                wallTransform.localScale.y, wallTransform.localScale.z));

            precisionPlacement.TogglePrecisionPlacement(false);

            return;
        }

        var vanillaType = transformedPoint.y <= 1.5f ? 0 : 1;

        wallTransform.localPosition = new Vector3(
            wallTransform.localPosition.x - 0.5f,
            vanillaType * 1.5f,
            wallTransform.localPosition.z);

        instantiatedContainer.SetScale(new Vector3(1, wallTransform.localPosition.y == 0 ? 3.5f : 2, 0));

        queuedData.CustomData = null;
        queuedData.LineIndex = Mathf.RoundToInt(wallTransform.localPosition.x + 2);
        queuedData.Type = vanillaType;

        precisionPlacement.TogglePrecisionPlacement(false);
    }

    public override void OnMousePositionUpdate(InputAction.CallbackContext context)
    {
        base.OnMousePositionUpdate(context);
        if (IsPlacing)
        {
            instantiatedContainer.transform.localPosition = new Vector3(instantiatedContainer.transform.localPosition.x,
                instantiatedContainer.transform.localPosition.y,
                startTime * EditorScaleController.EditorScale
            );
            instantiatedContainer.transform.localScale = new Vector3(instantiatedContainer.transform.localScale.x,
                instantiatedContainer.transform.localScale.y,
                (RoundedTime - startTime) * EditorScaleController.EditorScale);
        }
    }

    internal override void ApplyToMap()
    {
        if (IsPlacing)
        {
            IsPlacing = false;
            queuedData.Time = startTime;
            queuedData.Duration = instantiatedContainer.transform.localScale.z / EditorScaleController.EditorScale;
            if (queuedData.Duration < SmallestRankableWallDuration &&
                Settings.Instance.DontPlacePerfectZeroDurationWalls)
            {
                queuedData.Duration = SmallestRankableWallDuration;
            }

            objectContainerCollection.SpawnObject(queuedData, out var conflicting);
            BeatmapActionContainer.AddAction(GenerateAction(queuedData, conflicting));
            queuedData = GenerateOriginalData();
            instantiatedContainer.ObstacleData = queuedData;
            obstacleAppearanceSo.SetObstacleAppearance(instantiatedContainer);
            instantiatedContainer.transform.localScale = new Vector3(
                1, instantiatedContainer.transform.localPosition.y == 0 ? 3.5f : 2, 0);
        }
        else
        {
            IsPlacing = true;
            originIndex = queuedData.LineIndex;
            startTime = RoundedTime;
        }
    }

    public override void TransferQueuedToDraggedObject(ref BeatmapObstacle dragged, BeatmapObstacle queued)
    {
        dragged.Time = queued.Time;
        dragged.LineIndex = queued.LineIndex;
    }

    public override void CancelPlacement()
    {
        if (IsPlacing)
        {
            IsPlacing = false;
            queuedData = GenerateOriginalData();
            instantiatedContainer.ObstacleData = queuedData;
            obstacleAppearanceSo.SetObstacleAppearance(instantiatedContainer);
            instantiatedContainer.transform.localScale = new Vector3(
                1, instantiatedContainer.transform.localPosition.y == 0 ? 3.5f : 2, 0);
        }
    }
}
