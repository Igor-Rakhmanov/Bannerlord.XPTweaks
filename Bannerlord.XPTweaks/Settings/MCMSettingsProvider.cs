using Bannerlord.XPTweaks.Logic;
using System;

namespace Bannerlord.XPTweaks.Settings
{
    internal class McmSettingsProvider : ISettingsProvider
    {
        private McmSettingsProvider()
        {

        }

        private static McmSettingsProvider _instance;

        public static McmSettingsProvider Instance
        {
            get { return _instance ??= new McmSettingsProvider(); }
        }

        public ISettings Settings => McmSettings.Instance ?? throw new NullReferenceException("McmSettings instance is null");

        public bool IsInitialized => McmSettings.Instance is not null;
    }
}
