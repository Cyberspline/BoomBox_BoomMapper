using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading;
using Newtonsoft.Json;

[Serializable]
public class BoomBoxMap
{
    /// <summary>
    /// Local JSON format version(?)
    /// </summary>
    [JsonProperty]
    public string LocalVersion = "1";

    /// <summary>
    /// Online ID of this difficulty. I'm assuming this is assigned by the API.
    /// </summary>
    [JsonProperty]
    public int OnlineID = -1;

    /// <summary>
    /// Difficulty name
    /// </summary>
    [JsonProperty]
    public string DifficultyName;

    /// <summary>
    /// Creator/mapper of the difficulty file
    /// </summary>
    [JsonProperty]
    public string Creator;

    /// <summary>
    /// Short description of the difficulty file
    /// </summary>
    [JsonProperty]
    public string Description;

    /// <summary>
    /// ISO timestamp of when the difficulty was created, in UTC
    /// </summary>
    [JsonProperty]
    public string TimeCreated;

    /// <summary>
    /// Style of map 
    /// </summary>
    [JsonProperty]
    public int MapStyle;

    /// <summary>
    /// Biome to use for the difficulty
    /// </summary>
    [JsonProperty]
    public int BiomeType;

    /// <summary>
    /// Difficulty tags, separated by a space
    /// </summary>
    [JsonProperty]
    public string Tags;

    /// <summary>
    /// Timing points for the map (internally going to re-use BPM changes)
    /// </summary>
    [JsonProperty]
    public List<BeatmapBPMChange> TimingPoints;

    /// <summary>
    /// Unused list.
    /// </summary>
    [Obsolete]
    [JsonProperty]
    public List<object> Events = null;

    /// <summary>
    /// Unused list.
    /// </summary>
    [Obsolete]
    [JsonProperty]
    public List<object> Biomes = null;

    /// <summary>
    /// Bookmarks in the map
    /// </summary>
    [JsonProperty]
    public List<object> Bookmarks;

    /// <summary>
    /// Objects in the map
    /// </summary>
    [JsonProperty]
    public List<object> Objects;

    /// <summary>
    /// Obstacles in the map
    /// </summary>
    [JsonProperty]
    public List<object> Obstacles;

    /// <summary>
    /// Location and file name of the map
    /// </summary>
    public FileInfo FileInfo;

    public void Save()
    {
        if (string.IsNullOrEmpty(FileInfo.FullName))
        {
            throw new InvalidOperationException("Map was not created correctly.");
        }

        // Switch to invariant culture so that JSON is serialized properly
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;

        using var writer = new StreamWriter(FileInfo.FullName, false);

        var json = JsonSerializer.CreateDefault();
        json.Serialize(writer, this);
    }
}
