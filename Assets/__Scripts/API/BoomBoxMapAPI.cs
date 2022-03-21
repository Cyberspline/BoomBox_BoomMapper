using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;

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

    [JsonProperty("timing_points")]
    public readonly List<BeatmapBPMChange> TimingPoints;

    [JsonProperty("bookmarks")]
    public readonly List<BeatmapBookmark> Bookmarks;

    [JsonProperty("song")]
    public readonly int SongId;

    [JsonProperty("common_bpm")]
    public readonly float CommonBpm;

    [JsonProperty("length")]
    public readonly float Length;

    [JsonProperty("map_style")]
    public readonly int MapStyle = 1;

    [JsonProperty("is_active")]
    public readonly bool IsActive = true;

    [JsonProperty("map_status")]
    public readonly int MapStatus = 1;

    public BoomBoxMapAPI(BoomBoxPackBase pack, BoomBoxMap map)
    {
        if (pack.SongId == null)
        {
            throw new ArgumentNullException($"Cannot upload unofficial custom map: {nameof(pack.SongId)} is null");
        }

        DifficultyName = map.DifficultyName;
        Description = map.Description;

        Tags = map.Tags
            .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
            .Select(tag => new Tag(tag))
            .ToList();

        Objects = map.Objects;

        Obstacles = map.Obstacles;

        TimingPoints = map.TimingPoints;

        Bookmarks = map.Bookmarks;

        SongId = pack.SongId.Value;

        CommonBpm = map.BeginningBPM;

        Length = Mathf.Max(
            Objects.Max(it => it.TimeInMilliseconds),
            Obstacles.Max(it => it.TimeInMilliseconds)
            );
    }

    public class Tag
    {
        [JsonProperty("tag_name")]
        public readonly string TagName;

        public Tag(string tag) => TagName = tag;
    }
}
