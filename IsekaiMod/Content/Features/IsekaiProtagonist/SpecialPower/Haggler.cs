using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using TabletopTweaks.Core.Utilities;
using UnityEngine;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.SpecialPower {

    internal class Haggler {
        private static readonly Sprite Icon_Shout = BlueprintTools.GetBlueprint<BlueprintAbility>("f09453607e683784c8fca646eec49162").m_Icon;

        public static void Add() {
            var Haggler = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "Haggler", bp => {
                bp.SetName(IsekaiContext, "Haggler");
                bp.SetDescription(IsekaiContext, "Vendor prices are reduced by 50%.");
                bp.m_Icon = Icon_Shout;
                bp.AddComponent<AddVendorDiscount>(c => {
                    c.m_DiscountModifierPercents = 50;
                    c.m_VendorDiscountType = AddVendorDiscount.VendorDiscountEntry.BuyOnly;
                    c.m_ExcludeVendors = new BlueprintUnitReference[0];
                    c.m_ExcludeItems = new BlueprintItemReference[0];
                });
            });
            SpecialPowerSelection.AddToSelection(Haggler);
        }
    }
}