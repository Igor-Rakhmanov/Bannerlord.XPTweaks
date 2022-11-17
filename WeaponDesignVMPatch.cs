using Bannerlord.XPTweaks.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem.ViewModelCollection.WeaponCrafting.WeaponDesign;
using TaleWorlds.Localization;

namespace Bannerlord.XPTweaks
{
    [HarmonyPatch(typeof(WeaponDesignVM), nameof(WeaponDesignVM.CreateCraftingResultPopup))]
    public class WeaponDesignVMPatch
    {
        public static void Prefix(WeaponDesignVM __instance, ref string __state)
        {
            if (MCMSettings.Instance is null || !MCMSettings.Instance.AddCraftedItemRarity) return;

            var modifierTier = __instance.ModifierTier;
            var originalName = __instance.ItemName;
            __state = originalName;
            __instance.ItemName = GetWeaponNameWithModifierTier(modifierTier, originalName);
        }

        public static void Postfix(WeaponDesignVM __instance, ref string __state)
        {
            if (MCMSettings.Instance is null || !MCMSettings.Instance.AddCraftedItemRarity) return;

            __instance.ItemName = __state;
        }

        private static string GetWeaponNameWithModifierTier(int modifierTier, string originalName)
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
