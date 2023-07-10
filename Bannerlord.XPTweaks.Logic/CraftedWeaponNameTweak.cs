using TaleWorlds.CampaignSystem.ViewModelCollection.WeaponCrafting.WeaponDesign;
using TaleWorlds.Localization;

namespace Bannerlord.XPTweaks.Logic
{
    public class CraftedWeaponNameTweak
    {
        private readonly ISettingsProvider _settingsProvider;
        public CraftedWeaponNameTweak(ISettingsProvider settingsProvider)
        {
            _settingsProvider = settingsProvider;
        }

        public void AddWeaponRarityToName(WeaponDesignVM weaponDesignVM, ref string originalName)
        {
            if (!_settingsProvider.IsInitialized) return;
            if (!_settingsProvider.Settings.AddCraftedItemRarity) return;

            var modifierTier = weaponDesignVM.ModifierTier;
            originalName = weaponDesignVM.ItemName;
            weaponDesignVM.ItemName = GetWeaponNameWithModifierTier(modifierTier, originalName);
        }

        public void RestoreOriginalName(WeaponDesignVM weaponDesignVM, string originalName)
        {
            if (!_settingsProvider.IsInitialized) return;
            if (!_settingsProvider.Settings.AddCraftedItemRarity) return;

            weaponDesignVM.ItemName = originalName;
        }

        private string GetWeaponNameWithModifierTier(int modifierTier, string originalName)
        {
            if (modifierTier <= 0)
            {
                return originalName;
            }

            var prefixTemplateName = modifierTier switch
            {
                1 => "{=Wr8a8SMXCYkxX}Fine {ITEM_NAME}",
                2 => "{=98T9e7pM4IaTh}Masterwork {ITEM_NAME}",
                3 => "{=RiUyBG6mucouB}Legendary {ITEM_NAME}",
                _ => "{=RiUyBG6mucouB}Legendary {ITEM_NAME}"
            };

            var weaponTemplatePrefix = new TextObject(prefixTemplateName);
            weaponTemplatePrefix.SetTextVariable("ITEM_NAME", originalName);
            return weaponTemplatePrefix.ToString();
        }
    }
}
