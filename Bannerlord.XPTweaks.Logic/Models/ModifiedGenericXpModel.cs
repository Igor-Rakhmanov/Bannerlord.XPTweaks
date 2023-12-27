using Bannerlord.XPTweaks.Logic.Tweaks;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;

namespace Bannerlord.XPTweaks.Logic.Models
{

    public class ModifiedGenericXpModel : DefaultGenericXpModel
    {
        private readonly CharacterXpTweaks _characterXpTweaks;

        public ModifiedGenericXpModel(ISettingsProvider settingsProvider)
        {
            _characterXpTweaks = new CharacterXpTweaks(settingsProvider);
        }

        public override float GetXpMultiplier(Hero hero)
        {
            var baseXpMultiplier = base.GetXpMultiplier(hero);

            return _characterXpTweaks.GetXpMultiplier(baseXpMultiplier, hero);
        }
    }
}
