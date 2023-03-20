using IsekaiMod.Content.Classes.IsekaiProtagonist;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Villain;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Hero;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.EdgeLord;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using TabletopTweaks.Core.Utilities;
using Kingmaker.UnitLogic.FactLogic;
using static IsekaiMod.Main;
using Kingmaker.Blueprints.Classes.Prerequisites;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.InheritedClassFeature {
    internal class SkaldSilverTongueLegacy {
        private static BlueprintArchetype BaseArchetype = BlueprintTools.GetBlueprint<BlueprintArchetype>("5e63586bebd229649bdafe0fde4caaec");

        private static BlueprintProgression prog;

        public static void Configure() {
            prog = Helpers.CreateBlueprint<BlueprintProgression>(IsekaiContext, "SkaldSilverTongueLegacy", bp => {
                bp.SetName(IsekaiContext, "Skald Legacy - Silver Tongue");
                bp.SetDescription(IsekaiContext,
                    "You were a flatterer in your past life, and lean to hone your skills to a ridiculous level. \n" +
                    "No Queen can resist you, and that's a real advantage in those dark times.");
                bp.GiveFeaturesForPreviousLevels = true;
            });

            LegacySelection.GetClassFeature().AddFeatures(prog);
            LegacySelection.GetOverwhelmingFeature().AddFeatures(prog);
            VillainLegacySelection.getClassFeature().AddFeatures(prog);
            HeroLegacySelection.getClassFeature().AddFeatures(prog);
        }

        public static void PatchProgression() {
            //please note that this only patches the knight progression so this only works in combination of the already done patch by the other version

            prog = StaticReferences.PatchClassProgressionBasedonRefArchetype(prog, ClassTools.Classes.SkaldClass, BaseArchetype, null);
            BlueprintCharacterClassReference refClass = ClassTools.ClassReferences.KineticistClass;
            BlueprintCharacterClassReference myClass = IsekaiProtagonistClass.GetReference();
            StaticReferences.PatchProgressionFeaturesBasedOnReferenceArchetype(myClass, refClass, BaseArchetype);
        }

        public static BlueprintProgression Get() {
            if (prog != null) return prog;
            return BlueprintTools.GetModBlueprint<BlueprintProgression>(IsekaiContext, "SkaldSilverTongueLegacy");
        }
    }
}
