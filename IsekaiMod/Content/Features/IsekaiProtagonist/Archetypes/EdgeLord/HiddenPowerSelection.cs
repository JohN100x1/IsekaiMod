using IsekaiMod.Content.Features.IsekaiProtagonist.SpecialPower;
using Kingmaker.Blueprints.Classes.Selection;
using TabletopTweaks.Core.Utilities;
using UnityEngine;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.EdgeLord {

    static class HiddenPowerSelection {
        private static readonly Sprite Icon_SecretPower = AssetLoader.LoadInternal(IsekaiContext, "Features", "ICON_SECRET_POWER.png");
        public static void Add() {
            var HiddenPowerSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "HiddenPowerSelection", bp => {
                bp.SetName(IsekaiContext, "Hidden Power");
                bp.SetDescription(IsekaiContext, "On the verge of defeat, you were somehow able to draw out your hidden power."
                    + "\nYou gain an additional Special Power.");
                bp.m_Icon = Icon_SecretPower;
                bp.m_AllFeatures = SpecialPowerSelection.Get().m_AllFeatures;
            });
        }
    }
}