using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.GodEmperor {

    internal class GodEmperorEnergySelection {

        public static void Add() {
            var IsekaiChannelPositiveEnergyFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiChannelPositiveEnergyFeature");
            var IsekaiChannelNegativeEnergyFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiChannelNegativeEnergyFeature");

            var GodEmperorEnergySelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "GodEmperorEnergySelection", bp => {
                bp.SetName(IsekaiContext, "Channel Energy");
                bp.SetDescription(IsekaiContext, "At 3rd level, the God Emperor is able to choose between channeling positive energy or negative energy.");
                bp.m_Icon = IsekaiChannelPositiveEnergyFeature.m_Icon;
                bp.m_AllFeatures = new BlueprintFeatureReference[] {
                    IsekaiChannelPositiveEnergyFeature.ToReference<BlueprintFeatureReference>(),
                    IsekaiChannelNegativeEnergyFeature.ToReference<BlueprintFeatureReference>(),
                };
            });
        }
    }
}