using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Classes.IsekaiProtagonist {

    internal class PrestigeClassReplaceSpellbook {
        public static void Patch() {
            PatchIsekai();
            PatchVillain();
        }

        public static void PatchIsekai() {
            var LoremasterIsekai = Helpers.CreateBlueprint<BlueprintFeatureReplaceSpellbook>(IsekaiContext, "LoremasterIsekai", bp => {
                bp.SetName(IsekaiContext, "Isekai Protagonist");
                bp.SetDescription(IsekaiContext, "When a new loremaster level is gained, the character gains new {g|Encyclopedia:Spell}spells{/g} per day as if he had also gained a level in a "
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
            var HellknightSignifierIsekai = Helpers.CreateBlueprint<BlueprintFeatureReplaceSpellbook>(IsekaiContext, "HellknightSignifierIsekai", bp => {
                bp.SetName(IsekaiContext, "Isekai Protagonist");
                bp.SetDescription(IsekaiContext, "At 1st level, and at every level thereafter, a Hellknight signifer gains new {g|Encyclopedia:Spell}spells{/g} per day as if he had also gained a "
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
            var ArcaneTricksterIsekai = Helpers.CreateBlueprint<BlueprintFeatureReplaceSpellbook>(IsekaiContext, "ArcaneTricksterIsekai", bp => {
                bp.SetName(IsekaiContext, "Isekai Protagonist");
                bp.SetDescription(IsekaiContext, "At 1st level, an arcane trickster selects an arcane {g|Encyclopedia:Spell}spellcasting{/g} class she belonged to before adding the prestige class. "
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
            var MysticTheurgeArcaneIsekai = Helpers.CreateBlueprint<BlueprintFeatureReplaceSpellbook>(IsekaiContext, "MysticTheurgeArcaneIsekai", bp => {
                bp.SetName(IsekaiContext, "Isekai Protagonist");
                bp.SetDescription(IsekaiContext, "At 1st level, the mystic theurge selects an arcane {g|Encyclopedia:Spell}spellcasting{/g} class she belonged to before adding the prestige class. "
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
            var MysticTheurgeDivineIsekai = Helpers.CreateBlueprint<BlueprintFeatureReplaceSpellbook>(IsekaiContext, "MysticTheurgeDivineIsekai", bp => {
                bp.SetName(IsekaiContext, "Isekai Protagonist");
                bp.SetDescription(IsekaiContext, "At 1st level, the mystic theurge selects a divine {g|Encyclopedia:Spell}spellcasting{/g} class she belonged to before adding the prestige class. "
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
            var DragonDiscipleIsekai = Helpers.CreateBlueprint<BlueprintFeatureReplaceSpellbook>(IsekaiContext, "DragonDiscipleIsekai", bp => {
                bp.SetName(IsekaiContext, "Isekai Protagonist");
                bp.SetDescription(IsekaiContext, "At 2nd level, and at every level thereafter, with an exception for 5th and 9th levels, a Dragon Disciple gains new {g|Encyclopedia:Spell}spells{/g} "
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
            var EldritchKnightIsekai = Helpers.CreateBlueprint<BlueprintFeatureReplaceSpellbook>(IsekaiContext, "EldritchKnightIsekai", bp => {
                bp.SetName(IsekaiContext, "Isekai Protagonist");
                bp.SetDescription(IsekaiContext, "At 2nd level, and at every level thereafter, an eldritch knight gains new {g|Encyclopedia:Spell}spells{/g} per day as if he had also gained a level "
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
            var WinterWitchIsekai = Helpers.CreateBlueprint<BlueprintFeatureReplaceSpellbook>(IsekaiContext, "WinterWitchIsekai", bp => {
                bp.SetName(IsekaiContext, "Isekai Protagonist");
                bp.SetDescription(IsekaiContext, "When a new winter witch level is gained, the character gains new {g|Encyclopedia:Spell}spells{/g} per day as if she had also gained a level in witch "
                    + "or shaman spellcasting class she belonged to before she added the prestige class. Additionally, at 2nd level, and every two level after, a winter witch gets a "
                    + "new hex depending on the chosen spellcasting class.");
                bp.HideInUI = true;
                bp.HideNotAvailibleInUI = true;
                bp.Groups = new FeatureGroup[0];
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


            FeatTools.Selections.LoremasterSpellbookSelection.AddToSelection(LoremasterIsekai);
            FeatTools.Selections.HellknightSigniferSpellbook.AddToSelection(HellknightSignifierIsekai);
            FeatTools.Selections.ArcaneTricksterSpellbookSelection.AddToSelection(ArcaneTricksterIsekai);
            FeatTools.Selections.MysticTheurgeArcaneSpellbookSelection.AddToSelection(MysticTheurgeArcaneIsekai);
            FeatTools.Selections.MysticTheurgeDivineSpellbookSelection.AddToSelection(MysticTheurgeDivineIsekai);
            FeatTools.Selections.DragonDiscipleSpellbookSelection.AddToSelection(DragonDiscipleIsekai);
            FeatTools.Selections.EldritchKnightSpellbookSelection.AddToSelection(EldritchKnightIsekai);
            FeatTools.Selections.WinterWitchSpellbookSelection.AddToSelection(WinterWitchIsekai);
        }

        public static void PatchVillain() {
            var LoremasterVillain = Helpers.CreateBlueprint<BlueprintFeatureReplaceSpellbook>(IsekaiContext, "LoremasterVillain", bp => {
                bp.SetName(IsekaiContext, "Isekai Villain");
                bp.SetDescription(IsekaiContext, "When a new loremaster level is gained, the character gains new {g|Encyclopedia:Spell}spells{/g} per day as if he had also gained a level in a "
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
            var HellknightSignifierVillain = Helpers.CreateBlueprint<BlueprintFeatureReplaceSpellbook>(IsekaiContext, "HellknightSignifierVillain", bp => {
                bp.SetName(IsekaiContext, "Isekai Villain");
                bp.SetDescription(IsekaiContext, "At 1st level, and at every level thereafter, a Hellknight signifer gains new {g|Encyclopedia:Spell}spells{/g} per day as if he had also gained a "
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
            var ArcaneTricksterVillain = Helpers.CreateBlueprint<BlueprintFeatureReplaceSpellbook>(IsekaiContext, "ArcaneTricksterVillain", bp => {
                bp.SetName(IsekaiContext, "Isekai Villain");
                bp.SetDescription(IsekaiContext, "At 1st level, an arcane trickster selects an arcane {g|Encyclopedia:Spell}spellcasting{/g} class she belonged to before adding the prestige class. "
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
                bp.AddComponent<PrerequisiteArchetypeLevel>(c => {
                    c.Group = Prerequisite.GroupType.All;
                    c.m_CharacterClass = IsekaiProtagonistClass.GetReference();
                    c.m_Archetype = Archetypes.Villain.GetReference();
                    c.Level = 1;
                });
            });
            var MysticTheurgeArcaneVillain = Helpers.CreateBlueprint<BlueprintFeatureReplaceSpellbook>(IsekaiContext, "MysticTheurgeArcaneVillain", bp => {
                bp.SetName(IsekaiContext, "Isekai Villain");
                bp.SetDescription(IsekaiContext, "At 1st level, the mystic theurge selects an arcane {g|Encyclopedia:Spell}spellcasting{/g} class she belonged to before adding the prestige class. "
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
                bp.AddComponent<PrerequisiteArchetypeLevel>(c => {
                    c.Group = Prerequisite.GroupType.All;
                    c.m_CharacterClass = IsekaiProtagonistClass.GetReference();
                    c.m_Archetype = Archetypes.Villain.GetReference();
                    c.Level = 1;
                });
            });
            var MysticTheurgeDivineVillain = Helpers.CreateBlueprint<BlueprintFeatureReplaceSpellbook>(IsekaiContext, "MysticTheurgeDivineVillain", bp => {
                bp.SetName(IsekaiContext, "Isekai Villain");
                bp.SetDescription(IsekaiContext, "At 1st level, the mystic theurge selects a divine {g|Encyclopedia:Spell}spellcasting{/g} class she belonged to before adding the prestige class. "
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
                bp.AddComponent<PrerequisiteArchetypeLevel>(c => {
                    c.Group = Prerequisite.GroupType.All;
                    c.m_CharacterClass = IsekaiProtagonistClass.GetReference();
                    c.m_Archetype = Archetypes.Villain.GetReference();
                    c.Level = 1;
                });
            });
            var DragonDiscipleVillain = Helpers.CreateBlueprint<BlueprintFeatureReplaceSpellbook>(IsekaiContext, "DragonDiscipleVillain", bp => {
                bp.SetName(IsekaiContext, "Isekai Villain");
                bp.SetDescription(IsekaiContext, "At 2nd level, and at every level thereafter, with an exception for 5th and 9th levels, a Dragon Disciple gains new {g|Encyclopedia:Spell}spells{/g} "
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
                bp.AddComponent<PrerequisiteArchetypeLevel>(c => {
                    c.Group = Prerequisite.GroupType.All;
                    c.m_CharacterClass = IsekaiProtagonistClass.GetReference();
                    c.m_Archetype = Archetypes.Villain.GetReference();
                    c.Level = 1;
                });
            });
            var EldritchKnightVillain = Helpers.CreateBlueprint<BlueprintFeatureReplaceSpellbook>(IsekaiContext, "EldritchKnightVillain", bp => {
                bp.SetName(IsekaiContext, "Isekai Villain");
                bp.SetDescription(IsekaiContext, "At 2nd level, and at every level thereafter, an eldritch knight gains new {g|Encyclopedia:Spell}spells{/g} per day as if he had also gained a level "
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
                bp.AddComponent<PrerequisiteArchetypeLevel>(c => {
                    c.Group = Prerequisite.GroupType.All;
                    c.m_CharacterClass = IsekaiProtagonistClass.GetReference();
                    c.m_Archetype = Archetypes.Villain.GetReference();
                    c.Level = 1;
                });
            });
            var WinterWitchVillain = Helpers.CreateBlueprint<BlueprintFeatureReplaceSpellbook>(IsekaiContext, "WinterWitchVillain", bp => {
                bp.SetName(IsekaiContext, "Isekai Villain");
                bp.SetDescription(IsekaiContext, "When a new winter witch level is gained, the character gains new {g|Encyclopedia:Spell}spells{/g} per day as if she had also gained a level in witch "
                    + "or shaman spellcasting class she belonged to before she added the prestige class. Additionally, at 2nd level, and every two level after, a winter witch gets a "
                    + "new hex depending on the chosen spellcasting class.");
                bp.HideInUI = true;
                bp.HideNotAvailibleInUI = true;
                bp.Groups = new FeatureGroup[0];
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.m_Spellbook = VillainSpellbook.GetReference();
                bp.AddComponent<PrerequisiteClassSpellLevel>(c => {
                    c.Group = Prerequisite.GroupType.All;
                    c.m_CharacterClass = IsekaiProtagonistClass.GetReference();
                    c.RequiredSpellLevel = 2;
                });
                bp.AddComponent<PrerequisiteArchetypeLevel>(c => {
                    c.Group = Prerequisite.GroupType.All;
                    c.m_CharacterClass = IsekaiProtagonistClass.GetReference();
                    c.m_Archetype = Archetypes.Villain.GetReference();
                    c.Level = 1;
                });
            });


            FeatTools.Selections.LoremasterSpellbookSelection.AddToSelection(LoremasterVillain);
            FeatTools.Selections.HellknightSigniferSpellbook.AddToSelection(HellknightSignifierVillain);
            FeatTools.Selections.ArcaneTricksterSpellbookSelection.AddToSelection(ArcaneTricksterVillain);
            FeatTools.Selections.MysticTheurgeArcaneSpellbookSelection.AddToSelection(MysticTheurgeArcaneVillain);
            FeatTools.Selections.MysticTheurgeDivineSpellbookSelection.AddToSelection(MysticTheurgeDivineVillain);
            FeatTools.Selections.DragonDiscipleSpellbookSelection.AddToSelection(DragonDiscipleVillain);
            FeatTools.Selections.EldritchKnightSpellbookSelection.AddToSelection(EldritchKnightVillain);
            FeatTools.Selections.WinterWitchSpellbookSelection.AddToSelection(WinterWitchVillain);
        }
    }
}