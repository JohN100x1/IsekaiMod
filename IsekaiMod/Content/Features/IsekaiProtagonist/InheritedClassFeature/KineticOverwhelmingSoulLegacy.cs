using IsekaiMod.Content.Classes.IsekaiProtagonist;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.EdgeLord;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Hero;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Mastermind;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Overlord;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
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


            LegacySelection.Register(prog);
            EdgeLordLegacySelection.Prohibit(prog);
            HeroLegacySelection.Register(prog);
            MastermindLegacySelection.Prohibit(prog);
            OverlordLegacySelection.Register(prog);
            //GodEmperorLegacySelection.Register(prog);
        }
        public static void PatchProgression() {
             

            prog = StaticReferences.PatchClassProgressionBasedonRefArchetype(prog, ClassTools.Classes.KineticistClass, BaseArchetype, null);
            BlueprintCharacterClassReference refClass = ClassTools.ClassReferences.KineticistClass;
            BlueprintCharacterClassReference myClass = IsekaiProtagonistClass.GetReference();
            StaticReferences.PatchProgressionFeaturesBasedOnReferenceArchetype(myClass, refClass, BaseArchetype);
            prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = KineticDarkElementalistLegacy.Get().ToReference<BlueprintFeatureReference>(); });
            prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = KineticKnightLegacy.Get().ToReference<BlueprintFeatureReference>(); });
            prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = KineticLegacy.Get().ToReference<BlueprintFeatureReference>(); });
        }
        public static BlueprintProgression Get() {
            if (prog != null) return prog;
            return BlueprintTools.GetModBlueprint<BlueprintProgression>(IsekaiContext, "KineticOverwhelmingSoulLegacy");
        }
    }
}
