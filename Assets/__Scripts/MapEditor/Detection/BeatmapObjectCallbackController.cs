using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

//Name and idea totally not stolen directly from Beat Saber
public class BeatmapObjectCallbackController : MonoBehaviour
{
    private static readonly int notesToLookAhead = 25;

    [SerializeField] private NotesContainer notesContainer;

    [SerializeField] private AudioTimeSyncController timeSyncController;

    [SerializeField] private bool useOffsetFromConfig = true;

    [Tooltip("Whether or not to use the Despawn or Spawn offset from settings.")]
    [SerializeField]
    private bool useDespawnOffset;

    [FormerlySerializedAs("offset")] public float Offset;

    [SerializeField] private int nextNoteIndex;

    [FormerlySerializedAs("useAudioTime")] public bool UseAudioTime;

    private readonly HashSet<BeatmapObject> nextNotes = new HashSet<BeatmapObject>();
    private HashSet<BeatmapObject> allNotes = new HashSet<BeatmapObject>();
    private HashSet<BeatmapObject> queuedToClear = new HashSet<BeatmapObject>();

    private float curTime;
    public Action<bool, int, BeatmapObject> EventPassedThreshold;

    public Action<bool, int, BeatmapObject> NotePassedThreshold;
    public Action<bool, int> RecursiveEventCheckFinished;
    public Action<bool, int> RecursiveNoteCheckFinished;

    private void LateUpdate()
    {
        if (useOffsetFromConfig)
        {
            Offset = useDespawnOffset
                ? Settings.Instance.Offset_Despawning * -1
                : Settings.Instance.Offset_Spawning;

            if (!useDespawnOffset) Shader.SetGlobalFloat("_ObstacleFadeRadius", Offset * EditorScaleController.EditorScale);
        }

        if (queuedToClear.Count > 0)
        {
            foreach (var toClear in queuedToClear)
            {
                allNotes.Remove(toClear);
                nextNotes.Remove(toClear);
            }

            queuedToClear.Clear();
        }

        if (timeSyncController.IsPlaying)
        {
            curTime = UseAudioTime ? timeSyncController.CurrentSongBeats : timeSyncController.CurrentBeat;
            RecursiveCheckNotes(true, true);
        }
    }

    private void OnEnable()
    {
        notesContainer.ObjectSpawnedEvent += NotesContainer_ObjectSpawnedEvent;
        notesContainer.ObjectDeletedEvent += NotesContainer_ObjectDeletedEvent;
        timeSyncController.PlayToggle += OnPlayToggle;
    }

    private void OnDisable()
    {
        notesContainer.ObjectSpawnedEvent -= NotesContainer_ObjectSpawnedEvent;
        notesContainer.ObjectDeletedEvent -= NotesContainer_ObjectDeletedEvent;
        timeSyncController.PlayToggle -= OnPlayToggle;
    }

    private void OnPlayToggle(bool playing)
    {
        if (playing)
        {
            CheckAllNotes(false);
        }
    }

    private void CheckAllNotes(bool natural)
    {
        //notesContainer.SortObjects();
        curTime = UseAudioTime ? timeSyncController.CurrentSongBeats : timeSyncController.CurrentBeat;
        allNotes.Clear();
        allNotes = new HashSet<BeatmapObject>(notesContainer.LoadedObjects.Where(x => x.Time >= curTime + Offset));

        nextNoteIndex = notesContainer.LoadedObjects.Count - allNotes.Count;
        RecursiveNoteCheckFinished?.Invoke(natural, nextNoteIndex - 1);
        nextNotes.Clear();

        for (var i = 0; i < notesToLookAhead; i++)
        {
            if (allNotes.Count > 0) QueueNextObject(allNotes, nextNotes);
        }
    }

    private void RecursiveCheckNotes(bool init, bool natural)
    {
        var passed = nextNotes.Where(x => x.Time <= curTime + Offset).ToArray();
        foreach (var newlyAdded in passed)
        {
            if (natural) NotePassedThreshold?.Invoke(init, nextNoteIndex, newlyAdded);
            nextNotes.Remove(newlyAdded);
            if (allNotes.Count > 0 && natural) QueueNextObject(allNotes, nextNotes);
            nextNoteIndex++;
        }
    }

    private void NotesContainer_ObjectSpawnedEvent(BeatmapObject obj) => OnObjSpawn(obj, nextNotes);

    private void NotesContainer_ObjectDeletedEvent(BeatmapObject obj) => OnObjDeleted(obj);

    private void OnObjSpawn(BeatmapObject obj, HashSet<BeatmapObject> nextObjects)
    {
        if (!timeSyncController.IsPlaying) return;

        if (obj.Time >= timeSyncController.CurrentBeat)
        {
            nextObjects.Add(obj);
        }
    }

    private void OnObjDeleted(BeatmapObject obj)
    {
        if (!timeSyncController.IsPlaying) return;

        if (obj.Time >= timeSyncController.CurrentBeat)
        {
            queuedToClear.Add(obj);
        }
    }

    private void QueueNextObject(HashSet<BeatmapObject> allObjs, HashSet<BeatmapObject> nextObjs)
    {
        // Assumes that the "Count > 0" check happens before this is called
        var first = allObjs.First();
        nextObjs.Add(first);
        allObjs.Remove(first);
    }
}
