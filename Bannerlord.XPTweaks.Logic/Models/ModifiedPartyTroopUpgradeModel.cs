using Bannerlord.XPTweaks.Logic.Tweaks;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.CharacterDevelopment;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Party;

namespace Bannerlord.XPTweaks.Logic.Models
{
    public class ModifiedPartyTroopUpgradeModel : DefaultPartyTroopUpgradeModel
    {
        private readonly TroopUpgradeTweaks _troopUpgradeTweaks;

        public ModifiedPartyTroopUpgradeModel(ISettingsProvider settingsProvider)
        {
            _troopUpgradeTweaks = new TroopUpgradeTweaks(settingsProvider);
        }

        public override bool DoesPartyHaveRequiredPerksForUpgrade(PartyBase party, CharacterObject character, CharacterObject upgradeTarget, out PerkObject requiredPerk)
        {
            var result = base.DoesPartyHaveRequiredPerksForUpgrade(party, character, upgradeTarget, out requiredPerk);
            return _troopUpgradeTweaks.OverrideRequiredPerks(result, ref requiredPerk);
        }
    }
}
