using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Localization;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Classes.IsekaiProtagonist.Archetypes.Mastermind {

    internal class MastermindSpellbook {

        public static void Add() {
            var IsekaiProtagonistSpellList = BlueprintTools.GetModBlueprint<BlueprintSpellList>(IsekaiContext, "IsekaiProtagonistSpellList");
            var IsekaiProtagonistSpellsPerDay = BlueprintTools.GetModBlueprint<BlueprintSpellsTable>(IsekaiContext, "IsekaiProtagonistSpellsPerDay");
            var MastermindSpellbook = Helpers.CreateBlueprint<BlueprintSpellbook>(IsekaiContext, "MastermindSpellbook", bp => {
                bp.Name = Helpers.CreateString(IsekaiContext, "MastermindSpellbook.Name", "Mastermind");
                bp.Spontaneous = true;
                bp.CastingAttribute = StatType.Intelligence;
                bp.CantripsType = CantripsType.Cantrips;
                bp.IsArcane = true;
                bp.IsArcanist = true;
                bp.m_SpellsPerDay = IsekaiProtagonistSpellsPerDay.ToReference<BlueprintSpellsTableReference>();
                bp.m_SpellsKnown = null;
                bp.m_SpellList = IsekaiProtagonistSpellList.ToReference<BlueprintSpellListReference>();
                bp.m_SpellSlots = IsekaiProtagonistSpellsPerDay.ToReference<BlueprintSpellsTableReference>();
                bp.SpellsPerLevel = 4;
                bp.AllSpellsKnown = false;
                bp.CanCopyScrolls = true;

                // Mythic spellbook related
                bp.IsMythic = false;
                bp.m_MythicSpellList = null;

                // These relate to special spell slots (like wizard's favourite school spell slots or shaman's spirit magic slots)
                bp.HasSpecialSpellList = false;
                bp.SpecialSpellListName = new LocalizedString();
            });

            // Allow Spellbook to be merged with angel and lich
            var AngelIncorporateSpellBook = BlueprintTools.GetBlueprint<BlueprintFeatureSelectMythicSpellbook>("e1fbb0e0e610a3a4d91e5e5284587939");
            var LichIncorporateSpellBook = BlueprintTools.GetBlueprint<BlueprintFeatureSelectMythicSpellbook>("3f16e9caf7c683c40884c7c455ed26af");
            ThingsNotHandledByTTTCore.RegisterForPrestigeSpellbook(AngelIncorporateSpellBook, MastermindSpellbook);
            ThingsNotHandledByTTTCore.RegisterForPrestigeSpellbook(LichIncorporateSpellBook, MastermindSpellbook);
        }

        public static BlueprintSpellbook Get() {
            return BlueprintTools.GetModBlueprint<BlueprintSpellbook>(IsekaiContext, "MastermindSpellbook");
        }

        public static BlueprintSpellbookReference GetReference() {
            return Get().ToReference<BlueprintSpellbookReference>();
        }
    }
}