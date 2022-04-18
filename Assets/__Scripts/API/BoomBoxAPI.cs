using System;
using System.Collections;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class BoomBoxAPI
{
    public static readonly string AuthEndpoint = "api-token-auth/";
    public static readonly string UploadMapEndpoint = "map/";
    public static readonly string SongListEndpoint = "song/";

    private static readonly string api = "https://api.boomboxvr.com";

    private static readonly string header_token_auth = "Wpauthorization";
    private static readonly string header_auth = "Authorization";

    public static string UserId = null;

    private static string token;
    private static DateTime expiry;

    public static bool IsAuthenticated => !string.IsNullOrEmpty(token) && DateTime.UtcNow <= expiry;

    // TODO: Localize
    public static IEnumerator AuthenticateUser()
    {
        if (IsAuthenticated) yield break;

        var userSubmit = false;

        // It would be a good idea to cache this dialog box, however I am weary of moving user/pass boxes into static fields.
        var dialogBox = PersistentUI.Instance.CreateNewDialogBox()
            .WithTitle("Please Log In");

        dialogBox.AddComponent<TextComponent>()
            .WithInitialValue("You must be logged in to access BoomBox online services.");

        var user = dialogBox.AddComponent<TextBoxComponent>()
            .WithLabel("Username");

        var pass = dialogBox.AddComponent<TextBoxComponent>()
            .WithLabel("Password")
            .WithContentType(TMPro.TMP_InputField.ContentType.Password);

        dialogBox.AddFooterButton(() => userSubmit = false, "PersistentUI", "cancel");
        dialogBox.AddFooterButton(() => userSubmit = true, "PersistentUI", "ok");

        dialogBox.Open();

        yield return new WaitUntil(() => dialogBox == null);

        if (!userSubmit) yield break;

        var authenticateRequest = new UnityWebRequest($"{api}/{AuthEndpoint}", "GET", new DownloadHandlerBuffer(), null);
        var the_funny = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{user.Value}:{pass.Value}"));
        authenticateRequest.SetRequestHeader(header_token_auth, the_funny);

        yield return authenticateRequest.SendWebRequest();

        if (authenticateRequest.result != UnityWebRequest.Result.Success)
        {
            PersistentUI.Instance.ShowDialogBox($"Authentication error ({authenticateRequest.responseCode}): {authenticateRequest.error}",
                null, PersistentUI.DialogBoxPresetType.Ok);

            yield break;
        }

        var authResponse = JsonConvert.DeserializeObject<AuthResponse>(authenticateRequest.downloadHandler.text);

        if (authResponse == null)
        {
            PersistentUI.Instance.ShowDialogBox("Error decoding auth response body.",
                null, PersistentUI.DialogBoxPresetType.Ok);

            yield break;
        }

        Debug.LogWarning("Woohoo! We've authenticated!");

        token = authResponse.Token;
        expiry = authResponse.Expiry;
        UserId = authResponse.UserId;
    }

    public static UnityWebRequest CreateAuthenticatedRequest(string endpoint, string method = "GET")
    {
        if (!IsAuthenticated)
        {
            throw new InvalidOperationException("User must be authenticated.");
        }

        var webRequest = new UnityWebRequest($"{api}/{endpoint}", method, new DownloadHandlerBuffer(), null);

        webRequest.SetRequestHeader(header_auth, $"Token {token}");

        return webRequest;
    }

    private class AuthResponse
    {
        [JsonProperty("token")]
        public string Token;

        [JsonProperty("user_id")]
        public string UserId;

        [JsonProperty("steamid")]
        public string SteamId;

        [JsonProperty("username")]
        public string UsernameOrEmail;

        [JsonProperty("personaname")]
        public string DisplayName;

        [JsonProperty("expiry")]
        public DateTime Expiry;

        [JsonProperty("avatar")]
        public string AvatarUrl;

        public AuthResponse() { }
    }
}
