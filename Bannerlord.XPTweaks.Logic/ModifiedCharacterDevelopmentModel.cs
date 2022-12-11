using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace Bannerlord.XPTweaks.Logic
{
    public class ModifiedCharacterDevelopmentModel : DefaultCharacterDevelopmentModel
    {
        private readonly ISettingsProvider _settingsProvider;
        public ModifiedCharacterDevelopmentModel(ISettingsProvider settingsProvider)
        {
            _settingsProvider = settingsProvider;
        }

        public override ExplainedNumber CalculateLearningRate(int attributeValue, int focusValue, int skillValue, int characterLevel, TextObject attributeName, bool includeDescriptions = false)
        {
            var defaultLearningRate = base.CalculateLearningRate(attributeValue, focusValue, skillValue, characterLevel, attributeName, includeDescriptions);

            if (!_settingsProvider.IsInitialized) return defaultLearningRate;
            if (_settingsProvider.Settings.OnlyApplyLearningRateUntilSoftCapReached && skillValue >= 330) return defaultLearningRate;
            var maxSkillsLevel = _settingsProvider.Settings.MaxSkillLevels;

            if (skillValue < maxSkillsLevel)
            {
                defaultLearningRate.LimitMin(_settingsProvider.Settings.MinimumLearningRate);
            }

            return defaultLearningRate;
        }

        public override int LevelsPerAttributePoint
        {
            get
            {
                if (!_settingsProvider.IsInitialized) return base.LevelsPerAttributePoint;

                return _settingsProvider.Settings.LevelsPerAttributePoint;
            }
        }

        public override int FocusPointsPerLevel
        {
            get
            {
                if (!_settingsProvider.IsInitialized) return base.FocusPointsPerLevel;

                return _settingsProvider.Settings.FocusPointPerLevel;
            }
        }

        public override int GetSkillLevelChange(Hero hero, SkillObject skill, float skillXp)
        {
            var skillLevelChange = base.GetSkillLevelChange(hero, skill, skillXp);
            if (!_settingsProvider.IsInitialized) return skillLevelChange;

            var maxSkillsLevel = _settingsProvider.Settings.MaxSkillLevels;
            var skillValue = hero.GetSkillValue(skill);

            return MathF.Min(maxSkillsLevel - skillValue, skillLevelChange);
        }
    }
}
