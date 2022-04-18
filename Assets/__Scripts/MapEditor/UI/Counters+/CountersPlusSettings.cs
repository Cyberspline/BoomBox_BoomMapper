public class CountersPlusSettings : JSONDictionarySetting
{
    public CountersPlusSettings()
    {
        Add("enabled", false);
        Add("Notes", true);
        Add("Notes Per Second", true);
        Add("Red/Blue Ratio", true);
        Add("Obstacles", true);
        Add("BPM Changes", true);
        Add("Current BPM", true);
    }
}
