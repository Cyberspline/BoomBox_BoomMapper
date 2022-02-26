// TODO: Remove
public class LegacyChromaReq : RequirementCheck
{
    public override string Name => "Chroma Lighting Events";

    public override RequirementType IsRequiredOrSuggested(BeatSaberSong.DifficultyBeatmap mapInfo, BeatSaberMap map)
        => RequirementType.None;
}
