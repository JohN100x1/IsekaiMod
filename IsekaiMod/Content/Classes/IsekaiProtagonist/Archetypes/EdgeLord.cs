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

    internal class EdgeLord {
        private static readonly LocalizedString Name = Helpers.CreateString(IsekaiContext, $"EdgeLordArchetype.Name", "Edge Lord");
        private static readonly LocalizedString Description = Helpers.CreateString(IsekaiContext, $"EdgeLordArchetype.Description",
            "After reincarnating into Golarion, some protagonists use their newfound abilities to look cool and stylish. "
            + "Their attacks become flashy and myriad, moving so fast that side characters would be lucky to even see the afterimage.");

        public static void Add() {
            // Archetype features
            var EdgeLordProficiencies = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "EdgeLordProficiencies");
            var SupersonicCombat = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "SupersonicCombat");
            var EdgeLordFastMovement = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "EdgeLordFastMovement");
            var ExtraStrike = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "ExtraStrike");

            // Removed features
            var IsekaiProtagonistProficiencies = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiProtagonistProficiencies");
            var IsekaiFastMovement = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiFastMovement");
            var FriendlyAuraFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "FriendlyAuraFeature");
            var SecondReincarnation = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "SecondReincarnation");
            var OverpoweredAbilitySelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "OverpoweredAbilitySelection");
            var SpecialPowerSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "SpecialPowerSelection");

            // Archetype
            var EdgeLordArchetype = Helpers.CreateBlueprint<BlueprintArchetype>(IsekaiContext, "EdgeLordArchetype", bp => {
                bp.LocalizedName = Name
                bp.LocalizedDescription = Description;
                bp.LocalizedDescriptionShort = Description;
                bp.IsArcaneCaster = true;
                bp.IsDivineCaster = true;
                bp.RemoveFeatures = new LevelEntry[] {
                    Helpers.CreateLevelEntry(1, IsekaiProtagonistProficiencies, LegacySelection.GetClassFeature()),
                    Helpers.CreateLevelEntry(5, OverpoweredAbilitySelection),
                    Helpers.CreateLevelEntry(8, IsekaiFastMovement),
                    Helpers.CreateLevelEntry(10, FriendlyAuraFeature),
                    Helpers.CreateLevelEntry(10, OverpoweredAbilitySelection),
                    Helpers.CreateLevelEntry(15, OverpoweredAbilitySelection),
                    Helpers.CreateLevelEntry(20, SecondReincarnation),
                };
                bp.AddFeatures = new LevelEntry[] {
                    Helpers.CreateLevelEntry(1, EdgeLordProficiencies, SupersonicCombat, EdgeLordLegacySelection.getClassFeature()),
                    Helpers.CreateLevelEntry(5, SpecialPowerSelection, ExtraStrike),
                    Helpers.CreateLevelEntry(8, EdgeLordFastMovement),
                    Helpers.CreateLevelEntry(10, ExtraStrike),
                    Helpers.CreateLevelEntry(15, SpecialPowerSelection, ExtraStrike),
                    Helpers.CreateLevelEntry(20, ExtraStrike),
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