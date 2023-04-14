using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.ResourceLinks;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Abilities.Components.Base;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Commands.Base;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.Utility;
using Kingmaker.Visual.Animation.Kingmaker.Actions;
using System.Collections.Generic;
using TabletopTweaks.Core.Utilities;
using UnityEngine;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.SpecialPower {

    internal class KillingIntent {
        private static readonly Sprite Icon_ConsumeFear = BlueprintTools.GetBlueprint<BlueprintAbility>("644d2c0d029e54d4188bc34216d9d8c0").m_Icon;
        private static readonly BlueprintBuff Shaken = BlueprintTools.GetBlueprint<BlueprintBuff>("25ec6cb6ab1845c48a95f9c20b034220");
        private static readonly BlueprintBuff Frightened = BlueprintTools.GetBlueprint<BlueprintBuff>("f08a7239aa961f34c8301518e71d4cdf");
        private static readonly BlueprintBuff Cowering = BlueprintTools.GetBlueprint<BlueprintBuff>("6062e3a8206a4284d867cbb7120dc091");

        public static void Add() {
            var KillingIntentResource = Helpers.CreateBlueprint<BlueprintAbilityResource>(IsekaiContext, "KillingIntentResource", bp => {
                bp.m_MaxAmount = new BlueprintAbilityResource.Amount {
                    BaseValue = 1,
                    IncreasedByLevel = false,
                    LevelIncrease = 0,
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
            var KillingIntentAbility = Helpers.CreateBlueprint<BlueprintAbility>(IsekaiContext, "KillingIntentAbility", bp => {
                bp.SetName(IsekaiContext, "Killing Intent");
                bp.SetDescription(IsekaiContext, "Enemies within 40 feet of you who fails a DC 50 Will saving throw become shaken, frightened, and cowering for 1d4 rounds.");
                bp.m_Icon = Icon_ConsumeFear;
                bp.LocalizedDuration = StaticReferences.Strings.Null;
                bp.LocalizedSavingThrow = StaticReferences.Strings.Null;
                bp.AvailableMetamagic = Metamagic.Heighten | Metamagic.Extend | Metamagic.Heighten | Metamagic.Reach;
                bp.Range = AbilityRange.Personal;
                bp.Type = AbilityType.Special;
                bp.CanTargetEnemies = true;
                bp.EffectOnEnemy = AbilityEffectOnUnit.Harmful;
                bp.Animation = UnitAnimationActionCastSpell.CastAnimationStyle.Omni;
                bp.ActionType = UnitCommand.CommandType.Free;
                bp.AddComponent<AbilityResourceLogic>(c => {
                    c.m_RequiredResource = KillingIntentResource.ToReference<BlueprintAbilityResourceReference>();
                    c.m_IsSpendResource = true;
                    c.Amount = 1;
                    c.ResourceCostIncreasingFacts = new List<BlueprintUnitFactReference>();
                    c.ResourceCostDecreasingFacts = new List<BlueprintUnitFactReference>();
                });
                bp.AddComponent<AbilityTargetsAround>(c => {
                    c.m_Radius = new Feet(40);
                    c.m_TargetType = TargetType.Enemy;
                    c.m_Condition = ActionFlow.EmptyCondition();
                });
                bp.AddComponent<AbilitySpawnFx>(c => {
                    c.PrefabLink = new PrefabLink() { AssetId = "d80d51c0a08f35140b10dd1526e540c4" };
                    c.Time = AbilitySpawnFxTime.OnApplyEffect;
                    c.Anchor = AbilitySpawnFxAnchor.Caster;
                });
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.Actions = ActionFlow.DoSingle<ContextActionSavingThrow>(c => {
                        c.Type = SavingThrowType.Will;
                        c.m_ConditionalDCIncrease = new ContextActionSavingThrow.ConditionalDCIncrease[0];
                        c.HasCustomDC = false;
                        c.CustomDC = 0;
                        c.Actions = ActionFlow.DoSingle<ContextActionConditionalSaved>(c => {
                            c.Succeed = ActionFlow.DoNothing();
                            c.Failed = Helpers.CreateActionList(
                                new ContextActionApplyBuff() {
                                    m_Buff = Shaken.ToReference<BlueprintBuffReference>(),
                                    DurationValue = new() {
                                        Rate = DurationRate.Rounds,
                                        DiceType = DiceType.D4,
                                        DiceCountValue = 1,
                                        BonusValue = 0,
                                        m_IsExtendable = true,
                                    }
                                },
                                new ContextActionApplyBuff() {
                                    m_Buff = Frightened.ToReference<BlueprintBuffReference>(),
                                    DurationValue = new() {
                                        Rate = DurationRate.Rounds,
                                        DiceType = DiceType.D4,
                                        DiceCountValue = 1,
                                        BonusValue = 0,
                                        m_IsExtendable = true,
                                    }
                                },
                                new ContextActionApplyBuff() {
                                    m_Buff = Cowering.ToReference<BlueprintBuffReference>(),
                                    DurationValue = new() {
                                        Rate = DurationRate.Rounds,
                                        DiceType = DiceType.D4,
                                        DiceCountValue = 1,
                                        BonusValue = 0,
                                        m_IsExtendable = true,
                                    }
                                });
                        });
                    });
                });
                bp.AddComponent<ContextSetAbilityParams>(c => {
                    c.DC = 50;
                });
            });
            var KillingIntentFeature = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "KillingIntentFeature", bp => {
                bp.SetName(IsekaiContext, "Killing Intent");
                bp.SetDescription(IsekaiContext, "Once per Combat, as a free action, enemies within 40 feet of you who fails a DC 50 Will saving throw become shaken, frightened, and cowering for 1d4 rounds.");
                bp.m_Icon = Icon_ConsumeFear;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] {
                        KillingIntentAbility.ToReference<BlueprintUnitFactReference>(),
                    };
                });
                bp.AddComponent<AddAbilityResources>(c => {
                    c.m_Resource = KillingIntentResource.ToReference<BlueprintAbilityResourceReference>();
                    c.RestoreAmount = true;
                });
                bp.AddComponent<CombatStateTrigger>(c => {
                    c.CombatStartActions = ActionFlow.DoNothing();
                    c.CombatEndActions = ActionFlow.DoSingle<ContextRestoreResource>(c => {
                        c.m_Resource = KillingIntentResource.ToReference<BlueprintAbilityResourceReference>();
                        c.ContextValueRestoration = false;
                        c.Value = 0;
                    });
                });
            });

            // Add to selection
            SpecialPowerSelection.AddToSelection(KillingIntentFeature);
        }
    }
}