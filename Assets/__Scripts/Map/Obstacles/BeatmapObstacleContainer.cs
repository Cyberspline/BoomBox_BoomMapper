using UnityEngine;
using UnityEngine.Serialization;

public class BeatmapObstacleContainer : BeatmapObjectContainer
{
    [FormerlySerializedAs("obstacleData")] public BeatmapObstacle ObstacleData;

    public override BeatmapObject ObjectData { get => ObstacleData; set => ObstacleData = (BeatmapObstacle)value; }

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
        var a = ObstacleData.A.GetPoint();
        var b = ObstacleData.B.GetPoint();

        transform.localRotation = Quaternion.LookRotation(b - a, Vector3.forward);
        transform.localPosition = new Vector3(a.x, a.y, ObstacleData.Time * EditorScaleController.EditorScale);

        SetScale(new Vector3(0.8f, 0.3f, (a - b).magnitude));

        UpdateCollisionGroups();
    }
}
