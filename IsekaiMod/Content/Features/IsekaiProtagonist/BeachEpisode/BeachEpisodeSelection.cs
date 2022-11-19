using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using UnityEngine;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.BeachEpisode
{
    class BeachEpisodeSelection
    {
        private static readonly Sprite Icon_BeachEpisode = Resources.GetBlueprint<BlueprintAbility>("4e2e066dd4dc8de4d8281ed5b3f4acb6").m_Icon;
        public static void Add()
        {
            var BeachEpisodeSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>("BeachEpisodeSelection", bp => {
                bp.SetName("Beach Episode");
                bp.SetDescription("At 12th level, you and your companions take a short intermission beside a large body of water. During this time, you begin a journey of self discovery.");
                bp.m_Icon = Icon_BeachEpisode;
                bp.Ranks = 1;
                bp.IsClassFeature = true;

                // Add features later using AddToSelection
                bp.m_Features = new BlueprintFeatureReference[0];
                bp.m_AllFeatures = new BlueprintFeatureReference[0];
            });
        }
        public static void AddToSelection(BlueprintFeature feature)
        {
            var BeachEpisodeSelection = Resources.GetModBlueprint<BlueprintFeatureSelection>("BeachEpisodeSelection");
            BeachEpisodeSelection.m_Features = BeachEpisodeSelection.m_Features.AddToArray(feature.ToReference<BlueprintFeatureReference>());
            BeachEpisodeSelection.m_AllFeatures = BeachEpisodeSelection.m_AllFeatures.AddToArray(feature.ToReference<BlueprintFeatureReference>());
        }
    }
}
