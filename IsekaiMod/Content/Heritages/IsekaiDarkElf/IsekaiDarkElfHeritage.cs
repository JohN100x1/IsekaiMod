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
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.Designers.Mechanics.Buffs;

namespace IsekaiMod.Content.Heritages.IsekaiDarkElf
{
    internal class IsekaiDarkElfHeritage
    {
        private static readonly BlueprintFeature DestinyBeyondBirthMythicFeat = Resources.GetBlueprint<BlueprintFeature>("325f078c584318849bfe3da9ea245b9d");
        public static void Add()
        {
            // Dark Elf Abilities
            var DrowPoisonAbility = Resources.GetModBlueprint<BlueprintAbility>("DrowPoisonAbility");
            var DrowPoisonResource = Resources.GetModBlueprint<BlueprintAbilityResource>("DrowPoisonResource");

            // Dark Elf Heritage
            var Icon_Dark_Elf = AssetLoader.LoadInternal("Heritages", "ICON_DARK_ELF.png");
            var IsekaiDarkElfHeritage = Helpers.CreateFeature("IsekaiDarkElfHeritage", bp => {
                bp.SetName("Isekai Dark Elf");
                bp.SetDescription("Otherworldly entities who are reincarnated into the world of Golarion as a Dark Elf have both extreme beauty and power. "
                    + "They are a cruel and cunning dark reflection of the elven race.\n"
                    + "The Isekai Dark Elf has a +4 racial {g|Encyclopedia:Bonus}bonus{/g} to {g|Encyclopedia:Intelligence}Intelligence{/g}, a +2 racial bonus to "
                    + "{g|Encyclopedia:Dexterity}Dexterity{/g} and {g|Encyclopedia:Wisdom}Wisdom{/g}, and a -2 penalty to Constitution."
                    + "They have spell resistance equal to 10 + their character level. "
                    + "They can also use the Drow Poison ability as a swift action a number of times per day equal to their Intelligence modifier.");
                bp.m_Icon = Icon_Dark_Elf;

                // Attributes
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Racial;
                    c.Stat = StatType.Dexterity;
                    c.Value = 2;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Racial;
                    c.Stat = StatType.Intelligence;
                    c.Value = 4;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Racial;
                    c.Stat = StatType.Wisdom;
                    c.Value = 2;
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
                    c.Value = new ContextValue()
                    {
                        ValueType = ContextValueType.Rank,
                        ValueRank = AbilityRankType.StatBonus
                    };
                });
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.StatBonus;
                    c.m_BaseValueType = ContextRankBaseValueType.CharacterLevel;
                    c.m_Progression = ContextRankProgression.BonusValue;
                    c.m_StepLevel = 10;
                });

                // Add Resources
                bp.AddComponent<AddAbilityResources>(c => {
                    c.m_Resource = DrowPoisonResource.ToReference<BlueprintAbilityResourceReference>();
                    c.RestoreAmount = true;
                });

                // Add Abilities
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] {
                        DrowPoisonAbility.ToReference<BlueprintUnitFactReference>()
                    };
                });

                bp.Groups = new FeatureGroup[0];
                bp.ReapplyOnLevelUp = true;
            });

            // Add to Elven Heritage Selection
            var ElvenHeritageSelection = Resources.GetBlueprint<BlueprintFeatureSelection>("5482f879dcfd40f9a3168fdb48bc938c");
            ElvenHeritageSelection.m_AllFeatures = ElvenHeritageSelection.m_AllFeatures.AddToArray(IsekaiDarkElfHeritage.ToReference<BlueprintFeatureReference>());
        }
    }
}
