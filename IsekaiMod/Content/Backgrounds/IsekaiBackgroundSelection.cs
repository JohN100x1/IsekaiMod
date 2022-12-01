using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;

namespace IsekaiMod.Content.Backgrounds
{
    internal class IsekaiBackgroundSelection
    {
        public static void Add()
        {
            // Isekai Background Selection
            var IsekaiBackgroundSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>("IsekaiBackgroundSelection", bp => {
                bp.SetName("Isekai");
                bp.SetDescription("Before you were hit by a truck, you were a...");
                bp.HideInUI = true;
                bp.Groups = new FeatureGroup[] { FeatureGroup.BackgroundSelection };

                // Register Backgrounds later
                bp.m_AllFeatures = new BlueprintFeatureReference[0];
            });

            // Add Isekai Background Selection to Background Selection
            var BackgroundSelection = Resources.GetBlueprint<BlueprintFeatureSelection>("f926dabeee7f8a54db8f2010b323383c");
            BackgroundSelection.m_AllFeatures = BackgroundSelection.m_AllFeatures.AddToArray(IsekaiBackgroundSelection.ToReference<BlueprintFeatureReference>());
        }
        public static void Register(BlueprintFeature background)
        {
            BlueprintFeatureSelection backgroundSelection = Get();
            backgroundSelection.m_AllFeatures = backgroundSelection.m_AllFeatures.AddToArray(background.ToReference<BlueprintFeatureReference>());
        }
        public static BlueprintFeatureSelection Get()
        {
            return Resources.GetModBlueprint<BlueprintFeatureSelection>("IsekaiBackgroundSelection");
        }
    }
}