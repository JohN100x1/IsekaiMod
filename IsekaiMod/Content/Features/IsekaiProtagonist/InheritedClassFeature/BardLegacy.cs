using IsekaiMod.Content.Classes.IsekaiProtagonist;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Hero;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.InheritedClassFeature {

    internal class BardLegacy {
        private static BlueprintProgression prog;

        public static void Configure() {
            prog = Helpers.CreateBlueprint<BlueprintProgression>(IsekaiContext, "BardLegacy", bp => {
                bp.SetName(IsekaiContext, "Bard Legacy - Musical Prodige");
                bp.SetDescription(IsekaiContext, "You know what is even more effective in gathering a great harem than being a great hero? \nThat is right, music the language of romance, there is a reason why so many males hate bards...");
                bp.GiveFeaturesForPreviousLevels = true;

            });
            prog = StaticReferences.PatchClassProgressionBasedOnRefClass(prog, ClassTools.Classes.BardClass);

            LegacySelection.GetClassFeature().AddFeatures(prog);
            LegacySelection.GetOverwhelmingFeature().AddFeatures(prog);
            HeroLegacySelection.getClassFeature().AddFeatures(prog);
        }

        public static void PatchProgression() {
            if (prog != null) {
                BlueprintCharacterClassReference myClass = IsekaiProtagonistClass.GetReference();
                StaticReferences.PatchProgressionFeaturesBasedOnReferenceClass(prog, myClass, ClassTools.ClassReferences.BardClass);
            }
        }

        public static BlueprintProgression Get() {
            if (prog != null) return prog;
            return BlueprintTools.GetModBlueprint<BlueprintProgression>(IsekaiContext, "BardLegacy");
        }
    }
}
