using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SongList : MonoBehaviour
{
    public enum SongSortType
    {
        Name, Modified, Artist
    }

    private static readonly IComparer<BoomBoxPackBase> sortName =
        new WithFavouriteComparer((a, b) =>
            string.Compare(a.SongTitle, b.SongTitle, StringComparison.InvariantCultureIgnoreCase));

    private static readonly IComparer<BoomBoxPackBase> sortModified =
        new WithFavouriteComparer((a, b) =>
        {
            if (a is BoomBoxCustomPack customA && b is BoomBoxCustomPack customB)
            {
                return customA.LastWriteTime.CompareTo(customB.LastWriteTime);
            }
            else if (a is BoomBoxOfficialPack officialA && b is BoomBoxOfficialPack officialB)
            {
                return officialA.SongId.Value.CompareTo(officialB.SongId.Value);
            }

            return a.GetHashCode().CompareTo(b.GetHashCode());
        });

    private static readonly IComparer<BoomBoxPackBase> sortArtist =
        new WithFavouriteComparer((a, b) =>
            string.Compare(a.SongArtist, b.SongArtist, StringComparison.InvariantCultureIgnoreCase));

    private static bool lastVisitedWasWip = true;

    public SortedSet<BoomBoxPackBase> Songs = new SortedSet<BoomBoxPackBase>(sortName);

    public bool WipLevels = true;
    public bool FilteredBySearch;

    [SerializeField] private TMP_InputField searchField;
    [SerializeField] private Image sortImage;
    [SerializeField] private Sprite nameSortSprite;
    [SerializeField] private Sprite modifiedSortSprite;
    [SerializeField] private Sprite artistSortSprite;

    [SerializeField] private Color normalTabColor;
    [SerializeField] private Color selectedTabColor;
    [SerializeField] private Image wipTab;
    [SerializeField] private Image customTab;

    [SerializeField] private RecyclingListView newList;
    private SongSortType currentSort = SongSortType.Name;

    private List<BoomBoxPackBase> filteredLocalSongs = new List<BoomBoxPackBase>();

    private void Start()
    {
        newList.ItemCallback = (item, index) =>
        {
            if (item is SongListItem child) child.AssignSong(filteredLocalSongs[index], searchField.text);
        };

        currentSort = (SongSortType)Settings.Instance.LastSongSortType;
        ApplySort(currentSort);

        SortTypeChanged?.Invoke(currentSort);
        SetSongLocation(lastVisitedWasWip);
    }

    public event Action<SongSortType> SortTypeChanged;

    private void SwitchSort(IComparer<BoomBoxPackBase> newSort, Sprite sprite)
    {
        sortImage.sprite = sprite;
        Songs = new SortedSet<BoomBoxPackBase>(Songs, newSort);
        UpdateSongList();
    }

    public void NextSort()
    {
        currentSort = currentSort switch
        {
            SongSortType.Name => SongSortType.Modified,
            SongSortType.Modified => SongSortType.Artist,
            _ => SongSortType.Name,
        };
        ApplySort(currentSort);

        Settings.Instance.LastSongSortType = (int)currentSort;

        SortTypeChanged?.Invoke(currentSort);
    }

    public void ApplySort(SongSortType sortType)
    {
        switch (sortType)
        {
            case SongSortType.Name:
                SwitchSort(sortName, nameSortSprite);
                break;
            case SongSortType.Modified:
                SwitchSort(sortModified, modifiedSortSprite);
                break;
            default:
                SwitchSort(sortArtist, artistSortSprite);
                break;
        }
    }

    public void ToggleSongLocation() => SetSongLocation(!WipLevels);

    public void SetSongLocation(bool wip)
    {
        lastVisitedWasWip = WipLevels = wip;
        wipTab.color = wip ? selectedTabColor : normalTabColor;
        customTab.color = !wip ? selectedTabColor : normalTabColor;
        TriggerRefresh();
    }

    public void TriggerRefresh()
    {
        StopAllCoroutines();
        StartCoroutine(RefreshSongList());
    }

    public IEnumerator RefreshSongList()
    {
        Songs.Clear();
        newList.Clear();

        if (!WipLevels)
        {
            yield return StartCoroutine(BoomBoxAPI.AuthenticateUser());

            var page = 1;

            BoomBoxOfficialSongListResponse songListResponse = null;

            do
            {
                var request = BoomBoxAPI.CreateAuthenticatedRequest(BoomBoxAPI.SongListEndpoint);
                request.url = $"{request.url}?page={page}";

                yield return request.SendWebRequest();

                if (request.result != UnityEngine.Networking.UnityWebRequest.Result.Success || request.responseCode != 200)
                {
                    PersistentUI.Instance.ShowDialogBox($"Error while loading official songs ({request.responseCode}): {request.error}",
                        null, PersistentUI.DialogBoxPresetType.Ok);

                    UpdateSongList();

                    yield break;
                }

                try
                {
                    using var memorySream = new MemoryStream(request.downloadHandler.data);
                    using var textReader = new StreamReader(memorySream);
                    using var reader = new JsonTextReader(textReader);

                    songListResponse = JsonSerializer.CreateDefault().Deserialize<BoomBoxOfficialSongListResponse>(reader);

                    Debug.Log($"Loaded page {page}.");

                    foreach (var officialPack in songListResponse.OfficialPacks)
                    {
                        Songs.Add(officialPack);
                    }

                    UpdateSongList();
                }
                catch
                {
                    Debug.LogError($"Error while loading page {page}.");
                    Debug.LogError(System.Text.Encoding.Default.GetString(request.downloadHandler.data));
                }

                page++;

                yield return null;
            } while (songListResponse != null && !string.IsNullOrEmpty(songListResponse.NextUrl));
        }
        else
        {
            // Iterate over .bom archives and extract the packs from them
            foreach (var archive in Directory.GetFiles(Settings.Instance.CustomSongsFolder, "*.bom"))
            {
                Debug.LogWarning($"Found .bom archive: {archive}");

                var newDirectory = archive.Substring(0, archive.Length - 4);

                if (!Directory.Exists(newDirectory))
                {
                    using var reader = File.OpenRead(archive);
                    using var zip = new ZipArchive(reader, ZipArchiveMode.Read);

                    Directory.CreateDirectory(newDirectory);
                    zip.ExtractToDirectory(newDirectory);
                }

                File.Delete(archive);
            }

            var directories = Directory.GetDirectories(Settings.Instance.CustomSongsFolder);
            var iterBeginTime = Time.realtimeSinceStartup;
            foreach (var dir in directories)
            {
                if (Time.realtimeSinceStartup - iterBeginTime > 0.02f)
                {
                    UpdateSongList();
                    yield return null;
                    iterBeginTime = Time.realtimeSinceStartup;
                }

                var song = BoomBoxCustomPack.GetPackFromDirectory(dir);
                if (song == null)
                    Debug.LogWarning($"No song at location {dir} exists! Is it in a subfolder?");
                else
                    Songs.Add(song);
            }
        }

        UpdateSongList();
    }

    public void UpdateSongList()
    {
        FilteredBySearch = !string.IsNullOrEmpty(searchField.text);
        if (FilteredBySearch)
        {
            FilterBySearch();
        }
        else
        {
            filteredLocalSongs = Songs.ToList();
            ReloadListItems();
        }
    }

    public void FilterBySearch()
    {
        filteredLocalSongs = Songs.Where(x =>
            x.SongTitle.IndexOf(searchField.text, StringComparison.InvariantCultureIgnoreCase) >= 0 ||
            x.SongArtist.IndexOf(searchField.text, StringComparison.InvariantCultureIgnoreCase) >= 0).ToList();
        ReloadListItems();
    }

    private void ReloadListItems()
    {
        if (newList.RowCount != filteredLocalSongs.Count)
            newList.RowCount = filteredLocalSongs.Count;
        else
            newList.Refresh();
    }

    public void RemoveSong(BoomBoxPackBase song) => Songs.Remove(song);

    public void AddSong(BoomBoxPackBase song)
    {
        Songs.Add(song);
        UpdateSongList();
        /*if (song.IsFavourite)
        {
            newList.ScrollToRow(filteredSongs.IndexOf(song));
        }*/
    }

    private class FuncComparer<T> : IComparer<T>
    {
        private readonly Comparison<T> comparison;

        protected FuncComparer(Comparison<T> comparison) => this.comparison = comparison;

        public virtual int Compare(T x, T y)
        {
            var result = comparison(x, y);
            return result == 0 && x != null ? x.GetHashCode().CompareTo(y?.GetHashCode()) : result;
        }
    }

    private class WithFavouriteComparer : FuncComparer<BoomBoxPackBase>
    {
        public WithFavouriteComparer(Comparison<BoomBoxPackBase> comparison) : base(comparison) { }

        public override int Compare(BoomBoxPackBase a, BoomBoxPackBase b) =>
            a?.IsFavourite != b?.IsFavourite ? a?.IsFavourite == true ? -1 : 1 : base.Compare(a, b);
    }
}
