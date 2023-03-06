using MCM.Abstractions.Attributes.v2;
using MCM.Abstractions.Attributes;

namespace Bannerlord.XPTweaks.Settings;

public partial class McmSettings
{
    #region Factors

    [SettingPropertyFloatingInteger("{NvrOZtU1qXr5w}Player XP Multiplier", 0.01f, 100f, valueFormat: "0.00",
        HintText = "{=dkIWIBYCyKy7l}How much player character will get XP. 2 means your character will get double the XP, 0.5 will leave you only half the amount. This is independent of other xp multipliers (default = 1)",
        RequireRestart = false, Order = 11)]
    [SettingPropertyGroup(McmSettingsGroupNames.ExperienceMultipliers)]
    public float PlayerXpMultiplier { get; set; } = 1;

    [SettingPropertyFloatingInteger("{=f7U5eiuI9gph9}Player Clan XP multiplier", 0.01f, 100f, valueFormat: "0.00",
        HintText = "{=LWSs8jqrtBlyT}How much player clan characters will get XP. This is independent of other xp multipliers (default = 1)",
        RequireRestart = false, Order = 12)]
    [SettingPropertyGroup(McmSettingsGroupNames.ExperienceMultipliers)]
    public float PlayerClanXpMultiplier { get; set; } = 1;

    [SettingPropertyFloatingInteger("{=CVdhi6iOcgT9v}XP multiplier for everyone", 0.01f, 100f, valueFormat: "0.00",
        HintText = "{=0ZRLZGfMBbjEI}How much all other characters will get XP. This is independent of other xp multipliers (default = 1)",
        RequireRestart = false, Order = 13)]
    [SettingPropertyGroup(McmSettingsGroupNames.ExperienceMultipliers)]
    public float XpMultiplier { get; set; } = 1;

    #endregion

    #region Learning rates and limits

    [SettingPropertyFloatingInteger("{=ZoKcokmfk1jnf}Minimum Learning Rate", 0.00f, 10f, valueFormat: "0.00",
        HintText = "{=qPkUT2fPNNUMS}What should minimum learning rate be (default = 0%)",
        RequireRestart = false, Order = 21)]
    [SettingPropertyGroup(McmSettingsGroupNames.ExperienceLearning)]
    public float MinimumLearningRate { get; set; } = 0;

    [SettingPropertyBool("{=27IhzHu2hhztU}Only apply before level 330 reached",
    HintText = "{=fDV1tRkuFdpZv}If checked minimum learning limit will be set to 0 if skill reached level 330, otherwise it will not be reset until level 1024 or one specified in \"Skill level hard cap\" setting (default = true)",
    RequireRestart = false, Order = 22)]
    [SettingPropertyGroup(McmSettingsGroupNames.ExperienceLearning)]
    public bool OnlyApplyLearningRateUntilSoftCapReached { get; set; } = true;

    [SettingPropertyInteger("{=6QjhkpXaUGfan}Skill level hard cap", 330, 1024, valueFormat: "0",
    HintText = "{=EqwVBslVwo9Ch}Skill level will not increase above that value (default = 1024)",
    RequireRestart = false, Order = 23)]
    [SettingPropertyGroup(McmSettingsGroupNames.ExperienceLearning)]
    public int MaxSkillLevels { get; set; } = 1024;

    #endregion

    #region Trade

    [SettingPropertyInteger("{=faEkFGfqJu3rX}Minimum deal amount", 0, 50_000, valueFormat: "0 denars",
        HintText = "{=IAmbtcPLuesd0}Minimum deal amount to start earning additional XP (default = 0 denars)",
        RequireRestart = false, Order = 101)]
    [SettingPropertyGroup(McmSettingsGroupNames.ExperienceTradeAdditionalXp)]
    public int TotalCombinedDealValueMinimum { get; set; } = 0;

    [SettingPropertyFloatingInteger("{=kWNVC5nVH1weq}Denars to XP conversion multiplier", 0.00f, 2f, valueFormat: "0%",
        HintText = "{=LksWn7aH7TQeN}How much XP should you get for total deal denars amount (sold + purchased) (default = 0%)",
        RequireRestart = false, Order = 102)]
    [SettingPropertyGroup(McmSettingsGroupNames.ExperienceTradeAdditionalXp)]
    public float DealValueToXpMultiplier { get; set; } = 0.01f;

    #endregion
}
