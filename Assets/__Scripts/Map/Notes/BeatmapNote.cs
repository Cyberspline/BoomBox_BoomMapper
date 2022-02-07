using System;
using Newtonsoft.Json;
using SimpleJSON;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public class BeatmapNote : BeatmapObject, IBeatmapObjectBounds
{
    public const int LineIndexFarLeft = 0;
    public const int LineIndexMidLeft = 1;
    public const int LineIndexMidRight = 2;
    public const int LineIndexFarRight = 3;

    public const int LineLayerBottom = 0;
    public const int LineLayerMid = 1;
    public const int LineLayerTop = 2;

    public const int NoteTypeA = 0;

    public const int NoteTypeB = 1;

    //public const int NOTE_TYPE_GHOST = 2;
    public const int NoteTypeBomb = 3;

    public const int NoteCutDirectionUp = 0;
    public const int NoteCutDirectionDown = 1;
    public const int NoteCutDirectionLeft = 2;
    public const int NoteCutDirectionRight = 3;
    public const int NoteCutDirectionUpLeft = 4;
    public const int NoteCutDirectionUpRight = 5;
    public const int NoteCutDirectionDownLeft = 6;
    public const int NoteCutDirectionDownRight = 7;
    public const int NoteCutDirectionAny = 8;
    public const int NoteCutDirectionNone = 9;

    public const int HandLeft = 1;
    public const int HandRight = 2;

    [JsonIgnore, Obsolete, FormerlySerializedAs("_lineIndex")] public int LineIndex;
    [JsonIgnore, Obsolete, FormerlySerializedAs("_lineLayer")] public int LineLayer;
    [JsonIgnore, Obsolete, FormerlySerializedAs("_cutDirection")] public int CutDirection;

    [JsonIgnore, Obsolete, FormerlySerializedAs("id")] public uint ID;

    /// <summary>
    /// Hand used to hit the note (1 = left, 2 = right?)
    /// </summary>
    [JsonProperty]
    public int Hand = HandLeft;

    /// <summary>
    /// Type of note (always 1)
    /// </summary>
    // TODO make constant; Type should always be "1" for notes
    [JsonProperty, FormerlySerializedAs("_type")]
    public int Type = 1;

    /// <summary>
    /// Orbital ring to position notes around (always 1)
    /// </summary>
    // TODO make constant; OrbitalType should always be "1" for notes
    [JsonProperty]
    public int OrbitalType = 1;

    /// <summary>
    /// Index into the final position of an object, and potentially its rotation.
    /// </summary>
    [JsonProperty]
    public int RadialIndex = 0;

    [JsonProperty("StartTime")]
    public override float TimeInMilliseconds { get; set; }

    public BeatmapNote() { }

    public BeatmapNote(JSONNode node)
    {
        Time = RetrieveRequiredNode(node, "_time").AsFloat;
        LineIndex = RetrieveRequiredNode(node, "_lineIndex").AsInt;
        LineLayer = RetrieveRequiredNode(node, "_lineLayer").AsInt;
        Type = RetrieveRequiredNode(node, "_type").AsInt;
        CutDirection = RetrieveRequiredNode(node, "_cutDirection").AsInt;
        CustomData = node["_customData"];
    }

    public BeatmapNote(float time, int lineIndex, int lineLayer, int type, int cutDirection, JSONNode customData = null)
    {
        Time = time;
        LineIndex = lineIndex;
        LineLayer = lineLayer;
        Type = type;
        CutDirection = cutDirection;
        CustomData = customData;
    }

    [JsonIgnore]
    public override ObjectType BeatmapType { get; set; } = ObjectType.Note;

    public Vector2 GetCenter() => GetPosition() + new Vector2(0f, 0.5f);

    public override JSONNode ConvertToJson()
    {
        JSONNode node = new JSONObject();
        node["_time"] = Math.Round(Time, DecimalPrecision);
        node["_lineIndex"] = LineIndex;
        node["_lineLayer"] = LineLayer;
        node["_type"] = Type;
        node["_cutDirection"] = CutDirection;
        if (CustomData != null) node["_customData"] = CustomData;
        return node;
    }

    public Vector2 GetPosition() => RadialIndexTable.Instance.GetNotePlacement(RadialIndex);

    public Vector3 GetScale() => Vector3.one;

    protected override bool IsConflictingWithObjectAtSameTime(BeatmapObject other, bool deletion)
        => other is BeatmapNote note && note.RadialIndex == RadialIndex;

    public override void Apply(BeatmapObject originalData)
    {
        base.Apply(originalData);

        if (originalData is BeatmapNote note)
        {
            Hand = note.Hand;
            Type = OrbitalType = 1;
            RadialIndex = note.RadialIndex;
        }
    }
}
