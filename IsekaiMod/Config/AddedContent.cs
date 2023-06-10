using TabletopTweaks.Core.Config;

namespace IsekaiMod.Config {

    public class AddedContent : IUpdatableSettings {
        public bool NewSettingsOffByDefault = false;
        public bool ExcludeCompanionsFromIsekaiClass = false;
        public bool RestrictExceptionalFeats = false;
        public bool RestrictMythicOPAbility = false;
        public bool RestrictMythicSpecialPower = false;
        public bool MultipleMythicOPAbility = false;
        public bool MultipleMythicSpecialPower = false;
        public bool MergeIsekaiSpellList = false;

        public bool DisableSpellbookEdgeLord = false;
        public bool DisableSpellbookGodEmperor = false;
        public bool DisableSpellbookHero = false;
        public bool DisableSpellbookMastermind = false;
        public bool DisableSpellbookOverlord = false;

        public int IsekaiDefaultClothes = 20;
        public int IsekaiSpellsKnownIncrement = 6;
        public SettingGroup Isekai = new();
        public SettingGroup Other = new();

        public void Init() {
        }

        public void OverrideSettings(IUpdatableSettings userSettings) {
            var loadedSettings = userSettings as AddedContent;
            NewSettingsOffByDefault = loadedSettings.NewSettingsOffByDefault;
            ExcludeCompanionsFromIsekaiClass = loadedSettings.ExcludeCompanionsFromIsekaiClass;

            // Restrict Features
            RestrictExceptionalFeats = loadedSettings.RestrictExceptionalFeats;
            RestrictMythicOPAbility = loadedSettings.RestrictMythicOPAbility;
            RestrictMythicSpecialPower = loadedSettings.RestrictMythicSpecialPower;

            // Allow Multiple Selections
            MultipleMythicOPAbility = loadedSettings.MultipleMythicOPAbility;
            MultipleMythicSpecialPower = loadedSettings.MultipleMythicSpecialPower;

            // Change Isekai Protagonist Default Clothes
            IsekaiDefaultClothes = loadedSettings.IsekaiDefaultClothes;

            // Change Isekai Protagonist Spells Known Increment
            IsekaiSpellsKnownIncrement = loadedSettings.IsekaiSpellsKnownIncrement;

            // Disable Isekai Spellbook
            DisableSpellbookEdgeLord = loadedSettings.DisableSpellbookEdgeLord;
            DisableSpellbookGodEmperor = loadedSettings.DisableSpellbookGodEmperor;
            DisableSpellbookHero = loadedSettings.DisableSpellbookHero;
            DisableSpellbookMastermind = loadedSettings.DisableSpellbookMastermind;
            DisableSpellbookOverlord = loadedSettings.DisableSpellbookOverlord;

            MergeIsekaiSpellList = loadedSettings.MergeIsekaiSpellList;
            Isekai.LoadSettingGroup(loadedSettings.Isekai, NewSettingsOffByDefault);
            Other.LoadSettingGroup(loadedSettings.Other, NewSettingsOffByDefault);
        }
    }
}