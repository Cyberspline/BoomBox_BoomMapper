using UnityEngine;

public class BoomBoxSongContainer : MonoBehaviour
{
    public BoomBoxPack Pack;
    public BoomBoxMap Map;
    public AudioClip LoadedSong;

    public static BoomBoxSongContainer Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null) Destroy(Instance.gameObject);
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SelectSongForEditing(BoomBoxPack pack)
    {
        Pack = pack;
        SceneTransitionManager.Instance.LoadScene("02_SongEditMenu");
    }
}
