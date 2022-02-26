// TODO: Remove
public class MappingExtensionsReq : RequirementCheck
{
    public override string Name => "Mapping Extensions";

    public override RequirementType IsRequiredOrSuggested(BeatSaberSong.DifficultyBeatmap mapInfo, BeatSaberMap map)
        => RequirementType.None;
}
