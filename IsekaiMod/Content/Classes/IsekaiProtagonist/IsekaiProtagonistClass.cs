using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using UnityEngine;
using Kingmaker.Blueprints.Facts;

namespace IsekaiMod.Content.Classes.IsekaiProtagonist
{
    internal class IsekaiProtagonistClass
    {
        // Icons
        private static readonly Sprite Icon_SneakAttack = Resources.GetBlueprint<BlueprintFeature>("9b9eac6709e1c084cb18c3a366e0ec87").m_Icon;
        private static readonly Sprite Icon_EdictOfImpenetrableFortress = Resources.GetBlueprint<BlueprintAbility>("d7741c08ccf699e4a8a8f8ab2ed345f8").m_Icon;
        private static readonly Sprite Icon_TrickFate = Resources.GetBlueprint<BlueprintAbility>("6e109d21da9e1c44fb772a9eca2cafdd").m_Icon;
        private static readonly Sprite Icon_BasicFeatSelection = Resources.GetBlueprint<BlueprintFeatureSelection>("247a4068296e8be42890143f451b4b45").m_Icon;

        // Stat Progression
        private static readonly BlueprintStatProgression BABFull = Resources.GetBlueprint<BlueprintStatProgression>("b3057560ffff3514299e8b93e7648a9d");
        private static readonly BlueprintStatProgression SavesHigh = Resources.GetBlueprint<BlueprintStatProgression>("ff4662bde9e75f145853417313842751");

        // Used in Class
        private static readonly BlueprintCharacterClass SlayerClass = Resources.GetBlueprint<BlueprintCharacterClass>("c75e0971973957d4dbad24bc7957e4fb");
        private static readonly BlueprintCharacterClass AnimalClass = Resources.GetBlueprint<BlueprintCharacterClass>("4cd1757a0eea7694ba5c933729a53920");

        public static void Add()
        {
            // TODO: fix selective channel energy

            // TODO: add channel negative energy to villain and positive for hero
            // TODO: add scaling natural armor, strength and dexterity (like animal companion) to deathsnatcher
            // TODO: add vampiric drain spell for isekai vampire heritage
            // TODO: Load localisation instead of hardcoded strings

            // Class Signature Features
            var IsekaiProtagonistBonusFeat = Helpers.CreateBlueprint<BlueprintFeature>("IsekaiProtagonistBonusFeat", bp => {
                bp.SetName("Bonus Feat");
                bp.SetDescription("Isekai Protagonists gain twice as many {g|Encyclopedia:Feat}feats{/g} as the other classes.");
                bp.m_DescriptionShort = Helpers.CreateString("IsekaiProtagonistBonusFeat.DescriptionShort", "Isekai Protagonists gain twice as many {g|Encyclopedia:Feat}feats{/g} as the other classes.");
                bp.m_Icon = Icon_BasicFeatSelection;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
            var IsekaiProtagonistSneakFeat = Helpers.CreateBlueprint<BlueprintFeature>("IsekaiProtagonistSneakFeat", bp => {
                bp.SetName("Sneak Attack");
                bp.SetDescription("Most characters gain advantages when they {g|Encyclopedia:Flanking}flank{/g} an enemy, {g|Encyclopedia:Attack}attack{/g} an enemy who can't see them or enjoy a similar fortunate position. Isekai Protagonists deal a tremendous amount of additional {g|Encyclopedia:Damage}damage{/g} in such a situation.");
                bp.m_DescriptionShort = Helpers.CreateString("IsekaiProtagonistSneakFeat.DescriptionShort", "Most characters gain advantages when they {g|Encyclopedia:Flanking}flank{/g} an enemy, {g|Encyclopedia:Attack}attack{/g} an enemy who can't see them or enjoy a similar fortunate position. Isekai Protagonists deal a tremendous amount of additional {g|Encyclopedia:Damage}damage{/g} in such a situation.");
                bp.m_Icon = Icon_SneakAttack;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
            var IsekaiProtagonistPlotArmorFeat = Helpers.CreateBlueprint<BlueprintFeature>("IsekaiProtagonistPlotArmorFeat", bp => {
                bp.SetName("Plot Armor");
                bp.SetDescription("Isekai Protagonists gain a luck bonus to {g|Encyclopedia:Armor_Class}AC{/g} and all {g|Encyclopedia:Saving_Throw}saving throws{/g} equal to their character level.");
                bp.m_DescriptionShort = Helpers.CreateString("PlotArmor.DescriptionShort", "You gain a luck bonus to {g|Encyclopedia:Armor_Class}AC{/g} and all {g|Encyclopedia:Saving_Throw}saving throws{/g} based on your character level.");
                bp.m_Icon = Icon_EdictOfImpenetrableFortress;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
            var IsekaiProtagonistOverpoweredAbilityFeat = Helpers.CreateBlueprint<BlueprintFeature>("IsekaiProtagonistOverpoweredAbilityFeat", bp => {
                bp.SetName("Overpowered Ability");
                bp.SetDescription("Isekai Protagonists gain Overpowered Abilities as they increase their level.");
                bp.m_DescriptionShort = Helpers.CreateString("IsekaiProtagonistOverpoweredAbilityFeat.DescriptionShort", "Isekai Protagonists gain an Overpowered Abilities as they increase their level.");
                bp.m_Icon = Icon_TrickFate;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });

            // Main Class
            var IsekaiProtagonistClass = Helpers.CreateBlueprint<BlueprintCharacterClass>("IsekaiProtagonistClass", bp => {
                bp.LocalizedName = Helpers.CreateString($"IsekaiProtagonistClass.Name", "Isekai Protagonist");
                bp.LocalizedDescription = Helpers.CreateString($"IsekaiProtagonistClass.Description", "Isekai protagonists possess immense power, and are able to defeat every enemy "
                    + "with ease using their overpowered abilities. They also have plot armor, which make them hard to kill. They are the main character; everyone else are just NPCs.");
                bp.LocalizedDescriptionShort = Helpers.CreateString($"IsekaiProtagonistClass.Description",
                    "Isekai protagonists are people who have been reincarnated into the world of Golarion with overpowered abilities. "
                    + "As their story progresses, they gain more overpowered abilities to wreck every wannabe villain and side character they face.");
                bp.HitDie = DiceType.D12;
                bp.m_BaseAttackBonus = BABFull.ToReference<BlueprintStatProgressionReference>();
                bp.m_FortitudeSave = SavesHigh.ToReference<BlueprintStatProgressionReference>();
                bp.m_ReflexSave = SavesHigh.ToReference<BlueprintStatProgressionReference>();
                bp.m_WillSave = SavesHigh.ToReference<BlueprintStatProgressionReference>();
                bp.m_Difficulty = 1;
                bp.m_Spellbook = IsekaiProtagonistSpellbook.GetReference();
                bp.RecommendedAttributes = new StatType[] { StatType.Strength, StatType.Charisma};
                bp.NotRecommendedAttributes = new StatType[] { StatType.Constitution };
                bp.m_EquipmentEntities = new KingmakerEquipmentEntityReference[0];
                bp.m_StartingItems = new BlueprintItemReference[0];
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
                bp.IsArcaneCaster = false;
                bp.StartingGold = 69420;
                bp.PrimaryColor = 9;
                bp.SecondaryColor = 9;
                bp.MaleEquipmentEntities = SlayerClass.MaleEquipmentEntities;
                bp.FemaleEquipmentEntities = SlayerClass.FemaleEquipmentEntities;
                bp.m_SignatureAbilities = new BlueprintFeatureReference[4] {
                    IsekaiProtagonistBonusFeat.ToReference<BlueprintFeatureReference>(),
                    IsekaiProtagonistPlotArmorFeat.ToReference<BlueprintFeatureReference>(),
                    IsekaiProtagonistOverpoweredAbilityFeat.ToReference<BlueprintFeatureReference>(),
                    IsekaiProtagonistSneakFeat.ToReference<BlueprintFeatureReference>(),
                };
                bp.AddComponent<PrerequisiteNoClassLevel>(c => {
                    c.m_CharacterClass = AnimalClass.ToReference<BlueprintCharacterClassReference>();
                });
                bp.AddComponent<PrerequisiteIsPet>(c => {
                    c.Not = true;
                    c.HideInUI = true;
                });

                // Register Archetypes later using RegisterArchetype
                bp.m_Archetypes = new BlueprintArchetypeReference[0];

                // Set Progression later using SetProgression (This is because some features in the progression reference IsekaiProtagonistClass which doeesn't exist yet)
                bp.m_Progression = null;

                // Set Default Build later using SetDefaultBuild
                bp.m_DefaultBuild = null;
            });
            IsekaiProtagonistSpellbook.SetCharacterClass(IsekaiProtagonistClass);

            // Register Class
            Helpers.RegisterClass(IsekaiProtagonistClass);
        }
        public static void RegisterArchetype(BlueprintArchetype archetype)
        {
            BlueprintCharacterClass IsekaiProtagonistClass = Get();
            IsekaiProtagonistClass.m_Archetypes = IsekaiProtagonistClass.m_Archetypes.AppendToArray(archetype.ToReference<BlueprintArchetypeReference>());
        }
        public static void SetProgression(BlueprintProgression progression)
        {
            BlueprintCharacterClass IsekaiProtagonistClass = Get();
            IsekaiProtagonistClass.m_Progression = progression.ToReference<BlueprintProgressionReference>();
        }
        public static void SetDefaultBuild(BlueprintUnitFact prebuildFeatureList)
        {
            BlueprintCharacterClass IsekaiProtagonistClass = Get();
            IsekaiProtagonistClass.m_DefaultBuild = prebuildFeatureList.ToReference<BlueprintUnitFactReference>();
        }
        public static BlueprintCharacterClass Get()
        {
            return Resources.GetModBlueprint<BlueprintCharacterClass>("IsekaiProtagonistClass");
        }
        public static BlueprintCharacterClassReference GetReference()
        {
            return Get().ToReference<BlueprintCharacterClassReference>();
        }
    }
}