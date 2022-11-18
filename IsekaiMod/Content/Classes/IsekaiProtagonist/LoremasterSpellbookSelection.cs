using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;

namespace IsekaiMod.Content.Classes.IsekaiProtagonist
{
    class LoremasterSpellbookSelection
    {
        public static void Patch()
        {
            // Loremaster Isekai Protagonist
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
            // Loremaster Villain Protagonist
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

            // Add to Loremaster Spellbook Selection
            var LoremasterSpellbookSelection = Resources.GetBlueprint<BlueprintFeatureSelection>("7a28ab4dfc010834eabc770152997e87");
            LoremasterSpellbookSelection.m_AllFeatures = LoremasterSpellbookSelection.m_AllFeatures.AddToArray(LoremasterIsekai.ToReference<BlueprintFeatureReference>());
            LoremasterSpellbookSelection.m_AllFeatures = LoremasterSpellbookSelection.m_AllFeatures.AddToArray(LoremasterVillain.ToReference<BlueprintFeatureReference>());
        }
    }
}
