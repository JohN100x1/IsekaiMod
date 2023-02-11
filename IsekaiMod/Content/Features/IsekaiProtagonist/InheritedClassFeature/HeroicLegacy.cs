using IsekaiMod.Content.Classes.IsekaiProtagonist;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.EdgeLord;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Hero;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.InheritedClassFeature {

    internal class HeroicLegacy {
        private static BlueprintProgression prog;

        private static BlueprintFeature TrueSmiteFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "TrueSmiteFeature");
        private static BlueprintFeature TrueSmiteAdditionalUse = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "TrueSmiteAdditionalUse");
        private static BlueprintFeature TrueMarkFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "TrueMarkFeature");

        public static void Configure() {

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
                bp.AddComponent<PrerequisiteAlignment>(c => { c.Alignment = Kingmaker.UnitLogic.Alignments.AlignmentMaskType.Good; });
                bp.LevelEntries = new LevelEntry[] {
                    Helpers.CreateLevelEntry(1, TrueSmiteFeature),
                    Helpers.CreateLevelEntry(4, TrueSmiteAdditionalUse),
                    Helpers.CreateLevelEntry(7, TrueSmiteAdditionalUse),
                    Helpers.CreateLevelEntry(10, TrueSmiteAdditionalUse),
                    Helpers.CreateLevelEntry(11, TrueMarkFeature),
                    Helpers.CreateLevelEntry(13, TrueSmiteAdditionalUse),
                    Helpers.CreateLevelEntry(16, TrueSmiteAdditionalUse),
                    Helpers.CreateLevelEntry(19, TrueSmiteAdditionalUse),

            };
                bp.UIGroups = new UIGroup[] {
                    Helpers.CreateUIGroup(TrueSmiteFeature,TrueSmiteAdditionalUse,TrueMarkFeature),
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

