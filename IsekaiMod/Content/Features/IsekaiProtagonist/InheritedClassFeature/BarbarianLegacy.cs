using IsekaiMod.Content.Classes.IsekaiProtagonist;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.EdgeLord;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.UnitLogic.FactLogic;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.InheritedClassFeature {

    internal class BarbarianLegacy {
        private static BlueprintProgression prog;

        public static void Configure() {
            var IsekaiBarbarianTraining = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "BarbarianTraining", bp => {
                bp.SetName(IsekaiContext, "Deprecated");
                bp.SetDescription(IsekaiContext, "Old Feature, reference kept so your save won't crash!");
                bp.m_Icon = StaticReferences.SorcererArcana.m_Icon;
            });
            prog = Helpers.CreateBlueprint<BlueprintProgression>(IsekaiContext, "BarbarianLegacy", bp => {
                bp.SetName(IsekaiContext, "Barbarian Legacy - Ball of Rage");
                bp.SetDescription(IsekaiContext, "You really are just a walking bundle of issues waiting to explode at anyone getting too close aren't you?");
                bp.GiveFeaturesForPreviousLevels = true;
                
            });
            

            LegacySelection.GetClassFeature().AddFeatures(prog);
            LegacySelection.GetOverwhelmingFeature().AddFeatures(prog);
            EdgeLordLegacySelection.getClassFeature().AddFeatures(prog);
        }
        public static void PatchProgression() {
            if (prog != null) {
                prog = StaticReferences.PatchClassProgressionBasedOnRefClass(prog, ClassTools.Classes.BarbarianClass);
                BlueprintCharacterClassReference myClass = IsekaiProtagonistClass.GetReference();
                StaticReferences.PatchProgressionFeaturesBasedOnReferenceClass(prog, myClass, ClassTools.ClassReferences.BarbarianClass);
            }
        }
        public static BlueprintProgression Get() {
            if (prog != null) return prog;
            return BlueprintTools.GetModBlueprint<BlueprintProgression>(IsekaiContext, "BarbarianLegacy");
        }
    }
}
