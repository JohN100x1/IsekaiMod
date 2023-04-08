using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.Enums.Damage;
using Kingmaker.Localization;
using Kingmaker.ResourceLinks;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Abilities.Components.Base;
using Kingmaker.UnitLogic.Alignments;
using Kingmaker.UnitLogic.Commands.Base;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.UnitLogic.Mechanics.Conditions;
using Kingmaker.UnitLogic.Mechanics.Properties;
using Kingmaker.Utility;
using Kingmaker.Visual.Animation.Kingmaker.Actions;
using System.Collections.Generic;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.SpecialPower {

    internal class IsekaiChannelPositiveEnergy {
        private static BlueprintFeature Feature; // TODO: simplify AbilityEffectRunAction logic by copying directly

        private static readonly BlueprintFeature ExtraChannel = BlueprintTools.GetBlueprint<BlueprintFeature>("cd9f19775bd9d3343a31a065e93f0c47");
        private static readonly BlueprintFeature SelectiveChannel = BlueprintTools.GetBlueprint<BlueprintFeature>("fd30c69417b434d47b6b03b9c1f568ff");
        private static readonly BlueprintFeature NegativeEnergyAffinity = BlueprintTools.GetBlueprint<BlueprintFeature>("d5ee498e19722854198439629c1841a5");
        private static readonly BlueprintAbility ChannelPositiveHarm = BlueprintTools.GetBlueprint<BlueprintAbility>("279447a6bf2d3544d93a0a39c3b8e91d");
        private static readonly BlueprintAbility ChannelPositiveHeal = BlueprintTools.GetBlueprint<BlueprintAbility>("f5fc9a1a2a3c1a946a31b320d1dd31b2");
        private static readonly BlueprintUnitProperty MythicChannelProperty = BlueprintTools.GetBlueprint<BlueprintUnitProperty>("152e61de154108d489ff34b98066c25c");
        private static readonly BlueprintFeature DeathDomainGreaterUndead = BlueprintTools.GetBlueprint<BlueprintFeature>("49bf8c679d3a7424898a5cd448e5a06b");
        private static readonly BlueprintFeature LifeDominantSoul = BlueprintTools.GetBlueprint<BlueprintFeature>("8f58b4029511b5345981ffaf1da5ea2e");
        private static readonly BlueprintUnitFact ChannelEnergyFact = BlueprintTools.GetBlueprint<BlueprintUnitFact>("93f062bc0bf70e84ebae436e325e30e8");
        private static readonly BlueprintAbilityResource ChannelEnergyResource = BlueprintTools.GetBlueprint<BlueprintAbilityResource>("5e2bba3e07c37be42909a12945c27de7");
        private static readonly PrefabLink HealTargetFX = new() { AssetId = "61602c5b0ac793d489c008e9cb58f631" };

        public static void Add() {
            var HarmAbility = Helpers.CreateBlueprint<BlueprintAbility>(IsekaiContext, "IsekaiChannelPositiveEnergyAbility", bp => {
                bp.SetName(IsekaiContext, "Channel Positive Energy - Damage Undead");
                bp.SetDescription(IsekaiContext, "Channeling positive energy causes a burst that damages every undead creature in a 30-foot radius centered on the caster. The amount of damage "
                    + "inflicted is equal to 1d6 points of damage plus 1d6 points of damage for every two character levels beyond 1st (2d6 at 3rd, 3d6 at 5th, and so on). "
                    + "Creatures that take damage from channeled energy receive a Will save to halve the damage. "
                    + "The DC of this save is equal to 10 + 1/2 the character level + Charisma modifier.");
                bp.m_Icon = ChannelPositiveHarm.Icon;
                bp.LocalizedDuration = new LocalizedString();
                bp.LocalizedSavingThrow = new LocalizedString();
                bp.AvailableMetamagic = Metamagic.Empower | Metamagic.Maximize | Metamagic.Heighten | Metamagic.Quicken;
                bp.Range = AbilityRange.Personal;
                bp.Type = AbilityType.Special;
                bp.CanTargetEnemies = true;
                bp.CanTargetFriends = true;
                bp.EffectOnAlly = AbilityEffectOnUnit.Harmful;
                bp.EffectOnEnemy = AbilityEffectOnUnit.Harmful;
                bp.Animation = UnitAnimationActionCastSpell.CastAnimationStyle.Omni;
                bp.ActionType = UnitCommand.CommandType.Standard;
                bp.ResourceAssetIds = ChannelPositiveHarm.ResourceAssetIds;
                bp.AddComponent<AbilityResourceLogic>(c => {
                    c.m_RequiredResource = ChannelEnergyResource.ToReference<BlueprintAbilityResourceReference>();
                    c.m_IsSpendResource = true;
                    c.Amount = 1;
                    c.ResourceCostIncreasingFacts = new List<BlueprintUnitFactReference>();
                    c.ResourceCostDecreasingFacts = new List<BlueprintUnitFactReference>();
                });
                bp.AddComponent<AbilityTargetsAround>(c => {
                    c.m_Radius = new Feet(30);
                    c.m_TargetType = TargetType.Any;
                    c.m_Condition = ActionFlow.EmptyCondition();
                });
                bp.AddComponent<AbilitySpawnFx>(c => {
                    c.PrefabLink = ChannelPositiveHarm.GetComponent<AbilitySpawnFx>().PrefabLink;
                    c.Time = AbilitySpawnFxTime.OnApplyEffect;
                    c.Anchor = AbilitySpawnFxAnchor.Caster;
                    c.PositionAnchor = AbilitySpawnFxAnchor.None;
                    c.OrientationAnchor = AbilitySpawnFxAnchor.None;
                });
                bp.AddComponent<SpellDescriptorComponent>(c => {
                    c.Descriptor = SpellDescriptor.ChannelPositiveHarm;
                });
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.DamageDice;
                    c.m_BaseValueType = ContextRankBaseValueType.CharacterLevel;
                    c.m_Progression = ContextRankProgression.OnePlusDiv2;
                    c.m_StartLevel = 0;
                    c.m_StepLevel = 0;
                    c.m_Min = 0;
                    c.m_UseMin = false;
                    c.m_Class = new BlueprintCharacterClassReference[0];
                });
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.DamageBonus;
                    c.m_BaseValueType = ContextRankBaseValueType.CustomProperty;
                    c.m_CustomProperty = MythicChannelProperty.ToReference<BlueprintUnitPropertyReference>();
                    c.m_Progression = ContextRankProgression.AsIs;
                    c.m_Min = 0;
                    c.m_UseMin = true;
                });
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.Actions = ActionFlow.DoSingle<Conditional>(c => {
                        c.ConditionsChecker = ActionFlow.IfAny(
                            new ContextConditionHasFact() {
                                m_Fact = NegativeEnergyAffinity.ToReference<BlueprintUnitFactReference>(),
                                Not = true
                            },
                            new ContextConditionHasFact() {
                                m_Fact = DeathDomainGreaterUndead.ToReference<BlueprintUnitFactReference>(),
                                Not = false
                            });
                        c.IfTrue = ActionFlow.DoNothing();
                        c.IfFalse = ActionFlow.DoSingle<Conditional>(c => {
                            c.ConditionsChecker = ActionFlow.IfSingle<ContextConditionCasterHasFact>(c => {
                                c.m_Fact = SelectiveChannel.ToReference<BlueprintUnitFactReference>();
                                c.Not = false;
                            });
                            c.IfTrue = ActionFlow.DoSingle<Conditional>(c => {
                                c.ConditionsChecker = ActionFlow.IfSingle<ContextConditionIsEnemy>(c => {
                                    c.Not = false;
                                });
                                c.IfTrue = ActionFlow.DoSingle<ContextActionSavingThrow>(c => {
                                    c.m_ConditionalDCIncrease = new ContextActionSavingThrow.ConditionalDCIncrease[0];
                                    c.Type = SavingThrowType.Will;
                                    c.CustomDC = 0;
                                    c.Actions = ActionFlow.DoSingle<ContextActionDealDamage>(c => {
                                        c.DamageType = new DamageTypeDescription() {
                                            Type = DamageType.Energy,
                                            Common = new DamageTypeDescription.CommomData(),
                                            Physical = new DamageTypeDescription.PhysicalData(),
                                            Energy = DamageEnergyType.PositiveEnergy
                                        };
                                        c.Duration = Values.Duration.Zero;
                                        c.Value = new ContextDiceValue() {
                                            DiceType = DiceType.D6,
                                            DiceCountValue = Values.CreateContextRankValue(AbilityRankType.DamageDice),
                                            BonusValue = Values.CreateContextRankValue(AbilityRankType.DamageBonus)
                                        };
                                        c.IsAoE = true;
                                        c.HalfIfSaved = true;
                                    });
                                });
                                c.IfFalse = ActionFlow.DoNothing();
                            });
                            c.IfFalse = ActionFlow.DoSingle<Conditional>(c => {
                                c.ConditionsChecker = ActionFlow.IfSingle<ContextConditionIsCaster>(c => {
                                    c.Not = true;
                                });
                                c.IfTrue = ActionFlow.DoSingle<ContextActionSavingThrow>(c => {
                                    c.m_ConditionalDCIncrease = new ContextActionSavingThrow.ConditionalDCIncrease[0];
                                    c.Type = SavingThrowType.Will;
                                    c.CustomDC = 0;
                                    c.Actions = ActionFlow.DoSingle<ContextActionDealDamage>(c => {
                                        c.DamageType = new DamageTypeDescription() {
                                            Type = DamageType.Energy,
                                            Common = new DamageTypeDescription.CommomData(),
                                            Physical = new DamageTypeDescription.PhysicalData(),
                                            Energy = DamageEnergyType.PositiveEnergy
                                        };
                                        c.Duration = Values.Duration.Zero;
                                        c.Value = new ContextDiceValue() {
                                            DiceType = DiceType.D6,
                                            DiceCountValue = Values.CreateContextRankValue(AbilityRankType.DamageDice),
                                            BonusValue = Values.CreateContextRankValue(AbilityRankType.DamageBonus)
                                        };
                                        c.IsAoE = true;
                                        c.HalfIfSaved = true;
                                    });
                                });
                                c.IfFalse = ActionFlow.DoNothing();
                            });
                        });
                    });
                });
            });
            var HealAbility = Helpers.CreateBlueprint<BlueprintAbility>(IsekaiContext, "IsekaiChannelPositiveHealAbility", bp => {
                bp.SetName(IsekaiContext, "Channel Positive Energy - Heal Living");
                bp.SetDescription(IsekaiContext, "Channeling positive energy causes a burst that heals every living creature in a 30-foot radius centered on the caster. The amount of damage "
                    + "healed is equal to 1d6 points of damage plus 1d6 points of damage for every two character levels beyond 1st (2d6 at 3rd, 3d6 at 5th, and so on).");
                bp.m_Icon = ChannelPositiveHeal.Icon;
                bp.LocalizedDuration = new LocalizedString();
                bp.LocalizedSavingThrow = new LocalizedString();
                bp.AvailableMetamagic = Metamagic.Empower | Metamagic.Maximize | Metamagic.Heighten | Metamagic.Quicken;
                bp.Range = AbilityRange.Personal;
                bp.Type = AbilityType.Special;
                bp.CanTargetEnemies = true;
                bp.CanTargetFriends = true;
                bp.EffectOnAlly = AbilityEffectOnUnit.Helpful;
                bp.EffectOnEnemy = AbilityEffectOnUnit.Helpful;
                bp.Animation = UnitAnimationActionCastSpell.CastAnimationStyle.Omni;
                bp.ActionType = UnitCommand.CommandType.Standard;
                bp.ResourceAssetIds = ChannelPositiveHeal.ResourceAssetIds;
                bp.AddComponent<AbilityResourceLogic>(c => {
                    c.m_RequiredResource = ChannelEnergyResource.ToReference<BlueprintAbilityResourceReference>();
                    c.m_IsSpendResource = true;
                    c.Amount = 1;
                    c.ResourceCostIncreasingFacts = new List<BlueprintUnitFactReference>();
                    c.ResourceCostDecreasingFacts = new List<BlueprintUnitFactReference>();
                });
                bp.AddComponent<AbilityTargetsAround>(c => {
                    c.m_Radius = new Feet(30);
                    c.m_TargetType = TargetType.Any;
                    c.m_Condition = ActionFlow.EmptyCondition();
                });
                bp.AddComponent<AbilitySpawnFx>(c => {
                    c.PrefabLink = ChannelPositiveHeal.GetComponent<AbilitySpawnFx>().PrefabLink;
                    c.Time = AbilitySpawnFxTime.OnApplyEffect;
                    c.Anchor = AbilitySpawnFxAnchor.Caster;
                });
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.Default;
                    c.m_BaseValueType = ContextRankBaseValueType.CharacterLevel;
                    c.m_Progression = ContextRankProgression.OnePlusDiv2;
                    c.m_StartLevel = 0;
                    c.m_StepLevel = 0;
                    c.m_Min = 0;
                    c.m_UseMin = false;
                    c.m_Class = new BlueprintCharacterClassReference[0];
                });
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.DamageBonus;
                    c.m_BaseValueType = ContextRankBaseValueType.CustomProperty;
                    c.m_CustomProperty = MythicChannelProperty.ToReference<BlueprintUnitPropertyReference>();
                    c.m_Progression = ContextRankProgression.AsIs;
                    c.m_Min = 0;
                    c.m_UseMin = true;
                });
                bp.AddComponent<ContextCalculateSharedValue>(c => {
                    c.ValueType = AbilitySharedValue.Heal;
                    c.Value = new ContextDiceValue() {
                        DiceType = DiceType.D6,
                        DiceCountValue = Values.CreateContextRankValue(AbilityRankType.Default),
                        BonusValue = Values.CreateContextRankValue(AbilityRankType.DamageBonus)
                    };
                    c.Modifier = 1;
                });
                bp.AddComponent<ContextCalculateSharedValue>(c => {
                    c.ValueType = AbilitySharedValue.StatBonus;
                    c.Value = new ContextDiceValue() {
                        DiceType = DiceType.D6,
                        DiceCountValue = 0,
                        BonusValue = Values.CreateContextSharedValue(AbilitySharedValue.Heal)
                    };
                    c.Modifier = 0.5;
                });
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.Actions = ActionFlow.DoSingle<Conditional>(c => {
                        c.ConditionsChecker = ActionFlow.IfSingle<ContextConditionHasFact>(c => {
                            c.m_Fact = NegativeEnergyAffinity.ToReference<BlueprintUnitFactReference>();
                            c.Not = true;
                        });
                        c.IfTrue = ActionFlow.DoSingle<Conditional>(c => {
                            c.ConditionsChecker = ActionFlow.IfSingle<ContextConditionCasterHasFact>(c => {
                                c.m_Fact = SelectiveChannel.ToReference<BlueprintUnitFactReference>();
                                c.Not = false;
                            });
                            c.IfTrue = ActionFlow.DoSingle<Conditional>(c => {
                                c.ConditionsChecker = ActionFlow.IfAll(
                                    new ContextConditionIsAlly() {
                                        Not = false
                                    },
                                    new ContextConditionHasFact() {
                                        m_Fact = LifeDominantSoul.ToReference<BlueprintUnitFactReference>(),
                                        Not = true
                                    });
                                c.IfTrue = Helpers.CreateActionList(
                                    new ContextActionHealTarget() {
                                        Value = new ContextDiceValue() {
                                            DiceType = DiceType.Zero,
                                            DiceCountValue = 0,
                                            BonusValue = Values.CreateContextSharedValue(AbilitySharedValue.Heal)
                                        }
                                    },
                                    new ContextActionSpawnFx() {
                                        PrefabLink = HealTargetFX
                                    });
                                c.IfFalse = ActionFlow.DoSingle<Conditional>(c => {
                                    c.ConditionsChecker = ActionFlow.IfAll(
                                        new ContextConditionIsAlly() {
                                            Not = false
                                        },
                                        new ContextConditionHasFact() {
                                            m_Fact = LifeDominantSoul.ToReference<BlueprintUnitFactReference>(),
                                            Not = false
                                        });
                                    c.IfTrue = Helpers.CreateActionList(
                                        new ContextActionHealTarget() {
                                            Value = new ContextDiceValue() {
                                                DiceType = DiceType.Zero,
                                                DiceCountValue = 0,
                                                BonusValue = Values.CreateContextSharedValue(AbilitySharedValue.StatBonus)
                                            }
                                        },
                                        new ContextActionSpawnFx() {
                                            PrefabLink = HealTargetFX
                                        }
                                        );
                                    c.IfFalse = ActionFlow.DoNothing();
                                }
                                    );
                            }
                            );
                            c.IfFalse = ActionFlow.DoSingle<Conditional>(c => {
                                c.ConditionsChecker = ActionFlow.IfSingle<ContextConditionHasFact>(c => {
                                    c.m_Fact = LifeDominantSoul.ToReference<BlueprintUnitFactReference>();
                                    c.Not = false;
                                });
                                c.IfTrue = Helpers.CreateActionList(
                                    new ContextActionHealTarget() {
                                        Value = new ContextDiceValue() {
                                            DiceType = DiceType.Zero,
                                            DiceCountValue = 0,
                                            BonusValue = Values.CreateContextSharedValue(AbilitySharedValue.StatBonus)
                                        }
                                    },
                                    new ContextActionSpawnFx() {
                                        PrefabLink = HealTargetFX
                                    });
                                c.IfFalse = Helpers.CreateActionList(
                                    new ContextActionHealTarget() {
                                        Value = new ContextDiceValue() {
                                            DiceType = DiceType.Zero,
                                            DiceCountValue = 0,
                                            BonusValue = Values.CreateContextSharedValue(AbilitySharedValue.Heal)
                                        }
                                    },
                                    new ContextActionSpawnFx() {
                                        PrefabLink = HealTargetFX
                                    });
                            });
                        });
                        c.IfFalse = ActionFlow.DoNothing();
                    });
                });
                bp.AddComponent<AbilityUseOnRest>(c => {
                    c.Type = AbilityUseOnRestType.HealDamageMass;
                    c.BaseValue = 10;
                    c.AddCasterLevel = true;
                    c.MultiplyByCasterLevel = false;
                    c.MaxCasterLevel = 0;
                });
                bp.AddComponent<SpellDescriptorComponent>(c => {
                    c.Descriptor = SpellDescriptor.RestoreHP | SpellDescriptor.ChannelPositiveHeal;
                });
            });
            Feature = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiChannelPositiveEnergyFeature", bp => {
                bp.SetName(IsekaiContext, "Channel Positive Energy");
                bp.SetDescription(IsekaiContext, "You gain the supernatural ability to channel positive energy like a cleric. You use your character level as your effective cleric level when "
                    + "channeling positive energy.  You can channel energy a number of times per day equal to 3 + your Charisma modifier.");
                bp.m_Icon = ChannelPositiveHeal.Icon;
                bp.Groups = new FeatureGroup[0];
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] {
                        ChannelEnergyFact.ToReference<BlueprintUnitFactReference>(),
                        HarmAbility.ToReference<BlueprintUnitFactReference>(),
                        HealAbility.ToReference<BlueprintUnitFactReference>()
                    };
                });
                bp.AddComponent<PrerequisiteAlignment>(c => {
                    c.Group = Prerequisite.GroupType.Any;
                    c.Alignment = AlignmentMaskType.Good | AlignmentMaskType.ChaoticNeutral | AlignmentMaskType.TrueNeutral | AlignmentMaskType.LawfulNeutral;
                });
            });

            // Patch extra channel and selective channel feats
            SelectiveChannel.AddPrerequisiteFeature(Feature, Prerequisite.GroupType.Any);
            ExtraChannel.AddPrerequisiteFeature(Feature, Prerequisite.GroupType.Any);

            // Add to Selection
            SpecialPowerSelection.AddToSelection(Feature);
        }
        public static BlueprintFeature Get() {
            return Feature;
        }
        public static BlueprintFeatureReference GetReference() {
            return Feature.ToReference<BlueprintFeatureReference>();
        }
    }
}