using TabletopTweaks.Core.Config;

namespace IsekaiMod.Config
{

    public class AddedContent : IUpdatableSettings {
        public bool NewSettingsOffByDefault = false;
        public bool ExcludeCompanionsFromIsekaiClass = false;
        public SettingGroup Feats = new SettingGroup();
        public SettingGroup Heritages = new SettingGroup();
        public SettingGroup Backgrounds = new SettingGroup();
        public SettingGroup Classes = new SettingGroup();
        public SettingGroup Deities = new SettingGroup();

        public void Init() {
        }

        public void OverrideSettings(IUpdatableSettings userSettings) {
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