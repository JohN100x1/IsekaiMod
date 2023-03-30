using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.GodEmperor;
using IsekaiMod.Content.Features.IsekaiProtagonist.InheritedClassFeature;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Localization;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Classes.IsekaiProtagonist.Archetypes {

    internal class GodEmperorArchetype {
        private static readonly LocalizedString Name = Helpers.CreateString(IsekaiContext, $"GodEmperorArchetype.Name", "God Emperor");
        private static readonly LocalizedString Description = Helpers.CreateString(IsekaiContext, $"GodEmperorArchetype.Description",
            "Rather than wandering aimlessly, collecting harems, or defeating demon lords, some protagonists decide to become gods. "
            + "They sacrifice their special powers to gain powerful auras and a journey towards godhood.");

        public static void Add() {
            // Archetype features
            var GodEmperorProficiencies = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "GodEmperorProficiencies");
            var NascentApotheosis = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "NascentApotheosis");
            var DivineArray = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "DivineArray");
            var GodEmperorEnergySelection = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "GodEmperorEnergySelection");
            var AuraOfGoldenProtectionFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "AuraOfGoldenProtectionFeature");
            var DarkAuraFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "DarkAuraFeature");
            var AuraOfMajestyFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "AuraOfMajestyFeature");
            var CelestialRealmFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "CelestialRealmFeature");
            var Godhood = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "Godhood");
            var GodlyVessel = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "GodlyVessel");
            var SiphoningAuraFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "SiphoningAuraFeature");
            var OverpoweredAbilitySelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "OverpoweredAbilitySelection");
            var ArmorSaint = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "ArmorSaint");
            var AuraOfDivineFuryFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "AuraOfDivineFuryFeature");

            // Removed features
            var IsekaiProtagonistProficiencies = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiProtagonistProficiencies");
            var IsekaiAuraSelection = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiAuraSelection");
            var OtherworldlyStamina = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "OtherworldlyStamina");
            var SecondReincarnation = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "SecondReincarnation");

            var BeachEpisodeSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "BeachEpisodeSelection");
            var SpecialPowerSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "SpecialPowerSelection");

            // Archetype
            var GodEmperorArchetype = Helpers.CreateBlueprint<BlueprintArchetype>(IsekaiContext, "GodEmperorArchetype", bp => {
                bp.LocalizedName = Name;
                bp.LocalizedDescription = Description;
                bp.LocalizedDescriptionShort = Description;
                bp.IsArcaneCaster = true;
                bp.IsDivineCaster = true;
                bp.RemoveFeatures = new LevelEntry[] {
                    Helpers.CreateLevelEntry(1, IsekaiProtagonistProficiencies, LegacySelection.GetClassFeature()),
                    Helpers.CreateLevelEntry(3, SpecialPowerSelection),
                    Helpers.CreateLevelEntry(7, SpecialPowerSelection),
                    Helpers.CreateLevelEntry(9, SpecialPowerSelection),
                    Helpers.CreateLevelEntry(10, IsekaiAuraSelection),
                    Helpers.CreateLevelEntry(11, SpecialPowerSelection),
                    Helpers.CreateLevelEntry(12, BeachEpisodeSelection),
                    Helpers.CreateLevelEntry(13, SpecialPowerSelection, OtherworldlyStamina),
                    Helpers.CreateLevelEntry(17, SpecialPowerSelection),
                    Helpers.CreateLevelEntry(19, SpecialPowerSelection),
                    Helpers.CreateLevelEntry(20, SecondReincarnation),
                };
                bp.AddFeatures = new LevelEntry[] {
                    Helpers.CreateLevelEntry(1, NascentApotheosis, GodEmperorProficiencies, GodEmperorLegacySelection.getClassFeature()),
                    Helpers.CreateLevelEntry(3, DivineArray),
                    Helpers.CreateLevelEntry(4, ArmorSaint),
                    Helpers.CreateLevelEntry(5, GodEmperorEnergySelection),
                    Helpers.CreateLevelEntry(7, AuraOfGoldenProtectionFeature),
                    Helpers.CreateLevelEntry(9, AuraOfMajestyFeature),
                    Helpers.CreateLevelEntry(10, DarkAuraFeature),
                    Helpers.CreateLevelEntry(12, SiphoningAuraFeature),
                    Helpers.CreateLevelEntry(14, AuraOfDivineFuryFeature),
                    Helpers.CreateLevelEntry(15, GodlyVessel),
                    Helpers.CreateLevelEntry(17, CelestialRealmFeature),
                    Helpers.CreateLevelEntry(20, Godhood),
                };
            });

            // Add Archetype to Class
            IsekaiProtagonistClass.RegisterArchetype(GodEmperorArchetype);
        }
        public static BlueprintArchetype Get() {
            return BlueprintTools.GetModBlueprint<BlueprintArchetype>(IsekaiContext, "GodEmperorArchetype");
        }

        public static BlueprintArchetypeReference GetReference() {
            return Get().ToReference<BlueprintArchetypeReference>();
        }
    }
}