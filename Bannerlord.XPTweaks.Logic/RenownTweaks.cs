namespace Bannerlord.XPTweaks.Logic
{
    public class RenownTweaks
    {
        private readonly ISettingsProvider _settingsProvider;

        public RenownTweaks(ISettingsProvider settingsProvider)
        {
            _settingsProvider = settingsProvider;
        }

        public float GetModifiedClanRenown(float originalRenownValue)
        {
            if (_settingsProvider.IsInitialized) return originalRenownValue;

            return originalRenownValue * _settingsProvider.Settings.RenownMultiplier;
        }
    }
}
