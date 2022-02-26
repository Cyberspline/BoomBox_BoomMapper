using UnityEngine;
using UnityEngine.UI;

public class DeleteToolController : MonoBehaviour
{
    public static bool IsActive { get; private set; }

    [SerializeField] private Toggle deletionToggle;

    public void UpdateDeletion(bool enabled)
    {
        IsActive = enabled;
        deletionToggle.SetIsOnWithoutNotify(enabled);
    }

    public void ToggleDeletion() => UpdateDeletion(!IsActive);
}
