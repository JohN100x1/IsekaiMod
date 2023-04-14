using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.Enums;
using Kingmaker.Localization;
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
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.OverpoweredAbility {

    internal class MindControl {

        public static void Add() {
            var Icon_MindControl = AssetLoader.LoadInternal(IsekaiContext, "Features", "ICON_MIND_CONTROL.png");
            var Icon_MindControlImmune = AssetLoader.LoadInternal(IsekaiContext, "Features", "ICON_MIND_CONTROL_IMMUNE.png");

            LocalizedString MindControlDesc = Helpers.CreateString(IsekaiContext, "MindControl.Description",
                "Behold the power of a king! All will listen and obey!"
                + "\nBenefit: You can make any creature fight on your side as if it was your ally. "
                + "It will {g|Encyclopedia:Attack}attack{/g} your opponents to the best of its ability.");

            var MindControlImmunity = TTCoreExtensions.CreateBuff("MindControlImmunity", bp => {
                bp.SetName(IsekaiContext, "Mind Control Immunity");
                bp.SetDescription(IsekaiContext, "This creature cannot be mind controlled again.");
                bp.m_Icon = Icon_MindControlImmune;
                bp.AddComponent<IsPositiveEffect>();
            });
            var MindControlBuff = TTCoreExtensions.CreateBuff("MindControlBuff", bp => {
                bp.SetName(IsekaiContext, "Mind Controlled");
                bp.SetDescription(IsekaiContext, "This creature has been mind controlled.");
                bp.m_Icon = Icon_MindControl;
                bp.AddComponent<ChangeFaction>(c => {
                    c.m_Type = ChangeFaction.ChangeType.ToCaster;
                });
                bp.AddComponent<AddFactContextActions>(c => {
                    c.NewRound = ActionFlow.DoNothing();
                    c.Activated = ActionFlow.DoSingle<ContextActionSpawnFx>(c => {
                        c.PrefabLink = new PrefabLink() { AssetId = "28b3cd92c1fdc194d9ee1e378c23be6b" };
                    });
                    c.Deactivated = ActionFlow.DoSingle<ContextActionApplyBuff>(c => {
                        c.m_Buff = MindControlImmunity.ToReference<BlueprintBuffReference>();
                        c.Permanent = true;
                        c.DurationValue = Values.Duration.Zero;
                    });
                });
                bp.Stacking = StackingType.Ignore;
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.StayOnDeath;
                bp.FxOnStart = new PrefabLink() { AssetId = "53975f48f933c534ea9c6bb97a3f64eb" };
            });
            var MindControlAbility = Helpers.CreateBlueprint<BlueprintAbility>(IsekaiContext, "MindControlAbility", bp => {
                bp.SetName(IsekaiContext, "Overpowered Ability — Mind Control");
                bp.SetDescription(MindControlDesc);
                bp.m_Icon = Icon_MindControl;
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.Actions = ActionFlow.DoSingle<Conditional>(c => {
                        c.ConditionsChecker = ActionFlow.IfSingle<ContextConditionHasFact>(c => {
                            c.m_Fact = MindControlImmunity.ToReference<BlueprintUnitFactReference>();
                        });
                        c.IfTrue = ActionFlow.DoNothing();
                        c.IfFalse = ActionFlow.DoSingle<ContextActionApplyBuff>(c => {
                            c.m_Buff = MindControlBuff.ToReference<BlueprintBuffReference>();
                            c.DurationValue = new ContextDurationValue() {
                                Rate = DurationRate.Rounds,
                                DiceType = DiceType.Zero,
                                DiceCountValue = 0,
                                BonusValue = Values.CreateContextRankValue(AbilityRankType.Default),
                                m_IsExtendable = true,
                            };
                        });
                    });
                });
                bp.AddComponent<SpellComponent>(c => {
                    c.School = SpellSchool.Enchantment;
                });
                bp.AddComponent<AbilitySpawnFx>(c => {
                    c.PrefabLink = new PrefabLink() { AssetId = "c14a2f46018cb0e41bfeed61463510ff" };
                    c.Time = AbilitySpawnFxTime.OnApplyEffect;
                    c.Anchor = AbilitySpawnFxAnchor.SelectedTarget;
                });
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.StatBonus;
                    c.m_BaseValueType = ContextRankBaseValueType.CharacterLevel;
                });
                bp.Type = AbilityType.Supernatural;
                bp.Range = AbilityRange.Medium;
                bp.CanTargetEnemies = true;
                bp.Animation = UnitAnimationActionCastSpell.CastAnimationStyle.Directional;
                bp.ActionType = UnitCommand.CommandType.Standard;
                bp.AvailableMetamagic = Metamagic.Reach | Metamagic.CompletelyNormal;
                bp.LocalizedDuration = StaticReferences.Strings.Duration.OneRoundPerLevel;
                bp.LocalizedSavingThrow = StaticReferences.Strings.Null;
            });
            var MindControlFeature = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "MindControlFeature", bp => {
                bp.SetName(IsekaiContext, "Overpowered Ability — Mind Control");
                bp.SetDescription(MindControlDesc);
                bp.m_Icon = Icon_MindControl;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { MindControlAbility.ToReference<BlueprintUnitFactReference>() };
                });
            });

            OverpoweredAbilitySelection.AddToNonAutoSelection(MindControlFeature);
        }
    }
}