using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Abilities.Blueprints;

namespace IsekaiMod.Changes.Classes.IsekaiProtagonist
{
    internal class IsekaiProtagonistClass
    {
        // Stat Progression
        private static readonly BlueprintStatProgression BaseAttackBonus = Resources.GetBlueprint<BlueprintStatProgression>("b3057560ffff3514299e8b93e7648a9d");
        private static readonly BlueprintStatProgression SavesProgression = Resources.GetBlueprint<BlueprintStatProgression>("ff4662bde9e75f145853417313842751");

        public static void Add()
        {
            // TODO: Archetype idea: Edge Lord; has extra attacks and can cast spells as a swift action
            // TODO: Add more character development feats
            // TODO: rework backstories
            // TODO: Add custom equipment

            // TODO: Add isekai backgrounds, including ones that give good stats
            // TODO: Add MythicAbilitySelection ability

            // Used in Class
            var BasicFeatSelection = Resources.GetBlueprint<BlueprintFeatureSelection>("247a4068296e8be42890143f451b4b45");
            var AnimalClass = Resources.GetBlueprint<BlueprintCharacterClass>("4cd1757a0eea7694ba5c933729a53920");
            var MonkClass = Resources.GetBlueprint<BlueprintCharacterClass>("e8f21e5b58e0569468e420ebea456124");

            // Spellbook
            var SpellBook = Resources.GetModBlueprint<BlueprintSpellbook>("IsekaiProtagonistSpellbook");

            // Class Signature Features
            var Icon_SneakAttack = Resources.GetBlueprint<BlueprintFeature>("9b9eac6709e1c084cb18c3a366e0ec87").m_Icon;
            var Icon_EdictOfImpenetrableFortress = Resources.GetBlueprint<BlueprintAbility>("d7741c08ccf699e4a8a8f8ab2ed345f8").m_Icon;
            var Icon_Discovery = Resources.GetBlueprint<BlueprintFeatureSelection>("cd86c437488386f438dcc9ae727ea2a6").m_Icon;

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
            var IsekaiProtagonistCharacterDevelopmentFeat = Helpers.CreateBlueprint<BlueprintFeature>("IsekaiProtagonistCharacterDevelopmentFeat", bp => {
                bp.SetName("Character Development");
                bp.SetDescription("Isekai Protagonists can gain powerful character development feats when they reach certain levels.");
                bp.m_DescriptionShort = Helpers.CreateString("PlotArmor.DescriptionShort", "Isekai Protagonists can gain powerful character development feats when they reach certain levels.");
                bp.m_Icon = Icon_Discovery;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });

            // Main Class
            var IsekaiProtagonistClass = Helpers.CreateBlueprint<BlueprintCharacterClass>("IsekaiProtagonistClass", bp => {
                bp.LocalizedName = Helpers.CreateString($"IsekaiProtagonistClass.Name", "Isekai Protagonist");
                bp.LocalizedDescription = Helpers.CreateString($"IsekaiProtagonistClass.Description", "Isekai protagonists are skilled in both martial prowess and magical ability. " +
                    "They are able to cast spells while wearing any armor or shield. They also gain character development feats which greatly enhance their combat strength.");
                bp.LocalizedDescriptionShort = Helpers.CreateString($"IsekaiProtagonistClass.Description",
                    "Isekai protagonists are people who have been reincarnated into the world of Golarion with extraordinary abilities. " +
                    "As their story progresses, they gain more overpowered abilities to wreck every wannabe villain and side characters they face.");
                bp.HitDie = DiceType.D12;
                bp.m_BaseAttackBonus = BaseAttackBonus.ToReference<BlueprintStatProgressionReference>();
                bp.m_FortitudeSave = SavesProgression.ToReference<BlueprintStatProgressionReference>();
                bp.m_ReflexSave = SavesProgression.ToReference<BlueprintStatProgressionReference>();
                bp.m_WillSave = SavesProgression.ToReference<BlueprintStatProgressionReference>();
                bp.m_Difficulty = 1;
                bp.RecommendedAttributes = new StatType[] { StatType.Strength, StatType.Charisma};
                bp.NotRecommendedAttributes = new StatType[] { StatType.Constitution };
                bp.m_Spellbook = SpellBook.ToReference<BlueprintSpellbookReference>();
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
                bp.m_SignatureAbilities = new BlueprintFeatureReference[4] {
                    IsekaiProtagonistBonusFeat.ToReference<BlueprintFeatureReference>(),
                    IsekaiProtagonistSneakFeat.ToReference<BlueprintFeatureReference>(),
                    IsekaiProtagonistPlotArmorFeat.ToReference<BlueprintFeatureReference>(),
                    IsekaiProtagonistCharacterDevelopmentFeat.ToReference<BlueprintFeatureReference>()
                };
                bp.AddComponent<PrerequisiteNoClassLevel>(c => {
                    c.m_CharacterClass = AnimalClass.ToReference<BlueprintCharacterClassReference>();
                });
                bp.AddComponent<PrerequisiteIsPet>(c => {
                    c.Not = true;
                    c.HideInUI = true;
                });
            });
            SpellBook.m_CharacterClass = IsekaiProtagonistClass.ToReference<BlueprintCharacterClassReference>();

            // Allow Spellbook to be merged with angel and lich
            var AngelIncorporateSpellBook = Resources.GetBlueprint<BlueprintFeatureSelectMythicSpellbook>("e1fbb0e0e610a3a4d91e5e5284587939");
            var LichIncorporateSpellBook = Resources.GetBlueprint<BlueprintFeatureSelectMythicSpellbook>("3f16e9caf7c683c40884c7c455ed26af");
            AngelIncorporateSpellBook.m_AllowedSpellbooks = AngelIncorporateSpellBook.m_AllowedSpellbooks.AddToArray(SpellBook.ToReference<BlueprintSpellbookReference>());
            LichIncorporateSpellBook.m_AllowedSpellbooks = LichIncorporateSpellBook.m_AllowedSpellbooks.AddToArray(SpellBook.ToReference<BlueprintSpellbookReference>());

            // Register Class
            Helpers.RegisterClass(IsekaiProtagonistClass);
        }
    }
}