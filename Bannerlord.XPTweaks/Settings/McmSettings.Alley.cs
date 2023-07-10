using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;

namespace Bannerlord.XPTweaks.Settings;

public partial class McmSettings
{
    [SettingPropertyFloatingInteger("{=vIhsgJwm6POuZ}Income multiplier from player roguery", 0f, 1f, "0.000%",
    HintText = "{=9ZnhSP2qKVqlE}Increases alley income based on player roguery (default = 0)",
    RequireRestart = false, Order = 1)]
    [SettingPropertyGroup(McmSettingsGroupNames.Alley)]
    public float AlleyIncomePlayerRogueryFactor { get; set; } = 0f;

    [SettingPropertyFloatingInteger("{=iLX2arxbaDaOm}Income multiplier from assigned alley clan member roguery", 0f, 1f, "0.000%",
    HintText = "{=ZFVm8l4SAHJBG}Increases alley income based on assigned alley clan member roguery (default = 0)",
    RequireRestart = false, Order = 1)]
    [SettingPropertyGroup(McmSettingsGroupNames.Alley)]
    public float AlleyIncomeCompanionRogueryFactor { get; set; } = 0f;

    [SettingPropertyBool("{=VUq8M64tb6sD6}Ignore roguery skill requirement",
        HintText = "{=V008hYt4sMpye}Ignore roquery skill requirement for party member to become alley leader",
        RequireRestart = false)]
    [SettingPropertyGroup(McmSettingsGroupNames.Alley)]
    public bool AlleyIgnoreRoguerySkillRequirement { get; set; } = false;

    [SettingPropertyBool("{=PJsqwS0QXkoCN}Ignore merciful trait requirement",
        HintText = "{=AMzxRpwoF8Yde}Ignore merciful trait requirement for party member to become alley leader",
        RequireRestart = false)]
    [SettingPropertyGroup(McmSettingsGroupNames.Alley)]
    public bool AlleyIgnoreMercifulTraitRequirement { get; set; } = false;
}
