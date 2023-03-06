namespace Bannerlord.XPTweaks.Logic
{
    public interface ISettings
    {
        #region Smithing

        float ResearchPointsNeededMultiplier { get; set; }

        bool DisableDifficultyPenalty { get; set; }

        bool AddCraftedItemRarity { get; set; }

        float SmithingEnergyCostMultiplier { get; set; }

        #region Rarity Chance

        float FineWeaponChanceMultiplier { get; set; }

        float MasterworkWeaponChanceMultiplier { get; set; }

        float LegendaryWeaponChanceMultiplier { get; set; }

        #endregion

        #region Rarity Bonus

        int FineWeaponBonusPoints { get; set; }

        int MasterworkWeaponBonusPoints { get; set; }

        int LegendaryWeaponBonusPoints { get; set; }

        #endregion

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
    }
}
