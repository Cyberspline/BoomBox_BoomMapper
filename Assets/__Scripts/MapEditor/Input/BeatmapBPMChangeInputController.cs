using System.Linq;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class BeatmapBPMChangeInputController : BeatmapInputController<BeatmapBPMChangeContainer>,
    CMInput.IBPMChangeObjectsActions
{
    public override void OnQuickDelete(InputAction.CallbackContext context)
    {
        if (!context.performed || CustomStandaloneInputModule.IsPointerOverGameObject<GraphicRaycaster>(-1, true))
            return;

        RaycastFirstObject(out var obj);

        if (obj == null) return;

        var collection = BeatmapObjectContainerCollection.GetCollectionForType<BPMChangesContainer>(BeatmapObject.ObjectType.BpmChange);

        // TODO: Localize
        if (obj.ObjectData == collection.LoadedObjects.FirstOrDefault())
        {
            PersistentUI.Instance.ShowDialogBox(
                "This BPM Change defines the tempo for the entire map.\nBecause of this, deleting this BPM Change is not allowed.",
                null, PersistentUI.DialogBoxPresetType.Ok);

            return;
        }

        if (!obj.Dragging) StartCoroutine(CompleteDelete(obj));
    }

    public void OnReplaceBPM(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            RaycastFirstObject(out var containerToEdit);
            if (containerToEdit != null)
            {
                PersistentUI.Instance.ShowInputBox("Mapper", "bpm.dialog", s => ChangeBpm(containerToEdit, s),
                    "", containerToEdit.BpmData.Bpm.ToString());
            }
        }
    }

    public void OnTweakBPMValue(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            RaycastFirstObject(out var containerToEdit);
            if (containerToEdit != null)
            {
                var original = BeatmapObject.GenerateCopy(containerToEdit.ObjectData);

                var modifier = context.ReadValue<float>() > 0 ? 1 : -1;

                containerToEdit.BpmData.Bpm += modifier;
                containerToEdit.UpdateGridPosition();

                var bpmChanges =
                    BeatmapObjectContainerCollection.GetCollectionForType<BPMChangesContainer>(BeatmapObject.ObjectType
                        .BpmChange);
                bpmChanges.RefreshModifiedBeat();

                BeatmapActionContainer.AddAction(new BeatmapObjectModifiedAction(containerToEdit.ObjectData,
                    containerToEdit.ObjectData, original));

                // Update cursor position
                var atsc = bpmChanges.AudioTimeSyncController;
                var lastBpmChange = bpmChanges.FindLastBpm(atsc.CurrentBeat);
                if (lastBpmChange == containerToEdit.BpmData)
                {
                    var newTime = lastBpmChange.Time + ((atsc.CurrentBeat - lastBpmChange.Time) *
                        (lastBpmChange.Bpm - modifier) / lastBpmChange.Bpm);
                    atsc.MoveToTimeInBeats(newTime);
                }
            }
        }
    }

    internal static void ChangeBpm(BeatmapBPMChangeContainer containerToEdit, string obj)
    {
        if (string.IsNullOrEmpty(obj) || string.IsNullOrWhiteSpace(obj)) return;
        if (float.TryParse(obj, out var bpm))
        {
            var original = BeatmapObject.GenerateCopy(containerToEdit.ObjectData);
            containerToEdit.BpmData.Bpm = bpm;
            containerToEdit.UpdateGridPosition();
            var bpmChanges =
                BeatmapObjectContainerCollection.GetCollectionForType<BPMChangesContainer>(
                    BeatmapObject.ObjectType.BpmChange);
            bpmChanges.RefreshModifiedBeat();
            BeatmapActionContainer.AddAction(new BeatmapObjectModifiedAction(containerToEdit.ObjectData,
                containerToEdit.ObjectData, original));
        }
        else
        {
            PersistentUI.Instance.ShowInputBox("Mapper", "bpm.dialog.invalid",
                s => ChangeBpm(containerToEdit, s), "", containerToEdit.BpmData.Bpm.ToString());
        }
    }
}
