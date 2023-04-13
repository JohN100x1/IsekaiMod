using IsekaiMod.Content.Classes.Deathsnatcher;
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
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Abilities.Components.Base;
using Kingmaker.UnitLogic.Commands.Base;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.Visual.Animation.Kingmaker.Actions;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.Deathsnatcher {

    internal class DeathsnatcherFingerOfDeath {
        private static readonly BlueprintAbility FingerOfDeathAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("6f1dcf6cfa92d1948a740195707c0dbe");

        public static void Add() {
            var DeathsnatcherFingerOfDeathResource = Helpers.CreateBlueprint<BlueprintAbilityResource>(IsekaiContext, "DeathsnatcherFingerOfDeathResource", bp => {
                bp.m_MaxAmount = new BlueprintAbilityResource.Amount {
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
            var DeathsnatcherFingerOfDeathAbility = Helpers.CreateBlueprint<BlueprintAbility>(IsekaiContext, "DeathsnatcherFingerOfDeathAbility", bp => {
                bp.m_DisplayName = FingerOfDeathAbility.m_DisplayName;
                bp.m_Description = FingerOfDeathAbility.m_Description;
                bp.m_Icon = FingerOfDeathAbility.m_Icon;
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.SavingThrowType = SavingThrowType.Fortitude;
                    c.Actions = ActionFlow.DoSingle<ContextActionConditionalSaved>(c => {
                        c.Succeed = ActionFlow.DoSingle<ContextActionDealDamage>(c => {
                            c.m_Type = ContextActionDealDamage.Type.Damage;
                            c.DamageType = new DamageTypeDescription() {
                                Type = DamageType.Energy,
                                Energy = DamageEnergyType.Unholy
                            };
                            c.AbilityType = StatType.Unknown;
                            c.Duration = Values.Duration.Zero;
                            c.Value = new ContextDiceValue() {
                                DiceType = DiceType.D6,
                                DiceCountValue = 3,
                                BonusValue = Values.CreateContextRankValue(AbilityRankType.DamageBonus)
                            };
                        });
                        c.Failed = ActionFlow.DoSingle<ContextActionDealDamage>(c => {
                            c.m_Type = ContextActionDealDamage.Type.Damage;
                            c.DamageType = new DamageTypeDescription() {
                                Type = DamageType.Energy,
                                Energy = DamageEnergyType.Unholy
                            };
                            c.AbilityType = StatType.Unknown;
                            c.Duration = Values.Duration.Zero;
                            c.Value = new ContextDiceValue() {
                                DiceType = DiceType.Zero,
                                DiceCountValue = 0,
                                BonusValue = Values.CreateContextRankValue(AbilityRankType.Default)
                            };
                        });
                    });
                });
                bp.AddComponent<SpellComponent>(c => {
                    c.School = SpellSchool.Necromancy;
                });
                bp.AddComponent<SpellDescriptorComponent>(c => {
                    c.Descriptor = SpellDescriptor.Death;
                });
                bp.AddComponent<AbilitySpawnFx>(c => {
                    c.PrefabLink = new PrefabLink() { AssetId = "e8569f4442d66ee42ad10502a100c1df" };
                    c.Time = AbilitySpawnFxTime.OnStart;
                    c.Anchor = AbilitySpawnFxAnchor.SelectedTarget;
                });
                bp.AddComponent<AbilityDeliverDelay>(c => {
                    c.DelaySeconds = 0.65f;
                });
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.Default;
                    c.m_BaseValueType = ContextRankBaseValueType.ClassLevel;
                    c.m_Progression = ContextRankProgression.MultiplyByModifier;
                    c.m_StepLevel = 10;
                    c.m_Class = new BlueprintCharacterClassReference[] { DeathsnatcherClass.GetReference() };
                });
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.DamageBonus;
                    c.m_BaseValueType = ContextRankBaseValueType.ClassLevel;
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
                bp.CanTargetEnemies = true;
                bp.CanTargetSelf = true;
                bp.SpellResistance = true;
                bp.EffectOnEnemy = AbilityEffectOnUnit.Harmful;
                bp.EffectOnAlly = AbilityEffectOnUnit.Harmful;
                bp.Animation = UnitAnimationActionCastSpell.CastAnimationStyle.Directional;
                bp.ActionType = UnitCommand.CommandType.Standard;
                bp.AvailableMetamagic = FingerOfDeathAbility.AvailableMetamagic;
                bp.LocalizedDuration = StaticReferences.Strings.Null;
                bp.LocalizedSavingThrow = StaticReferences.Strings.SavingThrow.FortitudePartial;
            });
            var DeathsnatcherFingerOfDeathFeature = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "DeathsnatcherFingerOfDeathFeature", bp => {
                bp.SetName(IsekaiContext, "Finger of Death");
                bp.SetDescription(IsekaiContext, "At 16th level, the Deathsnatcher gains Finger of Death as a spell-like ability once per day.");
                bp.m_Icon = FingerOfDeathAbility.m_Icon;
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