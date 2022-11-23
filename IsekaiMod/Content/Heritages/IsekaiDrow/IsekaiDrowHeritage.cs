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

namespace IsekaiMod.Content.Heritages.IsekaiDrow
{
    internal class IsekaiDrowHeritage
    {
        public static void Add()
        {
            // Drow Abilities
            var DrowPoisonAbility = Resources.GetModBlueprint<BlueprintAbility>("DrowPoisonAbility");
            var DrowPoisonResource = Resources.GetModBlueprint<BlueprintAbilityResource>("DrowPoisonResource");

            // Drow Heritage
            var Icon_Drow = AssetLoader.LoadInternal("Heritages", "ICON_DROW.png");
            var IsekaiDrowHeritage = Helpers.CreateBlueprint<BlueprintFeature>("IsekaiDrowHeritage", bp => {
                bp.SetName("Isekai Drow");
                bp.SetDescription("Otherworldly entities who are reincarnated into the world of Golarion as a Drow have both extreme beauty and power. "
                    + "Also called Dark Elves, they are a cruel and cunning dark reflection of the elven race.\n"
                    + "The Isekai Drow has a +2 racial {g|Encyclopedia:Bonus}bonus{/g} to {g|Encyclopedia:Dexterity}Dexterity{/g}, {g|Encyclopedia:Intelligence}Intelligence{/g}, "
                    + "{g|Encyclopedia:Wisdom}Wisdom{/g}, and {g|Encyclopedia:Charisma}Charisma{/g}. "
                    + "They have spell resistance equal to 11 + their character level. "
                    + "They can also use the Drow Poison ability as a swift action a number of times per day equal to their Charisma modifier.");
                bp.m_Icon = Icon_Drow;
                bp.Ranks = 1;
                bp.IsClassFeature = true;

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
                    c.Value = 2;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Racial;
                    c.Stat = StatType.Charisma;
                    c.Value = 2;
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
                    c.m_StepLevel = 11;
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
            });

            // Add to Elven Heritage Selection
            var ElvenHeritageSelection = Resources.GetBlueprint<BlueprintFeatureSelection>("5482f879dcfd40f9a3168fdb48bc938c");
            ElvenHeritageSelection.m_AllFeatures = ElvenHeritageSelection.m_AllFeatures.AddToArray(IsekaiDrowHeritage.ToReference<BlueprintFeatureReference>());
        }
    }
}
