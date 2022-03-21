using System.Collections;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

public class BoomBoxMapUploadController : MonoBehaviour
{
    [SerializeField] private DifficultySelect difficultySelect;
    [SerializeField] private GameObject buttonGameObject;

    private void Start() => buttonGameObject.SetActive(BoomBoxSongContainer.Instance.Pack.SongId != null);

    public void AttemptMapUpload()
    {
        if (difficultySelect.CurrentDiff != null)
        {
            StartCoroutine(MapUploadCoroutine());
        }
    }

    // TODO: Localize
    private IEnumerator MapUploadCoroutine()
    {
        // Ensure we are authenticated.
        yield return StartCoroutine(BoomBoxAPI.AuthenticateUser());
        
        // We need to create a new API map object, since the format is slightly different
        var apiMap = new BoomBoxMapAPI(BoomBoxSongContainer.Instance.Pack, difficultySelect.CurrentDiff);

        // Create our stream and serialize the API map into JSON
        var jsonString = JsonConvert.SerializeObject(apiMap, Formatting.Indented);

        // Create our request and assign an upload handler
        var request = BoomBoxAPI.CreateAuthenticatedRequest(BoomBoxAPI.UploadMapEndpoint, "POST");
        request.SetRequestHeader("Content-Type", "application/json");

        File.WriteAllText("out.txt", jsonString, Encoding.UTF8);

        var handler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(jsonString));
        handler.contentType = "application/json";

        request.uploadHandler = handler;
        request.downloadHandler = new DownloadHandlerBuffer();

        // Make a fancy dialog box to show progress
        var dialogBox = PersistentUI.Instance.CreateNewDialogBox()
            .WithTitle("Uploading Map...");

        var progressBar = dialogBox.AddComponent<ProgressBarComponent>();

        dialogBox.AddFooterButton(() => request.Abort(), "Abort");

        dialogBox.Open();

        // Send our request
        request.SendWebRequest();

        // We manually wait asynchronously so we can update our dialog box with the upload progress
        while (!request.isDone)
        {
            progressBar.UpdateProgressBar(request.uploadProgress);
            yield return null;
        }

        File.WriteAllBytes("response.txt", request.downloadHandler.data);

        // Uploading is complete, close our dialog box
        dialogBox.Close();

        // Show a final dialog box depending on the result of the upload
        if (request.result != UnityWebRequest.Result.Success)
        {
            PersistentUI.Instance.ShowDialogBox($"Error while uploading map ({request.responseCode}): {request.error}",
                null, PersistentUI.DialogBoxPresetType.Ok);
        }
        else
        {
            PersistentUI.Instance.ShowDialogBox($"Successfully uploaded!",
                null, PersistentUI.DialogBoxPresetType.Ok);
        }
    }
}
