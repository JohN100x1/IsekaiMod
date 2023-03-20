using IsekaiMod.Content.Classes.IsekaiProtagonist;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Hero;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.UnitLogic.FactLogic;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.InheritedClassFeature {
    internal class KineticOverwhelmingSoulLegacy {
        private static BlueprintArchetype BaseArchetype = BlueprintTools.GetBlueprint<BlueprintArchetype>("aa11888104d17f7459851e8d559ffa98");

        private static BlueprintProgression prog;

        public static void Configure() {
            prog = Helpers.CreateBlueprint<BlueprintProgression>(IsekaiContext, "KineticOverwhelmingSoulLegacy", bp => {
                bp.SetName(IsekaiContext, "Kinetic Legacy - Noble Soul");
                bp.SetDescription(IsekaiContext,
                    "Your soul is stronger than most, for you hail from another world.\n" +
                    "You command the elements with ease and grace, while others struggle and suffer.\n" +
                    "You are a noble soul, a revered and feared master of elemental power.");
                bp.GiveFeaturesForPreviousLevels = true;
                bp.AddComponent<AddProficiencies>(c => {
                    c.WeaponProficiencies = new Kingmaker.Enums.WeaponCategory[] { Kingmaker.Enums.WeaponCategory.KineticBlast };
                });
            });


            LegacySelection.GetClassFeature().AddFeatures(prog);
            LegacySelection.GetOverwhelmingFeature().AddFeatures(prog);
            HeroLegacySelection.getClassFeature().AddFeatures(prog);
        }
        public static void PatchProgression() {
            //please note that this only patches the knight progression so this only works in combination of the already done patch by the other version

            prog = StaticReferences.PatchClassProgressionBasedonRefArchetype(prog, ClassTools.Classes.KineticistClass, BaseArchetype, null);
            BlueprintCharacterClassReference refClass = ClassTools.ClassReferences.KineticistClass;
            BlueprintCharacterClassReference myClass = IsekaiProtagonistClass.GetReference();
            StaticReferences.PatchProgressionFeaturesBasedOnReferenceArchetype(myClass, refClass, BaseArchetype);
        }
        public static BlueprintProgression Get() {
            if (prog != null) return prog;
            return BlueprintTools.GetModBlueprint<BlueprintProgression>(IsekaiContext, "KineticOverwhelmingSoulLegacy");
        }
    }
}
