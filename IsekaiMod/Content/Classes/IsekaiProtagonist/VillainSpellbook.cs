using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.EntitySystem.Stats;

namespace IsekaiMod.Content.Classes.IsekaiProtagonist
{
    class VillainSpellbook
    {
        public static void Add()
        {
            var IsekaiProtagonistSpellList = Resources.GetModBlueprint<BlueprintSpellList>("IsekaiProtagonistSpellList");
            var IsekaiProtagonistSpellsPerDay = Resources.GetModBlueprint<BlueprintSpellsTable>("IsekaiProtagonistSpellsPerDay");
            var VillainSpellbook = Helpers.CreateBlueprint<BlueprintSpellbook>("VillainSpellbook", bp => {
                bp.Name = Helpers.CreateString("VillainSpellbook.Name", "Villain");
                bp.Spontaneous = false;
                bp.CastingAttribute = StatType.Intelligence;
                bp.CantripsType = CantripsType.Cantrips;
                bp.IsArcane = false;
                bp.IsArcanist = false;
                bp.m_SpellsPerDay = IsekaiProtagonistSpellsPerDay.ToReference<BlueprintSpellsTableReference>();
                bp.m_SpellsKnown = null;
                bp.m_SpellList = IsekaiProtagonistSpellList.ToReference<BlueprintSpellListReference>();
                bp.m_SpellSlots = null;
                bp.SpellsPerLevel = 4;
                bp.AllSpellsKnown = false;
                bp.CanCopyScrolls = true;

                // Mythic spellbook related
                bp.IsMythic = false;
                bp.m_MythicSpellList = null;

                // These relate to special spell slots (like wizard's favourite school spell slots or shaman's spirit magic slots)
                bp.HasSpecialSpellList = false;
                bp.SpecialSpellListName = new Kingmaker.Localization.LocalizedString();
            });
        }
    }
}
