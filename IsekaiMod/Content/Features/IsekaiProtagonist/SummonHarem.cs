using IsekaiMod.Components;
using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Enums;
using Kingmaker.Localization;
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
using System;
using UnityEngine;

namespace IsekaiMod.Content.Features.IsekaiProtagonist
{
    class SummonHarem
    {
        // Units
        private static readonly BlueprintUnit CR20_SuccubusAdvancedFighter = Resources.GetBlueprint<BlueprintUnit>("2db556136eac2544fa9744314c2a5713");
        private static readonly BlueprintUnit CR14_AstralDeva = Resources.GetBlueprint<BlueprintUnit>("8f3bd0ecea704277a9f2b09296a7b01e");
        private static readonly BlueprintUnit CR7_Nymph = Resources.GetBlueprint<BlueprintUnit>("0cc7a2526e4557945b1d8eb277d1fb3a");
        private static readonly BlueprintUnit CR22_ErinyesDevilStandard = Resources.GetBlueprint<BlueprintUnit>("b576f3eb0aa94af44a985f51eda9db7b");

        private static readonly BlueprintSummonPool SummonMonsterPool = Resources.GetBlueprint<BlueprintSummonPool>("d94c93e7240f10e41ae41db4c83d1cbe");
        private static readonly BlueprintBuff SummonedCreatureSpawnMonsterVI_IX = Resources.GetBlueprint<BlueprintBuff>("0dff842f06edace43baf8a2f44207045");
        private static readonly Sprite Icon_SummonMonsterIX = Resources.GetBlueprint<BlueprintAbility>("52b5df2a97df18242aec67610616ded0").m_Icon;

        private static readonly ContextDurationValue RankDuration = new()
        {
            Rate = DurationRate.Rounds,
            DiceType = DiceType.Zero,
            DiceCountValue = 0,
            BonusValue = new ContextValue()
            {
                ValueType = ContextValueType.Rank,
                ValueRank = AbilityRankType.Default
            },
            m_IsExtendable = true
        };
        private static readonly ContextDiceValue DiceValueOne = new()
        {
            DiceType = DiceType.Zero,
            DiceCountValue = 0,
            BonusValue = 1
        };
        public static void Add()
        {
            var SummonHaremAbility = Helpers.CreateBlueprint<BlueprintAbility>("SummonHaremAbility", bp => {
                bp.SetName("Summon Harem");
                bp.SetDescription("This {g|Encyclopedia:Spell}spell{/g} summons a Succubus, Nymph, Astral Deva, and an Erinyes. Summoned monsters appear where you designate and act according to their "
                    + "{g|Encyclopedia:Initiative}initiative{/g} {g|Encyclopedia:Check}check{/g} results. They {g|Encyclopedia:Attack}attack{/g} your opponents to the best of their ability.");
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.Actions = Helpers.CreateActionList(
                        SpawnMonster(c => {
                            c.m_Blueprint = CR20_SuccubusAdvancedFighter.ToReference<BlueprintUnitReference>(); // TODO: place in different locations?
                        }),
                        new ContextActionOnNearbyPoint()
                        {
                            Actions = Helpers.CreateActionList(
                                SpawnMonster(c => {
                                    c.m_Blueprint = CR14_AstralDeva.ToReference<BlueprintUnitReference>();
                                })
                                )
                        },
                        new ContextActionOnNearbyPoint()
                        {
                            Actions = Helpers.CreateActionList(
                                SpawnMonster(c => {
                                    c.m_Blueprint = CR7_Nymph.ToReference<BlueprintUnitReference>();
                                })
                                )
                        },
                        new ContextActionOnNearbyPoint()
                        {
                            Actions = Helpers.CreateActionList(
                                SpawnMonster(c => {
                                    c.m_Blueprint = CR22_ErinyesDevilStandard.ToReference<BlueprintUnitReference>();
                                })
                                )
                        }
                        );
                });
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.Default;
                    c.m_BaseValueType = ContextRankBaseValueType.CharacterLevel;
                });
                bp.AddComponent<SpellComponent>(c => {
                    c.School = SpellSchool.Conjuration;
                });
                bp.AddComponent<SpellDescriptorComponent>(c => {
                    c.Descriptor = SpellDescriptor.Summoning;
                });
                bp.m_Icon = Icon_SummonMonsterIX;
                bp.Type = AbilityType.Special;
                bp.Range = AbilityRange.Close;
                bp.CanTargetPoint = true;
                bp.CanTargetSelf = true;
                bp.Animation = UnitAnimationActionCastSpell.CastAnimationStyle.Omni;
                bp.ActionType = UnitCommand.CommandType.Standard;
                bp.AvailableMetamagic = Metamagic.Quicken;
                bp.m_IsFullRoundAction = true;
                bp.LocalizedDuration = Helpers.CreateString($"{bp.name}.Duration", "1 round/level");
                bp.LocalizedSavingThrow = new LocalizedString();
            });
            var SummonHaremFeature = Helpers.CreateFeature("SummonHaremFeature", bp => {
                bp.SetName("Summon Harem");
                bp.SetDescription("As a full action, you summon a Succubus, a Nymph, an Astral Deva, and an Erinyes to aid you in battle.");
                bp.m_Icon = Icon_SummonMonsterIX;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { SummonHaremAbility.ToReference<BlueprintUnitFactReference>() };
                });
            });
        }
        private static ContextActionSpawnMonster SpawnMonster(Action<ContextActionSpawnMonster> init = null)
        {
            var t = new ContextActionSpawnMonster()
            {
                m_SummonPool = SummonMonsterPool.ToReference<BlueprintSummonPoolReference>(),
                DurationValue = RankDuration,
                CountValue = DiceValueOne,
                LevelValue = new ContextValue(),
                AfterSpawn = ActionFlow.DoSingle<ContextActionApplyBuff>(c => {
                    c.Permanent = true;
                    c.m_Buff = SummonedCreatureSpawnMonsterVI_IX.ToReference<BlueprintBuffReference>();
                    c.DurationValue = Constants.Duration.Zero;
                    c.IsNotDispelable = true;
                }),
            };
            init?.Invoke(t);
            return t;
        }
    }
}
