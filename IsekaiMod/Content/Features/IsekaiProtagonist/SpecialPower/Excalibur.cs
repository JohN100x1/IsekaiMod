using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Ecnchantments;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.Localization;
using Kingmaker.UI.GenericSlot;
using Kingmaker.UnitLogic.FactLogic;
using TabletopTweaks.Core.Utilities;
using UnityEngine;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.SpecialPower {
    internal class Excalibur {
        public static void Add() {
            LocalizedString ExcaliburDesc = Helpers.CreateString(IsekaiContext, "Excalibur.Description",
                "Your primary weapon gains the holy and radiant enchantments. Your attack range is increased by 40 feet.");
            Sprite Icon_Excalibur = AssetLoader.LoadInternal(IsekaiContext, "Features", "ICON_EXCALIBUR.png");

            var RadiantEnchantment = BlueprintTools.GetBlueprint<BlueprintWeaponEnchantment>("5ac5c88157f7dde48a2a5b24caf40131");
            var HolyEnchantment = BlueprintTools.GetBlueprint<BlueprintWeaponEnchantment>("28a9964d81fedae44bae3ca45710c140");

            var ExcaliburFeature = TTCoreExtensions.CreateToggleBuffFeature(
                name: "Excalibur",
                description: ExcaliburDesc,
                icon: Icon_Excalibur,
                buffEffect: bp => {
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

            SpecialPowerSelection.AddToSelection(ExcaliburFeature);
        }
    }
}
