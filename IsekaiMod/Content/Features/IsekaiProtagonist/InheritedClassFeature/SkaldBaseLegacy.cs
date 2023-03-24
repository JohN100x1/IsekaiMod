using IsekaiMod.Content.Classes.IsekaiProtagonist;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.EdgeLord;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.GodEmperor;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Hero;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Villain;
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

            LegacySelection.Register(prog);
            EdgeLordLegacySelection.Register(prog);
            HeroLegacySelection.Prohibit(prog);
            VillainLegacySelection.Prohibit(prog);
            GodEmperorLegacySelection.Prohibit(prog);
        }
        public static void PatchProgression() {
            if (prog != null) {
                prog = StaticReferences.PatchClassProgressionBasedOnRefClass(prog, ClassTools.Classes.SkaldClass);
                BlueprintCharacterClassReference myClass = IsekaiProtagonistClass.GetReference();
                StaticReferences.PatchProgressionFeaturesBasedOnReferenceClass(prog, myClass, ClassTools.ClassReferences.SkaldClass);

                prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = BardLegacy.Get().ToReference<BlueprintFeatureReference>(); });
                prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = BarbarianLegacy.Get().ToReference<BlueprintFeatureReference>(); });
                prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = SkaldVoiceLegacy.Get().ToReference<BlueprintFeatureReference>(); });
                prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = SkaldSilverTongueLegacy.Get().ToReference<BlueprintFeatureReference>(); });
            }            
        }

        public static BlueprintProgression Get() {
            if (prog != null) return prog;
            return BlueprintTools.GetModBlueprint<BlueprintProgression>(IsekaiContext, "SkaldBaseLegacy");
        }
    }
}
