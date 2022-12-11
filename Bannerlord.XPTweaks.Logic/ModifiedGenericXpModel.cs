using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;

namespace Bannerlord.XPTweaks.Logic
{

    public class ModifiedGenericXpModel : DefaultGenericXpModel
    {
        private readonly ISettingsProvider _settingsProvider;
        public ModifiedGenericXpModel(ISettingsProvider settingsProvider)
        {
            _settingsProvider = settingsProvider;
        }

        public override float GetXpMultiplier(Hero hero)
        {
            var multiplier = base.GetXpMultiplier(hero);

            if (!_settingsProvider.IsInitialized) return multiplier;

            if (hero.IsHumanPlayerCharacter)
            {
                multiplier += _settingsProvider.Settings.PlayerXpFactor;
            }
            if (hero.Clan == Clan.PlayerClan)
            {
                multiplier += _settingsProvider.Settings.PlayerClanXpFactor;
            }
            multiplier += _settingsProvider.Settings.XpFactor;

            return multiplier;
        }
    }
}
