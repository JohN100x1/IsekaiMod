using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Items.Ecnchantments;
using Kingmaker.Localization;
using Kingmaker.UI.GenericSlot;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using System.Linq;
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

            var ExceptionalWeaponFeatures = new BlueprintFeatureReference[] {
                CreateExceptionalWeapon("CorrosiveWeapon", "Your attacks have Corrosive. They deal an additional 1d6 acid damage.", Icon_ArcaneWeaponUnholyBuff, Corrosive),
                CreateExceptionalWeapon("FrostWeapon", "Your attacks have Frost. They deal an additional 1d6 cold damage.", Icon_ArcaneWeaponFrostBuff, Frost),
                CreateExceptionalWeapon("ShockWeapon", "Your attacks have Shock. They deal an additional 1d6 electricity damage.", Icon_ArcaneWeaponShockBuff, Shock),
                CreateExceptionalWeapon("FlamingWeapon", "Your attacks have Flaming. They deal an additional 1d6 fire damage.", Icon_ArcaneWeaponFlamingBuff, Flaming),
                CreateExceptionalWeapon("ThunderingWeapon", "Your attacks have Thundering. They deal an additional 1d6 sonic damage.", Icon_ArcaneWeaponKeenBuff, Thundering),
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
        private static BlueprintFeatureReference CreateExceptionalWeapon(string name, string description, Sprite icon, BlueprintItemEnchantment enchantment) {
            var feature = TTCoreExtensions.CreateToggleBuff(name, description, icon, bp => {
                bp.AddComponent<BuffEnchantAnyWeapon>(c => {
                    c.m_EnchantmentBlueprint = enchantment.ToReference<BlueprintItemEnchantmentReference>();
                    c.Slot = EquipSlotBase.SlotType.PrimaryHand;
                });
                bp.AddComponent<BuffEnchantAnyWeapon>(c => {
                    c.m_EnchantmentBlueprint = enchantment.ToReference<BlueprintItemEnchantmentReference>();
                    c.Slot = EquipSlotBase.SlotType.SecondaryHand;
                });
                bp.m_Flags = BlueprintBuff.Flags.HiddenInUi;
            });
            return feature.ToReference<BlueprintFeatureReference>();
        }
    }
}