using Bannerlord.XPTweaks.Logic;
using System;

namespace Bannerlord.XPTweaks.Settings
{
    internal class McmSettingsProvider : ISettingsProvider
    {
        private McmSettingsProvider()
        {

        }

        public static McmSettingsProvider Instance => new McmSettingsProvider();

        public ISettings Settings => McmSettings.Instance ?? throw new NullReferenceException("McmSettings instance is null");

        public bool IsInitialized => McmSettings.Instance is not null;
    }
}
