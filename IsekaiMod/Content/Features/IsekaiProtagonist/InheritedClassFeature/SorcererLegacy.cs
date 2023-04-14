using IsekaiMod.Content.Classes.IsekaiProtagonist;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.EdgeLord;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.GodEmperor;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Hero;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Mastermind;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Overlord;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
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
                bp.SetDescription(IsekaiContext, "Their otherworldly knowledge and point of view allow Chimeras to imbue themselves with different bloodlines in order to gain power and strength. \n" +
                    "Chimeras are constantly seeking out new sources of power, and their ability to absorb and incorporate these different bloodlines allows them to become truly formidable foes. \n" +
                    "However, their constant experimentation with bloodlines can also lead to confusion and uncertainty about their own heritage and identity, as their original ancestry becomes harder to discern over time.");
                bp.GiveFeaturesForPreviousLevels = false;
                bp.IsClassFeature = true;
                bp.m_Classes = new BlueprintProgression.ClassWithLevel[] {
                    new BlueprintProgression.ClassWithLevel {
                        m_Class = IsekaiProtagonistClass.GetReference(),
                        AdditionalLevel = 0
                    }

                };
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
            LegacySelection.RegisterForFeat(prog);
            LegacySelection.Register(prog);
            EdgeLordLegacySelection.Prohibit(prog);
            GodEmperorLegacySelection.Register(prog);
            HeroLegacySelection.Register(prog);
            MastermindLegacySelection.Register(prog);
            OverlordLegacySelection.Register(prog);

        }
        public static void PatchProgression() {
            BlueprintCharacterClassReference refClass = ClassTools.Classes.SorcererClass.ToReference<BlueprintCharacterClassReference>();
            BlueprintCharacterClassReference myClass = IsekaiProtagonistClass.GetReference();

            prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = BloodragerChimeraLegacy.Get().ToReference<BlueprintFeatureReference>(); });

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
                    FeatTools.Selections.SorcererBonusFeat.ToReference<BlueprintFeatureReference>(),
                    FeatTools.Selections.SorcererFeatSelection.ToReference<BlueprintFeatureReference>()
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
