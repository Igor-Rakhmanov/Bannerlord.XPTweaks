using Bannerlord.XPTweaks.Settings;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;

namespace Bannerlord.XPTweaks
{

    internal class ModifiedGenericXpModel : DefaultGenericXpModel
    {
        public override float GetXpMultiplier(Hero hero)
        {
            var multiplier = base.GetXpMultiplier(hero);

            if (MCMSettings.Instance is null) return multiplier;

            if (hero.IsHumanPlayerCharacter)
            {
                multiplier += MCMSettings.Instance.PlayerXpFactor;
            }
            if (hero.Clan == Clan.PlayerClan)
            {
                multiplier += MCMSettings.Instance.PlayerClanXpFactor;
            }
            multiplier += MCMSettings.Instance.XpFactor;

            return multiplier;
        }
    }
}
