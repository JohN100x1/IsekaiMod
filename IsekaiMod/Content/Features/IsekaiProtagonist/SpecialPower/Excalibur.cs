using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.Items.Ecnchantments;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.Localization;
using Kingmaker.RuleSystem;
using Kingmaker.UI.GenericSlot;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Commands.Base;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.Visual.Animation.Kingmaker.Actions;
using TabletopTweaks.Core.Utilities;
using UnityEngine;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.SpecialPower {
    internal class Excalibur {
        private const string ExcaliburName = "Excalibur";
        private static readonly LocalizedString ExcaliburDesc = Helpers.CreateString(IsekaiContext, "Excalibur.Description",
            "Your primary weapon gains the holy and radiant enchantments. Your attack range is increased by 40 feet.");

        private static readonly Sprite Icon_Excalibur = AssetLoader.LoadInternal(IsekaiContext, "Features", "ICON_EXCALIBUR.png");
        public static void Add() {

            var RadiantEnchantment = BlueprintTools.GetBlueprint<BlueprintWeaponEnchantment>("5ac5c88157f7dde48a2a5b24caf40131");
            var HolyEnchantment = BlueprintTools.GetBlueprint<BlueprintWeaponEnchantment>("28a9964d81fedae44bae3ca45710c140");

            var ExcaliburBuff = TTCoreExtensions.CreateBuff("ExcaliburBuff", bp => {
                bp.SetName(IsekaiContext, ExcaliburName);
                bp.SetDescription(ExcaliburDesc);
                bp.m_Icon = Icon_Excalibur;
                bp.AddComponent<BuffEnchantAnyWeapon>(c => {
                    c.m_EnchantmentBlueprint = RadiantEnchantment.ToReference<BlueprintItemEnchantmentReference>();
                    c.Slot = EquipSlotBase.SlotType.PrimaryHand;
                });
                bp.AddComponent<BuffEnchantAnyWeapon>(c => {
                    c.m_EnchantmentBlueprint = HolyEnchantment.ToReference<BlueprintItemEnchantmentReference>();
                    c.Slot = EquipSlotBase.SlotType.PrimaryHand;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.UntypedStackable;
                    c.Stat = StatType.Reach;
                    c.Value = 40;
                });
            });
            var ExcaliburAbility = Helpers.CreateBlueprint<BlueprintAbility>(IsekaiContext, "ExcaliburAbility", bp => {
                bp.SetName(IsekaiContext, ExcaliburName);
                bp.SetDescription(ExcaliburDesc);
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.Actions = ActionFlow.DoSingle<ContextActionApplyBuff>(c => {
                        c.m_Buff = ExcaliburBuff.ToReference<BlueprintBuffReference>();
                        c.DurationValue = new ContextDurationValue() {
                            Rate = DurationRate.Minutes,
                            DiceType = DiceType.Zero,
                            DiceCountValue = 0,
                            BonusValue = Values.CreateContextRankValue(AbilityRankType.Default),
                            m_IsExtendable = true,
                        };
                    });
                });
                bp.AddComponent<SpellComponent>(c => {
                    c.School = SpellSchool.Enchantment;
                });
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.Default;
                    c.m_BaseValueType = ContextRankBaseValueType.CharacterLevel;
                });
                bp.m_Icon = Icon_Excalibur;
                bp.Type = AbilityType.Supernatural;
                bp.Range = AbilityRange.Personal;
                bp.CanTargetFriends = false;
                bp.CanTargetSelf = true;
                bp.EffectOnAlly = AbilityEffectOnUnit.Helpful;
                bp.EffectOnEnemy = AbilityEffectOnUnit.None;
                bp.Animation = UnitAnimationActionCastSpell.CastAnimationStyle.Self;
                bp.ActionType = UnitCommand.CommandType.Standard;
                bp.AvailableMetamagic = Metamagic.Quicken;
                bp.LocalizedDuration = StaticReferences.Strings.Duration.OneMinutePerLevel;
                bp.LocalizedSavingThrow = StaticReferences.Strings.Null;
            });
            var ExcaliburFeature = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "ExcaliburFeature", bp => {
                bp.SetName(IsekaiContext, ExcaliburName);
                bp.SetDescription(ExcaliburDesc);
                bp.m_Icon = Icon_Excalibur;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] {
                        ExcaliburAbility.ToReference<BlueprintUnitFactReference>()
                    };
                });
                bp.AddComponent<PrerequisiteCharacterLevel>(c => {
                    c.Group = Prerequisite.GroupType.Any;
                    c.Level = 10;
                });
            });

            SpecialPowerSelection.AddToSelection(ExcaliburFeature);
        }
    }
}
