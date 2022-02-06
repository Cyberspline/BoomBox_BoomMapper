using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "ObstacleAppearanceSO", menuName = "Map/Appearance/Obstacle Appearance SO")]
// TODO: Remove
public class ObstacleAppearanceSO : ScriptableObject
{
    [FormerlySerializedAs("defaultObstacleColor")] public Color DefaultObstacleColor = BeatSaberSong.DefaultLeftColor;
    [SerializeField] private Color negativeWidthColor = Color.green;
    [SerializeField] private Color negativeDurationColor = Color.yellow;

    public void SetObstacleAppearance(BeatmapObstacleContainer obj, PlatformDescriptor platform = null)
    {
    }
}
