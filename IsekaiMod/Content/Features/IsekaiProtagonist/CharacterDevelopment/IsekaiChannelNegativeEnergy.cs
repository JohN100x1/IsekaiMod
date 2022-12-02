using IsekaiMod.Extensions;
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

namespace IsekaiMod.Content.Features.IsekaiProtagonist.CharacterDevelopment
{
    class IsekaiChannelNegativeEnergy
    {
        private static readonly BlueprintFeature NegativeEnergyAffinity = Resources.GetBlueprint<BlueprintFeature>("d5ee498e19722854198439629c1841a5");
        private static readonly BlueprintAbility ChannelNegativeEnergy = Resources.GetBlueprint<BlueprintAbility>("89df18039ef22174b81052e2e419c728");
        private static readonly BlueprintAbility ChannelNegativeHeal = Resources.GetBlueprint<BlueprintAbility>("9be3aa47a13d5654cbcb8dbd40c325f2");
        private static readonly BlueprintUnitProperty MythicChannelProperty = Resources.GetBlueprint<BlueprintUnitProperty>("152e61de154108d489ff34b98066c25c");
        private static readonly BlueprintFeature DeathDomainGreaterLiving = Resources.GetBlueprint<BlueprintFeature>("fd7c08ccd3c7773458eb9613db3e93ad");
        private static readonly BlueprintFeature LifeDominantSoul = Resources.GetBlueprint<BlueprintFeature>("8f58b4029511b5345981ffaf1da5ea2e");
        private static readonly BlueprintUnitFact ChannelEnergyFact = Resources.GetBlueprint<BlueprintUnitFact>("93f062bc0bf70e84ebae436e325e30e8");
        private static readonly BlueprintAbilityResource ChannelEnergyResource = Resources.GetBlueprint<BlueprintAbilityResource>("5e2bba3e07c37be42909a12945c27de7");
        private static readonly PrefabLink HealTargetFX = new() { AssetId = "9a38d742801be084d89bd34318c600e8" };
        public static void Add()
        {
            var ExtraChannel = Resources.GetBlueprint<BlueprintFeature>("cd9f19775bd9d3343a31a065e93f0c47");
            var SelectiveChannel = Resources.GetBlueprint<BlueprintFeature>("fd30c69417b434d47b6b03b9c1f568ff");
            var IsekaiChannelNegativeEnergyAbility = Helpers.CreateBlueprint<BlueprintAbility>("IsekaiChannelNegativeEnergyAbility", bp => {
                bp.SetName("Channel Negative Energy - Damage Living");
                bp.SetDescription("Channeling negative energy causes a burst that damages every living creature in a 30-foot radius centered on the caster. The amount of damage "
                    + "inflicted is equal to 1d6 points of damage plus 1d6 points of damage for every two character levels beyond 1st (2d6 at 3rd, 3d6 at 5th, and so on). "
                    + "Creatures that take damage from channeled energy receive a Will save to halve the damage. "
                    + "The DC of this save is equal to 10 + 1/2 the character level + Charisma modifier.");
                bp.m_Icon = ChannelNegativeEnergy.Icon;
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
                bp.ResourceAssetIds = ChannelNegativeEnergy.ResourceAssetIds;
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
                    c.PrefabLink = ChannelNegativeEnergy.GetComponent<AbilitySpawnFx>().PrefabLink;
                    c.Time = AbilitySpawnFxTime.OnApplyEffect;
                    c.Anchor = AbilitySpawnFxAnchor.Caster;
                    c.PositionAnchor = AbilitySpawnFxAnchor.None;
                    c.OrientationAnchor = AbilitySpawnFxAnchor.None;
                });
                bp.AddComponent<SpellDescriptorComponent>(c => {
                    c.Descriptor = SpellDescriptor.ChannelNegativeHarm;
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
                        c.ConditionsChecker = ActionFlow.IfSingle<ContextConditionHasFact>(c => {
                            c.m_Fact = NegativeEnergyAffinity.ToReference<BlueprintUnitFactReference>();
                            c.Not = false;
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
                                        c.DamageType = new DamageTypeDescription()
                                        {
                                            Type = DamageType.Energy,
                                            Common = new DamageTypeDescription.CommomData(),
                                            Physical = new DamageTypeDescription.PhysicalData(),
                                            Energy = DamageEnergyType.NegativeEnergy
                                        };
                                        c.Duration = new ContextDurationValue()
                                        {
                                            DiceType = DiceType.Zero,
                                            DiceCountValue = 0,
                                            BonusValue = 0,
                                            m_IsExtendable = true,
                                        };
                                        c.Value = new ContextDiceValue()
                                        {
                                            DiceType = DiceType.D6,
                                            DiceCountValue = new ContextValue()
                                            {
                                                ValueType = ContextValueType.Rank,
                                                ValueRank = AbilityRankType.DamageDice
                                            },
                                            BonusValue = new ContextValue()
                                            {
                                                ValueType = ContextValueType.Rank,
                                                ValueRank = AbilityRankType.DamageBonus
                                            }
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
                                        c.DamageType = new DamageTypeDescription()
                                        {
                                            Type = DamageType.Energy,
                                            Common = new DamageTypeDescription.CommomData(),
                                            Physical = new DamageTypeDescription.PhysicalData(),
                                            Energy = DamageEnergyType.NegativeEnergy
                                        };
                                        c.Duration = new ContextDurationValue()
                                        {
                                            m_IsExtendable = true,
                                            DiceCountValue = 0,
                                            BonusValue = 0,
                                        };
                                        c.Value = new ContextDiceValue()
                                        {
                                            DiceType = DiceType.D6,
                                            DiceCountValue = new ContextValue()
                                            {
                                                ValueType = ContextValueType.Rank,
                                                ValueRank = AbilityRankType.DamageDice
                                            },
                                            BonusValue = new ContextValue()
                                            {
                                                ValueType = ContextValueType.Rank,
                                                ValueRank = AbilityRankType.DamageBonus
                                            }
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
            var IsekaiChannelNegativeHealAbility = Helpers.CreateBlueprint<BlueprintAbility>("IsekaiChannelNegativeHealAbility", bp => {
                bp.SetName("Channel Negative Energy - Heal Undead");
                bp.SetDescription("Channeling negative energy causes a burst that heals every undead creature in a 30-foot radius centered on the caster. The amount of damage "
                    + "healed is equal to 1d6 points of damage plus 1d6 points of damage for every two character levels beyond 1st (2d6 at 3rd, 3d6 at 5th, and so on).");
                bp.m_Icon = ChannelNegativeHeal.Icon;
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
                bp.ResourceAssetIds = ChannelNegativeHeal.ResourceAssetIds;
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
                    c.PrefabLink = ChannelNegativeHeal.GetComponent<AbilitySpawnFx>().PrefabLink;
                    c.Time = AbilitySpawnFxTime.OnApplyEffect;
                    c.Anchor = AbilitySpawnFxAnchor.Caster;
                    c.PositionAnchor = AbilitySpawnFxAnchor.None;
                    c.OrientationAnchor = AbilitySpawnFxAnchor.None;
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
                    c.Value = new ContextDiceValue()
                    {
                        DiceType = DiceType.D6,
                        DiceCountValue = new ContextValue()
                        {
                            ValueType = ContextValueType.Rank,
                            Value = 0,
                            ValueRank = AbilityRankType.Default,
                            ValueShared = AbilitySharedValue.Damage,
                            Property = UnitProperty.None,
                            m_AbilityParameter = AbilityParameterType.Level
                        },
                        BonusValue = new ContextValue()
                        {
                            ValueType = ContextValueType.Rank,
                            Value = 0,
                            ValueRank = AbilityRankType.DamageBonus,
                            ValueShared = AbilitySharedValue.Damage,
                            Property = UnitProperty.None,
                            m_AbilityParameter = AbilityParameterType.Level
                        }
                    };
                    c.Modifier = 1;
                });
                bp.AddComponent<ContextCalculateSharedValue>(c => {
                    c.ValueType = AbilitySharedValue.StatBonus;
                    c.Value = new ContextDiceValue()
                    {
                        DiceType = DiceType.D6,
                        DiceCountValue = new ContextValue()
                        {
                            ValueType = ContextValueType.Simple,
                            Value = 0,
                            ValueRank = AbilityRankType.Default,
                            ValueShared = AbilitySharedValue.Damage,
                            Property = UnitProperty.None,
                            m_AbilityParameter = AbilityParameterType.Level
                        },
                        BonusValue = new ContextValue()
                        {
                            ValueType = ContextValueType.Shared,
                            Value = 0,
                            ValueRank = AbilityRankType.StatBonus,
                            ValueShared = AbilitySharedValue.Heal,
                            Property = UnitProperty.None,
                            m_AbilityParameter = AbilityParameterType.Level
                        }
                    };
                    c.Modifier = 0.5;
                });
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.Actions = ActionFlow.DoSingle<Conditional>(c => {
                        c.ConditionsChecker = ActionFlow.IfAny(
                            new ContextConditionHasFact()
                            {
                                m_Fact = NegativeEnergyAffinity.ToReference<BlueprintUnitFactReference>(),
                                Not = false
                            },
                            new ContextConditionHasFact()
                            {
                                m_Fact = DeathDomainGreaterLiving.ToReference<BlueprintUnitFactReference>(),
                                Not = false
                            });
                        c.IfTrue = ActionFlow.DoSingle<Conditional>(c => {
                            c.ConditionsChecker = ActionFlow.IfSingle<ContextConditionCasterHasFact>(c => {
                                c.m_Fact = SelectiveChannel.ToReference<BlueprintUnitFactReference>();
                                c.Not = false;
                            });
                            c.IfTrue = ActionFlow.DoSingle<Conditional>(c => {
                                c.ConditionsChecker = ActionFlow.IfAll(
                                    new ContextConditionIsAlly()
                                    {
                                        Not = false
                                    },
                                    new ContextConditionHasFact()
                                    {
                                        m_Fact = LifeDominantSoul.ToReference<BlueprintUnitFactReference>(),
                                        Not = true
                                    });
                                c.IfTrue = Helpers.CreateActionList(
                                    new ContextActionHealTarget()
                                    {
                                        Value = new ContextDiceValue()
                                        {
                                            DiceType = DiceType.Zero,
                                            DiceCountValue = new ContextValue()
                                            {
                                                ValueType = ContextValueType.Simple,
                                                Value = 0,
                                                ValueRank = AbilityRankType.Default,
                                                ValueShared = AbilitySharedValue.Damage,
                                                Property = UnitProperty.None,
                                                m_AbilityParameter = AbilityParameterType.Level
                                            },
                                            BonusValue = new ContextValue()
                                            {
                                                ValueType = ContextValueType.Shared,
                                                Value = 0,
                                                ValueRank = AbilityRankType.Default,
                                                ValueShared = AbilitySharedValue.Heal,
                                                Property = UnitProperty.None,
                                                m_AbilityParameter = AbilityParameterType.Level
                                            }
                                        }
                                    },
                                    new ContextActionSpawnFx()
                                    {
                                        PrefabLink = HealTargetFX
                                    });
                                c.IfFalse = ActionFlow.DoSingle<Conditional>(c => {
                                    c.ConditionsChecker = ActionFlow.IfAll(
                                        new ContextConditionIsAlly()
                                        {
                                            Not = false
                                        },
                                        new ContextConditionHasFact()
                                        {
                                            m_Fact = LifeDominantSoul.ToReference<BlueprintUnitFactReference>(),
                                            Not = false
                                        });
                                    c.IfTrue = Helpers.CreateActionList(
                                        new ContextActionHealTarget()
                                        {
                                            Value = new ContextDiceValue()
                                            {
                                                DiceType = DiceType.Zero,
                                                DiceCountValue = new ContextValue()
                                                {
                                                    ValueType = ContextValueType.Simple,
                                                    Value = 0,
                                                    ValueRank = AbilityRankType.Default,
                                                    ValueShared = AbilitySharedValue.Damage,
                                                    Property = UnitProperty.None,
                                                    m_AbilityParameter = AbilityParameterType.Level
                                                },
                                                BonusValue = new ContextValue()
                                                {
                                                    ValueType = ContextValueType.Shared,
                                                    Value = 0,
                                                    ValueRank = AbilityRankType.Default,
                                                    ValueShared = AbilitySharedValue.StatBonus,
                                                    Property = UnitProperty.None,
                                                    m_AbilityParameter = AbilityParameterType.Level
                                                }
                                            }
                                        },
                                        new ContextActionSpawnFx()
                                        {
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
                                    new ContextActionHealTarget()
                                    {
                                        Value = new ContextDiceValue()
                                        {
                                            DiceType = DiceType.Zero,
                                            DiceCountValue = new ContextValue()
                                            {
                                                ValueType = ContextValueType.Simple,
                                                Value = 0,
                                                ValueRank = AbilityRankType.Default,
                                                ValueShared = AbilitySharedValue.Damage,
                                                Property = UnitProperty.None,
                                                m_AbilityParameter = AbilityParameterType.Level
                                            },
                                            BonusValue = new ContextValue()
                                            {
                                                ValueType = ContextValueType.Shared,
                                                Value = 0,
                                                ValueRank = AbilityRankType.Default,
                                                ValueShared = AbilitySharedValue.StatBonus,
                                                Property = UnitProperty.None,
                                                m_AbilityParameter = AbilityParameterType.Level
                                            }
                                        }
                                    },
                                    new ContextActionSpawnFx()
                                    {
                                        PrefabLink = HealTargetFX
                                    });
                                c.IfFalse = Helpers.CreateActionList(
                                    new ContextActionHealTarget()
                                    {
                                        Value = new ContextDiceValue()
                                        {
                                            DiceType = DiceType.Zero,
                                            DiceCountValue = new ContextValue()
                                            {
                                                ValueType = ContextValueType.Simple,
                                                Value = 0,
                                                ValueRank = AbilityRankType.Default,
                                                ValueShared = AbilitySharedValue.Damage,
                                                Property = UnitProperty.None,
                                                m_AbilityParameter = AbilityParameterType.Level
                                            },
                                            BonusValue = new ContextValue()
                                            {
                                                ValueType = ContextValueType.Shared,
                                                Value = 0,
                                                ValueRank = AbilityRankType.Default,
                                                ValueShared = AbilitySharedValue.Heal,
                                                Property = UnitProperty.None,
                                                m_AbilityParameter = AbilityParameterType.Level
                                            }
                                        }
                                    },
                                    new ContextActionSpawnFx()
                                    {
                                        PrefabLink = HealTargetFX
                                    });
                            });
                        });
                        c.IfFalse = ActionFlow.DoNothing();

                    });
                });
                bp.AddComponent<AbilityUseOnRest>(c => {
                    c.Type = AbilityUseOnRestType.HealMassUndead;
                    c.BaseValue = 10;
                    c.AddCasterLevel = true;
                    c.MultiplyByCasterLevel = false;
                    c.MaxCasterLevel = 0;
                });
                bp.AddComponent<SpellDescriptorComponent>(c => {
                    c.Descriptor = SpellDescriptor.RestoreHP | SpellDescriptor.ChannelNegativeHeal;
                });
            });
            var IsekaiChannelNegativeEnergyFeature = Helpers.CreateFeature("IsekaiChannelNegativeEnergyFeature", bp => {
                bp.SetName("Channel Negative Energy");
                bp.SetDescription("You gain the supernatural ability to channel negative energy like a cleric. You use your character level as your effective cleric level when "
                    + "channeling negative energy. You can channel energy a number of times per day equal to 3 + your Charisma modifier.");
                bp.m_Icon = ChannelNegativeEnergy.Icon;
                bp.Groups = new FeatureGroup[0];
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] {
                        ChannelEnergyFact.ToReference<BlueprintUnitFactReference>(),
                        IsekaiChannelNegativeEnergyAbility.ToReference<BlueprintUnitFactReference>(),
                        IsekaiChannelNegativeHealAbility.ToReference<BlueprintUnitFactReference>()
                    };
                });
                bp.AddComponent<PrerequisiteAlignment>(c => {
                    c.Group = Prerequisite.GroupType.Any;
                    c.Alignment = AlignmentMaskType.Evil;
                });
            });

            // Patch extra channel and selective channel feats
            SelectiveChannel.AddPrerequisiteFeature(IsekaiChannelNegativeEnergyFeature, Prerequisite.GroupType.Any);
            ExtraChannel.AddPrerequisiteFeature(IsekaiChannelNegativeEnergyFeature, Prerequisite.GroupType.Any);

            // Add to selection
            CharacterDevelopmentSelection.AddToSelection(IsekaiChannelNegativeEnergyFeature);
        }
    }
}
