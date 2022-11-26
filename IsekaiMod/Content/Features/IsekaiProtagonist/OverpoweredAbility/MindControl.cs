using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.ResourceLinks;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Abilities.Components.Base;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Buffs.Components;
using Kingmaker.UnitLogic.Commands.Base;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.UnitLogic.Mechanics.Conditions;
using Kingmaker.Visual.Animation.Kingmaker.Actions;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.OverpoweredAbility
{
    class MindControl
    {
        public static void Add()
        {
            var Icon_Mind_Control = AssetLoader.LoadInternal("Features", "ICON_MIND_CONTROL.png");
            var Icon_Mind_Control_Immune = AssetLoader.LoadInternal("Features", "ICON_MIND_CONTROL_IMMUNE.png");
            var MindControlImmunity = Helpers.CreateBuff("MindControlImmunity", bp => {
                bp.SetName("Mind Control Immunity");
                bp.SetDescription("This creature cannot be mind controlled again.");
                bp.m_Icon = Icon_Mind_Control_Immune;
                bp.Stacking = StackingType.Replace;
                bp.Frequency = DurationRate.Rounds;
                bp.AddComponent<IsPositiveEffect>();
            });
            var MindControlBuff = Helpers.CreateBuff("MindControlBuff", bp => {
                bp.SetName("Mind Controlled");
                bp.SetDescription("This creature has been mind controlled.");
                bp.m_Icon = Icon_Mind_Control;
                bp.AddComponent<ChangeFaction>(c => {
                    c.m_Type = ChangeFaction.ChangeType.ToCaster;
                    c.m_AllowDirectControl = false;
                });
                bp.AddComponent<AddFactContextActions>(c => {
                    c.NewRound = ActionFlow.DoNothing();
                    c.Activated = ActionFlow.DoSingle<ContextActionSpawnFx>(c => {
                        c.PrefabLink = new PrefabLink() { AssetId = "28b3cd92c1fdc194d9ee1e378c23be6b" };
                    });
                    c.Deactivated = ActionFlow.DoSingle<ContextActionApplyBuff>(c => {
                        c.m_Buff = MindControlImmunity.ToReference<BlueprintBuffReference>();
                        c.Permanent = true;
                        c.DurationValue = new ContextDurationValue()
                        {
                            Rate = DurationRate.Rounds,
                            m_IsExtendable = true,
                            DiceType = DiceType.Zero,
                            DiceCountValue = 0,
                            BonusValue = 0,
                        };
                        c.IsFromSpell = false;
                    });
                });
                bp.Stacking = StackingType.Ignore;
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.StayOnDeath;
                bp.FxOnStart = new PrefabLink() { AssetId = "53975f48f933c534ea9c6bb97a3f64eb" };
            });
            var MindControlAbility = Helpers.CreateBlueprint<BlueprintAbility>("MindControlAbility", bp => {
                bp.SetName("Overpowered Ability — Mind Control");
                bp.SetDescription("You can make any creature fight on your side as if it was your ally. "
                    + "It will {g|Encyclopedia:Attack}attack{/g} your opponents to the best of its ability.\n"
                    + " They will not resist.");
                bp.m_Icon = Icon_Mind_Control;
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.SavingThrowType = SavingThrowType.Unknown;
                    c.Actions = ActionFlow.DoSingle<Conditional>(c => {
                        c.ConditionsChecker = ActionFlow.IfSingle<ContextConditionHasFact>(c => {
                            c.Not = false;
                            c.m_Fact = MindControlImmunity.ToReference<BlueprintUnitFactReference>();
                        });
                        c.IfTrue = ActionFlow.DoNothing();
                        c.IfFalse = ActionFlow.DoSingle<ContextActionApplyBuff>(c => {
                            c.m_Buff = MindControlBuff.ToReference<BlueprintBuffReference>();
                            c.Permanent = false;
                            c.DurationValue = new ContextDurationValue()
                            {
                                Rate = DurationRate.Rounds,
                                m_IsExtendable = true,
                                DiceType = DiceType.Zero,
                                DiceCountValue = 0,
                                BonusValue = new ContextValue()
                                {
                                    Value = 0,
                                    ValueType = ContextValueType.Rank
                                }
                            };
                            c.IsFromSpell = false;
                        });
                    });
                });
                bp.AddComponent<SpellComponent>(c => {
                    c.m_Flags = 0;
                    c.School = SpellSchool.Enchantment;
                });
                bp.AddComponent<AbilitySpawnFx>(c => {
                    c.PrefabLink = new PrefabLink() { AssetId = "c14a2f46018cb0e41bfeed61463510ff" };
                    c.Time = AbilitySpawnFxTime.OnApplyEffect;
                    c.Anchor = AbilitySpawnFxAnchor.SelectedTarget;
                });
                bp.Type = AbilityType.Supernatural;
                bp.Range = AbilityRange.Medium;
                bp.m_AllowNonContextActions = false;
                bp.CanTargetPoint = false;
                bp.CanTargetEnemies = true;
                bp.CanTargetFriends = false;
                bp.CanTargetSelf = false;
                bp.SpellResistance = false;
                bp.EffectOnEnemy = AbilityEffectOnUnit.None;
                bp.EffectOnAlly = AbilityEffectOnUnit.None;
                bp.Animation = UnitAnimationActionCastSpell.CastAnimationStyle.Directional;
                bp.ActionType = UnitCommand.CommandType.Standard;
                bp.AvailableMetamagic = Metamagic.Reach | Metamagic.CompletelyNormal;
                bp.m_TargetMapObjects = false;
                bp.LocalizedDuration = Helpers.CreateString($"{bp.name}.Duration", "1 round/level");
                bp.LocalizedSavingThrow = Helpers.CreateString($"{bp.name}.SavingThrow", "");
            });
            var MindControlFeature = Helpers.CreateBlueprint<BlueprintFeature>("MindControlFeature", bp => {
                bp.SetName("Overpowered Ability — Mind Control");
                bp.SetDescription("You can make any creature fight on your side as if it was your ally. "
                    + "It will {g|Encyclopedia:Attack}attack{/g} your opponents to the best of its ability.\n"
                    + " They will not resist.");
                bp.m_Icon = Icon_Mind_Control;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { MindControlAbility.ToReference<BlueprintUnitFactReference>() };
                });
            });

            OverpoweredAbilitySelection.AddToSelection(MindControlFeature);
        }
    }
}
