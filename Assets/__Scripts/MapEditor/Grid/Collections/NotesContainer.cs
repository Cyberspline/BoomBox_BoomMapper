using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class NotesContainer : BeatmapObjectContainerCollection
{
    [SerializeField] private GameObject notePrefab;
    [FormerlySerializedAs("noteAppearanceSO")] [SerializeField] private NoteAppearanceSO noteAppearanceSo;
    [SerializeField] private TracksManager tracksManager;

    [SerializeField] private CountersPlusController countersPlus;

    public override BeatmapObject.ObjectType ContainerType => BeatmapObject.ObjectType.Note;

    internal override void SubscribeToCallbacks()
    {
        SpawnCallbackController.NotePassedThreshold += SpawnCallback;
        SpawnCallbackController.RecursiveNoteCheckFinished += RecursiveCheckFinished;
        DespawnCallbackController.NotePassedThreshold += DespawnCallback;
        AudioTimeSyncController.PlayToggle += OnPlayToggle;

        Settings.NotifyBySettingName(nameof(Settings.LeftColor), OnColorsChanged);
        Settings.NotifyBySettingName(nameof(Settings.RightColor), OnColorsChanged);
        noteAppearanceSo.UpdateColor(Settings.Instance.LeftColor, Settings.Instance.RightColor);
    }

    internal override void UnsubscribeToCallbacks()
    {
        SpawnCallbackController.NotePassedThreshold -= SpawnCallback;
        SpawnCallbackController.RecursiveNoteCheckFinished += RecursiveCheckFinished;
        DespawnCallbackController.NotePassedThreshold -= DespawnCallback;
        AudioTimeSyncController.PlayToggle -= OnPlayToggle;

        Settings.ClearSettingNotifications(nameof(Settings.LeftColor));
        Settings.ClearSettingNotifications(nameof(Settings.RightColor));
    }

    private void OnColorsChanged(object _)
    {
        noteAppearanceSo.UpdateColor(Settings.Instance.LeftColor, Settings.Instance.RightColor);
        RefreshPool(true);
    }

    private void OnPlayToggle(bool isPlaying)
    {
        if (!isPlaying) RefreshPool();
    }

    // This should hopefully return a sorted list of notes to prevent flipped stack notes when playing in game.
    // (I'm done with note sorting; if you don't like it, go fix it yourself.)
    public override IEnumerable<BeatmapObject> GrabSortedObjects()
    {
        var sorted = new List<BeatmapObject>();
        var grouping = LoadedObjects.GroupBy(x => x.Time);
        foreach (var group in grouping)
        {
            sorted.AddRange(@group.OrderBy(x => ((BeatmapNote)x).LineIndex) //0 -> 3
                .ThenBy(x => ((BeatmapNote)x).LineLayer) //0 -> 2
                .ThenBy(x => ((BeatmapNote)x).Type));
        }

        return sorted;
    }

    //We don't need to check index as that's already done further up the chain
    private void SpawnCallback(bool initial, int index, BeatmapObject objectData) => CreateContainerFromPool(objectData);

    //We don't need to check index as that's already done further up the chain
    private void DespawnCallback(bool initial, int index, BeatmapObject objectData) => RecycleContainer(objectData);

    private void RecursiveCheckFinished(bool natural, int lastPassedIndex) => RefreshPool();

    public void UpdateSwingArcVisualizer()
    {
    }

    public override BeatmapObjectContainer CreateContainer()
    {
        BeatmapObjectContainer con = BeatmapNoteContainer.SpawnBeatmapNote(null, ref notePrefab);
        return con;
    }

    protected override void UpdateContainerData(BeatmapObjectContainer con, BeatmapObject obj)
    {
        var note = con as BeatmapNoteContainer;
        var noteData = obj as BeatmapNote;
        noteAppearanceSo.SetNoteAppearance(note);
        note.Setup();
        note.transform.localEulerAngles = BeatmapNoteContainer.Directionalize(noteData);

        var track = tracksManager.GetTrackAtTime(obj.Time);
        track.AttachContainer(con);
    }

    protected override void OnObjectSpawned(BeatmapObject _) =>
        countersPlus.UpdateStatistic(CountersPlusStatistic.Notes);

    protected override void OnObjectDelete(BeatmapObject _) =>
        countersPlus.UpdateStatistic(CountersPlusStatistic.Notes);
}
