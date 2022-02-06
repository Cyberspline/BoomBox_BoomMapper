using System;
using Newtonsoft.Json;
using SimpleJSON;
using UnityEngine;
using Random = System.Random;

public class BeatmapBookmark : BeatmapObject
{
    private static readonly Random rand = new Random();

    [JsonProperty("Message")]
    public string Name = "Invalid Bookmark";

    [JsonProperty]
    public const int SnappingBeatDivType = 4;

    [JsonProperty("Offset")]
    public override float TimeInMilliseconds { get; set; }

    [JsonIgnore]
    public Color Color;

    public BeatmapBookmark() { }

    public BeatmapBookmark(JSONNode node)
    {
        Time = RetrieveRequiredNode(node, "_time").AsFloat;
        Name = RetrieveRequiredNode(node, "_name");
        if (node.HasKey("_color")) Color = RetrieveRequiredNode(node, "_color");
        else Color = Color.HSVToRGB((float)rand.NextDouble(), 0.75f, 1);
    }


    public BeatmapBookmark(float time, string name)
    {
        Time = time;
        Name = name;
        Color = Color.HSVToRGB((float)rand.NextDouble(), 0.75f, 1);
    }

    public override ObjectType BeatmapType { get; set; } = ObjectType.BpmChange;

    public override JSONNode ConvertToJson()
    {
        JSONNode node = new JSONObject();
        node["_time"] = Math.Round(Time, DecimalPrecision);
        node["_name"] = Name;
        node["_color"] = Color;
        return node;
    }

    protected override bool IsConflictingWithObjectAtSameTime(BeatmapObject other, bool deletion) => true;

    public override void Apply(BeatmapObject originalData)
    {
        base.Apply(originalData);

        if (originalData is BeatmapBookmark bm) Name = bm.Name;
    }
}
