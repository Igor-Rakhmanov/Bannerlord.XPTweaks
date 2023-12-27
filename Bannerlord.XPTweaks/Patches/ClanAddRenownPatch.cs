using Bannerlord.XPTweaks.Logic.Tweaks;
using Bannerlord.XPTweaks.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;

namespace Bannerlord.XPTweaks.Patches
{
    [HarmonyPatch(typeof(Clan), nameof(Clan.AddRenown))]
    public static class ClanAddRenownPatch
    {
        private static readonly RenownTweaks renownTweaks = new(McmSettingsProvider.Instance);

        public static void Prefix(ref float value, bool shouldNotify, Clan __instance)
        {
            if (__instance.Leader == Hero.MainHero)
            {
                value = renownTweaks.GetModifiedClanRenown(value);
            }
        }
    }
}
