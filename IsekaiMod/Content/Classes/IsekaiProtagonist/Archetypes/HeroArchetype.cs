using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Hero;
using IsekaiMod.Content.Features.IsekaiProtagonist.InheritedClassFeature;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Localization;
using Kingmaker.UnitLogic.Alignments;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Classes.IsekaiProtagonist.Archetypes {

    internal class HeroArchetype {
        private static readonly LocalizedString Name = Helpers.CreateString(IsekaiContext, $"HeroArchetype.Name", "Hero");
        private static readonly LocalizedString Description = Helpers.CreateString(IsekaiContext, $"HeroArchetype.Description",
            "Heroes use their newfound powers for good. After realising the suffering and despair of the inhabitants of the new world, "
            + "the hero sets out to bring knowledge from their old world in order to save them.");

        public static void Add() {
            // Archetype features
            var HeroProficiencies = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "HeroProficiencies");
            var GracefulCombat = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "GracefulCombat");
            var IsekaiChannelPositiveEnergyFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiChannelPositiveEnergyFeature");
            var HandsOfSalvation = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "HandsOfSalvation");
            var GoldBarrierFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "GoldBarrierFeature");
            var GoldBarrierHeroism = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "GoldBarrierHeroism");
            var GoldBarrierFastHealing = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "GoldBarrierFastHealing");
            var GoldBarrierResistance = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "GoldBarrierResistance");
            var DeusExMachinaFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "DeusExMachinaFeature");

            var HeroAuraSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "HeroAuraSelection");

            // Removed features
            var IsekaiProficiencies = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiProficiencies");
            var ReleaseEnergy = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "ReleaseEnergy");
            var Gifted = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "Gifted");
            var SecondReincarnation = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "SecondReincarnation");

            var IsekaiAuraSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "IsekaiAuraSelection");
            var SecretPowerSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "SecretPowerSelection");
            var SignatureMoveBonusSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "SignatureMoveBonusSelection");
            var BeachEpisodeBonusSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "BeachEpisodeBonusSelection");
            var SpecialPowerSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "SpecialPowerSelection");
            var HaxSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "HaxSelection");

            // Archetype
            var HeroArchetype = Helpers.CreateBlueprint<BlueprintArchetype>(IsekaiContext, "HeroArchetype", bp => {
                bp.LocalizedName = Name;
                bp.LocalizedDescription = Description;
                bp.LocalizedDescriptionShort = Description;
                bp.IsArcaneCaster = true;
                bp.IsDivineCaster = true;
                bp.RemoveFeatures = new LevelEntry[] {
                    Helpers.CreateLevelEntry(1, IsekaiProficiencies, Gifted, LegacySelection.GetClassFeature()),
                    Helpers.CreateLevelEntry(3, ReleaseEnergy),
                    Helpers.CreateLevelEntry(6, SignatureMoveBonusSelection),
                    Helpers.CreateLevelEntry(9, SpecialPowerSelection),
                    Helpers.CreateLevelEntry(10, IsekaiAuraSelection, SecretPowerSelection),
                    Helpers.CreateLevelEntry(11, SpecialPowerSelection),
                    Helpers.CreateLevelEntry(12, BeachEpisodeBonusSelection),
                    Helpers.CreateLevelEntry(15, SecondReincarnation),
                    Helpers.CreateLevelEntry(20, HaxSelection),
                };
                bp.AddFeatures = new LevelEntry[] {
                    Helpers.CreateLevelEntry(1, HeroProficiencies, GracefulCombat, HeroLegacySelection.getClassFeature()),
                    Helpers.CreateLevelEntry(3, IsekaiChannelPositiveEnergyFeature),
                    Helpers.CreateLevelEntry(4, HandsOfSalvation),
                    Helpers.CreateLevelEntry(7, GoldBarrierFeature),
                    Helpers.CreateLevelEntry(10, HeroAuraSelection, GoldBarrierHeroism),
                    Helpers.CreateLevelEntry(12, GoldBarrierFastHealing),
                    Helpers.CreateLevelEntry(15, GoldBarrierResistance),
                    Helpers.CreateLevelEntry(20, DeusExMachinaFeature),
                };
                bp.AddComponent<PrerequisiteAlignment>(c => {
                    c.Group = Prerequisite.GroupType.Any;
                    c.Alignment = AlignmentMaskType.Good;
                });
                bp.OverrideAttributeRecommendations = true;
                bp.RecommendedAttributes = new StatType[] { StatType.Charisma };
            });

            // Add Archetype to Class
            IsekaiProtagonistClass.RegisterArchetype(HeroArchetype);
        }

        public static BlueprintArchetype Get() {
            return BlueprintTools.GetModBlueprint<BlueprintArchetype>(IsekaiContext, "HeroArchetype");
        }

        public static BlueprintArchetypeReference GetReference() {
            return Get().ToReference<BlueprintArchetypeReference>();
        }
    }
}