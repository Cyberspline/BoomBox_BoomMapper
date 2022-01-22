using System;
using System.IO;
using System.Linq;
using UnityEngine;

public class CreateNewSong : MonoBehaviour
{
    [SerializeField] private SongList list;

    public void CreateSong() => PersistentUI.Instance.ShowInputBox("SongSelectMenu", "newmap.dialog", HandleNewSongName,
        "newmap.dialog.default");

    private void HandleNewSongName(string res)
    {
        if (res is null) return;

        var song = new BoomBoxPack(res)
        {
            TimeCreated = DateTime.Now.ToUniversalTime().ToString("o")
        };

        if (list.Songs.Any(x => Path.GetFullPath(x.Directory).Equals(
            Path.GetFullPath(Path.Combine(Settings.Instance.CustomSongsFolder, song.CleanSongName)),
            StringComparison.CurrentCultureIgnoreCase
        )))
        {
            PersistentUI.Instance.ShowInputBox("SongSelectMenu", "newmap.dialog.duplicate", HandleNewSongName,
                "newmap.dialog.default");
            return;
        }

        BoomBoxSongContainer.Instance.SelectSongForEditing(song);

        PersistentUI.Instance.DisplayMessage("SongSelectMenu", "newmap.message",
            PersistentUI.DisplayMessageType.Bottom);
    }
}
