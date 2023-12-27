using TaleWorlds.CampaignSystem;

namespace Bannerlord.XPTweaks.Logic.Tweaks
{
    public class CharacterXpTweaks
    {
        private readonly ISettingsProvider _settingsProvider;
        public CharacterXpTweaks(ISettingsProvider settingsProvider)
        {
            _settingsProvider = settingsProvider;
        }

        public float GetXpMultiplier(float baseXpMultiplier, Hero hero)
        {
            if (!_settingsProvider.IsInitialized) return baseXpMultiplier;

            if (hero.IsHumanPlayerCharacter)
            {
                return baseXpMultiplier * _settingsProvider.Settings.PlayerXpMultiplier;
            }

            if (hero.Clan == Clan.PlayerClan)
            {
                return baseXpMultiplier * _settingsProvider.Settings.PlayerClanXpMultiplier;
            }

            return baseXpMultiplier * _settingsProvider.Settings.XpMultiplier;
        }
    }
}
