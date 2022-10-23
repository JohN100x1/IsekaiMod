using HarmonyLib;
using Kingmaker.Blueprints.JsonSystem;

namespace IsekaiMod.Changes
{
    class ContentAdder {
        [HarmonyPatch(typeof(BlueprintsCache), "Init")]
        static class BlueprintsCache_Init_Patch {
            static bool Initialized;

            [HarmonyPriority(Priority.First)]
            public static void Postfix() {
                if (Initialized) return;
                Initialized = true;

                Classes.IsekaiProtagonist.IsekaiProtagonistSpellList.AddIsekaiProtagonistSpellList();
                Classes.IsekaiProtagonist.IsekaiProtagonistClass.AddIsekaiProtagonistClass();
                Classes.IsekaiProtagonist.Archetypes.GodEmporer.AddGodEmporer();

                Heritages.TieflingHeritageSuccubus.AddTieflingHeritageSuccubus();

                Backgrounds.BlackRoseMatriarch.AddBackgroundBlackRoseMatriarch();
                Backgrounds.BackgroundSelectionFeature.PatchBackgroundSelection();
            }
        }
    }
}
