using IsekaiMod.Content.Classes.IsekaiProtagonist;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.EdgeLord;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Hero;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.InheritedClassFeature {

    internal class SkaldBaseLegacy {
        

        private static BlueprintProgression prog;

        public static void Configure() {

            prog = Helpers.CreateBlueprint<BlueprintProgression>(IsekaiContext, "SkaldBaseLegacy", bp => {
                bp.SetName(IsekaiContext, "Skald Legacy - Metal Singer");
                bp.SetDescription(IsekaiContext, 
                    "Your songs scream out your rage at the world. \n" +
                    "Inspiring your allies to rage along with your songs."
                    );
                bp.GiveFeaturesForPreviousLevels = true;
            });

            LegacySelection.GetClassFeature().AddFeatures(prog);
            LegacySelection.GetOverwhelmingFeature().AddFeatures(prog);
            HeroLegacySelection.getClassFeature().AddFeatures(prog);
            EdgeLordLegacySelection.getClassFeature().AddFeatures(prog);
        }
        public static void PatchProgression() {
            if (prog != null) {
                prog = StaticReferences.PatchClassProgressionBasedOnRefClass(prog, ClassTools.Classes.SkaldClass);
                BlueprintCharacterClassReference myClass = IsekaiProtagonistClass.GetReference();
                StaticReferences.PatchProgressionFeaturesBasedOnReferenceClass(prog, myClass, ClassTools.ClassReferences.SkaldClass);
            }            
        }
        public static void MakeProgsExclusive() {
            BlueprintProgression SilverTongue = SkaldSilverTongueLegacy.Get();
            BlueprintProgression Voice= SkaldVoiceLegacy.Get();

            BlueprintFeatureReference BaseRef = prog.ToReference<BlueprintFeatureReference>();
            BlueprintFeatureReference SilverTongueRef = SilverTongue.ToReference<BlueprintFeatureReference>();
            BlueprintFeatureReference VoiceRef = Voice.ToReference<BlueprintFeatureReference>();

            prog.AddComponent<PrerequisiteNoFeature>(c => { c.m_Feature = SilverTongueRef; });
            prog.AddComponent<PrerequisiteNoFeature>(c => { c.m_Feature = VoiceRef; });

            SilverTongue.AddComponent<PrerequisiteNoFeature>(c => { c.m_Feature = BaseRef; });
            SilverTongue.AddComponent<PrerequisiteNoFeature>(c => { c.m_Feature = VoiceRef; });

            Voice.AddComponent<PrerequisiteNoFeature>(c => { c.m_Feature = BaseRef; });
            Voice.AddComponent<PrerequisiteNoFeature>(c => { c.m_Feature = SilverTongueRef; });
        }

        public static BlueprintProgression Get() {
            if (prog != null) return prog;
            return BlueprintTools.GetModBlueprint<BlueprintProgression>(IsekaiContext, "SkaldBaseLegacy");
        }
    }
}
