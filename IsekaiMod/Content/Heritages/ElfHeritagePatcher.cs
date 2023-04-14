using IsekaiMod.Components;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Buffs;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.FactLogic;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Heritages {

    internal class ElfHeritagePatcher {
        private static readonly BlueprintFeature DestinyBeyondBirthMythicFeat = BlueprintTools.GetBlueprint<BlueprintFeature>("325f078c584318849bfe3da9ea245b9d");

        public static void Patch() {
            // Get Isekai Heritages
            var IsekaiDarkElfHeritageReference = BlueprintTools.GetModBlueprintReference<BlueprintUnitFactReference>(IsekaiContext, "IsekaiDarkElfHeritage");
            var IsekaiHighElfHeritageReference = BlueprintTools.GetModBlueprintReference<BlueprintUnitFactReference>(IsekaiContext, "IsekaiHighElfHeritage");
            var IsekaiWoodElfHeritageReference = BlueprintTools.GetModBlueprintReference<BlueprintUnitFactReference>(IsekaiContext, "IsekaiWoodElfHeritage");

            // Don't Add stat bonuses from Elf Race if Isekai Elf Heritage is selected
            var ElfRace = BlueprintTools.GetBlueprint<BlueprintRace>("25a5878d125338244896ebd3238226c8");
            ElfRace.RemoveComponents<AddStatBonus>();
            ElfRace.RemoveComponents<AddStatBonusIfHasFact>();
            ElfRace.AddComponent<AddStatBonusIfNotHasFact>(c => {
                c.Descriptor = ModifierDescriptor.Racial;
                c.Stat = StatType.Dexterity;
                c.Value = 2;
                c.m_CheckedFacts = new BlueprintUnitFactReference[] {
                    IsekaiDarkElfHeritageReference,
                    IsekaiHighElfHeritageReference,
                    IsekaiWoodElfHeritageReference,
                };
            });
            ElfRace.AddComponent<AddStatBonusIfNotHasFact>(c => {
                c.Descriptor = ModifierDescriptor.Racial;
                c.Stat = StatType.Intelligence;
                c.Value = 2;
                c.m_CheckedFacts = new BlueprintUnitFactReference[] {
                    IsekaiDarkElfHeritageReference,
                    IsekaiHighElfHeritageReference,
                    IsekaiWoodElfHeritageReference,
                };
            });
            ElfRace.AddComponent<AddStatBonusIfNotHasFact>(c => {
                c.Descriptor = ModifierDescriptor.Racial;
                c.Stat = StatType.Constitution;
                c.Value = -2;
                c.m_CheckedFacts = new BlueprintUnitFactReference[] {
                    DestinyBeyondBirthMythicFeat.ToReference<BlueprintUnitFactReference>(),
                    IsekaiDarkElfHeritageReference,
                    IsekaiHighElfHeritageReference,
                    IsekaiWoodElfHeritageReference,
                };
            });
        }
    }
}