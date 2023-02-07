using IsekaiMod.Content.Classes.IsekaiProtagonist;
using IsekaiMod.Content.Classes.IsekaiProtagonist.Archetypes;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.EdgeLord;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Villain;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Designers.Mechanics.Facts;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.InheritedClassFeature {
    internal class KineticLegacy {
        public static readonly BlueprintProgression KineticBlastProgression = BlueprintTools.GetBlueprint<BlueprintProgression>("30a5b8cf728bd4a4d8d90fc4953e322e");
        public static readonly BlueprintProgression KineticOverflowProgression = BlueprintTools.GetBlueprint<BlueprintProgression>("86beb0391653faf43aec60d5ec05b538");
        public static readonly BlueprintProgression KineticInfusionSpecProgression = BlueprintTools.GetBlueprint<BlueprintProgression>("1f86ce843fbd2d548a8d88ea1b652452");

        public static readonly BlueprintFeature KineticDismissInfusion = BlueprintTools.GetBlueprint<BlueprintFeature>("48bbbb16189443049663ca161bb3e338");
        public static readonly BlueprintFeature KineticBurnFeature = BlueprintTools.GetBlueprint<BlueprintFeature>("57e3577a0eb53294e9d7cc649d5239a3");
        public static readonly BlueprintFeature KineticGatherPower = BlueprintTools.GetBlueprint<BlueprintFeature>("71f526b1d4b50b94582b0b9cbe12b0e0");


        public static readonly BlueprintFeatureSelection KineticFocusSelection = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("1f3a15a3ae8a5524ab8b97f469bf4e3d");
        public static readonly BlueprintFeatureSelection KineticInfusionSelection = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("58d6f8e9eea63f6418b107ce64f315ea");
        public static readonly BlueprintFeature KineticOverflowBonusFeature = BlueprintTools.GetBlueprint<BlueprintFeature>("2496916d8465dbb4b9ddeafdf28c67d8");
        public static readonly BlueprintFeatureSelection KineticWildSelection = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("5c883ae0cd6d7d5448b7a420f51f8459");
        public static readonly BlueprintFeature KineticMetakinesisEmpower = BlueprintTools.GetBlueprint<BlueprintFeature>("70322f5a2a294e54a9552f77ee85b0a7");
        public static readonly BlueprintFeatureSelection KineticSecElementSelection = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("4204bc10b3d5db440b1f52f0c375848b");
        public static readonly BlueprintFeature KineticMetakinesisMaximize = BlueprintTools.GetBlueprint<BlueprintFeature>("0306bc7c6930a5c4b879c7dea78208c2");
        public static readonly BlueprintFeature KineticSuperCharge = BlueprintTools.GetBlueprint<BlueprintFeature>("5a13756fb4be25f46951bc3f16448276");
        public static readonly BlueprintFeature KineticMetakinesisQuicken = BlueprintTools.GetBlueprint<BlueprintFeature>("4bb9d2328a3fdca419243d6116b337ac");
        public static readonly BlueprintFeatureSelection KineticThirdElementSelection = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("e2c1718828fc843479f18ab4d75ded86");
        public static readonly BlueprintFeature KineticCompBlastSpec = BlueprintTools.GetBlueprint<BlueprintFeature>("df8897708983d4846871ca72c4cbfc52");
        public static readonly BlueprintFeatureSelection KineticMetakinesisMaster = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("8c33002186eb2fd45a140eed1301e207");

        public static void configure() {
            var IsekaiKineticistTraining = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiKineticistTraining", bp => {
                bp.SetName(IsekaiContext, "Kineticist Training");
                bp.SetDescription(IsekaiContext, "You count your Isekai Hero Level to qualify for Kineticist feats. If you also have actual Kineticist Levels this ability stacks.");
                bp.m_Icon = StaticReferences.SorcererArcana.m_Icon;
                bp.AddComponent<ClassLevelsForPrerequisites>(c => {
                    c.m_FakeClass = BlueprintTools.GetBlueprintReference<BlueprintCharacterClassReference>("42a455d9ec1ad924d889272429eb8391");
                    c.m_ActualClass = IsekaiProtagonistClass.GetReference();
                    c.Modifier = 1.0;
                });
            });

            var prog = Helpers.CreateBlueprint<BlueprintProgression>(IsekaiContext, "KineticLegacy", bp => {
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
                    Helpers.CreateLevelEntry(20, KineticWildSelection),

            };
                bp.UIGroups = new UIGroup[] {
                    Helpers.CreateUIGroup(KineticInfusionSelection),
                    Helpers.CreateUIGroup(KineticBurnFeature, KineticWildSelection),
                    Helpers.CreateUIGroup(KineticOverflowProgression, KineticMetakinesisEmpower,KineticMetakinesisMaster,KineticMetakinesisMaximize,KineticMetakinesisQuicken),
                    Helpers.CreateUIGroup(KineticBlastProgression, KineticCompBlastSpec,KineticThirdElementSelection,KineticSecElementSelection, KineticFocusSelection, KineticSuperCharge),
                };

            });
            LegacySelection.getClassFeature().AddFeatures(prog);
            LegacySelection.getOverwhelmingFeature().AddFeatures(prog);
            VillainLegacySelection.getClassFeature().AddFeatures(prog);
        }
        public static void PatchKineticistProgression() {
            BlueprintCharacterClass myClass = IsekaiProtagonistClass.Get();
            var KineticBlastProgression = BlueprintTools.GetBlueprint<BlueprintProgression>("30a5b8cf728bd4a4d8d90fc4953e322e");
            var KineticOverflowProgression = BlueprintTools.GetBlueprint<BlueprintProgression>("86beb0391653faf43aec60d5ec05b538");
            var KineticInfusionSpecProgression = BlueprintTools.GetBlueprint<BlueprintProgression>("1f86ce843fbd2d548a8d88ea1b652452");

            var KineticFocusSelection = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("1f3a15a3ae8a5524ab8b97f469bf4e3d");
            var KineticSecElementSelection = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("4204bc10b3d5db440b1f52f0c375848b");
            var KineticThirdElementSelection = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("e2c1718828fc843479f18ab4d75ded86");

            KineticBlastProgression.AddClass(myClass);
            KineticBlastProgression.GiveFeaturesForPreviousLevels = true;
            KineticOverflowProgression.AddClass(myClass);
            KineticOverflowProgression.GiveFeaturesForPreviousLevels = true;
            KineticInfusionSpecProgression.AddClass(myClass);
            KineticInfusionSpecProgression.GiveFeaturesForPreviousLevels = true;


            // the actual elemental blasts have to be progressions by definition, otherwise someone before me has already screwed up
            foreach (var elementalFocusRef in KineticFocusSelection.m_AllFeatures) {
                var elementalFocus = BlueprintTools.GetBlueprint<BlueprintProgression>(elementalFocusRef.Guid);
                elementalFocus.AddClass(myClass);
                elementalFocus.GiveFeaturesForPreviousLevels = true;
            }
            foreach (var elementalFocusRef in KineticSecElementSelection.m_AllFeatures) {
                var elementalFocus = BlueprintTools.GetBlueprint<BlueprintProgression>(elementalFocusRef.Guid);
                elementalFocus.AddClass(myClass);
                elementalFocus.GiveFeaturesForPreviousLevels = true;
            }
            foreach (var elementalFocusRef in KineticThirdElementSelection.m_AllFeatures) {
                var elementalFocus = BlueprintTools.GetBlueprint<BlueprintProgression>(elementalFocusRef.Guid);
                elementalFocus.AddClass(myClass);
                elementalFocus.GiveFeaturesForPreviousLevels = true;
            }
        }
    }
}
