using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;

namespace IsekaiMod.Content.Classes.IsekaiProtagonist
{
    class HellknightSignifierReplaceSpellbook
    {
        public static void Patch()
        {
            // HellknightSignifier Isekai Protagonist
            var HellknightSignifierIsekai = Helpers.CreateBlueprint<BlueprintFeatureReplaceSpellbook>("HellknightSignifierIsekai", bp => {
                bp.SetName("Isekai Protagonist");
                bp.SetDescription("At 1st level, and at every level thereafter, a Hellknight signifer gains new {g|Encyclopedia:Spell}spells{/g} per day as if he had also gained a "
                    + "level in a spellcasting class he belonged to before adding the prestige class. He does not, however, gain any other benefit a character of that class would "
                    + "have gained, except for additional spells per day, spells known, and an increased effective level of spellcasting. If a character had more than one spellcasting "
                    + "class before becoming a Hellknight signifer, he must decide to which class he adds the new level for purposes of determining spells per day.");
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
            // HellknightSignifier Villain Protagonist
            var HellknightSignifierVillain = Helpers.CreateBlueprint<BlueprintFeatureReplaceSpellbook>("HellknightSignifierVillain", bp => {
                bp.SetName("Isekai Villain");
                bp.SetDescription("At 1st level, and at every level thereafter, a Hellknight signifer gains new {g|Encyclopedia:Spell}spells{/g} per day as if he had also gained a "
                    + "level in a spellcasting class he belonged to before adding the prestige class. He does not, however, gain any other benefit a character of that class would "
                    + "have gained, except for additional spells per day, spells known, and an increased effective level of spellcasting. If a character had more than one spellcasting "
                    + "class before becoming a Hellknight signifer, he must decide to which class he adds the new level for purposes of determining spells per day.");
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
                bp.AddComponent<PrerequisiteArchetypeLevel>(c => {
                    c.Group = Prerequisite.GroupType.All;
                    c.m_CharacterClass = IsekaiProtagonistClass.GetReference();
                    c.m_Archetype = Archetypes.Villain.GetReference();
                    c.Level = 1;
                });
            });

            // Add to HellknightSignifier Spellbook Selection
            var HellknightSignifierSpellbook = Resources.GetBlueprint<BlueprintFeatureSelection>("68782aa7a302b6d43a42a71c6e9b5277");
            HellknightSignifierSpellbook.m_AllFeatures = HellknightSignifierSpellbook.m_AllFeatures.AddToArray(HellknightSignifierIsekai.ToReference<BlueprintFeatureReference>());
            HellknightSignifierSpellbook.m_AllFeatures = HellknightSignifierSpellbook.m_AllFeatures.AddToArray(HellknightSignifierVillain.ToReference<BlueprintFeatureReference>());
        }
    }
}
