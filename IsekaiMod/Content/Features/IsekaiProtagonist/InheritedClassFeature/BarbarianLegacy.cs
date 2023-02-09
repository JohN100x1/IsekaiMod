using IsekaiMod.Content.Classes.IsekaiProtagonist;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.EdgeLord;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.InheritedClassFeature {

    internal class BarbarianLegacy {

        public static void configure() {
            StaticReferences.BarbarianRageResource.m_MaxAmount.Class.m_Array.AppendToArray(IsekaiProtagonistClass.GetReference());
            var IsekaiBarbarianTraining = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "BarbarianTraining", bp => {
                bp.SetName(IsekaiContext, "Barbarian Training");
                bp.SetDescription(IsekaiContext, "Well, if you actually dare to call what barbarians do training, either way your experience in both classes stacks for the sake of qualifications...");
                bp.m_Icon = StaticReferences.SorcererArcana.m_Icon;
                bp.AddComponent<ClassLevelsForPrerequisites>(c => {
                    c.m_FakeClass = BlueprintTools.GetBlueprintReference<BlueprintCharacterClassReference>("f7d7eb166b3dd594fb330d085df41853");
                    c.m_ActualClass = IsekaiProtagonistClass.GetReference();
                    c.Modifier = 1.0;
                });
            });
            var prog = Helpers.CreateBlueprint<BlueprintProgression>(IsekaiContext, "BarbarianLegacy", bp => {
                bp.SetName(IsekaiContext, "Barbarian Legacy - Ball of Rage");
                bp.SetDescription(IsekaiContext, "You really are just a walking bundle of issues waiting to explode at anyone getting too close aren't you?");
                bp.GiveFeaturesForPreviousLevels = true;
                bp.IsClassFeature = true;
                bp.m_Classes = new BlueprintProgression.ClassWithLevel[] {
                    new BlueprintProgression.ClassWithLevel {
                        m_Class = IsekaiProtagonistClass.GetReference(),
                        AdditionalLevel = 0
                    }
                };
                bp.LevelEntries = new LevelEntry[] {
                    Helpers.CreateLevelEntry(1, StaticReferences.BarbarianRage, IsekaiBarbarianTraining),
                    Helpers.CreateLevelEntry(2, StaticReferences.BarbarianRagePower),
                    Helpers.CreateLevelEntry(4, StaticReferences.BarbarianRagePower),
                    Helpers.CreateLevelEntry(6, StaticReferences.BarbarianRagePower),
                    Helpers.CreateLevelEntry(7, StaticReferences.BarbarianDamageReduction),
                    Helpers.CreateLevelEntry(8, StaticReferences.BarbarianRagePower),
                    Helpers.CreateLevelEntry(9, StaticReferences.BarbarianDamageReduction),
                    Helpers.CreateLevelEntry(10, StaticReferences.BarbarianRagePower),
                    Helpers.CreateLevelEntry(11, StaticReferences.BarbarianRageGreater),
                    Helpers.CreateLevelEntry(12, StaticReferences.BarbarianRagePower),
                    Helpers.CreateLevelEntry(13, StaticReferences.BarbarianDamageReduction),
                    Helpers.CreateLevelEntry(14, StaticReferences.BarbarianRagePower),
                    Helpers.CreateLevelEntry(16, StaticReferences.BarbarianDamageReduction,StaticReferences.BarbarianRagePower),
                    Helpers.CreateLevelEntry(17, StaticReferences.BarbarianRageTireless),
                    Helpers.CreateLevelEntry(18, StaticReferences.BarbarianRagePower),
                    Helpers.CreateLevelEntry(19, StaticReferences.BarbarianDamageReduction),
            };
                bp.UIGroups = new UIGroup[] {
                    Helpers.CreateUIGroup(StaticReferences.BarbarianRage, StaticReferences.BarbarianRageGreater, StaticReferences.BarbarianRageTireless, StaticReferences.BarbarianDamageReduction),
                    Helpers.CreateUIGroup(StaticReferences.BarbarianRagePower, IsekaiBarbarianTraining)
                };
            });
            LegacySelection.getClassFeature().AddFeatures(prog);
            LegacySelection.getOverwhelmingFeature().AddFeatures(prog);
            EdgeLordLegacySelection.getClassFeature().AddFeatures(prog);
        }
    }
}