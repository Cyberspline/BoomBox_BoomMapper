using System;
using System.Collections;
using System.IO;
using System.Linq;
using UnityEngine.Networking;

public class OfficialSongDownloader
{
    private static DialogBox dialogBox;
    private static ProgressBarComponent progressBar;

    // TODO: Localize
    public static IEnumerator DownloadOfficialPack(SongListItem item, BoomBoxOfficialPack officialPack)
    {
        yield return item.StartCoroutine(BoomBoxAPI.AuthenticateUser());

        var subDirectoryName = $"pack - {officialPack.SongId} - {officialPack.SongTitle}";

        // Sanitize the directory name
        var cleanSubDirectoryName = Path.GetInvalidPathChars()
            .Aggregate(subDirectoryName, (res, el) => res.Replace(el.ToString(), string.Empty));

        var directory = Path.Combine(Settings.Instance.CustomSongsFolder, cleanSubDirectoryName);

        if (Directory.Exists(directory))
        {
            var existingPack = BoomBoxCustomPack.GetPackFromDirectory(directory);

            if (existingPack != null)
            {
                BoomBoxSongContainer.Instance.SelectSongForEditing(existingPack);

                PersistentUI.Instance.ShowDialogBox(
                    "It looks like you already have this song in your local library.\n\nBoomMapper has loaded that local copy.",
                    null, PersistentUI.DialogBoxPresetType.Ok);

                yield break;
            }
        }

        Directory.CreateDirectory(directory);

        if (dialogBox == null)
        {
            dialogBox = PersistentUI.Instance.CreateNewDialogBox()
                .WithTitle("Downloading Official Song...")
                .DontDestroyOnClose();

            progressBar = dialogBox.AddComponent<ProgressBarComponent>();
        }

        dialogBox.Open();

        var audioRequest = CreateDownloadRequest(officialPack.AudioFile, directory, out var localAudioFile);
        yield return item.StartCoroutine(DownloadAsset(audioRequest, "Downloading song..."));

        var coverRequest = CreateDownloadRequest(officialPack.ImageFile, directory, out var localImageFile);
        yield return item.StartCoroutine(DownloadAsset(coverRequest, "Downloading cover..."));

        dialogBox.Close();

        var customPack = new BoomBoxCustomPack(officialPack.SongTitle)
        {
            SongId = officialPack.SongId,
            SongArtist = officialPack.SongArtist,
            AudioFile = localAudioFile,
            ImageFile = localImageFile,
            Directory = directory,
            PreviewDuration = 10,
            TimeCreated = DateTime.Now.ToUniversalTime().ToString("o")
        };

        customPack.Save();

        BoomBoxSongContainer.Instance.SelectSongForEditing(customPack);
    }

    private static IEnumerator DownloadAsset(UnityWebRequest request, string labelText)
    {
        progressBar.WithCustomLabelFormatter((_) => labelText);

        request.SendWebRequest();

        while (!request.isDone)
        {
            progressBar.UpdateProgressBar(request.downloadProgress);
            yield return null;
        }
    }

    private static UnityWebRequest CreateDownloadRequest(string url, string downloadDirectory, out string fileName)
    {
        // Extract file name from URI
        var uri = new Uri(url, UriKind.Absolute);
        fileName = Path.GetFileName(Uri.UnescapeDataString(uri.AbsolutePath));

        // Generate our request and assign a download handler
        return new UnityWebRequest(uri)
        {
            downloadHandler = new DownloadHandlerFile(Path.Combine(downloadDirectory, fileName))
        };
    }
}
