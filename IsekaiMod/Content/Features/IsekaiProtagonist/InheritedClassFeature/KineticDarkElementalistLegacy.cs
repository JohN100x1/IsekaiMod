using IsekaiMod.Content.Classes.IsekaiProtagonist;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Villain;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using TabletopTweaks.Core.Utilities;
using Kingmaker.UnitLogic.FactLogic;
using static IsekaiMod.Main;
using Kingmaker.Blueprints.Classes.Prerequisites;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.InheritedClassFeature {
    internal class KineticDarkElementalistLegacy {
        private static BlueprintArchetype BaseArchetype = BlueprintTools.GetBlueprint<BlueprintArchetype>("f12f18ae8842425489d29f302e69134c");

        private static BlueprintProgression prog;

        public static void Configure() {
            prog = Helpers.CreateBlueprint<BlueprintProgression>(IsekaiContext, "KineticDarkElementalistLegacy", bp => {
                bp.SetName(IsekaiContext, "Kinetic Legacy - Soulbinder");
                bp.SetDescription(IsekaiContext,
                    "You have discovered a dark secret of elemental manipulation: you can use the souls of your enemies as fuel for your powers. \n" +
                    "Instead of straining your own body, you can use souls of those who oppose you and unleash devastating blasts of elemental energy. \n" +
                    "You are a master of soulbinding, a technique that some consider to be unnatural and morbid. \n" +
                    "But you don’t care about such moral qualms; you only care about your own survival and dominance.");
                bp.GiveFeaturesForPreviousLevels = true;
                bp.AddComponent<AddProficiencies>(c => {
                    c.WeaponProficiencies = new Kingmaker.Enums.WeaponCategory[] { Kingmaker.Enums.WeaponCategory.KineticBlast };
                });
                bp.AddComponent<PrerequisiteAlignment>(c => { c.Alignment = Kingmaker.UnitLogic.Alignments.AlignmentMaskType.Evil; });
            });
            
            LegacySelection.GetClassFeature().AddFeatures(prog);
            LegacySelection.GetOverwhelmingFeature().AddFeatures(prog);
            VillainLegacySelection.getClassFeature().AddFeatures(prog);
        }
        public static void PatchProgression() {
            //please note that this only patches the knight progression so this only works in combination of the already done patch by the other version

            BlueprintCharacterClassReference refClass = ClassTools.ClassReferences.KineticistClass;
            BlueprintCharacterClassReference myClass = IsekaiProtagonistClass.GetReference();
            prog = StaticReferences.PatchClassProgressionBasedonRefArchetype(prog, ClassTools.Classes.KineticistClass, BaseArchetype, null);
            StaticReferences.PatchProgressionFeaturesBasedOnReferenceArchetype(myClass, refClass, BaseArchetype);
        }
        public static BlueprintProgression Get() {
            if (prog != null) return prog;
            return BlueprintTools.GetModBlueprint<BlueprintProgression>(IsekaiContext, "KineticDarkElementalistLegacy");
        }
    }
}
