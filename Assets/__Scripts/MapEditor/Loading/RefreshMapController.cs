using System.Collections;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.InputSystem;

public class RefreshMapController : MonoBehaviour, CMInput.IRefreshMapActions
{
    [SerializeField] private MapLoader loader;
    [SerializeField] private TracksManager tracksManager;
    [SerializeField] private AudioTimeSyncController atsc;

    public void OnRefreshMap(InputAction.CallbackContext context)
    {
        if (context.performed)
            InitiateRefreshConversation();
    }

    public void InitiateRefreshConversation() =>
        PersistentUI.Instance.ShowDialogBox("Mapper", "refreshmap",
            HandleFirstLayerConversation, PersistentUI.DialogBoxPresetType.YesNo);

    private void HandleFirstLayerConversation(int res)
    {
        if (res == 0) StartCoroutine(RefreshMap());
    }

    private IEnumerator RefreshMap()
    {
        yield return PersistentUI.Instance.FadeInLoadingScreen();

        var json = JsonSerializer.CreateDefault();
        using var reader = new StreamReader(BoomBoxSongContainer.Instance.Map.FileInfo.FullName);
        using var jsonReader = new JsonTextReader(reader);

        var map = json.Deserialize<BoomBoxMap>(jsonReader);
        map.FileInfo = BoomBoxSongContainer.Instance.Map.FileInfo;

        BoomBoxSongContainer.Instance.Map = map;
        
        var currentBeat = atsc.CurrentBeat;
        atsc.MoveToTimeInBeats(0);

        yield return StartCoroutine(loader.HardRefresh());

        tracksManager.RefreshTracks();
        SelectionController.RefreshMap();

        atsc.MoveToTimeInBeats(currentBeat);
        
        yield return PersistentUI.Instance.FadeOutLoadingScreen();
    }
}
