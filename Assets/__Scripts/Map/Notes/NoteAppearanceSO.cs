using UnityEngine;

[CreateAssetMenu(fileName = "NoteAppearanceSO", menuName = "Map/Appearance/Note Appearance SO")]
public class NoteAppearanceSO : ScriptableObject
{
    public Color RedColor { get; private set; } = new Color(0.7352942f, 0, 0);
    public Color BlueColor { get; private set; } = new Color(0, 0.3701827f, 0.7352942f);

    public void UpdateColor(Color red, Color blue)
    {
        RedColor = red;
        BlueColor = blue;
    }

    public void SetNoteAppearance(BeatmapNoteContainer note)
        => note.SetColor(note.MapNoteData.Hand == BeatmapNote.HandLeft
            ? RedColor
            : BlueColor);
}
