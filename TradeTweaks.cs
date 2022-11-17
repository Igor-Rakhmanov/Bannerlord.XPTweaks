using Bannerlord.XPTweaks.Settings;
using System.Collections.Generic;
using System.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;

namespace Bannerlord.XPTweaks
{
    internal class TradeTweaks
    {
        public static void IncreaseTradeOnBigDeals(List<(ItemRosterElement, int)> itemsPurchased, List<(ItemRosterElement, int)> itemsSold, bool isTrade)
        {
            if (!isTrade || MCMSettings.Instance is null) return;

            int totalCombinedDealValue = itemsPurchased.Select(pair => pair.Item2).Sum() + itemsSold.Select(pair => pair.Item2).Sum();
            if (totalCombinedDealValue > MCMSettings.Instance.TotalCombinedDealValueMinimum)
            {
                Hero.MainHero.AddSkillXp(DefaultSkills.Trade, totalCombinedDealValue * MCMSettings.Instance.DealValueToXpMultiplier);
            }
        }
    }
}
