using HarmonyLib;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Designers.Mechanics.Buffs;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.Enums.Damage;
using Kingmaker.ResourceLinks;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Abilities.Components.Base;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Commands.Base;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.UnitLogic.Mechanics.Properties;
using Kingmaker.Visual.Animation.Kingmaker.Actions;
using System.Collections.Generic;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Heritages {

    internal class IsekaiSuccubusHeritage {
        private static readonly BlueprintFeature DestinyBeyondBirthMythicFeat = BlueprintTools.GetBlueprint<BlueprintFeature>("325f078c584318849bfe3da9ea245b9d");
        private static readonly BlueprintBuff DominatePersonBuff = BlueprintTools.GetBlueprint<BlueprintBuff>("c0f4e1c24c9cd334ca988ed1bd9d201f");
        private static readonly BlueprintAbilityResource TieflingSpellLikeResource = BlueprintTools.GetBlueprint<BlueprintAbilityResource>("803d7e39e05fa2a47a7e2424d0e4b623");

        public static void Add() {
            // Succubus Abilities
            var Icon_Charm = AssetLoader.LoadInternal(IsekaiContext, "Features", "ICON_CHARM.png");
            var SuccubusCharmUnitProperty = Helpers.CreateBlueprint<BlueprintUnitProperty>(IsekaiContext, "SuccubusCharmUnitProperty", bp => {
                bp.name = "SuccubusCharmUnitProperty";
                bp.AddComponent<SimplePropertyGetter>(c => {
                    c.Property = UnitProperty.Level;
                });
                bp.AddComponent<SimplePropertyGetter>(c => {
                    c.Property = UnitProperty.StatBonusCharisma;
                });
                bp.BaseValue = 10;
                bp.OperationOnComponents = BlueprintUnitProperty.MathOperation.Sum;
            });
            var SuccubusCharmAbility = Helpers.CreateBlueprint<BlueprintAbility>(IsekaiContext, "SuccubusCharmAbility", bp => {
                bp.SetName(IsekaiContext, "Succubus Charm");
                bp.SetDescription(IsekaiContext, "You can make any creature fight on your side as if it was your ally. "
                    + "It will {g|Encyclopedia:Attack}attack{/g} your opponents to the best of its ability. "
                    + "However this creature will try to throw off the domination effect, making a {g|Encyclopedia:Saving_Throw}Will save{/g} each {g|Encyclopedia:Combat_Round}round{/g}.");
                bp.m_Icon = Icon_Charm;
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.SavingThrowType = SavingThrowType.Will;
                    c.Actions = ActionFlow.DoSingle<ContextActionConditionalSaved>(c => {
                        c.Succeed = ActionFlow.DoNothing();
                        c.Failed = ActionFlow.DoSingle<ContextActionApplyBuff>(c => {
                            c.m_Buff = DominatePersonBuff.ToReference<BlueprintBuffReference>();
                            c.DurationValue = new ContextDurationValue() {
                                Rate = DurationRate.Minutes,
                                m_IsExtendable = true,
                                DiceCountValue = 0,
                                BonusValue = Values.CreateContextRankValue(AbilityRankType.Default)
                            };
                        });
                    });
                });
                bp.AddComponent<SpellComponent>(c => {
                    c.School = SpellSchool.Enchantment;
                });
                bp.AddComponent<SpellDescriptorComponent>(c => {
                    c.Descriptor = SpellDescriptor.MindAffecting | SpellDescriptor.Compulsion;
                });
                bp.AddComponent<AbilitySpawnFx>(c => {
                    c.PrefabLink = new PrefabLink() { AssetId = "c14a2f46018cb0e41bfeed61463510ff" };
                    c.Time = AbilitySpawnFxTime.OnApplyEffect;
                    c.Anchor = AbilitySpawnFxAnchor.SelectedTarget;
                });
                bp.AddComponent<ContextSetAbilityParams>(c => {
                    c.DC = Values.CreateContextCasterCustomPropertyValue(SuccubusCharmUnitProperty);
                });
                bp.AddComponent<AbilityResourceLogic>(c => {
                    c.m_RequiredResource = TieflingSpellLikeResource.ToReference<BlueprintAbilityResourceReference>();
                    c.m_IsSpendResource = true;
                    c.CostIsCustom = false;
                    c.Amount = 1;
                    c.ResourceCostIncreasingFacts = new List<BlueprintUnitFactReference>();
                    c.ResourceCostDecreasingFacts = new List<BlueprintUnitFactReference>();
                });
                bp.Type = AbilityType.SpellLike;
                bp.Range = AbilityRange.Medium;
                bp.CanTargetEnemies = true;
                bp.CanTargetFriends = true;
                bp.Animation = UnitAnimationActionCastSpell.CastAnimationStyle.Directional;
                bp.ActionType = UnitCommand.CommandType.Standard;
                bp.AvailableMetamagic = Metamagic.Heighten | Metamagic.Reach | Metamagic.CompletelyNormal;
                bp.LocalizedDuration = Helpers.CreateString(IsekaiContext, $"{bp.name}.Duration", "1 minute/level");
                bp.LocalizedSavingThrow = Helpers.CreateString(IsekaiContext, $"{bp.name}.SavingThrow", "Will negates");
            });
            var DevilWingsAbility = BlueprintTools.GetModBlueprint<BlueprintActivatableAbility>(IsekaiContext, "DevilWingsAbility");
            var DemonWingsAbility = BlueprintTools.GetModBlueprint<BlueprintActivatableAbility>(IsekaiContext, "DemonWingsAbility");
            var BlackWingsAbility = BlueprintTools.GetModBlueprint<BlueprintActivatableAbility>(IsekaiContext, "BlackWingsAbility");

            // Succubus Heritage
            var Icon_Succubus = AssetLoader.LoadInternal(IsekaiContext, "Heritages", "ICON_SUCCUBUS.png");
            var IsekaiSuccubusHeritage = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiSuccubusHeritage", bp => {
                bp.SetName(IsekaiContext, "Isekai Succubus");
                bp.SetDescription(IsekaiContext, "Otherworldly entities who are reincarnated into the world of Golarion as a Succubus have both extreme beauty and power, and often "
                    + "have a voracious appetite for sensory pleasures and carnal delights.\n"
                    + "The Isekai Succubus has a +2 racial {g|Encyclopedia:Bonus}bonus{/g} to {g|Encyclopedia:Dexterity}Dexterity{/g} and {g|Encyclopedia:Intelligence}Intelligence{/g}, "
                    + "a +4 racial bonus to {g|Encyclopedia:Charisma}Charisma{/g}, "
                    + "a -2 {g|Encyclopedia:Penalty}penalty{/g} to {g|Encyclopedia:Strength}Strength{/g}, and a +2 racial bonus on {g|Encyclopedia:Persuasion}Persuasion{/g} and "
                    + "{g|Encyclopedia:Perception}Perception checks{/g}. "
                    + "They have DR 10/Cold Iron or Good, and have spell resistance equal to 10 + their character level. "
                    + "They have immunity to fire, electricity, and poisons as well as acid and cold resistance 20. "
                    + "They can also use the Charm spell once per day.");
                bp.m_Icon = Icon_Succubus;

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
                    c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
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
                        DevilWingsAbility.ToReference<BlueprintUnitFactReference>(),
                        DemonWingsAbility.ToReference<BlueprintUnitFactReference>(),
                        BlackWingsAbility.ToReference<BlueprintUnitFactReference>()
                    };
                });

                bp.Groups = new FeatureGroup[] { FeatureGroup.Racial, FeatureGroup.TieflingHeritage };
                bp.ReapplyOnLevelUp = true;
            });

            // Add to Tiefling Heritage Selection
            var TieflingHeritageSelection = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("c862fd0e4046d2d4d9702dd60474a181");
            TieflingHeritageSelection.m_AllFeatures = TieflingHeritageSelection.m_AllFeatures.AddToArray(IsekaiSuccubusHeritage.ToReference<BlueprintFeatureReference>());
        }
    }
}