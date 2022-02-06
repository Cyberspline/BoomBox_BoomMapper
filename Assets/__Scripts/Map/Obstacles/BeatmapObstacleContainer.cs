using UnityEngine;
using UnityEngine.Serialization;

public class BeatmapObstacleContainer : BeatmapObjectContainer
{
    [FormerlySerializedAs("obstacleData")] public BeatmapObstacle ObstacleData;

    public override BeatmapObject ObjectData { get => ObstacleData; set => ObstacleData = (BeatmapObstacle)value; }

    public int ChunkEnd => (int)((ObstacleData.Time + ObstacleData.Duration) / Intersections.ChunkSize);

    public bool IsRotatedByNoodleExtensions =>
        ObstacleData.CustomData != null && (ObstacleData.CustomData?.HasKey("_rotation") ?? false);

    public static BeatmapObstacleContainer SpawnObstacle(BeatmapObstacle data, TracksManager _, ref GameObject prefab)
    {
        var container = Instantiate(prefab).GetComponent<BeatmapObstacleContainer>();
        container.ObstacleData = data;
        return container;
    }

    public void SetColor(Color color)
    {
        //MaterialPropertyBlock.SetColor(colorTint, color);
        UpdateMaterials();
    }

    public void SetScale(Vector3 scale)
    {
        transform.localScale = scale;

        //MaterialPropertyBlock.SetVector(shaderScale, scale);
        UpdateMaterials();
    }

    public override void UpdateGridPosition()
    {
        var duration = Mathf.Abs(ObstacleData.B.StartTime - ObstacleData.A.StartTime) * EditorScaleController.EditorScale;

        var bounds = ObstacleData.GetShape();

        // Enforce positive scale, offset our obstacles to match.
        transform.localPosition = new Vector3(
            bounds.Position + (bounds.Width < 0 ? bounds.Width : 0),
            bounds.StartHeight + (bounds.Height < 0 ? bounds.Height : 0),
            (ObstacleData.Time * EditorScaleController.EditorScale) + (duration < 0 ? duration : 0)
        );

        var localDirection = ObstacleData.B.GetCenter() - ObstacleData.A.GetCenter();

        transform.up = localDirection.normalized;

        SetScale(new Vector3(
            1,
            localDirection.magnitude,
            Mathf.Max(0.3f, duration)
        ));

        UpdateCollisionGroups();
    }
}
