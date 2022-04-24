using UnityEngine;

public class GraphicsQuickSettings : QuickSettings
{
    // TODO: Localize
    protected override void PopulateDialogBox()
    {
        DialogBox.WithTitle("Mapper", "quicksettings.graphics");

        AddSetting<bool>(nameof(Settings.OverviewCamera), "Overview Camera");

        AddSetting<bool>(nameof(Settings.SimplifiedObstacles), "Simplified Obstacles");
        AddSetting<float>(nameof(Settings.ObstacleOpacity), "Obstacle Opacity", 0, 1, 0.05f);

        AddSetting<Color>(nameof(Settings.LeftColor), "Left Drum Color");
        AddSetting<Color>(nameof(Settings.RightColor), "Right Drum Color");
    }
}
