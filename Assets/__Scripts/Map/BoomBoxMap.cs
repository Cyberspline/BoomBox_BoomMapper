using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
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
    public List<BeatmapBPMChange> TimingPoints = new List<BeatmapBPMChange>();

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
    public List<BeatmapBookmark> Bookmarks = new List<BeatmapBookmark>();

    /// <summary>
    /// Objects/notes in the map
    /// </summary>
    [JsonProperty]
    public List<BeatmapNote> Objects = new List<BeatmapNote>();

    /// <summary>
    /// Obstacles in the map
    /// </summary>
    [JsonProperty]
    public List<BeatmapObstacle> Obstacles = new List<BeatmapObstacle>();

    /// <summary>
    /// Location and file name of the map
    /// </summary>
    [JsonIgnore]
    public FileInfo FileInfo;

    /// <summary>
    /// Beginning BPM of the map, determined by the first BPM Change.
    /// </summary>
    [JsonIgnore]
    public float BeginningBPM
    {
        get => beginningBpm ??= TimingPoints.OrderBy(x => x.TimeInMilliseconds).FirstOrDefault()?.Bpm ?? 120;
        set
        {
            beginningBpm = value;

            if (TimingPoints.Count > 0)
            {
                TimingPoints.OrderBy(x => x.TimeInMilliseconds).FirstOrDefault().Bpm = value;
            }
            else
            {
                TimingPoints.Add(new BeatmapBPMChange(value, 0));
            }
        }
    }

    [JsonIgnore]
    private float? beginningBpm = null;

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
