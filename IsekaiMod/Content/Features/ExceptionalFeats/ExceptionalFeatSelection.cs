using HarmonyLib;
using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Designers.Mechanics.Recommendations;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.ExceptionalFeats
{
    class ExceptionalFeatSelection
    {
        private static readonly BlueprintFeatureSelection MythicFeatSelection = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("9ee0f6745f555484299b0a1563b99d81");
        private static readonly BlueprintFeatureSelection ExtraFeatMythicFeat = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("e10c4f18a6c8b4342afe6954bde0587b");
        private static readonly BlueprintFeatureSelection ExtraMythicAbilityMythicFeat = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("8a6a511c55e67d04db328cc49aaad2b8");
        public static void Add()
        {
            // The reason for two copies is to avoid a UI bug when exceptional feats are selected both in feat and bonus feat.
            var ExceptionalFeatSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "ExceptionalFeatSelection", bp => {
                bp.SetName(IsekaiContext, "Exceptional Feats");
                bp.SetDescription(IsekaiContext, "Exceptional feats are feats that no ordinary NPC possess.\nSource: Isekai Mod");
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
            var ExceptionalFeatBonusSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "ExceptionalFeatBonusSelection", bp => {
                bp.SetName(IsekaiContext, "Exceptional Feats");
                bp.SetDescription(IsekaiContext, "Exceptional feats are feats that no ordinary NPC possess.\nSource: Isekai Mod");
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
            var BasicFeatSelection = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("247a4068296e8be42890143f451b4b45");
            BasicFeatSelection.m_AllFeatures = ThingsNotHandledByTTTCore.AddToFirst<BlueprintFeatureReference>(BasicFeatSelection.m_AllFeatures, ExceptionalFeatSelection.ToReference<BlueprintFeatureReference>());
        }
        public static void AddToSelection(BlueprintFeature feature)
        {
            var ExceptionalFeatSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "ExceptionalFeatSelection");
            var ExceptionalFeatBonusSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "ExceptionalFeatBonusSelection");
            ExceptionalFeatSelection.m_AllFeatures = ExceptionalFeatSelection.m_AllFeatures.AddToArray(feature.ToReference<BlueprintFeatureReference>());
            ExceptionalFeatBonusSelection.m_AllFeatures = ExceptionalFeatBonusSelection.m_AllFeatures.AddToArray(feature.ToReference<BlueprintFeatureReference>());
        }
        public static void AddToSelection(BlueprintFeatureSelection selection, BlueprintFeatureSelection bonusSelection)
        {
            var ExceptionalFeatSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "ExceptionalFeatSelection");
            var ExceptionalFeatBonusSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "ExceptionalFeatBonusSelection");
            ExceptionalFeatSelection.m_AllFeatures = ExceptionalFeatSelection.m_AllFeatures.AddToArray(selection.ToReference<BlueprintFeatureReference>());
            ExceptionalFeatBonusSelection.m_AllFeatures = ExceptionalFeatBonusSelection.m_AllFeatures.AddToArray(bonusSelection.ToReference<BlueprintFeatureReference>());
        }
    }
}
