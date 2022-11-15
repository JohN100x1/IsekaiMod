using IsekaiMod.Content.Classes.Deathsnatcher;
using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.ResourceLinks;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Abilities.Components.Base;
using Kingmaker.UnitLogic.Abilities.Components.TargetCheckers;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Commands.Base;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.UnitLogic.Mechanics.Conditions;
using Kingmaker.Visual.Animation.Kingmaker.Actions;
using UnityEngine;

namespace IsekaiMod.Content.Features.Deathsnatcher
{
    class DeathsnatcherCommandUndead
    {
        private static readonly Sprite Icon_CommandUndead = Resources.GetBlueprint<BlueprintAbility>("0b101dd5618591e478f825f0eef155b4").m_Icon;

        private static readonly BlueprintBuff CommandUndeadIntelligentBuff = Resources.GetBlueprint<BlueprintBuff>("07f4f8d2000a91c459c23c7fff8c74fb");
        private static readonly BlueprintBuff CommandUndeadBuff = Resources.GetBlueprint<BlueprintBuff>("7cd727ddd4cc4be498720e45f0c1f6f4");
        private static readonly BlueprintFeature UndeadType = Resources.GetBlueprint<BlueprintFeature>("734a29b693e9ec346ba2951b27987e33");

        public static void Add()
        {
            var DeathsnatcherCommandUndeadAbility = Helpers.CreateBlueprint<BlueprintAbility>("DeathsnatcherCommandUndeadAbility", bp => {
                bp.SetName("Command Undead");
                bp.SetDescription("You can make any undead creature fight on your side as if it was your ally. It will {g|Encyclopedia:Attack}attack{/g} your opponents to the best of its "
                    + "ability. However {g|Encyclopedia:Intelligence}intelligent{/g} creatures will try to throw off the domination, making a {g|Encyclopedia:Saving_Throw}Will save{/g} "
                    + "each {g|Encyclopedia:Combat_Round}round{/g}.");
                bp.m_Icon = Icon_CommandUndead;
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.SavingThrowType = SavingThrowType.Will;
                    c.Actions = ActionFlow.DoSingle<ContextActionConditionalSaved>(c => {
                        c.Succeed = ActionFlow.DoNothing();
                        c.Failed = ActionFlow.DoSingle<Conditional>(c => {
                            c.ConditionsChecker = ActionFlow.IfSingle<ContextConditionStatValue>(c =>
                            {
                                c.Not = false;
                                c.N = 1;
                                c.Stat = StatType.Intelligence;
                            });
                            c.IfTrue = ActionFlow.DoSingle<ContextActionApplyBuff>(c =>
                            {
                                c.m_Buff = CommandUndeadIntelligentBuff.ToReference<BlueprintBuffReference>();
                                c.Permanent = false;
                                c.UseDurationSeconds = false;
                                c.DurationSeconds = 0;
                                c.IsFromSpell = true;
                                c.IsNotDispelable = false;
                                c.ToCaster = false;
                                c.AsChild = false;
                                c.SameDuration = false;
                                c.DurationValue = new ContextDurationValue()
                                {
                                    Rate = DurationRate.Rounds,
                                    DiceType = DiceType.Zero,
                                    DiceCountValue = 0,
                                    BonusValue = new ContextValue()
                                    {
                                        ValueType = ContextValueType.Rank,
                                        Value = 0,
                                        ValueShared = AbilitySharedValue.Damage,
                                        ValueRank = AbilityRankType.DamageBonus
                                    },
                                    m_IsExtendable = true
                                };
                            });
                            c.IfFalse = ActionFlow.DoSingle<ContextActionApplyBuff>(c => {
                                c.m_Buff = CommandUndeadBuff.ToReference<BlueprintBuffReference>();
                                c.Permanent = false;
                                c.UseDurationSeconds = false;
                                c.DurationSeconds = 0;
                                c.IsFromSpell = true;
                                c.IsNotDispelable = false;
                                c.ToCaster = false;
                                c.AsChild = false;
                                c.SameDuration = false;
                                c.DurationValue = new ContextDurationValue()
                                {
                                    Rate = DurationRate.Rounds,
                                    DiceType = DiceType.Zero,
                                    DiceCountValue = 0,
                                    BonusValue = new ContextValue()
                                    {
                                        ValueType = ContextValueType.Rank,
                                        Value = 0,
                                        ValueShared = AbilitySharedValue.Damage,
                                        ValueRank = AbilityRankType.DamageBonus
                                    },
                                    m_IsExtendable = true
                                };
                            });
                        });
                    });
                });
                bp.AddComponent<SpellComponent>(c => {
                    c.m_Flags = 0;
                    c.School = SpellSchool.Necromancy;
                });
                bp.AddComponent<SpellDescriptorComponent>(c => {
                    c.Descriptor = SpellDescriptor.UndeadControl;
                });
                bp.AddComponent<AbilitySpawnFx>(c => {
                    c.PrefabLink = new PrefabLink() { AssetId = "cbfe312cb8e63e240a859efaad8e467c" };
                    c.Time = AbilitySpawnFxTime.OnApplyEffect;
                    c.Anchor = AbilitySpawnFxAnchor.SelectedTarget;
                    c.WeaponTarget = AbilitySpawnFxWeaponTarget.None;
                    c.DestroyOnCast = false;
                    c.Delay = 0;
                    c.PositionAnchor = AbilitySpawnFxAnchor.None;
                    c.OrientationAnchor = AbilitySpawnFxAnchor.None;
                    c.OrientationMode = AbilitySpawnFxOrientation.Copy;
                });
                bp.AddComponent<AbilityTargetHasFact>(c => {
                    c.m_CheckedFacts = new BlueprintUnitFactReference[] { UndeadType.ToReference<BlueprintUnitFactReference>() };
                    c.Inverted = false;
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
                bp.Type = AbilityType.SpellLike;
                bp.Range = AbilityRange.Close;
                bp.m_AllowNonContextActions = false;
                bp.CanTargetPoint = false;
                bp.CanTargetEnemies = true;
                bp.CanTargetFriends = false;
                bp.CanTargetSelf = false;
                bp.SpellResistance = true;
                bp.EffectOnEnemy = AbilityEffectOnUnit.Harmful;
                bp.EffectOnAlly = AbilityEffectOnUnit.None;
                bp.Animation = UnitAnimationActionCastSpell.CastAnimationStyle.Point;
                bp.ActionType = UnitCommand.CommandType.Standard;
                bp.AvailableMetamagic = Metamagic.Heighten | Metamagic.Reach | Metamagic.Quicken | Metamagic.Extend | Metamagic.Persistent | Metamagic.CompletelyNormal;
                bp.m_TargetMapObjects = false;
                bp.LocalizedDuration = Helpers.CreateString($"{bp.name}.Duration", "1 round/level");
                bp.LocalizedSavingThrow = Helpers.CreateString($"{bp.name}.SavingThrow", "Will negates (save each round)");
            });
            var DeathsnatcherCommandUndeadFeature = Helpers.CreateBlueprint<BlueprintFeature>("DeathsnatcherCommandUndeadFeature", bp => {
                bp.SetName("Command Undead");
                bp.SetDescription("At 4th level, the Deathsnatcher gains Command Undead as a spell-like ability any number of times per day.");
                bp.m_Icon = Icon_CommandUndead;
                bp.IsClassFeature = true;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { DeathsnatcherCommandUndeadAbility.ToReference<BlueprintUnitFactReference>() };
                });
            });
        }
    }
}
