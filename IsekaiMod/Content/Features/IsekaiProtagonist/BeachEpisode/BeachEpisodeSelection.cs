using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.BeachEpisode
{
    class BeachEpisodeSelection
    {
        public static void Add()
        {
            // Beach Episode
            var HealthyBody = Resources.GetModBlueprint<BlueprintFeature>("HealthyBody");
            var InnerPower = Resources.GetModBlueprint<BlueprintFeature>("InnerPower");
            var MasterSelf = Resources.GetModBlueprint<BlueprintFeature>("MasterSelf");
            var Unstoppable = Resources.GetModBlueprint<BlueprintFeature>("Unstoppable");

            // Feature
            var Icon_BeachEpisode = AssetLoader.LoadInternal("Features", "ICON_BEACH.png");
            var BeachEpisodeSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>("BeachEpisodeSelection", bp => {
                bp.SetName("Beach Episode");
                bp.SetDescription("At 12th level, you and your companions take a short intermission beside a large body of water. During this time, you begin a journey of self discovery.");
                bp.m_Icon = Icon_BeachEpisode;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.m_AllFeatures = new BlueprintFeatureReference[] {
                    HealthyBody.ToReference<BlueprintFeatureReference>(),
                    InnerPower.ToReference<BlueprintFeatureReference>(),
                    MasterSelf.ToReference<BlueprintFeatureReference>(),
                    Unstoppable.ToReference<BlueprintFeatureReference>(),
                };
                bp.m_Features = new BlueprintFeatureReference[] {
                    HealthyBody.ToReference<BlueprintFeatureReference>(),
                    InnerPower.ToReference<BlueprintFeatureReference>(),
                    MasterSelf.ToReference<BlueprintFeatureReference>(),
                    Unstoppable.ToReference<BlueprintFeatureReference>(),
                };
            });
        }
    }
}
