using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.GodEmperor;
using IsekaiMod.Content.Features.IsekaiProtagonist.InheritedClassFeature;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.EntitySystem.Stats;
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
            var LightEnergyCondensation = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "LightEnergyCondensation");
            var GodEmperorQuickFooted = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "GodEmperorQuickFooted");
            var MajesticAuraFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "MajesticAuraFeature");
            var Godhood = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "Godhood");
            var GodlyVessel = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "GodlyVessel");
            var SiphoningAuraFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "SiphoningAuraFeature");
            var ArmorSaint = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "ArmorSaint");

            var GodEmperorEnergySelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "GodEmperorEnergySelection");
            var GodEmperorAuraSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "GodEmperorAuraSelection");
            var EnergyCondensationSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "EnergyCondensationSelection");
            var BarrierSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "BarrierSelection");
            var BodyMindAlterSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "BodyMindAlterSelection");
            var PathSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "PathSelection");
            var RealmSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "RealmSelection");

            // Removed features
            var IsekaiProficiencies = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiProficiencies");
            var IsekaiQuickFooted = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiQuickFooted");
            var ReleaseEnergy = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "ReleaseEnergy");
            var Gifted = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "Gifted");
            var SecondReincarnation = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "SecondReincarnation");

            var HaxSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "HaxSelection");
            var SecretPowerSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "SecretPowerSelection");
            var IsekaiAuraSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "IsekaiAuraSelection");
            var SignatureMoveBonusSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "SignatureMoveBonusSelection");
            var BeachEpisodeSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "BeachEpisodeSelection");
            var BeachEpisodeBonusSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "BeachEpisodeBonusSelection");
            var SpecialPowerSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "SpecialPowerSelection");
            var OverpoweredAbilitySelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "OverpoweredAbilitySelection");

            // Archetype
            var GodEmperorArchetype = Helpers.CreateBlueprint<BlueprintArchetype>(IsekaiContext, "GodEmperorArchetype", bp => {
                bp.LocalizedName = Name;
                bp.LocalizedDescription = Description;
                bp.LocalizedDescriptionShort = Description;
                bp.IsArcaneCaster = true;
                bp.IsDivineCaster = true;
                bp.RemoveFeatures = new LevelEntry[] {
                    Helpers.CreateLevelEntry(1, IsekaiProficiencies, Gifted, LegacySelection.GetClassFeature()),
                    Helpers.CreateLevelEntry(3, SpecialPowerSelection, ReleaseEnergy),
                    Helpers.CreateLevelEntry(6, SignatureMoveBonusSelection),
                    Helpers.CreateLevelEntry(7, SpecialPowerSelection),
                    Helpers.CreateLevelEntry(9, SpecialPowerSelection),
                    Helpers.CreateLevelEntry(10, IsekaiAuraSelection, SecretPowerSelection),
                    Helpers.CreateLevelEntry(11, SpecialPowerSelection),
                    Helpers.CreateLevelEntry(12, BeachEpisodeSelection, BeachEpisodeBonusSelection),
                    Helpers.CreateLevelEntry(13, SpecialPowerSelection),
                    Helpers.CreateLevelEntry(15, IsekaiQuickFooted, SecondReincarnation),
                    Helpers.CreateLevelEntry(17, SpecialPowerSelection),
                    Helpers.CreateLevelEntry(19, SpecialPowerSelection),
                    Helpers.CreateLevelEntry(20, HaxSelection),
                };
                bp.AddFeatures = new LevelEntry[] {
                    Helpers.CreateLevelEntry(1, NascentApotheosis, GodEmperorProficiencies, GodEmperorLegacySelection.getClassFeature()),
                    Helpers.CreateLevelEntry(3, GodEmperorEnergySelection, ArmorSaint),
                    Helpers.CreateLevelEntry(5, EnergyCondensationSelection),
                    Helpers.CreateLevelEntry(7, BarrierSelection),
                    Helpers.CreateLevelEntry(10, GodEmperorAuraSelection, BodyMindAlterSelection),
                    Helpers.CreateLevelEntry(12, PathSelection),
                    Helpers.CreateLevelEntry(15, RealmSelection, GodEmperorQuickFooted),
                    Helpers.CreateLevelEntry(17, GodlyVessel),
                    Helpers.CreateLevelEntry(20, Godhood),
                };
                bp.OverrideAttributeRecommendations = true;
                bp.m_ReplaceSpellbook = GodEmperorSpellbook.GetReference();
                bp.RecommendedAttributes = new StatType[] { StatType.Wisdom };
                bp.RemoveSpellbook = IsekaiContext.AddedContent.DisableSpellbookGodEmperor;
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