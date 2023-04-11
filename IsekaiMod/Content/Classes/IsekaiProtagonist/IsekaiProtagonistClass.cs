using IsekaiMod.Components;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Localization;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using TabletopTweaks.Core.Utilities;
using UnityEngine;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Classes.IsekaiProtagonist {

    internal class IsekaiProtagonistClass {
        private static readonly LocalizedString Name = Helpers.CreateString(IsekaiContext, $"IsekaiProtagonistClass.Name", "Isekai Protagonist");
        private static readonly LocalizedString Description = Helpers.CreateString(IsekaiContext, $"IsekaiProtagonistClass.Description",
            "Isekai protagonists possess immense power, and are able to defeat every enemy with ease using their overpowered abilities. "
            + "They also have plot armor, which make them hard to kill. They are the main character; everyone else are just NPCs.");
        private static readonly LocalizedString DescriptionShort = Helpers.CreateString(IsekaiContext, $"IsekaiProtagonistClass.DescriptionShort",
            "Isekai protagonists are people who have been reincarnated into the world of Golarion with overpowered abilities. "
            + "As their story progresses, they gain more overpowered abilities to wreck every wannabe villain and side character they face.");
        private static BlueprintCharacterClass isekaiProtagonistClass;

        // Icons
        private static readonly Sprite Icon_AllSkilled = BlueprintTools.GetBlueprint<BlueprintFeature>("f3bc6f9c855b2fb4e9aea364b8163aca").m_Icon;
        private static readonly Sprite Icon_ForetellAidBuff = BlueprintTools.GetBlueprint<BlueprintBuff>("faf473e3a977fd4428cd3f1a526346d2").m_Icon;
        private static readonly Sprite Icon_EdictOfImpenetrableFortress = BlueprintTools.GetBlueprint<BlueprintAbility>("d7741c08ccf699e4a8a8f8ab2ed345f8").m_Icon;
        private static readonly Sprite Icon_TrickFate = BlueprintTools.GetBlueprint<BlueprintAbility>("6e109d21da9e1c44fb772a9eca2cafdd").m_Icon;
        private static readonly Sprite Icon_BasicFeatSelection = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("247a4068296e8be42890143f451b4b45").m_Icon;

        // Stat Progression
        private static readonly BlueprintStatProgression BABFull = BlueprintTools.GetBlueprint<BlueprintStatProgression>("b3057560ffff3514299e8b93e7648a9d");
        private static readonly BlueprintStatProgression SavesHigh = BlueprintTools.GetBlueprint<BlueprintStatProgression>("ff4662bde9e75f145853417313842751");

        // Animal Class
        private static readonly BlueprintCharacterClass AnimalClass = BlueprintTools.GetBlueprint<BlueprintCharacterClass>("4cd1757a0eea7694ba5c933729a53920");

        public static void Add() {
            // Decide which default clothes to use (default 20 is the Slayer Class' clothes)
            var defaultClothesIndex = 20;
            var clothesIndex = IsekaiContext.AddedContent.IsekaiDefaultClothes;
            var maxClothesIndex = StaticReferences.BaseClasses.Length;
            var clothesClass = StaticReferences.BaseClasses[clothesIndex > -1 && clothesIndex < maxClothesIndex ? clothesIndex : defaultClothesIndex];

            // Class Signature Features
            var IsekaiProtagonistPlotArmorFeat = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiProtagonistPlotArmorFeat", bp => {
                bp.SetName(IsekaiContext, "Plot Armor");
                bp.SetDescription(IsekaiContext, "Isekai Protagonists gain a luck bonus to {g|Encyclopedia:Armor_Class}AC{/g} and all {g|Encyclopedia:Saving_Throw}saving throws{/g} equal to their character level.");
                bp.m_DescriptionShort = bp.m_Description;
                bp.m_Icon = Icon_EdictOfImpenetrableFortress;
            });
            var IsekaiProtagonistSpecialPowerFeat = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiProtagonistSpecialPowerFeat", bp => {
                bp.SetName(IsekaiContext, "Special Powers");
                bp.SetDescription(IsekaiContext, "Isekai Protagonists gain special powers as they increase their level. These are skills or abilities that greatly enhance the Isekai Protagonist's combat power.");
                bp.m_DescriptionShort = bp.m_Description;
                bp.m_Icon = Icon_ForetellAidBuff;
            });
            var IsekaiProtagonistOverpoweredAbilityFeat = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiProtagonistOverpoweredAbilityFeat", bp => {
                bp.SetName(IsekaiContext, "Overpowered Abilities");
                bp.SetDescription(IsekaiContext, "Isekai Protagonists gain Overpowered Abilities as they increase their level. These are extremely powerful abiilities that surpass even gods.");
                bp.m_DescriptionShort = bp.m_Description;
                bp.m_Icon = Icon_TrickFate;
            });
            var IsekaiProtagonistBonusFeat = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiProtagonistBonusFeat", bp => {
                bp.SetName(IsekaiContext, "Bonus Feat");
                bp.SetDescription(IsekaiContext, "Isekai Protagonists gain twice as many {g|Encyclopedia:Feat}feats{/g} as the other classes.");
                bp.m_DescriptionShort = bp.m_Description;
                bp.m_Icon = Icon_BasicFeatSelection;
            });
            var IsekaiProtagonistLegacyFeat = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiProtagonistLegacyFeat", bp => {
                bp.SetName(IsekaiContext, "Legacy");
                bp.SetDescription(IsekaiContext, "Isekai Protagonists gain a limited set of features from other classes.");
                bp.m_DescriptionShort = bp.m_Description;
                bp.m_Icon = Icon_AllSkilled;
            });

            // Main Class
            isekaiProtagonistClass = Helpers.CreateBlueprint<BlueprintCharacterClass>(IsekaiContext, "IsekaiProtagonistClass", bp => {
                bp.LocalizedName = Name;
                bp.LocalizedDescription = Description;
                bp.LocalizedDescriptionShort = DescriptionShort;
                bp.HitDie = DiceType.D12;
                bp.m_BaseAttackBonus = BABFull.ToReference<BlueprintStatProgressionReference>();
                bp.m_FortitudeSave = SavesHigh.ToReference<BlueprintStatProgressionReference>();
                bp.m_ReflexSave = SavesHigh.ToReference<BlueprintStatProgressionReference>();
                bp.m_WillSave = SavesHigh.ToReference<BlueprintStatProgressionReference>();
                bp.m_Difficulty = 1;
                bp.m_Spellbook = IsekaiProtagonistSpellbook.GetReference();
                bp.RecommendedAttributes = new StatType[] { StatType.Strength, StatType.Charisma };
                bp.NotRecommendedAttributes = new StatType[] { };
                bp.m_EquipmentEntities = new KingmakerEquipmentEntityReference[0];
                bp.m_StartingItems = new BlueprintItemReference[] {
                };
                bp.SkillPoints = 4;
                bp.ClassSkills = new StatType[11] {
                    StatType.SkillAthletics,
                    StatType.SkillMobility,
                    StatType.SkillThievery,
                    StatType.SkillStealth,
                    StatType.SkillKnowledgeArcana,
                    StatType.SkillKnowledgeWorld,
                    StatType.SkillLoreNature,
                    StatType.SkillLoreReligion,
                    StatType.SkillPerception,
                    StatType.SkillPersuasion,
                    StatType.SkillUseMagicDevice
                };
                bp.IsDivineCaster = true;
                bp.IsArcaneCaster = true;
                bp.StartingGold = 69420;
                bp.PrimaryColor = 9;
                bp.SecondaryColor = 9;
                bp.MaleEquipmentEntities = clothesClass.MaleEquipmentEntities;
                bp.FemaleEquipmentEntities = clothesClass.FemaleEquipmentEntities;
                bp.m_SignatureAbilities = new BlueprintFeatureReference[5] {
                    IsekaiProtagonistPlotArmorFeat.ToReference<BlueprintFeatureReference>(),
                    IsekaiProtagonistSpecialPowerFeat.ToReference<BlueprintFeatureReference>(),
                    IsekaiProtagonistOverpoweredAbilityFeat.ToReference<BlueprintFeatureReference>(),
                    IsekaiProtagonistBonusFeat.ToReference<BlueprintFeatureReference>(),
                    IsekaiProtagonistLegacyFeat.ToReference<BlueprintFeatureReference>(),
                };
                bp.AddComponent<PrerequisiteNoClassLevel>(c => {
                    c.m_CharacterClass = AnimalClass.ToReference<BlueprintCharacterClassReference>();
                });
                bp.AddComponent<PrerequisiteIsPet>(c => {
                    c.Not = true;
                    c.HideInUI = true;
                });
                if (IsekaiContext.AddedContent.ExcludeCompanionsFromIsekaiClass) {
                    bp.AddComponent<PrerequisiteIsMainCharacter>();
                }

                // Register Archetypes later using RegisterArchetype
                bp.m_Archetypes = new BlueprintArchetypeReference[0];

                // Set Progression later using SetProgression (Some features in the progression reference IsekaiProtagonistClass which doeesn't exist yet)
                bp.m_Progression = null;

                // Set Default Build later using SetDefaultBuild
                bp.m_DefaultBuild = null;
            });
            IsekaiProtagonistSpellbook.SetCharacterClass(isekaiProtagonistClass);

            // Register Class
            TTCoreExtensions.RegisterClass(isekaiProtagonistClass);
        }

        public static void RegisterArchetype(BlueprintArchetype archetype) {
            BlueprintCharacterClass IsekaiProtagonistClass = Get();
            IsekaiProtagonistClass.m_Archetypes = IsekaiProtagonistClass.m_Archetypes.AppendToArray(archetype.ToReference<BlueprintArchetypeReference>());
        }

        public static void SetProgression(BlueprintProgression progression) {
            BlueprintCharacterClass IsekaiProtagonistClass = Get();
            IsekaiProtagonistClass.m_Progression = progression.ToReference<BlueprintProgressionReference>();
        }

        public static void SetDefaultBuild(BlueprintUnitFact prebuildFeatureList) {
            BlueprintCharacterClass IsekaiProtagonistClass = Get();
            IsekaiProtagonistClass.m_DefaultBuild = prebuildFeatureList.ToReference<BlueprintUnitFactReference>();
        }

        public static BlueprintCharacterClass Get() {
            if (isekaiProtagonistClass != null) {
                return isekaiProtagonistClass;
            }
            return BlueprintTools.GetModBlueprint<BlueprintCharacterClass>(IsekaiContext, "IsekaiProtagonistClass");
        }

        public static BlueprintCharacterClassReference GetReference() {
            return BlueprintTools.GetModBlueprintReference<BlueprintCharacterClassReference>(IsekaiContext, "IsekaiProtagonistClass");
        }
    }
}