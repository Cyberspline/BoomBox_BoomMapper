using UnityEngine;
using UnityEngine.Serialization;

public class BeatmapObstacleContainer : BeatmapObjectContainer
{
    private static readonly int boomBoxObstacleOpacity = Shader.PropertyToID("_overallOpacity");

    private static readonly int chroMapperObstacleOpacity = Shader.PropertyToID("_MainAlpha");
    private static readonly int chroMapperObstacleSize = Shader.PropertyToID("_WorldScale");

    [FormerlySerializedAs("obstacleData")] public BeatmapObstacle ObstacleData;

    [SerializeField] private Material boomBoxObstacleMaterial;
    [SerializeField] private Material chroMapperObstacleMaterial;

    public override BeatmapObject ObjectData { get => ObstacleData; set => ObstacleData = (BeatmapObstacle)value; }

    public static BeatmapObstacleContainer SpawnObstacle(BeatmapObstacle data, TracksManager _, ref GameObject prefab)
    {
        var container = Instantiate(prefab).GetComponent<BeatmapObstacleContainer>();
        container.ObstacleData = data;
        return container;
    }

    public void SetAlpha(float alpha)
    {
        MaterialPropertyBlock.SetFloat(
            Settings.Instance.SimplifiedObstacles
                ? chroMapperObstacleOpacity
                : boomBoxObstacleOpacity,
            alpha);

        UpdateMaterials();
    }

    public void SetScale(Vector3 scale)
    {
        transform.localScale = scale;

        MaterialPropertyBlock.SetVector(chroMapperObstacleSize, scale);
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

    internal override void UpdateMaterials()
    {
        foreach (var renderer in ModelRenderers)
        {
            renderer.sharedMaterial = Settings.Instance.SimplifiedObstacles
                ? chroMapperObstacleMaterial
                : boomBoxObstacleMaterial;

            renderer.SetPropertyBlock(MaterialPropertyBlock);
        }
    }
}
