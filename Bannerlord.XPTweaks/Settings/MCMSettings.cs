using System.Collections.Generic;
using Bannerlord.XPTweaks.Logic;
using MCM.Abstractions;
using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;
using MCM.Abstractions.Base.Global;
using TaleWorlds.Localization;

namespace Bannerlord.XPTweaks.Settings;

public class MCMSettings : AttributeGlobalSettings<MCMSettings>, ISettings
{
    public override string Id => "Bannerlord_XPTweaks_v1_0";
    public override string DisplayName => $"Bannerlord XP Tweaks";
    public override string FolderName => "XP Tweaks";
    public override string FormatType => "json";

    #region Smithing

    [SettingPropertyFloatingInteger("{=ugKrmOzjyPQwg}Parts research speed multiplier", 0.01f, 1f, valueFormat: "0.00%",
        HintText = "{=kbcKX2c9JgEua}Modifies speed of researching new smithing parts. The lesser number means faster research (default = 100%)",
        RequireRestart = false, Order = 1)]
    [SettingPropertyGroup(MCMSettingsGroupNames.Smithing)]
    public float ResearchPointsNeededMultiplier { get; set; } = 1f;

    [SettingPropertyBool("{=HrGHQmGKuSce3}Disable difficulty penalty",
        HintText = "{=LpRgJ0iWJs9JG}If enabled you won't get decreased stats when weapon design difficulty is more than crafter's skill level (default = false)", 
        RequireRestart = false, Order = 2)]
    [SettingPropertyGroup(MCMSettingsGroupNames.Smithing)]
    public bool DisableDifficultyPenalty { get; set; } = false;

    [SettingPropertyBool("{=csL1uigWMDBqu}Add rarity to crafted items name*",
        HintText = "{=rgu9WE9CQYefL}If enabled default crafted weapon name will be prefixed with rarity (Fine, Masterwork, Legendary) if it was triggered by coresponding perk (default = false)\n" +
        "* Experimental feature.", 
        RequireRestart = false, Order = 3)]
    [SettingPropertyGroup(MCMSettingsGroupNames.Smithing)]
    public bool AddCraftedItemRarity { get; set; } = false;

    [SettingPropertyFloatingInteger("{=9CDiU6UWYWqBF}Smithing stamina cost multiplier", 0f, 1f, valueFormat: "0.00%",
    HintText = "{=fNWy6XDrHgwJR}Modifies stamina cost for all smithing activities (default = 100%)",
    RequireRestart = false, Order = 4)]
    [SettingPropertyGroup(MCMSettingsGroupNames.Smithing)]
    public float SmithingEnergyCostMultiplier { get; set; } = 1f;

    #region Rarity Chance

    [SettingPropertyFloatingInteger("{=f2uWrmvUZMzD2}Fine weapon chance multiplier", 0.00f, 10f, valueFormat: "0.00%",
    HintText = "{=Pd4c7iqbrlXKN}Multiplier for chance to create 'Fine' weapon with perk 'Experienced Smith' (10% chance). Perk tooltip will not change (default = 100%)",
    RequireRestart = false, Order = 1)]
    [SettingPropertyGroup(MCMSettingsGroupNames.SmithingRarityChance)]
    public float FineWeaponChanceMultiplier { get; set; } = 1f;

    [SettingPropertyFloatingInteger("{=5gbiMLZCb85Te}Masterwork weapon chance multiplier", 0.00f, 10f, valueFormat: "0.00%",
        HintText = "{=kd9PEYAkSBbDg}Multiplier for chance to create 'Masterwork' weapon with perk 'Master Smith' (10% chance). Perk tooltip will not change (default = 100%)",
        RequireRestart = false, Order = 2)]
    [SettingPropertyGroup(MCMSettingsGroupNames.SmithingRarityChance)]
    public float MasterworkWeaponChanceMultiplier { get; set; } = 1f;

    [SettingPropertyFloatingInteger("{=yeveWqbRZSsz3}Legendary weapon chance base multiplier", 0.00f, 20f, valueFormat: "0.00%",
    HintText = "{=yIQV0wNgpxvqC}Multiplier for chance to create 'Legendary' weapon with perk 'Legendary Smith' (5% chance + 1% per each skill level above 300). Perk tooltip will not change (default = 100%)",
    RequireRestart = false, Order = 3)]
    [SettingPropertyGroup(MCMSettingsGroupNames.SmithingRarityChance)]
    public float LegendaryWeaponChanceMultiplier { get; set; } = 1f;

    #endregion

    #region Rarity Bonus

    [SettingPropertyInteger("{=RnURhml8FkLPC}Fine weapon bonus points", 0, 100, valueFormat: "0",
        HintText = "{=Nll0US7Evrb6J}How many bonus points will crafted weapon get when 'Fine' version is triggered (default = 2)",
        RequireRestart = false, Order = 1)]
    [SettingPropertyGroup(MCMSettingsGroupNames.SmithingRarityBonus)]
    public int FineWeaponBonusPoints { get; set; } = 2;

    [SettingPropertyInteger("{=TcpaLF1OmWpCh}Masterwork weapon bonus points", 0, 100, valueFormat: "0",
        HintText = "{=88ezypskzKNEt}How many bonus points will crafted weapon get when 'Masterwork' version is triggered (default = 5)",
        RequireRestart = false, Order = 2)]
    [SettingPropertyGroup(MCMSettingsGroupNames.SmithingRarityBonus)]
    public int MasterworkWeaponBonusPoints { get; set; } = 5;

    [SettingPropertyInteger("{=RVi8HLF1RkNO5}Legendary weapon bonus points", 0, 100, valueFormat: "0",
        HintText = "{=Iz4VmzTloKYEl}How many bonus points will crafted weapon get when 'Legendary' version is triggered (default = 10)",
        RequireRestart = false, Order = 3)]
    [SettingPropertyGroup(MCMSettingsGroupNames.SmithingRarityBonus)]
    public int LegendaryWeaponBonusPoints { get; set; } = 10;

    #endregion

    #endregion

    #region Experience

    #region Factors

    [SettingPropertyFloatingInteger("{NvrOZtU1qXr5w}Player XP Factor", 0.00f, 10f, valueFormat: "0.00%",
        HintText = "{=dkIWIBYCyKy7l}How much more should player character get XP. 100% means your character will get double the XP. This is additive with other xp factors (default = 0%)",
        RequireRestart = false, Order = 11)]
    [SettingPropertyGroup(MCMSettingsGroupNames.ExperienceFactors)]
    public float PlayerXpFactor { get; set; } = 0;

    [SettingPropertyFloatingInteger("{=f7U5eiuI9gph9}Player Clan XP Factor", 0.00f, 10f, valueFormat: "0.00%",
        HintText = "{=LWSs8jqrtBlyT}How much more should player clan characters get XP. This is additive with other xp factors (default = 0%)",
        RequireRestart = false, Order = 12)]
    [SettingPropertyGroup(MCMSettingsGroupNames.ExperienceFactors)]
    public float PlayerClanXpFactor { get; set; } = 0;

    [SettingPropertyFloatingInteger("{=CVdhi6iOcgT9v}XP Factor for everyone", 0.00f, 10f, valueFormat: "0.00%",
        HintText = "{=0ZRLZGfMBbjEI}How much more should all characters get XP. This is additive with other xp factors (default = 0%)",
        RequireRestart = false, Order = 13)]
    [SettingPropertyGroup(MCMSettingsGroupNames.ExperienceFactors)]
    public float XpFactor { get; set; } = 0;

    #endregion

    #region Learning rates and limits

    [SettingPropertyFloatingInteger("{=ZoKcokmfk1jnf}Minimum Learning Rate", 0.00f, 10f, valueFormat: "0.00",
        HintText = "{=qPkUT2fPNNUMS}What should minimum learning rate be (default = 0%)",
        RequireRestart = false, Order = 21)]
    [SettingPropertyGroup(MCMSettingsGroupNames.ExperienceLearning)]
    public float MinimumLearningRate { get; set; } = 0;

    [SettingPropertyBool("{=27IhzHu2hhztU}Only apply before level 330 reached",
    HintText = "{=fDV1tRkuFdpZv}If checked minimum learning limit will be set to 0 if skill reached level 330, otherwise it will not be reset until level 1024 or one specified in \"Skill level hard cap\" setting (default = true)",
    RequireRestart = false, Order = 22)]
    [SettingPropertyGroup(MCMSettingsGroupNames.ExperienceLearning)]
    public bool OnlyApplyLearningRateUntilSoftCapReached { get; set; } = true;

    [SettingPropertyInteger("{=6QjhkpXaUGfan}Skill level hard cap", 330, 1024, valueFormat: "0",
    HintText = "{=EqwVBslVwo9Ch}Skill level will not increase above that value (default = 1024)",
    RequireRestart = false, Order = 23)]
    [SettingPropertyGroup(MCMSettingsGroupNames.ExperienceLearning)]
    public int MaxSkillLevels { get; set; } = 1024;

    #endregion

    #region Trade

    [SettingPropertyInteger("{=faEkFGfqJu3rX}Minimum deal amount", 0, 50_000, valueFormat: "0 denars",
        HintText = "{=IAmbtcPLuesd0}Minimum deal amount to start earning additional XP (default = 0 denars)",
        RequireRestart = false, Order = 101)]
    [SettingPropertyGroup(MCMSettingsGroupNames.ExperienceTradeAdditionalXp)]
    public int TotalCombinedDealValueMinimum { get; set; } = 0;

    [SettingPropertyFloatingInteger("{=kWNVC5nVH1weq}Denars to XP conversion multiplier", 0.00f, 2f, valueFormat: "0%",
        HintText = "{=LksWn7aH7TQeN}How much XP should you get for total deal denars amount (sold + purchased) (default = 0%)",
        RequireRestart = false, Order = 102)]
    [SettingPropertyGroup(MCMSettingsGroupNames.ExperienceTradeAdditionalXp)]
    public float DealValueToXpMultiplier { get; set; } = 0.01f; 

    #endregion

    #endregion

    #region Character development

    [SettingPropertyInteger("{=2sHCinTQdkZyq}Levels per attribute point", 1, 10, valueFormat: "0",
        HintText = "{=ZVyDzH8TRQXMB}How many level should character earn to get one attribute point (default = 4)",
        RequireRestart = false, Order = 201)]
    [SettingPropertyGroup(MCMSettingsGroupNames.CharacterDevelopment)]
    public int LevelsPerAttributePoint { get; set; } = 4;

    [SettingPropertyInteger("{=FRhnmFMqiWXWI}Focus points per level", 1, 10, valueFormat: "0",
        HintText = "{=wxmlViQ1hYh83}How many focus points will character get with each level up (default = 1)",
        RequireRestart = false, Order = 202)]
    [SettingPropertyGroup(MCMSettingsGroupNames.CharacterDevelopment)]
    public int FocusPointPerLevel { get; set; } = 1;

    #endregion

    #region Renown

    [SettingPropertyFloatingInteger("{=jjuQThMG1DnJz}Renown Multiplier", 1f, 10f, valueFormat: "0.00%",
    HintText = "{=Vn0OnWshqH8Im}Multiplies renown gain, 200% means double renown gain (default = 100%)",
    RequireRestart = false, Order = 1)]
    [SettingPropertyGroup(MCMSettingsGroupNames.Renown)]
    public float RenownMultiplier { get; set; } = 1f;

    #endregion

    #region Party

    [SettingPropertyBool("{=flTNVs6fqrl5T}Convert bandit prisoners without perk",
        HintText = "{=bcdGw16augeky}Ignore 'Veterans Respect' perk requirement. Allows freely upgrading bandit troops (default = false)",
        RequireRestart = false, Order = 2)]
    [SettingPropertyGroup(MCMSettingsGroupNames.Party)]
    public bool IgnoreVeteransRespectRequirement { get; set; } = false;

    #endregion

    public override IEnumerable<ISettingsPreset> GetBuiltInPresets()
    {
        yield return new MemorySettingsPreset(Id, "default", new TextObject("{=fHJABbrtIf6Tc}Default").ToString(), () => new MCMSettings());

        yield return new MemorySettingsPreset(Id, "comfortable_game", new TextObject("{=F8mTxNSWrksUx}Comfortable Game").ToString(), () => new MCMSettings
        {
            ResearchPointsNeededMultiplier = 0.1f,
            PlayerXpFactor = 1f,
            PlayerClanXpFactor = 1f,
            XpFactor = 0f,
            MinimumLearningRate = 1f,
            TotalCombinedDealValueMinimum = 5000,
            DealValueToXpMultiplier = 0.02f,
            OnlyApplyLearningRateUntilSoftCapReached = true,
            LevelsPerAttributePoint = 4,
            FocusPointPerLevel = 1,
            MaxSkillLevels = 1024,
            DisableDifficultyPenalty = true,
        });

        yield return new MemorySettingsPreset(Id, "max", new TextObject("{=JtEak4UKodfw4}Insane increase").ToString(), () => new MCMSettings
        {
            ResearchPointsNeededMultiplier = 0.01f,
            PlayerXpFactor = 10f,
            PlayerClanXpFactor = 10f,
            XpFactor = 0f,
            MinimumLearningRate = 10f,
            TotalCombinedDealValueMinimum = 0,
            DealValueToXpMultiplier = 2f,
            OnlyApplyLearningRateUntilSoftCapReached = false,
            LevelsPerAttributePoint = 1,
            FocusPointPerLevel = 10,
            MaxSkillLevels = 1024,
            DisableDifficultyPenalty = true,
            FineWeaponBonusPoints = 25,
            MasterworkWeaponBonusPoints = 50,
            LegendaryWeaponBonusPoints = 100,
            FineWeaponChanceMultiplier = 10f,
            MasterworkWeaponChanceMultiplier = 10f,
            LegendaryWeaponChanceMultiplier = 20f,
            SmithingEnergyCostMultiplier = 0f,
            RenownMultiplier = 10f,
            IgnoreVeteransRespectRequirement = true,
        });
    }
}

