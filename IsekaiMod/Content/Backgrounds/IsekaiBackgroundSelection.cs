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
            //Isekai Backgrounds
            var BackgroundTabletopRPGPlayer = Resources.GetModBlueprint<BlueprintFeature>("BackgroundTabletopRPGPlayer");
            var BackgroundMartialArtist = Resources.GetModBlueprint<BlueprintFeature>("BackgroundMartialArtist");
            var BackgroundSalaryman = Resources.GetModBlueprint<BlueprintFeature>("BackgroundSalaryman");

            // Isekai Background Selection
            var IsekaiBackgroundSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>("IsekaiBackgroundSelection", bp => {
                bp.SetName("Isekai");
                bp.SetDescription("Before you were hit by a truck, you were a...");
                bp.m_Icon = null;
                bp.HideInUI = true;
                bp.m_AllFeatures = new BlueprintFeatureReference[] {
                    BackgroundTabletopRPGPlayer.ToReference<BlueprintFeatureReference>(),
                    BackgroundMartialArtist.ToReference<BlueprintFeatureReference>(),
                    BackgroundSalaryman.ToReference<BlueprintFeatureReference>(),
                };
                bp.Groups = new FeatureGroup[] { FeatureGroup.BackgroundSelection };
            });

            // Add to Background Selection
            var BackgroundSelection = Resources.GetBlueprint<BlueprintFeatureSelection>("f926dabeee7f8a54db8f2010b323383c");
            BackgroundSelection.m_AllFeatures = BackgroundSelection.m_AllFeatures.AddToArray(IsekaiBackgroundSelection.ToReference<BlueprintFeatureReference>());
        }
    }
}