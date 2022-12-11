using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.UnitLogic.FactLogic;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.OverpoweredAbility
{
    class InfiniteInventory
    {
        public static void Add()
        {
            var Icon_InfiniteInventory = AssetLoader.LoadInternal("Features", "ICON_INFINITE_INVENTORY.png");
            var InfiniteInventoryFeature = Helpers.CreateFeature("InfiniteInventoryFeature", bp => {
                bp.SetName("Overpowered Ability — Infinite Inventory");
                bp.SetDescription("You have an infinite carry capacity.");
                bp.m_Icon = Icon_InfiniteInventory;
                bp.AddComponent<AddPartyEncumbrance>(c => {
                    c.Value = 1_000_000;
                });
            });

            OverpoweredAbilitySelection.AddToSelection(InfiniteInventoryFeature);
        }
    }
}
