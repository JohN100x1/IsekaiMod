using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using HarmonyLib;
using Kingmaker.Blueprints.JsonSystem;
using System.Linq;
using static UnityModManagerNet.UnityModManager;

namespace IsekaiMod.Utilities
{
    class ModSupport
    {
        protected static bool IsExpandedContentEnabled() { return IsModEnabled("ExpandedContent"); }
        protected static bool IsMysticalMayhemEnabled() { return IsModEnabled("MysticalMayhem"); }
        [HarmonyPatch(typeof(BlueprintsCache), "Init")]
        static class BlueprintsCache_Init_Patch
        {
            static bool Initialized;

            [HarmonyAfter()]
            public static void Postfix()
            {
                if (Initialized) return;
                Initialized = true;

                if (IsMysticalMayhemEnabled())
                {
                    var IsekaiProtagonistSpellList = Resources.GetModBlueprint<BlueprintSpellList>("IsekaiProtagonistSpellList");

                    Main.Log("Mystical Mayhem Support Enabled.");
                    BlueprintGuid MeteorSwarmGuid = BlueprintGuid.Parse("d0cd103b15494866b0444c1a961bc40f");
                    BlueprintAbility MeteorSwarmAbility = (BlueprintAbility)ResourcesLibrary.BlueprintsCache.Load(MeteorSwarmGuid);
                    IsekaiProtagonistSpellList.SpellsByLevel[9].m_Spells.Add(MeteorSwarmAbility.ToReference<BlueprintAbilityReference>());
                }
            }
        }
        protected static bool IsModEnabled(string modName)
        {
            return modEntries.Where(mod => mod.Info.Id.Equals(modName) && mod.Enabled && !mod.ErrorOnLoading).Any();
        }
    }
}
