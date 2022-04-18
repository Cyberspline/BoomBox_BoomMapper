using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class KeybindUpdateUIController : MonoBehaviour, CMInput.IWorkflowsActions
{
    [SerializeField] private DeleteToolController deleteToolController;
    [SerializeField] private PrecisionStepDisplayController stepController;
    [SerializeField] private RightButtonPanel rightButtonPanel;

    [SerializeField] private MirrorSelection mirror;

    [SerializeField] private ColorTypeController colorType;
    [SerializeField] private Toggle redToggle;
    [SerializeField] private Toggle blueToggle;

    public void OnSwapCursorInterval(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        stepController.SwapSelectedInterval();
    }

    public void OnToggleRightButtonPanel(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        rightButtonPanel.TogglePanel();
    }

    public void OnPlaceBlueNote(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        blueToggle.onValueChanged.Invoke(true);
        deleteToolController.UpdateDeletion(false);
    }

    public void OnPlaceRedNote(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        redToggle.onValueChanged.Invoke(true);
        deleteToolController.UpdateDeletion(false);
    }

    public void OnToggleNoteColor(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        if (colorType.LeftSelectedEnabled())
            blueToggle.onValueChanged.Invoke(true);
        else
            redToggle.onValueChanged.Invoke(true);
    }

    public void OnToggleDeleteTool(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        deleteToolController.UpdateDeletion(true);
    }

    public void OnMirror(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        mirror.Mirror();
    }

    public void OnMirrorinTime(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        mirror.MirrorTime();
    }

    public void OnMirrorColoursOnly(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        mirror.Mirror(false);
    }
}
