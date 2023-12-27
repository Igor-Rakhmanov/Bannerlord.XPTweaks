using System.Collections.Generic;
using System.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;

namespace Bannerlord.XPTweaks.Logic.Tweaks
{
    public class TradeTweaks
    {
        private readonly ISettingsProvider _settingsProvider;

        public TradeTweaks(ISettingsProvider settingsProvider)
        {
            _settingsProvider = settingsProvider;
        }

        public void IncreaseTradeOnBigDeals(List<(ItemRosterElement, int)> itemsPurchased, List<(ItemRosterElement, int)> itemsSold, bool isTrade)
        {
            if (!isTrade || !_settingsProvider.IsInitialized) return;

            int totalCombinedDealValue = itemsPurchased.Select(pair => pair.Item2).Sum() + itemsSold.Select(pair => pair.Item2).Sum();
            if (totalCombinedDealValue > _settingsProvider.Settings.TotalCombinedDealValueMinimum)
            {
                Hero.MainHero.AddSkillXp(DefaultSkills.Trade, totalCombinedDealValue * _settingsProvider.Settings.DealValueToXpMultiplier);
            }
        }
    }
}
