using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using TabletopTweaks.Core.Utilities;
using UnityEngine;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.SpecialPower {

    internal class AlphaStrike {
        private static readonly Sprite Icon_SneakStab = BlueprintTools.GetBlueprint<BlueprintFeature>("df4f34f7cac73ab40986bc33f87b1a3c").m_Icon;

        public static void Add() {
            var AlphaStrike = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "AlphaStrike", bp => {
                bp.SetName(IsekaiContext, "Alpha Strike");
                bp.SetDescription(IsekaiContext, "You have become an alpha. Your critical threats are automatically confirmed.");
                bp.m_Icon = Icon_SneakStab;
                bp.AddComponent<InitiatorCritAutoconfirm>();
            });
            SpecialPowerSelection.AddToSelection(AlphaStrike);
        }
    }
}