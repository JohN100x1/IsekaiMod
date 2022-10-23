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

        // Prebuild Features
        private static readonly BlueprintFeature PowerAttack = Resources.GetBlueprint<BlueprintFeature>("9972f33f977fc724c838e59641b2fca5");
        private static readonly BlueprintFeature CombatReflexes = Resources.GetBlueprint<BlueprintFeature>("0f8939ae6f220984e8fb568abbdfba95");
        private static readonly BlueprintFeature WeaponSpecializationScythe = Resources.GetBlueprint<BlueprintFeature>("d0a776a7998164d46a2100ed29004c0a");
        private static readonly BlueprintFeature Outflank = Resources.GetBlueprint<BlueprintFeature>("422dab7309e1ad343935f33a4d6e9f11");
        private static readonly BlueprintFeature WeaponFocusGreaterScythe = Resources.GetBlueprint<BlueprintFeature>("b03d4fdb4bd6353499c3e6318e3e2d66");
        private static readonly BlueprintFeature ImprovedInitiative = Resources.GetBlueprint<BlueprintFeature>("797f25d709f559546b29e7bcb181cc74");
        private static readonly BlueprintFeature IntimidatingProwess = Resources.GetBlueprint<BlueprintFeature>("d76497bfc48516e45a0831628f767a0f");
        private static readonly BlueprintFeature SpellPenetration = Resources.GetBlueprint<BlueprintFeature>("ee7dc126939e4d9438357fbd5980d459");
        private static readonly BlueprintFeature GreaterSpellPenetration = Resources.GetBlueprint<BlueprintFeature>("1978c3f91cfbbc24b9c9b0d017f4beec");
        private static readonly BlueprintFeature LightningReflexes = Resources.GetBlueprint<BlueprintFeature>("15e7da6645a7f3d41bdad7c8c4b9de1e");

        private static readonly BlueprintFeature Cleave = Resources.GetBlueprint<BlueprintFeature>("d809b6c4ff2aaff4fa70d712a70f7d7b");
        private static readonly BlueprintFeature CleavingFinish = Resources.GetBlueprint<BlueprintFeature>("59bd93899149fa44687ff4121389b3a9");
        private static readonly BlueprintFeature WeaponFocusScythe = Resources.GetBlueprint<BlueprintFeature>("9db0097ee1a4b4b4688f9a3190c23969");
        private static readonly BlueprintFeature DazzlingDisplay = Resources.GetBlueprint<BlueprintFeature>("bcbd674ec70ff6f4894bb5f07b6f4095");
        private static readonly BlueprintFeature ImprovedCriticalScythe = Resources.GetBlueprint<BlueprintFeature>("0fba06b436d498e46bbb598f8d8b2c83");
        private static readonly BlueprintFeature ShatterDefenses = Resources.GetBlueprint<BlueprintFeature>("61a17ccbbb3d79445b0926347ec07577");
        private static readonly BlueprintFeature WeaponSpecializationGreaterScythe = Resources.GetBlueprint<BlueprintFeature>("312a1650efbfb7849ab008bd4edc7d5d");
        private static readonly BlueprintFeature PenetratingStrike = Resources.GetBlueprint<BlueprintFeature>("308cd7dc4f10efd428f531bbf4f2823d");
        private static readonly BlueprintFeature GreaterPenetratingStrike = Resources.GetBlueprint<BlueprintFeature>("eb6eb946c68ef094f89c7633f5bfdc9b");
        private static readonly BlueprintFeature GreatFortitude = Resources.GetBlueprint<BlueprintFeature>("79042cb55f030614ea29956177977c52");
        private static readonly BlueprintFeature IronWill = Resources.GetBlueprint<BlueprintFeature>("175d1577bb6c9a04baf88eec99c66334");

        // Icons
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
        private static readonly Sprite Icon_Thoughtsense = Resources.GetBlueprint<BlueprintAbility>("8fb1a1670b6e1f84b89ea846f589b627").m_Icon;
        private static readonly Sprite Icon_LegendaryProportions = Resources.GetBlueprint<BlueprintAbility>("da1b292d91ba37948893cdbe9ea89e28").m_Icon;
        private static readonly Sprite Icon_Serenity = Resources.GetBlueprint<BlueprintAbility>("d316d3d94d20c674db2c24d7de96f6a7").m_Icon;
        private static readonly Sprite Icon_PureForm = Resources.GetBlueprint<BlueprintAbility>("33e53b74891b4c34ba6ee3baa322beeb").m_Icon;
        private static readonly Sprite Icon_SpellResistance = Resources.GetBlueprint<BlueprintAbility>("0a5ddfbcfb3989543ac7c936fc256889").m_Icon;
        private static readonly Sprite Icon_IronBody = Resources.GetBlueprint<BlueprintAbility>("198fcc43490993f49899ed086fe723c1").m_Icon;

        private static readonly Sprite Icon_SwordSaintWeaponMastery = Resources.GetBlueprint<BlueprintFeature>("5b31af13868166d4c9bb452f19277f19").m_Icon;
        private static readonly Sprite Icon_SwordSaintFighterTraining = Resources.GetBlueprint<BlueprintFeature>("9ab2ec65977cc524a99600babc7fe3b6").m_Icon;
        private static readonly Sprite Icon_FastMovement = Resources.GetBlueprint<BlueprintFeature>("d294a5dddd0120046aae7d4eb6cbc4fc").m_Icon;
        private static readonly Sprite Icon_Bravery = Resources.GetBlueprint<BlueprintFeature>("f6388946f9f472f4585591b80e9f2452").m_Icon;
        private static readonly Sprite Icon_PurityOfBody = Resources.GetBlueprint<BlueprintFeature>("9b02f77c96d6bba4daf9043eff876c76").m_Icon;
        private static readonly Sprite Icon_BurningRenewal = Resources.GetBlueprint<BlueprintFeature>("7cf2a6bf35c422e4ea219fcc2eb564f5").m_Icon;
        private static readonly Sprite Icon_SneakStab = Resources.GetBlueprint<BlueprintFeature>("df4f34f7cac73ab40986bc33f87b1a3c").m_Icon;
        private static readonly Sprite Icon_DextrousDuelist = Resources.GetBlueprint<BlueprintFeature>("b701196306bb4674bb902c9f1160180f").m_Icon;
        private static readonly Sprite Icon_PerfectStrike = Resources.GetBlueprint<BlueprintFeature>("9ff65b68c09567e48af9b33848b23323").m_Icon;
        private static readonly Sprite Icon_BladeSense = Resources.GetBlueprint<BlueprintFeature>("112bf4c6943097942b24eadfa750215f").m_Icon;

        private static readonly Sprite Icon_Discovery = Resources.GetBlueprint<BlueprintFeatureSelection>("cd86c437488386f438dcc9ae727ea2a6").m_Icon;

        public static void AddIsekaiProtagonistClass()
        {
            // TODO: refactor code
            // TODO: Add archetypes, Archetype ideas: God Emporer, Edge Lord
            // TODO: Add custom equipment

            // TODO: Add MythicAbilitySelection ability

            // Prebuild Selections
            var BackgroundNone = Resources.GetBlueprint<BlueprintFeature>("7d300f497584d9245ac24c062dce0bd6");
            var BackgroundBaseSelection = Resources.GetBlueprint<BlueprintFeatureSelection>("f926dabeee7f8a54db8f2010b323383c");

            var PitbornHeritage = Resources.GetBlueprint<BlueprintFeature>("c09ffb2657f6c2b41b5ed0ed607b362a");
            var TieflingHeritageSelection = Resources.GetBlueprint<BlueprintFeatureSelection>("c862fd0e4046d2d4d9702dd60474a181");

            var AngelHeritage = Resources.GetBlueprint<BlueprintFeature>("ceedc840b113c3348a2f32b434df5fef");
            var AasimarHeritageSelection = Resources.GetBlueprint<BlueprintFeatureSelection>("67aabcbce8f8ae643a9d08a6ca67cabd");

            var SkillFocusPhysique = Resources.GetBlueprint<BlueprintFeature>("9db907332bdaec1468cff3a99efef5b4");
            var Adaptibility = Resources.GetBlueprint<BlueprintFeatureSelection>("26a668c5a8c22354bac67bcd42e09a3f");

            // Used in Class
            var BasicFeatSelection = Resources.GetBlueprint<BlueprintFeatureSelection>("247a4068296e8be42890143f451b4b45");
            var AnimalClass = Resources.GetBlueprint<BlueprintCharacterClass>("4cd1757a0eea7694ba5c933729a53920");
            var FighterClass = Resources.GetBlueprint<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd");
            var MonkClass = Resources.GetBlueprint<BlueprintCharacterClass>("e8f21e5b58e0569468e420ebea456124");
            var AngelIncorporateSpellBook = Resources.GetBlueprint<BlueprintFeatureSelectMythicSpellbook>("e1fbb0e0e610a3a4d91e5e5284587939");
            var LichIncorporateSpellBook = Resources.GetBlueprint<BlueprintFeatureSelectMythicSpellbook>("3f16e9caf7c683c40884c7c455ed26af");

            // Spellbook
            var IsekaiProtagonistSpellList = Resources.GetModBlueprint<BlueprintSpellList>("IsekaiProtagonistSpellList");
            var IsekaiProtagonistSpellsPerDay = Helpers.CreateBlueprint<BlueprintSpellsTable>("IsekaiProtagonistSpellsPerDay", bp => {
                bp.Levels = new SpellsLevelEntry[29] {
                    new SpellsLevelEntry() { Count = new int[] { } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 6 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 12 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 18, 6 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 24, 12 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 24, 18, 6 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 30, 24, 6 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 30, 24, 12, 6 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 30, 30, 18, 6 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 30, 30, 18, 12, 6 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 30, 30, 24, 18, 6 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 30, 30, 24, 18, 12, 6 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 30, 30, 24, 24, 18, 6 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 30, 30, 24, 24, 18, 12, 6 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 30, 30, 24, 24, 24, 18, 6 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 30, 30, 24, 24, 24, 18, 12, 6 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 30, 30, 24, 24, 24, 24, 18, 6 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 30, 30, 24, 24, 24, 24, 18, 12, 6 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 30, 30, 24, 24, 24, 24, 24, 18, 6 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 30, 30, 24, 24, 24, 24, 24, 24, 12 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 30, 30, 24, 24, 24, 24, 24, 24, 20 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 30, 30, 24, 24, 24, 24, 24, 24, 20 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 30, 30, 24, 24, 24, 24, 24, 24, 20 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 30, 30, 24, 24, 24, 24, 24, 24, 20 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 30, 30, 24, 24, 24, 24, 24, 24, 20 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 30, 30, 24, 24, 24, 24, 24, 24, 20 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 30, 30, 24, 24, 24, 24, 24, 24, 20 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 30, 30, 24, 24, 24, 24, 24, 24, 20 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 30, 30, 24, 24, 24, 24, 24, 24, 20, 2 } }
                };
            });
            var IsekaiProtagonistSpellsKnown = Helpers.CreateBlueprint<BlueprintSpellsTable>("IsekaiProtagonistSpellsKnown", bp => {
                bp.Levels = new SpellsLevelEntry[21] {
                    new SpellsLevelEntry() { Count = new int[] { } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 6 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 12 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 18, 6 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 24, 12 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 24, 18, 6 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 30, 24, 6 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 30, 24, 12, 6 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 30, 30, 18, 6 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 30, 30, 18, 12, 6 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 30, 30, 24, 18, 6 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 30, 30, 24, 18, 12, 6 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 30, 30, 24, 24, 18, 6 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 30, 30, 24, 24, 18, 12, 6 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 30, 30, 24, 24, 24, 18, 6 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 30, 30, 24, 24, 24, 18, 12, 6 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 30, 30, 24, 24, 24, 24, 18, 6 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 30, 30, 24, 24, 24, 24, 18, 12, 6 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 30, 30, 24, 24, 24, 24, 24, 18, 6 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 30, 30, 24, 24, 24, 24, 24, 24, 12 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 30, 30, 24, 24, 24, 24, 24, 24, 20 } }
                };
            });
            var IsekaiProtagonistSpellbook = Helpers.CreateBlueprint<BlueprintSpellbook>("IsekaiProtagonistSpellbook", bp => {
                bp.Name = Helpers.CreateString("$IsekaiProtagonistSpellbook.Name", "Isekai Protagonist");
                bp.Spontaneous = true;
                bp.CastingAttribute = StatType.Charisma;
                bp.CantripsType = CantripsType.Cantrips;
                bp.IsArcane = false;
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
                bp.IsDivineCaster = true;
                bp.IsArcaneCaster = false;
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
            // Allow Spellbook to be merged with angel and lich
            AngelIncorporateSpellBook.m_AllowedSpellbooks = AngelIncorporateSpellBook.m_AllowedSpellbooks.AddToArray(IsekaiProtagonistSpellbook.ToReference<BlueprintSpellbookReference>());
            LichIncorporateSpellBook.m_AllowedSpellbooks = LichIncorporateSpellBook.m_AllowedSpellbooks.AddToArray(IsekaiProtagonistSpellbook.ToReference<BlueprintSpellbookReference>());

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
                bp.SetDescription("At 6th level, the Isekai Protagonist gains a luck bonus to {g|Encyclopedia:BAB}attack{/g} and damage rolls equal to their character level.");
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
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Luck;
                    c.Stat = StatType.AdditionalDamage;
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
            // Dark Aura
            var Icon_Dark_Aura = AssetLoader.LoadInternal("Features", "ICON_DARK_AURA.png");
            var DarkAuraEffectBuff = Helpers.CreateBlueprint<BlueprintBuff>("DarkAuraEffectBuff", bp => {
                bp.SetName("Dark Aura");
                bp.SetDescription("At 9th level, enemies within 40 feet of the God Emporer take a –4 penalty on attack {g|Encyclopedia:Dice}rolls{/g}, AC, and saving throws.");
                bp.IsClassFeature = true;
                bp.m_Icon = Icon_Dark_Aura;
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Penalty;
                    c.Stat = StatType.AdditionalAttackBonus;
                    c.Value = -4;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Penalty;
                    c.Stat = StatType.AC;
                    c.Value = -4;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Penalty;
                    c.Stat = StatType.SaveFortitude;
                    c.Value = -4;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Penalty;
                    c.Stat = StatType.SaveReflex;
                    c.Value = -4;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Penalty;
                    c.Stat = StatType.SaveWill;
                    c.Value = -4;
                });
            });
            var DarkAuraArea = Helpers.CreateBlueprint<BlueprintAbilityAreaEffect>("DarkAuraArea", bp => {
                bp.m_TargetType = BlueprintAbilityAreaEffect.TargetType.Enemy;
                bp.SpellResistance = false;
                bp.AggroEnemies = false;
                bp.AffectEnemies = true;
                bp.Shape = AreaEffectShape.Cylinder;
                bp.Size = new Feet() { m_Value = 40 };
                bp.Fx = new PrefabLink();
                bp.AddComponent(AuraUtils.CreateUnconditionalAuraEffect(DarkAuraEffectBuff.ToReference<BlueprintBuffReference>()));
            });
            var DarkAuraBuff = Helpers.CreateBlueprint<BlueprintBuff>("DarkAuraBuff", bp => {
                bp.SetName("Dark Aura");
                bp.SetDescription("At 9th level, enemies within 40 feet of the God Emporer take a –4 penalty on attack {g|Encyclopedia:Dice}rolls{/g}, AC, and saving throws.");
                bp.m_Icon = Icon_Dark_Aura;
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.HiddenInUi;
                bp.AddComponent<AddAreaEffect>(c => {
                    c.m_AreaEffect = DarkAuraArea.ToReference<BlueprintAbilityAreaEffectReference>();
                });
            });
            var DarkAuraFeature = Helpers.CreateBlueprint<BlueprintFeature>("DarkAuraFeature", bp => {
                bp.SetName("Dark Aura");
                bp.SetDescription("At 9th level, enemies within 40 feet of the God Emporer take a –4 penalty on attack {g|Encyclopedia:Dice}rolls{/g}, AC, and saving throws.");
                bp.m_Icon = Icon_Dark_Aura;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.AddComponent<AuraFeatureComponent>(c => {
                    c.m_Buff = DarkAuraBuff.ToReference<BlueprintBuffReference>();
                });
            });
            // Capstone
            var Icon_TrueMainCharacter = AssetLoader.LoadInternal("Features", "ICON_TRUE_MAIN_CHARACTER.png");
            var TrueMainCharacter = Helpers.CreateBlueprint<BlueprintFeature>("TrueMainCharacter", bp => {
                bp.SetName("True Main Character");
                bp.SetDescription("You are the main character of this world. Your attacks ignore {g|Encyclopedia:Damage_Reduction}damage reduction{/g}. The {g|Encyclopedia:Spell}spells{/g} you cast ignore {g|Encyclopedia:Spell_Resistance}spell resistance{/g} and spell immunity.");
                bp.m_Icon = Icon_TrueMainCharacter;
                bp.AddComponent<IgnoreSpellImmunity>();
                bp.AddComponent<IgnoreSpellResistanceForSpells>();
                bp.AddComponent<IgnoreDamageReductionOnAttack>();
                bp.IsClassFeature = true;
            });
            // Character development feats
            var Icon_CharacterDevelopment_1 = AssetLoader.LoadInternal("Features", "ICON_POSITIVE_SHIELD.png");
            var Icon_CharacterDevelopment_2 = AssetLoader.LoadInternal("Features", "ICON_NEGATIVE_SHIELD.png");

            // Backstories
            var VulnerabilityAcidFeat = Helpers.CreateBlueprint<BlueprintFeature>("VulnerabilityAcidFeat", bp => {
                bp.SetName("Acid Vulnerability");
                bp.SetDescription("You are vulnerable to Acid.");
                bp.m_Icon = IsekaiProtagonist.IsekaiProtagonistSpellList.AcidSplashAbility.m_Icon;
                bp.AddComponent<AddEnergyVulnerability>(c => {
                    c.Type = DamageEnergyType.Acid;
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
            var VulnerabilityColdFeat = Helpers.CreateBlueprint<BlueprintFeature>("VulnerabilityColdFeat", bp => {
                bp.SetName("Cold Vulnerability");
                bp.SetDescription("You are vulnerable to Cold.");
                bp.m_Icon = IsekaiProtagonist.IsekaiProtagonistSpellList.IceStormAbility.m_Icon;
                bp.AddComponent<AddEnergyVulnerability>(c => {
                    c.Type = DamageEnergyType.Cold;
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
            var VulnerabilityElectricityFeat = Helpers.CreateBlueprint<BlueprintFeature>("VulnerabilityElectricityFeat", bp => {
                bp.SetName("Electricity Vulnerability");
                bp.SetDescription("You are vulnerable to Electricity.");
                bp.m_Icon = IsekaiProtagonist.IsekaiProtagonistSpellList.LightningBoltAbility.m_Icon;
                bp.AddComponent<AddEnergyVulnerability>(c => {
                    c.Type = DamageEnergyType.Electricity;
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
            var VulnerabilityFireFeat = Helpers.CreateBlueprint<BlueprintFeature>("VulnerabilityFireFeat", bp => {
                bp.SetName("Fire Vulnerability");
                bp.SetDescription("You are vulnerable to Fire.");
                bp.m_Icon = IsekaiProtagonist.IsekaiProtagonistSpellList.FireballAbility.m_Icon;
                bp.AddComponent<AddEnergyVulnerability>(c => {
                    c.Type = DamageEnergyType.Fire;
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
            var VulnerabilitySonicFeat = Helpers.CreateBlueprint<BlueprintFeature>("VulnerabilitySonicFeat", bp => {
                bp.SetName("Sonic Vulnerability");
                bp.SetDescription("You are vulnerable to Sonic.");
                bp.m_Icon = IsekaiProtagonist.IsekaiProtagonistSpellList.EarPiercingScreamAbility.m_Icon;
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
                bp.SetDescription("You were subjected to unspeakable creulty in the past, leaving you traumatised to even the slightest shock of pain.\n" +
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

            //Training Arc
            var StudyMontage = Helpers.CreateBlueprint<BlueprintFeature>("StudyMontage", bp => {
                bp.SetName("Study Montage");
                bp.SetDescription("After extensive study sessions, you gain a +4 insight bonus to Intelligence, Wisdom, and Charisma.");
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Insight;
                    c.Stat = StatType.Intelligence;
                    c.Value = 4;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Insight;
                    c.Stat = StatType.Wisdom;
                    c.Value = 4;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Insight;
                    c.Stat = StatType.Charisma;
                    c.Value = 4;
                });
                bp.m_Icon = Icon_Thoughtsense;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
            var TrainingMontage = Helpers.CreateBlueprint<BlueprintFeature>("TrainingMontage", bp => {
                bp.SetName("Training Montage");
                bp.SetDescription("After extensive training sessions, you gain a +4 insight bonus to Strength, Dexterity, and Constitution.");
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Insight;
                    c.Stat = StatType.Strength;
                    c.Value = 4;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Insight;
                    c.Stat = StatType.Dexterity;
                    c.Value = 4;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Insight;
                    c.Stat = StatType.Constitution;
                    c.Value = 4;
                });
                bp.m_Icon = Icon_LegendaryProportions;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
            var BodyStrengthening = Helpers.CreateBlueprint<BlueprintFeature>("BodyStrengthening", bp => {
                bp.SetName("Body Strengthening");
                bp.SetDescription("After extensive strengthening of your body, you gain {g|Encyclopedia:Damage_Reduction}DR{/g}/— equal to your character level.");
                bp.AddComponent<AddDamageResistancePhysical>(c => {
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
                bp.m_Icon = Icon_IronBody;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
            var SpellNegation = Helpers.CreateBlueprint<BlueprintFeature>("SpellNegation", bp => {
                bp.SetName("Spell Negation");
                bp.SetDescription("After extensive studying of spells, you gain spell resistance equal to four times your character level.");
                bp.AddComponent<AddSpellResistance>(c => {
                    c.Value = new ContextValue()
                    {
                        ValueType = ContextValueType.Rank,
                        ValueRank = AbilityRankType.StatBonus
                    };
                });
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.StatBonus;
                    c.m_BaseValueType = ContextRankBaseValueType.CharacterLevel;
                    c.m_Progression = ContextRankProgression.MultiplyByModifier;
                    c.m_StepLevel = 4;
                });
                bp.m_Icon = Icon_SpellResistance;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });

            // Character development feats
            var AmorphousArmor = Helpers.CreateBlueprint<BlueprintFeature>("AmorphousArmor", bp => {
                bp.SetName("Amorphous Armor");
                bp.SetDescription("You gain immunity to Sneak attack damage and {g|Encyclopedia:Critical}critical hits{/g}.");
                bp.m_Icon = Icon_MageArmor;
                bp.AddComponent<AddImmunityToCriticalHits>();
                bp.AddComponent<AddImmunityToPrecisionDamage>();
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
            var VigorousWard = Helpers.CreateBlueprint<BlueprintFeature>("VigorousWard", bp => {
                bp.SetName("Vigorous Ward");
                bp.SetDescription("You gain immunity to {g|Encyclopedia:Ability_Scores}ability score{/g} {g|Encyclopedia:Damage}damage{/g}, energy drain, and negative levels.");
                bp.m_Icon = Icon_DeathWard;
                bp.AddComponent<AddImmunityToAbilityScoreDamage>();
                bp.AddComponent<AddImmunityToEnergyDrain>();
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.NegativeLevel
                    | SpellDescriptor.StatDebuff;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = SpellDescriptor.NegativeLevel
                    | SpellDescriptor.StatDebuff;
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
            var AlphaStrike = Helpers.CreateBlueprint<BlueprintFeature>("AlphaStrike", bp => {
                bp.SetName("Alpha Strike");
                bp.SetDescription("Your attacks ignore immunity to {g|Encyclopedia:Critical}critical hits{/g} and your critical threats are also automatically confirmed.");
                bp.m_Icon = Icon_SneakStab;
                bp.AddComponent<IgnoreCritImmunity>();
                bp.AddComponent<InitiatorCritAutoconfirm>();
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
            var GammaStrike = Helpers.CreateBlueprint<BlueprintFeature>("GammaStrike", bp => {
                bp.SetName("Gamma Strike");
                bp.SetDescription("Your attacks ignore concealment and are treated as adamantite for the purpose of overcoming {g|Encyclopedia:Damage_Reduction}damage reduction{/g}.");
                bp.m_Icon = Icon_BladeSense;
                bp.AddComponent<IgnoreConcealment>();
                bp.AddComponent<AddOutgoingPhysicalDamageProperty>(c => {
                    c.AddMaterial = true;
                    c.Material = PhysicalDamageMaterial.Adamantite;
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
            var HealthyBody = Helpers.CreateBlueprint<BlueprintFeature>("HealthyBody", bp => {
                bp.SetName("Healthy Body");
                bp.SetDescription("You gain immunity to bleed, blindness, curses, poison, disease, sickened, and nauseated conditions.");
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Sickened;
                });
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Nauseated;
                });
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Blindness;
                });
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.Sickened
                    | SpellDescriptor.Nauseated
                    | SpellDescriptor.Bleed
                    | SpellDescriptor.Blindness
                    | SpellDescriptor.Curse
                    | SpellDescriptor.Poison;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = SpellDescriptor.Sickened
                    | SpellDescriptor.Nauseated
                    | SpellDescriptor.Bleed
                    | SpellDescriptor.Blindness
                    | SpellDescriptor.Curse
                    | SpellDescriptor.Poison;
                });
                bp.m_Icon = Icon_PurityOfBody;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
            var InnerPower = Helpers.CreateBlueprint<BlueprintFeature>("InnerPower", bp => {
                bp.SetName("Inner Power");
                bp.SetDescription("You gain immunity to shaken, frightened, cowering, fear, petrified, paralysis, and death effects.");
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Shaken;
                });
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Frightened;
                });
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Cowering;
                });
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Paralyzed;
                });
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Petrified;
                });
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.Shaken
                    | SpellDescriptor.Frightened
                    | SpellDescriptor.Fear
                    | SpellDescriptor.Petrified
                    | SpellDescriptor.Paralysis
                    | SpellDescriptor.Death;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = SpellDescriptor.Shaken
                    | SpellDescriptor.Frightened
                    | SpellDescriptor.Fear
                    | SpellDescriptor.Petrified
                    | SpellDescriptor.Paralysis
                    | SpellDescriptor.Death;
                });
                bp.m_Icon = Icon_BurningRenewal;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
            var MasterSelf = Helpers.CreateBlueprint<BlueprintFeature>("MasterSelf", bp => {
                bp.SetName("Master Self-Control");
                bp.SetDescription("You gain immunity to sleep, confusion, charm, emotion, complusion, and mind-affecting effects.");
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Confusion;
                });
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Sleeping;
                });
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.Compulsion
                    | SpellDescriptor.Charm
                    | SpellDescriptor.MindAffecting
                    | SpellDescriptor.Emotion
                    | SpellDescriptor.NegativeEmotion
                    | SpellDescriptor.Confusion
                    | SpellDescriptor.Sleep;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = SpellDescriptor.Compulsion
                    | SpellDescriptor.Charm
                    | SpellDescriptor.MindAffecting
                    | SpellDescriptor.Emotion
                    | SpellDescriptor.NegativeEmotion
                    | SpellDescriptor.Confusion
                    | SpellDescriptor.Sleep;
                });
                bp.m_Icon = Icon_Serenity;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
            var Unstoppable = Helpers.CreateBlueprint<BlueprintFeature>("Unstoppable", bp => {
                bp.SetName("Unstoppable");
                bp.SetDescription("You gain immunity to dazed, dazzled, stunned, staggered, slowed, entangled, and movement impairing effects.");
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Slowed;
                });
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Staggered;
                });
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Stunned;
                });
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Dazed;
                });
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Dazzled;
                });
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.CantMove;
                });
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.MovementBan;
                });
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Entangled;
                });
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.Staggered
                    | SpellDescriptor.Stun
                    | SpellDescriptor.Daze
                    | SpellDescriptor.MovementImpairing;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = SpellDescriptor.Staggered
                    | SpellDescriptor.Stun
                    | SpellDescriptor.Daze
                    | SpellDescriptor.MovementImpairing;
                });
                bp.m_Icon = Icon_DextrousDuelist;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });


            // Character Development Selection
            var Icon_Backstory = AssetLoader.LoadInternal("Features", "ICON_BACKSTORY.png");
            var Icon_BeachEpisode = AssetLoader.LoadInternal("Features", "ICON_BEACH.png");
            var BackstorySelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>("BackstorySelection", bp => {
                bp.SetName("Backstory");
                bp.SetDescription("At 1st level, you get to select a backstory. These will develop over time as you increase your level.");
                bp.m_Icon = Icon_Backstory;
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
            var TrainingArcSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>("TrainingArcSelection", bp => {
                bp.SetName("Training Arc");
                bp.SetDescription("At 4th and 16th level, you train yourself intensely and gain insight into your own abilities.");
                bp.m_Icon = Icon_PerfectStrike;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.m_AllFeatures = new BlueprintFeatureReference[] {
                    StudyMontage.ToReference<BlueprintFeatureReference>(),
                    TrainingMontage.ToReference<BlueprintFeatureReference>(),
                    BodyStrengthening.ToReference<BlueprintFeatureReference>(),
                    SpellNegation.ToReference<BlueprintFeatureReference>(),
                };
                bp.m_Features = new BlueprintFeatureReference[] {
                    StudyMontage.ToReference<BlueprintFeatureReference>(),
                    TrainingMontage.ToReference<BlueprintFeatureReference>(),
                    BodyStrengthening.ToReference<BlueprintFeatureReference>(),
                    SpellNegation.ToReference<BlueprintFeatureReference>(),
                };
            });
            var BeachEpisodeSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>("BeachEpisodeSelection", bp => {
                bp.SetName("Beach Episode");
                bp.SetDescription("At 10th level, you and your companions take a short intermission beside a large body of water. During this time, you begin a journey of self discovery.");
                bp.m_Icon = Icon_BeachEpisode;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.m_AllFeatures = new BlueprintFeatureReference[] {
                    HealthyBody.ToReference<BlueprintFeatureReference>(),
                    InnerPower.ToReference<BlueprintFeatureReference>(),
                    MasterSelf.ToReference<BlueprintFeatureReference>(),
                    Unstoppable.ToReference<BlueprintFeatureReference>(),
                };
                bp.m_Features = new BlueprintFeatureReference[] {
                    HealthyBody.ToReference<BlueprintFeatureReference>(),
                    InnerPower.ToReference<BlueprintFeatureReference>(),
                    MasterSelf.ToReference<BlueprintFeatureReference>(),
                    Unstoppable.ToReference<BlueprintFeatureReference>(),
                };
            });

            var CharacterDevelopmentSelection1 = Helpers.CreateBlueprint<BlueprintFeatureSelection>("CharacterDevelopmentSelection1", bp => {
                bp.SetName("Character Development I");
                bp.SetDescription("At 7th, 13th, and 19th level, you can select one character development.");
                bp.m_Icon = Icon_Discovery;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.m_AllFeatures = new BlueprintFeatureReference[] {
                    AmorphousArmor.ToReference<BlueprintFeatureReference>(),
                    VigorousWard.ToReference<BlueprintFeatureReference>(),
                    AlphaStrike.ToReference<BlueprintFeatureReference>(),
                    GammaStrike.ToReference<BlueprintFeatureReference>(),
                };
                bp.m_Features = new BlueprintFeatureReference[] {
                    AmorphousArmor.ToReference<BlueprintFeatureReference>(),
                    VigorousWard.ToReference<BlueprintFeatureReference>(),
                    AlphaStrike.ToReference<BlueprintFeatureReference>(),
                    GammaStrike.ToReference<BlueprintFeatureReference>(),
                };
            });
            var CharacterDevelopmentSelection2 = Helpers.CreateBlueprint<BlueprintFeatureSelection>("CharacterDevelopmentSelection2", bp => {
                bp.SetName("Character Development II");
                bp.SetDescription("At 7th, 13th, and 19th level, you can select one character development.");
                bp.m_Icon = Icon_Discovery;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.m_AllFeatures = new BlueprintFeatureReference[] {
                    AmorphousArmor.ToReference<BlueprintFeatureReference>(),
                    VigorousWard.ToReference<BlueprintFeatureReference>(),
                    AlphaStrike.ToReference<BlueprintFeatureReference>(),
                    GammaStrike.ToReference<BlueprintFeatureReference>(),
                };
                bp.m_Features = new BlueprintFeatureReference[] {
                    AmorphousArmor.ToReference<BlueprintFeatureReference>(),
                    VigorousWard.ToReference<BlueprintFeatureReference>(),
                    AlphaStrike.ToReference<BlueprintFeatureReference>(),
                    GammaStrike.ToReference<BlueprintFeatureReference>(),
                };
            });
            var CharacterDevelopmentSelection3 = Helpers.CreateBlueprint<BlueprintFeatureSelection>("CharacterDevelopmentSelection3", bp => {
                bp.SetName("Character Development III");
                bp.SetDescription("At 7th, 13th, and 19th level, you can select one character development.");
                bp.m_Icon = Icon_Discovery;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.m_AllFeatures = new BlueprintFeatureReference[] {
                    AmorphousArmor.ToReference<BlueprintFeatureReference>(),
                    VigorousWard.ToReference<BlueprintFeatureReference>(),
                    AlphaStrike.ToReference<BlueprintFeatureReference>(),
                    GammaStrike.ToReference<BlueprintFeatureReference>(),
                };
                bp.m_Features = new BlueprintFeatureReference[] {
                    AmorphousArmor.ToReference<BlueprintFeatureReference>(),
                    VigorousWard.ToReference<BlueprintFeatureReference>(),
                    AlphaStrike.ToReference<BlueprintFeatureReference>(),
                    GammaStrike.ToReference<BlueprintFeatureReference>(),
                };
            });

            // Prebuild
            var PrebuildIsekaiProtagonistFeatureList = Helpers.CreateBlueprint<BlueprintFeature>("PrebuildIsekaiProtagonistFeatureList", bp => {
                bp.Ranks = 1;
                bp.HideInUI = true;
                bp.AddComponent<AddClassLevels>(c => {
                    c.DoNotApplyAutomatically = false;
                    c.m_CharacterClass = IsekaiProtagonistClass.ToReference<BlueprintCharacterClassReference>();
                    c.Levels = 20;
                    c.RaceStat = StatType.Strength;
                    c.LevelsStat = StatType.Charisma;
                    c.Skills = new StatType[11] {
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
                    c.Selections = new SelectionEntry[] {
                    new SelectionEntry()
                    {
                        m_Selection = BasicFeatSelection.ToReference<BlueprintFeatureSelectionReference>(),
                        m_Features = new BlueprintFeatureReference[]{
                            PowerAttack.ToReference<BlueprintFeatureReference>(),
                            CombatReflexes.ToReference<BlueprintFeatureReference>(),
                            WeaponSpecializationScythe.ToReference<BlueprintFeatureReference>(),
                            Outflank.ToReference<BlueprintFeatureReference>(),
                            WeaponFocusGreaterScythe.ToReference<BlueprintFeatureReference>(),
                            ImprovedInitiative.ToReference<BlueprintFeatureReference>(),
                            IntimidatingProwess.ToReference<BlueprintFeatureReference>(),
                            SpellPenetration.ToReference<BlueprintFeatureReference>(),
                            GreaterSpellPenetration.ToReference<BlueprintFeatureReference>(),
                            LightningReflexes.ToReference<BlueprintFeatureReference>(),
                        }
                    },
                    new SelectionEntry()
                    {
                        m_Selection = IsekaiProtagonistBonusFeatSelection.ToReference<BlueprintFeatureSelectionReference>(),
                        m_Features = new BlueprintFeatureReference[]{
                            Cleave.ToReference<BlueprintFeatureReference>(),
                            CleavingFinish.ToReference<BlueprintFeatureReference>(),
                            WeaponFocusScythe.ToReference<BlueprintFeatureReference>(),
                            DazzlingDisplay.ToReference<BlueprintFeatureReference>(),
                            ImprovedCriticalScythe.ToReference<BlueprintFeatureReference>(),
                            ShatterDefenses.ToReference<BlueprintFeatureReference>(),
                            WeaponSpecializationGreaterScythe.ToReference<BlueprintFeatureReference>(),
                            PenetratingStrike.ToReference<BlueprintFeatureReference>(),
                            GreaterPenetratingStrike.ToReference<BlueprintFeatureReference>(),
                            GreatFortitude.ToReference<BlueprintFeatureReference>(),
                            IronWill.ToReference<BlueprintFeatureReference>(),
                        }
                    },
                    new SelectionEntry()
                    {
                        m_Selection = BackstorySelection.ToReference<BlueprintFeatureSelectionReference>(),
                        m_Features = new BlueprintFeatureReference[]{
                            VengefulBackstory.ToReference<BlueprintFeatureReference>()
                        }
                    },
                    new SelectionEntry()
                    {
                        m_Selection = TrainingArcSelection.ToReference<BlueprintFeatureSelectionReference>(),
                        m_Features = new BlueprintFeatureReference[]{
                            TrainingMontage.ToReference<BlueprintFeatureReference>(),
                            StudyMontage.ToReference<BlueprintFeatureReference>()
                        }
                    },
                    new SelectionEntry()
                    {
                        m_Selection = CharacterDevelopmentSelection1.ToReference<BlueprintFeatureSelectionReference>(),
                        m_Features = new BlueprintFeatureReference[]{
                            AlphaStrike.ToReference<BlueprintFeatureReference>(),
                            GammaStrike.ToReference<BlueprintFeatureReference>(),
                            VigorousWard.ToReference<BlueprintFeatureReference>()
                        }
                    },
                    new SelectionEntry()
                    {
                        m_Selection = BeachEpisodeSelection.ToReference<BlueprintFeatureSelectionReference>(),
                        m_Features = new BlueprintFeatureReference[]{
                            MasterSelf.ToReference<BlueprintFeatureReference>()
                        }
                    },
                    new SelectionEntry()
                    {
                        m_Selection = Adaptibility.ToReference<BlueprintFeatureSelectionReference>(),
                        m_Features = new BlueprintFeatureReference[]{
                            SkillFocusPhysique.ToReference<BlueprintFeatureReference>()
                        }
                    },
                    new SelectionEntry()
                    {
                        m_Selection = AasimarHeritageSelection.ToReference<BlueprintFeatureSelectionReference>(),
                        m_Features = new BlueprintFeatureReference[]{
                            AngelHeritage.ToReference<BlueprintFeatureReference>()
                        }
                    },
                    new SelectionEntry()
                    {
                        m_Selection = TieflingHeritageSelection.ToReference<BlueprintFeatureSelectionReference>(),
                        m_Features = new BlueprintFeatureReference[]{
                            PitbornHeritage.ToReference<BlueprintFeatureReference>()
                        }
                    },
                    new SelectionEntry()
                    {
                        m_Selection = BackgroundBaseSelection.ToReference<BlueprintFeatureSelectionReference>(),
                        m_Features = new BlueprintFeatureReference[]{
                            BackgroundNone.ToReference<BlueprintFeatureReference>()
                        }
                    },
                };
                    c.m_SelectSpells = new BlueprintAbilityReference[]
                    {
                    // Level 1
                    IsekaiProtagonist.IsekaiProtagonistSpellList.EnlargePersonAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.ReducePersonAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.MageArmorAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.MagicWeaponAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.GreaseAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.MagicMissileAbility.ToReference<BlueprintAbilityReference>(),
                    //Level 2
                    IsekaiProtagonist.IsekaiProtagonistSpellList.MageShieldAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.TrueStrikeAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.BlessAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.ShieldOfFaithAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.SleepAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.DivineFavorAbility.ToReference<BlueprintAbilityReference>(),
                    // Level 3
                    IsekaiProtagonist.IsekaiProtagonistSpellList.UnbreakableHeartAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.VanishAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.StunningBarrierAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.FeatherStepAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.ExpeditiousRetreatAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.CureLightWoundsAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.AidAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.AlignWeaponAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.BarkskinAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.GlitterdustAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.RestorationLesserAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.ScorchingRayAbility.ToReference<BlueprintAbilityReference>(),
                    // Level 4
                    IsekaiProtagonist.IsekaiProtagonistSpellList.EntangleAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.FaerieFireAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.RemoveSicknessAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.RemoveFearAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.SummonMonsterIAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.SummonNaturesAllyIAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.AnimalAspectAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.FalseLifeAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.SenseVitalsAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.MirrorImageAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.CureModerateWoundsAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.InvisibilityAbility.ToReference<BlueprintAbilityReference>(),
                    // Level 5
                    IsekaiProtagonist.IsekaiProtagonistSpellList.FoxsCunningAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.BearsEnduranceAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.BullsStrengthAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.EaglesSplendorAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.CatsGraceAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.OwlsWisdomAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.HasteAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.FireballAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.AnimateDeadAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.CureSeriousWoundsAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.ResistEnergyCommunalAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.SlowAbility.ToReference<BlueprintAbilityReference>(),
                    // Level 6
                    IsekaiProtagonist.IsekaiProtagonistSpellList.HazeOfDreamsAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.InflictLightWoundsAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.LongstriderAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.RayOfEnfeeblementAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.TouchOfGracelessnessAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.CommandAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.ProtectionFromArrowsAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.RemoveParalysisAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.ResisEnergyAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.SummonElementalSmallAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.SummonMonsterIIAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.SummonNaturesAllyIIAbility.ToReference<BlueprintAbilityReference>(),
                    // Level 7
                    IsekaiProtagonist.IsekaiProtagonistSpellList.AnimalAspectGreaterAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.BestowCurseAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.MagicWeaponGreaterAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.HeroismAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.MagicalVestmentAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.ProtectionFromArrowsCommunalAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.CrusaderEdgeAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.DeathWardAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.FalseLifeGreaterAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.FreedomOfMovementAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.ProtectionFromEnergyCommunalAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.RestorationAbility.ToReference<BlueprintAbilityReference>(),
                    // Level 8
                    IsekaiProtagonist.IsekaiProtagonistSpellList.PoxPustulesAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.PerniciousPoisonAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.SeeInvisibilityAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.HoldAnimalAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.HoldPersonAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.InflictModerateWoundsAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.DispelMagicAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.DisplacementAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.InflictSeriousWoundsAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.PrayerAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.ProtectionFromEnergyAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.SeeInvisibilityCommunalAbility.ToReference<BlueprintAbilityReference>(),
                    // Level 9
                    IsekaiProtagonist.IsekaiProtagonistSpellList.CureCriticalWoundsAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.InvisibilityGreaterAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.PhantasmalKillerAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.SummonElementalMediumAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.SummonMonsterIVAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.SummonNaturesAllyIVAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.CureLightWoundsMassAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.InflictLightWoundsMassAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.TrueSeeingAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.SummonElementalLargeAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.SummonMonsterVAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.SummonNaturesAllyVAbility.ToReference<BlueprintAbilityReference>(),
                    // Level 10
                    IsekaiProtagonist.IsekaiProtagonistSpellList.LightningBoltAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.RemoveBlindnessAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.RemoveCurseAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.RemoveDiseaseAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.SummonMonsterIIIAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.SummonNaturesAllyIIIAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.BoneshatterAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.ControlledFireballAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.DimensionDoorAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.DragonsBreathAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.ElementalBodyIAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.InflictCriticalWoundsAbility.ToReference<BlueprintAbilityReference>(),
                    // Level 11
                    IsekaiProtagonist.IsekaiProtagonistSpellList.BalefulPolymorphAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.BreathOfLifeAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.CaveFangsAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.DominatePersonAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.MindFogAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.StoneskinCommunalAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.BearsEnduranceMassAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.BullsStrengthMassAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.EaglesSplendorMassAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.FoxsCunningMassAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.OwlsWisdomMassAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.CatsGraceMassAbility.ToReference<BlueprintAbilityReference>(),
                    // Level 12
                    IsekaiProtagonist.IsekaiProtagonistSpellList.EnervationAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.EnlargePersonMassAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.LifeBubbleAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.ShadowConjurationAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.ShieldOfDawnAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.ThornBodyAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.BreakEnchantmentAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.BurstOfGloryAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.ElementalBodyIIAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.HoldMonsterAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.ShadowEvocationAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.SpellResistanceAbility.ToReference<BlueprintAbilityReference>(),
                    // Level 13
                    IsekaiProtagonist.IsekaiProtagonistSpellList.CreateUndeadAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.CureModerateWoundsMassAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.FormOfTheDragonIAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.EaglesoulAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.ElementalBodyIIIAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.InflictModerateWoundsMassAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.BestowCurseGreaterAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.CreepingDoomAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.FormOfTheDragonIIAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.ElementalBodyIVAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.LegendaryProportionsAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.RestorationGreaterAbility.ToReference<BlueprintAbilityReference>(),
                    // Level 14
                    IsekaiProtagonist.IsekaiProtagonistSpellList.AnimalGrowthAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.HungryPitAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.PolymorphAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.RaiseDeadAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.SerenityAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.FeeblemindAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.HarmAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.HealAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.HeroismGreaterAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.SummonElementalHugeAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.SummonMonsterVIAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.SummonNaturesAllyVIAbility.ToReference<BlueprintAbilityReference>(),
                    // Level 15
                    IsekaiProtagonist.IsekaiProtagonistSpellList.CureSeriousWoundsMassAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.InflictSeriousWoundsMassAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.InvisibilityMassAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.PolymorphGreaterAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.ResurrectionAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.WavesOfExhaustionAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.DeathClutchAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.CureCriticalWoundsMassAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.InflictCriticalWoundsMassAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.SummonElementalElderAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.SummonMonsterVIIIAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.SummonNaturesAllyVIIIAbility.ToReference<BlueprintAbilityReference>(),
                    // Level 16
                    IsekaiProtagonist.IsekaiProtagonistSpellList.DispelMagicGreaterAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.EyebiteAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.InspiringRecoveryAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.PrimalRegressionAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.SiroccoAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.StoneToFleshAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.FingerOfDeathAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.WalkThroughSpaceAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.ShadowConjurationGreaterAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.SummonElementalGreaterAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.SummonMonsterVIIAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.SummonNaturesAllyVIIAbility.ToReference<BlueprintAbilityReference>(),
                    // Level 17
                    IsekaiProtagonist.IsekaiProtagonistSpellList.AngelicAspectGreaterAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.FrightfulAspectAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.HolyAuraAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.FormOfTheDragonIIIAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.IronBodyAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.SeamantleAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.DominateMonsterAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.DeathClutchAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.ElementalSwarmAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.SummonElderWormAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.SummonMonsterIXAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.SummonNaturesAllyIXAbility.ToReference<BlueprintAbilityReference>(),
                    // Level 18
                    IsekaiProtagonist.IsekaiProtagonistSpellList.DestructionAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.HolyWordAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.FireStormAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.IceBodyAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.KiShoutAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.PrismaticSprayAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.MindBlankAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.PolarRayAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.StormboltsAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.ShieldOfLawAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.RiftOfRuinAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.ShadowEvocationGreaterAbility.ToReference<BlueprintAbilityReference>(),
                    // Level 19
                    IsekaiProtagonist.IsekaiProtagonistSpellList.EuphoricTranquilityAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.ScintillatingPatternAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.ProtectionFromSpellsAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.SouldreaverAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.SunburstAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.UnholyAuraAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.HealMassAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.MindBlankCommunalAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.HeroicInvocationAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.ShadesAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.WeirdAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.ShapechangeAbility.ToReference<BlueprintAbilityReference>(),
                    // Level 20
                    IsekaiProtagonist.IsekaiProtagonistSpellList.EnergyDrainAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.FieryBodyAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.ForesightAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.HoldMonsterMassAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.IcyPrisonMassAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.OverwhelmingPresenceAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.PolarMidnightAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonist.IsekaiProtagonistSpellList.WailOfBansheeAbility.ToReference<BlueprintAbilityReference>(),
                    };
                });
                bp.AddComponent<StatsDistributionPreset>(c => {
                    c.TargetPoints = 20;
                    c.Strength = 14;
                    c.Dexterity = 12;
                    c.Constitution = 8;
                    c.Intelligence = 10;
                    c.Wisdom = 12;
                    c.Charisma = 17;
                });
                bp.AddComponent<StatsDistributionPreset>(c => {
                    c.TargetPoints = 25;
                    c.Strength = 14;
                    c.Dexterity = 13;
                    c.Constitution = 8;
                    c.Intelligence = 10;
                    c.Wisdom = 12;
                    c.Charisma = 18;
                });
                bp.AddComponent<BuildBalanceRadarChart>(c => {
                    c.Control = 5;
                    c.Defense = 5;
                    c.Magic = 5;
                    c.Melee = 5;
                    c.Ranged = 5;
                    c.Support = 5;
                });
            });
            IsekaiProtagonistClass.m_DefaultBuild = PrebuildIsekaiProtagonistFeatureList.ToReference<BlueprintUnitFactReference>();

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
            var CharacterDevelopmentFeat = Helpers.CreateBlueprint<BlueprintFeature>("CharacterDevelopmentFeat", bp => {
                bp.SetName("Character Development");
                bp.SetDescription("At 7th, 13th, and 19th level, you can select one character development.");
                bp.m_DescriptionShort = Helpers.CreateString("PlotArmor.DescriptionShort", "At 7th, 13th, and 19th level, you can select one character development.");
                bp.m_Icon = Icon_Discovery;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });

            // Signature Abilities
            IsekaiProtagonistClass.m_SignatureAbilities = new BlueprintFeatureReference[4] {
                    IsekaiProtagonistBonusFeat.ToReference<BlueprintFeatureReference>(),
                    IsekaiProtagonistSneakFeat.ToReference<BlueprintFeatureReference>(),
                    PlotArmor.ToReference<BlueprintFeatureReference>(),
                    CharacterDevelopmentFeat.ToReference<BlueprintFeatureReference>()
            };
            IsekaiProtagonistProgression.LevelEntries = new LevelEntry[20] {
                Helpers.LevelEntry(1, IsekaiProtagonistProficiencies, IsekaiProtagonistCantripsFeature, IsekaiProtagonistBonusFeatSelection, SneakAttack, BackstorySelection, PlotArmor),
                Helpers.LevelEntry(2, IsekaiProtagonistBonusFeatSelection, UncannyDodge),
                Helpers.LevelEntry(3, SneakAttack, IsekaiFighterTraining, Evasion),
                Helpers.LevelEntry(4, IsekaiProtagonistBonusFeatSelection, TrainingArcSelection),
                Helpers.LevelEntry(5, SneakAttack, ImprovedUncannyDodge),
                Helpers.LevelEntry(6, IsekaiProtagonistBonusFeatSelection, SignatureAttack),
                Helpers.LevelEntry(7, SneakAttack, CharacterDevelopmentSelection1),
                Helpers.LevelEntry(8, IsekaiProtagonistBonusFeatSelection, IsekaiFastMovement),
                Helpers.LevelEntry(9, SneakAttack, FriendlyAuraFeature),
                Helpers.LevelEntry(10, IsekaiProtagonistBonusFeatSelection, BeachEpisodeSelection, ImprovedEvasion),
                Helpers.LevelEntry(11, SneakAttack),
                Helpers.LevelEntry(12, IsekaiProtagonistBonusFeatSelection),
                Helpers.LevelEntry(13, SneakAttack, CharacterDevelopmentSelection2),
                Helpers.LevelEntry(14, IsekaiProtagonistBonusFeatSelection),
                Helpers.LevelEntry(15, SneakAttack, OtherworldlyStamina, IsekaiQuickFooted),
                Helpers.LevelEntry(16, IsekaiProtagonistBonusFeatSelection, TrainingArcSelection),
                Helpers.LevelEntry(17, SneakAttack, HaremMagnetFeature),
                Helpers.LevelEntry(18, IsekaiProtagonistBonusFeatSelection),
                Helpers.LevelEntry(19, SneakAttack, CharacterDevelopmentSelection3),
                Helpers.LevelEntry(20, IsekaiProtagonistBonusFeatSelection, TrueMainCharacter)
            };
            IsekaiProtagonistProgression.UIGroups = new UIGroup[] {
                Helpers.CreateUIGroup(BackstorySelection, TrainingArcSelection, BeachEpisodeSelection, CharacterDevelopmentSelection1, CharacterDevelopmentSelection2, CharacterDevelopmentSelection3),
                Helpers.CreateUIGroup(PlotArmor, IsekaiFighterTraining, SignatureAttack, FriendlyAuraFeature, DarkAuraFeature, OtherworldlyStamina, HaremMagnetFeature, TrueMainCharacter),
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