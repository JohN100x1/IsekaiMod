using IsekaiMod.Utilities;
using IsekaiMod.Extensions;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Enums.Damage;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.Enums;
using Kingmaker.Designers.Mechanics.Buffs;
using Kingmaker.UnitLogic.Mechanics.Components;

namespace IsekaiMod.Content.Heritages
{
    internal class IsekaiSuccubusHeritage
    {
        public static void Add()
        {
            // TODO: add an ability to summon a babau
            // TODO: attacks apply negative levels

            var DestinyBeyondBirthMythicFeat = Resources.GetBlueprint<BlueprintFeature>("325f078c584318849bfe3da9ea245b9d");

            // Succubus Abilities
            var SuccubusCharmAbility = Resources.GetModBlueprint<BlueprintAbility>("SuccubusCharmAbility");
            var SuccubusWingsAbility = Resources.GetModBlueprint<BlueprintActivatableAbility>("SuccubusWingsAbility");

            // Succubus Heritage
            var Icon_Succubus = AssetLoader.LoadInternal("Heritages", "ICON_SUCCUBUS.png");
            var IsekaiSuccubusHeritage = Helpers.CreateBlueprint<BlueprintFeature>("IsekaiSuccubusHeritage", bp => {
                bp.SetName("Isekai Succubus");
                bp.SetDescription("Otherworldly entities who are reincarnated into the world of Golarion as a Succubus have both extreme beauty and power, and often " +
                    "have a voracious appetite for sensory pleasures and carnal delights.\n" +
                    "The Isekai Succubus has a +4 racial {g|Encyclopedia:Bonus}bonus{/g} to {g|Encyclopedia:Charisma}Charisma{/g}, a -2 {g|Encyclopedia:Penalty}penalty{/g} to "
                    + "{g|Encyclopedia:Strength}Strength{/g}, and a +2 racial bonus on {g|Encyclopedia:Persuasion}Persuasion{/g} and {g|Encyclopedia:Perception}Perception checks{/g}. "
                    + "They have DR 10/Cold Iron or Good, and have spell resistance equal to 10 + their character level. "
                    + "They have immunity to fire, electricity, and poisons as well as acid and cold resistance 20. "
                    + "They can also use the Charm spell once per day.");
                bp.m_Icon = Icon_Succubus;
                bp.Ranks = 1;
                bp.IsClassFeature = true;

                // Attributes
                bp.AddComponent<AddStatBonusIfHasFact>(c => {
                    c.Descriptor = ModifierDescriptor.Racial;
                    c.Stat = StatType.Strength;
                    c.Value = -2;
                    c.InvertCondition = true;
                    c.m_CheckedFacts = new BlueprintUnitFactReference[] { DestinyBeyondBirthMythicFeat.ToReference<BlueprintUnitFactReference>() };
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Racial;
                    c.Stat = StatType.Charisma;
                    c.Value = 4;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Racial;
                    c.Stat = StatType.SkillPerception;
                    c.Value = 2;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Racial;
                    c.Stat = StatType.SkillPersuasion;
                    c.Value = 2;
                });

                // Add DR/cold iron or good
                bp.AddComponent<AddDamageResistancePhysical>(c => {
                    c.Or = true;
                    c.Value = 10;
                    c.BypassedByMaterial = true;
                    c.BypassedByAlignment = true;
                    c.Material = PhysicalDamageMaterial.ColdIron;
                    c.Alignment = DamageAlignment.Good;
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

                // Add Resistance and Immunities
                bp.AddComponent<AddDamageResistanceEnergy>(c => {
                    c.Type = DamageEnergyType.Acid;
                    c.Value = 20;
                });
                bp.AddComponent<AddDamageResistanceEnergy>(c => {
                    c.Type = DamageEnergyType.Cold;
                    c.Value = 20;
                });
                bp.AddComponent<AddDamageResistanceEnergy>(c => {
                    c.Type = DamageEnergyType.Fire;
                    c.Value = 20;
                });
                bp.AddComponent<AddDamageResistanceEnergy>(c => {
                    c.Type = DamageEnergyType.Electricity;
                    c.Value = 20;
                });
                bp.AddComponent<AddEnergyImmunity>(c => {
                    c.Type = DamageEnergyType.Electricity;
                });
                bp.AddComponent<AddEnergyImmunity>(c => {
                    c.Type = DamageEnergyType.Fire;
                });
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.Poison
                    | SpellDescriptor.Electricity
                    | SpellDescriptor.Fire;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = SpellDescriptor.Poison
                    | SpellDescriptor.Electricity
                    | SpellDescriptor.Fire;
                });

                // Add Abilities
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] {
                        SuccubusCharmAbility.ToReference<BlueprintUnitFactReference>(),
                        SuccubusWingsAbility.ToReference<BlueprintUnitFactReference>()
                    };
                });

                bp.Groups = new FeatureGroup[] { FeatureGroup.Racial, FeatureGroup.TieflingHeritage };
                bp.IsClassFeature = true;
                bp.ReapplyOnLevelUp = true;
            });

            // Add to Tiefling Heritage Selection
            var TieflingHeritageSelection = Resources.GetBlueprint<BlueprintFeatureSelection>("c862fd0e4046d2d4d9702dd60474a181");
            TieflingHeritageSelection.m_AllFeatures = TieflingHeritageSelection.m_AllFeatures.AddToArray(IsekaiSuccubusHeritage.ToReference<BlueprintFeatureReference>());
        }
    }
}
