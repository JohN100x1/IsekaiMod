using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;

namespace IsekaiMod.Content.Features.ExceptionalFeats
{
    class ExceptionalFeatSelection
    {
        public static void Add()
        {
            var BasicFeatSelection = Resources.GetBlueprint<BlueprintFeatureSelection>("247a4068296e8be42890143f451b4b45");
            var ExceptionalFeatSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>("ExceptionalFeatSelection", bp => {
                bp.SetName("Exceptional Feats");
                bp.SetDescription("Exceptional feats are feats that no ordinary NPC possess.\nSource: Isekai Mod");
                bp.m_Icon = null;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.Group = FeatureGroup.Feat;
                bp.Group2 = FeatureGroup.TricksterFeat;

                // Add Exceptional feats later
                bp.m_AllFeatures = new BlueprintFeatureReference[0];
            });

            // Add to Basic Feat Selection
            BasicFeatSelection.m_AllFeatures = BasicFeatSelection.m_AllFeatures.AddToFirst(ExceptionalFeatSelection.ToReference<BlueprintFeatureReference>());
        }
        public static void AddToSelection(BlueprintFeature feature)
        {
            var ExceptionalFeatSelection = Resources.GetModBlueprint<BlueprintFeatureSelection>("ExceptionalFeatSelection");
            ExceptionalFeatSelection.m_AllFeatures = ExceptionalFeatSelection.m_AllFeatures.AddToArray(feature.ToReference<BlueprintFeatureReference>());
        }
    }
}
