using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;

namespace Bannerlord.XPTweaks.Settings;

public partial class McmSettings
{
    [SettingPropertyInteger("{=2sHCinTQdkZyq}Levels per attribute point", 1, 10, valueFormat: "0",
        HintText = "{=ZVyDzH8TRQXMB}How many level should character earn to get one attribute point (default = 4)",
        RequireRestart = false, Order = 201)]
    [SettingPropertyGroup(McmSettingsGroupNames.CharacterDevelopment)]
    public int LevelsPerAttributePoint { get; set; } = 4;

    [SettingPropertyInteger("{=FRhnmFMqiWXWI}Focus points per level", 1, 10, valueFormat: "0",
        HintText = "{=wxmlViQ1hYh83}How many focus points will character get with each level up (default = 1)",
        RequireRestart = false, Order = 202)]
    [SettingPropertyGroup(McmSettingsGroupNames.CharacterDevelopment)]
    public int FocusPointPerLevel { get; set; } = 1;
}
