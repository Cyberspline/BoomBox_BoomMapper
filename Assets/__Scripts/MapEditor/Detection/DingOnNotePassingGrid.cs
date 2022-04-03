using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class DingOnNotePassingGrid : MonoBehaviour
{
    public static Dictionary<int, bool> NoteTypeToDing = new Dictionary<int, bool>
    {
        {BeatmapNote.NoteTypeA, true}, {BeatmapNote.NoteTypeB, true}
    };

    [SerializeField] private AudioTimeSyncController atsc;
    [SerializeField] private SoundList[] soundLists;
    [FormerlySerializedAs("ThresholdInNoteTime")] [SerializeField] private float thresholdInNoteTime = 0.25f;
    [SerializeField] private AudioUtil audioUtil;
    [SerializeField] private NotesContainer container;
    [SerializeField] private BeatmapObjectCallbackController defaultCallbackController;

    private float lastCheckedTime;

    private float offset;
    private float songSpeed = 1;

    private void Start()
    {
        NoteTypeToDing[BeatmapNote.HandLeft] = Settings.Instance.Ding_Red_Notes;
        NoteTypeToDing[BeatmapNote.HandRight] = Settings.Instance.Ding_Blue_Notes;

        atsc.PlayToggle += OnPlayToggle;
    }

    private void OnEnable()
    {
        Settings.NotifyBySettingName("Ding_Red_Notes", UpdateRedNoteDing);
        Settings.NotifyBySettingName("Ding_Blue_Notes", UpdateBlueNoteDing);
        Settings.NotifyBySettingName("Ding_Bombs", UpdateBombDing);
        Settings.NotifyBySettingName("SongSpeed", UpdateSongSpeed);

        defaultCallbackController.NotePassedThreshold += PlaySound;
    }

    private void OnDisable()
    {
        defaultCallbackController.NotePassedThreshold -= PlaySound;

        Settings.ClearSettingNotifications("Ding_Red_Notes");
        Settings.ClearSettingNotifications("Ding_Blue_Notes");
        Settings.ClearSettingNotifications("Ding_Bombs");
        Settings.ClearSettingNotifications("SongSpeed");
    }

    private void OnDestroy() => atsc.PlayToggle -= OnPlayToggle;

    private void UpdateSongSpeed(object value)
    {
        var speedValue = (float)Convert.ChangeType(value, typeof(float));
        songSpeed = speedValue / 10f;
    }

    private void OnPlayToggle(bool playing)
    {
        lastCheckedTime = -1;
        audioUtil.StopOneShot();
        if (playing)
        {
            var now = atsc.CurrentSongBeats;
            var notes = container.GetBetween(now, now + 0.5f);

            // Schedule notes between now and threshold
            foreach (var n in notes) PlaySound(false, 0, n);
        }
    }

    private void UpdateRedNoteDing(object obj) => NoteTypeToDing[BeatmapNote.NoteTypeA] = (bool)obj;

    private void UpdateBlueNoteDing(object obj) => NoteTypeToDing[BeatmapNote.NoteTypeB] = (bool)obj;

    private void UpdateBombDing(object obj) => NoteTypeToDing[BeatmapNote.NoteTypeBomb] = (bool)obj;

    private void PlaySound(bool initial, int index, BeatmapObject objectData)
    {
        if (!(objectData is BeatmapNote note)) return;

        // Should be cached because Time is a property that converts MS to Beats
        var time = note.Time;

        // Filter notes that are too far behind the current beat
        // (Commonly occurs when Unity freezes for some unrelated fucking reason)
        if (time - container.AudioTimeSyncController.CurrentBeat <= -0.5f) return;

        //actual ding stuff
        if (time == lastCheckedTime || !NoteTypeToDing[note.Hand]) return;

        /*
         * As for why we are not using "initial", it is so notes that are not supposed to ding do not prevent notes at
         * the same time that are supposed to ding from triggering the sound effects.
         */
        lastCheckedTime = time;
        var soundListId = Settings.Instance.NoteHitSound;
        var list = soundLists[soundListId];

        var shortCut = time - lastCheckedTime < thresholdInNoteTime;

        var timeUntilDing = time - atsc.CurrentSongBeats;
        var hitTime = (atsc.GetSecondsFromBeat(timeUntilDing) / songSpeed) - offset;
        audioUtil.PlayOneShotSound(list.GetRandomClip(shortCut), Settings.Instance.NoteHitVolume, 1, hitTime);
    }
}
