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

    internal class MonkLegacy {


        private static BlueprintProgression prog;

        public static void Configure() {

            prog = Helpers.CreateBlueprint<BlueprintProgression>(IsekaiContext, "MonkBaseLegacy", bp => {
                bp.SetName(IsekaiContext, "Monk Legacy - Daoist Martial Artist");
                bp.SetDescription(IsekaiContext, "You practiced your martial arts day and night. \n" +
                    "Reading chinese cultivation novels in the spare time left. \n" +
                    "Being reborn and getting access to Ki as such was a dream come true.");
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
            if (prog != null) {
                prog = PatchTools.PatchClassProgressionBasedOnRefClass(prog, ClassTools.Classes.MonkClass);
                BlueprintCharacterClassReference myClass = IsekaiProtagonistClass.GetReference();
                PatchTools.PatchProgressionFeaturesBasedOnReferenceClass(prog, myClass, ClassTools.ClassReferences.MonkClass);

                prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = MonkScaledFistLegacy.Get().ToReference<BlueprintFeatureReference>(); });
            }
        }

        public static BlueprintProgression Get() {
            if (prog != null) return prog;
            return BlueprintTools.GetModBlueprint<BlueprintProgression>(IsekaiContext, "MonkBaseLegacy");
        }
    }
}
