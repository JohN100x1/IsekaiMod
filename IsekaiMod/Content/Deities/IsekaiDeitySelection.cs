using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;

namespace IsekaiMod.Content.Deities
{
    internal class IsekaiDeitySelection
    {
        public static void Add()
        {
            // Isekai Background Selection
            var IsekaiDeitySelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>("IsekaiDeitySelection", bp => {
                bp.SetName("Isekai");
                bp.SetDescription("Gods from another world.");
                bp.m_Icon = null;
                bp.m_AllFeatures = new BlueprintFeatureReference[] { }; // Added upon blueprint creation
                bp.Groups = new FeatureGroup[] { FeatureGroup.Deities };
                bp.Group = FeatureGroup.Deities;
            });

            // Add to Deity Selection
            var DeitySelection = Resources.GetBlueprint<BlueprintFeatureSelection>("59e7a76987fe3b547b9cce045f4db3e4");
            DeitySelection.m_AllFeatures = DeitySelection.m_AllFeatures.AddToArray(IsekaiDeitySelection.ToReference<BlueprintFeatureReference>());
        }
    }
}