using IsekaiMod.Content.Classes.IsekaiProtagonist;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.EdgeLord;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Hero;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Designers.Mechanics.Facts;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.InheritedClassFeature {

    internal class HeroicLegacy {
        private static BlueprintProgression prog;

        private static BlueprintFeature TrueSmiteFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "TrueSmiteFeature");
        private static BlueprintFeature TrueSmiteAdditionalUse = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "TrueSmiteAdditionalUse");
        private static BlueprintFeature TrueMarkFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "TrueMarkFeature");

        private static BlueprintFeature LayOnHands = BlueprintTools.GetBlueprint<BlueprintFeature>("858a3689c285c844d9e6ce278e686491");
        private static BlueprintFeatureSelection Mercy = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("02b187038a8dce545bb34bbfb346428d");
        private static BlueprintAbilityResource LoHRessource = BlueprintTools.GetBlueprint<BlueprintAbilityResource>("9dedf41d995ff4446a181f143c3db98c");

        public static void Configure() {
            LoHRessource.m_MaxAmount.Class.m_Array.AppendToArray(IsekaiProtagonistClass.GetReference());

            prog = Helpers.CreateBlueprint<BlueprintProgression>(IsekaiContext, "HeroicLegacy", bp => {
                bp.SetName(IsekaiContext, "Paladin Legacy - Hero of Light");
                bp.SetDescription(IsekaiContext, "You are a true hero, smighting your enemies wherever you go.");
                bp.GiveFeaturesForPreviousLevels = true;
                bp.IsClassFeature = true;
                bp.m_Classes = new BlueprintProgression.ClassWithLevel[] {
                    new BlueprintProgression.ClassWithLevel {
                        m_Class = IsekaiProtagonistClass.GetReference(),
                        AdditionalLevel = 0
                    }
                };
                bp.AddComponent<ClassLevelsForPrerequisites>(c => {
                    c.m_FakeClass = ClassTools.ClassReferences.PaladinClass;
                    c.m_ActualClass = IsekaiProtagonistClass.GetReference();
                    c.Modifier = 1.0;
                });
                bp.AddComponent<PrerequisiteAlignment>(c => { c.Alignment = Kingmaker.UnitLogic.Alignments.AlignmentMaskType.Good; });
                bp.LevelEntries = new LevelEntry[] {
                    Helpers.CreateLevelEntry(1, TrueSmiteFeature),
                    Helpers.CreateLevelEntry(2, LayOnHands),
                    Helpers.CreateLevelEntry(3, Mercy),
                    Helpers.CreateLevelEntry(4, TrueSmiteAdditionalUse),
                    Helpers.CreateLevelEntry(6, Mercy),
                    Helpers.CreateLevelEntry(7, TrueSmiteAdditionalUse),
                    Helpers.CreateLevelEntry(9, Mercy),
                    Helpers.CreateLevelEntry(10, TrueSmiteAdditionalUse),
                    Helpers.CreateLevelEntry(11, TrueMarkFeature),
                    Helpers.CreateLevelEntry(12, Mercy),
                    Helpers.CreateLevelEntry(13, TrueSmiteAdditionalUse),
                    Helpers.CreateLevelEntry(15, Mercy),
                    Helpers.CreateLevelEntry(16, TrueSmiteAdditionalUse),
                    Helpers.CreateLevelEntry(18, Mercy),
                    Helpers.CreateLevelEntry(19, TrueSmiteAdditionalUse),

            };
                bp.UIGroups = new UIGroup[] {
                    Helpers.CreateUIGroup(TrueSmiteFeature,TrueSmiteAdditionalUse,TrueMarkFeature, Mercy, LayOnHands)
                };

            });
            LegacySelection.GetClassFeature().AddFeatures(prog);
            LegacySelection.GetOverwhelmingFeature().AddFeatures(prog);
            HeroLegacySelection.getClassFeature().AddFeatures(prog);
            EdgeLordLegacySelection.getClassFeature().AddFeatures(prog);
        }
        public static BlueprintProgression Get() {
            if (prog != null) return prog;
            return BlueprintTools.GetModBlueprint<BlueprintProgression>(IsekaiContext, "HeroicLegacy");
        }
    }
}

