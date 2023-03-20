using IsekaiMod.Content.Classes.IsekaiProtagonist;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.EdgeLord;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Hero;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Villain;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.UnitLogic.FactLogic;
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
                    "By learning druidic secrets you can finally choose your own form and pay tribut to Neko-chan (a two tons tiger with five inches fangs can be rather cute).");
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


                LegacySelection.GetClassFeature().AddFeatures(prog);
                LegacySelection.GetOverwhelmingFeature().AddFeatures(prog);
                EdgeLordLegacySelection.getClassFeature().AddFeatures(prog);
                HeroLegacySelection.getClassFeature().AddFeatures(prog);
                VillainLegacySelection.getClassFeature().AddFeatures(prog);
            }            
        }
        public static void MakeProgsExclusive() {
            if (ClassTools.Classes.ShifterClass == null) { return; }

            BlueprintProgression Stinger = ShifterStingerLegacy.Get();
            BlueprintProgression Dragon = ShifterDragonLegacy.Get();

            BlueprintFeatureReference BaseRef = prog.ToReference<BlueprintFeatureReference>();
            BlueprintFeatureReference StingerRef = Stinger.ToReference<BlueprintFeatureReference>();
            BlueprintFeatureReference DragonRef = Dragon.ToReference<BlueprintFeatureReference>();

            prog.AddComponent<PrerequisiteNoFeature>(c => { c.m_Feature = StingerRef; });
            prog.AddComponent<PrerequisiteNoFeature>(c => { c.m_Feature = DragonRef; });

            Stinger.AddComponent<PrerequisiteNoFeature>(c => { c.m_Feature = BaseRef; });
            Stinger.AddComponent<PrerequisiteNoFeature>(c => { c.m_Feature = StingerRef; });

            Stinger.AddComponent<PrerequisiteNoFeature>(c => { c.m_Feature = BaseRef; });
            Stinger.AddComponent<PrerequisiteNoFeature>(c => { c.m_Feature = DragonRef; });
        }

        public static BlueprintProgression Get() {
            if (prog != null) return prog;
            return BlueprintTools.GetModBlueprint<BlueprintProgression>(IsekaiContext, "ShifterBaseLegacy");
        }
    }
}
