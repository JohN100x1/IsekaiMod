using Kingmaker.Blueprints.Classes;
using Kingmaker.UnitLogic.FactLogic;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.OverpoweredAbility {

    internal class InfiniteSpace {

        public static void Add() {
            var Icon_InfiniteSpace = AssetLoader.LoadInternal(IsekaiContext, "Features", "ICON_INFINITE_SPACE.png");
            var InfiniteSpaceFeature = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "InfiniteSpaceFeature", bp => {
                bp.SetName(IsekaiContext, "Overpowered Ability — Infinite Space");
                bp.SetDescription(IsekaiContext, "You have an infinite carry capacity.");
                bp.m_Icon = Icon_InfiniteSpace;
                bp.AddComponent<AddPartyEncumbrance>(c => {
                    c.Value = 1_000_000;
                });
            });

            OverpoweredAbilitySelection.AddToSelection(InfiniteSpaceFeature);
        }
    }
}