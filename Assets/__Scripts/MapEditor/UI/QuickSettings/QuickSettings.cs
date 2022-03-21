using System;
using UnityEngine;
using UnityEngine.Localization.Settings;

public abstract class QuickSettings : MonoBehaviour
{
    protected DialogBox DialogBox;
    protected Action OnSubmit;

    public void Open()
    {
        if (DialogBox == null)
        {
            DialogBox = PersistentUI.Instance.CreateNewDialogBox();

            PopulateDialogBox();
        }

        DialogBox.AddFooterButton(null, "PersistentUI", "cancel");
        DialogBox.AddFooterButton(OnSubmit, "PersistentUI", "ok");

        DialogBox.Open();
    }

    protected abstract void PopulateDialogBox();

    protected void AddSetting<T>(string setting, string labelTable, string labelKey, params object[] settingArgs)
        => AddSetting((T)Settings.AllFieldInfos[setting].GetValue(Settings.Instance),
            (v) => Settings.ApplyOptionByName(setting, v),
            labelTable, labelKey, settingArgs);
    
    protected void AddSetting<T>(string setting, string label, params object[] settingArgs)
     => AddSetting((T)Settings.AllFieldInfos[setting].GetValue(Settings.Instance),
         (v) => Settings.ApplyOptionByName(setting, v), label, settingArgs);

    protected void AddSetting<T>(T value, Action<T> onValueChanged,
        string table, string key, params object[] settingArgs)
    {
        var label = LocalizationSettings.StringDatabase.GetLocalizedString(table, key, null);

        AddSetting(value, onValueChanged, label, settingArgs);
    }

    protected void AddSetting<T>(T value, Action<T> onValueChanged, string label, params object[] settingArgs)
    {
        CMUIComponent<T> component = null;

        switch (typeof(T))
        {
            case var t when t == typeof(float):
                component = DialogBox.AddComponent<SliderComponent>()
                    .WithSliderParams(
                        Convert.ToSingle(settingArgs[0]), 
                        Convert.ToSingle(settingArgs[1]), 
                        Convert.ToSingle(settingArgs[2])
                    ) as CMUIComponent<T>;
                break;
            case var t when t == typeof(string):
                component = DialogBox.AddComponent<TextBoxComponent>() as CMUIComponent<T>;
                break;
            case var t when t == typeof(bool):
                component = DialogBox.AddComponent<ToggleComponent>() as CMUIComponent<T>;
                break;
            case var t when t == typeof(Enum):
                component = DialogBox.AddComponent<DropdownComponent>()
                    .WithOptions(t) as CMUIComponent<T>;
                break;
        }

        if (component == null)
        {
            throw new InvalidOperationException($"Cant find suitable CMUI component for type {typeof(T).Name}");
        }

        component.WithLabel(label)
            .WithInitialValue(value);

        OnSubmit += () => onValueChanged?.Invoke(component.Value);
    }
}
