using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessingController : MonoBehaviour
{
    public Volume PostProcess;

    private void Start()
    {
        Settings.NotifyBySettingName(nameof(Settings.ChromaticAberration), UpdateChromaticAberration);

        UpdateChromaticAberration(Settings.Instance.ChromaticAberration);
    }

    public void UpdateChromaticAberration(object o)
    {
        var enabled = Convert.ToBoolean(o);
        PostProcess.profile.TryGet(out ChromaticAberration ca);
        ca.active = enabled;
    }

    private void OnDestroy() => Settings.ClearSettingNotifications(nameof(Settings.ChromaticAberration));
}
