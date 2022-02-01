using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;
using static BeatSaberSong;

public class DifficultySelect : MonoBehaviour
{
    [SerializeField] private TMP_InputField bpmField;
    [SerializeField] private Color copyColor;
    [SerializeField] private DifficultyInfo difficultyInfo;

    private readonly HashSet<DifficultyRow> rows = new HashSet<DifficultyRow>();
    private CopySource copySource;
    private DifficultyBeatmapSet currentCharacteristic;
    private Dictionary<string, DifficultySettings> diffs = new Dictionary<string, DifficultySettings>();

    private bool loading;
    private DifficultyRow selected;

    public BoomBoxMap CurrentDiff => diffs[selected.Name].Map;

    private BoomBoxPack Song => BoomBoxSongContainer.Instance != null ? BoomBoxSongContainer.Instance.Pack : null;

    /// <summary>
    ///     Load song data and set up listeners on UI elements
    /// </summary>
    public void Start()
    {
        foreach (Transform child in transform)
        {
            // Add event listeners, it's hard to do this staticly as the rows are prefabs
            // so they can't access the parent object with this script
            var row = new DifficultyRow(child);
            rows.Add(row);

            row.Toggle.onValueChanged.AddListener(val => OnChange(row, val));
            row.Button.onClick.AddListener(() => OnClick(row));
            row.NameInput.onValueChanged.AddListener(name => OnValueChanged(row, name));
            row.Copy.onClick.AddListener(() => SetCopySource(row));
            row.Save.onClick.AddListener(() => SaveDiff(row));
            row.Revert.onClick.AddListener(() => Revertdiff(row));
            row.Paste.onClick.AddListener(() => DoPaste(row));
        }

        if (Song?.Maps?.Any() ?? false)
        {
            for (var i = 0; i < Song.Maps.Count; i++)
            {
                diffs.Add(rows.ElementAt(i).Name, new DifficultySettings(Song.Maps[i]));
            }
        }

        LoadDifficulties();
    }

    /// <summary>
    ///     Update the offset of the selected diff
    ///     If there's no selected diff this just goes into oblivion
    /// </summary>
    public void UpdateOffset()
    {
        if (selected == null || !diffs.ContainsKey(selected.Name)) return;

        var diff = diffs[selected.Name];

        selected.ShowDirtyObjects(diff);
    }

    /// <summary>
    ///     Update the NJS of the selected diff
    ///     If there's no selected diff this just goes into oblivion
    /// </summary>
    public void UpdateNJS()
    {
        if (selected == null || !diffs.ContainsKey(selected.Name)) return;

        var diff = diffs[selected.Name];

        selected.ShowDirtyObjects(diff);
    }

    [Obsolete("BoomBox does not support environment enhancement.")]
    public void UpdateEnvRemoval() { }

    /// <summary>
    ///     Revert the diff to the saved version
    /// </summary>
    /// <param name="obj">UI row that was clicked on</param>
    private void Revertdiff(DifficultyRow row)
    {
        var localDiff = diffs[row.Name];
        localDiff.Revert();

        row.NameInput.text = localDiff.CustomName;

        row.ShowDirtyObjects(localDiff);
    }

    private BoomBoxMap TryGetExistingMapFromDiff(DifficultySettings diff) => diff?.Map ?? null;

    /// <summary>
    ///     Save the diff
    /// </summary>
    /// <param name="row">UI row that was clicked on</param>
    private void SaveDiff(DifficultyRow row)
    {
        var localSong = BoomBoxSongContainer.Instance.Pack;

        if (localSong.Directory == null)
            localSong.Save();

        var localDiff = diffs[row.Name];
        var firstSave = localDiff.ForceDirty;
        localDiff.Commit();
        row.ShowDirtyObjects(false, true);

        // Try to get the existing map, or create a new map if none exist
        var map = TryGetExistingMapFromDiff(localDiff) ?? new BoomBoxMap()
        {
            TimeCreated = DateTime.Now.ToUniversalTime().ToString("o"),
        };

        var oldPath = map.FileInfo;

        // Enforce constant starting BPM for diffs
        if (!float.TryParse(bpmField.text, out var bpm))
        {
            bpm = 120;
        }

        if ((map.TimingPoints ??= new List<BeatmapBPMChange>()).Find(x => x.TimeInMilliseconds == 0).Bpm != bpm)
        {
            map.TimingPoints.RemoveAll(x => x.TimeInMilliseconds == 0);
            map.TimingPoints.Add(new BeatmapBPMChange(bpm, 0));
        }

        map.FileInfo = new FileInfo(Path.Combine(localSong.Directory, localDiff.CustomName));

        if (oldPath.Exists && oldPath != map.FileInfo && !map.FileInfo.Exists)
        {
            // This should properly "convert" difficulties just fine
            if (firstSave)
                File.Copy(oldPath.FullName, map.FileInfo.FullName);
            else
                File.Move(oldPath.FullName, map.FileInfo.FullName);
        }
        else
        {
            map.Save();
        }

        localSong.Save();

        Debug.Log("Saved " + row.Name);
    }

    /// <summary>
    ///     Handle changes to the difficulty label
    /// </summary>
    /// <param name="row">UI row that was updated</param>
    /// <param name="difficultyLabel">New label value</param>
    private void OnValueChanged(DifficultyRow row, string difficultyLabel)
    {
        if (!diffs.ContainsKey(row.Name)) return;

        var diff = diffs[row.Name];

        // Expert+ is special as the only difficulty that is different in JSON
        diff.CustomName = difficultyLabel;

        row.ShowDirtyObjects(diff);
    }

    /// <summary>
    ///     Helper to deselect the currently selected row
    /// </summary>
    private void DeselectDiff()
    {
        if (selected != null)
        {
            var selImage = selected.Background;
            selImage.color = new Color(selImage.color.r, selImage.color.g, selImage.color.b, 0.0f);

            // Clean the UI, if we're selecting a new item they'll be repopulated
            BoomBoxSongContainer.Instance.Map = null;
        }

        selected = null;
        difficultyInfo.SelectMap(null);
    }

    /// <summary>
    ///     Helper for ForwardOnClick which handles clicks on the difficulty label text
    /// </summary>
    /// <param name="obj">UI row that was clicked on</param>
    public void OnClick(Transform obj)
    {
        var row = rows.First(it => it.Obj == obj);
        if (row != null) OnClick(row);
    }

    /// <summary>
    ///     Handle selecting the row when clicked
    /// </summary>
    /// <param name="row">UI row that was clicked on</param>
    private void OnClick(DifficultyRow row)
    {
        if (!diffs.ContainsKey(row.Name)) return;

        DeselectDiff();

        // Select a difficulty
        selected = row;
        var selImage = selected.Background;
        selImage.color = new Color(selImage.color.r, selImage.color.g, selImage.color.b, 1.0f);

        var diff = diffs[row.Name];
        BoomBoxSongContainer.Instance.Map = diff.Map;

        difficultyInfo.SelectMap(diff.Map);
    }

    /// <summary>
    ///     Paste from another difficulty to this one
    ///     As the toggles are hidden in this mode and replaced with paste icons
    ///     we just forward the click to the toggle below
    /// </summary>
    /// <param name="row">UI row that was clicked on</param>
    private void DoPaste(DifficultyRow row) =>
        // This will trigger the code in OnChange below
        row.Toggle.isOn = true;

    /// <summary>
    ///     Handle adding and deleting difficulties, they aren't added to the
    ///     song being edited until they are saved so this method stages them
    /// </summary>
    /// <param name="row">UI row that was clicked on</param>
    /// <param name="val">True if the diff is being added</param>
    private void OnChange(DifficultyRow row, bool val)
    {
        if (!val && diffs.ContainsKey(row.Name)) // Delete if exists
        {
            // ForceDirty = has never been saved, don't ask for permission
            if (diffs[row.Name].ForceDirty)
            {
                if (row == selected) DeselectDiff();

                diffs.Remove(row.Name);
                row.SetInteractable(false);
                row.NameInput.text = "";
                row.ShowDirtyObjects(false, false);
                return;
            }

            // This diff has previously been saved, confirm deletion
            PersistentUI.Instance.ShowDialogBox("SongEditMenu", "deletediff.dialog",
                r => HandleDeleteDifficulty(row, r), PersistentUI.DialogBoxPresetType.YesNo,
                new object[] { diffs[row.Name].Map.DifficultyName });
        }
        else if (val && !diffs.ContainsKey(row.Name)) // Create if does not exist
        {
            // Enforce constant starting BPM for diffs
            if (!float.TryParse(bpmField.text, out var bpm))
            {
                bpm = 120;
            }

            var map = new BoomBoxMap()
            {
                TimeCreated = DateTime.Now.ToUniversalTime().ToString("o"),
                TimingPoints = new List<BeatmapBPMChange>()
                {
                    new BeatmapBPMChange(bpm, 0)
                }
            };

            if (copySource != null)
            {
                var fromDiff = copySource.DifficultySettings;

                CancelCopy();

                if (fromDiff != null)
                {
                    map.DifficultyName = $"{fromDiff.Map.DifficultyName} (Copy)";
                    map.Creator = fromDiff.Map.Creator;
                    map.Description = fromDiff.Map.Description;
                    map.Tags = fromDiff.Map.Tags;
                    map.BiomeType = fromDiff.Map.BiomeType;
                    map.Bookmarks = fromDiff.Map.Bookmarks.ToList();
                    map.Objects = fromDiff.Map.Objects.ToList();
                    map.Obstacles = fromDiff.Map.Obstacles.ToList();
                    map.TimingPoints = fromDiff.Map.TimingPoints.ToList();
                    map.LocalVersion = fromDiff.Map.LocalVersion;
                }
            }

            diffs[row.Name] = new DifficultySettings(map, true);

            row.ShowDirtyObjects(diffs[row.Name]);
            row.SetInteractable(true);
            OnClick(row);
        }
        else if (val) // Create, but already exists
        {
            // I don't know how this would happen anymore
            row.ShowDirtyObjects(diffs[row.Name]);
            row.SetInteractable(true);
            if (!loading) OnClick(row);
        }
    }

    /// <summary>
    ///     Handle deleting a difficulty that was previously saved
    /// </summary>
    /// <param name="row">UI row that was clicked on</param>
    /// <param name="r">Confirmation from the user</param>
    private void HandleDeleteDifficulty(DifficultyRow row, int r)
    {
        if (r == 1) // User canceled out
        {
            row.Toggle.isOn = true;
            return;
        }

        var map = diffs[row.Name].Map;

        var fileToDelete = map.FileInfo;
        if (fileToDelete.Exists) FileOperationAPIWrapper.MoveToRecycleBin(fileToDelete.FullName);

        // Remove status effects if present
        if (copySource != null && row == copySource.Obj &&
            currentCharacteristic == copySource.Characteristic)
        {
            CancelCopy();
        }

        if (row == selected) DeselectDiff();

        diffs.Remove(row.Name);
        Song.Save();

        row.SetInteractable(false);
        row.NameInput.text = "";
        row.ShowDirtyObjects(false, false);
    }

    /// <summary>
    ///     Set the row as the source for a copy-paste operation
    /// </summary>
    /// <param name="row">UI row that was clicked on</param>
    private void SetCopySource(DifficultyRow row)
    {
        // If we copied from the current characteristic remove the highlight
        if (copySource != null && currentCharacteristic == copySource.Characteristic)
            copySource.Obj.CopyImage.color = Color.white;

        // Clicking twice on the same source removes it
        if (copySource != null && copySource.Obj == row && currentCharacteristic == copySource.Characteristic)
        {
            CancelCopy();
            return;
        }

        copySource = new CopySource(diffs[row.Name], currentCharacteristic, row);
        SetPasteMode(true);
        row.CopyImage.color = copyColor;
    }

    /// <summary>
    ///     Helper to clear any in progress copy-paste
    /// </summary>
    public void CancelCopy()
    {
        if (copySource != null && currentCharacteristic == copySource.Characteristic)
            copySource.Obj.CopyImage.color = Color.white;
        copySource = null;
        SetPasteMode(false);
    }

    /// <summary>
    ///     Show the difficulties for the given characteristic
    /// </summary>
    /// <param name="name">Characteristic to load from</param>
    public void LoadDifficulties()
    {
        DeselectDiff();

        loading = true;

        foreach (var row in rows)
        {
            var hasDiff = diffs.ContainsKey(row.Name);
            row.SetInteractable(diffs.ContainsKey(row.Name));

            // Highlight the copy source if it's here
            row.CopyImage.color =
                copySource != null && currentCharacteristic == copySource.Characteristic && copySource.Obj == row
                    ? copyColor
                    : Color.white;

            row.NameInput.text = hasDiff ? diffs[row.Name].CustomName : "";

            if (hasDiff)
            {
                row.ShowDirtyObjects(diffs[row.Name]);
                if (Settings.Instance.LastLoadedMap.Equals(Song.Directory) &&
                    Settings.Instance.LastLoadedDiff.Equals(row.Name))
                {
                    OnClick(row);
                }
            }
            else
            {
                row.ShowDirtyObjects(false, false);
            }
        }

        loading = false;

        SetPasteMode(copySource != null);
    }

    /// <summary>
    ///     Show or hide paste buttons for non-existing difficulties
    /// </summary>
    /// <param name="mode">True if we should show paste buttons</param>
    private void SetPasteMode(bool mode)
    {
        foreach (Transform child in transform)
        {
            var localMode = mode && !diffs.ContainsKey(child.name);
            child.Find("Paste").gameObject.SetActive(localMode);
            child.Find("Button/Toggle").gameObject.SetActive(!localMode);
        }
    }

    /// <summary>
    ///     Check if any difficulties have unsaved changes
    /// </summary>
    /// <returns>True if there are unsaved changes</returns>
    public bool IsDirty() => diffs.Any(diff => diff.Value.IsDirty());
}
