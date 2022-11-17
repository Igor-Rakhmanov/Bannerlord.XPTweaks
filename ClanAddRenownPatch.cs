using Bannerlord.XPTweaks.Settings;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Text;
using TaleWorlds.CampaignSystem;

namespace Bannerlord.XPTweaks
{
    [HarmonyPatch(typeof(Clan), nameof(Clan.AddRenown))]
    public class ClanAddRenownPatch
    {
        public static void Prefix(ref float value)
        {
            if (MCMSettings.Instance is null) return;

            value *= MCMSettings.Instance.RenownMultiplier;
        }
    }
}
