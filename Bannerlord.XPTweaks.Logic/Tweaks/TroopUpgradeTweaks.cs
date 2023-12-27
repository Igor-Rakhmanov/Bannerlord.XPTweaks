using TaleWorlds.CampaignSystem.CharacterDevelopment;

namespace Bannerlord.XPTweaks.Logic.Tweaks
{
    public class TroopUpgradeTweaks
    {
        private readonly ISettingsProvider _settingsProvider;
        public TroopUpgradeTweaks(ISettingsProvider settingsProvider)
        {
            _settingsProvider = settingsProvider;
        }

        public bool OverrideRequiredPerks(bool originalResult, ref PerkObject requiredPerk)
        {
            if (!_settingsProvider.IsInitialized) return originalResult;
            if (requiredPerk == null) return originalResult;

            if (_settingsProvider.Settings.IgnoreVeteransRespectRequirement && requiredPerk == DefaultPerks.Leadership.VeteransRespect)
            {
                requiredPerk = null;
                return true;
            }

            return originalResult;
        }
    }
}
