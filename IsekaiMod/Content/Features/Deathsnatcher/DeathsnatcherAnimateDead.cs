using IsekaiMod.Content.Classes.Deathsnatcher;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Commands.Base;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.Visual.Animation.Kingmaker.Actions;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.Deathsnatcher {

    internal class DeathsnatcherAnimateDead {
        private static readonly BlueprintAbility AnimateDeadAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("4b76d32feb089ad4499c3a1ce8e1ac27");
        private static readonly BlueprintUnit SummonedSkeletonChampion = BlueprintTools.GetBlueprint<BlueprintUnit>("53e228ba7fe18104c93dc4b7294a1b30");
        private static readonly BlueprintSummonPool SummonMonsterPool = BlueprintTools.GetBlueprint<BlueprintSummonPool>("d94c93e7240f10e41ae41db4c83d1cbe");
        private static readonly BlueprintBuff SummonedCreatureSpawnMonsterIV_VI = BlueprintTools.GetBlueprint<BlueprintBuff>("50d51854cf6a3434d96a87d050e1d09a");

        public static void Add() {
            var DeathsnatcherAnimateDeadResource = Helpers.CreateBlueprint<BlueprintAbilityResource>(IsekaiContext, "DeathsnatcherAnimateDeadResource", bp => {
                bp.m_MaxAmount = new BlueprintAbilityResource.Amount {
                    BaseValue = 3,
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
            var DeathsnatcherAnimateDeadAbility = Helpers.CreateBlueprint<BlueprintAbility>(IsekaiContext, "DeathsnatcherAnimateDeadAbility", bp => {
                bp.SetName(AnimateDeadAbility.m_DisplayName);
                bp.SetDescription(AnimateDeadAbility.m_Description);
                bp.m_Icon = AnimateDeadAbility.m_Icon;
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.Actions = ActionFlow.DoSingle<ContextActionSpawnMonster>(c => {
                        c.m_Blueprint = SummonedSkeletonChampion.ToReference<BlueprintUnitReference>();
                        c.m_SummonPool = SummonMonsterPool.ToReference<BlueprintSummonPoolReference>();
                        c.DurationValue = new ContextDurationValue() {
                            Rate = DurationRate.Rounds,
                            DiceType = DiceType.Zero,
                            DiceCountValue = 0,
                            BonusValue = Values.CreateContextRankValue(AbilityRankType.Default)
                        };
                        c.CountValue = new ContextDiceValue() {
                            DiceType = DiceType.D4,
                            DiceCountValue = 1,
                            BonusValue = 2
                        };
                        c.LevelValue = 0;
                        c.AfterSpawn = ActionFlow.DoSingle<ContextActionApplyBuff>(c => {
                            c.Permanent = true;
                            c.m_Buff = SummonedCreatureSpawnMonsterIV_VI.ToReference<BlueprintBuffReference>();
                            c.DurationValue = Values.Duration.Zero;
                            c.IsNotDispelable = true;
                        });
                    });
                });
                bp.AddComponent<SpellComponent>(c => {
                    c.m_Flags = 0;
                    c.School = SpellSchool.Necromancy;
                });
                bp.AddComponent<SpellDescriptorComponent>(c => {
                    c.Descriptor = SpellDescriptor.Evil;
                });
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.Default;
                    c.m_BaseValueType = ContextRankBaseValueType.ClassLevel;
                    c.m_Progression = ContextRankProgression.BonusValue;
                    c.m_StepLevel = 1;
                    c.m_Class = new BlueprintCharacterClassReference[] { DeathsnatcherClass.GetReference() };
                });
                bp.AddComponent<AbilityResourceLogic>(c => {
                    c.m_RequiredResource = DeathsnatcherAnimateDeadResource.ToReference<BlueprintAbilityResourceReference>();
                    c.m_IsSpendResource = true;
                });
                bp.Type = AbilityType.SpellLike;
                bp.Range = AbilityRange.Close;
                bp.CanTargetPoint = true;
                bp.CanTargetSelf = true;
                bp.Animation = UnitAnimationActionCastSpell.CastAnimationStyle.Point;
                bp.ActionType = UnitCommand.CommandType.Standard;
                bp.AvailableMetamagic = AnimateDeadAbility.AvailableMetamagic;
                bp.LocalizedDuration = StaticReferences.Strings.Duration.OneRoundPerLevel;
                bp.LocalizedSavingThrow = StaticReferences.Strings.Null;
            });
            var DeathsnatcherAnimateDeadFeature = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "DeathsnatcherAnimateDeadFeature", bp => {
                bp.SetName(AnimateDeadAbility.m_DisplayName);
                bp.SetDescription(IsekaiContext, "At 7th level, the Deathsnatcher gains Animate Dead as a spell-like ability 3 times per day.");
                bp.m_Icon = AnimateDeadAbility.m_Icon;
                bp.AddComponent<AddAbilityResources>(c => {
                    c.m_Resource = DeathsnatcherAnimateDeadResource.ToReference<BlueprintAbilityResourceReference>();
                    c.RestoreAmount = true;
                });
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { DeathsnatcherAnimateDeadAbility.ToReference<BlueprintUnitFactReference>() };
                });
            });
            var DeathsnatcherAnimateDeadAdditionalUse = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "DeathsnatcherAnimateDeadAdditionalUse", bp => {
                bp.SetName(IsekaiContext, "Animate Dead — Additional Uses");
                bp.SetDescription(IsekaiContext, "At 10th level, the Deathsnatcher gains 2 additional uses of Animate Dead per day.");
                bp.m_Icon = AnimateDeadAbility.m_Icon;
                bp.AddComponent<IncreaseResourceAmount>(c => {
                    c.m_Resource = DeathsnatcherAnimateDeadResource.ToReference<BlueprintAbilityResourceReference>();
                    c.Value = 2;
                });
            });
        }
    }
}