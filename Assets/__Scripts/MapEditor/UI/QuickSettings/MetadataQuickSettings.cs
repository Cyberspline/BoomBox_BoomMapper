using System.Collections;
public class MetadataQuickSettings : QuickSettings
{
    // TODO: Localize everything
    protected override void PopulateDialogBox()
    {
        var pack = BoomBoxSongContainer.Instance.Pack;
        var map = BoomBoxSongContainer.Instance.Map;

        DialogBox.WithTitle("Metadata Settings");

        DialogBox.AddComponent<TextComponent>().WithInitialValue("Pack");

        AddSetting(pack.SongTitle, (title) => pack.SongTitle = title, "Song Title");
        AddSetting(pack.SongArtist, (artist) => pack.SongArtist = artist, "Song Artist");

        // Preview time needs to be done a little differently
        var previewTime = DialogBox.AddComponent<TextBoxComponent>()
            .WithLabel("Preview Time (Seconds)")
            .WithContentType(TMPro.TMP_InputField.ContentType.DecimalNumber)
            .WithInitialValue((pack.PreviewTime / 1000).ToString());

        OnSubmit += () => pack.PreviewTime = float.Parse(previewTime.Value) * 1000;

        DialogBox.AddComponent<TextComponent>().WithInitialValue("Map");

        AddSetting(map.DifficultyName, (name) => map.DifficultyName = name, "Name");
        AddSetting(map.Creator, (creator) => map.Creator = creator, "Creator");
        AddSetting(map.Description, (description) => map.Description = description, "Description");
        AddSetting(map.Tags, (tags) => map.Tags = tags, "Tags");
    }
}
