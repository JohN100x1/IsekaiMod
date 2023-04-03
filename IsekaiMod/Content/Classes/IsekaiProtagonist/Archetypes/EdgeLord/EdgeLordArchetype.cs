using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.EdgeLord;
using IsekaiMod.Content.Features.IsekaiProtagonist.InheritedClassFeature;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Localization;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Classes.IsekaiProtagonist.Archetypes {

    internal class EdgeLordArchetype {
        private static readonly LocalizedString Name = Helpers.CreateString(IsekaiContext, $"EdgeLordArchetype.Name", "Edge Lord");
        private static readonly LocalizedString Description = Helpers.CreateString(IsekaiContext, $"EdgeLordArchetype.Description",
            "After reincarnating into Golarion, some protagonists use their newfound abilities to look cool and stylish. "
            + "Their attacks become flashy and myriad, moving so fast that side characters would be lucky to even see the Afterimage.");

        public static void Add() {
            // Archetype features
            var EdgeLordProficiencies = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "EdgeLordProficiencies");
            var SupersonicCombat = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "SupersonicCombat");
            var ExtraStrike = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "ExtraStrike");
            var ChuunibyouPowerFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "ChuunibyouPowerFeature");

            // Removed features
            var IsekaiProtagonistProficiencies = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiProtagonistProficiencies");
            var ReleaseEnergy = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "ReleaseEnergy");
            var Gifted = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "Gifted");
            var SecretPowerSelection = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "SecretPowerSelection");
            var SignatureMoveSelectionBonus = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "SignatureMoveSelectionBonus");
            var IsekaiAuraSelection = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiAuraSelection");
            var SecondReincarnation = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "SecondReincarnation");
            var HaxSelection = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "HaxSelection");
            var OverpoweredAbilitySelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "OverpoweredAbilitySelection");
            var SpecialPowerSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "SpecialPowerSelection");

            // Archetype
            var EdgeLordArchetype = Helpers.CreateBlueprint<BlueprintArchetype>(IsekaiContext, "EdgeLordArchetype", bp => {
                bp.LocalizedName = Name;
                bp.LocalizedDescription = Description;
                bp.LocalizedDescriptionShort = Description;
                bp.IsArcaneCaster = true;
                bp.IsDivineCaster = true;
                bp.RemoveFeatures = new LevelEntry[] {
                    Helpers.CreateLevelEntry(1, IsekaiProtagonistProficiencies, Gifted, LegacySelection.GetClassFeature()),
                    Helpers.CreateLevelEntry(3, ReleaseEnergy),
                    Helpers.CreateLevelEntry(5, OverpoweredAbilitySelection),
                    Helpers.CreateLevelEntry(6, SignatureMoveSelectionBonus),
                    Helpers.CreateLevelEntry(10, IsekaiAuraSelection, SecretPowerSelection),
                    Helpers.CreateLevelEntry(15, OverpoweredAbilitySelection, SecondReincarnation),
                    Helpers.CreateLevelEntry(20, HaxSelection),
                };
                bp.AddFeatures = new LevelEntry[] {
                    Helpers.CreateLevelEntry(1, EdgeLordProficiencies, SupersonicCombat, EdgeLordLegacySelection.getClassFeature()),
                    Helpers.CreateLevelEntry(5, SpecialPowerSelection, ExtraStrike),
                    Helpers.CreateLevelEntry(10, ExtraStrike),
                    Helpers.CreateLevelEntry(15, SpecialPowerSelection, ExtraStrike),
                    Helpers.CreateLevelEntry(20, ExtraStrike, ChuunibyouPowerFeature),
                };
                bp.OverrideAttributeRecommendations = true;
                bp.RecommendedAttributes = new StatType[] { StatType.Dexterity, StatType.Charisma };
            });

            // Add Archetype to Class
            IsekaiProtagonistClass.RegisterArchetype(EdgeLordArchetype);
        }

        public static BlueprintArchetype Get() {
            return BlueprintTools.GetModBlueprint<BlueprintArchetype>(IsekaiContext, "EdgeLordArchetype");
        }

        public static BlueprintArchetypeReference GetReference() {
            return Get().ToReference<BlueprintArchetypeReference>();
        }
    }
}