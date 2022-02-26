using System;
using Newtonsoft.Json;
using SimpleJSON;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public class BeatmapObstacle : BeatmapObject, IBeatmapObjectBounds
{
    //These are uhh, assumptions...
    public const int ValueFullBarrier = 0;
    public const int ValueHighBarrier = 1;

    public static readonly float MappingextensionsStartHeightMultiplier = 1.35f;
    public static readonly float MappingextensionsUnitsToFullHeightWall = 1000 / 3.5f;

    [JsonIgnore, Obsolete, FormerlySerializedAs("_lineIndex")] public int LineIndex;
    [JsonIgnore, Obsolete, FormerlySerializedAs("_type")] public int Type;
    [JsonIgnore, Obsolete, FormerlySerializedAs("_duration")] public float Duration;
    [JsonIgnore, Obsolete, FormerlySerializedAs("_width")] public int Width;

    [JsonProperty()]
    public Point A;

    [JsonProperty()]
    public Point B;

    public override float TimeInMilliseconds
    {
        get => Mathf.Min(A.StartTime, B.StartTime);
        set
        {
            var difference = Mathf.Abs(A.StartTime - B.StartTime);

            if (A.StartTime < B.StartTime)
            {
                A.StartTime = value;
                B.StartTime = value + difference;
            }
            else
            {
                B.StartTime = value;
                A.StartTime = value + difference;
            }
        }
    }

    /*
     * Obstacle Logic
     */

    public BeatmapObstacle() { }

    public BeatmapObstacle(JSONNode node)
    {
        Time = RetrieveRequiredNode(node, "_time").AsFloat;
        LineIndex = RetrieveRequiredNode(node, "_lineIndex").AsInt;
        Type = RetrieveRequiredNode(node, "_type").AsInt;
        Duration = RetrieveRequiredNode(node, "_duration").AsFloat;
        Width = RetrieveRequiredNode(node, "_width").AsInt;
        CustomData = node["_customData"];
    }

    public BeatmapObstacle(float time, int lineIndex, int type, float duration, int width, JSONNode customData = null)
    {
        A = new Point()
        {
            StartTime = GetMillisceondsFromBeats(time),
        };

        B = new Point()
        {
            StartTime = A.StartTime + GetMillisceondsFromBeats(duration)
        };
    }

    [JsonIgnore, Obsolete]
    public bool IsNoodleExtensionsWall => CustomData != null &&
                                          (CustomData.HasKey("_position") || CustomData.HasKey("_scale")
                                                                           || CustomData.HasKey("_localRotation") ||
                                                                           CustomData.HasKey("_rotation"));

    [JsonIgnore]
    public override ObjectType BeatmapType { get; set; } = ObjectType.Obstacle;

    public Vector2 GetPoint()
    {
        var centerA = A.GetPoint();
        var centerB = B.GetPoint();

        // I will assume the center will be the midpoint of the two points
        return (centerA + centerB) / 2;
    }

    public override JSONNode ConvertToJson()
    {
        JSONNode node = new JSONObject();
        node["_time"] = Math.Round(Time, DecimalPrecision);
        node["_lineIndex"] = LineIndex;
        node["_type"] = Type;
        node["_duration"] = Math.Round(Duration, DecimalPrecision); //Get rid of float precision errors
        node["_width"] = Width;
        if (CustomData != null) node["_customData"] = CustomData;
        return node;
    }

    protected override bool IsConflictingWithObjectAtSameTime(BeatmapObject other, bool deletion)
        => other is BeatmapObstacle obstacle
        && A.RadialIndex == obstacle.A.RadialIndex
        && B.RadialIndex == obstacle.B.RadialIndex;

    public override void Apply(BeatmapObject originalData)
    {
        base.Apply(originalData);

        if (originalData is BeatmapObstacle obs)
        {
            Type = obs.Type;
            Width = obs.Width;
            LineIndex = obs.LineIndex;
            Duration = obs.Duration;
        }
    }

    public ObstacleBounds GetShape()
    {
        var positionA = A.GetPoint();
        var positionB = B.GetPoint();

        var width = Mathf.Abs(positionA.x - positionB.x);
        var height = Mathf.Abs(positionA.y - positionB.y);
        var position = positionA.x;
        var startHeight = positionA.y;

        return new ObstacleBounds(width, height, position, startHeight);
    }

    [Serializable]
    public class Point : IBeatmapObjectBounds
    {
        /// <summary>
        /// Hand used for the point (always 0 AKA no hand)
        /// </summary>
        [JsonProperty]
        public const int Hand = 0;

        /// <summary>
        /// Type of the object (always 6 AKA obstacle)
        /// </summary>
        [JsonProperty]
        public const int Type = 6;

        /// <summary>
        /// Time, in milliseconds, where this point is located
        /// </summary>
        [JsonProperty]
        public float StartTime = 0;

        /// <summary>
        /// Orbital type for obstacle (always 2 AKA obstacle orbit)
        /// </summary>
        [JsonProperty]
        public const int OrbitalType = 2;

        /// <summary>
        /// Radial index for this point, which determines the position
        /// </summary>
        [JsonProperty]
        public int RadialIndex = 0;

        public Vector2 GetPoint() => RadialIndexTable.Instance.GetObstaclePlacement(RadialIndex);
    }
}
