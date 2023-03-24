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

    internal class ShifterBaseLegacy {
        

        private static BlueprintProgression prog;

        public static void Configure() {

            prog = Helpers.CreateBlueprint<BlueprintProgression>(IsekaiContext, "ShifterBaseLegacy", bp => {
                bp.SetName(IsekaiContext, "Shifter Legacy - Ditto");
                bp.SetDescription(IsekaiContext, 
                    "Some hard facts : you did not choose to reincarnate on this world, nor could you choose your new body. \n" +
                    "Nothing can be done for the fist part but you can change the latter ! \n" +
                    "By learning druidic secrets you can finally choose your own form.");
                bp.GiveFeaturesForPreviousLevels = true;
            });
        }
        public static void PatchProgression() {
            if (prog != null) {
                if (ClassTools.Classes.ShifterClass == null) {
                    Main.Log("Shifter Class not present Shifter skipped.");
                    return; 
                }
                BlueprintCharacterClassReference myClass = IsekaiProtagonistClass.GetReference();
                prog = StaticReferences.PatchClassProgressionBasedOnRefClass(prog, ClassTools.Classes.ShifterClass);
                StaticReferences.PatchProgressionFeaturesBasedOnReferenceClass(prog, myClass, ClassTools.ClassReferences.ShifterClass);


                LegacySelection.Register(prog);
                EdgeLordLegacySelection.Register(prog);
                HeroLegacySelection.Register(prog);
                VillainLegacySelection.Prohibit(prog);
                GodEmperorLegacySelection.Prohibit(prog);

                prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = ShifterStingerLegacy.Get().ToReference<BlueprintFeatureReference>(); });
                prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = ShifterDragonLegacy.Get().ToReference<BlueprintFeatureReference>(); });
                prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = DruidBaseLegacy.Get().ToReference<BlueprintFeatureReference>(); });
            }            
        }

        public static BlueprintProgression Get() {
            if (prog != null) return prog;
            return BlueprintTools.GetModBlueprint<BlueprintProgression>(IsekaiContext, "ShifterBaseLegacy");
        }
    }
}
