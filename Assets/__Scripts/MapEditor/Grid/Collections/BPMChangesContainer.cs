using System;
using System.Linq;
using UnityEngine;

public class BPMChangesContainer : BeatmapObjectContainerCollection
{
    // We cap the amount of BPM Changes in the shader to reduce memory and have it work on OpenGL/Vulkan/Metal.
    // Unless you have over 256 BPM Changes within a section of a song, this SHOULD be fine.
    public static readonly int MaxBpmChangesInShader = 256;

    private static readonly int times = Shader.PropertyToID("_BPMChange_Times");
    private static readonly int bpMs = Shader.PropertyToID("_BPMChange_BPMs");
    private static readonly int bpmCount = Shader.PropertyToID("_BPMChange_Count");

    private static readonly float firstVisibleBeatTime = 2;

    private static readonly float[] bpmShaderTimes = new float[MaxBpmChangesInShader];
    private static readonly float[] bpmShaderBpMs = new float[MaxBpmChangesInShader];

    [SerializeField] private GameObject bpmPrefab;
    [SerializeField] private MeasureLinesController measureLinesController;
    [SerializeField] private CountersPlusController countersPlus;

    public override BeatmapObject.ObjectType ContainerType => BeatmapObject.ObjectType.BpmChange;

    internal override void SubscribeToCallbacks()
    {
        EditorScaleController.EditorScaleChangedEvent += EditorScaleChanged;
        LoadInitialMap.LevelLoadedEvent += RefreshModifiedBeat;
        AudioTimeSyncController.TimeChanged += OnTimeChanged;
    }

    private void EditorScaleChanged(float obj) =>
        Shader.SetGlobalFloat("_EditorScale", EditorScaleController.EditorScale);

    private void OnTimeChanged()
    {
        if (AudioTimeSyncController.IsPlaying) return;
        RefreshGridProperties();
    }

    internal override void UnsubscribeToCallbacks()
    {
        EditorScaleController.EditorScaleChangedEvent -= EditorScaleChanged;
        LoadInitialMap.LevelLoadedEvent -= RefreshModifiedBeat;
        AudioTimeSyncController.TimeChanged -= OnTimeChanged;
    }

    protected override void OnObjectDelete(BeatmapObject obj)
    {
        RefreshModifiedBeat();
        countersPlus.UpdateStatistic(CountersPlusStatistic.BpmChanges);
    }

    protected override void OnObjectSpawned(BeatmapObject obj) =>
        countersPlus.UpdateStatistic(CountersPlusStatistic.BpmChanges);

    public void RefreshModifiedBeat()
    {
        BeatmapBPMChange lastChange = null;
        var songBpm = BoomBoxSongContainer.Instance.Map.BeginningBPM;

        foreach (var obj in LoadedObjects)
        {
            var bpmChange = obj as BeatmapBPMChange;

            if (lastChange == null)
            {
                bpmChange.Beat = Mathf.CeilToInt(bpmChange.Time);
            }
            else
            {
                var passedBeats = (bpmChange.Time - lastChange.Time - 0.01f) / songBpm * lastChange.Bpm;
                bpmChange.Beat = lastChange.Beat + Mathf.CeilToInt(passedBeats);
            }

            lastChange = bpmChange;
        }

        RefreshGridProperties();

        measureLinesController.RefreshMeasureLines();
    }

    public void RefreshGridProperties()
    {
        // Could probably save a tiny bit of performance since this should always be constant (0, Song BPM) but whatever
        var bpmChangeCount = 1;
        bpmShaderTimes[0] = 0;
        bpmShaderBpMs[0] = BoomBoxSongContainer.Instance.Map.BeginningBPM;

        // Grab the last object before grid ends
        var lastBpmChange = FindLastBpm(AudioTimeSyncController.CurrentBeat - firstVisibleBeatTime, false);

        // Plug this last bpm change in if it's not the starting BPM
        // Believe it or not, I cannot actually skip this BPM change if it exists
        if (lastBpmChange != null)
        {
            bpmChangeCount = 2;
            bpmShaderTimes[1] = lastBpmChange.Time;
            bpmShaderBpMs[1] = lastBpmChange.Bpm;
        }

        // Let's include all active, visible containers
        if (LoadedContainers.Count > 0)
        {
            // Ensure ordered by time (im not changing the entire collection to SortedSet just for this stfu)
            var activeBpmChanges = LoadedContainers.OrderBy(x => x.Key.Time);

            // Iterate over and copy time/bpm values to arrays, and increase count
            foreach (var bpmChangeKvp in activeBpmChanges)
            {
                if (bpmChangeCount >= MaxBpmChangesInShader)
                {
                    Debug.LogError(
                        @$":hyperPepega: :mega: THE CAP FOR BPM CHANGES IN THE SHADER IS {MaxBpmChangesInShader - 1}");
                    break;
                }

                var bpmChange = bpmChangeKvp.Key as BeatmapBPMChange;
                bpmShaderTimes[bpmChangeCount] = bpmChange.Time;
                bpmShaderBpMs[bpmChangeCount] = bpmChange.Bpm;
                bpmChangeCount++;
            }
        }

        // Pass all of this into our shader
        Shader.SetGlobalFloatArray(times, bpmShaderTimes);
        Shader.SetGlobalFloatArray(bpMs, bpmShaderBpMs);
        Shader.SetGlobalInt(bpmCount, bpmChangeCount);
    }

    protected override void OnContainerSpawn(BeatmapObjectContainer container, BeatmapObject obj)
        => RefreshGridProperties();

    protected override void OnContainerDespawn(BeatmapObjectContainer container, BeatmapObject obj)
        => RefreshGridProperties();

    public float FindRoundedBpmTime(float beatTimeInSongBpm, float snap = -1)
    {
        if (snap == -1) snap = 1f / AudioTimeSyncController.GridMeasureSnapping;

        var lastBpm = FindLastBpm(beatTimeInSongBpm); //Find the last BPM Change before our beat time
        
        if (lastBpm is null)
        {
            return (float)Math.Round(beatTimeInSongBpm / snap, MidpointRounding.AwayFromZero) *
                   snap; //If its null, return rounded song bpm
        }

        var songBpm = BoomBoxSongContainer.Instance.Map.BeginningBPM;

        var difference = beatTimeInSongBpm - lastBpm.Time;
        var differenceInBpmBeat = difference / songBpm * lastBpm.Bpm;
        var roundedDifference = (float)Math.Round(differenceInBpmBeat / snap, MidpointRounding.AwayFromZero) * snap;
        var roundedDifferenceInSongBpm = roundedDifference / lastBpm.Bpm * songBpm;
        return roundedDifferenceInSongBpm + lastBpm.Time;
    }

    /// <summary>
    ///     Find the last <see cref="BeatmapBPMChange" /> before a given beat time.
    /// </summary>
    /// <param name="beatTimeInSongBpm">Time in raw beats (Unmodified by any BPM Changes)</param>
    /// <param name="inclusive">Whether or not to include <see cref="BeatmapBPMChange" />s with the same time value.</param>
    /// <returns>The last <see cref="BeatmapBPMChange" /> before the given beat (or <see cref="null" /> if there is none).</returns>
    public BeatmapBPMChange FindLastBpm(float beatTimeInSongBpm, bool inclusive = true)
        => inclusive
            ? LoadedObjects.Where(x => x.Time <= beatTimeInSongBpm + 0.01f).LastOrDefault() as BeatmapBPMChange
            : LoadedObjects.Where(x => x.Time + 0.01f < beatTimeInSongBpm).LastOrDefault() as BeatmapBPMChange;

    /// <summary>
    ///     Find the next <see cref="BeatmapBPMChange" /> after a given beat time.
    /// </summary>
    /// <param name="beatTimeInSongBpm">Time in raw beats (Unmodified by any BPM Changes)</param>
    /// <param name="inclusive">Whether or not to include <see cref="BeatmapBPMChange" />s with the same time value.</param>
    /// <returns>The next <see cref="BeatmapBPMChange" /> after the given beat (or <see cref="null" /> if there is none).</returns>
    public BeatmapBPMChange FindNextBpm(float beatTimeInSongBpm, bool inclusive = false)
        => inclusive
            ? LoadedObjects.Where(x => x.Time >= beatTimeInSongBpm - 0.01f).FirstOrDefault() as BeatmapBPMChange
            : LoadedObjects.Where(x => x.Time - 0.01f > beatTimeInSongBpm).FirstOrDefault() as BeatmapBPMChange;

    /// <summary>
    ///     Calculates the number of beats in song BPM for a given number of beats in local BPM, accounting for all BPM
    ///     changes, relative to a starting position
    /// </summary>
    /// <param name="localBeats">Number of beats in local BPM</param>
    /// <param name="startBeat">The starting position from which to calculate. Number is in song BPM</param>
    /// <returns>The number of beats in song BPM equivalent to the number of beats in local bpm around a starting position</returns>
    public float LocalBeatsToSongBeats(float localBeats, float startBeat)
    {
        float totalSongBeats = 0;
        var localBeatsLeft = localBeats;
        var currentBeat = startBeat;
        var songBpm = BoomBoxSongContainer.Instance.Map.BeginningBPM;
        var currentBpm = FindLastBpm(startBeat)?.Bpm ?? songBpm;

        if (localBeats > 0)
        {
            var nextBpmChange = FindNextBpm(startBeat);
            while (localBeatsLeft > 0)
            {
                if (nextBpmChange is null)
                {
                    totalSongBeats += localBeatsLeft * songBpm / currentBpm;
                    break;
                }

                var distance = Math.Min(localBeatsLeft * songBpm / currentBpm, nextBpmChange.Time - currentBeat);
                totalSongBeats += distance;
                localBeatsLeft -= distance * currentBpm / songBpm;

                currentBeat = nextBpmChange.Time;
                currentBpm = nextBpmChange.Bpm;
                nextBpmChange = FindNextBpm(currentBeat);
            }
        }
        else
        {
            var lastBpmChange = FindLastBpm(startBeat, false);
            while (localBeatsLeft < 0)
            {
                if (lastBpmChange is null)
                {
                    totalSongBeats += localBeatsLeft;
                    break;
                }

                currentBpm = lastBpmChange.Bpm;

                var distance = Math.Max(localBeatsLeft * songBpm / currentBpm, lastBpmChange.Time - currentBeat);
                totalSongBeats += distance;
                localBeatsLeft -= distance * currentBpm / songBpm;

                currentBeat = lastBpmChange.Time;
                lastBpmChange = FindLastBpm(currentBeat, false);
            }
        }

        return totalSongBeats;
    }

    public override BeatmapObjectContainer CreateContainer() =>
        BeatmapBPMChangeContainer.SpawnBpmChange(null, ref bpmPrefab);

    protected override void UpdateContainerData(BeatmapObjectContainer con, BeatmapObject obj)
    {
        var container = con as BeatmapBPMChangeContainer;
        container.UpdateBpmText();
    }
}
