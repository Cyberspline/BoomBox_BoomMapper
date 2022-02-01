using System.Collections;
using System.IO;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class RefreshMapController : MonoBehaviour, CMInput.IRefreshMapActions
{
    [SerializeField] private MapLoader loader;
    [SerializeField] private TracksManager tracksManager;
    [SerializeField] private AudioTimeSyncController atsc;
    [SerializeField] private TMP_FontAsset cancelFontAsset;
    [SerializeField] private TMP_FontAsset thingYouCanRefreshFontAsset;

    public void OnRefreshMap(InputAction.CallbackContext context)
    {
        if (context.performed)
            InitiateRefreshConversation();
    }

    public void InitiateRefreshConversation() =>
        PersistentUI.Instance.ShowDialogBox("Mapper", "refreshmap",
            HandleFirstLayerConversation,
            new[]
            {
                "refreshmap.notes", "refreshmap.walls", "refreshmap.events", "refreshmap.other", "refreshmap.full",
                "refreshmap.cancel"
            },
            new[]
            {
                thingYouCanRefreshFontAsset, thingYouCanRefreshFontAsset, thingYouCanRefreshFontAsset,
                thingYouCanRefreshFontAsset, thingYouCanRefreshFontAsset, cancelFontAsset
            });

    private void HandleFirstLayerConversation(int res)
    {
        switch (res)
        {
            case 0:
                StartCoroutine(RefreshMap(true, false, false, false, false));
                break;
            case 1:
                StartCoroutine(RefreshMap(false, true, false, false, false));
                break;
            case 2:
                StartCoroutine(RefreshMap(false, false, true, false, false));
                break;
            case 3:
                StartCoroutine(RefreshMap(false, false, false, true, false));
                break;
            case 4:
                StartCoroutine(RefreshMap(false, false, false, false, true));
                break;
        }
    }

    private IEnumerator RefreshMap(bool notes, bool obstacles, bool events, bool others, bool full)
    {
        yield return PersistentUI.Instance.FadeInLoadingScreen();

        var json = JsonSerializer.CreateDefault();
        using var reader = new StreamReader(BoomBoxSongContainer.Instance.Map.FileInfo.FullName);
        using var jsonReader = new JsonTextReader(reader);

        var map = json.Deserialize<BoomBoxMap>(jsonReader);
        BoomBoxSongContainer.Instance.Map = map;
        
        var currentBeat = atsc.CurrentBeat;
        atsc.MoveToTimeInBeats(0);

        if (notes || full) yield return StartCoroutine(loader.LoadObjects(map.Objects));
        if (obstacles || full) yield return StartCoroutine(loader.LoadObjects(map.Obstacles));
        if (others || full) yield return StartCoroutine(loader.LoadObjects(map.TimingPoints));

        tracksManager.RefreshTracks();
        SelectionController.RefreshMap();

        atsc.MoveToTimeInBeats(currentBeat);
        
        yield return PersistentUI.Instance.FadeOutLoadingScreen();
    }
}
