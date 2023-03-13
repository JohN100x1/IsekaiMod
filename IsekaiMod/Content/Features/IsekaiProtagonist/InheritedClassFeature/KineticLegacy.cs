using IsekaiMod.Content.Classes.IsekaiProtagonist;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Villain;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.UnitLogic.FactLogic;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.InheritedClassFeature {

    internal class KineticLegacy {
        public static BlueprintProgression KineticBlastProgression = BlueprintTools.GetBlueprint<BlueprintProgression>("30a5b8cf728bd4a4d8d90fc4953e322e");
        public static BlueprintProgression KineticOverflowProgression = BlueprintTools.GetBlueprint<BlueprintProgression>("86beb0391653faf43aec60d5ec05b538");
        public static BlueprintProgression KineticInfusionSpecProgression = BlueprintTools.GetBlueprint<BlueprintProgression>("1f86ce843fbd2d548a8d88ea1b652452");

        public static BlueprintFeature KineticDismissInfusion = BlueprintTools.GetBlueprint<BlueprintFeature>("48bbbb16189443049663ca161bb3e338");
        public static BlueprintFeature KineticBurnFeature = BlueprintTools.GetBlueprint<BlueprintFeature>("57e3577a0eb53294e9d7cc649d5239a3");
        public static BlueprintFeature KineticGatherPower = BlueprintTools.GetBlueprint<BlueprintFeature>("71f526b1d4b50b94582b0b9cbe12b0e0");

        public static BlueprintFeatureSelection KineticFocusSelection = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("1f3a15a3ae8a5524ab8b97f469bf4e3d");
        public static BlueprintFeatureSelection KineticInfusionSelection = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("58d6f8e9eea63f6418b107ce64f315ea");
        public static BlueprintFeature KineticOverflowBonusFeature = BlueprintTools.GetBlueprint<BlueprintFeature>("2496916d8465dbb4b9ddeafdf28c67d8");
        public static BlueprintFeatureSelection KineticWildSelection = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("5c883ae0cd6d7d5448b7a420f51f8459");
        public static BlueprintFeature KineticMetakinesisEmpower = BlueprintTools.GetBlueprint<BlueprintFeature>("70322f5a2a294e54a9552f77ee85b0a7");
        public static BlueprintFeatureSelection KineticSecElementSelection = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("4204bc10b3d5db440b1f52f0c375848b");
        public static BlueprintFeature KineticMetakinesisMaximize = BlueprintTools.GetBlueprint<BlueprintFeature>("0306bc7c6930a5c4b879c7dea78208c2");
        public static BlueprintFeature KineticSuperCharge = BlueprintTools.GetBlueprint<BlueprintFeature>("5a13756fb4be25f46951bc3f16448276");
        public static BlueprintFeature KineticMetakinesisQuicken = BlueprintTools.GetBlueprint<BlueprintFeature>("4bb9d2328a3fdca419243d6116b337ac");
        public static BlueprintFeatureSelection KineticThirdElementSelection = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("e2c1718828fc843479f18ab4d75ded86");
        public static BlueprintFeature KineticCompBlastSpec = BlueprintTools.GetBlueprint<BlueprintFeature>("df8897708983d4846871ca72c4cbfc52");
        public static BlueprintFeatureSelection KineticMetakinesisMaster = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("8c33002186eb2fd45a140eed1301e207");

        private static BlueprintProgression prog;

        public static void Configure() {
            var IsekaiKineticistTraining = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiKineticistTraining", bp => {
                bp.SetName(IsekaiContext, "Kineticist Training");
                bp.SetDescription(IsekaiContext, "You count your Isekai Hero Level to qualify for Kineticist feats. If you also have actual Kineticist Levels this ability stacks.");
                bp.m_Icon = StaticReferences.SorcererArcana.m_Icon;
                bp.AddComponent<ClassLevelsForPrerequisites>(c => {
                    c.m_FakeClass = ClassTools.ClassReferences.KineticistClass;
                    c.m_ActualClass = IsekaiProtagonistClass.GetReference();
                    c.Modifier = 1.0;
                });
                bp.AddComponent<AddProficiencies>(c => {
                    c.WeaponProficiencies = new Kingmaker.Enums.WeaponCategory[] { Kingmaker.Enums.WeaponCategory.KineticBlast };
                });
            });

            prog = Helpers.CreateBlueprint<BlueprintProgression>(IsekaiContext, "KineticLegacy", bp => {
                bp.SetName(IsekaiContext, "Kineticist Legacy - Kinetic Lord");
                bp.SetDescription(IsekaiContext, "Most Protagonists only occasionally use kinetic blasts when they think they would look cool.\n But you really loved them, and given that there is no other cantrip this overpowered why not?");
                bp.GiveFeaturesForPreviousLevels = true;
                bp.IsClassFeature = true;
                bp.m_Classes = new BlueprintProgression.ClassWithLevel[] {
                    new BlueprintProgression.ClassWithLevel {
                        m_Class = IsekaiProtagonistClass.GetReference(),
                        AdditionalLevel = 0
                    }
                };
                bp.LevelEntries = new LevelEntry[] {
                    Helpers.CreateLevelEntry(1, KineticBlastProgression, KineticBurnFeature, KineticFocusSelection, KineticGatherPower, KineticInfusionSelection, KineticOverflowProgression, KineticInfusionSpecProgression, KineticDismissInfusion, IsekaiKineticistTraining),
                    Helpers.CreateLevelEntry(2, KineticWildSelection),
                    Helpers.CreateLevelEntry(3,KineticInfusionSelection),
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
                    Helpers.CreateUIGroup(KineticInfusionSelection),
                    Helpers.CreateUIGroup(KineticBurnFeature, KineticWildSelection),
                    Helpers.CreateUIGroup(KineticOverflowProgression, KineticMetakinesisEmpower,KineticMetakinesisMaster,KineticMetakinesisMaximize,KineticMetakinesisQuicken),
                    Helpers.CreateUIGroup(KineticBlastProgression, KineticCompBlastSpec,KineticThirdElementSelection,KineticSecElementSelection, KineticFocusSelection, KineticSuperCharge),
                };

            });
            LegacySelection.GetClassFeature().AddFeatures(prog);
            LegacySelection.GetOverwhelmingFeature().AddFeatures(prog);
            VillainLegacySelection.getClassFeature().AddFeatures(prog);
        }
        public static void PatchKineticistProgression() {

            BlueprintCharacterClassReference refClass = ClassTools.ClassReferences.KineticistClass;
            BlueprintCharacterClassReference myClass = IsekaiProtagonistClass.GetReference();
            StaticReferences.PatchClassIntoFeatureOfReferenceClass(KineticBlastProgression, myClass, refClass, 0);
            StaticReferences.PatchClassIntoFeatureOfReferenceClass(KineticOverflowProgression, myClass, refClass, 0);
            StaticReferences.PatchClassIntoFeatureOfReferenceClass(KineticInfusionSpecProgression, myClass, refClass, 0);
            StaticReferences.PatchClassIntoFeatureOfReferenceClass(KineticFocusSelection, myClass, refClass, 0);
            StaticReferences.PatchClassIntoFeatureOfReferenceClass(KineticSecElementSelection, myClass, refClass, 0);
            StaticReferences.PatchClassIntoFeatureOfReferenceClass(KineticThirdElementSelection, myClass, refClass, 0);
            prog.AddComponent<PrerequisiteNoFeature>(c => { c.m_Feature = KineticKnightLegacy.Get().ToReference<BlueprintFeatureReference>(); });
        }
        public static BlueprintProgression Get() {
            if (prog != null) return prog;
            return BlueprintTools.GetModBlueprint<BlueprintProgression>(IsekaiContext, "KineticLegacy");
        }
    }
}
