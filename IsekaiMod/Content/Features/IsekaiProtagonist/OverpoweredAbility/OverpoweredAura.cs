using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Items.Ecnchantments;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.Designers.Mechanics.Buffs;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.Enums;
using Kingmaker.Enums.Damage;
using Kingmaker.Localization;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UI.GenericSlot;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components.AreaEffects;
using Kingmaker.UnitLogic.Alignments;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.UnitLogic.Mechanics.Conditions;
using Kingmaker.Utility;
using TabletopTweaks.Core.Utilities;
using UnityEngine;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.OverpoweredAbility {

    internal class OverpoweredAura {
        public static void Add() {

            var Icon_RighteousWrath = AssetLoader.LoadInternal(IsekaiContext, "Features", "ICON_OP_AURA_RIGHTEOUS_WRATH.png");
            var Icon_MalevolentRage = AssetLoader.LoadInternal(IsekaiContext, "Features", "ICON_OP_AURA_MALEVOLENT_RAGE.png");
            var Icon_ChaoticFrenzy = AssetLoader.LoadInternal(IsekaiContext, "Features", "ICON_OP_AURA_CHAOTIC_FRENZY.png");
            var Icon_IndignantFury = BlueprintTools.GetBlueprint<BlueprintAbility>("4c349361d720e844e846ad8c19959b1e").m_Icon;

            LocalizedString RighteousWrathDisplayName = Helpers.CreateString(IsekaiContext, "RighteousWrath.Name",
                "Overpowered Aura — Righteous Wrath");
            LocalizedString RighteousWrathDisplayNameBuff = Helpers.CreateString(IsekaiContext, "RighteousWrathBuff.Name",
                "Aura of Righteous Wrath");
            LocalizedString RighteousWrathDisplayDesc = Helpers.CreateString(IsekaiContext, "RighteousWrath.Description",
                "Good allies within 120 feet of you has an extra attack and deals an additional 5d6 holy damage.");
            LocalizedString RighteousWrathDisplayDescBuff = Helpers.CreateString(IsekaiContext, "RighteousWrathBuff.Description",
                "This character has an extra attack and deals an additional 5d6 holy damage.");

            var RighteousWrathEnchantment = Helpers.CreateBlueprint<BlueprintWeaponEnchantment>(IsekaiContext, "RighteousWrathEnchantment", bp => {
                bp.SetName(RighteousWrathDisplayNameBuff);
                bp.SetDescription(RighteousWrathDisplayDescBuff);
                bp.m_Prefix = StaticReferences.Strings.Null;
                bp.m_Suffix = StaticReferences.Strings.Null;
                bp.AddComponent<WeaponEnergyDamageDice>(c => {
                    c.EnergyDamageDice = new DiceFormula() {
                        m_Dice = DiceType.D6,
                        m_Rolls = 5
                    };
                    c.Element = DamageEnergyType.Holy;
                });
            });
            var RighteousWrathBuff = TTCoreExtensions.CreateBuff($"RighteousWrathBuff", bp => {
                bp.SetName(RighteousWrathDisplayNameBuff);
                bp.SetDescription(RighteousWrathDisplayDescBuff);
                bp.IsClassFeature = true;
                bp.m_Icon = Icon_RighteousWrath;
                bp.AddComponent<BuffExtraAttack>(c => {
                    c.Number = 1;
                });
                bp.AddComponent<BuffEnchantAnyWeapon>(c => {
                    c.m_EnchantmentBlueprint = RighteousWrathEnchantment.ToReference<BlueprintItemEnchantmentReference>();
                    c.Slot = EquipSlotBase.SlotType.PrimaryHand;
                });
                bp.AddComponent<BuffEnchantAnyWeapon>(c => {
                    c.m_EnchantmentBlueprint = RighteousWrathEnchantment.ToReference<BlueprintItemEnchantmentReference>();
                    c.Slot = EquipSlotBase.SlotType.SecondaryHand;
                });
            });
            var RighteousWrathFeature = CreateOPAuraFeature(
                name: "RighteousWrath",
                displayName: RighteousWrathDisplayName,
                displayDesc: RighteousWrathDisplayDesc,
                icon: Icon_RighteousWrath,
                buff: RighteousWrathBuff,
                alignment: AlignmentComponent.Good,
                alignmentMask: AlignmentMaskType.Good
                );


            LocalizedString MalevolentRageDisplayName = Helpers.CreateString(IsekaiContext, "MalevolentRage.Name",
                "Overpowered Aura — Malevolent Rage");
            LocalizedString MalevolentRageDisplayNameBuff = Helpers.CreateString(IsekaiContext, "MalevolentRageBuff.Name",
                "Aura of Malevolent Rage");
            LocalizedString MalevolentRageDisplayDesc = Helpers.CreateString(IsekaiContext, "MalevolentRage.Description",
                "Evil allies within 120 feet of you has an extra attack and deals an additional 5d6 unholy damage.");
            LocalizedString MalevolentRageDisplayDescBuff = Helpers.CreateString(IsekaiContext, "MalevolentRageBuff.Description",
                "This character has an extra attack and deals an additional 5d6 unholy damage.");


            var MalevolentRageEnchantment = Helpers.CreateBlueprint<BlueprintWeaponEnchantment>(IsekaiContext, "MalevolentRageEnchantment", bp => {
                bp.SetName(MalevolentRageDisplayNameBuff);
                bp.SetDescription(MalevolentRageDisplayDescBuff);
                bp.m_Prefix = StaticReferences.Strings.Null;
                bp.m_Suffix = StaticReferences.Strings.Null;
                bp.AddComponent<WeaponEnergyDamageDice>(c => {
                    c.EnergyDamageDice = new DiceFormula() {
                        m_Dice = DiceType.D6,
                        m_Rolls = 5
                    };
                    c.Element = DamageEnergyType.Unholy;
                });
            });
            var MalevolentRageBuff = TTCoreExtensions.CreateBuff($"MalevolentRageBuff", bp => {
                bp.SetName(MalevolentRageDisplayNameBuff);
                bp.SetDescription(MalevolentRageDisplayDescBuff);
                bp.IsClassFeature = true;
                bp.m_Icon = Icon_MalevolentRage;
                bp.AddComponent<BuffExtraAttack>(c => {
                    c.Number = 1;
                });
                bp.AddComponent<BuffEnchantAnyWeapon>(c => {
                    c.m_EnchantmentBlueprint = MalevolentRageEnchantment.ToReference<BlueprintItemEnchantmentReference>();
                    c.Slot = EquipSlotBase.SlotType.PrimaryHand;
                });
                bp.AddComponent<BuffEnchantAnyWeapon>(c => {
                    c.m_EnchantmentBlueprint = MalevolentRageEnchantment.ToReference<BlueprintItemEnchantmentReference>();
                    c.Slot = EquipSlotBase.SlotType.SecondaryHand;
                });
            });
            var MalevolentRageFeature = CreateOPAuraFeature(
                name: "MalevolentRage",
                displayName: MalevolentRageDisplayName,
                displayDesc: MalevolentRageDisplayDesc,
                icon: Icon_MalevolentRage,
                buff: MalevolentRageBuff,
                alignment: AlignmentComponent.Evil,
                alignmentMask: AlignmentMaskType.Evil
                );

            LocalizedString IndignantFuryDisplayName = Helpers.CreateString(IsekaiContext, "IndignantFury.Name",
                "Overpowered Aura — Indignant Fury");
            LocalizedString IndignantFuryDisplayNameBuff = Helpers.CreateString(IsekaiContext, "IndignantFuryBuff.Name",
                "Aura of Indignant Fury");
            LocalizedString IndignantFuryDisplayDesc = Helpers.CreateString(IsekaiContext, "IndignantFury.Description",
                "Lawful allies within 120 feet of you deals an additional 8d6 force damage.");
            LocalizedString IndignantFuryDisplayDescBuff = Helpers.CreateString(IsekaiContext, "IndignantFuryBuff.Description",
                "This character deals an additional 8d6 force damage.");


            var IndignantFuryEnchantment = Helpers.CreateBlueprint<BlueprintWeaponEnchantment>(IsekaiContext, "IndignantFuryEnchantment", bp => {
                bp.SetName(IndignantFuryDisplayNameBuff);
                bp.SetDescription(IndignantFuryDisplayDescBuff);
                bp.m_Prefix = StaticReferences.Strings.Null;
                bp.m_Suffix = StaticReferences.Strings.Null;
                bp.AddComponent<WeaponConditionalDamageDice>(c => {
                    c.Conditions = ActionFlow.EmptyCondition();
                    c.Damage = new DamageDescription() {
                        Dice = new DiceFormula() {
                            m_Dice = DiceType.D6,
                            m_Rolls = 8,
                        },
                        TypeDescription = new DamageTypeDescription() {
                            Type = DamageType.Force,
                            Physical = new DamageTypeDescription.PhysicalData(),
                            Common = new DamageTypeDescription.CommomData(),
                        }
                    };
                });
            });
            var IndignantFuryBuff = TTCoreExtensions.CreateBuff($"IndignantFuryBuff", bp => {
                bp.SetName(IndignantFuryDisplayNameBuff);
                bp.SetDescription(IndignantFuryDisplayDescBuff);
                bp.IsClassFeature = true;
                bp.m_Icon = Icon_IndignantFury;
                bp.AddComponent<BuffEnchantAnyWeapon>(c => {
                    c.m_EnchantmentBlueprint = IndignantFuryEnchantment.ToReference<BlueprintItemEnchantmentReference>();
                    c.Slot = EquipSlotBase.SlotType.PrimaryHand;
                });
                bp.AddComponent<BuffEnchantAnyWeapon>(c => {
                    c.m_EnchantmentBlueprint = IndignantFuryEnchantment.ToReference<BlueprintItemEnchantmentReference>();
                    c.Slot = EquipSlotBase.SlotType.SecondaryHand;
                });
            });
            var IndignantFuryFeature = CreateOPAuraFeature(
                name: "IndignantFury",
                displayName: IndignantFuryDisplayName,
                displayDesc: IndignantFuryDisplayDesc,
                icon: Icon_IndignantFury,
                buff: IndignantFuryBuff,
                alignment: AlignmentComponent.Lawful,
                alignmentMask: AlignmentMaskType.Lawful
                );

            LocalizedString ChaoticFrenzyDisplayName = Helpers.CreateString(IsekaiContext, "ChaoticFrenzy.Name",
                "Overpowered Aura — Chaotic Frenzy");
            LocalizedString ChaoticFrenzyDisplayNameBuff = Helpers.CreateString(IsekaiContext, "ChaoticFrenzyBuff.Name",
                "Aura of Chaotic Frenzy");
            LocalizedString ChaoticFrenzyDisplayDesc = Helpers.CreateString(IsekaiContext, "ChaoticFrenzy.Description",
                "Chaotic allies within 120 feet of you has two extra attacks and deals an additional 2d6 physical damage.");
            LocalizedString ChaoticFrenzyDisplayDescBuff = Helpers.CreateString(IsekaiContext, "ChaoticFrenzyBuff.Description",
                "This character has two extra attacks and deals an additional 2d6 physical damage.");


            var ChaoticFrenzyEnchantment = Helpers.CreateBlueprint<BlueprintWeaponEnchantment>(IsekaiContext, "ChaoticFrenzyEnchantment", bp => {
                bp.SetName(ChaoticFrenzyDisplayNameBuff);
                bp.SetDescription(ChaoticFrenzyDisplayDescBuff);
                bp.m_Prefix = StaticReferences.Strings.Null;
                bp.m_Suffix = StaticReferences.Strings.Null;
                bp.AddComponent<WeaponConditionalDamageDice>(c => {
                    c.Conditions = ActionFlow.EmptyCondition();
                    c.Damage = new DamageDescription() {
                        Dice = new DiceFormula() {
                            m_Dice = DiceType.D6,
                            m_Rolls = 2,
                        },
                        TypeDescription = new DamageTypeDescription() {
                            Type = DamageType.Physical,
                            Physical = new DamageTypeDescription.PhysicalData() {
                                Form = PhysicalDamageForm.Bludgeoning | PhysicalDamageForm.Piercing | PhysicalDamageForm.Slashing
                            },
                            Common = new DamageTypeDescription.CommomData(),
                        }
                    };
                });
            });
            var ChaoticFrenzyBuff = TTCoreExtensions.CreateBuff($"ChaoticFrenzyBuff", bp => {
                bp.SetName(ChaoticFrenzyDisplayNameBuff);
                bp.SetDescription(ChaoticFrenzyDisplayDescBuff);
                bp.IsClassFeature = true;
                bp.m_Icon = Icon_ChaoticFrenzy;
                bp.AddComponent<BuffExtraAttack>(c => {
                    c.Number = 2;
                });
                bp.AddComponent<BuffEnchantAnyWeapon>(c => {
                    c.m_EnchantmentBlueprint = ChaoticFrenzyEnchantment.ToReference<BlueprintItemEnchantmentReference>();
                    c.Slot = EquipSlotBase.SlotType.PrimaryHand;
                });
                bp.AddComponent<BuffEnchantAnyWeapon>(c => {
                    c.m_EnchantmentBlueprint = ChaoticFrenzyEnchantment.ToReference<BlueprintItemEnchantmentReference>();
                    c.Slot = EquipSlotBase.SlotType.SecondaryHand;
                });
            });
            var ChaoticFrenzyFeature = CreateOPAuraFeature(
                name: "ChaoticFrenzy",
                displayName: ChaoticFrenzyDisplayName,
                displayDesc: ChaoticFrenzyDisplayDesc,
                icon: Icon_ChaoticFrenzy,
                buff: ChaoticFrenzyBuff,
                alignment: AlignmentComponent.Chaotic,
                alignmentMask: AlignmentMaskType.Chaotic
                );


            var OverpoweredAuraSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "OverpoweredAuraSelection", bp => {
                bp.SetName(IsekaiContext, "Overpowered Aura");
                bp.SetDescription(IsekaiContext, "You gain an Overpowered Aura that greatly enhances the combat ability of your allies.");
                bp.m_Icon = Icon_RighteousWrath;
                bp.m_AllFeatures = new BlueprintFeatureReference[] {
                    RighteousWrathFeature.ToReference<BlueprintFeatureReference>(),
                    MalevolentRageFeature.ToReference<BlueprintFeatureReference>(),
                    IndignantFuryFeature.ToReference<BlueprintFeatureReference>(),
                    ChaoticFrenzyFeature.ToReference<BlueprintFeatureReference>(),
                };
            });

            OverpoweredAbilitySelection.AddToNonAutoSelection(OverpoweredAuraSelection);
        }

        private static BlueprintFeature CreateOPAuraFeature(string name, LocalizedString displayName, LocalizedString displayDesc, Sprite icon, BlueprintBuff buff, AlignmentComponent alignment, AlignmentMaskType alignmentMask) {
            var feature = TTCoreExtensions.CreateToggleAuraFeature(
                name: name,
                displayName: displayName,
                displayDesc: displayDesc,
                icon: icon,
                areaEffect: bp => {
                    bp.m_TargetType = BlueprintAbilityAreaEffect.TargetType.Ally;
                    bp.Size = new Feet(120);
                    bp.AddComponent<AbilityAreaEffectRunAction>(c => {
                        c.UnitEnter = ActionFlow.DoSingle<Conditional>(c => {
                            c.ConditionsChecker = ActionFlow.IfSingle<ContextConditionAlignment>(c => {
                                c.Alignment = alignment;
                            });
                            c.IfTrue = ActionFlow.DoSingle<ContextActionApplyBuff>(c => {
                                c.m_Buff = buff.ToReference<BlueprintBuffReference>();
                                c.DurationValue = Values.Duration.Zero;
                                c.Permanent = true;
                            });
                            c.IfFalse = ActionFlow.DoNothing();
                        });
                        c.UnitExit = ActionFlow.DoSingle<ContextActionRemoveBuff>(b => {
                            b.m_Buff = buff.ToReference<BlueprintBuffReference>();
                        });
                        c.UnitMove = ActionFlow.DoNothing();
                        c.Round = ActionFlow.DoNothing();
                    });
                });
            feature.AddComponent<PrerequisiteAlignment>(c => {
                c.Group = Prerequisite.GroupType.Any;
                c.Alignment = alignmentMask;
            });
            return feature;
        }
    }
}