using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist {

    internal class IsekaiBonusFeatSelection {
        private static readonly BlueprintFeatureSelection BasicFeatSelection = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("247a4068296e8be42890143f451b4b45");

        public static void Add() {
            var IsekaiBonusFeatSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "IsekaiBonusFeatSelection", bp => {
                bp.SetName(IsekaiContext, "Bonus Feat");
                bp.SetDescription(IsekaiContext, "At 1st level, and at every even level thereafter, you gain a bonus {g|Encyclopedia:Feat}feat{/g} in addition to those gained from normal advancement.");
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.Group = FeatureGroup.Feat;
                bp.Group2 = FeatureGroup.TricksterFeat;
                bp.m_AllFeatures = BasicFeatSelection.m_AllFeatures;
            });
            PatchExceptionalFeatSelection(IsekaiBonusFeatSelection);
        }

        private static void PatchExceptionalFeatSelection(BlueprintFeatureSelection blueprintFeatureSelection) {
            var ExceptionalFeatSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "ExceptionalFeatSelection");
            var ExceptionalFeatBonusSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "ExceptionalFeatBonusSelection");
            if (ExceptionalFeatSelection != null && ExceptionalFeatBonusSelection != null) {
                blueprintFeatureSelection.RemoveFromSelection(ExceptionalFeatSelection);
                blueprintFeatureSelection.AddToFirst(ExceptionalFeatBonusSelection);
            }
        }
    }
}