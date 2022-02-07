using System;
using System.Collections;
using UnityEngine;

public class LoadInitialMap : MonoBehaviour
{
    public static Action<PlatformDescriptor> PlatformLoadedEvent;
    public static Action LevelLoadedEvent;
    public static readonly Vector3 PlatformOffset = new Vector3(0, -0.5f, -1.5f);

    [SerializeField] private AudioTimeSyncController atsc;
    [SerializeField] private MapLoader loader;
    [SerializeField] private PlatformDescriptor basicPlatform;

    private void Awake() => SceneTransitionManager.Instance.AddLoadRoutine(LoadMap());

    public IEnumerator LoadMap()
    {
        if (BoomBoxSongContainer.Instance == null) yield break;
        PersistentUI.Instance.LevelLoadSliderLabel.text = "";

        // Wait until Start has been called
        yield return new WaitUntil(() => atsc.Initialized);

        // TODO: Remove, replace with BoomBox biomes (maybe)
        var platform = Instantiate(basicPlatform, PlatformOffset, Quaternion.identity);
        PlatformLoadedEvent?.Invoke(platform);
        platform.gameObject.SetActive(false);

        yield return StartCoroutine(loader.HardRefresh());

        LevelLoadedEvent?.Invoke();
    }
}
