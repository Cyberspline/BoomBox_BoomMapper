using UnityEngine;

[CreateAssetMenu(fileName = "NoteAppearanceSO", menuName = "Map/Appearance/Note Appearance SO")]
public class NoteAppearanceSO : ScriptableObject
{
    public Color RedColor { get; private set; } = BeatSaberSong.DefaultLeftNote;
    public Color BlueColor { get; private set; } = BeatSaberSong.DefaultRightNote;

    public void UpdateColor(Color red, Color blue)
    {
        RedColor = red;
        BlueColor = blue;
    }

    public void SetNoteAppearance(BeatmapNoteContainer note)
        => note.SetColor(note.MapNoteData.Hand == BeatmapNote.HandLeft
            ? BeatSaberSong.DefaultLeftNote
            : BeatSaberSong.DefaultRightNote);
}
