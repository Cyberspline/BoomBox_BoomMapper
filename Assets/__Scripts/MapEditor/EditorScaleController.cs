using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class EditorScaleController : MonoBehaviour, CMInput.IEditorScaleActions
{
    private const float keybindMultiplyValue = 1.25f;
    private const float baseBpm = 160;

    public static float EditorScale = 4;
    public static Action<float> EditorScaleChangedEvent;

    [SerializeField] private Transform moveableGridTransform;
    [SerializeField] private Transform[] scalingOffsets;
    [SerializeField] private AudioTimeSyncController atsc;
    private BeatmapObjectContainerCollection[] collections;
    private float currentBpm = baseBpm;

    private float previousEditorScale = -1;

    // Use this for initialization
    private void Start()
    {
        collections = moveableGridTransform.GetComponents<BeatmapObjectContainerCollection>();
        currentBpm = BoomBoxSongContainer.Instance.Map.BeginningBPM;
        Settings.NotifyBySettingName(nameof(Settings.EditorScale), UpdateEditorScale);
        Settings.NotifyBySettingName(nameof(Settings.EditorScaleBPMIndependent), RecalcEditorScale);
        UpdateEditorScale(Settings.Instance.EditorScale);
    }

    private void OnDestroy()
    {
        Settings.ClearSettingNotifications(nameof(Settings.EditorScale));
        Settings.ClearSettingNotifications(nameof(Settings.EditorScaleBPMIndependent));
    }

    public void OnDecreaseEditorScale(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        Settings.Instance.EditorScale /= keybindMultiplyValue;
        Settings.ManuallyNotifySettingUpdatedEvent("EditorScale", Settings.Instance.EditorScale);
    }

    public void OnIncreaseEditorScale(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        Settings.Instance.EditorScale *= keybindMultiplyValue;
        Settings.ManuallyNotifySettingUpdatedEvent("EditorScale", Settings.Instance.EditorScale);
    }

    public void UpdateEditorScale(object value)
    {
        var setting = (float)value;
        EditorScale = Settings.Instance.EditorScaleBPMIndependent
            ? setting * baseBpm / currentBpm
            : setting;

        if (previousEditorScale != EditorScale) Apply();
    }

    private void RecalcEditorScale(object obj) => UpdateEditorScale(Settings.Instance.EditorScale);

    private void Apply()
    {
        foreach (var collection in collections)
        {
            foreach (var b in collection.LoadedContainers.Values)
                b.UpdateGridPosition();
        }

        atsc.MoveToTimeInSeconds(atsc.CurrentSeconds);
        EditorScaleChangedEvent?.Invoke(EditorScale);
        previousEditorScale = EditorScale;
        foreach (var offset in scalingOffsets)
            offset.localScale = new Vector3(offset.localScale.x, offset.localScale.y, 8 * EditorScale);
    }
}
