using System.Collections.Generic;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.CampaignBehaviors;
using TaleWorlds.CampaignSystem.CharacterDevelopment;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace Bannerlord.XPTweaks.Logic
{
    public class ModifiedAlleyModel : DefaultAlleyModel
    {
        private readonly ISettingsProvider _settingsProvider;
        public ModifiedAlleyModel(ISettingsProvider settingsProvider)
        {
            _settingsProvider = settingsProvider;
        }

        public override int GetDailyIncomeOfAlley(Alley alley)
        {
            var baseIncome = base.GetDailyIncomeOfAlley(alley);
            if (!_settingsProvider.IsInitialized)
            {
                return baseIncome;
            }

            IAlleyCampaignBehavior campaignBehavior = Campaign.Current.GetCampaignBehavior<IAlleyCampaignBehavior>();
            var assignedMember = campaignBehavior.GetAssignedClanMemberOfAlley(alley);
            var assignedMemberRoguery = assignedMember?.GetSkillValue(DefaultSkills.Roguery) ?? 0;

            var ownerRoguery = alley.Owner.GetSkillValue(DefaultSkills.Roguery);
            var multiplier = (1 +
                assignedMemberRoguery * _settingsProvider.Settings.AlleyIncomeCompanionRogueryFactor +
                ownerRoguery * _settingsProvider.Settings.AlleyIncomePlayerRogueryFactor);

            return MathF.Floor(baseIncome * multiplier);
        }

        public override List<(Hero, AlleyMemberAvailabilityDetail)> GetClanMembersAndAvailabilityDetailsForLeadingAnAlley(Alley alley)
        {
            List<(Hero, AlleyMemberAvailabilityDetail)> list = new();
            foreach (Hero lord in Clan.PlayerClan.Lords)
            {
                if (lord != Hero.MainHero && !lord.IsDead)
                {
                    list.Add((lord, GetAvailability(alley, lord)));
                }
            }

            foreach (Hero companion in Clan.PlayerClan.Companions)
            {
                if (companion != Hero.MainHero && !companion.IsDead)
                {
                    list.Add((companion, GetAvailability(alley, companion)));
                }
            }

            return list;
        }

        private AlleyMemberAvailabilityDetail GetAvailability(Alley alley, Hero hero)
        {
            IAlleyCampaignBehavior campaignBehavior = Campaign.Current.GetCampaignBehavior<IAlleyCampaignBehavior>();
            if (hero.GetSkillValue(DefaultSkills.Roguery) < 30 && !_settingsProvider.Settings.AlleyIgnoreRoguerySkillRequirement)
            {
                return AlleyMemberAvailabilityDetail.NotEnoughRoguerySkill;
            }

            if (hero.GetTraitLevel(DefaultTraits.Mercy) > 0 && !_settingsProvider.Settings.AlleyIgnoreMercifulTraitRequirement)
            {
                return AlleyMemberAvailabilityDetail.NotEnoughMercyTrait;
            }

            if (campaignBehavior != null && campaignBehavior.GetAllAssignedClanMembersForOwnedAlleys().Contains(hero))
            {
                return AlleyMemberAvailabilityDetail.AlreadyAlleyLeader;
            }

            if (!hero.CanLeadParty())
            {
                return AlleyMemberAvailabilityDetail.CanNotLeadParty;
            }

            if (hero.IsPrisoner)
            {
                return AlleyMemberAvailabilityDetail.IsPrisoner;
            }

            if (Campaign.Current.Models.DelayedTeleportationModel.GetTeleportationDelayAsHours(hero, alley.Settlement.Party).BaseNumber > 0f)
            {
                return AlleyMemberAvailabilityDetail.AvailableWithDelay;
            }

            return AlleyMemberAvailabilityDetail.Available;
        }
    }
}
