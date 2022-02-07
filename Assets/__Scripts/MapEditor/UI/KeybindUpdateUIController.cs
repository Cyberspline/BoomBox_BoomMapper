using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class KeybindUpdateUIController : MonoBehaviour, CMInput.IWorkflowsActions
{
    [SerializeField] private PlacementModeController placeMode;
    [SerializeField] private LightingModeController lightMode;
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

    public void OnPlaceBlueNoteorEvent(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        blueToggle.onValueChanged.Invoke(true);
        placeMode.SetMode(PlacementModeController.PlacementMode.Note);
    }

    public void OnPlaceRedNoteorEvent(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        redToggle.onValueChanged.Invoke(true);
        placeMode.SetMode(PlacementModeController.PlacementMode.Note);
    }

    public void OnToggleNoteorEvent(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        if (colorType.LeftSelectedEnabled())
            blueToggle.onValueChanged.Invoke(true);
        else
            redToggle.onValueChanged.Invoke(true);
    }

    public void OnPlaceBomb(InputAction.CallbackContext context)
    {
    }

    public void OnPlaceObstacle(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        placeMode.SetMode(PlacementModeController.PlacementMode.Wall);
    }

    public void OnToggleDeleteTool(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        placeMode.SetMode(PlacementModeController.PlacementMode.Delete);
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

    public void OnUpdateSwingArcVisualizer(InputAction.CallbackContext context)
    {
    }
}
