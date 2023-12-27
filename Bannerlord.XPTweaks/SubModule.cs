using Bannerlord.XPTweaks.Logic.Models;
using Bannerlord.XPTweaks.Logic.Tweaks;
using Bannerlord.XPTweaks.Settings;
using System.Reflection;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace Bannerlord.XPTweaks;

public class SubModule : MBSubModuleBase
{
    private const string HarmonyDomain = "com.yngvarr94.bannerlordmods.xptweaks";

    protected override void OnSubModuleLoad()
    {
        base.OnSubModuleLoad();

        var harmony = new HarmonyLib.Harmony(HarmonyDomain);
        harmony.PatchAll(Assembly.GetExecutingAssembly());
    }

    protected override void OnGameStart(Game game, IGameStarter gameStarterObject)
    {
        base.OnGameStart(game, gameStarterObject);

        if (game.GameType is Campaign)
        {
            InitializeGameModels(gameStarterObject);
            InitializeTradeTweaks();
        }
    }

    private void InitializeGameModels(IGameStarter gameStarterObject)
    {
        gameStarterObject.AddModel(new ModifiedGenericXpModel(McmSettingsProvider.Instance));
        gameStarterObject.AddModel(new ModifiedCharacterDevelopmentModel(McmSettingsProvider.Instance));
        gameStarterObject.AddModel(new ModifiedSmithingModel(McmSettingsProvider.Instance));
        gameStarterObject.AddModel(new ModifiedPartyTroopUpgradeModel(McmSettingsProvider.Instance));
        gameStarterObject.AddModel(new ModifiedAlleyModel(McmSettingsProvider.Instance));
    }

    private void InitializeTradeTweaks()
    {
        var tradeTweaks = new TradeTweaks(McmSettingsProvider.Instance);
        CampaignEvents.PlayerInventoryExchangeEvent.AddNonSerializedListener(this, tradeTweaks.IncreaseTradeOnBigDeals);
    }
}