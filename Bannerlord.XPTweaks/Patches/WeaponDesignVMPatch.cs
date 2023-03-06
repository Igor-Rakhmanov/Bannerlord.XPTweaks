using Bannerlord.XPTweaks.Logic;
using Bannerlord.XPTweaks.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem.ViewModelCollection.WeaponCrafting.WeaponDesign;

namespace Bannerlord.XPTweaks.Patches
{
    [HarmonyPatch(typeof(WeaponDesignVM), nameof(WeaponDesignVM.CreateCraftingResultPopup))]
    public class WeaponDesignVMPatch
    {
        private static readonly CraftedWeaponNameTweak craftedWeaponNameTweak = new CraftedWeaponNameTweak(McmSettingsProvider.Instance);

        public static void Prefix(WeaponDesignVM __instance, ref string __state)
        {
            craftedWeaponNameTweak.AddWeaponRarityToName(__instance, ref __state);
        }

        public static void Postfix(WeaponDesignVM __instance, ref string __state)
        {
            craftedWeaponNameTweak.RestoreOriginalName(__instance, __state);
        }
    }
}
