
namespace IsekaiMod.Config
{
    public class AddedContent : IUpdatableSettings
    {
        public bool NewSettingsOffByDefault = false;
        public SettingGroup Heritages = new SettingGroup();
        public SettingGroup Backgrounds = new SettingGroup();

        public void Init()
        {
        }

        public void OverrideSettings(IUpdatableSettings userSettings)
        {
            var loadedSettings = userSettings as AddedContent;
            NewSettingsOffByDefault = loadedSettings.NewSettingsOffByDefault;
            Heritages.LoadSettingGroup(loadedSettings.Heritages, NewSettingsOffByDefault);
            Backgrounds.LoadSettingGroup(loadedSettings.Backgrounds, NewSettingsOffByDefault);
        }
    }
}