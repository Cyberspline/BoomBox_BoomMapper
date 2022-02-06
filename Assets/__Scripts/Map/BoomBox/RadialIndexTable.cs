using System.Collections.Generic;
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
    [Header("Obstacles")]
    [SerializeField] private List<Vector2> obstaclePlacements = new List<Vector2>();

    public int NotePlacements => notePlacements.Count;

    public int ObstaclePlacements => obstaclePlacements.Count;

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

    private void OnEnable() => Instance = this;
}
