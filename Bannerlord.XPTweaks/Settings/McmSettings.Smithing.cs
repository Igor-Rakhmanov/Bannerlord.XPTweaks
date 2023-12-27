using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;

namespace Bannerlord.XPTweaks.Settings;

public partial class McmSettings
{

    [SettingPropertyFloatingInteger("{=ugKrmOzjyPQwg}Parts research speed multiplier", 0.01f, 1f, valueFormat: "0.00%",
        HintText = "{=kbcKX2c9JgEua}Modifies speed of researching new smithing parts. The lesser number means faster research (default = 100%)",
        RequireRestart = false, Order = 1)]
    [SettingPropertyGroup(McmSettingsGroupNames.Smithing)]
    public float ResearchPointsNeededMultiplier { get; set; } = 1f;

    [SettingPropertyFloatingInteger("{=9CDiU6UWYWqBF}Smithing stamina cost multiplier", 0f, 1f, valueFormat: "0.00%",
    HintText = "{=fNWy6XDrHgwJR}Modifies stamina cost for all smithing activities (default = 100%)",
    RequireRestart = false, Order = 4)]
    [SettingPropertyGroup(McmSettingsGroupNames.Smithing)]
    public float SmithingEnergyCostMultiplier { get; set; } = 1f;

}
