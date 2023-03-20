using IsekaiMod.Content.Classes.IsekaiProtagonist;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.EdgeLord;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Hero;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Villain;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.InheritedClassFeature {
    internal class ShifterStingerLegacy {
        private static BlueprintArchetype BaseArchetype = BlueprintTools.GetBlueprint<BlueprintArchetype>("1a51b5856d3b48d78b3e967dc5f20bd6");

        private static BlueprintProgression prog;

        public static void Configure() {
            if (ClassTools.Classes.ShifterClass == null) { return; }
            prog = Helpers.CreateBlueprint<BlueprintProgression>(IsekaiContext, "ShifterStingerLegacy", bp => {
                bp.SetName(IsekaiContext, "Shifter Legacy - Stinger");
                bp.SetDescription(IsekaiContext,
                    "Some things cannot be easily forgotten, and in your dreaded former life you were called a hedgehog... \n" +
                    "But this new world shall be respectful to your newfound stingers, as they are even more dangerous than your sharp tongue.");
                bp.GiveFeaturesForPreviousLevels = true;
            });


            
        }
        public static void PatchProgression() {
            if (ClassTools.Classes.ShifterClass == null) { return; }

            LegacySelection.GetClassFeature().AddFeatures(prog);
            LegacySelection.GetOverwhelmingFeature().AddFeatures(prog);
            VillainLegacySelection.getClassFeature().AddFeatures(prog);
            HeroLegacySelection.getClassFeature().AddFeatures(prog);
            EdgeLordLegacySelection.getClassFeature().AddFeatures(prog);

            //please note that this only patches the knight progression so this only works in combination of the already done patch by the other version

            prog = StaticReferences.PatchClassProgressionBasedonRefArchetype(prog, ClassTools.Classes.ShifterClass, BaseArchetype, null);
            BlueprintCharacterClassReference refClass = ClassTools.ClassReferences.ShifterClass;
            BlueprintCharacterClassReference myClass = IsekaiProtagonistClass.GetReference();
            StaticReferences.PatchProgressionFeaturesBasedOnReferenceArchetype(myClass, refClass, BaseArchetype);
        }
        public static BlueprintProgression Get() {
            if (prog != null) return prog;
            return BlueprintTools.GetModBlueprint<BlueprintProgression>(IsekaiContext, "ShifterStingerLegacy");
        }
    }
}
