using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;

namespace Bannerlord.XPTweaks.Settings;

public partial class McmSettings
{
    [SettingPropertyFloatingInteger("{=jjuQThMG1DnJz}Renown Multiplier", 1f, 10f, valueFormat: "0.00%",
    HintText = "{=Vn0OnWshqH8Im}Multiplies renown gain, 200% means double renown gain (default = 100%)",
    RequireRestart = false, Order = 1)]
    [SettingPropertyGroup(McmSettingsGroupNames.Renown)]
    public float RenownMultiplier { get; set; } = 1f;
}
