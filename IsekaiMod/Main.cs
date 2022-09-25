using UnityModManagerNet;
using HarmonyLib;
using IsekaiMod.Config;
using IsekaiMod.Utilities;
using Kingmaker;

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
        public static void Error(string message)
        {
            Log(message);
            PFLog.Mods.Error(message);
        }
        static void OnSaveGUI(UnityModManager.ModEntry modEntry)
        {
            ModSettings.SaveSettings("AddedContent.json", ModSettings.AddedContent);
        }
    }
}