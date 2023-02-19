using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Hero;
using IsekaiMod.Content.Features.IsekaiProtagonist.InheritedClassFeature;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.UnitLogic.Alignments;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Classes.IsekaiProtagonist.Archetypes {

    internal class Hero {

        public static void Add() {
            // Archetype features
            var HeroProficiencies = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "HeroProficiencies");
            var GracefulCombat = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "GracefulCombat");
            var HerosPresenceFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "HerosPresenceFeature");
            var IsekaiChannelPositiveEnergyFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiChannelPositiveEnergyFeature");
            var AuraOfDivineFuryFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "AuraOfDivineFuryFeature");
            var CelestialRealmFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "CelestialRealmFeature");

            // Removed features
            var IsekaiProtagonistProficiencies = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiProtagonistProficiencies");
            var OverpoweredAbilitySelection2 = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "OverpoweredAbilitySelection2");
            var SpecialPowerSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "SpecialPowerSelection");
            var SecondReincarnation = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "SecondReincarnation");

            // Archetype
            var HeroArchetype = Helpers.CreateBlueprint<BlueprintArchetype>(IsekaiContext, "HeroArchetype", bp => {
                bp.LocalizedName = Helpers.CreateString(IsekaiContext, $"HeroArchetype.Name", "Hero");
                bp.LocalizedDescription = Helpers.CreateString(IsekaiContext, $"HeroArchetype.Description", "Heroes use their newfound powers for good. After realising the suffering and "
                    + "despair of the inhabitants of the new world, the hero sets out to bring knowledge from their old world in order to save them.");
                bp.LocalizedDescriptionShort = Helpers.CreateString(IsekaiContext, $"HeroArchetype.DescriptionShort", "Heroes use their newfound powers for good. After realising the suffering and "
                    + "despair of the inhabitants of the new world, the hero sets out to bring knowledge from their old world in order to save them.");
                bp.IsArcaneCaster = true;
                bp.IsDivineCaster = true;
                bp.RemoveFeatures = new LevelEntry[] {
                    Helpers.CreateLevelEntry(1, IsekaiProtagonistProficiencies, LegacySelection.GetClassFeature()),
                    Helpers.CreateLevelEntry(3, SpecialPowerSelection),
                    Helpers.CreateLevelEntry(10, OverpoweredAbilitySelection2),
                    Helpers.CreateLevelEntry(17,  SpecialPowerSelection),
                    Helpers.CreateLevelEntry(20, SecondReincarnation),
                };
                bp.AddFeatures = new LevelEntry[] {
                    Helpers.CreateLevelEntry(1, HeroProficiencies, GracefulCombat, HeroLegacySelection.getClassFeature()),
                    Helpers.CreateLevelEntry(3, IsekaiChannelPositiveEnergyFeature),
                    Helpers.CreateLevelEntry(10, AuraOfDivineFuryFeature),

                    Helpers.CreateLevelEntry(17, CelestialRealmFeature),
                    Helpers.CreateLevelEntry(20, HerosPresenceFeature),
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
    }
}