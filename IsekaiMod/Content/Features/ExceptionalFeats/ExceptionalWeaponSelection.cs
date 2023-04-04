using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Items.Ecnchantments;
using Kingmaker.UI.GenericSlot;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using TabletopTweaks.Core.Utilities;
using UnityEngine;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.ExceptionalFeats {

    internal class ExceptionalWeaponSelection {
        private static readonly Sprite Icon_ArcaneWeapon = BlueprintTools.GetBlueprint<BlueprintFeature>("3cbe3e308342b3247ba2f4fbaf5e6307").m_Icon;
        private static readonly Sprite Icon_ArcaneWeaponUnholyBuff = BlueprintTools.GetBlueprint<BlueprintBuff>("9140db37a973e6543b5906d6da5780f7").m_Icon;
        private static readonly Sprite Icon_ArcaneWeaponFrostBuff = BlueprintTools.GetBlueprint<BlueprintBuff>("39f8c2ca61fa4bb419b13813001125ce").m_Icon;
        private static readonly Sprite Icon_ArcaneWeaponShockBuff = BlueprintTools.GetBlueprint<BlueprintBuff>("5b76e44a1ed84704e858c38e7e97e7f2").m_Icon;
        private static readonly Sprite Icon_ArcaneWeaponFlamingBuff = BlueprintTools.GetBlueprint<BlueprintBuff>("32e17840df49fbd48b835d080f5673a4").m_Icon;
        private static readonly Sprite Icon_ArcaneWeaponKeenBuff = BlueprintTools.GetBlueprint<BlueprintBuff>("49083bf0cdd00ec4dacbffb4be26e69a").m_Icon;

        private static readonly BlueprintItemEnchantment Corrosive = BlueprintTools.GetBlueprint<BlueprintItemEnchantment>("633b38ff1d11de64a91d490c683ab1c8");
        private static readonly BlueprintItemEnchantment Frost = BlueprintTools.GetBlueprint<BlueprintItemEnchantment>("421e54078b7719d40915ce0672511d0b");
        private static readonly BlueprintItemEnchantment Shock = BlueprintTools.GetBlueprint<BlueprintItemEnchantment>("7bda5277d36ad114f9f9fd21d0dab658");
        private static readonly BlueprintItemEnchantment Flaming = BlueprintTools.GetBlueprint<BlueprintItemEnchantment>("30f90becaaac51f41bf56641966c4121");
        private static readonly BlueprintItemEnchantment Thundering = BlueprintTools.GetBlueprint<BlueprintItemEnchantment>("690e762f7704e1f4aa1ac69ef0ce6a96");

        public static void Add() {
            var CorrosiveWeaponBuff = TTCoreExtensions.CreateBuff("CorrosiveWeaponBuff", bp => {
                bp.SetName(IsekaiContext, "Corrosive Weapon");
                bp.SetDescription(IsekaiContext, "Your attacks have Corrosive. They deal an additional 1d6 acid damage.");
                bp.m_Icon = Icon_ArcaneWeaponUnholyBuff;
                bp.AddComponent<BuffEnchantAnyWeapon>(c => {
                    c.m_EnchantmentBlueprint = Corrosive.ToReference<BlueprintItemEnchantmentReference>();
                    c.Slot = EquipSlotBase.SlotType.PrimaryHand;
                });
                bp.AddComponent<BuffEnchantAnyWeapon>(c => {
                    c.m_EnchantmentBlueprint = Corrosive.ToReference<BlueprintItemEnchantmentReference>();
                    c.Slot = EquipSlotBase.SlotType.SecondaryHand;
                });
                bp.AddComponent<BuffEnchantAnyWeapon>(c => {
                    c.m_EnchantmentBlueprint = Corrosive.ToReference<BlueprintItemEnchantmentReference>();
                    c.Slot = EquipSlotBase.SlotType.AdditionalLimb;
                });
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.HiddenInUi;
            });
            var CorrosiveWeaponAbility = TTCoreExtensions.CreateActivatableAbility("CorrosiveWeaponAbility", bp => {
                bp.SetName(IsekaiContext, "Corrosive Weapon");
                bp.SetDescription(IsekaiContext, "Your attacks have Corrosive. They deal an additional 1d6 acid damage.");
                bp.m_Icon = Icon_ArcaneWeaponUnholyBuff;
                bp.m_Buff = CorrosiveWeaponBuff.ToReference<BlueprintBuffReference>();
            });
            var CorrosiveWeaponFeature = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "CorrosiveWeaponFeature", bp => {
                bp.SetName(IsekaiContext, "Corrosive Weapon");
                bp.SetDescription(IsekaiContext, "Your attacks have Corrosive. They deal an additional 1d6 acid damage.");
                bp.m_Icon = Icon_ArcaneWeaponUnholyBuff;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] {
                        CorrosiveWeaponAbility.ToReference<BlueprintUnitFactReference>()
                    };
                });
            });
            var FrostWeaponBuff = TTCoreExtensions.CreateBuff("FrostWeaponBuff", bp => {
                bp.SetName(IsekaiContext, "Frost Weapon");
                bp.SetDescription(IsekaiContext, "Your attacks have Frost. They deal an additional 1d6 cold damage.");
                bp.m_Icon = Icon_ArcaneWeaponFrostBuff;
                bp.AddComponent<BuffEnchantAnyWeapon>(c => {
                    c.m_EnchantmentBlueprint = Frost.ToReference<BlueprintItemEnchantmentReference>();
                    c.Slot = EquipSlotBase.SlotType.PrimaryHand;
                });
                bp.AddComponent<BuffEnchantAnyWeapon>(c => {
                    c.m_EnchantmentBlueprint = Frost.ToReference<BlueprintItemEnchantmentReference>();
                    c.Slot = EquipSlotBase.SlotType.SecondaryHand;
                });
                bp.AddComponent<BuffEnchantAnyWeapon>(c => {
                    c.m_EnchantmentBlueprint = Frost.ToReference<BlueprintItemEnchantmentReference>();
                    c.Slot = EquipSlotBase.SlotType.AdditionalLimb;
                });
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.HiddenInUi;
            });
            var FrostWeaponAbility = TTCoreExtensions.CreateActivatableAbility("FrostWeaponAbility", bp => {
                bp.SetName(IsekaiContext, "Frost Weapon");
                bp.SetDescription(IsekaiContext, "Your attacks have Frost. They deal an additional 1d6 cold damage.");
                bp.m_Icon = Icon_ArcaneWeaponFrostBuff;
                bp.m_Buff = FrostWeaponBuff.ToReference<BlueprintBuffReference>();
            });
            var FrostWeaponFeature = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "FrostWeaponFeature", bp => {
                bp.SetName(IsekaiContext, "Frost Weapon");
                bp.SetDescription(IsekaiContext, "Your attacks have Frost. They deal an additional 1d6 cold damage.");
                bp.m_Icon = Icon_ArcaneWeaponFrostBuff;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] {
                        FrostWeaponAbility.ToReference<BlueprintUnitFactReference>()
                    };
                });
            });
            var ShockWeaponBuff = TTCoreExtensions.CreateBuff("ShockWeaponBuff", bp => {
                bp.SetName(IsekaiContext, "Shock Weapon");
                bp.SetDescription(IsekaiContext, "Your attacks have Shock. They deal an additional 1d6 electricity damage.");
                bp.m_Icon = Icon_ArcaneWeaponShockBuff;
                bp.AddComponent<BuffEnchantAnyWeapon>(c => {
                    c.m_EnchantmentBlueprint = Shock.ToReference<BlueprintItemEnchantmentReference>();
                    c.Slot = EquipSlotBase.SlotType.PrimaryHand;
                });
                bp.AddComponent<BuffEnchantAnyWeapon>(c => {
                    c.m_EnchantmentBlueprint = Shock.ToReference<BlueprintItemEnchantmentReference>();
                    c.Slot = EquipSlotBase.SlotType.SecondaryHand;
                });
                bp.AddComponent<BuffEnchantAnyWeapon>(c => {
                    c.m_EnchantmentBlueprint = Shock.ToReference<BlueprintItemEnchantmentReference>();
                    c.Slot = EquipSlotBase.SlotType.AdditionalLimb;
                });
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.HiddenInUi;
            });
            var ShockWeaponAbility = TTCoreExtensions.CreateActivatableAbility("ShockWeaponAbility", bp => {
                bp.SetName(IsekaiContext, "Shock Weapon");
                bp.SetDescription(IsekaiContext, "Your attacks have Shock. They deal an additional 1d6 electricity damage.");
                bp.m_Icon = Icon_ArcaneWeaponShockBuff;
                bp.m_Buff = ShockWeaponBuff.ToReference<BlueprintBuffReference>();
            });
            var ShockWeaponFeature = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "ShockWeaponFeature", bp => {
                bp.SetName(IsekaiContext, "Shock Weapon");
                bp.SetDescription(IsekaiContext, "Your attacks have Shock. They deal an additional 1d6 electricity damage.");
                bp.m_Icon = Icon_ArcaneWeaponShockBuff;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] {
                        ShockWeaponAbility.ToReference<BlueprintUnitFactReference>()
                    };
                });
            });
            var FlamingWeaponBuff = TTCoreExtensions.CreateBuff("FlamingWeaponBuff", bp => {
                bp.SetName(IsekaiContext, "Flaming Weapon");
                bp.SetDescription(IsekaiContext, "Your attacks have Flaming. They deal an additional 1d6 fire damage.");
                bp.m_Icon = Icon_ArcaneWeaponFlamingBuff;
                bp.AddComponent<BuffEnchantAnyWeapon>(c => {
                    c.m_EnchantmentBlueprint = Flaming.ToReference<BlueprintItemEnchantmentReference>();
                    c.Slot = EquipSlotBase.SlotType.PrimaryHand;
                });
                bp.AddComponent<BuffEnchantAnyWeapon>(c => {
                    c.m_EnchantmentBlueprint = Flaming.ToReference<BlueprintItemEnchantmentReference>();
                    c.Slot = EquipSlotBase.SlotType.SecondaryHand;
                });
                bp.AddComponent<BuffEnchantAnyWeapon>(c => {
                    c.m_EnchantmentBlueprint = Flaming.ToReference<BlueprintItemEnchantmentReference>();
                    c.Slot = EquipSlotBase.SlotType.AdditionalLimb;
                });
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.HiddenInUi;
            });
            var FlamingWeaponAbility = TTCoreExtensions.CreateActivatableAbility("FlamingWeaponAbility", bp => {
                bp.SetName(IsekaiContext, "Flaming Weapon");
                bp.SetDescription(IsekaiContext, "Your attacks have Flaming. They deal an additional 1d6 fire damage.");
                bp.m_Icon = Icon_ArcaneWeaponFlamingBuff;
                bp.m_Buff = FlamingWeaponBuff.ToReference<BlueprintBuffReference>();
            });
            var FlamingWeaponFeature = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "FlamingWeaponFeature", bp => {
                bp.SetName(IsekaiContext, "Flaming Weapon");
                bp.SetDescription(IsekaiContext, "Your attacks have Flaming. They deal an additional 1d6 fire damage.");
                bp.m_Icon = Icon_ArcaneWeaponFlamingBuff;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] {
                        FlamingWeaponAbility.ToReference<BlueprintUnitFactReference>()
                    };
                });
            });
            var ThunderingWeaponBuff = TTCoreExtensions.CreateBuff("ThunderingWeaponBuff", bp => {
                bp.SetName(IsekaiContext, "Thundering Weapon");
                bp.SetDescription(IsekaiContext, "Your attacks have Thundering. They deal an additional 1d6 sonic damage.");
                bp.m_Icon = Icon_ArcaneWeaponKeenBuff;
                bp.AddComponent<BuffEnchantAnyWeapon>(c => {
                    c.m_EnchantmentBlueprint = Thundering.ToReference<BlueprintItemEnchantmentReference>();
                    c.Slot = EquipSlotBase.SlotType.PrimaryHand;
                });
                bp.AddComponent<BuffEnchantAnyWeapon>(c => {
                    c.m_EnchantmentBlueprint = Thundering.ToReference<BlueprintItemEnchantmentReference>();
                    c.Slot = EquipSlotBase.SlotType.SecondaryHand;
                });
                bp.AddComponent<BuffEnchantAnyWeapon>(c => {
                    c.m_EnchantmentBlueprint = Thundering.ToReference<BlueprintItemEnchantmentReference>();
                    c.Slot = EquipSlotBase.SlotType.AdditionalLimb;
                });
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.HiddenInUi;
            });
            var ThunderingWeaponAbility = TTCoreExtensions.CreateActivatableAbility("ThunderingWeaponAbility", bp => {
                bp.SetName(IsekaiContext, "Thundering Weapon");
                bp.SetDescription(IsekaiContext, "Your attacks have Thundering. They deal an additional 1d6 sonic damage.");
                bp.m_Icon = Icon_ArcaneWeaponKeenBuff;
                bp.m_Buff = ThunderingWeaponBuff.ToReference<BlueprintBuffReference>();
            });
            var ThunderingWeaponFeature = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "ThunderingWeaponFeature", bp => {
                bp.SetName(IsekaiContext, "Thundering Weapon");
                bp.SetDescription(IsekaiContext, "Your attacks have Thundering. They deal an additional 1d6 sonic damage.");
                bp.m_Icon = Icon_ArcaneWeaponKeenBuff;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] {
                        ThunderingWeaponAbility.ToReference<BlueprintUnitFactReference>()
                    };
                });
            });

            var ExceptionalWeaponFeatures = new BlueprintFeatureReference[] {
                CorrosiveWeaponFeature.ToReference<BlueprintFeatureReference>(),
                FrostWeaponFeature.ToReference<BlueprintFeatureReference>(),
                ShockWeaponFeature.ToReference<BlueprintFeatureReference>(),
                FlamingWeaponFeature.ToReference<BlueprintFeatureReference>(),
                ThunderingWeaponFeature.ToReference<BlueprintFeatureReference>(),
            };

            // Exceptional Weapon Selection
            var ExceptionalWeaponSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "ExceptionalWeaponSelection", bp => {
                bp.SetName(IsekaiContext, "Exceptional Weapon");
                bp.SetDescription(IsekaiContext, "Your attacks have an additional enchantment. This enchantment does not stack with existing enchantments on weapons.");
                bp.m_Icon = Icon_ArcaneWeapon;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.m_AllFeatures = ExceptionalWeaponFeatures;
            });
            var ExceptionalWeaponBonusSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "ExceptionalWeaponBonusSelection", bp => {
                bp.SetName(IsekaiContext, "Exceptional Weapon");
                bp.SetDescription(IsekaiContext, "Your attacks have an additional enchantment. This enchantment does not stack with existing enchantments on weapons.");
                bp.m_Icon = Icon_ArcaneWeapon;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.m_AllFeatures = ExceptionalWeaponFeatures;
            });
            ExceptionalFeatSelection.AddToSelection(ExceptionalWeaponSelection, ExceptionalWeaponBonusSelection);
        }
    }
}