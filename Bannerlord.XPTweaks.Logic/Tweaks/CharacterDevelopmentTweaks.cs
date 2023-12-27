using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace Bannerlord.XPTweaks.Logic.Tweaks
{
    public class CharacterDevelopmentTweaks
    {
        private readonly ISettingsProvider _settingsProvider;
        public CharacterDevelopmentTweaks(ISettingsProvider settingsProvider)
        {
            _settingsProvider = settingsProvider;
        }

        public ExplainedNumber CalculateLearningRate(ExplainedNumber baseLearningRate, int attributeValue, int focusValue, int skillValue, int characterLevel, TextObject attributeName, bool includeDescriptions = false)
        {

            if (!_settingsProvider.IsInitialized) return baseLearningRate;
            if (_settingsProvider.Settings.OnlyApplyLearningRateUntilSoftCapReached && skillValue >= 330) return baseLearningRate;
            var maxSkillsLevel = _settingsProvider.Settings.MaxSkillLevels;

            if (skillValue < maxSkillsLevel)
            {
                baseLearningRate.LimitMin(_settingsProvider.Settings.MinimumLearningRate);
            }

            return baseLearningRate;
        }

        public int GetLevelsPerAttributePoint(int baseLevelsPerAttributePoint)
        {
            if (!_settingsProvider.IsInitialized) return baseLevelsPerAttributePoint;

            return _settingsProvider.Settings.LevelsPerAttributePoint;
        }

        public int GetFocusPointsPerLevel(int baseFocusPointsPerLevel)
        {
            if (!_settingsProvider.IsInitialized) return baseFocusPointsPerLevel;

            return _settingsProvider.Settings.FocusPointPerLevel;
        }

        public int GetSkillLevelChange(int baseSkillLevelChange, Hero hero, SkillObject skill, float skillXp)
        {
            if (!_settingsProvider.IsInitialized) return baseSkillLevelChange;

            var maxSkillsLevel = _settingsProvider.Settings.MaxSkillLevels;
            var skillValue = hero.GetSkillValue(skill);

            return MathF.Min(maxSkillsLevel - skillValue, baseSkillLevelChange);
        }
    }
}
