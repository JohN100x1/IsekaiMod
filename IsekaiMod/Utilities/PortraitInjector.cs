using HarmonyLib;
using Kingmaker.Blueprints;
using System.Collections.Generic;
using UnityEngine;

namespace IsekaiMod.Utilities
{
    [HarmonyPatch(typeof(PortraitData), "get_FullLengthPortrait")]
    public static class FullPortraitInjector
    {
        public static Dictionary<PortraitData, Sprite> Replacements = new();
        public static bool Prefix(PortraitData __instance, ref Sprite __result)
        {
            if (Replacements.TryGetValue(__instance, out __result))
                return false;
            return true;
        }
    }
    [HarmonyPatch(typeof(PortraitData), "get_HalfLengthPortrait")]
    public static class HalfPortraitInjector
    {
        public static Dictionary<PortraitData, Sprite> Replacements = new();
        public static bool Prefix(PortraitData __instance, ref Sprite __result)
        {
            if (Replacements.TryGetValue(__instance, out __result))
                return false;
            return true;
        }
    }
    [HarmonyPatch(typeof(PortraitData), "get_SmallPortrait")]
    public static class SmallPortraitInjector
    {
        public static Dictionary<PortraitData, Sprite> Replacements = new();
        public static bool Prefix(PortraitData __instance, ref Sprite __result)
        {
            if (Replacements.TryGetValue(__instance, out __result))
                return false;
            return true;
        }
    }
    [HarmonyPatch(typeof(PortraitData), "get_PetEyePortrait")]
    public static class EyePortraitInjector
    {
        public static Dictionary<PortraitData, Sprite> Replacements = new();
        public static bool Prefix(PortraitData __instance, ref Sprite __result)
        {
            if (Replacements.TryGetValue(__instance, out __result))
                return false;
            return true;
        }
    }
}
