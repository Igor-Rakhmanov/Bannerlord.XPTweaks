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
                return multiplier * _settingsProvider.Settings.PlayerXpMultiplier;
            }

            if (hero.Clan == Clan.PlayerClan)
            {
                return multiplier * _settingsProvider.Settings.PlayerClanXpMultiplier;
            }

            return multiplier * _settingsProvider.Settings.XpMultiplier;
        }
    }
}
