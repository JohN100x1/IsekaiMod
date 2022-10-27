
namespace IsekaiMod.Config
{
    public class AddedContent : IUpdatableSettings
    {
        public bool NewSettingsOffByDefault = false;
        public SettingGroup Heritages = new();
        public SettingGroup Backgrounds = new();
        public SettingGroup Classes = new();

        public void Init()
        {
        }

        public void OverrideSettings(IUpdatableSettings userSettings)
        {
            var loadedSettings = userSettings as AddedContent;
            NewSettingsOffByDefault = loadedSettings.NewSettingsOffByDefault;
            Heritages.LoadSettingGroup(loadedSettings.Heritages, NewSettingsOffByDefault);
            Backgrounds.LoadSettingGroup(loadedSettings.Backgrounds, NewSettingsOffByDefault);
            Classes.LoadSettingGroup(loadedSettings.Classes, NewSettingsOffByDefault);
        }
    }
}