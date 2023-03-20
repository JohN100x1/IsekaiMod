using IsekaiMod.Content.Classes.IsekaiProtagonist;
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

    internal class KineticLegacy {
        

        private static BlueprintProgression prog;

        public static void Configure() {
            var IsekaiKineticistTraining = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiKineticistTraining", bp => {
                bp.SetName(IsekaiContext, "Deprecated");
                bp.SetDescription(IsekaiContext, "Old Feature, reference kept so your save won't crash!");
                bp.m_Icon = StaticReferences.SorcererArcana.m_Icon;
                
            });

            prog = Helpers.CreateBlueprint<BlueprintProgression>(IsekaiContext, "KineticLegacy", bp => {
                bp.SetName(IsekaiContext, "Kineticist Legacy - Kinetic Lord");
                bp.SetDescription(IsekaiContext, "Most Protagonists only occasionally use kinetic blasts when they think they would look cool.\n But you really love them, and given that there is no other cantrip this overpowered why not?");
                bp.GiveFeaturesForPreviousLevels = true;
                bp.AddComponent<AddProficiencies>(c => {
                    c.WeaponProficiencies = new Kingmaker.Enums.WeaponCategory[] { Kingmaker.Enums.WeaponCategory.KineticBlast };
                });
            });
            LegacySelection.GetClassFeature().AddFeatures(prog);
            LegacySelection.GetOverwhelmingFeature().AddFeatures(prog);
            HeroLegacySelection.getClassFeature().AddFeatures(prog);
            VillainLegacySelection.getClassFeature().AddFeatures(prog);
        }
        public static void PatchProgression() {
            if (prog != null) {
                prog = StaticReferences.PatchClassProgressionBasedOnRefClass(prog, ClassTools.Classes.KineticistClass);
                BlueprintCharacterClassReference myClass = IsekaiProtagonistClass.GetReference();
                StaticReferences.PatchProgressionFeaturesBasedOnReferenceClass(prog, myClass, ClassTools.ClassReferences.KineticistClass);
            }            
        }
        public static void MakeKineticProgsExclusive() {
            BlueprintProgression Knight = KineticKnightLegacy.Get();
            BlueprintProgression OS = KineticOverwhelmingSoulLegacy.Get();
            BlueprintProgression DE = KineticDarkElementalistLegacy.Get();

            BlueprintFeatureReference BaseRef = prog.ToReference<BlueprintFeatureReference>();
            BlueprintFeatureReference KnightRef = Knight.ToReference<BlueprintFeatureReference>();
            BlueprintFeatureReference OSRef = OS.ToReference<BlueprintFeatureReference>();
            BlueprintFeatureReference DERef = DE.ToReference<BlueprintFeatureReference>();

            prog.AddComponent<PrerequisiteNoFeature>(c => { c.m_Feature = KnightRef; });
            prog.AddComponent<PrerequisiteNoFeature>(c => { c.m_Feature = OSRef; });
            prog.AddComponent<PrerequisiteNoFeature>(c => { c.m_Feature = DERef; });

            Knight.AddComponent<PrerequisiteNoFeature>(c => { c.m_Feature = BaseRef; });
            Knight.AddComponent<PrerequisiteNoFeature>(c => { c.m_Feature = OSRef; });
            Knight.AddComponent<PrerequisiteNoFeature>(c => { c.m_Feature = DERef; });

            OS.AddComponent<PrerequisiteNoFeature>(c => { c.m_Feature = BaseRef; });
            OS.AddComponent<PrerequisiteNoFeature>(c => { c.m_Feature = KnightRef; });
            OS.AddComponent<PrerequisiteNoFeature>(c => { c.m_Feature = DERef; });

            DE.AddComponent<PrerequisiteNoFeature>(c => { c.m_Feature = BaseRef; });
            DE.AddComponent<PrerequisiteNoFeature>(c => { c.m_Feature = KnightRef; });
            DE.AddComponent<PrerequisiteNoFeature>(c => { c.m_Feature = OSRef; });
        }

        public static BlueprintProgression Get() {
            if (prog != null) return prog;
            return BlueprintTools.GetModBlueprint<BlueprintProgression>(IsekaiContext, "KineticLegacy");
        }
    }
}
