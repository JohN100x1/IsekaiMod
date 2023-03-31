using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Mastermind;
using IsekaiMod.Content.Features.IsekaiProtagonist.InheritedClassFeature;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Localization;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Classes.IsekaiProtagonist.Archetypes {

    internal class MastermindArchetype {
        private static readonly LocalizedString Name = Helpers.CreateString(IsekaiContext, $"MastermindArchetype.Name", "Mastermind");
        private static readonly LocalizedString Description = Helpers.CreateString(IsekaiContext, $"MastermindArchetype.Description",
            "..." // TODO: put description here
            + "\nYou cast spells like an Arcanist with a number of slots equal to your spells per day.");

        public static void Add() {
            // Archetype features
            var MastermindSpellbook = BlueprintTools.GetModBlueprint<BlueprintSpellbook>(IsekaiContext, "MastermindSpellbook");
            var MastermindProficiencies = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "MastermindProficiencies");
            var DarkAuraFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "DarkAuraFeature");
            var SignatureAbility = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "SignatureAbility");
            var OverpoweredAbilitySelectionMastermind = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "OverpoweredAbilitySelectionMastermind");
            var MastermindQuickFooted = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "MastermindQuickFooted");

            // Removed features
            var IsekaiProtagonistBonusFeatSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "IsekaiProtagonistBonusFeatSelection");
            var IsekaiProtagonistProficiencies = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiProtagonistProficiencies");
            var SignatureMoveSelection = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "SignatureMoveSelection");
            var ReleaseEnergy = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "ReleaseEnergy");
            var Gifted = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "Gifted");
            var IsekaiFighterTraining = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiFighterTraining");
            var IsekaiAuraSelection = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiAuraSelection");
            var IsekaiQuickFooted = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiQuickFooted");
            var SecondReincarnation = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "SecondReincarnation");
            var OverpoweredAbilitySelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "OverpoweredAbilitySelection");
            var SpecialPowerSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "SpecialPowerSelection");

            // Archetype
            var MastermindArchetype = Helpers.CreateBlueprint<BlueprintArchetype>(IsekaiContext, "MastermindArchetype", bp => {
                bp.LocalizedName = Name;
                bp.LocalizedDescription = Description;
                bp.LocalizedDescriptionShort = Description;
                bp.IsArcaneCaster = true;
                bp.IsDivineCaster = true;
                bp.ChangeCasterType = true;
                bp.RemoveFeatures = new LevelEntry[] {
                    Helpers.CreateLevelEntry(1, IsekaiProtagonistBonusFeatSelection, IsekaiProtagonistProficiencies, Gifted, LegacySelection.GetClassFeature()),
                    Helpers.CreateLevelEntry(2, IsekaiProtagonistBonusFeatSelection),
                    Helpers.CreateLevelEntry(3, IsekaiFighterTraining, ReleaseEnergy),
                    Helpers.CreateLevelEntry(4, IsekaiProtagonistBonusFeatSelection),
                    Helpers.CreateLevelEntry(6, IsekaiProtagonistBonusFeatSelection, SignatureMoveSelection),
                    Helpers.CreateLevelEntry(8, IsekaiProtagonistBonusFeatSelection),
                    Helpers.CreateLevelEntry(10, IsekaiProtagonistBonusFeatSelection, OverpoweredAbilitySelection, IsekaiAuraSelection),
                    Helpers.CreateLevelEntry(12, IsekaiProtagonistBonusFeatSelection),
                    Helpers.CreateLevelEntry(14, IsekaiProtagonistBonusFeatSelection),
                    Helpers.CreateLevelEntry(15, IsekaiQuickFooted),
                    Helpers.CreateLevelEntry(16, IsekaiProtagonistBonusFeatSelection),
                    Helpers.CreateLevelEntry(18, IsekaiProtagonistBonusFeatSelection),
                    Helpers.CreateLevelEntry(20, IsekaiProtagonistBonusFeatSelection, SecondReincarnation),
                };
                bp.AddFeatures = new LevelEntry[] {
                    Helpers.CreateLevelEntry(1, MastermindProficiencies, OverpoweredAbilitySelectionMastermind, MastermindLegacySelection.getClassFeature()),
                    Helpers.CreateLevelEntry(5, OverpoweredAbilitySelectionMastermind),
                    Helpers.CreateLevelEntry(6, SignatureAbility),
                    Helpers.CreateLevelEntry(9, OverpoweredAbilitySelectionMastermind),
                    Helpers.CreateLevelEntry(10, DarkAuraFeature),
                    Helpers.CreateLevelEntry(13, OverpoweredAbilitySelectionMastermind),
                    Helpers.CreateLevelEntry(15, MastermindQuickFooted),
                    Helpers.CreateLevelEntry(17, OverpoweredAbilitySelectionMastermind),
                };
                bp.OverrideAttributeRecommendations = true;
                bp.m_ReplaceSpellbook = MastermindSpellbook.ToReference<BlueprintSpellbookReference>();
                bp.RecommendedAttributes = new StatType[] { StatType.Intelligence };
            });

            // Add Archetype to Class
            IsekaiProtagonistClass.RegisterArchetype(MastermindArchetype);
        }

        public static BlueprintArchetype Get() {
            return BlueprintTools.GetModBlueprint<BlueprintArchetype>(IsekaiContext, "MastermindArchetype");
        }

        public static BlueprintArchetypeReference GetReference() {
            return Get().ToReference<BlueprintArchetypeReference>();
        }
    }
}