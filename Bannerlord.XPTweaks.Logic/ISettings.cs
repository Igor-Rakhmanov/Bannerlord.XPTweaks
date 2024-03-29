﻿namespace Bannerlord.XPTweaks.Logic
{
    public interface ISettings
    {
        #region Smithing

        float ResearchPointsNeededMultiplier { get; set; }

        float SmithingEnergyCostMultiplier { get; set; }

        #endregion

        #region Experience

        #region Factors

        float PlayerXpMultiplier { get; set; }

        float PlayerClanXpMultiplier { get; set; }

        float XpMultiplier { get; set; }

        #endregion

        #region Learning rates and limits

        float MinimumLearningRate { get; set; }

        bool OnlyApplyLearningRateUntilSoftCapReached { get; set; }

        int MaxSkillLevels { get; set; }

        #endregion

        #region Trade

        int TotalCombinedDealValueMinimum { get; set; }

        float DealValueToXpMultiplier { get; set; }

        #endregion

        #endregion

        #region Character development

        int LevelsPerAttributePoint { get; set; }

        int FocusPointPerLevel { get; set; }

        #endregion

        #region Renown

        float RenownMultiplier { get; set; }

        #endregion

        #region Party

        bool IgnoreVeteransRespectRequirement { get; set; }

        #endregion

        #region Alley

        float AlleyIncomePlayerRogueryFactor { get; set; }

        float AlleyIncomeCompanionRogueryFactor { get; set; }

        bool AlleyIgnoreRoguerySkillRequirement { get; set; }

        bool AlleyIgnoreMercifulTraitRequirement { get; set; }

        #endregion
    }
}
