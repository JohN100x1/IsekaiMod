using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Designers.Mechanics.Recommendations;

namespace IsekaiMod.Content.Features.ExceptionalFeats
{
    class ExceptionalFeatSelection
    {
        private static readonly BlueprintFeatureSelection MythicFeatSelection = Resources.GetBlueprint<BlueprintFeatureSelection>("9ee0f6745f555484299b0a1563b99d81");
        private static readonly BlueprintFeatureSelection ExtraFeatMythicFeat = Resources.GetBlueprint<BlueprintFeatureSelection>("e10c4f18a6c8b4342afe6954bde0587b");
        private static readonly BlueprintFeatureSelection ExtraMythicAbilityMythicFeat = Resources.GetBlueprint<BlueprintFeatureSelection>("8a6a511c55e67d04db328cc49aaad2b8");
        public static void Add()
        {
            // The reason for two copies is to avoid a UI bug when exceptional feats are selected both in feat and bonus feat.
            var ExceptionalFeatSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>("ExceptionalFeatSelection", bp => {
                bp.SetName("Exceptional Feats");
                bp.SetDescription("Exceptional feats are feats that no ordinary NPC possess.\nSource: Isekai Mod");
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.AddComponent<PureRecommendation>(c => {
                    c.Priority = RecommendationPriority.Good;
                });

                // Add more Exceptional feats later
                bp.m_AllFeatures = MythicFeatSelection.m_AllFeatures
                    .RemoveFromArray(ExtraFeatMythicFeat.ToReference<BlueprintFeatureReference>())
                    .RemoveFromArray(ExtraMythicAbilityMythicFeat.ToReference<BlueprintFeatureReference>());
            });
            var ExceptionalFeatBonusSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>("ExceptionalFeatBonusSelection", bp => {
                bp.SetName("Exceptional Feats");
                bp.SetDescription("Exceptional feats are feats that no ordinary NPC possess.\nSource: Isekai Mod");
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.AddComponent<PureRecommendation>(c => {
                    c.Priority = RecommendationPriority.Good;
                });

                // Add more Exceptional feats later
                bp.m_AllFeatures = MythicFeatSelection.m_AllFeatures
                    .RemoveFromArray(ExtraFeatMythicFeat.ToReference<BlueprintFeatureReference>())
                    .RemoveFromArray(ExtraMythicAbilityMythicFeat.ToReference<BlueprintFeatureReference>());
            });

            // Add to Basic Feat Selection
            var BasicFeatSelection = Resources.GetBlueprint<BlueprintFeatureSelection>("247a4068296e8be42890143f451b4b45");
            BasicFeatSelection.m_AllFeatures = BasicFeatSelection.m_AllFeatures.AddToFirst(ExceptionalFeatSelection.ToReference<BlueprintFeatureReference>());
        }
        public static void AddToSelection(BlueprintFeature feature)
        {
            var ExceptionalFeatSelection = Resources.GetModBlueprint<BlueprintFeatureSelection>("ExceptionalFeatSelection");
            var ExceptionalFeatBonusSelection = Resources.GetModBlueprint<BlueprintFeatureSelection>("ExceptionalFeatBonusSelection");
            ExceptionalFeatSelection.m_AllFeatures = ExceptionalFeatSelection.m_AllFeatures.AddToArray(feature.ToReference<BlueprintFeatureReference>());
            ExceptionalFeatBonusSelection.m_AllFeatures = ExceptionalFeatBonusSelection.m_AllFeatures.AddToArray(feature.ToReference<BlueprintFeatureReference>());
        }
        public static void AddToSelection(BlueprintFeatureSelection selection, BlueprintFeatureSelection bonusSelection)
        {
            var ExceptionalFeatSelection = Resources.GetModBlueprint<BlueprintFeatureSelection>("ExceptionalFeatSelection");
            var ExceptionalFeatBonusSelection = Resources.GetModBlueprint<BlueprintFeatureSelection>("ExceptionalFeatBonusSelection");
            ExceptionalFeatSelection.m_AllFeatures = ExceptionalFeatSelection.m_AllFeatures.AddToArray(selection.ToReference<BlueprintFeatureReference>());
            ExceptionalFeatBonusSelection.m_AllFeatures = ExceptionalFeatBonusSelection.m_AllFeatures.AddToArray(bonusSelection.ToReference<BlueprintFeatureReference>());
        }
    }
}
