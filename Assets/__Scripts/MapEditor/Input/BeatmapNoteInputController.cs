using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class BeatmapNoteInputController : BeatmapInputController<BeatmapNoteContainer>, CMInput.INoteObjectsActions
{
    [FormerlySerializedAs("noteAppearanceSO")] [SerializeField] private NoteAppearanceSO noteAppearanceSo;
    public bool QuickModificationActive;

    //Do some shit later lmao
    public void OnInvertNoteColors(InputAction.CallbackContext context)
    {
        if (CustomStandaloneInputModule.IsPointerOverGameObject<GraphicRaycaster>(-1, true) ||
            !KeybindsController.IsMouseInWindow || !context.performed)
        {
            return;
        }

        RaycastFirstObject(out var note);
        if (note != null && !note.Dragging) InvertNote(note);
    }

    public void OnQuickDirectionModifier(InputAction.CallbackContext context) =>
        QuickModificationActive = context.performed;

    public void InvertNote(BeatmapNoteContainer note)
    {
        var original = BeatmapObject.GenerateCopy(note.ObjectData);
        var newHand = note.MapNoteData.Hand == BeatmapNote.HandRight
            ? BeatmapNote.HandLeft
            : BeatmapNote.HandRight;
        note.MapNoteData.Hand = newHand;
        noteAppearanceSo.SetNoteAppearance(note);
        BeatmapActionContainer.AddAction(new BeatmapObjectModifiedAction(note.ObjectData, note.ObjectData, original));
    }
}
