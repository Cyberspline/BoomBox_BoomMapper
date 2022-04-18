using TMPro;
using UnityEngine;

public class DifficultyInfo : MonoBehaviour
{
    [SerializeField] private TMP_InputField creator;
    [SerializeField] private TMP_InputField description;
    [SerializeField] private TMP_InputField tags;
    [SerializeField] private TMP_Dropdown style;
    [SerializeField] private TMP_Dropdown biome;

    private BoomBoxMap selectedMap;
    private DifficultySelect select;
    private DifficultySettings settings;

    public void SelectMap(DifficultySelect select, DifficultySettings settings)
    {
        // Turn on/off all fields if map is null
        creator.interactable =
            description.interactable =
            tags.interactable =
            style.interactable =
            biome.interactable =
            settings != null;

        if (settings == null) return;

        this.select = select;
        this.settings = settings;
        selectedMap = settings.Map;

        creator.SetTextWithoutNotify(selectedMap.Creator);
        description.SetTextWithoutNotify(selectedMap.Description);
        tags.SetTextWithoutNotify(selectedMap.Tags);
        style.SetValueWithoutNotify(selectedMap.MapStyle);
        biome.SetValueWithoutNotify(selectedMap.BiomeType);

        creator.onEndEdit.AddListener((_) => select.UpdateDifficultySettings());
        description.onEndEdit.AddListener((_) => select.UpdateDifficultySettings());
        tags.onEndEdit.AddListener((_) => select.UpdateDifficultySettings());
        style.onValueChanged.AddListener((_) => select.UpdateDifficultySettings());
        biome.onValueChanged.AddListener((_) => select.UpdateDifficultySettings());
    }

    public void UpdateCreator(string creator)
    {
        settings.Creator = creator;
        select.UpdateDifficultySettings();
    }

    public void UpdateDescription(string description)
    {
        settings.Description = description;
        select.UpdateDifficultySettings();
    }

    public void UpdateTags(string tags)
    {
        settings.Tags = tags;
        select.UpdateDifficultySettings();
    }

    public void UpdateStyle(int style)
    {
        settings.MapStyle = style;
        select.UpdateDifficultySettings();
    }

    public void UpdateBiome(int biome)
    {
        settings.BiomeType = biome;
        select.UpdateDifficultySettings();
    }
}
