using System;
using System.Collections.Generic;
using System.Text;
using TaleWorlds.CampaignSystem.CharacterDevelopment;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Party;
using Bannerlord.XPTweaks.Settings;

namespace Bannerlord.XPTweaks
{
    internal class ModifiedPartyTroopUpgradeModel : DefaultPartyTroopUpgradeModel
    {
        public override bool DoesPartyHaveRequiredPerksForUpgrade(PartyBase party, CharacterObject character, CharacterObject upgradeTarget, out PerkObject requiredPerk)
        {
            var result = base.DoesPartyHaveRequiredPerksForUpgrade(party, character, upgradeTarget, out requiredPerk);
            if(MCMSettings.Instance is null) return result;

            if (MCMSettings.Instance.IgnoreVeteransRespectRequirement && requiredPerk == DefaultPerks.Leadership.VeteransRespect)
            {
                requiredPerk = null;
                result = true;
            }

            return result;
        }
    }
}
