using IsekaiMod.Content.Classes.IsekaiProtagonist.Archetypes.Overlord;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Overlord;
using IsekaiMod.Content.Features.IsekaiProtagonist.InheritedClassFeature;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
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
            var OverlordProficiencies = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "OverlordProficiencies");
            var DarkAuraFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "DarkAuraFeature");
            var OverpoweredAbilitySelectionOverlord = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "OverpoweredAbilitySelectionOverlord");
            var CorruptAuraFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "CorruptAuraFeature");
            var SecondFormFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "SecondFormFeature");
            var IsekaiChannelNegativeEnergyFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiChannelNegativeEnergyFeature");

            // Removed features
            var IsekaiProtagonistBonusFeatSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "IsekaiProtagonistBonusFeatSelection");
            var IsekaiProtagonistProficiencies = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiProtagonistProficiencies");
            var IsekaiAuraSelection = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiAuraSelection");
            var ReleaseEnergy = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "ReleaseEnergy");
            var Gifted = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "Gifted");
            var SecretPower = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "SecretPower");
            var SignatureMoveSelectionBonus = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "SignatureMoveSelectionBonus");
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
                    Helpers.CreateLevelEntry(1, IsekaiProtagonistBonusFeatSelection, IsekaiProtagonistProficiencies, Gifted, LegacySelection.GetClassFeature()),
                    Helpers.CreateLevelEntry(2, IsekaiProtagonistBonusFeatSelection),
                    Helpers.CreateLevelEntry(3, ReleaseEnergy),
                    Helpers.CreateLevelEntry(4, IsekaiProtagonistBonusFeatSelection),
                    Helpers.CreateLevelEntry(6, IsekaiProtagonistBonusFeatSelection, SignatureMoveSelectionBonus),
                    Helpers.CreateLevelEntry(8, IsekaiProtagonistBonusFeatSelection),
                    Helpers.CreateLevelEntry(10, IsekaiProtagonistBonusFeatSelection, OverpoweredAbilitySelection, IsekaiAuraSelection, SecretPower),
                    Helpers.CreateLevelEntry(12, IsekaiProtagonistBonusFeatSelection),
                    Helpers.CreateLevelEntry(14, IsekaiProtagonistBonusFeatSelection),
                    Helpers.CreateLevelEntry(16, IsekaiProtagonistBonusFeatSelection),
                    Helpers.CreateLevelEntry(18, IsekaiProtagonistBonusFeatSelection),
                    Helpers.CreateLevelEntry(20, IsekaiProtagonistBonusFeatSelection, SecondReincarnation),
                };
                bp.AddFeatures = new LevelEntry[] {
                    Helpers.CreateLevelEntry(1, OverlordProficiencies, OverpoweredAbilitySelectionOverlord, OverlordLegacySelection.getClassFeature()),
                    Helpers.CreateLevelEntry(3, IsekaiChannelNegativeEnergyFeature),
                    Helpers.CreateLevelEntry(5, OverpoweredAbilitySelectionOverlord),
                    Helpers.CreateLevelEntry(9, OverpoweredAbilitySelectionOverlord),
                    Helpers.CreateLevelEntry(10, CorruptAuraFeature, DarkAuraFeature),
                    Helpers.CreateLevelEntry(13, OverpoweredAbilitySelectionOverlord),
                    Helpers.CreateLevelEntry(17, OverpoweredAbilitySelectionOverlord),
                    Helpers.CreateLevelEntry(20, SecondFormFeature),
                };
                bp.AddComponent<PrerequisiteAlignment>(c => {
                    c.Group = Prerequisite.GroupType.Any;
                    c.Alignment = AlignmentMaskType.Evil;
                });
                bp.m_ReplaceSpellbook = OverlordSpellbook.GetReference();
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