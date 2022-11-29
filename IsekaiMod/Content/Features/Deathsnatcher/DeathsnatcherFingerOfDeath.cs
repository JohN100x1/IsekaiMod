using IsekaiMod.Content.Classes.Deathsnatcher;
using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.Enums.Damage;
using Kingmaker.ResourceLinks;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Abilities.Components.Base;
using Kingmaker.UnitLogic.Commands.Base;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.Visual.Animation.Kingmaker.Actions;
using UnityEngine;

namespace IsekaiMod.Content.Features.Deathsnatcher
{
    class DeathsnatcherFingerOfDeath
    {
        private static readonly Sprite Icon_FingerOfDeath = Resources.GetBlueprint<BlueprintAbility>("6f1dcf6cfa92d1948a740195707c0dbe").m_Icon;

        public static void Add()
        {
            var DeathsnatcherFingerOfDeathResource = Helpers.CreateBlueprint<BlueprintAbilityResource>("DeathsnatcherFingerOfDeathResource", bp => {
                bp.m_MaxAmount = new BlueprintAbilityResource.Amount
                {
                    BaseValue = 1,
                    IncreasedByLevel = false,
                    LevelIncrease = 1,
                    IncreasedByLevelStartPlusDivStep = false,
                    StartingLevel = 0,
                    StartingIncrease = 0,
                    LevelStep = 0,
                    PerStepIncrease = 0,
                    MinClassLevelIncrease = 0,
                    OtherClassesModifier = 0,
                    IncreasedByStat = false,
                    ResourceBonusStat = StatType.Unknown,
                };
            });
            var DeathsnatcherFingerOfDeathAbility = Helpers.CreateBlueprint<BlueprintAbility>("DeathsnatcherFingerOfDeathAbility", bp => {
                bp.SetName("Finger of Death");
                bp.SetDescription("This {g|Encyclopedia:Spell}spell{/g} instantly delivers 10 points of {g|Encyclopedia:Damage}damage{/g} per {g|Encyclopedia:Caster_Level}caster level{/g}. "
                    + "If the target's {g|Encyclopedia:Saving_Throw}Fortitude saving throw{/g} succeeds, it instead takes {g|Encyclopedia:Dice}3d6{/g} points of damage + 1 point per caster "
                    + "level.");
                bp.m_Icon = Icon_FingerOfDeath;
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.SavingThrowType = SavingThrowType.Fortitude;
                    c.Actions = ActionFlow.DoSingle<ContextActionConditionalSaved>(c => {
                        c.Succeed = ActionFlow.DoSingle<ContextActionDealDamage>(c => {
                            c.m_Type = ContextActionDealDamage.Type.Damage;
                            c.DamageType = new DamageTypeDescription()
                            {
                                Type = DamageType.Energy,
                                Energy = DamageEnergyType.Unholy
                            };
                            c.AbilityType = StatType.Unknown;
                            c.Duration = new ContextDurationValue()
                            {
                                Rate = DurationRate.Rounds,
                                DiceType = DiceType.Zero,
                            };
                            c.Value = new ContextDiceValue()
                            {
                                DiceType = DiceType.D6,
                                DiceCountValue = 3,
                                BonusValue = new ContextValue()
                                {
                                    ValueType = ContextValueType.Rank,
                                    ValueRank = AbilityRankType.DamageBonus
                                }
                            };
                        });
                        c.Failed = ActionFlow.DoSingle<ContextActionDealDamage>(c => {
                            c.m_Type = ContextActionDealDamage.Type.Damage;
                            c.DamageType = new DamageTypeDescription()
                            {
                                Type = DamageType.Energy,
                                Energy = DamageEnergyType.Unholy
                            };
                            c.AbilityType = StatType.Unknown;
                            c.Duration = new ContextDurationValue()
                            {
                                Rate = DurationRate.Rounds,
                                DiceType = DiceType.Zero,
                            };
                            c.Value = new ContextDiceValue()
                            {
                                DiceType = DiceType.Zero,
                                DiceCountValue = 0,
                                BonusValue = new ContextValue()
                                {
                                    ValueType = ContextValueType.Rank,
                                    ValueRank = AbilityRankType.Default
                                }
                            };
                        });
                    });
                });
                bp.AddComponent<SpellComponent>(c => {
                    c.m_Flags = 0;
                    c.School = SpellSchool.Necromancy;
                });
                bp.AddComponent<SpellDescriptorComponent>(c => {
                    c.Descriptor = SpellDescriptor.Death;
                });
                bp.AddComponent<AbilitySpawnFx>(c => {
                    c.PrefabLink = new PrefabLink() { AssetId = "e8569f4442d66ee42ad10502a100c1df" };
                    c.Time = AbilitySpawnFxTime.OnStart;
                    c.Anchor = AbilitySpawnFxAnchor.SelectedTarget;
                    c.WeaponTarget = AbilitySpawnFxWeaponTarget.None;
                    c.DestroyOnCast = false;
                    c.Delay = 0;
                    c.PositionAnchor = AbilitySpawnFxAnchor.None;
                    c.OrientationAnchor = AbilitySpawnFxAnchor.None;
                    c.OrientationMode = AbilitySpawnFxOrientation.Copy;
                });
                bp.AddComponent<AbilityDeliverDelay>(c => {
                    c.DelaySeconds = 0.65f;
                });
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.Default;
                    c.m_BaseValueType = ContextRankBaseValueType.ClassLevel;
                    c.m_Stat = StatType.Unknown;
                    c.m_SpecificModifier = ModifierDescriptor.None;
                    c.m_Progression = ContextRankProgression.MultiplyByModifier;
                    c.m_StepLevel = 10;
                    c.m_Class = new BlueprintCharacterClassReference[] { DeathsnatcherClass.GetReference() };
                });
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.DamageBonus;
                    c.m_BaseValueType = ContextRankBaseValueType.ClassLevel;
                    c.m_Stat = StatType.Unknown;
                    c.m_SpecificModifier = ModifierDescriptor.None;
                    c.m_Progression = ContextRankProgression.AsIs;
                    c.m_StepLevel = 1;
                    c.m_Class = new BlueprintCharacterClassReference[] { DeathsnatcherClass.GetReference() };
                });
                bp.AddComponent<AbilityResourceLogic>(c => {
                    c.m_RequiredResource = DeathsnatcherFingerOfDeathResource.ToReference<BlueprintAbilityResourceReference>();
                    c.m_IsSpendResource = true;
                });
                bp.Type = AbilityType.SpellLike;
                bp.Range = AbilityRange.Close;
                bp.m_AllowNonContextActions = false;
                bp.CanTargetPoint = false;
                bp.CanTargetEnemies = true;
                bp.CanTargetFriends = false;
                bp.CanTargetSelf = true;
                bp.SpellResistance = true;
                bp.EffectOnEnemy = AbilityEffectOnUnit.Harmful;
                bp.EffectOnAlly = AbilityEffectOnUnit.Harmful;
                bp.Animation = UnitAnimationActionCastSpell.CastAnimationStyle.Directional;
                bp.ActionType = UnitCommand.CommandType.Standard;
                bp.AvailableMetamagic = Metamagic.Maximize | Metamagic.Heighten | Metamagic.Persistent | Metamagic.Bolstered | Metamagic.Reach | Metamagic.Quicken | Metamagic.Extend | Metamagic.Empower | Metamagic.CompletelyNormal;
                bp.m_TargetMapObjects = false;
                bp.LocalizedDuration = new LocalizedString();
                bp.LocalizedSavingThrow = Helpers.CreateString($"{bp.name}.SavingThrow", "Fortitude partial");
            });
            var DeathsnatcherFingerOfDeathFeature = Helpers.CreateBlueprint<BlueprintFeature>("DeathsnatcherFingerOfDeathFeature", bp => {
                bp.SetName("Finger of Death");
                bp.SetDescription("At 16th level, the Deathsnatcher gains Finger of Death as a spell-like ability once per day.");
                bp.m_Icon = Icon_FingerOfDeath;
                bp.IsClassFeature = true;
                bp.AddComponent<AddAbilityResources>(c => {
                    c.m_Resource = DeathsnatcherFingerOfDeathResource.ToReference<BlueprintAbilityResourceReference>();
                    c.RestoreAmount = true;
                });
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { DeathsnatcherFingerOfDeathAbility.ToReference<BlueprintUnitFactReference>() };
                });
            });
        }
    }
}
