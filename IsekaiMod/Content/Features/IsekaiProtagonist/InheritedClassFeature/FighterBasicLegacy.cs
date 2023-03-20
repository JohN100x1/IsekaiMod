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
    internal class FighterBasicLegacy {
        private static BlueprintProgression prog;

        public static void Configure() {
            prog = Helpers.CreateBlueprint<BlueprintProgression>(IsekaiContext, "FighterBasicIsekaiLegacy", bp => {
            bp.SetName(IsekaiContext, "Fighter Legacy - Basic Fighter");
                bp.SetDescription(IsekaiContext, 
                    "Sure others make fun of you for being basic.\n"+
                    "What they fail to understand is that they are the basic ones, they play an auto optimized build that only allows them some little choice on what feature to use in each fight.\n"+
                    "You are carefully crafted at each level to ensure the optimal combination of feats.\n"+
                    "They completely fail to see the hours of planning it takes to ensure that when the time for battle comes your attack will always do the optimum damage, even if it is just repeatedly smashing the hammer into the enemies face."
                    );
            bp.GiveFeaturesForPreviousLevels = true;
            });
            
            LegacySelection.GetClassFeature().AddFeatures(prog);
            LegacySelection.GetOverwhelmingFeature().AddFeatures(prog);
            EdgeLordLegacySelection.getClassFeature().AddFeatures(prog);
            HeroLegacySelection.getClassFeature().AddFeatures(prog);
            VillainLegacySelection.getClassFeature().AddFeatures(prog);
        }
        public static BlueprintProgression Get() {
            if (prog != null) return prog;
            return BlueprintTools.GetModBlueprint<BlueprintProgression>(IsekaiContext, "FighterBasicIsekaiLegacy");
        }

        public static void PatchProgression() {
            if (prog != null) {
                prog = StaticReferences.PatchClassProgressionBasedOnRefClass(prog, ClassTools.Classes.FighterClass);
                BlueprintCharacterClassReference myClass = IsekaiProtagonistClass.GetReference();
                StaticReferences.PatchProgressionFeaturesBasedOnReferenceClass(prog, myClass, ClassTools.ClassReferences.FighterClass);
            }
        }

    }
}
