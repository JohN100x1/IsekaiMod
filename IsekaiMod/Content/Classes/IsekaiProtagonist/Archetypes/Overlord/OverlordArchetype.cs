using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Overlord;
using IsekaiMod.Content.Features.IsekaiProtagonist.InheritedClassFeature;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Localization;
using Kingmaker.UnitLogic.Alignments;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Classes.IsekaiProtagonist.Archetypes {

    internal class OverlordArchetype {
        private static readonly LocalizedString Name = Helpers.CreateString(IsekaiContext, $"OverlordArchetype.Name", "Overlord");
        private static readonly LocalizedString Description = Helpers.CreateString(IsekaiContext, $"OverlordArchetype.Description",
            "After obtaining ungodly amounts of power, some protagonists become Overlords. They view the new world as theirs to play with, "
            + "and the new inhabitants as theirs to torment. Overlords seek to increase their power even further, often by establishing their own kingdom.");

        public static void Add() {
            // Archetype features
            var OverlordSpellbook = BlueprintTools.GetModBlueprint<BlueprintSpellbook>(IsekaiContext, "OverlordSpellbook");
            var OverlordProficiencies = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "OverlordProficiencies");
            var DarkAuraFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "DarkAuraFeature");
            var SlayerStudyTargetFeature = BlueprintTools.GetBlueprint<BlueprintFeature>("09bdd9445ac38044389476689ae8d5a1");
            var SlayerSwiftStudyTargetFeature = BlueprintTools.GetBlueprint<BlueprintFeature>("40d4f55a5ac0e4f469d67d36c0dfc40b");
            var OverpoweredAbilitySelectionOverlord = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "OverpoweredAbilitySelectionOverlord");
            var CorruptAuraFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "CorruptAuraFeature");
            var OverlordQuickFooted = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "OverlordQuickFooted");
            var SecondFormFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "SecondFormFeature");
            var IsekaiChannelNegativeEnergyFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiChannelNegativeEnergyFeature");

            // Removed features
            var IsekaiProtagonistBonusFeatSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "IsekaiProtagonistBonusFeatSelection");
            var IsekaiProtagonistProficiencies = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiProtagonistProficiencies");
            var FriendlyAuraFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "FriendlyAuraFeature");
            var IsekaiQuickFooted = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiQuickFooted");
            var SecondReincarnation = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "SecondReincarnation");
            var OverpoweredAbilitySelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "OverpoweredAbilitySelection");
            var SpecialPowerSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "SpecialPowerSelection");

            // Archetype
            var OverlordArchetype = Helpers.CreateBlueprint<BlueprintArchetype>(IsekaiContext, "OverlordArchetype", bp => {
                bp.LocalizedName = Name;
                bp.LocalizedDescription = Description;
                bp.LocalizedDescriptionShort = Description;
                bp.IsArcaneCaster = true;
                bp.IsDivineCaster = true;
                bp.ChangeCasterType = true;
                bp.RemoveFeatures = new LevelEntry[] {
                    Helpers.CreateLevelEntry(1, IsekaiProtagonistBonusFeatSelection, IsekaiProtagonistProficiencies, LegacySelection.GetClassFeature()),
                    Helpers.CreateLevelEntry(2, IsekaiProtagonistBonusFeatSelection),
                    Helpers.CreateLevelEntry(3, SpecialPowerSelection),
                    Helpers.CreateLevelEntry(4, IsekaiProtagonistBonusFeatSelection),
                    Helpers.CreateLevelEntry(6, IsekaiProtagonistBonusFeatSelection),
                    Helpers.CreateLevelEntry(8, IsekaiProtagonistBonusFeatSelection),
                    Helpers.CreateLevelEntry(10, IsekaiProtagonistBonusFeatSelection, OverpoweredAbilitySelection, FriendlyAuraFeature),
                    Helpers.CreateLevelEntry(12, IsekaiProtagonistBonusFeatSelection),
                    Helpers.CreateLevelEntry(14, IsekaiProtagonistBonusFeatSelection),
                    Helpers.CreateLevelEntry(16, IsekaiQuickFooted),
                    Helpers.CreateLevelEntry(16, IsekaiProtagonistBonusFeatSelection),
                    Helpers.CreateLevelEntry(18, IsekaiProtagonistBonusFeatSelection),
                    Helpers.CreateLevelEntry(20, IsekaiProtagonistBonusFeatSelection, SecondReincarnation),
                };
                bp.AddFeatures = new LevelEntry[] {
                    Helpers.CreateLevelEntry(1, OverlordProficiencies, OverpoweredAbilitySelectionOverlord, SlayerStudyTargetFeature, OverlordLegacySelection.getClassFeature()),
                    Helpers.CreateLevelEntry(3, IsekaiChannelNegativeEnergyFeature),
                    Helpers.CreateLevelEntry(5, SlayerStudyTargetFeature, OverpoweredAbilitySelectionOverlord),
                    Helpers.CreateLevelEntry(7, SlayerSwiftStudyTargetFeature),
                    Helpers.CreateLevelEntry(9, OverpoweredAbilitySelectionOverlord),
                    Helpers.CreateLevelEntry(10, CorruptAuraFeature, SlayerStudyTargetFeature, DarkAuraFeature),
                    Helpers.CreateLevelEntry(13, OverpoweredAbilitySelectionOverlord),
                    Helpers.CreateLevelEntry(15, SlayerStudyTargetFeature),
                    Helpers.CreateLevelEntry(16, OverlordQuickFooted),
                    Helpers.CreateLevelEntry(17, OverpoweredAbilitySelectionOverlord),
                    Helpers.CreateLevelEntry(20, SlayerStudyTargetFeature, SecondFormFeature),
                };
                bp.OverrideAttributeRecommendations = true;
                bp.AddComponent<PrerequisiteAlignment>(c => {
                    c.Group = Prerequisite.GroupType.Any;
                    c.Alignment = AlignmentMaskType.Evil;
                });
                bp.m_ReplaceSpellbook = OverlordSpellbook.ToReference<BlueprintSpellbookReference>();
                bp.RecommendedAttributes = new StatType[] { StatType.Intelligence, StatType.Strength };
            });

            // Add Archetype to Class
            IsekaiProtagonistClass.RegisterArchetype(OverlordArchetype);
        }

        public static BlueprintArchetype Get() {
            return BlueprintTools.GetModBlueprint<BlueprintArchetype>(IsekaiContext, "OverlordArchetype");
        }

        public static BlueprintArchetypeReference GetReference() {
            return Get().ToReference<BlueprintArchetypeReference>();
        }
    }
}