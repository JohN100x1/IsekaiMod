using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using TabletopTweaks.Core.Utilities;
using UnityEngine;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist {
    static class SecretPowerSelection {
        private static readonly Sprite Icon_SecretPower = AssetLoader.LoadInternal(IsekaiContext, "Features", "ICON_SECRET_POWER.png");
        public static void Add() {
            var OverpoweredAbilitySelectionMastermind = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "OverpoweredAbilitySelectionMastermind");

            var SecretPowerSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "SecretPowerSelection", bp => {
                bp.SetName(IsekaiContext, "Secret Power");
                bp.SetDescription(IsekaiContext, "On the verge of defeat, you were somehow able to draw out your secret power...");
                bp.m_Icon = Icon_SecretPower;
                bp.m_AllFeatures = new BlueprintFeatureReference[] {
                    OverpoweredAbilitySelectionMastermind.ToReference<BlueprintFeatureReference>()
                };
            });
        }
        public static void AddToSelection(BlueprintFeature feature) {
            var SecretPowerSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "SecretPowerSelection");
            SecretPowerSelection.AddToSelection(feature);
        }
    }
}
