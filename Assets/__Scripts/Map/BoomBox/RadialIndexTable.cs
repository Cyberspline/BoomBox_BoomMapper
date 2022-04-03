using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "RadialIndexTableSO", menuName = "Map/Radial Index Table")]
public class RadialIndexTable : ScriptableObject
{
    public static RadialIndexTable Instance;

    /*
     * Thanks a lot to HardCPP for giving me this data straight from BoomBox itself.
     */

    [SerializeField] private Vector2 globalScale = Vector2.one;
    [SerializeField] private Vector2 globalOffset = Vector2.up;
    [Header("Notes")]
    [SerializeField] private List<Vector2> notePlacements = new List<Vector2>();
    [SerializeField] private List<Vector2> noteDirections = new List<Vector2>();
    [SerializeField] private List<float> noteInwardRotation = new List<float>();
    [SerializeField] private List<int> noteRotatedIndices = new List<int>();
    [Header("Obstacles")]
    [SerializeField] private List<Vector2> obstaclePlacements = new List<Vector2>();
    [SerializeField] private List<int> obstacleRotatedIndices = new List<int>();

    public int NotePlacements => notePlacements.Count;

    public int ObstaclePlacements => obstaclePlacements.Count;

    private Dictionary<int, int> mirroredNotePlacementIndices = new Dictionary<int, int>();

    private Dictionary<int, int> mirroredObstaclePlacementIndices = new Dictionary<int, int>();

    /// <summary>
    /// Gets the 2D position of a note
    /// </summary>
    /// <param name="radialIndex">Radial index of the note, which determines its position.</param>
    /// <returns>Position of the note</returns>
    public Vector2 GetNotePlacement(int radialIndex) => (notePlacements[radialIndex] * globalScale) + globalOffset;

    /// <summary>
    /// Gets the (undetermined) direction for a note
    /// </summary>
    /// <param name="radialIndex">Radial index of the note, which determines its (undetermined) direction</param>
    /// <returns>(Undetermined) direction for the note</returns>
    public Vector2 GetNoteDirection(int radialIndex) => noteDirections[radialIndex];

    /// <summary>
    /// Gets the inward rotation for a note
    /// </summary>
    /// <param name="radialIndex">Radial Index of the note, which determines its inward rotation.</param>
    /// <returns>Inward rotation (unknown axis) for the note</returns>
    public float GetNoteInwardRotation(int radialIndex) => noteInwardRotation[radialIndex];

    /// <summary>
    /// Gets the 2D position of an obstacle point.
    /// </summary>
    /// <param name="radialIndex">Radial index of an obstacle point, which determines its position</param>
    /// <returns>Position of the obstacle point.</returns>
    public Vector2 GetObstaclePlacement(int radialIndex) => (obstaclePlacements[radialIndex] * globalScale) + globalOffset;

    public int GetHorizontallyMirroredNoteRadialIndex(int radialIndex)
    {
        if (!mirroredNotePlacementIndices.TryGetValue(radialIndex, out var mirroredRadialIndex))
        {
            var position = (GetNotePlacement(radialIndex) / globalScale) - globalOffset;
            position.x *= -1;

            var closest = notePlacements.OrderBy((x) => Vector2.Distance(x, position));
            mirroredRadialIndex = notePlacements.IndexOf(closest.First());

            mirroredNotePlacementIndices.Add(radialIndex, mirroredRadialIndex);
        }

        return mirroredRadialIndex;
    }

    public int GetHorizontallyMirroredObstacleRadialIndex(int radialIndex)
    {
        if (!mirroredObstaclePlacementIndices.TryGetValue(radialIndex, out var mirroredRadialIndex))
        {
            var position = (GetObstaclePlacement(radialIndex) / globalScale) - globalOffset;
            position.x *= -1;

            var closest = obstaclePlacements.OrderBy((x) => Vector2.Distance(x, position));
            mirroredRadialIndex = obstaclePlacements.IndexOf(closest.First());

            mirroredObstaclePlacementIndices.Add(radialIndex, mirroredRadialIndex);
        }

        return mirroredRadialIndex;
    }

    // Gets radial index to the right of given radial index
    public int GetRightNoteRadialIndex(int radialIndex) => noteRotatedIndices[radialIndex];

    public int GetRightObstacleRadialIndex(int radialIndex) => obstacleRotatedIndices[radialIndex];

    // Gets radial index to the left of given radial index
    public int GetLeftNoteRadialIndex(int radialIndex) => noteRotatedIndices.IndexOf(radialIndex);

    public int GetLeftObstacleRadialIndex(int radialIndex) => obstacleRotatedIndices.IndexOf(radialIndex);

    private void OnEnable() => Instance = this;
}
