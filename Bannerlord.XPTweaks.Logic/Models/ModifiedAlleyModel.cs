using System.Collections.Generic;
using Bannerlord.XPTweaks.Logic.Tweaks;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Settlements;

namespace Bannerlord.XPTweaks.Logic.Models
{
    public class ModifiedAlleyModel : DefaultAlleyModel
    {
        private readonly BanditAlleyTweaks _banditAlleyTweaks;

        public ModifiedAlleyModel(ISettingsProvider settingsProvider)
        {
            _banditAlleyTweaks = new BanditAlleyTweaks(settingsProvider);
        }

        public override int GetDailyIncomeOfAlley(Alley alley)
        {
            var baseIncome = base.GetDailyIncomeOfAlley(alley);
            return _banditAlleyTweaks.ModifyDailyIncomeOfAlley(alley, baseIncome);
        }

        public override List<(Hero, AlleyMemberAvailabilityDetail)> GetClanMembersAndAvailabilityDetailsForLeadingAnAlley(Alley alley)
        {
            return _banditAlleyTweaks.GetClanMembersAndAvailabilityDetailsForLeadingAnAlley(alley);
        }
    }
}
