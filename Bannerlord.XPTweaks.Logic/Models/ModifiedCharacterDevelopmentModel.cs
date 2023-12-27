using Bannerlord.XPTweaks.Logic.Tweaks;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.Core;
using TaleWorlds.Localization;

namespace Bannerlord.XPTweaks.Logic.Models
{
    public class ModifiedCharacterDevelopmentModel : DefaultCharacterDevelopmentModel
    {
        private readonly CharacterDevelopmentTweaks _characterDevelopmentTweaks;

        public ModifiedCharacterDevelopmentModel(ISettingsProvider settingsProvider)
        {
            _characterDevelopmentTweaks = new CharacterDevelopmentTweaks(settingsProvider);
        }

        public override ExplainedNumber CalculateLearningRate(int attributeValue, int focusValue, int skillValue, int characterLevel, TextObject attributeName, bool includeDescriptions = false)
        {
            var baseLearningRate = base.CalculateLearningRate(attributeValue, focusValue, skillValue, characterLevel, attributeName, includeDescriptions);

            return _characterDevelopmentTweaks.CalculateLearningRate(baseLearningRate, attributeValue, focusValue, skillValue, characterLevel, attributeName, includeDescriptions);
        }

        public override int LevelsPerAttributePoint
        {
            get
            {
                return _characterDevelopmentTweaks.GetLevelsPerAttributePoint(base.LevelsPerAttributePoint);
            }
        }

        public override int FocusPointsPerLevel
        {
            get
            {
                return _characterDevelopmentTweaks.GetFocusPointsPerLevel(base.FocusPointsPerLevel);
            }
        }

        public override int GetSkillLevelChange(Hero hero, SkillObject skill, float skillXp)
        {
            var baseSkillLevelChange = base.GetSkillLevelChange(hero, skill, skillXp);

            return _characterDevelopmentTweaks.GetSkillLevelChange(baseSkillLevelChange, hero, skill, skillXp);
        }
    }
}
