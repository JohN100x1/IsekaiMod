using IsekaiMod.Content.Classes.IsekaiProtagonist;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.EdgeLord;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Hero;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Villain;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.UI.Tooltip;
using Kingmaker.UnitLogic.FactLogic;
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
            LegacySelection.GetClassFeature().AddFeatures(prog);
            LegacySelection.GetOverwhelmingFeature().AddFeatures(prog);
            VillainLegacySelection.getClassFeature().AddFeatures(prog);
            HeroLegacySelection.getClassFeature().AddFeatures(prog);
            EdgeLordLegacySelection.getClassFeature().AddFeatures(prog);
        }
        public static void PatchProgression() {
            if (prog != null) {
                prog = StaticReferences.PatchClassProgressionBasedOnRefClass(prog, ClassTools.Classes.MonkClass);
                BlueprintCharacterClassReference myClass = IsekaiProtagonistClass.GetReference();
                StaticReferences.PatchProgressionFeaturesBasedOnReferenceClass(prog, myClass, ClassTools.ClassReferences.MonkClass);
            }            
        }
        public static void MakeProgsExclusive() {
            BlueprintProgression ScaledFist = MonkScaledFistLegacy.Get();

            BlueprintFeatureReference BaseRef = prog.ToReference<BlueprintFeatureReference>();
            BlueprintFeatureReference ScaledFistRef = ScaledFist.ToReference<BlueprintFeatureReference>();

            prog.AddComponent<PrerequisiteNoFeature>(c => { c.m_Feature = ScaledFistRef; });

            ScaledFist.AddComponent<PrerequisiteNoFeature>(c => { c.m_Feature = BaseRef; });
        }

        public static BlueprintProgression Get() {
            if (prog != null) return prog;
            return BlueprintTools.GetModBlueprint<BlueprintProgression>(IsekaiContext, "MonkBaseLegacy");
        }
    }
}
