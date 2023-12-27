using Bannerlord.XPTweaks.Logic.Tweaks;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.Core;

namespace Bannerlord.XPTweaks.Logic.Models
{
    public class ModifiedSmithingModel : DefaultSmithingModel
    {
        private readonly SmithingTweaks _smithingTweaks;

        public ModifiedSmithingModel(ISettingsProvider settingsProvider)
        {
            _smithingTweaks = new SmithingTweaks(settingsProvider);
        }

        public override float ResearchPointsNeedForNewPart(int totalPartCount, int openedPartCount)
        {
            var result = base.ResearchPointsNeedForNewPart(totalPartCount, openedPartCount);

            return _smithingTweaks.OverrideResearchPointsForNewPart(result);
        }

        public override int GetEnergyCostForRefining(ref Crafting.RefiningFormula refineFormula, Hero hero)
        {
            var energyCost = base.GetEnergyCostForRefining(ref refineFormula, hero);

            return _smithingTweaks.OverrideEnergyCost(energyCost);
        }

        public override int GetEnergyCostForSmelting(ItemObject item, Hero hero)
        {
            var energyCost = base.GetEnergyCostForSmelting(item, hero);

            return _smithingTweaks.OverrideEnergyCost(energyCost);
        }

        public override int GetEnergyCostForSmithing(ItemObject item, Hero hero)
        {
            var energyCost = base.GetEnergyCostForSmithing(item, hero);

            return _smithingTweaks.OverrideEnergyCost(energyCost);
        }
    }
}
