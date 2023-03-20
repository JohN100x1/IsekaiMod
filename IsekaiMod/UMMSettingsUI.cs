using IsekaiMod.Config;
using TabletopTweaks.Core.UMMTools;
using UnityModManagerNet;
using static IsekaiMod.Main;

namespace IsekaiMod {

    public static class UMMSettingsUI {
        private static int selectedTab;

        public static void OnGUI(UnityModManager.ModEntry modEntry) {
            UI.AutoWidth();
            UI.TabBar(ref selectedTab,
                    () => UI.Label("Select your preferred settings and restart your game.".yellow().bold()),
                   new NamedAction("Added Content", () => SettingsTabs.AddedContent()),
                   new NamedAction("Settings", () => SettingsTabs.Settings())
            );
        }
    }

    internal static class SettingsTabs {
        private static readonly AddedContent addedContent = IsekaiContext.AddedContent;
        public static void AddedContent() {
            var TabLevel = SetttingUI.TabLevel.Zero;
            UI.Div();
            UI.Toggle("New Settings Off By Default".bold(), ref addedContent.NewSettingsOffByDefault);
            using (UI.VerticalScope()) {
                SetttingUI.SettingGroup("Isekai", TabLevel, addedContent.Isekai);
                SetttingUI.SettingGroup("Other", TabLevel, addedContent.Other);
            }
        }
        public static void Settings() {
            UI.Div();
            UI.Toggle("Exclude Companions and Mercenaries from having the Isekai Protagonist Class.", ref addedContent.ExcludeCompanionsFromIsekaiClass);
            UI.Toggle("Restrict Exceptional Feats to the Isekai Protagonist Class.", ref addedContent.RestrictExceptionalFeats);
            UI.Toggle("Restrict Mythic Overpowered Abilities to the Isekai Protagonist Class.", ref addedContent.RestrictMythicOPAbility);
            UI.Toggle("Restrict Mythic Special Powers to the Isekai Protagonist Class.", ref addedContent.RestrictMythicSpecialPower);
            UI.Toggle("Allow multiple Mythic Overpowered Abilities to be selected.", ref addedContent.MultipleMythicOPAbility);
            UI.Toggle("Allow multiple Mythic Special Powers to be selected.", ref addedContent.MultipleMythicSpecialPower);
            UI.Toggle("Apply a merge function on all canon baseclass spell lists to create the Isekai Spell list.", ref addedContent.MergeIsekaiSpellList);
        }
    }
}