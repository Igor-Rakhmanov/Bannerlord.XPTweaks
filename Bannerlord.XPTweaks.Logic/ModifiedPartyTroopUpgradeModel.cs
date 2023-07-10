using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.CharacterDevelopment;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Party;

namespace Bannerlord.XPTweaks.Logic
{
    public class ModifiedPartyTroopUpgradeModel : DefaultPartyTroopUpgradeModel
    {
        private readonly ISettingsProvider _settingsProvider;
        public ModifiedPartyTroopUpgradeModel(ISettingsProvider settingsProvider)
        {
            _settingsProvider = settingsProvider;
        }

        public override bool DoesPartyHaveRequiredPerksForUpgrade(PartyBase party, CharacterObject character, CharacterObject upgradeTarget, out PerkObject requiredPerk)
        {
            var result = base.DoesPartyHaveRequiredPerksForUpgrade(party, character, upgradeTarget, out requiredPerk);
            if (!_settingsProvider.IsInitialized) return result;

            if (_settingsProvider.Settings.IgnoreVeteransRespectRequirement && requiredPerk == DefaultPerks.Leadership.VeteransRespect)
            {
                requiredPerk = null;
                result = true;
            }

            return result;
        }
    }
}
