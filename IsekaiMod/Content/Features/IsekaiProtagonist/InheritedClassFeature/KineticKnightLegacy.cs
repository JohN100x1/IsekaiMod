using IsekaiMod.Content.Classes.IsekaiProtagonist;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.EdgeLord;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Hero;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Content.Features.IsekaiProtagonist.InheritedClassFeature.KineticLegacy;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.InheritedClassFeature {
    internal class KineticKnightLegacy {
        private static BlueprintFeature EnergizeWeapon = BlueprintTools.GetBlueprint<BlueprintFeature>("fb9fe27f13934807bcd62dfeec477758");
        private static BlueprintFeature KineticBlade = BlueprintTools.GetBlueprint<BlueprintFeature>("9ff81732daddb174aa8138ad1297c787");
        private static BlueprintFeatureSelection KineticKnightFocus = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("b1f296f0bd16bc242ae35d0638df82eb");

        private static BlueprintProgression prog;


        public static void configure() {
            var IsekaiKineticistTraining = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiKineticistTraining");

            prog = Helpers.CreateBlueprint<BlueprintProgression>(IsekaiContext, "KineticKnightLegacy", bp => {
                bp.SetName(IsekaiContext, "Kineticist Legacy - Kinetic Knight");
                bp.SetDescription(IsekaiContext, "Just like all Kinetic Knights your sanity is somewhat questionable, after all you willingly choose to forego fighting at range and instead choose to use energy blasts as melee weapons...\nAnd why? Because the burning blade looked cool.");
                bp.GiveFeaturesForPreviousLevels = true;
                bp.IsClassFeature = true;
                bp.m_Classes = new BlueprintProgression.ClassWithLevel[] {
                    new BlueprintProgression.ClassWithLevel {
                        m_Class = IsekaiProtagonistClass.GetReference(),
                        AdditionalLevel = 0
                    }
                };
                LevelEntry level1;
                if (ModSupport.IsExpandedElementEnabled() && EnergizeWeapon != null) {
                    level1 = Helpers.CreateLevelEntry(1, KineticBlastProgression, KineticBurnFeature, KineticKnightFocus, KineticBlade, EnergizeWeapon, KineticGatherPower, KineticOverflowProgression, KineticInfusionSpecProgression, KineticDismissInfusion, IsekaiKineticistTraining);
                    
                } else {
                    level1 = Helpers.CreateLevelEntry(1, KineticBlastProgression, KineticBurnFeature, KineticKnightFocus, KineticBlade, KineticGatherPower, KineticOverflowProgression, KineticInfusionSpecProgression, KineticDismissInfusion, IsekaiKineticistTraining);
                    
                }
                bp.LevelEntries = new LevelEntry[] {
                    level1,
                    Helpers.CreateLevelEntry(2, KineticWildSelection),
                    Helpers.CreateLevelEntry(4, KineticWildSelection),
                    Helpers.CreateLevelEntry(5, KineticInfusionSelection, KineticMetakinesisEmpower),
                    Helpers.CreateLevelEntry(6, KineticWildSelection),
                    Helpers.CreateLevelEntry(7, KineticSecElementSelection),
                    Helpers.CreateLevelEntry(9, KineticInfusionSelection, KineticMetakinesisMaximize),
                    Helpers.CreateLevelEntry(10, KineticWildSelection),
                    Helpers.CreateLevelEntry(11, KineticInfusionSelection, KineticSuperCharge),
                    Helpers.CreateLevelEntry(12, KineticWildSelection),
                    Helpers.CreateLevelEntry(13, KineticInfusionSelection, KineticMetakinesisQuicken),
                    Helpers.CreateLevelEntry(14, KineticWildSelection),
                    Helpers.CreateLevelEntry(15, KineticThirdElementSelection),
                    Helpers.CreateLevelEntry(16, KineticWildSelection, KineticCompBlastSpec),
                    Helpers.CreateLevelEntry(17, KineticInfusionSelection),
                    Helpers.CreateLevelEntry(18, KineticWildSelection),
                    Helpers.CreateLevelEntry(19, KineticInfusionSelection, KineticMetakinesisMaster),

            };
                bp.UIGroups = new UIGroup[] {
                    Helpers.CreateUIGroup(KineticBlade,KineticInfusionSelection),
                    Helpers.CreateUIGroup(KineticBurnFeature, KineticWildSelection),
                    Helpers.CreateUIGroup(KineticOverflowProgression, KineticMetakinesisEmpower,KineticMetakinesisMaster,KineticMetakinesisMaximize,KineticMetakinesisQuicken),
                    Helpers.CreateUIGroup(KineticBlastProgression, KineticCompBlastSpec,KineticThirdElementSelection,KineticSecElementSelection, KineticFocusSelection, KineticSuperCharge),
                };
                

            });
            LegacySelection.GetClassFeature().AddFeatures(prog);
            LegacySelection.GetOverwhelmingFeature().AddFeatures(prog);
            EdgeLordLegacySelection.getClassFeature().AddFeatures(prog);
            HeroLegacySelection.getClassFeature().AddFeatures(prog);
        }
        public static void PatchKineticistProgression() {
            //please note that this only patches the knight progression so this only works in combination of the already done patch by the other version

            BlueprintCharacterClassReference refClass = ClassTools.ClassReferences.KineticistClass;
            BlueprintCharacterClassReference myClass = IsekaiProtagonistClass.GetReference();
            StaticReferences.PatchClassIntoFeatureOfReferenceClass(KineticKnightFocus, myClass, refClass, 0);
        }
        public static BlueprintProgression Get() {
            if (prog != null) return prog;
            return BlueprintTools.GetModBlueprint<BlueprintProgression>(IsekaiContext, "KineticKnightLegacy");
        }
    }
}
