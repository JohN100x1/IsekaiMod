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

            var TieflingHeritageSelection = Resources.GetBlueprint<BlueprintFeatureSelection>("c862fd0e4046d2d4d9702dd60474a181");
            var ICON_SUCCUBUS = AssetLoader.LoadInternal("Heritages", "ICON_SUCCUBUS.png");
            var IsekaiSuccubusHeritage = Helpers.CreateBlueprint<BlueprintFeature>("IsekaiSuccubusHeritage", bp => {
                bp.SetName("Isekai Succubus");
                bp.SetDescription("Otherworldly entities who are reincarnated into the world of Golarion as a Succubus have both extreme beauty and power. " +
                    "They have a voracious appetite for sensory pleasures and carnal delights.\n" +
                    "................................................");
                bp.m_Icon = ICON_SUCCUBUS;
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


                // Add AC Bonus
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Racial;
                    c.Stat = StatType.AC;
                    c.Value = 100;
                });
                // Add DR Bonus
                bp.AddComponent<AddDamageResistancePhysical>(c => {
                    c.Value = 100;
                });
                // Add Spell Resistance
                bp.AddComponent<AddSpellResistance>(c => {
                    c.Value = new ContextValue { Value = 100 };
                });

                // Add Energy Damage Immunity
                bp.AddComponent<AddEnergyImmunity>(c => {
                    c.Type = DamageEnergyType.Acid;
                });
                bp.AddComponent<AddEnergyImmunity>(c => {
                    c.Type = DamageEnergyType.Cold;
                });
                bp.AddComponent<AddEnergyImmunity>(c => {
                    c.Type = DamageEnergyType.Electricity;
                });
                bp.AddComponent<AddEnergyImmunity>(c => {
                    c.Type = DamageEnergyType.Fire;
                });
                bp.AddComponent<AddEnergyImmunity>(c => {
                    c.Type = DamageEnergyType.Sonic;
                });
                bp.AddComponent<AddEnergyImmunity>(c => {
                    c.Type = DamageEnergyType.Unholy;
                });
                bp.AddComponent<AddEnergyImmunity>(c => {
                    c.Type = DamageEnergyType.NegativeEnergy;
                });


                // Add Descriptor Immunity
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.Compulsion
                    | SpellDescriptor.Charm
                    | SpellDescriptor.Blindness
                    | SpellDescriptor.Fatigue
                    | SpellDescriptor.Exhausted
                    | SpellDescriptor.Death
                    | SpellDescriptor.Poison
                    | SpellDescriptor.Sickened
                    | SpellDescriptor.Disease
                    | SpellDescriptor.Petrified
                    | SpellDescriptor.Paralysis
                    | SpellDescriptor.NegativeLevel
                    | SpellDescriptor.StatDebuff
                    | SpellDescriptor.MindAffecting
                    | SpellDescriptor.Fear
                    | SpellDescriptor.Daze
                    | SpellDescriptor.Acid
                    | SpellDescriptor.Cold
                    | SpellDescriptor.Electricity
                    | SpellDescriptor.Force
                    | SpellDescriptor.Sonic
                    | SpellDescriptor.Evil
                    | SpellDescriptor.Chaos
                    | SpellDescriptor.Bleed
                    | SpellDescriptor.Fire;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = SpellDescriptor.Compulsion
                    | SpellDescriptor.Charm
                    | SpellDescriptor.Fatigue
                    | SpellDescriptor.Exhausted
                    | SpellDescriptor.Death
                    | SpellDescriptor.Poison
                    | SpellDescriptor.Sickened
                    | SpellDescriptor.Disease
                    | SpellDescriptor.Petrified
                    | SpellDescriptor.NegativeLevel
                    | SpellDescriptor.StatDebuff
                    | SpellDescriptor.MindAffecting
                    | SpellDescriptor.Fear
                    | SpellDescriptor.Daze
                    | SpellDescriptor.Acid
                    | SpellDescriptor.Cold
                    | SpellDescriptor.Electricity
                    | SpellDescriptor.Force
                    | SpellDescriptor.Sonic
                    | SpellDescriptor.Evil
                    | SpellDescriptor.Chaos
                    | SpellDescriptor.Bleed
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
            });
            TieflingHeritageSelection.m_AllFeatures = TieflingHeritageSelection.m_AllFeatures.AddToArray(IsekaiSuccubusHeritage.ToReference<BlueprintFeatureReference>());
        }
    }
}
