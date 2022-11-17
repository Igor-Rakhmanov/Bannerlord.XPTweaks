using Bannerlord.XPTweaks.Settings;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace Bannerlord.XPTweaks
{
    internal class ModifiedCharacterDevelopmentModel : DefaultCharacterDevelopmentModel
    {
        public override ExplainedNumber CalculateLearningRate(int attributeValue, int focusValue, int skillValue, int characterLevel, TextObject attributeName, bool includeDescriptions = false)
        {
            var defaultLearningRate = base.CalculateLearningRate(attributeValue, focusValue, skillValue, characterLevel, attributeName, includeDescriptions);

            if (MCMSettings.Instance is null) return defaultLearningRate;
            if (MCMSettings.Instance.OnlyApplyLearningRateUntilSoftCapReached && skillValue >= 330) return defaultLearningRate;
            var maxSkillsLevel = MCMSettings.Instance.MaxSkillLevels;

            if (skillValue < maxSkillsLevel)
            {
                defaultLearningRate.LimitMin(MCMSettings.Instance.MinimumLearningRate);
            }

            return defaultLearningRate;
        }

        public override int LevelsPerAttributePoint
        {
            get
            {
                if (MCMSettings.Instance is null) return base.LevelsPerAttributePoint;

                return MCMSettings.Instance.LevelsPerAttributePoint;
            }
        }

        public override int FocusPointsPerLevel
        {
            get
            {
                if (MCMSettings.Instance is null) return base.FocusPointsPerLevel;

                return MCMSettings.Instance.FocusPointPerLevel;
            }
        }

        public override int GetSkillLevelChange(Hero hero, SkillObject skill, float skillXp)
        {
            var skillLevelChange = base.GetSkillLevelChange(hero, skill, skillXp);
            if (MCMSettings.Instance is null) return skillLevelChange;

            var maxSkillsLevel = MCMSettings.Instance.MaxSkillLevels;
            var skillValue = hero.GetSkillValue(skill);

            return MathF.Min(maxSkillsLevel - skillValue, skillLevelChange);
        }
    }
}
