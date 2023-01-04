using TabletopTweaks.Core.UMMTools;
using UnityModManagerNet;
using static IsekaiMod.Main;

namespace IsekaiMod
{
    public static class UMMSettingsUI
    {
        private static int selectedTab;
        public static void OnGUI(UnityModManager.ModEntry modEntry)
        {
            UI.AutoWidth();
            UI.TabBar(ref selectedTab,
                    () => UI.Label("Select your preferred settings and restart your game.".yellow().bold()),
                   new NamedAction("Added Content", () => SettingsTabs.AddedContent())
            );
        }
    }

    static class SettingsTabs
    {
        public static void AddedContent()
        {
            var TabLevel = SetttingUI.TabLevel.Zero;
            var AddedContent = IsekaiContext.AddedContent;
            UI.Div(0, 15);
            using (UI.VerticalScope())
            {
                UI.Toggle("New Settings Off By Default".bold(), ref AddedContent.NewSettingsOffByDefault);
                UI.Space(25);
                SetttingUI.SettingGroup("Exceptional Feats", TabLevel, AddedContent.Feats);
                SetttingUI.SettingGroup("Classes", TabLevel, AddedContent.Classes);
                SetttingUI.SettingGroup("Heritages", TabLevel, AddedContent.Heritages);
                SetttingUI.SettingGroup("Backgrounds", TabLevel, AddedContent.Backgrounds);
                SetttingUI.SettingGroup("Deities", TabLevel, AddedContent.Deities);
                SetttingUI.SettingGroup("Archetypes", TabLevel, AddedContent.Archetypes);
            }
            UI.Toggle("Exclude Companions and Mercenaries from having the Isekai Protagonist Class (Requires Restart)", ref AddedContent.ExcludeCompanionsFromIsekaiClass);
        }
    }
}
