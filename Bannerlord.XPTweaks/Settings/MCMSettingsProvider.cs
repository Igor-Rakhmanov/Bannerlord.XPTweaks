using Bannerlord.XPTweaks.Logic;
using System;

namespace Bannerlord.XPTweaks.Settings
{
    internal class MCMSettingsProvider : ISettingsProvider
    {
        private MCMSettingsProvider()
        {

        }

        public static MCMSettingsProvider Instance => new MCMSettingsProvider();

        public ISettings Settings => MCMSettings.Instance ?? throw new NullReferenceException("MCMSettings instance is null");

        public bool IsInitialized => MCMSettings.Instance is not null;
    }
}
