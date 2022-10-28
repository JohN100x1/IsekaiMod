using UnityModManagerNet;
using HarmonyLib;
using IsekaiMod.Config;
using IsekaiMod.Utilities;

namespace IsekaiMod
{
    static class Main
    {
        public static bool Load(UnityModManager.ModEntry modEntry)
        {
            var harmony = new Harmony(modEntry.Info.Id);
            ModSettings.ModEntry = modEntry;
            ModSettings.LoadAllSettings();
            ModSettings.ModEntry.OnSaveGUI = OnSaveGUI;
            ModSettings.ModEntry.OnGUI = UMMSettingsUI.OnGUI;
            harmony.PatchAll();
            PostPatchInitializer.Initialize();
            return true;
        }
        public static void Log(string msg)
        {
            ModSettings.ModEntry.Logger.Log(msg);
        }
        [System.Diagnostics.Conditional("DEBUG")]
        public static void LogDebug(string msg)
        {
            ModSettings.ModEntry.Logger.Log(msg);
        }
        static void OnSaveGUI(UnityModManager.ModEntry modEntry)
        {
            ModSettings.SaveSettings("AddedContent.json", ModSettings.AddedContent);
        }
    }
}