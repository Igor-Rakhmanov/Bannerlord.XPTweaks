using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;

namespace Bannerlord.XPTweaks.Settings;

public partial class McmSettings
{
    [SettingPropertyBool("{=flTNVs6fqrl5T}Convert bandit prisoners without perk",
        HintText = "{=bcdGw16augeky}Ignore 'Veterans Respect' perk requirement. Allows freely upgrading bandit troops (default = false)",
        RequireRestart = false, Order = 2)]
    [SettingPropertyGroup(McmSettingsGroupNames.Party)]
    public bool IgnoreVeteransRespectRequirement { get; set; } = false;
}
