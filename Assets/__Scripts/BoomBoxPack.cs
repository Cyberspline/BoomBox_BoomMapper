using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using Newtonsoft.Json;
using UnityEngine;

[Serializable]
public class BoomBoxPack
{
    /// <summary>
    /// ID of the pack in the BoomBox servers (Filled in by the API, default is -1)
    /// </summary>
    [JsonProperty]
    public int OnlineId = -1;

    /// <summary>
    /// ID of the official provided song (Only non-null if song is officially provided by the API)
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public int? SongId = null;

    /// <summary>
    /// Artist of the song (NOT the mapper)
    /// </summary>
    [JsonProperty]
    public string SongArtist;

    /// <summary>
    /// Title of the song
    /// </summary>
    [JsonProperty]
    public string SongTitle;

    /// <summary>
    /// Name of the audio file
    /// </summary>
    [JsonProperty]
    public string AudioFile;

    /// <summary>
    /// Name of the cover image file
    /// </summary>
    [JsonProperty]
    public string ImageFile;

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
    public string Directory;

    /// <summary>
    /// Last write time
    /// </summary>
    public DateTime LastWriteTime;

    /// <summary>
    /// Whether or not this pack is favorited by the mapper. This is an editor-exclusive feature.
    /// </summary>
    public bool IsFavourite
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
    public List<BoomBoxMap> Maps
    {
        get
        {
            if (maps != null) return maps;

            maps = new List<BoomBoxMap>();

            var json = JsonSerializer.CreateDefault();

            // Loop over .box files in the repo
            foreach (var file in System.IO.Directory.GetFiles(Settings.Instance.CustomPlatformsFolder, "*.box"))
            {
                using var reader = new StreamReader(file);
                using var jsonReader = new JsonTextReader(reader);

                maps.Add(json.Deserialize<BoomBoxMap>(jsonReader));
            }

            return maps;
        }
    }

    private bool isFavourite;
    private List<BoomBoxMap> maps = null;

    private readonly string stagedDirectory;

    /// <summary>
    /// Default constructor for JSON deserializing only
    /// </summary>
    [Obsolete("This constructor is for JSON deserializing only.")]
    public BoomBoxPack() { }

    public BoomBoxPack(string name)
    {
        SongTitle = name;
        stagedDirectory = CleanSongName;
    }

    public string CleanSongName => Path.GetInvalidFileNameChars()
        .Aggregate(SongTitle, (res, el) => res.Replace(el.ToString(), string.Empty));

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
    /// Attempts to load a <see cref="BoomBoxPack"/> at the given directory.
    /// </summary>
    /// <param name="directory">Map directory</param>
    /// <returns>The <see cref="BoomBoxPack"/> at the given directory, or <see cref="null"/> if none exists.</returns>
    public static BoomBoxPack GetPackFromDirectory(string directory)
    {
        var infoPath = Path.Combine(directory, "info.dat");

        if (File.Exists(infoPath))
        {
            using var reader = new StreamReader(infoPath);
            using var jsonReader = new JsonTextReader(reader);

            var json = JsonSerializer.CreateDefault();

            var pack = json.Deserialize<BoomBoxPack>(jsonReader);
            pack.Directory = directory;
            pack.LastWriteTime = System.IO.Directory.GetLastWriteTime(directory);

            return pack;
        }

        return null;
    }
}
