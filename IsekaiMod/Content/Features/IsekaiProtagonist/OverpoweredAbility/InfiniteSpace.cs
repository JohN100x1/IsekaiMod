using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.UnitLogic.FactLogic;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.OverpoweredAbility
{
    class InfiniteSpace
    {
        public static void Add()
        {
            var Icon_InfiniteSpace = AssetLoader.LoadInternal("Features", "ICON_INFINITE_SPACE.png");
            var InfiniteSpaceFeature = Helpers.CreateFeature("InfiniteSpaceFeature", bp => {
                bp.SetName("Overpowered Ability — Infinite Space");
                bp.SetDescription("You have an infinite carry capacity.");
                bp.m_Icon = Icon_InfiniteSpace;
                bp.AddComponent<AddPartyEncumbrance>(c => {
                    c.Value = 1_000_000;
                });
            });

            OverpoweredAbilitySelection.AddToSelection(InfiniteSpaceFeature);
        }
    }
}
