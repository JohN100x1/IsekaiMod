using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Items.Ecnchantments;
using Kingmaker.UI.GenericSlot;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using UnityEngine;

namespace IsekaiMod.Content.Features.ExceptionalFeats
{
    class ExceptionalWeaponSelection
    {
        private static readonly Sprite Icon_ArcaneWeapon = Resources.GetBlueprint<BlueprintFeature>("3cbe3e308342b3247ba2f4fbaf5e6307").m_Icon;
        private static readonly Sprite Icon_ArcaneWeaponUnholyBuff = Resources.GetBlueprint<BlueprintBuff>("9140db37a973e6543b5906d6da5780f7").m_Icon;
        private static readonly Sprite Icon_ArcaneWeaponFrostBuff = Resources.GetBlueprint<BlueprintBuff>("39f8c2ca61fa4bb419b13813001125ce").m_Icon;
        private static readonly Sprite Icon_ArcaneWeaponShockBuff = Resources.GetBlueprint<BlueprintBuff>("5b76e44a1ed84704e858c38e7e97e7f2").m_Icon;
        private static readonly Sprite Icon_ArcaneWeaponFlamingBuff = Resources.GetBlueprint<BlueprintBuff>("32e17840df49fbd48b835d080f5673a4").m_Icon;
        private static readonly Sprite Icon_ArcaneWeaponKeenBuff = Resources.GetBlueprint<BlueprintBuff>("49083bf0cdd00ec4dacbffb4be26e69a").m_Icon;

        private static readonly BlueprintItemEnchantment Corrosive = Resources.GetBlueprint<BlueprintItemEnchantment>("633b38ff1d11de64a91d490c683ab1c8");
        private static readonly BlueprintItemEnchantment Frost = Resources.GetBlueprint<BlueprintItemEnchantment>("421e54078b7719d40915ce0672511d0b");
        private static readonly BlueprintItemEnchantment Shock = Resources.GetBlueprint<BlueprintItemEnchantment>("7bda5277d36ad114f9f9fd21d0dab658");
        private static readonly BlueprintItemEnchantment Flaming = Resources.GetBlueprint<BlueprintItemEnchantment>("30f90becaaac51f41bf56641966c4121");
        private static readonly BlueprintItemEnchantment Thundering = Resources.GetBlueprint<BlueprintItemEnchantment>("690e762f7704e1f4aa1ac69ef0ce6a96");
        public static void Add()
        {
            var CorrosiveWeaponFeature = Helpers.CreateFeature("CorrosiveWeaponFeature", bp => {
                bp.SetName("Corrosive Weapon");
                bp.SetDescription("Your attacks have Corrosive. They deal an additional 1d6 acid damage.");
                bp.m_Icon = Icon_ArcaneWeaponUnholyBuff;
                bp.AddComponent<BuffEnchantAnyWeapon>(c => {
                    c.m_EnchantmentBlueprint = Corrosive.ToReference<BlueprintItemEnchantmentReference>();
                    c.Slot = EquipSlotBase.SlotType.PrimaryHand;
                });
                bp.AddComponent<BuffEnchantAnyWeapon>(c => {
                    c.m_EnchantmentBlueprint = Corrosive.ToReference<BlueprintItemEnchantmentReference>();
                    c.Slot = EquipSlotBase.SlotType.SecondaryHand;
                });
            });
            var FrostWeaponFeature = Helpers.CreateFeature("FrostWeaponFeature", bp => {
                bp.SetName("Frost Weapon");
                bp.SetDescription("Your attacks have Frost. They deal an additional 1d6 cold damage.");
                bp.m_Icon = Icon_ArcaneWeaponFrostBuff;
                bp.AddComponent<BuffEnchantAnyWeapon>(c => {
                    c.m_EnchantmentBlueprint = Frost.ToReference<BlueprintItemEnchantmentReference>();
                    c.Slot = EquipSlotBase.SlotType.PrimaryHand;
                });
                bp.AddComponent<BuffEnchantAnyWeapon>(c => {
                    c.m_EnchantmentBlueprint = Frost.ToReference<BlueprintItemEnchantmentReference>();
                    c.Slot = EquipSlotBase.SlotType.SecondaryHand;
                });
            });
            var ShockWeaponFeature = Helpers.CreateFeature("ShockWeaponFeature", bp => {
                bp.SetName("Shock Weapon");
                bp.SetDescription("Your attacks have Shock. They deal an additional 1d6 electricity damage.");
                bp.m_Icon = Icon_ArcaneWeaponShockBuff;
                bp.AddComponent<BuffEnchantAnyWeapon>(c => {
                    c.m_EnchantmentBlueprint = Shock.ToReference<BlueprintItemEnchantmentReference>();
                    c.Slot = EquipSlotBase.SlotType.PrimaryHand;
                });
                bp.AddComponent<BuffEnchantAnyWeapon>(c => {
                    c.m_EnchantmentBlueprint = Shock.ToReference<BlueprintItemEnchantmentReference>();
                    c.Slot = EquipSlotBase.SlotType.SecondaryHand;
                });
            });
            var FlamingWeaponFeature = Helpers.CreateFeature("FlamingWeaponFeature", bp => {
                bp.SetName("Flaming Weapon");
                bp.SetDescription("Your attacks have Flaming. They deal an additional 1d6 fire damage.");
                bp.m_Icon = Icon_ArcaneWeaponFlamingBuff;
                bp.AddComponent<BuffEnchantAnyWeapon>(c => {
                    c.m_EnchantmentBlueprint = Flaming.ToReference<BlueprintItemEnchantmentReference>();
                    c.Slot = EquipSlotBase.SlotType.PrimaryHand;
                });
                bp.AddComponent<BuffEnchantAnyWeapon>(c => {
                    c.m_EnchantmentBlueprint = Flaming.ToReference<BlueprintItemEnchantmentReference>();
                    c.Slot = EquipSlotBase.SlotType.SecondaryHand;
                });
            });
            var ThunderingWeaponFeature = Helpers.CreateFeature("ThunderingWeaponFeature", bp => {
                bp.SetName("Thundering Weapon");
                bp.SetDescription("Your attacks have Thundering. They deal an additional 1d6 sonic damage.");
                bp.m_Icon = Icon_ArcaneWeaponKeenBuff;
                bp.AddComponent<BuffEnchantAnyWeapon>(c => {
                    c.m_EnchantmentBlueprint = Thundering.ToReference<BlueprintItemEnchantmentReference>();
                    c.Slot = EquipSlotBase.SlotType.PrimaryHand;
                });
                bp.AddComponent<BuffEnchantAnyWeapon>(c => {
                    c.m_EnchantmentBlueprint = Thundering.ToReference<BlueprintItemEnchantmentReference>();
                    c.Slot = EquipSlotBase.SlotType.SecondaryHand;
                });
            });

            // Elemental Weapon Selection
            var ExceptionalWeaponSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>("ExceptionalWeaponSelection", bp => {
                bp.SetName("Exceptional Weapon");
                bp.SetDescription("Your attacks have an additional enchantment. This enchantment does not stack with existing enchantments on weapons.");
                bp.m_Icon = Icon_ArcaneWeapon;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.m_AllFeatures = new BlueprintFeatureReference[] {
                    CorrosiveWeaponFeature.ToReference<BlueprintFeatureReference>(),
                    FrostWeaponFeature.ToReference<BlueprintFeatureReference>(),
                    ShockWeaponFeature.ToReference<BlueprintFeatureReference>(),
                    FlamingWeaponFeature.ToReference<BlueprintFeatureReference>(),
                    ThunderingWeaponFeature.ToReference<BlueprintFeatureReference>(),
                };
            });
            ExceptionalFeatSelection.AddToSelection(ExceptionalWeaponSelection);
        }
    }
}
