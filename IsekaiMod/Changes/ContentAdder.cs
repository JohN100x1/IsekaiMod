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

                Features.IsekaiProtagonist.IsekaiProtagonistProficiencies.Add();
                Features.IsekaiProtagonist.IsekaiProtagonistCantripsFeature.Add();
                Features.IsekaiProtagonist.PlotArmor.Add();
                Features.IsekaiProtagonist.FriendlyAuraFeature.Add();

                Features.IsekaiProtagonist.GodEmporerProficiencies.Add();
                Features.IsekaiProtagonist.GodEmporerPlotArmor.Add();
                Features.IsekaiProtagonist.DarkAuraFeature.Add();

                Classes.IsekaiProtagonist.IsekaiProtagonistSpellList.Add();
                Classes.IsekaiProtagonist.IsekaiProtagonistSpellsPerDay.Add();
                Classes.IsekaiProtagonist.IsekaiProtagonistSpellsKnown.Add();
                Classes.IsekaiProtagonist.IsekaiProtagonistClass.Add();
                Classes.IsekaiProtagonist.Archetypes.GodEmporer.Add();

                Heritages.TieflingHeritageSuccubus.Add();

                Backgrounds.BlackRoseMatriarch.Add();
                Backgrounds.BlackRoseSelection.Add();
            }
        }
    }
}
