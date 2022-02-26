using UnityEngine;
using UnityEngine.UI;

public class ColorTypeController : MonoBehaviour
{
    [SerializeField] private NotePlacement notePlacement;
    [SerializeField] private DeleteToolController deleteToolController;
    [SerializeField] private Image leftSelected;
    [SerializeField] private Image rightSelected;
    [SerializeField] private Image leftNote;
    [SerializeField] private Image rightNote;

    private void Start()
    {
        leftSelected.enabled = true;
        rightSelected.enabled = false;
        UpdateColors();
    }

    // TODO: What are good default colors for boombox
    private void UpdateColors()
    {
        leftNote.color = Color.red;
        rightNote.color = Color.blue;
    }

    public void RedNote(bool active)
    {
        if (active) UpdateValue(BeatmapNote.NoteTypeA);
    }

    public void BlueNote(bool active)
    {
        if (active) UpdateValue(BeatmapNote.NoteTypeB);
    }

    public void UpdateValue(int type)
    {
        notePlacement.UpdateType(type);
        deleteToolController.UpdateDeletion(false);
        UpdateUI();
    }

    public void UpdateUI()
    {
        leftSelected.enabled = notePlacement.queuedData.Hand == BeatmapNote.HandLeft;
        rightSelected.enabled = notePlacement.queuedData.Hand == BeatmapNote.HandRight;
    }

    public bool LeftSelectedEnabled() => leftSelected.enabled;
}
