using System.Reflection;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace Bannerlord.XPTweaks;

public class SubModule : MBSubModuleBase
{
    const string HarmonyDomain = "com.yngvarr94.bannerlordmods.xptweaks";

    protected override void OnSubModuleLoad()
    {
        base.OnSubModuleLoad();

        var harmony = new HarmonyLib.Harmony(HarmonyDomain);
        harmony.PatchAll(Assembly.GetExecutingAssembly());
    }

    protected override void OnSubModuleUnloaded()
    {
        base.OnSubModuleUnloaded();
    }

    protected override void OnBeforeInitialModuleScreenSetAsRoot()
    {
        base.OnBeforeInitialModuleScreenSetAsRoot();
    }

    protected override void OnGameStart(Game game, IGameStarter gameStarterObject)
    {
        base.OnGameStart(game, gameStarterObject);

        if(game.GameType is Campaign)
        {
            gameStarterObject.AddModel(new ModifiedGenericXpModel());
            gameStarterObject.AddModel(new ModifiedCharacterDevelopmentModel());
            gameStarterObject.AddModel(new ModifiedSmithingModel());
            gameStarterObject.AddModel(new ModifiedPartyTroopUpgradeModel());

            CampaignEvents.PlayerInventoryExchangeEvent.AddNonSerializedListener(this, TradeTweaks.IncreaseTradeOnBigDeals);
        }
    }
}