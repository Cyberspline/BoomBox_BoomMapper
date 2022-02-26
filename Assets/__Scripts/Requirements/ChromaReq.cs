// TODO: Remove
public class ChromaReq : RequirementCheck
{
    public override string Name => "Chroma";

    public override RequirementType IsRequiredOrSuggested(BeatSaberSong.DifficultyBeatmap mapInfo, BeatSaberMap map)
        => RequirementType.None;
}
