﻿using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Root;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Localization;
using Kingmaker.ResourceLinks;
using Kingmaker.RuleSystem;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Classes.Deathsnatcher {

    internal class DeathsnatcherClass {
        private static readonly LocalizedString Name = Helpers.CreateString(IsekaiContext, "DeathsnatcherClass.Name", "Deathsnatcher");
        private static readonly LocalizedString Description = Helpers.CreateString(IsekaiContext, $"DeathsnatcherClass.Description",
            "This bipedal jackal has vulture wings and a rat tail ending in a scorpion’s stinger. Each of its four arms ends in a clawed hand.");

        // Creature Type
        private static readonly BlueprintFeature MonstrousHumanoidType = BlueprintTools.GetBlueprint<BlueprintFeature>("57614b50e8d86b24395931fffc5e409b");

        // Stat Progression
        private static readonly BlueprintStatProgression BABFull = BlueprintTools.GetBlueprint<BlueprintStatProgression>("b3057560ffff3514299e8b93e7648a9d");
        private static readonly BlueprintStatProgression SavesHigh = BlueprintTools.GetBlueprint<BlueprintStatProgression>("ff4662bde9e75f145853417313842751");
        private static readonly BlueprintStatProgression SavesLow = BlueprintTools.GetBlueprint<BlueprintStatProgression>("dc0c7c1aba755c54f96c089cdf7d14a3");

        public static void Add() {
            // Add Deathsnatcher Class
            var DeathsnatcherClass = Helpers.CreateBlueprint<BlueprintCharacterClass>(IsekaiContext, "DeathsnatcherClass", bp => {
                bp.LocalizedName = Name;
                bp.LocalizedDescription = Description;
                bp.LocalizedDescriptionShort = Description;
                bp.HitDie = DiceType.D10;
                bp.m_BaseAttackBonus = BABFull.ToReference<BlueprintStatProgressionReference>();
                bp.m_FortitudeSave = SavesLow.ToReference<BlueprintStatProgressionReference>();
                bp.m_ReflexSave = SavesHigh.ToReference<BlueprintStatProgressionReference>();
                bp.m_WillSave = SavesHigh.ToReference<BlueprintStatProgressionReference>();
                bp.m_Difficulty = 1;
                bp.HideIfRestricted = true;
                bp.m_Archetypes = new BlueprintArchetypeReference[0];
                bp.RecommendedAttributes = new StatType[0];
                bp.NotRecommendedAttributes = new StatType[0];
                bp.m_EquipmentEntities = new KingmakerEquipmentEntityReference[0];
                bp.m_StartingItems = new BlueprintItemReference[0];
                bp.SkillPoints = 2;
                bp.ClassSkills = new StatType[4] {
                    StatType.SkillAthletics,
                    StatType.SkillMobility,
                    StatType.SkillLoreNature,
                    StatType.SkillPersuasion
                };
                bp.IsDivineCaster = false;
                bp.IsArcaneCaster = false;
                bp.StartingGold = 0;
                bp.PrimaryColor = 0;
                bp.SecondaryColor = 0;
                bp.MaleEquipmentEntities = new EquipmentEntityLink[0];
                bp.FemaleEquipmentEntities = new EquipmentEntityLink[0];
                bp.m_SignatureAbilities = new BlueprintFeatureReference[0];
                bp.AddComponent<PrerequisiteIsPet>(c => {
                    c.Group = Prerequisite.GroupType.Any;
                });
                bp.AddComponent<PrerequisiteFeature>(c => {
                    c.HideInUI = true;
                    c.m_Feature = MonstrousHumanoidType.ToReference<BlueprintFeatureReference>();
                });
                bp.m_Archetypes = new BlueprintArchetypeReference[0];

                // Set Progression later using SetProgression
                bp.m_Progression = null;
                bp.m_DefaultBuild = null;
            });

            // Patch Animal Companion Class
            var AnimalCompanionClass = BlueprintTools.GetBlueprint<BlueprintCharacterClass>("26b10d4340839004f960f9816f6109fe");
            AnimalCompanionClass.AddComponent<PrerequisiteNoFeature>(c => {
                c.HideInUI = true;
                c.m_Feature = MonstrousHumanoidType.ToReference<BlueprintFeatureReference>();
            });
            var BlueprintRoot = BlueprintTools.GetBlueprint<BlueprintRoot>("2d77316c72b9ed44f888ceefc2a131f6");
            BlueprintRoot.Instance.Progression.m_PetClasses = BlueprintRoot.Instance.Progression.m_PetClasses.AppendToArray(DeathsnatcherClass.ToReference<BlueprintCharacterClassReference>());
        }

        public static void SetProgression(BlueprintProgression progression) {
            BlueprintCharacterClass DeathsnatcherClass = Get();
            DeathsnatcherClass.m_Progression = progression.ToReference<BlueprintProgressionReference>();
        }

        public static BlueprintCharacterClass Get() {
            return BlueprintTools.GetModBlueprint<BlueprintCharacterClass>(IsekaiContext, "DeathsnatcherClass");
        }

        public static BlueprintCharacterClassReference GetReference() {
            return Get().ToReference<BlueprintCharacterClassReference>();
        }
    }
}