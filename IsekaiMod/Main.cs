using UnityModManagerNet;
using HarmonyLib;
using IsekaiMod.Config;
using TabletopTweaks.Core.Utilities;
using IsekaiMod.ModLogic;

namespace IsekaiMod
{
    static class Main
    {
        public static ModContextTTTBase IsekaiContext;
        public static bool Load(UnityModManager.ModEntry modEntry)
        {
            var harmony = new Harmony(modEntry.Info.Id);
            IsekaiContext = new ModContextTTTBase(modEntry);
            IsekaiContext.ModEntry.OnSaveGUI = OnSaveGUI;
            IsekaiContext.ModEntry.OnGUI = UMMSettingsUI.OnGUI;
            harmony.PatchAll();
            PostPatchInitializer.Initialize(IsekaiContext);
            return true;
        }
        public static void Log(string msg)
        {
            IsekaiContext.Logger.Log(msg);
        }
        [System.Diagnostics.Conditional("DEBUG")]
        public static void LogDebug(string msg)
        {
            IsekaiContext.Logger.Log(msg);
        }
        static void OnSaveGUI(UnityModManager.ModEntry modEntry)
        {
            IsekaiContext.SaveAllSettings();
        }
    }
}