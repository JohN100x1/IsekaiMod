using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;

namespace IsekaiMod.Changes.Backgrounds
{
    internal class BackgroundSelectionFeature
    {

        public static void PatchBackgroundSelection()
        {

            //Black Rose Backgrounds
            var BlackRoseMatriarch = Resources.GetModBlueprint<BlueprintFeature>("BackgroundBlackRoseMatriarch");

            // Edit Background Selection
            var BackgroundSelection = Resources.GetBlueprint<BlueprintFeatureSelection>("f926dabeee7f8a54db8f2010b323383c");
            var ICON_BR = AssetLoader.LoadInternal("Backgrounds", "ICON_BLACK_ROSE.png");
            var BlackRoseBackgroundSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>("BlackRoseBackgroundSelection", bp => {
                bp.SetName("Black Roses");
                bp.SetDescription("You are a member of The Black Roses, an evil syndicate of powerful women plotting to take over Golarion.");
                bp.m_Icon = ICON_BR;
                bp.HideInUI = true;
                bp.m_AllFeatures = new BlueprintFeatureReference[] { BlackRoseMatriarch.ToReference<BlueprintFeatureReference>() };
                bp.Groups = new FeatureGroup[] { FeatureGroup.BackgroundSelection };
            });

            BackgroundSelection.m_AllFeatures = BackgroundSelection.m_AllFeatures.AddToArray(BlackRoseBackgroundSelection.ToReference<BlueprintFeatureReference>());
        }
    }
}