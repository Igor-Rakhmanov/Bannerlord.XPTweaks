using System.Collections.Generic;
using System.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.CampaignBehaviors;
using TaleWorlds.CampaignSystem.CharacterDevelopment;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;
using TaleWorlds.Library;
using static TaleWorlds.CampaignSystem.GameComponents.DefaultAlleyModel;

namespace Bannerlord.XPTweaks.Logic.Tweaks
{
    public class BanditAlleyTweaks
    {
        private readonly ISettingsProvider _settingsProvider;
        public BanditAlleyTweaks(ISettingsProvider settingsProvider)
        {
            _settingsProvider = settingsProvider;
        }

        public int ModifyDailyIncomeOfAlley(Alley alley, int baseIncome)
        {
            if (!_settingsProvider.IsInitialized)
            {
                return baseIncome;
            }

            IAlleyCampaignBehavior campaignBehavior = Campaign.Current.GetCampaignBehavior<IAlleyCampaignBehavior>();
            var assignedMember = campaignBehavior.GetAssignedClanMemberOfAlley(alley);
            var assignedMemberRoguery = assignedMember?.GetSkillValue(DefaultSkills.Roguery) ?? 0;

            var ownerRoguery = alley.Owner.GetSkillValue(DefaultSkills.Roguery);
            var multiplier = 1 +
                assignedMemberRoguery * _settingsProvider.Settings.AlleyIncomeCompanionRogueryFactor +
                ownerRoguery * _settingsProvider.Settings.AlleyIncomePlayerRogueryFactor;

            return MathF.Floor(baseIncome * multiplier);
        }

        public List<(Hero, AlleyMemberAvailabilityDetail)> GetClanMembersAndAvailabilityDetailsForLeadingAnAlley(Alley alley)
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
            var ignoreRogueryRequirement = false;
            var ignoreTraitRequirement = false;

            if (_settingsProvider.IsInitialized)
            {
                ignoreRogueryRequirement = _settingsProvider.Settings.AlleyIgnoreRoguerySkillRequirement;
                ignoreTraitRequirement = _settingsProvider.Settings.AlleyIgnoreMercifulTraitRequirement;
            }

            if (campaignBehavior != null && campaignBehavior.GetIsAlleyUnderAttack(alley))
            {
                return AlleyMemberAvailabilityDetail.AlleyUnderAttack;
            }

            if (hero.GetSkillValue(DefaultSkills.Roguery) < 30 && !ignoreRogueryRequirement)
            {
                return AlleyMemberAvailabilityDetail.NotEnoughRoguerySkill;
            }

            if (hero.GetTraitLevel(DefaultTraits.Mercy) > 0 && !ignoreTraitRequirement)
            {
                return AlleyMemberAvailabilityDetail.NotEnoughMercyTrait;
            }

            if (campaignBehavior != null && campaignBehavior.GetAllAssignedClanMembersForOwnedAlleys().Contains(hero))
            {
                return AlleyMemberAvailabilityDetail.AlreadyAlleyLeader;
            }

            if (hero.GovernorOf != null)
            {
                return AlleyMemberAvailabilityDetail.Governor;
            }

            if (!hero.CanLeadParty())
            {
                return AlleyMemberAvailabilityDetail.CanNotLeadParty;
            }

            if (Campaign.Current.IssueManager.IssueSolvingCompanionList.Contains(hero))
            {
                return AlleyMemberAvailabilityDetail.SolvingIssue;
            }

            if (hero.IsFugitive)
            {
                return AlleyMemberAvailabilityDetail.Fugutive;
            }

            if (hero.IsTraveling)
            {
                return AlleyMemberAvailabilityDetail.Traveling;
            }

            if (hero.IsPrisoner)
            {
                return AlleyMemberAvailabilityDetail.Prisoner;
            }

            if (!hero.IsActive)
            {
                return AlleyMemberAvailabilityDetail.Busy;
            }

            if (hero.IsPartyLeader)
            {
                return AlleyMemberAvailabilityDetail.Busy;
            }

            if (Campaign.Current.Models.DelayedTeleportationModel.GetTeleportationDelayAsHours(hero, alley.Settlement.Party).BaseNumber > 0f)
            {
                return AlleyMemberAvailabilityDetail.AvailableWithDelay;
            }

            return AlleyMemberAvailabilityDetail.Available;
        }
    }
}
