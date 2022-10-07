using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.Enums.Damage;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Buffs.Components;
using Kingmaker.Utility;
using Kingmaker.ResourceLinks;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.ElementsSystem;
using Kingmaker.UnitLogic.Mechanics.Conditions;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.UnitLogic;
using UnityEngine;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.Visual.Animation.Kingmaker.Actions;
using Kingmaker.UnitLogic.Commands.Base;
using Kingmaker.UnitLogic.Abilities.Components;

namespace IsekaiMod.Changes.Classes.IsekaiProtagonist
{
    internal class IsekaiProtagonistClass
    {
        // Stat Progression
        private static readonly BlueprintStatProgression BaseAttackBonus = Resources.GetBlueprint<BlueprintStatProgression>("b3057560ffff3514299e8b93e7648a9d");
        private static readonly BlueprintStatProgression SavesProgression = Resources.GetBlueprint<BlueprintStatProgression>("ff4662bde9e75f145853417313842751");

        // Proficiencies
        private static readonly BlueprintFeature LightArmorProficiency = Resources.GetBlueprint<BlueprintFeature>("6d3728d4e9c9898458fe5e9532951132");
        private static readonly BlueprintFeature MediumArmorProficiency = Resources.GetBlueprint<BlueprintFeature>("46f4fb320f35704488ba3d513397789d");
        private static readonly BlueprintFeature HeavyArmorProficiency = Resources.GetBlueprint<BlueprintFeature>("1b0f68188dcc435429fb87a022239681");
        private static readonly BlueprintFeature SimpleWeaponProficiency = Resources.GetBlueprint<BlueprintFeature>("e70ecf1ed95ca2f40b754f1adb22bbdd");
        private static readonly BlueprintFeature MartialWeaponProficiency = Resources.GetBlueprint<BlueprintFeature>("203992ef5b35c864390b4e4a1e200629");
        private static readonly BlueprintFeature ShieldsProficiency = Resources.GetBlueprint<BlueprintFeature>("cb8686e7357a68c42bdd9d4e65334633");
        private static readonly BlueprintFeature TowerShieldProficiency = Resources.GetBlueprint<BlueprintFeature>("6105f450bb2acbd458d277e71e19d835");

        // Mythic Classes
        private static readonly BlueprintCharacterClass MythicCompanionClass = Resources.GetBlueprint<BlueprintCharacterClass>("530b6a79cb691c24ba99e1577b4beb6d");
        private static readonly BlueprintCharacterClass MythicStartingClass = Resources.GetBlueprint<BlueprintCharacterClass>("247aa787806d5da4f89cfc3dff0b217f");
        private static readonly BlueprintCharacterClass AeonMythicClass = Resources.GetBlueprint<BlueprintCharacterClass>("15a85e67b7d69554cab9ed5830d0268e");
        private static readonly BlueprintCharacterClass AngelMythicClass = Resources.GetBlueprint<BlueprintCharacterClass>("a5a9fe8f663d701488bd1db8ea40484e");
        private static readonly BlueprintCharacterClass AzataMythicClass = Resources.GetBlueprint<BlueprintCharacterClass>("9a3b2c63afa79744cbca46bea0da9a16");
        private static readonly BlueprintCharacterClass DemonMythicClass = Resources.GetBlueprint<BlueprintCharacterClass>("8e19495ea576a8641964102d177e34b7");
        private static readonly BlueprintCharacterClass LichMythicClass = Resources.GetBlueprint<BlueprintCharacterClass>("5d501618a28bdc24c80007a5c937dcb7");
        private static readonly BlueprintCharacterClass DevilMythicClass = Resources.GetBlueprint<BlueprintCharacterClass>("211f49705f478b3468db6daa802452a2");
        private static readonly BlueprintCharacterClass SwarmThatWalksClass = Resources.GetBlueprint<BlueprintCharacterClass>("5295b8e13c2303f4c88bdb3d7760a757");

        // Mythic Ability Selection
        private static readonly BlueprintFeatureSelection MythicAbilitySelection = Resources.GetBlueprint<BlueprintFeatureSelection>("ba0e5a900b775be4a99702f1ed08914d");


        // Icons
        private static readonly Sprite Icon_AcidSplash = Resources.GetBlueprint<BlueprintAbility>("0c852a2405dd9f14a8bbcfaf245ff823").m_Icon;
        private static readonly Sprite Icon_IceStorm = Resources.GetBlueprint<BlueprintAbility>("fcb028205a71ee64d98175ff39a0abf9").m_Icon;
        private static readonly Sprite Icon_LightningBolt = Resources.GetBlueprint<BlueprintAbility>("d2cff9243a7ee804cb6d5be47af30c73").m_Icon;
        private static readonly Sprite Icon_Fireball = Resources.GetBlueprint<BlueprintAbility>("2d81362af43aeac4387a3d4fced489c3").m_Icon;
        private static readonly Sprite Icon_EarPiercingScream = Resources.GetBlueprint<BlueprintAbility>("8e7cfa5f213a90549aadd18f8f6f4664").m_Icon;

        private static readonly Sprite Icon_ResistAcid = Resources.GetBlueprint<BlueprintAbility>("fedc77de9b7aad54ebcc43b4daf8decd").m_Icon;
        private static readonly Sprite Icon_ResistCold = Resources.GetBlueprint<BlueprintAbility>("5368cecec375e1845ae07f48cdc09dd1").m_Icon;
        private static readonly Sprite Icon_ResistElectricity = Resources.GetBlueprint<BlueprintAbility>("90987584f54ab7a459c56c2d2f22cee2").m_Icon;
        private static readonly Sprite Icon_ResistFire = Resources.GetBlueprint<BlueprintAbility>("ddfb4ac970225f34dbff98a10a4a8844").m_Icon;
        private static readonly Sprite Icon_ResistSonic = Resources.GetBlueprint<BlueprintAbility>("8d3b10f92387c84429ced317b06ad001").m_Icon;

        private static readonly Sprite Icon_ProtectionFromAcid = Resources.GetBlueprint<BlueprintAbility>("3d77ee3fc4913c44b9df7c5bbcdc4906").m_Icon;
        private static readonly Sprite Icon_ProtectionFromCold = Resources.GetBlueprint<BlueprintAbility>("021d39c8e0eec384ba69140f4875e166").m_Icon;
        private static readonly Sprite Icon_ProtectionFromElectricity = Resources.GetBlueprint<BlueprintAbility>("e24ce0c3e8eaaaf498d3656b534093df").m_Icon;
        private static readonly Sprite Icon_ProtectionFromFire = Resources.GetBlueprint<BlueprintAbility>("3f9605134d34e1243b096e1f6cb4c148").m_Icon;
        private static readonly Sprite Icon_ProtectionFromSonic = Resources.GetBlueprint<BlueprintAbility>("0cee375b4e5265a46a13fc269beb8763").m_Icon;
        private static readonly Sprite Icon_DeathWard = Resources.GetBlueprint<BlueprintAbility>("0413915f355a38146bc6ad40cdf27b3f").m_Icon;
        private static readonly Sprite Icon_MageArmor = Resources.GetBlueprint<BlueprintAbility>("9e1ad5d6f87d19e4d8883d63a6e35568").m_Icon;
        private static readonly Sprite Icon_EdictOfImpenetrableFortress = Resources.GetBlueprint<BlueprintAbility>("d7741c08ccf699e4a8a8f8ab2ed345f8").m_Icon;
        private static readonly Sprite Icon_ExpeditiousRetreat = Resources.GetBlueprint<BlueprintAbility>("4f8181e7a7f1d904fbaea64220e83379").m_Icon;
        private static readonly Sprite Icon_PredictionOfFailure = Resources.GetBlueprint<BlueprintAbility>("0e67fa8f011662c43934d486acc50253").m_Icon;
        private static readonly Sprite Icon_CrushingDespair = Resources.GetBlueprint<BlueprintAbility>("4baf4109145de4345861fe0f2209d903").m_Icon;
        private static readonly Sprite Icon_Daze = Resources.GetBlueprint<BlueprintAbility>("55f14bc84d7c85446b07a1b5dd6b2b4c").m_Icon;
        private static readonly Sprite Icon_Rage = Resources.GetBlueprint<BlueprintAbility>("97b991256e43bb140b263c326f690ce2").m_Icon;
        private static readonly Sprite Icon_OverwhelmingGrief = Resources.GetBlueprint<BlueprintAbility>("dd2918e4a77c50044acba1ac93494c36").m_Icon;

        private static readonly Sprite Icon_SwordSaintWeaponMastery = Resources.GetBlueprint<BlueprintFeature>("5b31af13868166d4c9bb452f19277f19").m_Icon;
        private static readonly Sprite Icon_SwordSaintFighterTraining = Resources.GetBlueprint<BlueprintFeature>("9ab2ec65977cc524a99600babc7fe3b6").m_Icon;
        private static readonly Sprite Icon_FastMovement = Resources.GetBlueprint<BlueprintFeature>("d294a5dddd0120046aae7d4eb6cbc4fc").m_Icon;
        private static readonly Sprite Icon_Bravery = Resources.GetBlueprint<BlueprintFeature>("f6388946f9f472f4585591b80e9f2452").m_Icon;

        private static readonly Sprite Icon_Discovery = Resources.GetBlueprint<BlueprintFeatureSelection>("cd86c437488386f438dcc9ae727ea2a6").m_Icon;

        public static void AddIsekaiProtagonistClass()
        {
            // TODO: fix spells known progression
            // TODO: add story arcs: entrance exam arc, training montage, study montage, tournament arc, beach episode, flashback episode, Final boss arc, tragic backstory
            // TODO: character development feats should be renamed to personality types.
            // TODO: character development feats should initially give energy resistance and then finally give immunity at a certain level.
            // TODO: "character development feats" should probably be more than just immunities

            // TODO: Add a "hexagon-player" default build
            // TODO: Add MythicAbilitySelection ability
            // TODO: Add mythic spellbook merging

            // TODO: Add archetypes, Archetype ideas: God Emporer, Edge Lord
            // TODO: Add custom equipment
            var BasicFeatSelection = Resources.GetBlueprint<BlueprintFeatureSelection>("247a4068296e8be42890143f451b4b45");

            var AnimalClass = Resources.GetBlueprint<BlueprintCharacterClass>("4cd1757a0eea7694ba5c933729a53920");
            var FighterClass = Resources.GetBlueprint<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd");
            var MonkClass = Resources.GetBlueprint<BlueprintCharacterClass>("e8f21e5b58e0569468e420ebea456124");

            // Spellbook
            var IsekaiProtagonistSpellList = Resources.GetModBlueprint<BlueprintSpellList>("IsekaiProtagonistSpellList");
            var IsekaiProtagonistSpellsPerDay = Helpers.CreateBlueprint<BlueprintSpellsTable>("IsekaiProtagonistSpellsPerDay", bp => {
                bp.Levels = new SpellsLevelEntry[29] {
                    new SpellsLevelEntry() { Count = new int[] { } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 5 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 10 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 15, 5 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 20, 10, 5 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 20, 15, 10 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 20, 20, 15, 5 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 20, 20, 20, 10, 5 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 20, 20, 20, 15, 10 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 20, 20, 20, 20, 15, 5 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 20, 20, 20, 20, 20, 10, 5 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 20, 20, 20, 20, 20, 15, 10 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 20, 20, 20, 20, 20, 20, 15, 5 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 20, 20, 20, 20, 20, 20, 20, 10, 5 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 20, 20, 20, 20, 20, 20, 20, 15, 10 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 20, 20, 20, 20, 20, 20, 20, 20, 15 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 20, 20, 20, 20, 20, 20, 20, 20, 20 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 20, 20, 20, 20, 20, 20, 20, 20, 20 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 20, 20, 20, 20, 20, 20, 20, 20, 20 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 20, 20, 20, 20, 20, 20, 20, 20, 20 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 20, 20, 20, 20, 20, 20, 20, 20, 20 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 20, 20, 20, 20, 20, 20, 20, 20, 20 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 20, 20, 20, 20, 20, 20, 20, 20, 20 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 20, 20, 20, 20, 20, 20, 20, 20, 20 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 20, 20, 20, 20, 20, 20, 20, 20, 20 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 20, 20, 20, 20, 20, 20, 20, 20, 20 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 20, 20, 20, 20, 20, 20, 20, 20, 20 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 20, 20, 20, 20, 20, 20, 20, 20, 20 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 20, 20, 20, 20, 20, 20, 20, 20, 20, 2 } }
                };
            });
            var IsekaiProtagonistSpellsKnown = Helpers.CreateBlueprint<BlueprintSpellsTable>("IsekaiProtagonistSpellsKnown", bp => {
                bp.Levels = new SpellsLevelEntry[21] {
                    new SpellsLevelEntry() { Count = new int[] { } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 5 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 10 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 15, 5 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 20, 10, 5 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 20, 15, 10 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 20, 20, 15, 5 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 20, 20, 20, 10, 5 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 20, 20, 20, 15, 10 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 20, 20, 20, 20, 15, 5 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 20, 20, 20, 20, 20, 10, 5 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 20, 20, 20, 20, 20, 15, 10 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 20, 20, 20, 20, 20, 20, 15, 5 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 20, 20, 20, 20, 20, 20, 20, 10, 5 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 20, 20, 20, 20, 20, 20, 20, 15, 10 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 20, 20, 20, 20, 20, 20, 20, 20, 15 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 20, 20, 20, 20, 20, 20, 20, 20, 20 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 20, 20, 20, 20, 20, 20, 20, 20, 20 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 20, 20, 20, 20, 20, 20, 20, 20, 20 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 20, 20, 20, 20, 20, 20, 20, 20, 20 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 20, 20, 20, 20, 20, 20, 20, 20, 20 } }
                };
            });
            var IsekaiProtagonistSpellbook = Helpers.CreateBlueprint<BlueprintSpellbook>("IsekaiProtagonistSpellbook", bp => {
                bp.Name = Helpers.CreateString("$IsekaiProtagonistSpellbook.Name", "Isekai Protagonist");
                bp.Spontaneous = true;
                bp.CastingAttribute = StatType.Charisma;
                bp.CantripsType = CantripsType.Cantrips;
                bp.IsArcane = true;
                bp.IsArcanist = false;
                bp.m_SpellsPerDay = IsekaiProtagonistSpellsPerDay.ToReference<BlueprintSpellsTableReference>();
                bp.m_SpellsKnown = IsekaiProtagonistSpellsKnown.ToReference<BlueprintSpellsTableReference>();
                bp.m_SpellList = IsekaiProtagonistSpellList.ToReference<BlueprintSpellListReference>();
                bp.m_SpellSlots = null;
                bp.SpellsPerLevel = 0;
                bp.AllSpellsKnown = false;
                bp.CanCopyScrolls = false;

                // Mythic spellbook related
                bp.IsMythic = false;
                bp.m_MythicSpellList = null;

                // These relate to special spell slots (like wizard's favourite school spell slots or shaman's spirit magic slots)
                bp.HasSpecialSpellList = false;
                bp.SpecialSpellListName = new Kingmaker.Localization.LocalizedString();
            });
            // Progression
            var IsekaiProtagonistProgression = Helpers.CreateBlueprint<BlueprintProgression>("IsekaiProtagonistProgression", bp => {
                bp.SetName("");
                bp.SetDescription(
                    "Isekai protagonists are otherworldly entities who have been reincarnated into the world of Golarion with extraordinary abilities. " +
                    "As their story progresses, they gain more unexplained and overpowered abilities to overcome every challenge they face.");
                bp.m_AllowNonContextActions = false;
                bp.IsClassFeature = true;
                bp.m_FeaturesRankIncrease = null;
            });
            // Main Class
            var IsekaiProtagonistClass = Helpers.CreateBlueprint<BlueprintCharacterClass>("IsekaiProtagonistClass", bp => {
                bp.LocalizedName = Helpers.CreateString($"IsekaiProtagonistClass.Name", "Isekai Protagonist");
                bp.LocalizedDescription = Helpers.CreateString($"IsekaiProtagonistClass.Description", "Isekai protagonists are skilled in both martial prowess and magical ability. " +
                    "They are able to cast spells while wearing any armor or shield.");
                bp.LocalizedDescriptionShort = Helpers.CreateString($"IsekaiProtagonistClass.Description",
                    "Isekai protagonists are otherworldly entities who have been reincarnated into the world of Golarion with extraordinary abilities. " +
                    "As their story progresses, they gain more unexplained and overpowered abilities to overcome every challenge they face.");
                bp.HitDie = DiceType.D12;
                bp.m_BaseAttackBonus = BaseAttackBonus.ToReference<BlueprintStatProgressionReference>();
                bp.m_FortitudeSave = SavesProgression.ToReference<BlueprintStatProgressionReference>();
                bp.m_ReflexSave = SavesProgression.ToReference<BlueprintStatProgressionReference>();
                bp.m_WillSave = SavesProgression.ToReference<BlueprintStatProgressionReference>();
                bp.m_Progression = IsekaiProtagonistProgression.ToReference<BlueprintProgressionReference>();
                bp.m_Difficulty = 1;
                bp.RecommendedAttributes = new StatType[] { StatType.Strength, StatType.Charisma};
                bp.NotRecommendedAttributes = new StatType[] { StatType.Constitution };
                bp.m_Spellbook = IsekaiProtagonistSpellbook.ToReference<BlueprintSpellbookReference>();
                bp.m_EquipmentEntities = new KingmakerEquipmentEntityReference[] { };
                bp.m_StartingItems = new BlueprintItemReference[] { };
                bp.m_DefaultBuild = null;
                bp.m_Archetypes = new BlueprintArchetypeReference[] { };
                bp.SkillPoints = 0;
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
                bp.IsDivineCaster = false;
                bp.IsArcaneCaster = true;
                bp.StartingGold = 69420;
                bp.PrimaryColor = 9;
                bp.SecondaryColor = 9;
                bp.MaleEquipmentEntities = MonkClass.MaleEquipmentEntities;
                bp.FemaleEquipmentEntities = MonkClass.FemaleEquipmentEntities;
                bp.AddComponent<PrerequisiteNoClassLevel>(c => {
                    c.m_CharacterClass = AnimalClass.ToReference<BlueprintCharacterClassReference>();
                });
                bp.AddComponent<PrerequisiteIsPet>(c => {
                    c.Not = true;
                    c.HideInUI = true;
                });
            });
            IsekaiProtagonistProgression.m_Classes = new BlueprintProgression.ClassWithLevel[] {
                new BlueprintProgression.ClassWithLevel {
                    m_Class = IsekaiProtagonistClass.ToReference<BlueprintCharacterClassReference>(),
                    AdditionalLevel = 0
                }
            };
            IsekaiProtagonistSpellbook.m_CharacterClass = IsekaiProtagonistClass.ToReference<BlueprintCharacterClassReference>();

            //// Class Features
            // Proficiencies
            var IsekaiProtagonistProficiencies = Helpers.CreateBlueprint<BlueprintFeature>("IsekaiProtagonistProficiencies", bp => {
                bp.SetName("Isekai Protagonist Proficiences");
                bp.SetDescription("Isekai Protagonists are proficient with all simple and {g|Encyclopedia:Weapon_Proficiency}martial weapons{/g} and with all armor (heavy, light, and medium) and shields (including tower shields). They can cast {g|Encyclopedia:Spell}spells{/g} from this class while wearing armor and shields (including tower shields) without incurring the normal {g|Encyclopedia:Spell_Fail_Chance}arcane spell failure chance{/g}, but they incur the normal arcane spell failure chance for arcane spells received from other classes.");
                bp.m_Icon = null;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] {
                        LightArmorProficiency.ToReference<BlueprintUnitFactReference>(),
                        MediumArmorProficiency.ToReference<BlueprintUnitFactReference>(),
                        HeavyArmorProficiency.ToReference<BlueprintUnitFactReference>(),
                        SimpleWeaponProficiency.ToReference<BlueprintUnitFactReference>(),
                        MartialWeaponProficiency.ToReference<BlueprintUnitFactReference>(),
                        ShieldsProficiency.ToReference<BlueprintUnitFactReference>(),
                        TowerShieldProficiency.ToReference<BlueprintUnitFactReference>(),
                    };
                });
                bp.AddComponent<ArcaneArmorProficiency>(c => {
                    c.Armor = new ArmorProficiencyGroup[] {
                        ArmorProficiencyGroup.Light,
                        ArmorProficiencyGroup.Medium,
                        ArmorProficiencyGroup.Heavy,
                        ArmorProficiencyGroup.Buckler,
                        ArmorProficiencyGroup.LightShield,
                        ArmorProficiencyGroup.HeavyShield,
                        ArmorProficiencyGroup.TowerShield
                    };
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
            // Cantrips (May need to change this in the future since it doesn't actually add the cantrips)
            var IsekaiProtagonistCantripsFeature = Helpers.CreateBlueprint<BlueprintFeature>("IsekaiProtagonistCantripsFeature", bp => {
                bp.SetName("Cantrips");
                bp.SetDescription("Isekai Protagonists can cast a number of {g|Encyclopedia:Cantrips_Orisons}cantrips{/g}, or 0-level {g|Encyclopedia:Spell}spells{/g}. These spells are cast like any other spell, but they are not expended when cast and may be used again.");
                bp.m_Icon = null;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[]
                    {
                        IsekaiProtagonist.IsekaiProtagonistSpellList.MageLightAbility.ToReference<BlueprintUnitFactReference>(),
                        IsekaiProtagonist.IsekaiProtagonistSpellList.JoltAbility.ToReference<BlueprintUnitFactReference>(),
                        IsekaiProtagonist.IsekaiProtagonistSpellList.DisruptUndeadAbility.ToReference<BlueprintUnitFactReference>(),
                        IsekaiProtagonist.IsekaiProtagonistSpellList.AcidSplashAbility.ToReference<BlueprintUnitFactReference>(),
                        IsekaiProtagonist.IsekaiProtagonistSpellList.DismissAreaEffectAbility.ToReference<BlueprintUnitFactReference>(),
                        IsekaiProtagonist.IsekaiProtagonistSpellList.DazeAbility.ToReference<BlueprintUnitFactReference>(),
                        IsekaiProtagonist.IsekaiProtagonistSpellList.TouchOfFatigueAbility.ToReference<BlueprintUnitFactReference>(),
                        IsekaiProtagonist.IsekaiProtagonistSpellList.FlareAbility.ToReference<BlueprintUnitFactReference>(),
                        IsekaiProtagonist.IsekaiProtagonistSpellList.RayOfFrostAbility.ToReference<BlueprintUnitFactReference>(),
                        IsekaiProtagonist.IsekaiProtagonistSpellList.ResistanceAbility.ToReference<BlueprintUnitFactReference>(),
                        IsekaiProtagonist.IsekaiProtagonistSpellList.DivineZapAbility.ToReference<BlueprintUnitFactReference>(),
                        IsekaiProtagonist.IsekaiProtagonistSpellList.GuidanceAbility.ToReference<BlueprintUnitFactReference>(),
                        IsekaiProtagonist.IsekaiProtagonistSpellList.VirtueAbility.ToReference<BlueprintUnitFactReference>()
                    };
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
            // Bonus Feats
            var IsekaiProtagonistBonusFeatSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>("IsekaiProtagonistBonusFeatSelection", bp => {
                bp.SetName("Bonus Feat");
                bp.SetDescription("At 1st level, and at every even level thereafter, Isekai Protagonists gain a bonus {g|Encyclopedia:Feat}feat{/g} in addition to those gained from normal advancement.");
                bp.m_Icon = null;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.Group = FeatureGroup.Feat;
                bp.Group2 = FeatureGroup.TricksterFeat;
                bp.m_AllFeatures = BasicFeatSelection.m_AllFeatures;
            });
            // Sneak Attack
            var SneakAttack = Resources.GetBlueprint<BlueprintFeature>("9b9eac6709e1c084cb18c3a366e0ec87");
            // Plot Armor
            var PlotArmor = Helpers.CreateBlueprint<BlueprintFeature>("PlotArmor", bp => {
                bp.SetName("Plot Armor");
                bp.SetDescription("Isekai Protagonists gain a luck bonus to {g|Encyclopedia:Armor_Class}AC{/g} and all {g|Encyclopedia:Saving_Throw}saving throws{/g} equal to their character level.");
                bp.m_DescriptionShort = Helpers.CreateString("PlotArmor.DescriptionShort", "Isekai Protagonists gain a luck bonus to {g|Encyclopedia:Armor_Class}AC{/g} and all {g|Encyclopedia:Saving_Throw}saving throws{/g} equal to their character level.");
                bp.m_Icon = Icon_EdictOfImpenetrableFortress;
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Luck;
                    c.Stat = StatType.AC;
                    c.Value = new ContextValue()
                    {
                        ValueType = ContextValueType.Rank,
                        ValueRank = AbilityRankType.StatBonus
                    };
                });
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Luck;
                    c.Stat = StatType.SaveFortitude;
                    c.Value = new ContextValue()
                    {
                        ValueType = ContextValueType.Rank,
                        ValueRank = AbilityRankType.StatBonus
                    };
                });
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Luck;
                    c.Stat = StatType.SaveReflex;
                    c.Value = new ContextValue()
                    {
                        ValueType = ContextValueType.Rank,
                        ValueRank = AbilityRankType.StatBonus
                    };
                });
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Luck;
                    c.Stat = StatType.SaveWill;
                    c.Value = new ContextValue()
                    {
                        ValueType = ContextValueType.Rank,
                        ValueRank = AbilityRankType.StatBonus
                    };
                });
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.StatBonus;
                    c.m_BaseValueType = ContextRankBaseValueType.CharacterLevel;
                });
                bp.IsClassFeature = true;
                bp.ReapplyOnLevelUp = true;
            });
            var UncannyDodge = Resources.GetBlueprint<BlueprintFeature>("3c08d842e802c3e4eb19d15496145709");
            var ImprovedUncannyDodge = Resources.GetBlueprint<BlueprintFeature>("485a18c05792521459c7d06c63128c79");
            var Evasion = Resources.GetBlueprint<BlueprintFeature>("576933720c440aa4d8d42b0c54b77e80");
            var ImprovedEvasion = Resources.GetBlueprint<BlueprintFeature>("ce96af454a6137d47b9c6a1e02e66803");
            // Harem Magnet
            var Icon_Harem = AssetLoader.LoadInternal("Abilities", "ICON_HAREM.png");
            var HaremMagnetEffect = Helpers.CreateBlueprint<BlueprintBuff>("HaremMagnetEffect", bp => {
                bp.SetName("Fascinated");
                bp.SetDescription("This creature is Fascinated by the Protagonist and can take no actions. Any {g|Encyclopedia:Damage}damage{/g} to the target automatically breaks the effect.");
                bp.m_Icon = Icon_Harem;
                bp.TickEachSecond = false;
                bp.Stacking = StackingType.Replace;
                bp.Frequency = DurationRate.Rounds;
                bp.m_AllowNonContextActions = false;
                bp.FxOnStart = new PrefabLink() { AssetId = "396af91a93f6e2b468f5fa1a944fae8a" };
                bp.FxOnRemove = new PrefabLink();
                bp.AddComponent<AddCondition>(c => { c.Condition = UnitCondition.Dazed; });
                bp.AddComponent<AddIncomingDamageTrigger>(c => {
                    c.TriggerOnStatDamageOrEnergyDrain = true;
                    c.Actions = Helpers.CreateActionList(
                        new ContextActionRemoveSelf() { name = "$ContextActionRemoveSelf$e030f2e6-efe6-48e4-b836-211ee145248d" } // Turns out having a name is very important
                        );
                });
                bp.AddComponent<AddFactContextActions>(c => {
                    c.NewRound = Helpers.CreateActionList();
                    c.Deactivated = Helpers.CreateActionList();
                    c.Activated = Helpers.CreateActionList(
                        new ContextActionSpawnFx() {
                            PrefabLink = new PrefabLink() {
                                AssetId = "28b3cd92c1fdc194d9ee1e378c23be6b"
                            }
                        });
                });
                bp.Ranks = 0;
                bp.IsClassFeature = true;
            });
            var HaremMagnetImmunity = Helpers.CreateBlueprint<BlueprintBuff>("HaremMagnetImmunity", bp => {
                bp.SetName("Harem Magnet Immunity");
                bp.SetDescription("This creature is immune to the Protagonist's Harem Magnet for 24 hours.");
                bp.m_Icon = Icon_Harem;
                bp.Stacking = StackingType.Replace;
                bp.Frequency = DurationRate.Rounds;
                bp.AddComponent<IsPositiveEffect>();
            });
            var HaremMagnetAbility = Helpers.CreateBlueprint<BlueprintAbility>("HaremMagnetAbility", bp => {
                bp.SetName("Harem Magnet");
                bp.SetDescription("As a {g|Encyclopedia:Free_Action}free action{/g}, enemies within 60 feet who fails a {g|Encyclopedia:DC}DC{/g} 50 {g|Encyclopedia:Saving_Throw}Will save{/g} loses any immunity to mind-affecting effects, charm effects, and compulsion effects, and becomes fascinated by the Isekai Protagonist for {g|Encyclopedia:Dice}5d4{/g} {g|Encyclopedia:Combat_Round}rounds{/g}. Creatures that succeed at this saving throw are immune to this ability for 24 hours.");
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.SavingThrowType = SavingThrowType.Unknown;
                    c.Actions = Helpers.CreateActionList(
                        new Conditional()
                        {
                            ConditionsChecker = new ConditionsChecker()
                            {
                                Operation = Operation.And,
                                Conditions = new Condition[] {
                                    new ContextConditionIsCaster() {
                                        Not = true
                                    },
                                    new ContextConditionHasFact() {
                                        Not = true,
                                        m_Fact = HaremMagnetEffect.ToReference<BlueprintUnitFactReference>()
                                    },
                                    new ContextConditionHasFact() {
                                        Not = true,
                                        m_Fact = HaremMagnetImmunity.ToReference<BlueprintUnitFactReference>()
                                    }
                                }
                            },
                            IfTrue = Helpers.CreateActionList(
                                new ContextActionSavingThrow()
                                {
                                    m_ConditionalDCIncrease = new ContextActionSavingThrow.ConditionalDCIncrease[0],
                                    FromBuff = false,
                                    Type = SavingThrowType.Will,
                                    UseDCFromContextSavingThrow = true,
                                    CustomDC = 50,
                                    HasCustomDC = true,
                                    Actions = Helpers.CreateActionList(
                                        new ContextActionConditionalSaved()
                                        {
                                            Succeed = Helpers.CreateActionList(
                                                new ContextActionApplyBuff()
                                                {
                                                    Permanent = false,
                                                    m_Buff = HaremMagnetImmunity.ToReference<BlueprintBuffReference>(),
                                                    DurationValue = new ContextDurationValue()
                                                    {
                                                        Rate = DurationRate.Hours,
                                                        DiceType = DiceType.Zero,
                                                        DiceCountValue = 0,
                                                        BonusValue = new ContextValue()
                                                        {
                                                            ValueType = ContextValueType.Simple,
                                                            Value = 24,
                                                            ValueRank = AbilityRankType.Default
                                                        },
                                                        m_IsExtendable = true
                                                    },
                                                    UseDurationSeconds = false,
                                                    DurationSeconds = 0,
                                                    IsFromSpell = false,
                                                    ToCaster = false,
                                                    AsChild = false,
                                                }),
                                            Failed = Helpers.CreateActionList(
                                                new ContextActionApplyBuff()
                                                {
                                                    Permanent = false,
                                                    m_Buff = HaremMagnetEffect.ToReference<BlueprintBuffReference>(),
                                                    DurationValue = new ContextDurationValue()
                                                    {
                                                        Rate = DurationRate.Rounds,
                                                        DiceType = DiceType.D4,
                                                        DiceCountValue = 5,
                                                        BonusValue = new ContextValue(),
                                                        m_IsExtendable = true
                                                    },
                                                    UseDurationSeconds = false,
                                                    DurationSeconds = 0,
                                                    IsFromSpell = false,
                                                    ToCaster = false,
                                                    AsChild = false,
                                                })
                                        }
                                    )
                                }),
                            IfFalse = Helpers.CreateActionList(),
                        });
                });
                bp.AddComponent<AbilityTargetsAround>(c => {
                    c.m_Radius = new Feet() { m_Value = 60 };
                    c.m_TargetType = TargetType.Enemy;
                    c.m_Condition = new ConditionsChecker()
                    {
                        Conditions = new Condition[0]
                    };
                });
                bp.AddComponent<ContextSetAbilityParams>(c => {
                    c.Add10ToDC = false;
                    c.DC = 50;
                });
                bp.m_Icon = Icon_Harem;
                bp.Type = AbilityType.Supernatural;
                bp.Range = AbilityRange.Personal;
                bp.CanTargetPoint = false;
                bp.CanTargetEnemies = true;
                bp.CanTargetFriends = false;
                bp.CanTargetSelf = true;
                bp.EffectOnAlly = AbilityEffectOnUnit.None;
                bp.EffectOnEnemy = AbilityEffectOnUnit.None;
                bp.Animation = UnitAnimationActionCastSpell.CastAnimationStyle.Self;
                bp.ActionType = UnitCommand.CommandType.Free;
                bp.AvailableMetamagic = Metamagic.Reach;
                bp.m_TargetMapObjects = false;
                bp.LocalizedDuration = Helpers.CreateString($"{bp.name}.Duration", "5d4 rounds");
                bp.LocalizedSavingThrow = Helpers.CreateString($"{bp.name}.SavingThrow", "Will negates");
            });
            var HaremMagnetFeature = Helpers.CreateBlueprint<BlueprintFeature>("HaremMagnetFeature", bp => {
                bp.SetName("Harem Magnet");
                bp.SetDescription("At 17th Level, the Isekai Protagonist gains the ability to attract anyone. As a {g|Encyclopedia:Free_Action}free action{/g}, enemies within 60 feet who fails a {g|Encyclopedia:DC}DC{/g} 50 {g|Encyclopedia:Saving_Throw}Will save{/g} loses any immunity to mind-affecting effects, charm effects, and compulsion effects, and becomes fascinated by the Isekai Protagonist for {g|Encyclopedia:Dice}5d4{/g} {g|Encyclopedia:Combat_Round}rounds{/g}. Creatures that succeed at this saving throw are immune to this ability for 24 hours.");
                bp.m_Icon = Icon_Harem;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { HaremMagnetAbility.ToReference<BlueprintUnitFactReference>() };
                });
            });
            // Otherworldly Stamina
            var OtherworldlyStamina = Helpers.CreateBlueprint<BlueprintFeature>("OtherworldlyStamina", bp => {
                bp.SetName("Otherworldly Stamina");
                bp.SetDescription("At 15th Level, the Isekai Protagonist becomes immune to fatigue and exhaustion.");
                bp.m_Icon = Icon_Bravery;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Fatigued;
                });
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Exhausted;
                });
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.Fatigue | SpellDescriptor.Exhausted;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = SpellDescriptor.Fatigue | SpellDescriptor.Exhausted;
                });
            });
            // Signature Attack
            var SignatureAttack = Helpers.CreateBlueprint<BlueprintFeature>("SignatureAttack", bp => {
                bp.SetName("Signature Attack");
                bp.SetDescription("At 6th level, the Isekai Protagonist gains a luck bonus to {g|Encyclopedia:BAB}attack{/g} equal to 1/2 their character level.");
                bp.m_DescriptionShort = Helpers.CreateString("PlotArmor.DescriptionShort", "Isekai Protagonists gain a luck bonus to {g|Encyclopedia:BAB}attack{/g} equal to 1/2 their character level.");
                bp.m_Icon = Icon_SwordSaintWeaponMastery;
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Luck;
                    c.Stat = StatType.AdditionalAttackBonus;
                    c.Value = new ContextValue()
                    {
                        ValueType = ContextValueType.Rank,
                        ValueRank = AbilityRankType.StatBonus
                    };
                });
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.StatBonus;
                    c.m_BaseValueType = ContextRankBaseValueType.CharacterLevel;
                    c.m_Progression = ContextRankProgression.OnePlusDiv2;
                });
                bp.IsClassFeature = true;
                bp.ReapplyOnLevelUp = true;
            });
            // Fighter Training
            var IsekaiFighterTraining = Helpers.CreateBlueprint<BlueprintFeature>("IsekaiFighterTraining", bp => {
                bp.SetName("Fighter Training");
                bp.SetDescription("At 3rd level, the Isekai Protagonist counts their class level as his fighter level for the purpose of qualifying for {g|Encyclopedia:Feat}feats{/g}. If they have levels in fighter, these levels stack.");
                bp.m_DescriptionShort = Helpers.CreateString("PlotArmor.DescriptionShort", "The Isekai Protagonist counts their class level as his fighter level for the purpose of qualifying for {g|Encyclopedia:Feat}feats{/g}. If they have levels in fighter, these levels stack.");
                bp.m_Icon = Icon_SwordSaintFighterTraining;
                bp.AddComponent<ClassLevelsForPrerequisites>(c => {
                    c.m_FakeClass = FighterClass.ToReference<BlueprintCharacterClassReference>();
                    c.m_ActualClass = IsekaiProtagonistClass.ToReference<BlueprintCharacterClassReference>();
                    c.Modifier = 1.0;
                    c.Summand = 0;
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
            // Fast Movement
            var IsekaiFastMovement = Helpers.CreateBlueprint<BlueprintFeature>("IsekaiFastMovement", bp => {
                bp.SetName("Fast Movement");
                bp.SetDescription("At 8th level, the Isekai Protagonist gains a +10 competence {g|Encyclopedia:Bonus}bonus{/g} to their base {g|Encyclopedia:Speed}speed{/g}.");
                bp.m_DescriptionShort = Helpers.CreateString("PlotArmor.DescriptionShort", "The Isekai Protagonist gains a +10 enhancement {g|Encyclopedia:Bonus}bonus{/g} to their base {g|Encyclopedia:Speed}speed{/g}.");
                bp.m_Icon = Icon_FastMovement;
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Competence;
                    c.Stat = StatType.Speed;
                    c.Value = 10;
                });
                bp.IsClassFeature = true;
            });
            // Quick-Footed
            var IsekaiQuickFooted = Helpers.CreateBlueprint<BlueprintFeature>("IsekaiQuickFooted", bp => {
                bp.SetName("Quick-Footed");
                bp.SetDescription("At 15th level, the Isekai Protagonist gains a competence {g|Encyclopedia:Bonus}bonus{/g} to their {g|Encyclopedia:Initiative}initiative{/g} {g|Encyclopedia:Check}checks{/g} equal to their {g|Encyclopedia:Charisma}Charisma{/g} modifier (minimum 1).");
                bp.m_DescriptionShort = Helpers.CreateString("PlotArmor.DescriptionShort", "The Isekai Protagonist gains a competence {g|Encyclopedia:Bonus}bonus{/g} to their {g|Encyclopedia:Initiative}initiative{/g} {g|Encyclopedia:Check}checks{/g} equal to their {g|Encyclopedia:Charisma}Charisma{/g} modifier (minimum 1).");
                bp.m_Icon = Icon_ExpeditiousRetreat;
                bp.AddComponent<DerivativeStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Competence;
                    c.BaseStat = StatType.Charisma;
                    c.DerivativeStat = StatType.Initiative;
                });
                bp.AddComponent<RecalculateOnStatChange>(c => {
                    c.Stat = StatType.Charisma;
                });
                bp.IsClassFeature = true;
            });
            // Friendly Aura
            var Icon_Friendly_Aura = AssetLoader.LoadInternal("Features", "ICON_FRIENDLY_AURA.png");
            var FriendlyAuraEffectBuff = Helpers.CreateBlueprint<BlueprintBuff>("FriendlyAuraEffectBuff", bp => {
                bp.SetName("Friendly Aura");
                bp.SetDescription("At 9th level, enemies within 40 feet of the Isekai Protagonist take a –4 penalty on attack {g|Encyclopedia:Dice}rolls{/g}.");
                bp.IsClassFeature = true;
                bp.m_Icon = Icon_Friendly_Aura;
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Penalty;
                    c.Stat = StatType.AdditionalAttackBonus;
                    c.Value = -4;
                });
            });
            var FriendlyAuraArea = Helpers.CreateBlueprint<BlueprintAbilityAreaEffect>("FriendlyAuraArea", bp => {
                bp.m_TargetType = BlueprintAbilityAreaEffect.TargetType.Enemy;
                bp.SpellResistance = false;
                bp.AggroEnemies = false;
                bp.AffectEnemies = true;
                bp.Shape = AreaEffectShape.Cylinder;
                bp.Size = new Feet() { m_Value = 40 };
                bp.Fx = new PrefabLink();
                bp.AddComponent(AuraUtils.CreateUnconditionalAuraEffect(FriendlyAuraEffectBuff.ToReference<BlueprintBuffReference>()));
            });
            var FriendlyAuraBuff = Helpers.CreateBlueprint<BlueprintBuff>("FriendlyAuraBuff", bp => {
                bp.SetName("Friendly Aura");
                bp.SetDescription("At 9th level, enemies within 40 feet of the Isekai Protagonist take a –4 penalty on attack {g|Encyclopedia:Dice}rolls{/g}.");
                bp.m_Icon = Icon_Friendly_Aura;
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.HiddenInUi;
                bp.AddComponent<AddAreaEffect>(c => {
                    c.m_AreaEffect = FriendlyAuraArea.ToReference<BlueprintAbilityAreaEffectReference>();
                });
            });
            var FriendlyAuraFeature = Helpers.CreateBlueprint<BlueprintFeature>("FriendlyAuraFeature", bp => {
                bp.SetName("Friendly Aura");
                bp.SetDescription("At 9th level, enemies within 40 feet of the Isekai Protagonist take a –4 penalty on attack {g|Encyclopedia:Dice}rolls{/g}.");
                bp.m_Icon = Icon_Friendly_Aura;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.AddComponent<AuraFeatureComponent>(c => {
                    c.m_Buff = FriendlyAuraBuff.ToReference<BlueprintBuffReference>();
                });
            });
            // Capstone
            var Icon_TrueMainCharacter = AssetLoader.LoadInternal("Features", "ICON_TRUE_MAIN_CHARACTER.png");
            var TrueMainCharacter = Helpers.CreateBlueprint<BlueprintFeature>("TrueMainCharacter", bp => {
                bp.SetName("True Main Character");
                bp.SetDescription("You are the main character of this world. Your attacks ignore {g|Encyclopedia:Damage_Reduction}damage reduction{/g} and immunity to {g|Encyclopedia:Critical}critical hits{/g}. Your critical threats are also automatically confirmed. The {g|Encyclopedia:Spell}spells{/g} you cast ignore {g|Encyclopedia:Spell_Resistance}spell resistance{/g} and spell immunity.");
                bp.m_Icon = Icon_TrueMainCharacter;
                bp.AddComponent<IgnoreSpellImmunity>();
                bp.AddComponent<IgnoreSpellResistanceForSpells>();
                bp.AddComponent<IgnoreDamageReductionOnAttack>();
                bp.AddComponent<IgnoreCritImmunity>();
                bp.AddComponent<InitiatorCritAutoconfirm>();
                bp.IsClassFeature = true;
            });
            // Character development feats
            var Icon_CharacterDevelopment_1 = AssetLoader.LoadInternal("Features", "ICON_POSITIVE_SHIELD.png");
            var Icon_CharacterDevelopment_2 = AssetLoader.LoadInternal("Features", "ICON_NEGATIVE_SHIELD.png");
            var ImmunityToSneakAndCriticalHitsFeat = Helpers.CreateBlueprint<BlueprintFeature>("ImmunityToSneakAndCriticalHitsFeat", bp => {
                bp.SetName("Ultimate Protection");
                bp.SetDescription("You gain immunity to Sneak attack damage and {g|Encyclopedia:Critical}critical hits{/g}.");
                bp.m_Icon = Icon_MageArmor;
                bp.AddComponent<AddImmunityToCriticalHits>();
                bp.AddComponent<AddImmunityToPrecisionDamage>();
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
            var ImmunityToAbilityScoreDamageAndEnergyDrainFeat = Helpers.CreateBlueprint<BlueprintFeature>("ImmunityToAbilityScoreDamageAndEnergyDrainFeat", bp => {
                bp.SetName("Steadfast Vigour");
                bp.SetDescription("You gain immunity to {g|Encyclopedia:Ability_Scores}ability score{/g} {g|Encyclopedia:Damage}damage{/g} and energy drain.");
                bp.m_Icon = Icon_DeathWard;
                bp.AddComponent<AddImmunityToAbilityScoreDamage>();
                bp.AddComponent<AddImmunityToEnergyDrain>();
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });

            var VulnerabilityAcidFeat = Helpers.CreateBlueprint<BlueprintFeature>("VulnerabilityAcidFeat", bp => {
                bp.SetName("Acid Vulnerability");
                bp.SetDescription("You are vulnerable to Acid.");
                bp.m_Icon = Icon_AcidSplash;
                bp.AddComponent<AddEnergyVulnerability>(c => {
                    c.Type = DamageEnergyType.Acid;
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
            var VulnerabilityColdFeat = Helpers.CreateBlueprint<BlueprintFeature>("VulnerabilityColdFeat", bp => {
                bp.SetName("Cold Vulnerability");
                bp.SetDescription("You are vulnerable to Cold.");
                bp.m_Icon = Icon_IceStorm;
                bp.AddComponent<AddEnergyVulnerability>(c => {
                    c.Type = DamageEnergyType.Cold;
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
            var VulnerabilityElectricityFeat = Helpers.CreateBlueprint<BlueprintFeature>("VulnerabilityElectricityFeat", bp => {
                bp.SetName("Electricity Vulnerability");
                bp.SetDescription("You are vulnerable to Electricity.");
                bp.m_Icon = Icon_LightningBolt;
                bp.AddComponent<AddEnergyVulnerability>(c => {
                    c.Type = DamageEnergyType.Electricity;
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
            var VulnerabilityFireFeat = Helpers.CreateBlueprint<BlueprintFeature>("VulnerabilityFireFeat", bp => {
                bp.SetName("Fire Vulnerability");
                bp.SetDescription("You are vulnerable to Fire.");
                bp.m_Icon = Icon_Fireball;
                bp.AddComponent<AddEnergyVulnerability>(c => {
                    c.Type = DamageEnergyType.Fire;
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
            var VulnerabilitySonicFeat = Helpers.CreateBlueprint<BlueprintFeature>("VulnerabilitySonicFeat", bp => {
                bp.SetName("Sonic Vulnerability");
                bp.SetDescription("You are vulnerable to Sonic.");
                bp.m_Icon = Icon_EarPiercingScream;
                bp.AddComponent<AddEnergyVulnerability>(c => {
                    c.Type = DamageEnergyType.Sonic;
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
            var ResistanceAcid10 = Helpers.CreateBlueprint<BlueprintFeature>("ResistanceAcid10", bp => {
                bp.SetName("Acid Resistance 10");
                bp.SetDescription("You gain acid resistance 10.");
                bp.m_Icon = Icon_ResistAcid;
                bp.AddComponent<AddDamageResistanceEnergy>(c => {
                    c.Type = DamageEnergyType.Acid;
                    c.Value = 10;
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
            var ResistanceCold10 = Helpers.CreateBlueprint<BlueprintFeature>("ResistanceCold10", bp => {
                bp.SetName("Cold Resistance 10");
                bp.SetDescription("You gain cold resistance 10.");
                bp.m_Icon = Icon_ResistCold;
                bp.AddComponent<AddDamageResistanceEnergy>(c => {
                    c.Type = DamageEnergyType.Cold;
                    c.Value = 10;
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
            var ResistanceElectricity10 = Helpers.CreateBlueprint<BlueprintFeature>("ResistanceElectricity10", bp => {
                bp.SetName("Electricity Resistance 10");
                bp.SetDescription("You gain electricity resistance 10.");
                bp.m_Icon = Icon_ResistElectricity;
                bp.AddComponent<AddDamageResistanceEnergy>(c => {
                    c.Type = DamageEnergyType.Electricity;
                    c.Value = 10;
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
            var ResistanceFire10 = Helpers.CreateBlueprint<BlueprintFeature>("ResistanceFire10", bp => {
                bp.SetName("Fire Resistance 10");
                bp.SetDescription("You gain fire resistance 10.");
                bp.m_Icon = Icon_ResistFire;
                bp.AddComponent<AddDamageResistanceEnergy>(c => {
                    c.Type = DamageEnergyType.Fire;
                    c.Value = 10;
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
            var ResistanceSonic10 = Helpers.CreateBlueprint<BlueprintFeature>("ResistanceSonic10", bp => {
                bp.SetName("Sonic Resistance 10");
                bp.SetDescription("You gain sonic resistance 10.");
                bp.m_Icon = Icon_ResistSonic;
                bp.AddComponent<AddDamageResistanceEnergy>(c => {
                    c.Type = DamageEnergyType.Sonic;
                    c.Value = 10;
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
            var ImmunityToAcidFeat = Helpers.CreateBlueprint<BlueprintFeature>("ImmunityToAcidFeat", bp => {
                bp.SetName("Acid Immunity");
                bp.SetDescription("You gain immunity to Acid.");
                bp.m_Icon = Icon_ProtectionFromAcid;
                bp.AddComponent<AddEnergyImmunity>(c => {
                    c.Type = DamageEnergyType.Acid;
                });
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.Acid;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = SpellDescriptor.Acid;
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
            var ImmunityToColdFeat = Helpers.CreateBlueprint<BlueprintFeature>("ImmunityToColdFeat", bp => {
                bp.SetName("Cold Immunity");
                bp.SetDescription("You gain immunity to Cold.");
                bp.m_Icon = Icon_ProtectionFromCold;
                bp.AddComponent<AddEnergyImmunity>(c => {
                    c.Type = DamageEnergyType.Cold;
                });
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.Cold;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = SpellDescriptor.Cold;
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
            var ImmunityToElectricityFeat = Helpers.CreateBlueprint<BlueprintFeature>("ImmunityToElectricityFeat", bp => {
                bp.SetName("Electricity Immunity");
                bp.SetDescription("You gain immunity to Electricity.");
                bp.m_Icon = Icon_ProtectionFromElectricity;
                bp.AddComponent<AddEnergyImmunity>(c => {
                    c.Type = DamageEnergyType.Electricity;
                });
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.Electricity;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = SpellDescriptor.Electricity;
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
            var ImmunityToFireFeat = Helpers.CreateBlueprint<BlueprintFeature>("ImmunityToFireFeat", bp => {
                bp.SetName("Fire Immunity");
                bp.SetDescription("You gain immunity to Fire.");
                bp.m_Icon = Icon_ProtectionFromFire;
                bp.AddComponent<AddEnergyImmunity>(c => {
                    c.Type = DamageEnergyType.Fire;
                });
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.Fire;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = SpellDescriptor.Fire;
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
            var ImmunityToSonicFeat = Helpers.CreateBlueprint<BlueprintFeature>("ImmunityToSonicFeat", bp => {
                bp.SetName("Sonic Immunity");
                bp.SetDescription("You gain immunity to Sonic.");
                bp.m_Icon = Icon_ProtectionFromSonic;
                bp.AddComponent<AddEnergyImmunity>(c => {
                    c.Type = DamageEnergyType.Sonic;
                });
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.Sonic;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = SpellDescriptor.Sonic;
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });

            // Story Arcs
            var HopelessBackstory = Helpers.CreateBlueprint<BlueprintFeature>("HopelessBackstory", bp => {
                bp.SetName("Hopeless Backstory");
                bp.SetDescription("You were a hopeless and untalented side character in the past, envious of what others had which you did not. Your inner insecurities leave you vulnerable to toxicity.\n" +
                    "At 1st level, you are vulnerable to acid.\n" +
                    "At 4th level, you are no longer vulnerable to acid.\n" +
                    "At 7th level, you gain acid resistance 10.\n" +
                    "At 10th level, you are immune to acid.\n");
                bp.m_Icon = Icon_PredictionOfFailure;
                bp.AddComponent<AddFeatureOnClassLevel>(c => {
                    c.Level = 4;
                    c.BeforeThisLevel = true;
                    c.m_Feature = VulnerabilityAcidFeat.ToReference<BlueprintFeatureReference>();
                    c.m_Class = IsekaiProtagonistClass.ToReference<BlueprintCharacterClassReference>();
                    c.m_AdditionalClasses = new BlueprintCharacterClassReference[0];
                    c.m_Archetypes = new BlueprintArchetypeReference[0];
                });
                bp.AddComponent<AddFeatureOnClassLevel>(c => {
                    c.Level = 7;
                    c.BeforeThisLevel = false;
                    c.m_Feature = ResistanceAcid10.ToReference<BlueprintFeatureReference>();
                    c.m_Class = IsekaiProtagonistClass.ToReference<BlueprintCharacterClassReference>();
                    c.m_AdditionalClasses = new BlueprintCharacterClassReference[0];
                    c.m_Archetypes = new BlueprintArchetypeReference[0];
                });
                bp.AddComponent<AddFeatureOnClassLevel>(c => {
                    c.Level = 10;
                    c.BeforeThisLevel = false;
                    c.m_Feature = ImmunityToAcidFeat.ToReference<BlueprintFeatureReference>();
                    c.m_Class = IsekaiProtagonistClass.ToReference<BlueprintCharacterClassReference>();
                    c.m_AdditionalClasses = new BlueprintCharacterClassReference[0];
                    c.m_Archetypes = new BlueprintArchetypeReference[0];
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
            var TragicBackstory = Helpers.CreateBlueprint<BlueprintFeature>("TragicBackstory", bp => {
                bp.SetName("Tragic Backstory");
                bp.SetDescription("You had a heart-breaking and emotionally tragic past, leaving you vulnerable to the coldness in your heart.\n" +
                    "At 1st level, you are vulnerable to cold.\n" +
                    "At 4th level, you are no longer vulnerable to cold.\n" +
                    "At 7th level, you gain cold resistance 10.\n" +
                    "At 10th level, you are immune to cold.\n");
                bp.m_Icon = Icon_CrushingDespair;
                bp.AddComponent<AddFeatureOnClassLevel>(c => {
                    c.Level = 4;
                    c.BeforeThisLevel = true;
                    c.m_Feature = VulnerabilityColdFeat.ToReference<BlueprintFeatureReference>();
                    c.m_Class = IsekaiProtagonistClass.ToReference<BlueprintCharacterClassReference>();
                    c.m_AdditionalClasses = new BlueprintCharacterClassReference[0];
                    c.m_Archetypes = new BlueprintArchetypeReference[0];
                });
                bp.AddComponent<AddFeatureOnClassLevel>(c => {
                    c.Level = 7;
                    c.BeforeThisLevel = false;
                    c.m_Feature = ResistanceCold10.ToReference<BlueprintFeatureReference>();
                    c.m_Class = IsekaiProtagonistClass.ToReference<BlueprintCharacterClassReference>();
                    c.m_AdditionalClasses = new BlueprintCharacterClassReference[0];
                    c.m_Archetypes = new BlueprintArchetypeReference[0];
                });
                bp.AddComponent<AddFeatureOnClassLevel>(c => {
                    c.Level = 10;
                    c.BeforeThisLevel = false;
                    c.m_Feature = ImmunityToColdFeat.ToReference<BlueprintFeatureReference>();
                    c.m_Class = IsekaiProtagonistClass.ToReference<BlueprintCharacterClassReference>();
                    c.m_AdditionalClasses = new BlueprintCharacterClassReference[0];
                    c.m_Archetypes = new BlueprintArchetypeReference[0];
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
            var PainfulBackstory = Helpers.CreateBlueprint<BlueprintFeature>("PainfulBackstory", bp => {
                bp.SetName("Painful Backstory");
                bp.SetDescription("You were subjected to unspeakable creulty in the past, leaving you traumatised to even the slight shock of pain.\n" +
                    "At 1st level, you are vulnerable to electricity.\n" +
                    "At 4th level, you are no longer vulnerable to electricity.\n" +
                    "At 7th level, you gain electricity resistance 10.\n" +
                    "At 10th level, you are immune to electricity.\n");
                bp.m_Icon = Icon_Daze;
                bp.AddComponent<AddFeatureOnClassLevel>(c => {
                    c.Level = 4;
                    c.BeforeThisLevel = true;
                    c.m_Feature = VulnerabilityElectricityFeat.ToReference<BlueprintFeatureReference>();
                    c.m_Class = IsekaiProtagonistClass.ToReference<BlueprintCharacterClassReference>();
                    c.m_AdditionalClasses = new BlueprintCharacterClassReference[0];
                    c.m_Archetypes = new BlueprintArchetypeReference[0];
                });
                bp.AddComponent<AddFeatureOnClassLevel>(c => {
                    c.Level = 7;
                    c.BeforeThisLevel = false;
                    c.m_Feature = ResistanceElectricity10.ToReference<BlueprintFeatureReference>();
                    c.m_Class = IsekaiProtagonistClass.ToReference<BlueprintCharacterClassReference>();
                    c.m_AdditionalClasses = new BlueprintCharacterClassReference[0];
                    c.m_Archetypes = new BlueprintArchetypeReference[0];
                });
                bp.AddComponent<AddFeatureOnClassLevel>(c => {
                    c.Level = 10;
                    c.BeforeThisLevel = false;
                    c.m_Feature = ImmunityToElectricityFeat.ToReference<BlueprintFeatureReference>();
                    c.m_Class = IsekaiProtagonistClass.ToReference<BlueprintCharacterClassReference>();
                    c.m_AdditionalClasses = new BlueprintCharacterClassReference[0];
                    c.m_Archetypes = new BlueprintArchetypeReference[0];
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
            var VengefulBackstory = Helpers.CreateBlueprint<BlueprintFeature>("VengefulBackstory", bp => {
                bp.SetName("Vengeful Backstory");
                bp.SetDescription("You were betrayed by a some-one you trusted, leaving your heart full of vengeance and malevolence. You decide to fight fire with more fire, even if you end up being burnt.\n" +
                    "At 1st level, you are vulnerable to fire.\n" +
                    "At 4th level, you are no longer vulnerable to fire.\n" +
                    "At 7th level, you gain fire resistance 10.\n" +
                    "At 10th level, you are immune to fire.\n");
                bp.m_Icon = Icon_Rage;
                bp.AddComponent<AddFeatureOnClassLevel>(c => {
                    c.Level = 4;
                    c.BeforeThisLevel = true;
                    c.m_Feature = VulnerabilityFireFeat.ToReference<BlueprintFeatureReference>();
                    c.m_Class = IsekaiProtagonistClass.ToReference<BlueprintCharacterClassReference>();
                    c.m_AdditionalClasses = new BlueprintCharacterClassReference[0];
                    c.m_Archetypes = new BlueprintArchetypeReference[0];
                });
                bp.AddComponent<AddFeatureOnClassLevel>(c => {
                    c.Level = 7;
                    c.BeforeThisLevel = false;
                    c.m_Feature = ResistanceFire10.ToReference<BlueprintFeatureReference>();
                    c.m_Class = IsekaiProtagonistClass.ToReference<BlueprintCharacterClassReference>();
                    c.m_AdditionalClasses = new BlueprintCharacterClassReference[0];
                    c.m_Archetypes = new BlueprintArchetypeReference[0];
                });
                bp.AddComponent<AddFeatureOnClassLevel>(c => {
                    c.Level = 10;
                    c.BeforeThisLevel = false;
                    c.m_Feature = ImmunityToFireFeat.ToReference<BlueprintFeatureReference>();
                    c.m_Class = IsekaiProtagonistClass.ToReference<BlueprintCharacterClassReference>();
                    c.m_AdditionalClasses = new BlueprintCharacterClassReference[0];
                    c.m_Archetypes = new BlueprintArchetypeReference[0];
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
            var ForsakenBackstory = Helpers.CreateBlueprint<BlueprintFeature>("ForsakenBackstory", bp => {
                bp.SetName("Forsaken Backstory");
                bp.SetDescription("Your past life was lonely and devoid. Your only friend was the sound of silence.\n" +
                    "At 1st level, you are vulnerable to sonic.\n" +
                    "At 4th level, you are no longer vulnerable to sonic.\n" +
                    "At 7th level, you gain sonic resistance 10.\n" +
                    "At 10th level, you are immune to sonic.\n");
                bp.m_Icon = Icon_OverwhelmingGrief;
                bp.AddComponent<AddFeatureOnClassLevel>(c => {
                    c.Level = 4;
                    c.BeforeThisLevel = true;
                    c.m_Feature = VulnerabilitySonicFeat.ToReference<BlueprintFeatureReference>();
                    c.m_Class = IsekaiProtagonistClass.ToReference<BlueprintCharacterClassReference>();
                    c.m_AdditionalClasses = new BlueprintCharacterClassReference[0];
                    c.m_Archetypes = new BlueprintArchetypeReference[0];
                });
                bp.AddComponent<AddFeatureOnClassLevel>(c => {
                    c.Level = 7;
                    c.BeforeThisLevel = false;
                    c.m_Feature = ResistanceSonic10.ToReference<BlueprintFeatureReference>();
                    c.m_Class = IsekaiProtagonistClass.ToReference<BlueprintCharacterClassReference>();
                    c.m_AdditionalClasses = new BlueprintCharacterClassReference[0];
                    c.m_Archetypes = new BlueprintArchetypeReference[0];
                });
                bp.AddComponent<AddFeatureOnClassLevel>(c => {
                    c.Level = 10;
                    c.BeforeThisLevel = false;
                    c.m_Feature = ImmunityToSonicFeat.ToReference<BlueprintFeatureReference>();
                    c.m_Class = IsekaiProtagonistClass.ToReference<BlueprintCharacterClassReference>();
                    c.m_AdditionalClasses = new BlueprintCharacterClassReference[0];
                    c.m_Archetypes = new BlueprintArchetypeReference[0];
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });

            // Character Development Selection
            var BackstorySelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>("BackstorySelection", bp => {
                bp.SetName("Backstory");
                bp.SetDescription("At 1st level, you get to select a backstory. These will develop over time as you increase your level.");
                bp.m_Icon = Icon_Discovery;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.m_AllFeatures = new BlueprintFeatureReference[] {
                    HopelessBackstory.ToReference<BlueprintFeatureReference>(),
                    TragicBackstory.ToReference<BlueprintFeatureReference>(),
                    PainfulBackstory.ToReference<BlueprintFeatureReference>(),
                    VengefulBackstory.ToReference<BlueprintFeatureReference>(),
                    ForsakenBackstory.ToReference<BlueprintFeatureReference>(),
                };
                bp.m_Features = new BlueprintFeatureReference[] {
                    HopelessBackstory.ToReference<BlueprintFeatureReference>(),
                    TragicBackstory.ToReference<BlueprintFeatureReference>(),
                    PainfulBackstory.ToReference<BlueprintFeatureReference>(),
                    VengefulBackstory.ToReference<BlueprintFeatureReference>(),
                    ForsakenBackstory.ToReference<BlueprintFeatureReference>(),
                };
            });
            var CharacterDevelopmentSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>("CharacterDevelopmentSelection", bp => {
                bp.SetName("Character Development");
                bp.SetDescription("At 1st level, and every three levels thereafter, you can select one character development.");
                bp.m_DescriptionShort = Helpers.CreateString("PlotArmor.DescriptionShort", "Isekai Protagonists gain character development feats. These feats include immunity to {g|Encyclopedia:Critical}critical hits{/g}, {g|Encyclopedia:Energy_Damage}energy damage{/g}, or conditions.");
                bp.m_Icon = Icon_Discovery;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.m_AllFeatures = new BlueprintFeatureReference[] {
                    ImmunityToSneakAndCriticalHitsFeat.ToReference<BlueprintFeatureReference>(),
                    ImmunityToAbilityScoreDamageAndEnergyDrainFeat.ToReference<BlueprintFeatureReference>(),
                    ImmunityToAcidFeat.ToReference<BlueprintFeatureReference>(),
                    ImmunityToColdFeat.ToReference<BlueprintFeatureReference>(),
                    ImmunityToFireFeat.ToReference<BlueprintFeatureReference>(),
                    ImmunityToElectricityFeat.ToReference<BlueprintFeatureReference>(),
                    ImmunityToSonicFeat.ToReference<BlueprintFeatureReference>(),
                };
                bp.m_Features = new BlueprintFeatureReference[] {
                    ImmunityToSneakAndCriticalHitsFeat.ToReference<BlueprintFeatureReference>(),
                    ImmunityToAbilityScoreDamageAndEnergyDrainFeat.ToReference<BlueprintFeatureReference>(),
                    ImmunityToAcidFeat.ToReference<BlueprintFeatureReference>(),
                    ImmunityToColdFeat.ToReference<BlueprintFeatureReference>(),
                    ImmunityToFireFeat.ToReference<BlueprintFeatureReference>(),
                    ImmunityToElectricityFeat.ToReference<BlueprintFeatureReference>(),
                    ImmunityToSonicFeat.ToReference<BlueprintFeatureReference>(),
                };
            });

            //// Class Signature Features
            // Bonus Feats
            var IsekaiProtagonistBonusFeat = Helpers.CreateBlueprint<BlueprintFeature>("IsekaiProtagonistBonusFeat", bp => {
                bp.SetName("Bonus Feat");
                bp.SetDescription("Isekai Protagonists gain twice as many {g|Encyclopedia:Feat}feats{/g} as the other classes.");
                bp.m_DescriptionShort = Helpers.CreateString("IsekaiProtagonistBonusFeat.DescriptionShort", "Isekai Protagonists gain twice as many {g|Encyclopedia:Feat}feats{/g} as the other classes.");
                bp.m_Icon = BasicFeatSelection.m_Icon;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
            var IsekaiProtagonistSneakFeat = Helpers.CreateBlueprint<BlueprintFeature>("IsekaiProtagonistSneakFeat", bp => {
                bp.SetName("Sneak Attack");
                bp.SetDescription("Most characters gain advantages when they {g|Encyclopedia:Flanking}flank{/g} an enemy, {g|Encyclopedia:Attack}attack{/g} an enemy who can't see them or enjoy a similar fortunate position. Isekai Protagonists deal a tremendous amount of additional {g|Encyclopedia:Damage}damage{/g} in such a situation.");
                bp.m_DescriptionShort = Helpers.CreateString("IsekaiProtagonistSneakFeat.DescriptionShort", "Most characters gain advantages when they {g|Encyclopedia:Flanking}flank{/g} an enemy, {g|Encyclopedia:Attack}attack{/g} an enemy who can't see them or enjoy a similar fortunate position. Isekai Protagonists deal a tremendous amount of additional {g|Encyclopedia:Damage}damage{/g} in such a situation.");
                bp.m_Icon = SneakAttack.m_Icon;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });

            // Signature Abilities
            IsekaiProtagonistClass.m_SignatureAbilities = new BlueprintFeatureReference[4] {
                    IsekaiProtagonistBonusFeat.ToReference<BlueprintFeatureReference>(),
                    IsekaiProtagonistSneakFeat.ToReference<BlueprintFeatureReference>(),
                    PlotArmor.ToReference<BlueprintFeatureReference>(),
                    CharacterDevelopmentSelection.ToReference<BlueprintFeatureReference>()
            };
            IsekaiProtagonistProgression.LevelEntries = new LevelEntry[20] {
                Helpers.LevelEntry(1, IsekaiProtagonistProficiencies, IsekaiProtagonistCantripsFeature, IsekaiProtagonistBonusFeatSelection, SneakAttack, BackstorySelection, PlotArmor),
                Helpers.LevelEntry(2, IsekaiProtagonistBonusFeatSelection, UncannyDodge),
                Helpers.LevelEntry(3, SneakAttack, IsekaiFighterTraining, Evasion),
                Helpers.LevelEntry(4, IsekaiProtagonistBonusFeatSelection, CharacterDevelopmentSelection),
                Helpers.LevelEntry(5, SneakAttack, ImprovedUncannyDodge),
                Helpers.LevelEntry(6, IsekaiProtagonistBonusFeatSelection, SignatureAttack),
                Helpers.LevelEntry(7, SneakAttack, CharacterDevelopmentSelection),
                Helpers.LevelEntry(8, IsekaiProtagonistBonusFeatSelection, IsekaiFastMovement),
                Helpers.LevelEntry(9, SneakAttack, FriendlyAuraFeature),
                Helpers.LevelEntry(10, IsekaiProtagonistBonusFeatSelection, CharacterDevelopmentSelection),
                Helpers.LevelEntry(11, SneakAttack, ImprovedEvasion),
                Helpers.LevelEntry(12, IsekaiProtagonistBonusFeatSelection),
                Helpers.LevelEntry(13, SneakAttack, CharacterDevelopmentSelection),
                Helpers.LevelEntry(14, IsekaiProtagonistBonusFeatSelection),
                Helpers.LevelEntry(15, SneakAttack, OtherworldlyStamina, IsekaiQuickFooted),
                Helpers.LevelEntry(16, IsekaiProtagonistBonusFeatSelection, CharacterDevelopmentSelection),
                Helpers.LevelEntry(17, SneakAttack, HaremMagnetFeature),
                Helpers.LevelEntry(18, IsekaiProtagonistBonusFeatSelection),
                Helpers.LevelEntry(19, SneakAttack, CharacterDevelopmentSelection),
                Helpers.LevelEntry(20, IsekaiProtagonistBonusFeatSelection, TrueMainCharacter)
            };
            IsekaiProtagonistProgression.UIGroups = new UIGroup[] {
                Helpers.CreateUIGroup(BackstorySelection, CharacterDevelopmentSelection),
                Helpers.CreateUIGroup(PlotArmor, IsekaiFighterTraining, SignatureAttack, FriendlyAuraFeature, OtherworldlyStamina, HaremMagnetFeature, TrueMainCharacter),
                Helpers.CreateUIGroup(UncannyDodge, ImprovedUncannyDodge, Evasion, ImprovedEvasion, IsekaiFastMovement, IsekaiQuickFooted),
            };
            IsekaiProtagonistProgression.m_UIDeterminatorsGroup = new BlueprintFeatureBaseReference[] {
                IsekaiProtagonistProficiencies.ToReference<BlueprintFeatureBaseReference>(),
                IsekaiProtagonistCantripsFeature.ToReference<BlueprintFeatureBaseReference>()
            };
            Helpers.RegisterClass(IsekaiProtagonistClass);
        }
    }
}