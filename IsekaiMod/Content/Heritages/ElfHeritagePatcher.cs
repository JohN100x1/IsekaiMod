using IsekaiMod.Components;
using IsekaiMod.Extensions;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Buffs;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.FactLogic;

namespace IsekaiMod.Content.Heritages
{
    class ElfHeritagePatcher
    {
        private static readonly BlueprintFeature DestinyBeyondBirthMythicFeat = Resources.GetBlueprint<BlueprintFeature>("325f078c584318849bfe3da9ea245b9d");
        public static void Patch()
        {
            // Get Isekai Heritages
            var IsekaiDarkElfHeritage = Resources.GetModBlueprint<BlueprintFeature>("IsekaiDarkElfHeritage");
            var IsekaiHighElfHeritage = Resources.GetModBlueprint<BlueprintFeature>("IsekaiHighElfHeritage");
            var IsekaiWoodElfHeritage = Resources.GetModBlueprint<BlueprintFeature>("IsekaiWoodElfHeritage");

            // Don't Add stat bonuses from Elf Race if Isekai Elf Heritage is selected
            var ElfRace = Resources.GetBlueprint<BlueprintRace>("25a5878d125338244896ebd3238226c8");
            ElfRace.RemoveComponents<AddStatBonus>();
            ElfRace.RemoveComponents<AddStatBonusIfHasFact>();
            ElfRace.AddComponent<AddStatBonusIfNotHasFact>(c => {
                c.Descriptor = ModifierDescriptor.Racial;
                c.Stat = StatType.Dexterity;
                c.Value = 2;
                c.m_CheckedFacts = new BlueprintUnitFactReference[] {
                    IsekaiDarkElfHeritage.ToReference<BlueprintUnitFactReference>(),
                    IsekaiHighElfHeritage.ToReference<BlueprintUnitFactReference>(),
                    IsekaiWoodElfHeritage.ToReference<BlueprintUnitFactReference>(),
                };
            });
            ElfRace.AddComponent<AddStatBonusIfNotHasFact>(c => {
                c.Descriptor = ModifierDescriptor.Racial;
                c.Stat = StatType.Intelligence;
                c.Value = 2;
                c.m_CheckedFacts = new BlueprintUnitFactReference[] {
                    IsekaiDarkElfHeritage.ToReference<BlueprintUnitFactReference>(),
                    IsekaiHighElfHeritage.ToReference<BlueprintUnitFactReference>(),
                    IsekaiWoodElfHeritage.ToReference<BlueprintUnitFactReference>(),
                };
            });
            ElfRace.AddComponent<AddStatBonusIfNotHasFact>(c => {
                c.Descriptor = ModifierDescriptor.Racial;
                c.Stat = StatType.Constitution;
                c.Value = -2;
                c.m_CheckedFacts = new BlueprintUnitFactReference[] {
                    DestinyBeyondBirthMythicFeat.ToReference<BlueprintUnitFactReference>(),
                    IsekaiDarkElfHeritage.ToReference<BlueprintUnitFactReference>(),
                    IsekaiHighElfHeritage.ToReference<BlueprintUnitFactReference>(),
                    IsekaiWoodElfHeritage.ToReference<BlueprintUnitFactReference>(),
                };
            });
        }
    }
}
