namespace Bannerlord.XPTweaks.Logic
{
    public interface ISettingsProvider
    {
        ISettings Settings { get; }

        bool IsInitialized { get; }
    }
}
