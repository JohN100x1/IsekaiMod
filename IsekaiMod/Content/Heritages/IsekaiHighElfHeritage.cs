using IsekaiMod.Utilities;
using IsekaiMod.Extensions;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.Designers.Mechanics.Buffs;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using UnityEngine;

namespace IsekaiMod.Content.Heritages
{
    internal class IsekaiHighElfHeritage
    {
        private static readonly BlueprintFeature DestinyBeyondBirthMythicFeat = Resources.GetBlueprint<BlueprintFeature>("325f078c584318849bfe3da9ea245b9d");
        private static readonly Sprite Icon_TricksterCharmWhatever = Resources.GetBlueprint<BlueprintAbility>("943328ac5bc8a734e85b5b2af3ae2bf7").m_Icon;
        public static void Add()
        {
            // High Elf Heritage
            var IsekaiHighElfHeritage = Helpers.CreateFeature("IsekaiHighElfHeritage", bp => {
                bp.SetName("Isekai High Elf");
                bp.SetDescription("Otherworldly entities who are reincarnated into the world of Golarion as a High Elf have both extreme beauty and power. "
                    + "They are a refined and cultured reflection of the elven race.\n"
                    + "The Isekai High Elf has a +4 racial {g|Encyclopedia:Bonus}bonus{/g} to {g|Encyclopedia:Wisdom}Wisdom{/g}, a +2 racial bonus to "
                    + "{g|Encyclopedia:Dexterity}Dexterity{/g} and {g|Encyclopedia:Intelligence}Intelligence{/g}, and a -2 penalty to Constitution. "
                    + "They have spell resistance equal to 10 + their character level. "
                    + "They can also cast 4 more spells per day for each spell rank.");
                bp.m_Icon = Icon_TricksterCharmWhatever;

                // Attributes
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Racial;
                    c.Stat = StatType.Dexterity;
                    c.Value = 2;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Racial;
                    c.Stat = StatType.Intelligence;
                    c.Value = 2;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Racial;
                    c.Stat = StatType.Wisdom;
                    c.Value = 4;
                });
                bp.AddComponent<AddStatBonusIfHasFact>(c => {
                    c.Descriptor = ModifierDescriptor.Racial;
                    c.Stat = StatType.Constitution;
                    c.Value = -2;
                    c.InvertCondition = true;
                    c.m_CheckedFacts = new BlueprintUnitFactReference[] { DestinyBeyondBirthMythicFeat.ToReference<BlueprintUnitFactReference>() };
                });

                // Add Spell Resistance
                bp.AddComponent<AddSpellResistance>(c => {
                    c.Value = Values.ContextRankValue(AbilityRankType.StatBonus);
                });
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.StatBonus;
                    c.m_BaseValueType = ContextRankBaseValueType.CharacterLevel;
                    c.m_Progression = ContextRankProgression.BonusValue;
                    c.m_StepLevel = 10;
                });

                // Extra Spells per day
                bp.AddComponent<AddSpellsPerDay>(c => {
                    c.Amount = 4;
                    c.Levels = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
                });

                bp.Groups = new FeatureGroup[0];
                bp.ReapplyOnLevelUp = true;
            });

            // Add to Elven Heritage Selection
            var ElvenHeritageSelection = Resources.GetBlueprint<BlueprintFeatureSelection>("5482f879dcfd40f9a3168fdb48bc938c");
            ElvenHeritageSelection.m_AllFeatures = ElvenHeritageSelection.m_AllFeatures.AddToArray(IsekaiHighElfHeritage.ToReference<BlueprintFeatureReference>());
        }
    }
}
