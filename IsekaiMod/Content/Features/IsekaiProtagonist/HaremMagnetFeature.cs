using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.EntitySystem.Stats;
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
            var HaremMagnetImmunity = Helpers.CreateBuff("HaremMagnetImmunity", bp => {
                bp.SetName("Harem Magnet Immunity");
                bp.SetDescription("This creature is immune to Harem Magnet for 24 hours.");
                bp.m_Icon = Icon_Harem;
                bp.AddComponent<IsPositiveEffect>();
            });
            var HaremMagnetBuff = Helpers.CreateBuff("HaremMagnetBuff", bp => {
                bp.SetName("Fascinated");
                bp.SetDescription("This creature is Fascinated and can take no actions. Any {g|Encyclopedia:Damage}damage{/g} to the target automatically breaks the effect.");
                bp.m_Icon = Icon_Harem_Immune;
                bp.Stacking = StackingType.Ignore;
                bp.FxOnStart = new PrefabLink() { AssetId = "396af91a93f6e2b468f5fa1a944fae8a" };
                bp.AddComponent<AddCondition>(c => { c.Condition = UnitCondition.Dazed; });
                bp.AddComponent<AddIncomingDamageTrigger>(c => {
                    c.TriggerOnStatDamageOrEnergyDrain = true;
                    c.Actions = ActionFlow.DoSingle<ContextActionRemoveSelf>();
                });
                bp.AddComponent<AddFactContextActions>(c => {
                    c.NewRound = ActionFlow.DoNothing();
                    c.Deactivated = ActionFlow.DoSingle<ContextActionApplyBuff>(c => {
                        c.m_Buff = HaremMagnetImmunity.ToReference<BlueprintBuffReference>();
                        c.DurationValue = Constants.OneDay;
                    });
                    c.Activated = ActionFlow.DoSingle<ContextActionSpawnFx>(c => {
                        c.PrefabLink = new PrefabLink() { AssetId = "28b3cd92c1fdc194d9ee1e378c23be6b" };
                    });
                });
                bp.IsClassFeature = true;
            });
            var HaremMagnetAbility = Helpers.CreateBlueprint<BlueprintAbility>("HaremMagnetAbility", bp => {
                bp.SetName("Harem Magnet");
                bp.SetDescription("As a {g|Encyclopedia:Free_Action}free action{/g}, enemies within 60 feet who fails a {g|Encyclopedia:DC}DC{/g} 50 "
                    + "{g|Encyclopedia:Saving_Throw}Will save{/g} loses any immunity to mind-affecting effects, charm effects, and compulsion effects, and becomes fascinated for "
                    + "{g|Encyclopedia:Dice}1d4{/g} {g|Encyclopedia:Combat_Round}rounds{/g}. Creatures that succeed at this saving throw are immune to this ability for 24 hours.");
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.Actions = ActionFlow.DoSingle<Conditional>(c => {
                        c.ConditionsChecker = ActionFlow.IfSingle<ContextConditionHasFact>(c => {
                            c.Not = true;
                            c.m_Fact = HaremMagnetImmunity.ToReference<BlueprintUnitFactReference>();
                        });
                        c.IfTrue = ActionFlow.DoSingle<ContextActionSavingThrow>(c => {
                            c.m_ConditionalDCIncrease = new ContextActionSavingThrow.ConditionalDCIncrease[0];
                            c.Type = SavingThrowType.Will;
                            c.UseDCFromContextSavingThrow = true;
                            c.HasCustomDC = true;
                            c.CustomDC = 50;
                            c.Actions = ActionFlow.DoSingle<ContextActionConditionalSaved>(c => {
                                c.Succeed = ActionFlow.DoSingle<ContextActionApplyBuff>(c => {
                                    c.m_Buff = HaremMagnetImmunity.ToReference<BlueprintBuffReference>();
                                    c.DurationValue = Constants.OneDay;
                                });
                                c.Failed = ActionFlow.DoSingle<ContextActionApplyBuff>(c => {
                                    c.m_Buff = HaremMagnetBuff.ToReference<BlueprintBuffReference>();
                                    c.DurationValue = new ContextDurationValue()
                                    {
                                        Rate = DurationRate.Rounds,
                                        DiceType = DiceType.D4,
                                        DiceCountValue = 1,
                                        BonusValue = 0,
                                        m_IsExtendable = true
                                    };
                                });
                            });
                        });
                    c.IfFalse = ActionFlow.DoNothing();
                    });
                });
                bp.AddComponent<AbilityTargetsAround>(c => {
                    c.m_Radius = new Feet(60);
                    c.m_TargetType = TargetType.Enemy;
                    c.m_Condition = ActionFlow.EmptyCondition();
                });
                bp.AddComponent<ContextSetAbilityParams>(c => {
                    c.DC = 50;
                });
                bp.m_Icon = Icon_Harem;
                bp.Type = AbilityType.Supernatural;
                bp.Range = AbilityRange.Personal;
                bp.CanTargetEnemies = true;
                bp.Animation = UnitAnimationActionCastSpell.CastAnimationStyle.Self;
                bp.ActionType = UnitCommand.CommandType.Free;
                bp.AvailableMetamagic = Metamagic.Reach;
                bp.LocalizedDuration = Helpers.CreateString($"{bp.name}.Duration", "1d4 rounds");
                bp.LocalizedSavingThrow = Helpers.CreateString($"{bp.name}.SavingThrow", "Will negates");
            });
            var HaremMagnetFeature = Helpers.CreateFeature("HaremMagnetFeature", bp => {
                bp.SetName("Harem Magnet");
                bp.SetDescription("At 17th Level, you gain the ability to attract anyone. As a {g|Encyclopedia:Free_Action}free action{/g}, enemies within 60 feet who fails a "
                    + "{g|Encyclopedia:DC}DC{/g} 50 {g|Encyclopedia:Saving_Throw}Will save{/g} loses any immunity to mind-affecting effects, charm effects, and compulsion effects, "
                    + "and becomes fascinated for {g|Encyclopedia:Dice}1d4{/g} {g|Encyclopedia:Combat_Round}rounds{/g}. Creatures that succeed at this saving throw are immune to this "
                    + "ability for 24 hours.");
                bp.m_Icon = Icon_Harem;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { HaremMagnetAbility.ToReference<BlueprintUnitFactReference>() };
                });
            });
        }
    }
}
