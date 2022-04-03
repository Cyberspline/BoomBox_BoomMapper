public class CopySource
{
    public CopySource(DifficultySettings difficultySettings, DifficultyRow obj)
    {
        DifficultySettings = difficultySettings;
        Obj = obj;
    }

    public DifficultySettings DifficultySettings { get; }
    public DifficultyRow Obj { get; }
}
