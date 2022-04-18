using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using SimpleJSON;
using UnityEngine;

public abstract class BeatmapObject
{
    protected static int DecimalPrecision => 3;

    public enum ObjectType
    {
        Note,
        Event,
        Obstacle,
        CustomNote,
        CustomEvent,
        BpmChange
    }

    [JsonIgnore]
    public abstract ObjectType BeatmapType { get; set; }

    /// <summary>
    /// Time, in beats, where this object is located.
    /// </summary>
    [JsonIgnore]
    public float Time
    {
        get => GetBeatsFromMilliseconds(TimeInMilliseconds);
        set => TimeInMilliseconds = GetMillisceondsFromBeats(value);
    }

    /// <summary>
    /// Time, in milliseconds, where this object is located.
    /// In JSON, this is either called "Offset" or "StartTime", depending on the data structure.
    /// </summary>
    public abstract float TimeInMilliseconds { get; set; }

    /// <summary>
    ///     An expandable <see cref="JSONNode" /> that stores data for Beat Saber mods to use.
    /// </summary>
    [JsonIgnore, Obsolete]
    public JSONNode CustomData;

    public abstract JSONNode ConvertToJson();

    protected abstract bool IsConflictingWithObjectAtSameTime(BeatmapObject other, bool deletion = false);

    /// <summary>
    ///     Create an identical, yet not exact, copy of a given <see cref="BeatmapObject" />.
    /// </summary>
    /// <typeparam name="T">Specific type of BeatmapObject (Note, event, etc.)</typeparam>
    /// <param name="originalData">Original object to clone.</param>
    /// <returns>A clone of <paramref name="originalData" />.</returns>
    public static T GenerateCopy<T>(T originalData) where T : BeatmapObject
    {
        if (originalData is null) throw new ArgumentException("originalData is null.");

        using var textWriter = new System.IO.StringWriter();
        using var jsonWriter = new JsonTextWriter(textWriter);

        var json = JsonSerializer.CreateDefault();
        json.Serialize(jsonWriter, originalData);

        using var textReader = new System.IO.StringReader(textWriter.ToString());
        using var jsonReader = new JsonTextReader(textReader);

        return json.Deserialize(jsonReader, originalData.GetType()) as T;
    }

    protected JSONNode RetrieveRequiredNode(JSONNode node, string key)
    {
        if (!node.HasKey(key)) throw new ArgumentException($"{GetType().Name} missing required node \"{key}\".");
        return node[key];
    }

    /// <summary>
    ///     Determines if this object is found to be conflicting with <paramref name="other" />.
    /// </summary>
    /// <param name="other">Other object to check if they're conflicting.</param>
    /// <returns>Whether or not they are conflicting with each other.</returns>
    public virtual bool IsConflictingWith(BeatmapObject other, bool deletion = false)
        => Mathf.Abs(Time - other.Time) < BeatmapObjectContainerCollection.Epsilon
            && IsConflictingWithObjectAtSameTime(other, deletion);

    public override string ToString() => ConvertToJson().ToString();

    public virtual void Apply(BeatmapObject originalData) => TimeInMilliseconds = originalData.TimeInMilliseconds;

    // With how often this will get called, I think inlining will be necessary.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected float GetBeatsFromMilliseconds(float milliseconds)
        => BoomBoxSongContainer.Instance.Map.BeginningBPM / 60 * milliseconds / 1000;

    // With how often this will get called, I think inlining will be necessary.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected float GetMillisceondsFromBeats(float beats)
        => 60 / BoomBoxSongContainer.Instance.Map.BeginningBPM * beats * 1000;
}
