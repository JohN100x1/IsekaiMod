using IsekaiMod.Content.Classes.Deathsnatcher;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.ResourceLinks;
using Kingmaker.RuleSystem;
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
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.Deathsnatcher {

    internal class DeathsnatcherCommandUndead {
        private static readonly BlueprintAbility CommandUndeadAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("0b101dd5618591e478f825f0eef155b4");
        private static readonly BlueprintBuff CommandUndeadIntelligentBuff = BlueprintTools.GetBlueprint<BlueprintBuff>("07f4f8d2000a91c459c23c7fff8c74fb");
        private static readonly BlueprintBuff CommandUndeadBuff = BlueprintTools.GetBlueprint<BlueprintBuff>("7cd727ddd4cc4be498720e45f0c1f6f4");
        private static readonly BlueprintFeature UndeadType = BlueprintTools.GetBlueprint<BlueprintFeature>("734a29b693e9ec346ba2951b27987e33");

        public static void Add() {
            var DeathsnatcherCommandUndeadResource = Helpers.CreateBlueprint<BlueprintAbilityResource>(IsekaiContext, "DeathsnatcherCommandUndeadResource", bp => {
                bp.m_MaxAmount = new BlueprintAbilityResource.Amount {
                    BaseValue = 10,
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
            var DeathsnatcherCommandUndeadAbility = Helpers.CreateBlueprint<BlueprintAbility>(IsekaiContext, "DeathsnatcherCommandUndeadAbility", bp => {
                bp.SetName(CommandUndeadAbility.m_DisplayName);
                bp.SetDescription(CommandUndeadAbility.m_Description);
                bp.m_Icon = CommandUndeadAbility.m_Icon;
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.SavingThrowType = SavingThrowType.Will;
                    c.Actions = ActionFlow.DoSingle<ContextActionConditionalSaved>(c => {
                        c.Succeed = ActionFlow.DoNothing();
                        c.Failed = ActionFlow.DoSingle<Conditional>(c => {
                            c.ConditionsChecker = ActionFlow.IfSingle<ContextConditionStatValue>(c => {
                                c.Not = false;
                                c.N = 1;
                                c.Stat = StatType.Intelligence;
                            });
                            c.IfTrue = ActionFlow.DoSingle<ContextActionApplyBuff>(c => {
                                c.m_Buff = CommandUndeadIntelligentBuff.ToReference<BlueprintBuffReference>();
                                c.Permanent = false;
                                c.UseDurationSeconds = false;
                                c.DurationSeconds = 0;
                                c.IsFromSpell = true;
                                c.IsNotDispelable = false;
                                c.ToCaster = false;
                                c.AsChild = false;
                                c.SameDuration = false;
                                c.DurationValue = new ContextDurationValue() {
                                    Rate = DurationRate.Rounds,
                                    DiceType = DiceType.Zero,
                                    DiceCountValue = 0,
                                    BonusValue = Values.CreateContextRankValue(AbilityRankType.DamageBonus),
                                    m_IsExtendable = true
                                };
                            });
                            c.IfFalse = ActionFlow.DoSingle<ContextActionApplyBuff>(c => {
                                c.m_Buff = CommandUndeadBuff.ToReference<BlueprintBuffReference>();
                                c.DurationValue = new ContextDurationValue() {
                                    Rate = DurationRate.Rounds,
                                    DiceType = DiceType.Zero,
                                    DiceCountValue = 0,
                                    BonusValue = Values.CreateContextRankValue(AbilityRankType.DamageBonus),
                                    m_IsExtendable = true
                                };
                                c.IsFromSpell = true;
                            });
                        });
                    });
                });
                bp.AddComponent<SpellComponent>(c => {
                    c.School = SpellSchool.Necromancy;
                });
                bp.AddComponent<SpellDescriptorComponent>(c => {
                    c.Descriptor = SpellDescriptor.UndeadControl;
                });
                bp.AddComponent<AbilitySpawnFx>(c => {
                    c.PrefabLink = new PrefabLink() { AssetId = "cbfe312cb8e63e240a859efaad8e467c" };
                    c.Time = AbilitySpawnFxTime.OnApplyEffect;
                    c.Anchor = AbilitySpawnFxAnchor.SelectedTarget;
                });
                bp.AddComponent<AbilityTargetHasFact>(c => {
                    c.m_CheckedFacts = new BlueprintUnitFactReference[] { UndeadType.ToReference<BlueprintUnitFactReference>() };
                    c.Inverted = false;
                });
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.Default;
                    c.m_BaseValueType = ContextRankBaseValueType.ClassLevel;
                    c.m_Progression = ContextRankProgression.BonusValue;
                    c.m_StepLevel = 1;
                    c.m_Class = new BlueprintCharacterClassReference[] { DeathsnatcherClass.GetReference() };
                });
                bp.AddComponent<AbilityResourceLogic>(c => {
                    c.m_RequiredResource = DeathsnatcherCommandUndeadResource.ToReference<BlueprintAbilityResourceReference>();
                    c.m_IsSpendResource = true;
                });
                bp.Type = AbilityType.SpellLike;
                bp.Range = AbilityRange.Close;
                bp.CanTargetEnemies = true;
                bp.SpellResistance = true;
                bp.EffectOnEnemy = AbilityEffectOnUnit.Harmful;
                bp.EffectOnAlly = AbilityEffectOnUnit.None;
                bp.Animation = UnitAnimationActionCastSpell.CastAnimationStyle.Point;
                bp.ActionType = UnitCommand.CommandType.Standard;
                bp.AvailableMetamagic = CommandUndeadAbility.AvailableMetamagic;
                bp.LocalizedDuration = StaticReferences.Strings.Duration.OneRoundPerLevel;
                bp.LocalizedSavingThrow = StaticReferences.Strings.SavingThrow.WillNegatesSaveEachRound;
            });
            var DeathsnatcherCommandUndeadFeature = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "DeathsnatcherCommandUndeadFeature", bp => {
                bp.SetName(CommandUndeadAbility.m_DisplayName);
                bp.SetDescription(IsekaiContext, "At 1st level, the Deathsnatcher gains Command Undead as a spell-like ability 10 times per day.");
                bp.m_Icon = CommandUndeadAbility.m_Icon;
                bp.AddComponent<AddAbilityResources>(c => {
                    c.m_Resource = DeathsnatcherCommandUndeadResource.ToReference<BlueprintAbilityResourceReference>();
                    c.RestoreAmount = true;
                });
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { DeathsnatcherCommandUndeadAbility.ToReference<BlueprintUnitFactReference>() };
                });
            });
        }
    }
}