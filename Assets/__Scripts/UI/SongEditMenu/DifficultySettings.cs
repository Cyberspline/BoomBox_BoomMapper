/// <summary>
///     Holds users changes to a difficulty until they ask to save them
/// </summary>
public class DifficultySettings
{
    public BoomBoxMap Map { get; }
    
    public string CustomName = "";
    public string Creator = "";
    public string Description = "";
    public string Tags = "";
    public int MapStyle = 0;
    public int BiomeType = 0;

    public bool ForceDirty;

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
    public bool IsDirty() => Map != null &&
        (ForceDirty ||
        !(CustomName ?? "").Equals(Map.DifficultyName ?? "") ||
        !(Creator ?? "").Equals(Map.Creator ?? "") ||
        !(Description ?? "").Equals(Map.Description ?? "") ||
        !(Tags ?? "").Equals(Map.Tags ?? "") ||
        !MapStyle.Equals(Map.MapStyle) ||
        !BiomeType.Equals(Map.BiomeType));

    /// <summary>
    ///     Save the users changes to the backing DifficultyBeatmap object
    /// </summary>
    public void Commit()
    {
        ForceDirty = false;

        Map.DifficultyName = CustomName;
        Map.Creator = Creator;
        Map.Description = Description;
        Map.Tags = Tags;
        Map.BiomeType = BiomeType;
        Map.MapStyle = MapStyle;
    }

    /// <summary>
    ///     Discard any changes from the user
    /// </summary>
    public void Revert()
    {
        CustomName = Map.DifficultyName;
        Creator = Map.Creator;
        Description = Map.Description;
        Tags = Map.Tags;
        BiomeType = Map.BiomeType;
        MapStyle = Map.MapStyle;
    }
}
