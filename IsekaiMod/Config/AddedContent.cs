using TabletopTweaks.Core.Config;

namespace IsekaiMod.Config {

    public class AddedContent : IUpdatableSettings {
        public bool NewSettingsOffByDefault = false;
        public bool ExcludeCompanionsFromIsekaiClass = false;
        public bool MultipleMythicOPAbility = false;
        public bool MultipleMythicSpecialPower = false;
        public bool MergeIsekaiSpellList = false;
        public SettingGroup Isekai = new();
        public SettingGroup Other = new();

        public void Init() {
        }

        public void OverrideSettings(IUpdatableSettings userSettings) {
            var loadedSettings = userSettings as AddedContent;
            NewSettingsOffByDefault = loadedSettings.NewSettingsOffByDefault;
            ExcludeCompanionsFromIsekaiClass = loadedSettings.ExcludeCompanionsFromIsekaiClass;
            MultipleMythicOPAbility = loadedSettings.MultipleMythicOPAbility;
            MultipleMythicSpecialPower = loadedSettings.MultipleMythicSpecialPower;
            MergeIsekaiSpellList = loadedSettings.MergeIsekaiSpellList;
            Isekai.LoadSettingGroup(loadedSettings.Isekai, NewSettingsOffByDefault);
            Other.LoadSettingGroup(loadedSettings.Other, NewSettingsOffByDefault);
        }
    }
}