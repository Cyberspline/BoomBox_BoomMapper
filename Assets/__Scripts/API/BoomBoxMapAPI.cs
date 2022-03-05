using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

/// <summary>
/// The backend structure of a BoomBox map.
/// </summary>
public class BoomBoxMapAPI
{
    [JsonProperty("difficulty_name")]
    public readonly string DifficultyName;

    [JsonProperty("description")]
    public readonly string Description;

    [JsonProperty("tag")]
    public readonly List<Tag> Tags;

    [JsonProperty("bbox_objects")]
    public readonly List<BeatmapNote> Objects;

    [JsonProperty("obstacles")]
    public readonly List<BeatmapObstacle> Obstacles;

    [JsonProperty("song")]
    public readonly int SongId;

    [JsonProperty("common_bpm")]
    public readonly float CommonBpm;

    public BoomBoxMapAPI(BoomBoxPackBase pack, BoomBoxMap map)
    {
        if (pack.SongId == null)
        {
            throw new ArgumentNullException($"Cannot upload unofficial custom map: {nameof(pack.SongId)} is null");
        }

        DifficultyName = map.DifficultyName;
        Description = map.Description;

        Tags = map.Tags
            .Split(' ')
            .Select(tag => new Tag(tag))
            .ToList();

        Objects = map.Objects;

        Obstacles = map.Obstacles;

        SongId = pack.SongId.Value;

        CommonBpm = map.BeginningBPM;
    }

    public class Tag
    {
        [JsonProperty("tag_name")]
        public readonly string TagName;

        public Tag(string tag) => TagName = tag;
    }
}
