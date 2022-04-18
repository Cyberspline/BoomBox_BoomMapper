using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using SimpleJSON;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class AutoSaveController : MonoBehaviour, CMInput.ISavingActions
{
    private const int maximumAutosaveCount = 15;
    [SerializeField] private Toggle autoSaveToggle;

    private List<DirectoryInfo> currentAutoSaves = new List<DirectoryInfo>();

    private Thread savingThread;

    private float t;

    // Use this for initialization
    private void Start()
    {
        autoSaveToggle.isOn = Settings.Instance.AutoSave;
        t = 0;

        var autoSavesDir = Path.Combine(BoomBoxSongContainer.Instance.Pack.Directory, "autosaves");
        if (Directory.Exists(autoSavesDir))
        {
            foreach (var dir in Directory.EnumerateDirectories(autoSavesDir))
                currentAutoSaves.Add(new DirectoryInfo(dir));
        }

        CleanAutosaves();
    }

    // Update is called once per frame
    private void Update()
    {
        if (!Settings.Instance.AutoSave || !Application.isFocused) return;
        t += Time.deltaTime;
        if (t > Settings.Instance.AutoSaveInterval * 60)
        {
            t = 0;
            Save(true);
        }
    }

    public void OnSave(InputAction.CallbackContext context)
    {
        if (context.performed) Save();
    }

    public void ToggleAutoSave(bool enabled) => Settings.Instance.AutoSave = enabled;

    public void Save(bool auto = false)
    {
        if (savingThread != null && savingThread.IsAlive)
        {
            Debug.LogError(":hyperPepega: :mega: STOP TRYING TO SAVE THE SONG WHILE ITS ALREADY SAVING TO DISK");
            return;
        }

        var notification = PersistentUI.Instance.DisplayMessage("Mapper", $"{(auto ? "auto" : "")}save.message",
            PersistentUI.DisplayMessageType.Bottom);
        notification.SkipFade = true;
        notification.WaitTime = 5.0f;

        SelectionController.RefreshMap();
        
        savingThread = new Thread(() =>
        {
            // I need this on a separate thread to not block the main game thread
            Thread.CurrentThread.IsBackground = true;
            
            // Fixes weird shit regarding how people write numbers (20,35 VS 20.35), causing issues in JSON
            // This should be thread-wide, but I have this set throughout just in case it isnt.
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
            
            // Original pack/map location to revert after an autosave
            var originalMap = BoomBoxSongContainer.Instance.Map.FileInfo;
            var originalSong = BoomBoxSongContainer.Instance.Pack.Directory;

            try
            {
                // Create new autosave directory and save
                if (auto)
                {
                    var autoSaveDir = Path.Combine(originalSong, "autosaves", $"{DateTime.Now:dd-MM-yyyy_HH-mm-ss}");

                    //We need to create the autosave directory before we can save the .dat difficulty into it.
                    Directory.CreateDirectory(autoSaveDir);
                    BoomBoxSongContainer.Instance.Map.FileInfo = new FileInfo(
                        Path.Combine(autoSaveDir, BoomBoxSongContainer.Instance.Map.FileInfo.Name));
                    BoomBoxSongContainer.Instance.Pack.Directory = autoSaveDir;

                    var newDirectoryInfo = new DirectoryInfo(autoSaveDir);
                    currentAutoSaves.Add(newDirectoryInfo);
                    CleanAutosaves();
                }

                BoomBoxSongContainer.Instance.Map.Save();
                BoomBoxSongContainer.Instance.Pack.Save();
                Debug.Log($"Auto saved to: {BoomBoxSongContainer.Instance.Pack.Directory}");
            }
            catch(Exception ex)
            {
                Debug.LogError("Error while saving autosave (don't worry, progress wasn't lost)");
                Debug.LogException(ex);
            }

            // Revert directory if it was changed by autosave
            // Done outside the try/catch loop to successfully recover from a failed autosave
            BoomBoxSongContainer.Instance.Pack.Directory = originalSong;
            BoomBoxSongContainer.Instance.Map.FileInfo = originalMap;

            notification.SkipDisplay = true;
        });

        savingThread.Start();
    }

    private void CleanAutosaves()
    {
        if (currentAutoSaves.Count <= maximumAutosaveCount) return;

        Debug.Log($"Too many autosaves; removing excess... ({currentAutoSaves.Count} > {maximumAutosaveCount})");

        var ordered = currentAutoSaves.OrderByDescending(d => d.LastWriteTime).ToArray();
        currentAutoSaves = ordered.Take(maximumAutosaveCount).ToList();

        foreach (var directoryInfo in ordered.Skip(maximumAutosaveCount))
        {
            try
            {
                Directory.Delete(directoryInfo.FullName, true);
            }
            catch(Exception ex)
            {
                Debug.LogError($"Failed to delete autosave {directoryInfo.Name}: {ex.Message}");
            }
        }
    }
}
