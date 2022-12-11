using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.GodEmperor
{
    class GodEmperorEnergySelection
    {
        public static void Add()
        {
            var IsekaiChannelPositiveEnergyFeature = Resources.GetModBlueprint<BlueprintFeature>("IsekaiChannelPositiveEnergyFeature");
            var IsekaiChannelNegativeEnergyFeature = Resources.GetModBlueprint<BlueprintFeature>("IsekaiChannelNegativeEnergyFeature");

            var GodEmperorEnergySelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>("GodEmperorEnergySelection", bp => {
                bp.SetName("Channel Energy");
                bp.SetDescription("At 5th level, the God Emperor is able to choose between channeling positive energy or negative energy.");
                bp.m_Icon = IsekaiChannelPositiveEnergyFeature.m_Icon;
                bp.IgnorePrerequisites = true;
                bp.m_AllFeatures = new BlueprintFeatureReference[] {
                    IsekaiChannelPositiveEnergyFeature.ToReference<BlueprintFeatureReference>(),
                    IsekaiChannelNegativeEnergyFeature.ToReference<BlueprintFeatureReference>(),
                };
            });
        }
    }
}
