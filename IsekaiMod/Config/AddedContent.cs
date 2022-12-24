
namespace IsekaiMod.Config
{
    public class AddedContent : IUpdatableSettings
    {
        public bool ExcludeCompanionsFromIsekaiClass = false;
        public bool NewSettingsOffByDefault = false;
        public SettingGroup Feats = new();
        public SettingGroup Heritages = new();
        public SettingGroup Backgrounds = new();
        public SettingGroup Classes = new();
        public SettingGroup Deities = new();

        public void Init()
        {
        }

        public void OverrideSettings(IUpdatableSettings userSettings)
        {
            var loadedSettings = userSettings as AddedContent;
            ExcludeCompanionsFromIsekaiClass = loadedSettings.ExcludeCompanionsFromIsekaiClass;
            NewSettingsOffByDefault = loadedSettings.NewSettingsOffByDefault;
            Heritages.LoadSettingGroup(loadedSettings.Heritages, NewSettingsOffByDefault);
            Backgrounds.LoadSettingGroup(loadedSettings.Backgrounds, NewSettingsOffByDefault);
            Classes.LoadSettingGroup(loadedSettings.Classes, NewSettingsOffByDefault);
            Deities.LoadSettingGroup(loadedSettings.Deities, NewSettingsOffByDefault);
            Feats.LoadSettingGroup(loadedSettings.Feats, NewSettingsOffByDefault);
        }
    }
}