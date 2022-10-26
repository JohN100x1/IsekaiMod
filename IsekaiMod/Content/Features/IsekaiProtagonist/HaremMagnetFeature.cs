using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.ResourceLinks;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Buffs.Components;
using Kingmaker.UnitLogic.Commands.Base;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.UnitLogic.Mechanics.Conditions;
using Kingmaker.Utility;
using Kingmaker.Visual.Animation.Kingmaker.Actions;

namespace IsekaiMod.Content.Features.IsekaiProtagonist
{
    class HaremMagnetFeature
    {
        public static void Add()
        {
            var Icon_Harem = AssetLoader.LoadInternal("Features", "ICON_HAREM.png");
            var Icon_Harem_Immune = AssetLoader.LoadInternal("Features", "ICON_HAREM_IMMUNE.png");
            var HaremMagnetBuff = Helpers.CreateBlueprint<BlueprintBuff>("HaremMagnetBuff", bp => {
                bp.SetName("Fascinated");
                bp.SetDescription("This creature is Fascinated and can take no actions. Any {g|Encyclopedia:Damage}damage{/g} to the target automatically breaks the effect.");
                bp.m_Icon = Icon_Harem_Immune;
                bp.TickEachSecond = false;
                bp.Stacking = StackingType.Replace;
                bp.Frequency = DurationRate.Rounds;
                bp.m_AllowNonContextActions = false;
                bp.FxOnStart = new PrefabLink() { AssetId = "396af91a93f6e2b468f5fa1a944fae8a" };
                bp.FxOnRemove = new PrefabLink();
                bp.AddComponent<AddCondition>(c => { c.Condition = UnitCondition.Dazed; });
                bp.AddComponent<AddIncomingDamageTrigger>(c => {
                    c.TriggerOnStatDamageOrEnergyDrain = true;
                    c.Actions = Helpers.CreateActionList(
                        new ContextActionRemoveSelf()
                        );
                });
                bp.AddComponent<AddFactContextActions>(c => {
                    c.NewRound = Helpers.CreateActionList();
                    c.Deactivated = Helpers.CreateActionList();
                    c.Activated = Helpers.CreateActionList(
                        new ContextActionSpawnFx()
                        {
                            PrefabLink = new PrefabLink() { AssetId = "28b3cd92c1fdc194d9ee1e378c23be6b" }
                        });
                });
                bp.Ranks = 0;
                bp.IsClassFeature = true;
            });
            var HaremMagnetImmunity = Helpers.CreateBlueprint<BlueprintBuff>("HaremMagnetImmunity", bp => {
                bp.SetName("Harem Magnet Immunity");
                bp.SetDescription("This creature is immune to Harem Magnet for 24 hours.");
                bp.m_Icon = Icon_Harem;
                bp.Stacking = StackingType.Replace;
                bp.Frequency = DurationRate.Rounds;
                bp.AddComponent<IsPositiveEffect>();
                bp.FxOnStart = new PrefabLink();
                bp.FxOnRemove = new PrefabLink();
            });
            var HaremMagnetAbility = Helpers.CreateBlueprint<BlueprintAbility>("HaremMagnetAbility", bp => {
                bp.SetName("Harem Magnet");
                bp.SetDescription("As a {g|Encyclopedia:Free_Action}free action{/g}, enemies within 60 feet who fails a {g|Encyclopedia:DC}DC{/g} 50 {g|Encyclopedia:Saving_Throw}Will save{/g} loses any immunity to mind-affecting effects, charm effects, and compulsion effects, and becomes fascinated for {g|Encyclopedia:Dice}1d4{/g} {g|Encyclopedia:Combat_Round}rounds{/g}. Creatures that succeed at this saving throw are immune to this ability for 24 hours.");
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.SavingThrowType = SavingThrowType.Unknown;
                    c.Actions = Helpers.CreateActionList(
                        new Conditional()
                        {
                            ConditionsChecker = new ConditionsChecker()
                            {
                                Operation = Operation.And,
                                Conditions = new Condition[] {
                                    new ContextConditionIsCaster() {
                                        Not = true
                                    },
                                    new ContextConditionHasFact() {
                                        Not = true,
                                        m_Fact = HaremMagnetBuff.ToReference<BlueprintUnitFactReference>()
                                    },
                                    new ContextConditionHasFact() {
                                        Not = true,
                                        m_Fact = HaremMagnetImmunity.ToReference<BlueprintUnitFactReference>()
                                    }
                                }
                            },
                            IfTrue = Helpers.CreateActionList(
                                new ContextActionSavingThrow()
                                {
                                    m_ConditionalDCIncrease = new ContextActionSavingThrow.ConditionalDCIncrease[0],
                                    FromBuff = false,
                                    Type = SavingThrowType.Will,
                                    UseDCFromContextSavingThrow = true,
                                    CustomDC = 50,
                                    HasCustomDC = true,
                                    Actions = Helpers.CreateActionList(
                                        new ContextActionConditionalSaved()
                                        {
                                            Succeed = Helpers.CreateActionList(
                                                new ContextActionApplyBuff()
                                                {
                                                    Permanent = false,
                                                    m_Buff = HaremMagnetImmunity.ToReference<BlueprintBuffReference>(),
                                                    DurationValue = new ContextDurationValue()
                                                    {
                                                        Rate = DurationRate.Hours,
                                                        DiceType = DiceType.Zero,
                                                        DiceCountValue = 0,
                                                        BonusValue = new ContextValue()
                                                        {
                                                            ValueType = ContextValueType.Simple,
                                                            Value = 24,
                                                            ValueRank = AbilityRankType.Default
                                                        },
                                                        m_IsExtendable = true
                                                    },
                                                    UseDurationSeconds = false,
                                                    DurationSeconds = 0,
                                                    IsFromSpell = false,
                                                    ToCaster = false,
                                                    AsChild = false,
                                                }),
                                            Failed = Helpers.CreateActionList(
                                                new ContextActionApplyBuff()
                                                {
                                                    Permanent = false,
                                                    m_Buff = HaremMagnetBuff.ToReference<BlueprintBuffReference>(),
                                                    DurationValue = new ContextDurationValue()
                                                    {
                                                        Rate = DurationRate.Rounds,
                                                        DiceType = DiceType.D4,
                                                        DiceCountValue = 1,
                                                        BonusValue = new ContextValue(),
                                                        m_IsExtendable = true
                                                    },
                                                    UseDurationSeconds = false,
                                                    DurationSeconds = 0,
                                                    IsFromSpell = false,
                                                    ToCaster = false,
                                                    AsChild = false,
                                                })
                                        }
                                    )
                                }),
                            IfFalse = Helpers.CreateActionList(),
                        });
                });
                bp.AddComponent<AbilityTargetsAround>(c => {
                    c.m_Radius = new Feet() { m_Value = 60 };
                    c.m_TargetType = TargetType.Enemy;
                    c.m_Condition = new ConditionsChecker()
                    {
                        Conditions = new Condition[0]
                    };
                });
                bp.AddComponent<ContextSetAbilityParams>(c => {
                    c.DC = 50;
                });
                bp.m_Icon = Icon_Harem;
                bp.Type = AbilityType.Supernatural;
                bp.Range = AbilityRange.Personal;
                bp.CanTargetPoint = false;
                bp.CanTargetEnemies = true;
                bp.CanTargetFriends = false;
                bp.CanTargetSelf = true;
                bp.EffectOnAlly = AbilityEffectOnUnit.None;
                bp.EffectOnEnemy = AbilityEffectOnUnit.None;
                bp.Animation = UnitAnimationActionCastSpell.CastAnimationStyle.Self;
                bp.ActionType = UnitCommand.CommandType.Free;
                bp.AvailableMetamagic = Metamagic.Reach;
                bp.m_TargetMapObjects = false;
                bp.LocalizedDuration = Helpers.CreateString($"{bp.name}.Duration", "1d4 rounds");
                bp.LocalizedSavingThrow = Helpers.CreateString($"{bp.name}.SavingThrow", "Will negates");
            });
            var HaremMagnetFeature = Helpers.CreateBlueprint<BlueprintFeature>("HaremMagnetFeature", bp => {
                bp.SetName("Harem Magnet");
                bp.SetDescription("At 17th Level, you gain the ability to attract anyone. As a {g|Encyclopedia:Free_Action}free action{/g}, enemies within 60 feet who fails a {g|Encyclopedia:DC}DC{/g} 50 {g|Encyclopedia:Saving_Throw}Will save{/g} loses any immunity to mind-affecting effects, charm effects, and compulsion effects, and becomes fascinated for {g|Encyclopedia:Dice}1d4{/g} {g|Encyclopedia:Combat_Round}rounds{/g}. Creatures that succeed at this saving throw are immune to this ability for 24 hours.");
                bp.m_Icon = Icon_Harem;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { HaremMagnetAbility.ToReference<BlueprintUnitFactReference>() };
                });
            });
        }
    }
}
