﻿using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Backgrounds {

    internal class IsekaiBackgroundSelection {

        public static void Add() {
            var IsekaiBackgroundSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "IsekaiBackgroundSelection", bp => {
                bp.SetName(IsekaiContext, "Isekai");
                bp.SetDescription(IsekaiContext, "Before you were hit by a truck, you were a...");
                bp.HideInUI = true;
                bp.Groups = new FeatureGroup[] { FeatureGroup.BackgroundSelection };

                // Register Backgrounds later
                bp.m_AllFeatures = new BlueprintFeatureReference[0];
            });

            FeatTools.Selections.BackgroundsBaseSelection.AddToSelection(IsekaiBackgroundSelection);
        }

        public static void AddToSelection(BlueprintFeature background) {
            var backgroundSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "IsekaiBackgroundSelection");
            backgroundSelection.AddToSelection(background);
        }
    }
}