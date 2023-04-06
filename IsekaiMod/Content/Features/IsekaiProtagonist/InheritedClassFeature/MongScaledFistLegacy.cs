using IsekaiMod.Content.Classes.IsekaiProtagonist;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.EdgeLord;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Hero;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Mastermind;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Overlord;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.InheritedClassFeature {
    internal class MonkScaledFistLegacy {
        private static BlueprintArchetype BaseArchetype = BlueprintTools.GetBlueprint<BlueprintArchetype>("5868fc82eb11a4244926363983897279");

        private static BlueprintProgression prog;

        public static void Configure() {
            prog = Helpers.CreateBlueprint<BlueprintProgression>(IsekaiContext, "MonkScaledFistLegacy", bp => {
                bp.SetName(IsekaiContext, "Monk Legacy - Fist of a Dragon");
                bp.SetDescription(IsekaiContext,
                    "You have a dragon in your dantian!");
                bp.GiveFeaturesForPreviousLevels = true;
                bp.AddComponent<PrerequisiteAlignment>(c => {
                    c.Alignment =
                      Kingmaker.UnitLogic.Alignments.AlignmentMaskType.Lawful
                    | Kingmaker.UnitLogic.Alignments.AlignmentMaskType.TrueNeutral
                    | Kingmaker.UnitLogic.Alignments.AlignmentMaskType.NeutralEvil
                    | Kingmaker.UnitLogic.Alignments.AlignmentMaskType.NeutralGood;
                });
            });


            LegacySelection.RegisterForFeat(prog);
            LegacySelection.Register(prog);
            EdgeLordLegacySelection.Register(prog);
            //GodEmperorLegacySelection.Register(prog);
            HeroLegacySelection.Register(prog);
            MastermindLegacySelection.Prohibit(prog);
            OverlordLegacySelection.Register(prog);
        }
        public static void PatchProgression() {
             

            prog = StaticReferences.PatchClassProgressionBasedonRefArchetype(prog, ClassTools.Classes.MonkClass, BaseArchetype, null);
            BlueprintCharacterClassReference refClass = ClassTools.ClassReferences.MonkClass;
            BlueprintCharacterClassReference myClass = IsekaiProtagonistClass.GetReference();
            StaticReferences.PatchProgressionFeaturesBasedOnReferenceArchetype(myClass, refClass, BaseArchetype);
            prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = MonkLegacy.Get().ToReference<BlueprintFeatureReference>(); });
        }
        public static BlueprintProgression Get() {
            if (prog != null) return prog;
            return BlueprintTools.GetModBlueprint<BlueprintProgression>(IsekaiContext, "MonkScaledFistLegacy");
        }
    }
}
