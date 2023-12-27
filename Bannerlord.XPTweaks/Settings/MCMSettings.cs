using Bannerlord.XPTweaks.Logic;
using MCM.Abstractions;
using MCM.Abstractions.Base.Global;
using System.Collections.Generic;
using TaleWorlds.Localization;

namespace Bannerlord.XPTweaks.Settings;

public partial class McmSettings : AttributeGlobalSettings<McmSettings>, ISettings
{
    public override string Id => "Bannerlord_XPTweaks_v2_1";
    public override string DisplayName => $"Bannerlord XP Tweaks";
    public override string FolderName => "XP Tweaks";
    public override string FormatType => "json";

    public override IEnumerable<ISettingsPreset> GetBuiltInPresets()
    {
        yield return new MemorySettingsPreset(Id, "default", new TextObject("{=fHJABbrtIf6Tc}Default").ToString(), () => new McmSettings());

        yield return new MemorySettingsPreset(Id, "comfortable_game", new TextObject("{=F8mTxNSWrksUx}Comfortable Game").ToString(), () => new McmSettings
        {
            ResearchPointsNeededMultiplier = 0.1f,
            PlayerXpMultiplier = 2f,
            PlayerClanXpMultiplier = 2f,
            XpMultiplier = 1f,
            MinimumLearningRate = 1f,
            TotalCombinedDealValueMinimum = 5000,
            DealValueToXpMultiplier = 0.02f,
            OnlyApplyLearningRateUntilSoftCapReached = true,
            LevelsPerAttributePoint = 4,
            FocusPointPerLevel = 1,
            MaxSkillLevels = 1024,
            AlleyIncomeCompanionRogueryFactor = 0.02f,
            AlleyIncomePlayerRogueryFactor = 0.01f,
            AlleyIgnoreRoguerySkillRequirement = true,
            AlleyIgnoreMercifulTraitRequirement = true,
        });

        yield return new MemorySettingsPreset(Id, "max", new TextObject("{=JtEak4UKodfw4}Insane increase").ToString(), () => new McmSettings
        {
            ResearchPointsNeededMultiplier = 0.01f,
            PlayerXpMultiplier = 100f,
            PlayerClanXpMultiplier = 100f,
            XpMultiplier = 1f,
            MinimumLearningRate = 10f,
            TotalCombinedDealValueMinimum = 0,
            DealValueToXpMultiplier = 2f,
            OnlyApplyLearningRateUntilSoftCapReached = false,
            LevelsPerAttributePoint = 1,
            FocusPointPerLevel = 10,
            MaxSkillLevels = 1024,
            SmithingEnergyCostMultiplier = 0f,
            RenownMultiplier = 10f,
            IgnoreVeteransRespectRequirement = true,
            AlleyIncomeCompanionRogueryFactor = 1f,
            AlleyIncomePlayerRogueryFactor = 1f,
            AlleyIgnoreRoguerySkillRequirement = true,
            AlleyIgnoreMercifulTraitRequirement = true,
        });
    }
}