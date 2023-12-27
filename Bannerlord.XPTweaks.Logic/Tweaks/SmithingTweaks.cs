using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.CampaignSystem.CharacterDevelopment;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace Bannerlord.XPTweaks.Logic.Tweaks
{
    public class SmithingTweaks
    {
        private readonly ISettingsProvider _settingsProvider;

        public SmithingTweaks(ISettingsProvider settingsProvider)
        {
            _settingsProvider = settingsProvider;
        }

        public float OverrideResearchPointsForNewPart(float originalPointsValue)
        {
            if (!_settingsProvider.IsInitialized)
            {
                return originalPointsValue;
            }

            return originalPointsValue * _settingsProvider.Settings.ResearchPointsNeededMultiplier;
        }

        public int OverrideEnergyCost(int originalValue)
        {
            if (!_settingsProvider.IsInitialized)
                return originalValue;

            return MathF.Floor(originalValue * _settingsProvider.Settings.SmithingEnergyCostMultiplier);
        }
    }
}
