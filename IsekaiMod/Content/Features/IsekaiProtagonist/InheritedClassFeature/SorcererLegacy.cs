using IsekaiMod.Content.Classes.IsekaiProtagonist;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Villain;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.InheritedClassFeature {

    internal class SorcererLegacy {
        private static BlueprintProgression prog;

        public static void Configure() {
            ExtraBloodlineSelection.Configure();
            var ExtraSelection = ExtraBloodlineSelection.Get();
            prog = Helpers.CreateBlueprint<BlueprintProgression>(IsekaiContext, "SorcererLegacyProgression", bp => {
                bp.SetName(IsekaiContext, "Sorcerer Legacy - Chimera");
                bp.SetDescription(IsekaiContext, "Their otherworldly knowledge and point of view allow Chimeras to imbue themselves with different bloodlines in order to gain power and strength. \nChimeras are constantly seeking out new sources of power, and their ability to absorb and incorporate these different bloodlines allows them to become truly formidable foes. \nHowever, their constant experimentation with bloodlines can also lead to confusion and uncertainty about their own heritage and identity, as their original ancestry becomes harder to discern over time.");
                bp.GiveFeaturesForPreviousLevels = false;
                bp.IsClassFeature = true;
                bp.m_Classes = new BlueprintProgression.ClassWithLevel[] {
                    new BlueprintProgression.ClassWithLevel {
                        m_Class = IsekaiProtagonistClass.GetReference(),
                        AdditionalLevel = 0
                    }

                };
                //do not place the bloodline at level 1, when inside a progression it does not like that and makes all options invalid, strangely for oracle it works and that is a progression too...
                bp.LevelEntries = new LevelEntry[] {
                    Helpers.CreateLevelEntry (1, ExtraSelection ),
                    Helpers.CreateLevelEntry(3, ExtraSelection),
                    Helpers.CreateLevelEntry(6, ExtraSelection),
                    Helpers.CreateLevelEntry(9, ExtraSelection),
                    Helpers.CreateLevelEntry(12, ExtraSelection),
                    Helpers.CreateLevelEntry(15, ExtraSelection),
                    Helpers.CreateLevelEntry(18, ExtraSelection),
                };
                bp.UIGroups = new UIGroup[] {
                    Helpers.CreateUIGroup( ExtraSelection),
                };
            });
            LegacySelection.GetClassFeature().AddFeatures(prog);
            LegacySelection.GetOverwhelmingFeature().AddFeatures(prog);
            VillainLegacySelection.getClassFeature().AddFeatures(prog);

        }
        public static void PatchProgression() {
            BlueprintCharacterClassReference refClass = ClassTools.Classes.SorcererClass.ToReference<BlueprintCharacterClassReference>();
            BlueprintCharacterClassReference myClass = IsekaiProtagonistClass.GetReference();
            StaticReferences.PatchClassIntoFeatureOfReferenceClass(StaticReferences.SorcererBloodlineSelection, myClass, refClass, 0, new BlueprintFeatureBase[] { });
        }

        public static BlueprintProgression Get() {
            if (prog != null) return prog;
            return BlueprintTools.GetModBlueprint<BlueprintProgression>(IsekaiContext, "SorcererLegacyProgression");
        }
    }

    internal class ExtraBloodlineSelection {
        private static BlueprintFeatureSelection IsekaiSorcererSelection;

        public static void Configure() {
            var IsekaiBloodlineSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "IsekaiBloodlineSelection", bp => {
                bp.SetName(IsekaiContext, "Bloodline");
                bp.SetDescription(IsekaiContext, "You can pick additional bloodlines as your chimera blood becomes stronger.");
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.IgnorePrerequisites = true;
                //bp.Group = FeatureGroup.BloodLine;
                bp.m_AllFeatures = StaticReferences.SorcererBloodlineSelection.m_AllFeatures;
            });
            IsekaiSorcererSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "IsekaiSorcererSelection", bp => {
                bp.SetName(IsekaiContext, "Bloodline Evolution");
                bp.SetDescription(IsekaiContext, "As your chimera blood evolves you can pick a new bloodline feat or a new bloodline.");
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                //bp.Group = FeatureGroup.BloodLine;
                bp.m_AllFeatures = new BlueprintFeatureReference[] {
                    IsekaiBloodlineSelection.ToReference<BlueprintFeatureReference>(),
                    StaticReferences.SorcererFeatSelection.ToReference<BlueprintFeatureReference>(),
                };
            });

        }

        public static BlueprintFeatureSelection Get() {
            if (IsekaiSorcererSelection != null) return IsekaiSorcererSelection;
            return BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "IsekaiSorcererSelection");
        }

        public static BlueprintFeatureReference GetReference() {
            return Get().ToReference<BlueprintFeatureReference>();
        }
    }
}
