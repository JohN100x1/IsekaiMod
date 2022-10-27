using IsekaiMod.Utilities;
using IsekaiMod.Extensions;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Enums.Damage;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Commands.Base;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.ElementsSystem;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.Visual.Animation.Kingmaker.Actions;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.ActivatableAbilities;

namespace IsekaiMod.Content.Heritages
{
    internal class TieflingHeritageSuccubus
    {
        private static readonly int AttributeBoostAmount = 61;
        private static readonly int CharismaBoostAmount = 72;

        public static void Add()
        {

            // TODO: Change DemonWingsAbility to custom use custom icon (create new BlueprintActivatableAbility)
            // TODO: use diabolic wings
            // TODO: rework charm to scale with charisma
            // TODO: add perception and persuasion as class skills
            // TODO: add an ability to summon a babau
            // TODO: attacks apply negative levels

            // Charm Ability
            var ICON_CHARM = AssetLoader.LoadInternal("Abilities", "ICON_CHARM.png");
            var DominatePersonBuff = Resources.GetBlueprint<BlueprintBuff>("c0f4e1c24c9cd334ca988ed1bd9d201f");
            var SuccubusCharmAbility = Helpers.CreateBlueprint<BlueprintAbility>("SuccubusCharmAbility", bp => {
                bp.SetName("Succubus Charm");
                bp.SetDescription("You can make any creature fight on your side as if it was your ally. " +
                    "It will {g|Encyclopedia:Attack}attack{/g} your opponents to the best of its ability. " +
                    "However this creature will try to throw off the domination effect, making a {g|Encyclopedia:Saving_Throw}Will save{/g} each {g|Encyclopedia:Combat_Round}round{/g}.");
                bp.m_Icon = ICON_CHARM;
                bp.AddComponent<SpellComponent>(c => {
                    c.m_Flags = 0;
                    c.School = SpellSchool.Enchantment;
                });
                bp.AddComponent<SpellDescriptorComponent>(c => {
                    c.Descriptor = SpellDescriptor.MindAffecting | SpellDescriptor.Compulsion;
                });
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.SavingThrowType = SavingThrowType.Will;
                    c.Actions = Helpers.CreateActionList(
                    new ContextActionConditionalSaved()
                    {
                        Succeed = new ActionList(),
                        Failed = Helpers.CreateActionList(
                        new ContextActionApplyBuff()
                        {
                            m_Buff = DominatePersonBuff.ToReference<BlueprintBuffReference>(),
                            Permanent = false,
                            DurationValue = new ContextDurationValue()
                            {
                                Rate = DurationRate.Minutes,
                                m_IsExtendable = true,
                                DiceCountValue = 0,
                                BonusValue = new ContextValue()
                                {
                                    Value = 0,
                                    ValueType = ContextValueType.Rank
                                }
                            },
                            IsFromSpell = false,
                        }),
                    });
                });

                bp.Type = AbilityType.SpellLike;
                bp.Range = AbilityRange.Medium;
                bp.m_AllowNonContextActions = false;
                bp.LocalizedDuration = Helpers.CreateString($"{bp.name}.Duration", "1 minute/level");
                bp.LocalizedSavingThrow = Helpers.CreateString($"{bp.name}.SavingThrow", "Will negates");
                bp.CanTargetFriends = true;
                bp.CanTargetEnemies = true;
                bp.CanTargetSelf = false;
                bp.EffectOnEnemy = AbilityEffectOnUnit.None;
                bp.Animation = UnitAnimationActionCastSpell.CastAnimationStyle.Directional;
                bp.ActionType = UnitCommand.CommandType.Standard;
                bp.AvailableMetamagic = Metamagic.Heighten | Metamagic.Reach | Metamagic.CompletelyNormal;
            });
            // Wings Ability
            var DemonWingsAbility = Resources.GetBlueprint<BlueprintActivatableAbility>("9ae14c50ef7a28e468b585c673b5c48f");

            var TieflingHeritageSelection = Resources.GetBlueprint<BlueprintFeatureSelection>("c862fd0e4046d2d4d9702dd60474a181");
            var ICON_SUCCUBUS = AssetLoader.LoadInternal("Heritages", "ICON_SUCCUBUS.png");
            var TieflingHeritageSuccubus = Helpers.CreateBlueprint<BlueprintFeature>("TieflingHeritageSuccubus", bp => {
                bp.SetName("Isekai Succubus");
                bp.SetDescription("Otherworldly entities who are reincarnated into the world of Golarion as a Succubus have both extreme beauty and power. " +
                    "They have a voracious appetite for sensory pleasures and carnal delights.\n" +
                    "Isekai Succubus have a +72 racial bonus {g|Encyclopedia:Bonus}bonus{/g} to {g|Encyclopedia:Charisma}Charisma{/g} and a +60 racial bonus {g|Encyclopedia:Bonus}bonus{/g} to all other attributes. " +
                    "They gain a +100 racial {g|Encyclopedia:Bonus}bonus{/g} to {g|Encyclopedia:Armor_Class}AC{/g}, have {g|Encyclopedia:Damage_Reduction}DR{/g} 100/—, and a {g|Encyclopedia:Spell_Resistance}spell resistance{/g} of 100. " +
                    "They can use the Charm {g|Encyclopedia:Spell}spell{/g}.");
                bp.m_Icon = ICON_SUCCUBUS;
                bp.Ranks = 1;
                bp.IsClassFeature = true;

                // Add boost to all attributes
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = Kingmaker.Enums.ModifierDescriptor.Racial;
                    c.Stat = StatType.Strength;
                    c.Value = AttributeBoostAmount;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = Kingmaker.Enums.ModifierDescriptor.Racial;
                    c.Stat = StatType.Dexterity;
                    c.Value = AttributeBoostAmount;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = Kingmaker.Enums.ModifierDescriptor.Racial;
                    c.Stat = StatType.Constitution;
                    c.Value = AttributeBoostAmount;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = Kingmaker.Enums.ModifierDescriptor.Racial;
                    c.Stat = StatType.Intelligence;
                    c.Value = AttributeBoostAmount;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = Kingmaker.Enums.ModifierDescriptor.Racial;
                    c.Stat = StatType.Wisdom;
                    c.Value = AttributeBoostAmount;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = Kingmaker.Enums.ModifierDescriptor.Racial;
                    c.Stat = StatType.Charisma;
                    c.Value = CharismaBoostAmount;
                });


                // Add AC Bonus
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = Kingmaker.Enums.ModifierDescriptor.Racial;
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
                        DemonWingsAbility.ToReference<BlueprintUnitFactReference>()
                    };
                });

                bp.Groups = new FeatureGroup[] { FeatureGroup.Racial, FeatureGroup.TieflingHeritage };
            });
            TieflingHeritageSelection.m_AllFeatures = TieflingHeritageSelection.m_AllFeatures.AddToArray(TieflingHeritageSuccubus.ToReference<BlueprintFeatureReference>());
        }
    }
}
