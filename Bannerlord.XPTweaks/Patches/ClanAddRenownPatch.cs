using Bannerlord.XPTweaks.Logic;
using Bannerlord.XPTweaks.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;

namespace Bannerlord.XPTweaks.Patches
{
    [HarmonyPatch(typeof(Clan), nameof(Clan.AddRenown))]
    public static class ClanAddRenownPatch
    {
        private static readonly RenownTweaks renownTweaks = new(McmSettingsProvider.Instance);

        public static void Prefix(ref float value)
        {
            value = renownTweaks.GetModifiedClanRenown(value);
        }
    }
}
