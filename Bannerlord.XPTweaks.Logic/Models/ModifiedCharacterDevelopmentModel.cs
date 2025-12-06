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

        public override ExplainedNumber CalculateLearningRate(
            IReadOnlyPropertyOwner<CharacterAttribute> characterAttributes,
            int focusValue,
            int skillValue,
            SkillObject skill,
            bool includeDescriptions = false)
        {
            var baseLearningRate = base.CalculateLearningRate(characterAttributes, focusValue, skillValue, skill, includeDescriptions);

            return _characterDevelopmentTweaks.CalculateLearningRate(baseLearningRate, characterAttributes, focusValue, skillValue, skill, includeDescriptions);
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
