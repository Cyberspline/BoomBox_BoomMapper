using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using Newtonsoft.Json;
using UnityEngine;

[Serializable]
public class BoomBoxCustomPack : BoomBoxPackBase
{
    /// <summary>
    /// ID of the pack in the BoomBox servers (Filled in by the API, default is -1)
    /// </summary>
    [JsonProperty]
    public readonly int OnlineId = -1;

    /// <summary>
    /// ID of the official provided song (Only non-null if song is officially provided by the API)
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public override int? SongId { get; set; }

    /// <summary>
    /// Artist of the song (NOT the mapper)
    /// </summary>
    [JsonProperty]
    public override string SongArtist { get; set; }

    /// <summary>
    /// Title of the song
    /// </summary>
    [JsonProperty]
    public override string SongTitle { get; set; }

    /// <summary>
    /// Name of the audio file
    /// </summary>
    [JsonProperty]
    public override string AudioFile { get; set; }

    /// <summary>
    /// Name of the cover image file
    /// </summary>
    [JsonProperty]
    public override string ImageFile { get; set; }

    /// <summary>
    /// ISO timestamp of the creation date, in UTC
    /// </summary>
    [JsonProperty]
    public string TimeCreated;

    /// <summary>
    /// Start time of the preview, in milliseconds
    /// </summary>
    [JsonProperty]
    public float PreviewTime;

    /// <summary>
    /// Duration of the song preview, in milliseconds
    /// </summary>
    [JsonProperty]
    public float PreviewDuration;

    /// <summary>
    /// Pack folder
    /// </summary>
    [JsonIgnore]
    public string Directory;

    /// <summary>
    /// Last write time
    /// </summary>
    [JsonIgnore]
    public DateTime LastWriteTime;

    /// <summary>
    /// Whether or not this pack is favorited by the mapper. This is an editor-exclusive feature.
    /// </summary>
    [JsonIgnore]
    public override bool IsFavourite
    {
        get => isFavourite;
        set
        {
            var path = Path.Combine(Directory, ".favourite");
            lock (this)
            {
                if (value)
                {
                    File.Create(path).Dispose();
                    File.SetAttributes(path, FileAttributes.Hidden);
                }
                else
                {
                    File.Delete(path);
                }
            }

            isFavourite = value;
        }
    }

    /// <summary>
    /// All of the maps in the pack. Populated and deserialized on first access.
    /// </summary>
    [JsonIgnore]
    public List<BoomBoxMap> Maps
    {
        get
        {
            if (maps != null) return maps;

            maps = new List<BoomBoxMap>();

            if (string.IsNullOrEmpty(Directory))
            {
                Directory = Path.Combine(Settings.Instance.CustomSongsFolder, stagedDirectory ?? CleanSongName);
            }

            var json = JsonSerializer.CreateDefault();
            var dir = new DirectoryInfo(Directory);

            if (!dir.Exists)
            {
                dir.Create();
            }

            // Loop over .box files in the repo
            foreach (var file in dir.EnumerateFiles("*.box"))
            {
                using var reader = new StreamReader(file.FullName);
                using var jsonReader = new JsonTextReader(reader);

                var map = json.Deserialize<BoomBoxMap>(jsonReader);
                map.FileInfo = file;

                maps.Add(map);
            }

            return maps;
        }
    }

    [JsonIgnore]
    public string CleanSongName => Path.GetInvalidFileNameChars()
        .Aggregate(SongTitle, (res, el) => res.Replace(el.ToString(), string.Empty));

    private bool isFavourite;
    private List<BoomBoxMap> maps = null;

    private readonly string stagedDirectory;

    /// <summary>
    /// Default constructor for JSON deserializing only
    /// </summary>
    [Obsolete("This constructor is for JSON deserializing only.")]
    public BoomBoxCustomPack() { }

    public BoomBoxCustomPack(string name)
    {
        SongTitle = name;
        stagedDirectory = CleanSongName;
    }

    /// <summary>
    /// Attempts to save the info.dat file.
    /// </summary>
    public void Save()
    {
        if (string.IsNullOrEmpty(Directory))
        {
            Directory = Path.Combine(Settings.Instance.CustomSongsFolder, stagedDirectory ?? CleanSongName);
        }

        // Switch to invariant culture so that JSON is serialized properly
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;

        var infoPath = Path.Combine(Directory, "info.dat");
        var info = new FileInfo(infoPath);

        // No, patrick, not existing does not mean it is read only.
        if (!info.IsReadOnly || !info.Exists)
        {
            using var writer = new StreamWriter(infoPath, false);

            var json = JsonSerializer.CreateDefault();
            json.Serialize(writer, this);
        }
        else
        {
            PersistentUI.Instance.ShowDialogBox("PersistentUI", "readonly",
                null, PersistentUI.DialogBoxPresetType.Ok);
            Debug.LogError(":hyperPepega: :mega: DONT MAKE YOUR MAP FILES READONLY");
        }
    }

    /// <summary>
    /// Attempts to load a <see cref="BoomBoxCustomPack"/> at the given directory.
    /// </summary>
    /// <param name="directory">Map directory</param>
    /// <returns>The <see cref="BoomBoxCustomPack"/> at the given directory, or <see cref="null"/> if none exists.</returns>
    public static BoomBoxCustomPack GetPackFromDirectory(string directory)
    {
        var infoPath = Path.Combine(directory, "info.dat");

        if (File.Exists(infoPath))
        {
            using var reader = new StreamReader(infoPath);
            using var jsonReader = new JsonTextReader(reader);

            var json = JsonSerializer.CreateDefault();

            var pack = json.Deserialize<BoomBoxCustomPack>(jsonReader);
            pack.Directory = directory;
            pack.LastWriteTime = System.IO.Directory.GetLastWriteTime(directory);

            return pack;
        }

        return null;
    }
}
