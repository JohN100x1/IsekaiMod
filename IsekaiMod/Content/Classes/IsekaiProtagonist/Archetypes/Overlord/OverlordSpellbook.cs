using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.EntitySystem.Stats;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Classes.IsekaiProtagonist.Archetypes.Overlord {

    internal class OverlordSpellbook {

        public static void Add() {
            var OverlordSpellbook = Helpers.CreateBlueprint<BlueprintSpellbook>(IsekaiContext, "OverlordSpellbook", bp => {
                bp.Name = Helpers.CreateString(IsekaiContext, "OverlordSpellbook.Name", "Overlord");
                bp.Spontaneous = true;
                bp.CastingAttribute = StatType.Charisma;
                bp.CantripsType = CantripsType.Cantrips;
                bp.IsArcane = true;
                bp.IsArcanist = false;
                bp.m_SpellsPerDay = IsekaiProtagonistSpellsPerDay.GetReference();
                bp.m_SpellsKnown = IsekaiProtagonistSpellsKnown.GetReference();
                bp.m_SpellList = IsekaiProtagonistSpellList.GetReference();
                bp.m_SpellSlots = null;
                bp.SpellsPerLevel = 0;
                bp.AllSpellsKnown = false;
                bp.CanCopyScrolls = false;

                // Mythic spellbook related
                bp.IsMythic = false;
                bp.m_MythicSpellList = null;

                // These relate to special spell slots (like wizard's favourite school spell slots or shaman's spirit magic slots)
                bp.HasSpecialSpellList = false;
                bp.SpecialSpellListName = StaticReferences.Strings.Null;
            });

            PatchTools.RegisterSpellbook(OverlordSpellbook);
        }

        public static BlueprintSpellbook Get() {
            return BlueprintTools.GetModBlueprint<BlueprintSpellbook>(IsekaiContext, "OverlordSpellbook");
        }

        public static BlueprintSpellbookReference GetReference() {
            return Get().ToReference<BlueprintSpellbookReference>();
        }
    }
}