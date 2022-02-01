using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using SimpleJSON;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.InputSystem.InputAction;
using Debug = UnityEngine.Debug;

public class SongInfoEditUI : MenuBase
{
    public static readonly Dictionary<string, AudioType> ExtensionToAudio = new Dictionary<string, AudioType>
    {
        {"ogg", AudioType.OGGVORBIS}, {"egg", AudioType.OGGVORBIS}, {"wav", AudioType.WAV}
    };

    [SerializeField] private AudioSource previewAudio;

    [SerializeField] private DifficultySelect difficultySelect;
    [SerializeField] private TMP_InputField nameField;
    [SerializeField] private TMP_InputField songAuthorField;
    [SerializeField] private TMP_InputField coverImageField;

    [SerializeField] private TMP_InputField bpmField;
    [SerializeField] private TMP_InputField prevStartField;
    [SerializeField] private TMP_InputField prevDurField;

    [SerializeField] private TMP_InputField audioPath;

    [SerializeField] private Image revertInfoButtonImage;

    private Coroutine reloadSongDataCoroutine;
    public Action TempSongLoadedEvent;

    private BoomBoxPack Song => BoomBoxSongContainer.Instance.Pack;

    private void Start()
    {
        if (BoomBoxSongContainer.Instance == null)
        {
            SceneManager.LoadScene(0);
            return;
        }

        LoadFromSong();
    }

    // TODO: Remove
    [Obsolete]
    public static int GetDirectionalEnvironmentIDFromString(string platforms) => -1;

    // TODO: Remove
    [Obsolete]
    public static int GetEnvironmentIDFromString(string environment) => -1;

    // TODO: Remove
    [Obsolete]
    public static string GetEnvironmentNameFromID(int id) => null;

    /// <summary>
    ///     Default object to select when pressing Tab and nothing is selected
    /// </summary>
    /// <returns>A GUI object</returns>
    protected override GameObject GetDefault() => nameField.gameObject;

    /// <summary>
    ///     Callback for when escape is pressed, user wants out of here
    /// </summary>
    /// <param name="context">Information about the event</param>
    public override void OnLeaveMenu(CallbackContext context)
    {
        if (context.performed) ReturnToSongList();
    }

    /// <summary>
    ///     Save the changes the user has made in the song info panel
    /// </summary>
    public void SaveToSong()
    {
        Song.SongTitle = nameField.text;
        Song.SongArtist = songAuthorField.text;
        Song.ImageFile = coverImageField.text;
        Song.AudioFile = audioPath.text;

        // TODO: bpm
        //Song.BeatsPerMinute = GetTextValue(bpmField);
        Song.PreviewTime = GetTextValue(prevStartField) / 1000;
        Song.PreviewDuration = GetTextValue(prevDurField) / 1000;

        // TODO: Switch to biomes
        //Song.EnvironmentName = GetEnvironmentNameFromID(environmentDropdown.value);

        Song.Save();

        // Update duration cache (This needs to be beneath SaveSong so that the directory is garaunteed to be created)
        // also dont forget to null check please thanks
        if (previewAudio.clip != null)
            SongListItem.SetDuration(this, Path.GetFullPath(Song.Directory), previewAudio.clip.length);

        // Trigger validation checks, if this is the first save they will not have been done yet
        coverImageField.GetComponent<InputBoxFileValidator>().OnUpdate();
        audioPath.GetComponent<InputBoxFileValidator>().OnUpdate();
        ReloadAudio();

        PersistentUI.Instance.DisplayMessage("SongEditMenu", "saved", PersistentUI.DisplayMessageType.Bottom);
    }

    /// <summary>
    ///     Populate UI from song data
    /// </summary>
    public void LoadFromSong()
    {
        nameField.text = Song.SongTitle;
        songAuthorField.text = Song.SongArtist;

        BroadcastMessage("OnValidate"); // god unity why are you so dumb

        coverImageField.text = Song.ImageFile;
        audioPath.text = Song.AudioFile;

        // TODO: Get bpm from a difficulty
        //bpmField.text = Song.BeatsPerMinute.ToString(CultureInfo.InvariantCulture);

        var maps = Song.Maps;

        var bpms = maps.Select(x => x.BeginningBPM);

        var distinctBpms = bpms.Distinct();
        var bpmCount = distinctBpms.Count();

        if (bpmCount > 1)
        {
            // TODO: Localize
            var dialogBox = PersistentUI.Instance.CreateNewDialogBox().WithTitle("BPM Ambiguity Detected");

            // Add label text which explains the problem (more than 1 starting BPM) and what the user needs to do
            // TODO: Localize
            dialogBox.AddComponent<TextComponent>()
                .WithInitialValue(() => "BoomMapper has detected multiple starting BPMs in your pack.\n\n" +
                    "For simplicity, BoomMapper will have one starting BPM for all maps in the pack.\n\n" + 
                    "Please select which starting BPM BoomMapper will apply to all maps.");

            // Add a dropdown which will force the user to select one BPM to apply
            var dropdown = dialogBox.AddComponent<DropdownComponent>()
                // Populate dropdown with formatted strings of difficulty name and BPM
                // Example: "Master (320 BPM)" and "Expert (128 BPM)"
                .WithOptionsList(maps.Select(x =>
                    string.Format("{0} ({1} BPM)", x.DifficultyName, x.TimingPoints.Find(y => y.TimeInMilliseconds == 0))
                    ))
                // Set default value to the first difficulty
                .WithInitialValue(() => 0)
                // Register OnChanged event to dynamically change bpm text
                .OnChanged<DropdownComponent, int>(i => bpmField.text = bpms.ElementAt(i).ToString(CultureInfo.InvariantCulture));

            // Add footer button which will apply the selected value
            dialogBox.AddFooterButton(() => bpmField.text = bpms.ElementAt(dropdown.Value).ToString(CultureInfo.InvariantCulture), "Ok");
        }
        else if (bpmCount == 1)
        {
            bpmField.text = distinctBpms.First().ToString(CultureInfo.InvariantCulture);
        }
        else
        {
            // Default BPM.
            bpmField.text = "120";
        }

        // Preview Time and Duration are in milliseconds. It will be easier on the user if we convert to seconds and back.
        prevStartField.text = (Song.PreviewTime / 1000).ToString(CultureInfo.InvariantCulture);
        prevDurField.text = (Song.PreviewDuration / 1000).ToString(CultureInfo.InvariantCulture);

        ReloadAudio();
    }

    /// <summary>
    ///     Start the LoadAudio Coroutine
    /// </summary>
    public void ReloadAudio() => StartCoroutine(LoadAudio());

    /// <summary>
    ///     Try and load the song, this is used for the song preview as well as later
    ///     passed to the mapping scene
    /// </summary>
    /// <param name="useTemp">Should we load the song the user has updated in the UI or from the saved song data</param>
    /// <returns>Coroutine IEnumerator</returns>
    private IEnumerator LoadAudio(bool useTemp = true, bool applySongTimeOffset = false)
    {
        if (Song.Directory == null) yield break;

        var fullPath = Path.Combine(Song.Directory, useTemp ? audioPath.text : Song.AudioFile);

        // Commented out since Song Time Offset changes need to reload the song, even if its the same file
        //if (fullPath == loadedSong)
        //{
        //    yield break;
        //}

        Debug.Log("Loading audio");
        if (File.Exists(fullPath))
        {
            var extension = audioPath.text.Contains(".")
                ? Path.GetExtension(audioPath.text.ToLower()).Replace(".", "")
                : "";


            if (!string.IsNullOrEmpty(extension) && ExtensionToAudio.ContainsKey(extension))
            {
                Debug.Log("Lets go");
                var audioType = ExtensionToAudio[extension];
                var www = UnityWebRequestMultimedia.GetAudioClip($"file:///{Uri.EscapeDataString($"{fullPath}")}",
                    audioType);
                //Escaping should fix the issue where half the people can't open ChroMapper's editor (I believe this is caused by spaces in the directory, hence escaping)
                yield return www.SendWebRequest();
                Debug.Log("Song loaded!");
                var clip = DownloadHandlerAudioClip.GetContent(www);
                if (clip == null)
                {
                    Debug.Log("Error getting Audio data!");
                    SceneTransitionManager.Instance.CancelLoading("load.error.audio");
                }

                clip.name = "Song";

                // Unfortunately BoomBox does not have any form of song, so that code is removed

                previewAudio.clip = clip;
                BoomBoxSongContainer.Instance.LoadedSong = clip;

                if (useTemp) TempSongLoadedEvent?.Invoke();
            }
            else
            {
                Debug.Log("Incompatible file type! WTF!?");
                SceneTransitionManager.Instance.CancelLoading("load.error.audio2");
            }
        }
        else
        {
            SceneTransitionManager.Instance.CancelLoading("load.error.audio3");
            Debug.Log("Song does not exist! WTF!?");
            Debug.Log(fullPath);
        }
    }

    /// <summary>
    ///     Check the user wants to delete the map
    /// </summary>
    public void DeleteMap() =>
        PersistentUI.Instance.ShowDialogBox("SongEditMenu", "delete.dialog", HandleDeleteMap,
            PersistentUI.DialogBoxPresetType.YesNo, new object[] { Song.SongTitle });

    /// <summary>
    ///     Delete the map, it's still recoverable externally
    /// </summary>
    /// <param name="result">Confirmation from the user</param>
    private void HandleDeleteMap(int result)
    {
        if (result == 0) //Left button (ID 0) pressed; the user wants to delete the map.
        {
            FileOperationAPIWrapper.MoveToRecycleBin(Song.Directory);
            ReturnToSongList();
        } //Middle button (ID 1) would be pressed; the user doesn't want to delete the map, so we do nothing.
    }

    private void AddToZip(ZipArchive archive, string fileLocation)
    {
        var fullPath = Path.Combine(Song.Directory, fileLocation);
        if (File.Exists(fullPath)) archive.CreateEntryFromFile(fullPath, fileLocation);
    }

    /// <summary>
    ///     Create a zip for sharing the map
    /// </summary>
    public void PackageZip()
    {
        var infoFileLocation = "";
        var zipPath = "";
        if (Song.Directory != null)
        {
            zipPath = Path.Combine(Song.Directory, Song.CleanSongName + ".zip");
            // Mac doesn't seem to like overwriting existing zips, so delete the old one first
            File.Delete(zipPath);

            infoFileLocation = Path.Combine(Song.Directory, "Info.dat");
        }

        if (!File.Exists(infoFileLocation))
        {
            Debug.LogError(":hyperPepega: :mega: WHY TF ARE YOU TRYING TO PACKAGE A MAP WITH NO INFO.DAT FILE");
            PersistentUI.Instance.ShowDialogBox("SongEditMenu", "zip.warning", null,
                PersistentUI.DialogBoxPresetType.Ok);
            return;
        }

        using (var archive = ZipFile.Open(zipPath, ZipArchiveMode.Create))
        {
            archive.CreateEntryFromFile(infoFileLocation, "info.dat");

            AddToZip(archive, Song.ImageFile);
            AddToZip(archive, Song.AudioFile);

            foreach (var set in Song.Maps)
            {
                AddToZip(archive, set.FileInfo.Name);
            }
        }

        OpenSelectedMapInFileBrowser();
    }

    /// <summary>
    ///     Open the folder containing the map's files in a native file browser
    /// </summary>
    public void OpenSelectedMapInFileBrowser()
    {
        if (Song.Directory == null)
        {
            PersistentUI.Instance.ShowDialogBox("SongEditMenu", "explorer.warning", null,
                PersistentUI.DialogBoxPresetType.Ok);
            return;
        }

        var path = Song.Directory;
#if UNITY_STANDALONE_WIN
        path = path.Replace("/", "\\").Replace("\\\\", "\\");
#else
        path = path.Replace("\\", "/").Replace("//", "/");
#endif
        if (!path.StartsWith("\"")) path = "\"" + path;
        if (!path.EndsWith("\"")) path += "\"";

#if UNITY_STANDALONE_WIN
        Debug.Log($"Opening song directory ({path}) with Windows...");
        Process.Start("explorer.exe", path);
#elif UNITY_STANDALONE_OSX
        Debug.Log($"Opening song directory ({path}) with Mac...");
        Process.Start("open", path);
#elif UNITY_STANDALONE_LINUX
        Debug.Log($"Opening song directory ({path}) with Linux...");
        Process.Start("xdg-open", path);
#else
        Debug.Log("What is this, some UNIX bullshit?");
        PersistentUI.Instance.ShowDialogBox(
            "Unrecognized OS!\n\nIf you happen to know this OS and would like to contribute," +
            " please contact me on Discord: Caeden117#0117", null, PersistentUI.DialogBoxPresetType.Ok);
#endif
    }

    /// <summary>
    ///     Return the the song list scene, if the user has unsaved changes ask first
    /// </summary>
    public void ReturnToSongList()
    {
        // Do nothing if a dialog is open
        if (PersistentUI.Instance.DialogBoxIsEnabled) return;

        CheckForChanges(HandleReturnToSongList);
    }

    /// <summary>
    ///     Return the the song list scene
    /// </summary>
    /// <param name="r">Confirmation from the user</param>
    public void HandleReturnToSongList(int r)
    {
        if (r == 0) SceneTransitionManager.Instance.LoadScene("01_SongSelectMenu");
    }

    /// <summary>
    ///     The user wants to edit the map
    ///     Check first that some objects are enabled and that there are no unsaved changes
    /// </summary>
    public void EditMapButtonPressed()
    {
        // If no difficulty is selected or there is a dialog open do nothing
        if (BoomBoxSongContainer.Instance.Map == null || PersistentUI.Instance.DialogBoxIsEnabled) return;

        var a = Settings.Instance.Load_Notes;
        var b = Settings.Instance.Load_Obstacles;
        var c = Settings.Instance.Load_Events;
        var d = Settings.Instance.Load_Others;

        if (!(a || b || c || d))
        {
            PersistentUI.Instance.ShowDialogBox(
                "SongEditMenu", "load.warning",
                null, PersistentUI.DialogBoxPresetType.Ok);
            return;
        }

        if (!(a && b && c && d))
        {
            PersistentUI.Instance.ShowDialogBox(
                "SongEditMenu", "load.warning2",
                null, PersistentUI.DialogBoxPresetType.Ok);
        }

        CheckForChanges(HandleEditMapButtonPressed);
    }

    /// <summary>
    ///     Load the editor scene
    /// </summary>
    /// <param name="r">Confirmation from the user</param>
    private void HandleEditMapButtonPressed(int r)
    {
        if (r == 0)
        {
            var map = difficultySelect.CurrentDiff;

            Debug.Log("Transitioning...");
            if (map != null)
            {
                Settings.Instance.LastLoadedMap = Song.Directory;
                Settings.Instance.LastLoadedDiff = BoomBoxSongContainer.Instance.Map.DifficultyName;
                BoomBoxSongContainer.Instance.Map = map;
                SceneTransitionManager.Instance.LoadScene("03_Mapper", LoadAudio(false, true));
            }
        }
    }

    /// <summary>
    ///     Helper methods to prompt the user if there are unsaved changes
    ///     Will call the callback immediately if there are none
    /// </summary>
    /// <param name="callback">Method to call when the user has made a decision</param>
    /// <returns>True if a dialog has been opened, false otherwise</returns>
    private bool CheckForChanges(Action<int> callback)
    {
        if (IsDirty())
        {
            PersistentUI.Instance.ShowDialogBox("SongEditMenu", "unsaved.warning", callback,
                PersistentUI.DialogBoxPresetType.YesNo);
            return true;
        }

        if (difficultySelect.IsDirty())
        {
            PersistentUI.Instance.ShowDialogBox("SongEditMenu", "unsaveddiff.warning", callback,
                PersistentUI.DialogBoxPresetType.YesNo);
            return true;
        }

        callback(0);
        return false;
    }

    /// <summary>
    ///     Undo button has been pressed, trigger animation and reload the song data
    /// </summary>
    public void UndoChanges()
    {
        reloadSongDataCoroutine = StartCoroutine(SpinReloadSongDataButton());

        LoadFromSong();
    }

    /// <summary>
    ///     Spins the undo button for extra flare
    /// </summary>
    /// <returns>Coroutine IEnumerator</returns>
    private IEnumerator SpinReloadSongDataButton()
    {
        if (reloadSongDataCoroutine != null) StopCoroutine(reloadSongDataCoroutine);

        var startTime = Time.time;
        var transform1 = revertInfoButtonImage.transform;
        var rotationQ = transform1.rotation;
        var rotation = rotationQ.eulerAngles;
        rotation.z = -330;
        transform1.rotation = Quaternion.Euler(rotation);

        while (true)
        {
            var rot = rotation.z;
            var timing = Time.time / startTime * 0.075f;
            rot = Mathf.Lerp(rot, 30f, timing);
            rotation.z = rot;
            transform1.rotation = Quaternion.Euler(rotation);

            if (rot >= 25f)
            {
                rotation.z = 30;
                transform1.rotation = Quaternion.Euler(rotation);
                yield break;
            }

            yield return new WaitForFixedUpdate();
        }
    }

    /// <summary>
    ///     Helper method to get the float value from a UI element
    ///     Returns the placeholder value if the field is empty
    /// </summary>
    /// <param name="inputfield">Text field to get the value from</param>
    /// <returns>The value parsed to a float</returns>
    private static float GetTextValue(TMP_InputField inputfield)
    {
        if (!float.TryParse(inputfield.text, out var result))
        {
            if (!float.TryParse(inputfield.placeholder.GetComponent<TMP_Text>().text, out result))
                // How have you changed the placeholder so that it isn't valid?
                result = 0;
        }

        return result;
    }

    /// <summary>
    ///     Check if any changes have been made from the original song data
    /// </summary>
    /// <returns>True if user has made changes, false otherwise</returns>
    private bool IsDirty() =>
        Song.SongTitle != nameField.text ||
        Song.SongArtist != songAuthorField.text ||
        Song.ImageFile != coverImageField.text ||
        Song.AudioFile != audioPath.text ||
        // TODO: bpm
        //!NearlyEqual(Song.BeatsPerMinute, GetTextValue(bpmField)) ||
        !NearlyEqual(Song.PreviewTime, GetTextValue(prevStartField)) ||
        !NearlyEqual(Song.PreviewDuration, GetTextValue(prevDurField));

    private static bool NearlyEqual(float a, float b, float epsilon = 0.01f) =>
        a.Equals(b) || Math.Abs(a - b) < epsilon;
}
