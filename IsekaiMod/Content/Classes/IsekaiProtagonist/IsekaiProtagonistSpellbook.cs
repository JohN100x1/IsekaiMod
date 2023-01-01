using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Localization;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Classes.IsekaiProtagonist
{
    class IsekaiProtagonistSpellbook
    {
        public static void Add()
        {
            var IsekaiProtagonistSpellList = BlueprintTools.GetModBlueprint<BlueprintSpellList>(IsekaiContext, "IsekaiProtagonistSpellList");
            var IsekaiProtagonistSpellsPerDay = BlueprintTools.GetModBlueprint<BlueprintSpellsTable>(IsekaiContext, "IsekaiProtagonistSpellsPerDay");
            var IsekaiProtagonistSpellsKnown = BlueprintTools.GetModBlueprint<BlueprintSpellsTable>(IsekaiContext, "IsekaiProtagonistSpellsKnown");
            var IsekaiProtagonistSpellbook = Helpers.CreateBlueprint<BlueprintSpellbook>(IsekaiContext, "IsekaiProtagonistSpellbook", bp => {
                bp.Name = Helpers.CreateString(IsekaiContext, "$IsekaiProtagonistSpellbook.Name", "Isekai Protagonist");
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
                bp.SpecialSpellListName = new LocalizedString();
            });

            // Allow Spellbook to be merged with angel and lich
            var AngelIncorporateSpellBook = BlueprintTools.GetBlueprint<BlueprintFeatureSelectMythicSpellbook>("e1fbb0e0e610a3a4d91e5e5284587939");
            var LichIncorporateSpellBook = BlueprintTools.GetBlueprint<BlueprintFeatureSelectMythicSpellbook>("3f16e9caf7c683c40884c7c455ed26af");
            ThingsNotHandledByTTTCore.RegisterForPrestigeSpellbook(LichIncorporateSpellBook, IsekaiProtagonistSpellbook);
            ThingsNotHandledByTTTCore.RegisterForPrestigeSpellbook(AngelIncorporateSpellBook, IsekaiProtagonistSpellbook);
        }
        public static void SetCharacterClass(BlueprintCharacterClass characterClass)
        {
            BlueprintSpellbook SpellBook = Get();
            SpellBook.m_CharacterClass = characterClass.ToReference<BlueprintCharacterClassReference>();
        }
        public static BlueprintSpellbook Get()
        {
            return BlueprintTools.GetModBlueprint<BlueprintSpellbook>( IsekaiContext, "IsekaiProtagonistSpellbook");
        }
        public static BlueprintSpellbookReference GetReference()
        {
            return Get().ToReference<BlueprintSpellbookReference>();
        }
    }
}
