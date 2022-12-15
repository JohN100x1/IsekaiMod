using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;

namespace IsekaiMod.Content.Classes.IsekaiProtagonist
{
    class PrestigeClassReplaceSpellbook
    {
        private static BlueprintFeatureSelection LoremasterSpellbookSelection = Resources.GetBlueprint<BlueprintFeatureSelection>("7a28ab4dfc010834eabc770152997e87");
        private static BlueprintFeatureSelection HellknightSignifierSpellbook = Resources.GetBlueprint<BlueprintFeatureSelection>("68782aa7a302b6d43a42a71c6e9b5277");
        private static BlueprintFeatureSelection ArcaneTricksterSpellbookSelection = Resources.GetBlueprint<BlueprintFeatureSelection>("ae04b7cdeb88b024b9fd3882cc7d3d76");
        private static BlueprintFeatureSelection MysticTheurgeArcaneSpellbook = Resources.GetBlueprint<BlueprintFeatureSelection>("97f510c6483523c49bc779e93e4c4568");
        private static BlueprintFeatureSelection MysticTheurgeDivineSpellbook = Resources.GetBlueprint<BlueprintFeatureSelection>("7cd057944ce7896479717778330a4933");
        private static BlueprintFeatureSelection DragonDiscipleSpellbookSelection = Resources.GetBlueprint<BlueprintFeatureSelection>("8c1ba14c0b6dcdb439c56341385ee474");
        private static BlueprintFeatureSelection EldritchKnightSpellbookSelection = Resources.GetBlueprint<BlueprintFeatureSelection>("dc3ab8d0484467a4787979d93114ebc3");
        public static void Patch()
        {
            PatchIsekai();
            PatchVillain();
        }
        public static void PatchIsekai()
        {
            var LoremasterIsekai = Helpers.CreateBlueprint<BlueprintFeatureReplaceSpellbook>("LoremasterIsekai", bp => {
                bp.SetName("Isekai Protagonist");
                bp.SetDescription("When a new loremaster level is gained, the character gains new {g|Encyclopedia:Spell}spells{/g} per day as if he had also gained a level in a "
                    + "spellcasting class he belonged to before adding the prestige class. He does not, however, gain other benefits a character of that class would have gained, "
                    + "except for additional spells per day, spells known (if he is a spontaneous spellcaster), and an increased effective level of spellcasting. If a character had "
                    + "more than one spellcasting class before becoming a loremaster, he must decide to which class he adds the new level for purposes of determining the number of "
                    + "spells per day.");
                bp.HideInUI = true;
                bp.HideNotAvailibleInUI = true;
                bp.HideInCharacterSheetAndLevelUp = false;
                bp.Groups = new FeatureGroup[] { FeatureGroup.MythicAdditionalProgressions };
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.m_Spellbook = IsekaiProtagonistSpellbook.GetReference();
                bp.AddComponent<PrerequisiteClassSpellLevel>(c => {
                    c.Group = Prerequisite.GroupType.All;
                    c.m_CharacterClass = IsekaiProtagonistClass.GetReference();
                    c.RequiredSpellLevel = 3;
                });
                bp.AddComponent<PrerequisiteNoArchetype>(c => {
                    c.Group = Prerequisite.GroupType.All;
                    c.m_CharacterClass = IsekaiProtagonistClass.GetReference();
                    c.m_Archetype = Archetypes.Villain.GetReference();
                });
            });
            var HellknightSignifierIsekai = Helpers.CreateBlueprint<BlueprintFeatureReplaceSpellbook>("HellknightSignifierIsekai", bp => {
                bp.SetName("Isekai Protagonist");
                bp.SetDescription("At 1st level, and at every level thereafter, a Hellknight signifer gains new {g|Encyclopedia:Spell}spells{/g} per day as if he had also gained a "
                    + "level in a spellcasting class he belonged to before adding the prestige class. He does not, however, gain any other benefit a character of that class would "
                    + "have gained, except for additional spells per day, spells known, and an increased effective level of spellcasting. If a character had more than one spellcasting "
                    + "class before becoming a Hellknight signifer, he must decide to which class he adds the new level for purposes of determining spells per day.");
                bp.HideInUI = true;
                bp.HideNotAvailibleInUI = true;
                bp.HideInCharacterSheetAndLevelUp = false;
                bp.Groups = new FeatureGroup[] { FeatureGroup.HellknightSigniferSpellbook };
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.m_Spellbook = IsekaiProtagonistSpellbook.GetReference();
                bp.AddComponent<PrerequisiteClassSpellLevel>(c => {
                    c.Group = Prerequisite.GroupType.All;
                    c.m_CharacterClass = IsekaiProtagonistClass.GetReference();
                    c.RequiredSpellLevel = 3;
                });
                bp.AddComponent<PrerequisiteNoArchetype>(c => {
                    c.Group = Prerequisite.GroupType.All;
                    c.m_CharacterClass = IsekaiProtagonistClass.GetReference();
                    c.m_Archetype = Archetypes.Villain.GetReference();
                });
            });
            var ArcaneTricksterIsekai = Helpers.CreateBlueprint<BlueprintFeatureReplaceSpellbook>("ArcaneTricksterIsekai", bp => {
                bp.SetName("Isekai Protagonist");
                bp.SetDescription("At 1st level, an arcane trickster selects an arcane {g|Encyclopedia:Spell}spellcasting{/g} class she belonged to before adding the prestige class. "
                    + "When a new arcane trickster level is gained, the character gains new spells per day and new spells known as if she had also gained a level in "
                    + "that spellcasting class.");
                bp.HideInUI = true;
                bp.HideNotAvailibleInUI = true;
                bp.Groups = new FeatureGroup[] { FeatureGroup.ArcaneTricksterSpellbook };
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.m_Spellbook = IsekaiProtagonistSpellbook.GetReference();
                bp.AddComponent<PrerequisiteClassSpellLevel>(c => {
                    c.Group = Prerequisite.GroupType.All;
                    c.m_CharacterClass = IsekaiProtagonistClass.GetReference();
                    c.RequiredSpellLevel = 2;
                });
                bp.AddComponent<PrerequisiteNoArchetype>(c => {
                    c.Group = Prerequisite.GroupType.All;
                    c.m_CharacterClass = IsekaiProtagonistClass.GetReference();
                    c.m_Archetype = Archetypes.Villain.GetReference();
                });
            });
            var MysticTheurgeArcaneIsekai = Helpers.CreateBlueprint<BlueprintFeatureReplaceSpellbook>("MysticTheurgeArcaneIsekai", bp => {
                bp.SetName("Isekai Protagonist");
                bp.SetDescription("At 1st level, the mystic theurge selects an arcane {g|Encyclopedia:Spell}spellcasting{/g} class she belonged to before adding the prestige class. "
                    + "When a new mystic theurge level is gained, the character gains new spells per day and new spells known as if she had also gained a level in that spellcasting class.");
                bp.HideInUI = true;
                bp.HideNotAvailibleInUI = true;
                bp.Groups = new FeatureGroup[] { FeatureGroup.MysticTheurgeArcaneSpellbook };
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.m_Spellbook = IsekaiProtagonistSpellbook.GetReference();
                bp.AddComponent<PrerequisiteClassSpellLevel>(c => {
                    c.Group = Prerequisite.GroupType.All;
                    c.m_CharacterClass = IsekaiProtagonistClass.GetReference();
                    c.RequiredSpellLevel = 2;
                });
                bp.AddComponent<PrerequisiteNoArchetype>(c => {
                    c.Group = Prerequisite.GroupType.All;
                    c.m_CharacterClass = IsekaiProtagonistClass.GetReference();
                    c.m_Archetype = Archetypes.Villain.GetReference();
                });
            });
            var MysticTheurgeDivineIsekai = Helpers.CreateBlueprint<BlueprintFeatureReplaceSpellbook>("MysticTheurgeDivineIsekai", bp => {
                bp.SetName("Isekai Protagonist");
                bp.SetDescription("At 1st level, the mystic theurge selects a divine {g|Encyclopedia:Spell}spellcasting{/g} class she belonged to before adding the prestige class. "
                    + "When a new mystic theurge level is gained, the character gains new spells per day and new spells known as if she had also gained a level in that spellcasting class.");
                bp.HideInUI = true;
                bp.HideNotAvailibleInUI = true;
                bp.Groups = new FeatureGroup[] { FeatureGroup.MysticTheurgeDivineSpellbook };
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.m_Spellbook = IsekaiProtagonistSpellbook.GetReference();
                bp.AddComponent<PrerequisiteClassSpellLevel>(c => {
                    c.Group = Prerequisite.GroupType.All;
                    c.m_CharacterClass = IsekaiProtagonistClass.GetReference();
                    c.RequiredSpellLevel = 2;
                });
                bp.AddComponent<PrerequisiteNoArchetype>(c => {
                    c.Group = Prerequisite.GroupType.All;
                    c.m_CharacterClass = IsekaiProtagonistClass.GetReference();
                    c.m_Archetype = Archetypes.Villain.GetReference();
                });
            });
            var DragonDiscipleIsekai = Helpers.CreateBlueprint<BlueprintFeatureReplaceSpellbook>("DragonDiscipleIsekai", bp => {
                bp.SetName("Isekai Protagonist");
                bp.SetDescription("At 2nd level, and at every level thereafter, with an exception for 5th and 9th levels, a Dragon Disciple gains new {g|Encyclopedia:Spell}spells{/g} "
                    + "per day as if he had also gained a level in an arcane spellcasting class he belonged to before adding the prestige class. He does not, however, gain any other "
                    + "benefit a character of that class would have gained, except for additional spells per day, spells known, and an increased effective level of spellcasting. "
                    + "If a character had more than one arcane spellcasting class before becoming an Dragon Disciple, he must decide to which class he adds the new level for purposes "
                    + "of determining spells per day.");
                bp.HideInUI = true;
                bp.HideNotAvailibleInUI = true;
                bp.Groups = new FeatureGroup[] { FeatureGroup.DragonDiscipleSpellbook };
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.m_Spellbook = IsekaiProtagonistSpellbook.GetReference();
                bp.AddComponent<PrerequisiteClassSpellLevel>(c => {
                    c.Group = Prerequisite.GroupType.All;
                    c.m_CharacterClass = IsekaiProtagonistClass.GetReference();
                    c.RequiredSpellLevel = 2;
                });
                bp.AddComponent<PrerequisiteNoArchetype>(c => {
                    c.Group = Prerequisite.GroupType.All;
                    c.m_CharacterClass = IsekaiProtagonistClass.GetReference();
                    c.m_Archetype = Archetypes.Villain.GetReference();
                });
            });
            var EldritchKnightIsekai = Helpers.CreateBlueprint<BlueprintFeatureReplaceSpellbook>("EldritchKnightIsekai", bp => {
                bp.SetName("Isekai Protagonist");
                bp.SetDescription("At 2nd level, and at every level thereafter, an eldritch knight gains new {g|Encyclopedia:Spell}spells{/g} per day as if he had also gained a level "
                    + "in an arcane spellcasting class he belonged to before adding the prestige class. He does not, however, gain any other benefit a character of that class would have "
                    + "gained, except for additional spells per day, spells known, and an increased effective level of spellcasting. If a character had more than one arcane spellcasting "
                    + "class before becoming an eldritch knight, he must decide to which class he adds the new level for purposes of determining spells per day.");
                bp.HideInUI = true;
                bp.HideNotAvailibleInUI = true;
                bp.Groups = new FeatureGroup[] { FeatureGroup.EldritchKnightSpellbook };
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.m_Spellbook = IsekaiProtagonistSpellbook.GetReference();
                bp.AddComponent<PrerequisiteClassSpellLevel>(c => {
                    c.Group = Prerequisite.GroupType.All;
                    c.m_CharacterClass = IsekaiProtagonistClass.GetReference();
                    c.RequiredSpellLevel = 2;
                });
                bp.AddComponent<PrerequisiteNoArchetype>(c => {
                    c.Group = Prerequisite.GroupType.All;
                    c.m_CharacterClass = IsekaiProtagonistClass.GetReference();
                    c.m_Archetype = Archetypes.Villain.GetReference();
                });
            });

            LoremasterSpellbookSelection.m_AllFeatures = LoremasterSpellbookSelection.m_AllFeatures.AddToArray(LoremasterIsekai.ToReference<BlueprintFeatureReference>());
            HellknightSignifierSpellbook.m_AllFeatures = HellknightSignifierSpellbook.m_AllFeatures.AddToArray(HellknightSignifierIsekai.ToReference<BlueprintFeatureReference>());
            ArcaneTricksterSpellbookSelection.m_AllFeatures = ArcaneTricksterSpellbookSelection.m_AllFeatures.AddToArray(ArcaneTricksterIsekai.ToReference<BlueprintFeatureReference>());
            MysticTheurgeArcaneSpellbook.m_AllFeatures = MysticTheurgeArcaneSpellbook.m_AllFeatures.AddToArray(MysticTheurgeArcaneIsekai.ToReference<BlueprintFeatureReference>());
            MysticTheurgeDivineSpellbook.m_AllFeatures = MysticTheurgeDivineSpellbook.m_AllFeatures.AddToArray(MysticTheurgeDivineIsekai.ToReference<BlueprintFeatureReference>());
            DragonDiscipleSpellbookSelection.m_AllFeatures = DragonDiscipleSpellbookSelection.m_AllFeatures.AddToArray(DragonDiscipleIsekai.ToReference<BlueprintFeatureReference>());
            EldritchKnightSpellbookSelection.m_AllFeatures = EldritchKnightSpellbookSelection.m_AllFeatures.AddToArray(EldritchKnightIsekai.ToReference<BlueprintFeatureReference>());
        }
        public static void PatchVillain()
        {

            var LoremasterVillain = Helpers.CreateBlueprint<BlueprintFeatureReplaceSpellbook>("LoremasterVillain", bp => {
                bp.SetName("Isekai Villain");
                bp.SetDescription("When a new loremaster level is gained, the character gains new {g|Encyclopedia:Spell}spells{/g} per day as if he had also gained a level in a "
                    + "spellcasting class he belonged to before adding the prestige class. He does not, however, gain other benefits a character of that class would have gained, "
                    + "except for additional spells per day, spells known (if he is a spontaneous spellcaster), and an increased effective level of spellcasting. If a character had "
                    + "more than one spellcasting class before becoming a loremaster, he must decide to which class he adds the new level for purposes of determining the number of "
                    + "spells per day.");
                bp.HideInUI = true;
                bp.HideNotAvailibleInUI = true;
                bp.HideInCharacterSheetAndLevelUp = false;
                bp.Groups = new FeatureGroup[] { FeatureGroup.MythicAdditionalProgressions };
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.m_Spellbook = VillainSpellbook.GetReference();
                bp.AddComponent<PrerequisiteClassSpellLevel>(c => {
                    c.Group = Prerequisite.GroupType.All;
                    c.m_CharacterClass = IsekaiProtagonistClass.GetReference();
                    c.RequiredSpellLevel = 3;
                });
                bp.AddComponent<PrerequisiteArchetypeLevel>(c => {
                    c.Group = Prerequisite.GroupType.All;
                    c.m_CharacterClass = IsekaiProtagonistClass.GetReference();
                    c.m_Archetype = Archetypes.Villain.GetReference();
                    c.Level = 1;
                });
            });
            var HellknightSignifierVillain = Helpers.CreateBlueprint<BlueprintFeatureReplaceSpellbook>("HellknightSignifierVillain", bp => {
                bp.SetName("Isekai Villain");
                bp.SetDescription("At 1st level, and at every level thereafter, a Hellknight signifer gains new {g|Encyclopedia:Spell}spells{/g} per day as if he had also gained a "
                    + "level in a spellcasting class he belonged to before adding the prestige class. He does not, however, gain any other benefit a character of that class would "
                    + "have gained, except for additional spells per day, spells known, and an increased effective level of spellcasting. If a character had more than one spellcasting "
                    + "class before becoming a Hellknight signifer, he must decide to which class he adds the new level for purposes of determining spells per day.");
                bp.HideInUI = true;
                bp.HideNotAvailibleInUI = true;
                bp.Groups = new FeatureGroup[] { FeatureGroup.HellknightSigniferSpellbook };
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.m_Spellbook = VillainSpellbook.GetReference();
                bp.AddComponent<PrerequisiteClassSpellLevel>(c => {
                    c.Group = Prerequisite.GroupType.All;
                    c.m_CharacterClass = IsekaiProtagonistClass.GetReference();
                    c.RequiredSpellLevel = 3;
                });
                bp.AddComponent<PrerequisiteArchetypeLevel>(c => {
                    c.Group = Prerequisite.GroupType.All;
                    c.m_CharacterClass = IsekaiProtagonistClass.GetReference();
                    c.m_Archetype = Archetypes.Villain.GetReference();
                    c.Level = 1;
                });
            });
            var ArcaneTricksterVillain = Helpers.CreateBlueprint<BlueprintFeatureReplaceSpellbook>("ArcaneTricksterVillain", bp => {
                bp.SetName("Isekai Villain");
                bp.SetDescription("At 1st level, an arcane trickster selects an arcane {g|Encyclopedia:Spell}spellcasting{/g} class she belonged to before adding the prestige class. "
                    + "When a new arcane trickster level is gained, the character gains new spells per day and new spells known as if she had also gained a level in "
                    + "that spellcasting class.");
                bp.HideInUI = true;
                bp.HideNotAvailibleInUI = true;
                bp.Groups = new FeatureGroup[] { FeatureGroup.ArcaneTricksterSpellbook };
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.m_Spellbook = VillainSpellbook.GetReference();
                bp.AddComponent<PrerequisiteClassSpellLevel>(c => {
                    c.Group = Prerequisite.GroupType.All;
                    c.m_CharacterClass = IsekaiProtagonistClass.GetReference();
                    c.RequiredSpellLevel = 2;
                });
                bp.AddComponent<PrerequisiteNoArchetype>(c => {
                    c.Group = Prerequisite.GroupType.All;
                    c.m_CharacterClass = IsekaiProtagonistClass.GetReference();
                    c.m_Archetype = Archetypes.Villain.GetReference();
                });
            });
            var MysticTheurgeArcaneVillain = Helpers.CreateBlueprint<BlueprintFeatureReplaceSpellbook>("MysticTheurgeArcaneVillain", bp => {
                bp.SetName("Isekai Villain");
                bp.SetDescription("At 1st level, the mystic theurge selects an arcane {g|Encyclopedia:Spell}spellcasting{/g} class she belonged to before adding the prestige class. "
                    + "When a new mystic theurge level is gained, the character gains new spells per day and new spells known as if she had also gained a level in that spellcasting class.");
                bp.HideInUI = true;
                bp.HideNotAvailibleInUI = true;
                bp.Groups = new FeatureGroup[] { FeatureGroup.MysticTheurgeArcaneSpellbook };
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.m_Spellbook = VillainSpellbook.GetReference();
                bp.AddComponent<PrerequisiteClassSpellLevel>(c => {
                    c.Group = Prerequisite.GroupType.All;
                    c.m_CharacterClass = IsekaiProtagonistClass.GetReference();
                    c.RequiredSpellLevel = 2;
                });
                bp.AddComponent<PrerequisiteNoArchetype>(c => {
                    c.Group = Prerequisite.GroupType.All;
                    c.m_CharacterClass = IsekaiProtagonistClass.GetReference();
                    c.m_Archetype = Archetypes.Villain.GetReference();
                });
            });
            var MysticTheurgeDivineVillain = Helpers.CreateBlueprint<BlueprintFeatureReplaceSpellbook>("MysticTheurgeDivineVillain", bp => {
                bp.SetName("Isekai Villain");
                bp.SetDescription("At 1st level, the mystic theurge selects a divine {g|Encyclopedia:Spell}spellcasting{/g} class she belonged to before adding the prestige class. "
                    + "When a new mystic theurge level is gained, the character gains new spells per day and new spells known as if she had also gained a level in that spellcasting class.");
                bp.HideInUI = true;
                bp.HideNotAvailibleInUI = true;
                bp.Groups = new FeatureGroup[] { FeatureGroup.MysticTheurgeDivineSpellbook };
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.m_Spellbook = VillainSpellbook.GetReference();
                bp.AddComponent<PrerequisiteClassSpellLevel>(c => {
                    c.Group = Prerequisite.GroupType.All;
                    c.m_CharacterClass = IsekaiProtagonistClass.GetReference();
                    c.RequiredSpellLevel = 2;
                });
                bp.AddComponent<PrerequisiteNoArchetype>(c => {
                    c.Group = Prerequisite.GroupType.All;
                    c.m_CharacterClass = IsekaiProtagonistClass.GetReference();
                    c.m_Archetype = Archetypes.Villain.GetReference();
                });
            });
            var DragonDiscipleVillain = Helpers.CreateBlueprint<BlueprintFeatureReplaceSpellbook>("DragonDiscipleVillain", bp => {
                bp.SetName("Isekai Villain");
                bp.SetDescription("At 2nd level, and at every level thereafter, with an exception for 5th and 9th levels, a Dragon Disciple gains new {g|Encyclopedia:Spell}spells{/g} "
                    + "per day as if he had also gained a level in an arcane spellcasting class he belonged to before adding the prestige class. He does not, however, gain any other "
                    + "benefit a character of that class would have gained, except for additional spells per day, spells known, and an increased effective level of spellcasting. "
                    + "If a character had more than one arcane spellcasting class before becoming an Dragon Disciple, he must decide to which class he adds the new level for purposes "
                    + "of determining spells per day.");
                bp.HideInUI = true;
                bp.HideNotAvailibleInUI = true;
                bp.Groups = new FeatureGroup[] { FeatureGroup.DragonDiscipleSpellbook };
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.m_Spellbook = VillainSpellbook.GetReference();
                bp.AddComponent<PrerequisiteClassSpellLevel>(c => {
                    c.Group = Prerequisite.GroupType.All;
                    c.m_CharacterClass = IsekaiProtagonistClass.GetReference();
                    c.RequiredSpellLevel = 2;
                });
                bp.AddComponent<PrerequisiteNoArchetype>(c => {
                    c.Group = Prerequisite.GroupType.All;
                    c.m_CharacterClass = IsekaiProtagonistClass.GetReference();
                    c.m_Archetype = Archetypes.Villain.GetReference();
                });
            });
            var EldritchKnightVillain = Helpers.CreateBlueprint<BlueprintFeatureReplaceSpellbook>("EldritchKnightVillain", bp => {
                bp.SetName("Isekai Villain");
                bp.SetDescription("At 2nd level, and at every level thereafter, an eldritch knight gains new {g|Encyclopedia:Spell}spells{/g} per day as if he had also gained a level "
                    + "in an arcane spellcasting class he belonged to before adding the prestige class. He does not, however, gain any other benefit a character of that class would have "
                    + "gained, except for additional spells per day, spells known, and an increased effective level of spellcasting. If a character had more than one arcane spellcasting "
                    + "class before becoming an eldritch knight, he must decide to which class he adds the new level for purposes of determining spells per day.");
                bp.HideInUI = true;
                bp.HideNotAvailibleInUI = true;
                bp.Groups = new FeatureGroup[] { FeatureGroup.EldritchKnightSpellbook };
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.m_Spellbook = VillainSpellbook.GetReference();
                bp.AddComponent<PrerequisiteClassSpellLevel>(c => {
                    c.Group = Prerequisite.GroupType.All;
                    c.m_CharacterClass = IsekaiProtagonistClass.GetReference();
                    c.RequiredSpellLevel = 2;
                });
                bp.AddComponent<PrerequisiteNoArchetype>(c => {
                    c.Group = Prerequisite.GroupType.All;
                    c.m_CharacterClass = IsekaiProtagonistClass.GetReference();
                    c.m_Archetype = Archetypes.Villain.GetReference();
                });
            });

            LoremasterSpellbookSelection.m_AllFeatures = LoremasterSpellbookSelection.m_AllFeatures.AddToArray(LoremasterVillain.ToReference<BlueprintFeatureReference>());
            HellknightSignifierSpellbook.m_AllFeatures = HellknightSignifierSpellbook.m_AllFeatures.AddToArray(HellknightSignifierVillain.ToReference<BlueprintFeatureReference>());
            ArcaneTricksterSpellbookSelection.m_AllFeatures = ArcaneTricksterSpellbookSelection.m_AllFeatures.AddToArray(ArcaneTricksterVillain.ToReference<BlueprintFeatureReference>());
            MysticTheurgeArcaneSpellbook.m_AllFeatures = MysticTheurgeArcaneSpellbook.m_AllFeatures.AddToArray(MysticTheurgeArcaneVillain.ToReference<BlueprintFeatureReference>());
            MysticTheurgeDivineSpellbook.m_AllFeatures = MysticTheurgeDivineSpellbook.m_AllFeatures.AddToArray(MysticTheurgeDivineVillain.ToReference<BlueprintFeatureReference>());
            DragonDiscipleSpellbookSelection.m_AllFeatures = DragonDiscipleSpellbookSelection.m_AllFeatures.AddToArray(DragonDiscipleVillain.ToReference<BlueprintFeatureReference>());
            EldritchKnightSpellbookSelection.m_AllFeatures = EldritchKnightSpellbookSelection.m_AllFeatures.AddToArray(EldritchKnightVillain.ToReference<BlueprintFeatureReference>());
        }
    }
}
