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

    public void SelectMap(BoomBoxMap map)
    {
        selectedMap = map;

        // Turn on/off all fields if map is null
        creator.interactable = 
            description.interactable =
            tags.interactable =
            style.interactable =
            biome.interactable =
            map != null;

        if (map == null) return;

        creator.SetTextWithoutNotify(map.Creator);
        description.SetTextWithoutNotify(map.Description);
        tags.SetTextWithoutNotify(map.Tags);
        style.SetValueWithoutNotify(map.MapStyle);
        biome.SetValueWithoutNotify(map.BiomeType);
    }

    public void UpdateCreator(string creator) => selectedMap.Creator = creator;

    public void UpdateDescription(string description) => selectedMap.Description = description;

    public void UpdateTags(string tags) => selectedMap.Tags = tags;

    public void UpdateStyle (int style) => selectedMap.MapStyle = style;

    public void UpdateBiome(int biome) => selectedMap.BiomeType = biome;

}
