/// <summary>
///     Holds users changes to a difficulty until they ask to save them
/// </summary>
public class DifficultySettings
{
    public BoomBoxMap Map { get; }
    
    public string CustomName = "";
    public bool ForceDirty;
    public float NoteJumpMovementSpeed = 16;
    public float NoteJumpStartBeatOffset;

    public DifficultySettings(BoomBoxMap map)
    {
        Map = map;

        Revert();
    }

    public DifficultySettings(BoomBoxMap map, bool forceDirty) : this(map) => ForceDirty = forceDirty;

    /// <summary>
    ///     Check if the user has made changes
    /// </summary>
    /// <returns>True if changes have been made, false otherwise</returns>
    public bool IsDirty() =>
        ForceDirty ||
        !(CustomName ?? "").Equals(Map.DifficultyName == null);

    /// <summary>
    ///     Save the users changes to the backing DifficultyBeatmap object
    /// </summary>
    public void Commit()
    {
        ForceDirty = false;

        Map.DifficultyName = CustomName;

        Map.Save();
    }

    /// <summary>
    ///     Discard any changes from the user
    /// </summary>
    public void Revert()
    {
        CustomName = Map.DifficultyName;
    }
}
