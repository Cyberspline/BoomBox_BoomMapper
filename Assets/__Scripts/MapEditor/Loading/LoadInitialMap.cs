using System;
using System.Collections;
using UnityEngine;

public class LoadInitialMap : MonoBehaviour
{
    public static Action LevelLoadedEvent;

    [SerializeField] private AudioTimeSyncController atsc;
    [SerializeField] private MapLoader loader;

    private void Awake() => SceneTransitionManager.Instance.AddLoadRoutine(LoadMap());

    public IEnumerator LoadMap()
    {
        if (BoomBoxSongContainer.Instance == null) yield break;
        PersistentUI.Instance.LevelLoadSliderLabel.text = "";

        // Wait until Start has been called
        yield return new WaitUntil(() => atsc.Initialized);

        yield return StartCoroutine(loader.HardRefresh());

        LevelLoadedEvent?.Invoke();
    }
}
