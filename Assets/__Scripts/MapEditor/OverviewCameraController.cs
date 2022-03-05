using UnityEngine;

public class OverviewCameraController : MonoBehaviour
{
    [SerializeField] private GameObject overviewCamera;

    private void Start()
    {
        Settings.NotifyBySettingName(nameof(Settings.OverviewCamera), UpdateOverviewCamera);
        UpdateOverviewCamera(Settings.Instance.OverviewCamera);
    }

    private void UpdateOverviewCamera(object obj) => overviewCamera.SetActive((bool)obj);

    private void OnDestroy() => Settings.ClearSettingNotifications(nameof(Settings.OverviewCamera));
}
