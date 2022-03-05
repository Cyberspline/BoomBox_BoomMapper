public class GraphicsQuickSettings : QuickSettings
{
    // TODO: Localize
    protected override void PopulateDialogBox()
    {
        DialogBox.WithTitle("Mapper", "quicksettings.graphics");

        // TODO: Remove
        DialogBox.AddComponent<TextComponent>().WithInitialValue("It's a little empty, let me know what should go here.");

        AddSetting<bool>(nameof(Settings.OverviewCamera), "Overview Camera");
    }
}
