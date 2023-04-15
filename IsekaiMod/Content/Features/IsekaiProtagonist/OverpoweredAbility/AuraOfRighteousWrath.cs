using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Items.Ecnchantments;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.Designers.Mechanics.Buffs;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.Enums.Damage;
using Kingmaker.Localization;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UI.GenericSlot;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components.AreaEffects;
using Kingmaker.UnitLogic.Alignments;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.UnitLogic.Mechanics.Conditions;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.OverpoweredAbility {

    internal class AuraOfRighteousWrath {
        public static void Add() {

            var Icon_AuraOfRighteousWrath = AssetLoader.LoadInternal(IsekaiContext, "Features", "ICON_OP_AURA_RIGHTEOUS_WRATH.png");
            var Icon_AuraOfMalevolentRage = AssetLoader.LoadInternal(IsekaiContext, "Features", "ICON_OP_AURA_MALEVOLENT_RAGE.png");
            var Icon_AuraOfChaoticFrenzy = AssetLoader.LoadInternal(IsekaiContext, "Features", "ICON_OP_AURA_CHAOTIC_FRENZY.png");
            var Icon_AuraOfIndignantFury = BlueprintTools.GetBlueprint<BlueprintAbility>("4c349361d720e844e846ad8c19959b1e").m_Icon;

            LocalizedString AuraOfRighteousWrathDescBuff = Helpers.CreateString(IsekaiContext, "AuraOfRighteousWrathBuff.Description",
                "This character has two extra attacks and deal an additional 5d6 physical damage.");

            var AuraOfRighteousWrathEnchantment = Helpers.CreateBlueprint<BlueprintWeaponEnchantment>(IsekaiContext, "AuraOfRighteousWrathEnchantment", bp => {
                bp.SetName(IsekaiContext, "Overpowered Ability — Aura of Righteous Wrath");
                bp.SetDescription(AuraOfRighteousWrathDescBuff);
                bp.m_Prefix = StaticReferences.Strings.Null;
                bp.m_Suffix = StaticReferences.Strings.Null;
                bp.AddComponent<WeaponConditionalDamageDice>(c => {
                    c.Damage = new DamageDescription() {
                        Dice = new DiceFormula() {
                            m_Dice = DiceType.D6,
                            m_Rolls = 5
                        },
                        TypeDescription = new DamageTypeDescription() {
                            Type = DamageType.Physical,
                            Common = new DamageTypeDescription.CommomData(),
                            Physical = new DamageTypeDescription.PhysicalData() {
                                Form = PhysicalDamageForm.Bludgeoning | PhysicalDamageForm.Piercing | PhysicalDamageForm.Slashing
                            }
                        }
                    };
                    c.Conditions = ActionFlow.EmptyCondition();
                });
            });
            var AuraOfRighteousWrathBuff = TTCoreExtensions.CreateBuff($"AuraOfRighteousWrathBuff", bp => {
                bp.SetName(IsekaiContext, "Overpowered Ability — Aura of Righteous Wrath");
                bp.SetDescription(AuraOfRighteousWrathDescBuff);
                bp.IsClassFeature = true;
                bp.m_Icon = Icon_AuraOfRighteousWrath;
                bp.AddComponent<BuffExtraAttack>(c => {
                    c.Number = 2;
                });
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Stat = StatType.SneakAttack;
                    c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                }); // TODO: remove sneak attack
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.StatBonus;
                    c.m_BaseValueType = ContextRankBaseValueType.CharacterLevel;
                    c.m_Progression = ContextRankProgression.Div2;
                });
                bp.AddComponent<BuffEnchantAnyWeapon>(c => {
                    c.m_EnchantmentBlueprint = AuraOfRighteousWrathEnchantment.ToReference<BlueprintItemEnchantmentReference>();
                    c.Slot = EquipSlotBase.SlotType.PrimaryHand;
                });
                bp.AddComponent<BuffEnchantAnyWeapon>(c => {
                    c.m_EnchantmentBlueprint = AuraOfRighteousWrathEnchantment.ToReference<BlueprintItemEnchantmentReference>();
                    c.Slot = EquipSlotBase.SlotType.SecondaryHand;
                });
            });

            var AuraOfRighteousWrathFeature = TTCoreExtensions.CreateToggleAuraFeature(
                name: "AuraOfRighteousWrath",
                displayName: "Overpowered Ability — Aura of Righteous Wrath",
                description: "Good allies within 120 feet of you has two extra attacks and deal an additional 5d6 physical damage.",
                icon: Icon_AuraOfRighteousWrath,
                areaEffect: bp => {
                    bp.AddComponent<AbilityAreaEffectRunAction>(c => {
                        c.UnitEnter = ActionFlow.DoSingle<Conditional>(c => {
                            c.ConditionsChecker = ActionFlow.IfSingle<ContextConditionAlignment>(c => {
                                c.Alignment = AlignmentComponent.Good;
                            });
                            c.IfTrue = ActionFlow.DoSingle<ContextActionApplyBuff>(c => {
                                c.m_Buff = AuraOfRighteousWrathBuff.ToReference<BlueprintBuffReference>();
                                c.DurationValue = Values.Duration.Zero;
                                c.Permanent = true;
                            });
                            c.IfFalse = ActionFlow.DoNothing();
                        });
                        c.UnitExit = ActionFlow.DoSingle<ContextActionRemoveBuff>(b => {
                            b.m_Buff = AuraOfRighteousWrathBuff.ToReference<BlueprintBuffReference>();
                        });
                        c.UnitMove = ActionFlow.DoNothing();
                        c.Round = ActionFlow.DoNothing();
                    });
                });
            AuraOfRighteousWrathFeature.AddComponent<PrerequisiteAlignment>(c => {
                c.Group = Prerequisite.GroupType.Any;
                c.Alignment = AlignmentMaskType.Good;
            });

            OverpoweredAbilitySelection.AddToNonAutoSelection(AuraOfRighteousWrathFeature);
        }
    }
}