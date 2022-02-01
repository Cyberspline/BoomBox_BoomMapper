using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MapLoader : MonoBehaviour
{
    [SerializeField] private TracksManager manager;
    [SerializeField] private NoteLanesController noteLanesController;

    public IEnumerator HardRefresh()
    {
        var map = BoomBoxSongContainer.Instance.Map;

        if (Settings.Instance.Load_Notes) yield return StartCoroutine(LoadObjects(map.Objects));
        if (Settings.Instance.Load_Obstacles) yield return StartCoroutine(LoadObjects(map.Obstacles));
        if (Settings.Instance.Load_Others)
        {
            yield return StartCoroutine(LoadObjects(map.TimingPoints));
        }

        PersistentUI.Instance.LevelLoadSliderLabel.text = "Finishing up...";
        manager.RefreshTracks();
        SelectionController.RefreshMap();
        PersistentUI.Instance.LevelLoadSlider.gameObject.SetActive(false);
    }

    public IEnumerator LoadObjects<T>(IEnumerable<T> objects) where T : BeatmapObject
    {
        if (!objects.Any()) yield break;

        var collection = BeatmapObjectContainerCollection.GetCollectionForType(objects.First().BeatmapType);

        if (collection == null) yield break;

        foreach (var obj in collection.UnsortedObjects.ToArray()) collection.DeleteObject(obj, false, false);

        PersistentUI.Instance.LevelLoadSlider.gameObject.SetActive(true);

        collection.LoadedObjects = new SortedSet<BeatmapObject>(objects, new BeatmapObjectComparer());
        collection.UnsortedObjects = collection.LoadedObjects.ToList();

        PersistentUI.Instance.LevelLoadSliderLabel.text = $"Loading {nameof(T)}s... ";
        PersistentUI.Instance.LevelLoadSlider.value = 1;

        collection.RefreshPool(true);
    }
}
