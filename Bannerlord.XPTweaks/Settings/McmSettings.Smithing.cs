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

    [SettingPropertyBool("{=HrGHQmGKuSce3}Disable difficulty penalty",
        HintText = "{=LpRgJ0iWJs9JG}If enabled you won't get decreased stats when weapon design difficulty is more than crafter's skill level (default = false)",
        RequireRestart = false, Order = 2)]
    [SettingPropertyGroup(McmSettingsGroupNames.Smithing)]
    public bool DisableDifficultyPenalty { get; set; } = false;

    [SettingPropertyBool("{=csL1uigWMDBqu}Add rarity to crafted items name*",
        HintText = "{=rgu9WE9CQYefL}If enabled default crafted weapon name will be prefixed with rarity (Fine, Masterwork, Legendary) if it was triggered by coresponding perk (default = false)\n" +
        "* Experimental feature.",
        RequireRestart = false, Order = 3)]
    [SettingPropertyGroup(McmSettingsGroupNames.Smithing)]
    public bool AddCraftedItemRarity { get; set; } = false;

    [SettingPropertyFloatingInteger("{=9CDiU6UWYWqBF}Smithing stamina cost multiplier", 0f, 1f, valueFormat: "0.00%",
    HintText = "{=fNWy6XDrHgwJR}Modifies stamina cost for all smithing activities (default = 100%)",
    RequireRestart = false, Order = 4)]
    [SettingPropertyGroup(McmSettingsGroupNames.Smithing)]
    public float SmithingEnergyCostMultiplier { get; set; } = 1f;


    #region Rarity Chance

    [SettingPropertyFloatingInteger("{=f2uWrmvUZMzD2}Fine weapon chance multiplier", 0.00f, 10f, valueFormat: "0.00%",
    HintText = "{=Pd4c7iqbrlXKN}Multiplier for chance to create 'Fine' weapon with perk 'Experienced Smith' (10% chance). Perk tooltip will not change (default = 100%)",
    RequireRestart = false, Order = 1)]
    [SettingPropertyGroup(McmSettingsGroupNames.SmithingRarityChance)]
    public float FineWeaponChanceMultiplier { get; set; } = 1f;

    [SettingPropertyFloatingInteger("{=5gbiMLZCb85Te}Masterwork weapon chance multiplier", 0.00f, 10f, valueFormat: "0.00%",
        HintText = "{=kd9PEYAkSBbDg}Multiplier for chance to create 'Masterwork' weapon with perk 'Master Smith' (10% chance). Perk tooltip will not change (default = 100%)",
        RequireRestart = false, Order = 2)]
    [SettingPropertyGroup(McmSettingsGroupNames.SmithingRarityChance)]
    public float MasterworkWeaponChanceMultiplier { get; set; } = 1f;

    [SettingPropertyFloatingInteger("{=yeveWqbRZSsz3}Legendary weapon chance base multiplier", 0.00f, 20f, valueFormat: "0.00%",
    HintText = "{=yIQV0wNgpxvqC}Multiplier for chance to create 'Legendary' weapon with perk 'Legendary Smith' (5% chance + 1% per each skill level above 300). Perk tooltip will not change (default = 100%)",
    RequireRestart = false, Order = 3)]
    [SettingPropertyGroup(McmSettingsGroupNames.SmithingRarityChance)]
    public float LegendaryWeaponChanceMultiplier { get; set; } = 1f;

    #endregion

    #region Rarity Bonus

    [SettingPropertyInteger("{=RnURhml8FkLPC}Fine weapon bonus points", 0, 100, valueFormat: "0",
        HintText = "{=Nll0US7Evrb6J}How many bonus points will crafted weapon get when 'Fine' version is triggered (default = 2)",
        RequireRestart = false, Order = 1)]
    [SettingPropertyGroup(McmSettingsGroupNames.SmithingRarityBonus)]
    public int FineWeaponBonusPoints { get; set; } = 2;

    [SettingPropertyInteger("{=TcpaLF1OmWpCh}Masterwork weapon bonus points", 0, 100, valueFormat: "0",
        HintText = "{=88ezypskzKNEt}How many bonus points will crafted weapon get when 'Masterwork' version is triggered (default = 5)",
        RequireRestart = false, Order = 2)]
    [SettingPropertyGroup(McmSettingsGroupNames.SmithingRarityBonus)]
    public int MasterworkWeaponBonusPoints { get; set; } = 5;

    [SettingPropertyInteger("{=RVi8HLF1RkNO5}Legendary weapon bonus points", 0, 100, valueFormat: "0",
        HintText = "{=Iz4VmzTloKYEl}How many bonus points will crafted weapon get when 'Legendary' version is triggered (default = 10)",
        RequireRestart = false, Order = 3)]
    [SettingPropertyGroup(McmSettingsGroupNames.SmithingRarityBonus)]
    public int LegendaryWeaponBonusPoints { get; set; } = 10;

    #endregion

}
