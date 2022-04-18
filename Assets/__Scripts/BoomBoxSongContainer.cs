using UnityEngine;

public class BoomBoxSongContainer : MonoBehaviour
{
    public BoomBoxCustomPack Pack;
    public BoomBoxMap Map;
    public AudioClip LoadedSong;

    public static BoomBoxSongContainer Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null) Destroy(Instance.gameObject);
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SelectSongForEditing(BoomBoxCustomPack pack)
    {
        Pack = pack;
        SceneTransitionManager.Instance.LoadScene("02_SongEditMenu");
    }
}
