using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using TabletopTweaks.Core.Utilities;
using UnityEngine;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.SpecialPower {

    internal class Haggler {
        private static readonly Sprite Icon_Shout = BlueprintTools.GetBlueprint<BlueprintAbility>("f09453607e683784c8fca646eec49162").m_Icon;

        public static void Add() {
            var HagglerDesc = Helpers.CreateString(IsekaiContext, "Haggler.Description", "Vendor prices are reduced by 50%.");
            var Haggler = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "Haggler", bp => {
                bp.SetName(IsekaiContext, "Haggler");
                bp.SetDescription(HagglerDesc);
                bp.m_Icon = Icon_Shout;
                bp.AddComponent<AddVendorDiscount>(c => {
                    c.m_DiscountModifierPercents = 50;
                    c.m_VendorDiscountType = AddVendorDiscount.VendorDiscountEntry.BuyOnly;
                    c.m_ExcludeVendors = new BlueprintUnitReference[0];
                    c.m_ExcludeItems = new BlueprintItemReference[0];
                });
                bp.AddComponent<RecalculateOnChangeParty>(c => {
                    c.m_IsRecalculateIfDeath = true;
                });
            });
            SpecialPowerSelection.AddToSelection(Haggler);
        }
    }
}