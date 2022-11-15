using IsekaiMod.Content.Classes.Deathsnatcher;
using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Commands.Base;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.Visual.Animation.Kingmaker.Actions;
using UnityEngine;

namespace IsekaiMod.Content.Features.Deathsnatcher
{
    class DeathsnatcherAnimateDead
    {
        private static readonly Sprite Icon_AnimateDead = Resources.GetBlueprint<BlueprintAbility>("4b76d32feb089ad4499c3a1ce8e1ac27").m_Icon;

        private static readonly BlueprintUnit SummonedSkeletonChampion = Resources.GetBlueprint<BlueprintUnit>("53e228ba7fe18104c93dc4b7294a1b30");
        private static readonly BlueprintSummonPool SummonMonsterPool = Resources.GetBlueprint<BlueprintSummonPool>("d94c93e7240f10e41ae41db4c83d1cbe");
        private static readonly BlueprintBuff SummonedCreatureSpawnMonsterIV_VI = Resources.GetBlueprint<BlueprintBuff>("50d51854cf6a3434d96a87d050e1d09a");

        public static void Add()
        {
            var DeathsnatcherAnimateDeadResource = Helpers.CreateBlueprint<BlueprintAbilityResource>("DeathsnatcherAnimateDeadResource", bp => {
                bp.m_MaxAmount = new BlueprintAbilityResource.Amount
                {
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
            var DeathsnatcherAnimateDeadAbility = Helpers.CreateBlueprint<BlueprintAbility>("DeathsnatcherAnimateDeadAbility", bp => {
                bp.SetName("Animate Dead");
                bp.SetDescription("This {g|Encyclopedia:Spell}spell{/g} raises {g|Encyclopedia:Dice}1d4{/g}+2 undead skeletal champions. They appear where you designate and act "
                    + "according to their {g|Encyclopedia:Initiative}initiative{/g} {g|Encyclopedia:Check}check{/g} results. They {g|Encyclopedia:Attack}attack{/g} your opponents to "
                    + "the best of their ability.");
                bp.m_Icon = Icon_AnimateDead;
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.SavingThrowType = SavingThrowType.Unknown;
                    c.Actions = Helpers.CreateActionList(
                    new ContextActionSpawnMonster()
                    {
                        m_Blueprint = SummonedSkeletonChampion.ToReference<BlueprintUnitReference>(),
                        m_SummonPool = SummonMonsterPool.ToReference<BlueprintSummonPoolReference>(),
                        DurationValue = new ContextDurationValue()
                        {
                            Rate = DurationRate.Rounds,
                            DiceType = DiceType.Zero,
                            DiceCountValue = 0,
                            BonusValue = new ContextValue()
                            {
                                ValueType = ContextValueType.Rank,
                                ValueRank = AbilityRankType.Default
                            }
                        },
                        CountValue = new ContextDiceValue()
                        {
                            DiceType = DiceType.D4,
                            DiceCountValue = 1,
                            BonusValue = 2
                        },
                        LevelValue = 0,
                        AfterSpawn = Helpers.CreateActionList(
                            new ContextActionApplyBuff()
                            {
                                Permanent = true,
                                m_Buff = SummonedCreatureSpawnMonsterIV_VI.ToReference<BlueprintBuffReference>(),
                                DurationValue = new ContextDurationValue()
                                {
                                    Rate = DurationRate.Rounds,
                                    DiceType = DiceType.Zero,
                                    DiceCountValue = 0,
                                    BonusValue = 0,
                                    m_IsExtendable = true
                                },
                                IsNotDispelable = true,
                                UseDurationSeconds = false,
                                DurationSeconds = 0,
                                IsFromSpell = false,
                                ToCaster = false,
                                AsChild = false,
                            })
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
                    c.m_Stat = StatType.Unknown;
                    c.m_SpecificModifier = ModifierDescriptor.None;
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
                bp.m_AllowNonContextActions = false;
                bp.CanTargetPoint = true;
                bp.CanTargetEnemies = false;
                bp.CanTargetFriends = false;
                bp.CanTargetSelf = true;
                bp.SpellResistance = false;
                bp.EffectOnEnemy = AbilityEffectOnUnit.None;
                bp.EffectOnAlly = AbilityEffectOnUnit.None;
                bp.Animation = UnitAnimationActionCastSpell.CastAnimationStyle.Point;
                bp.ActionType = UnitCommand.CommandType.Standard;
                bp.AvailableMetamagic = Metamagic.Maximize | Metamagic.Reach | Metamagic.Quicken | Metamagic.Extend | Metamagic.Empower | Metamagic.CompletelyNormal;
                bp.m_TargetMapObjects = false;
                bp.LocalizedDuration = Helpers.CreateString($"{bp.name}.Duration", "1 round/level");
                bp.LocalizedSavingThrow = Helpers.CreateString($"{bp.name}.SavingThrow", "");
            });
            var DeathsnatcherAnimateDeadFeature = Helpers.CreateBlueprint<BlueprintFeature>("DeathsnatcherAnimateDeadFeature", bp => {
                bp.SetName("Animate Dead");
                bp.SetDescription("At 7th level, the Deathsnatcher gains Animate Dead as a spell-like ability 3 times per day.");
                bp.m_Icon = Icon_AnimateDead;
                bp.IsClassFeature = true;
                bp.AddComponent<AddAbilityResources>(c => {
                    c.m_Resource = DeathsnatcherAnimateDeadResource.ToReference<BlueprintAbilityResourceReference>();
                    c.RestoreAmount = true;
                });
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { DeathsnatcherAnimateDeadAbility.ToReference<BlueprintUnitFactReference>() };
                });
            });
        }
    }
}
