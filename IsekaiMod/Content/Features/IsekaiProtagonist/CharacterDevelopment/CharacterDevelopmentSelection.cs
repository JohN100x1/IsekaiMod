using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.CharacterDevelopment
{
    class CharacterDevelopmentSelection
    {
        public static void Add()
        {
            var IsekaiProtagonistBonusFeatSelection = Resources.GetModBlueprint<BlueprintFeatureSelection>("IsekaiProtagonistBonusFeatSelection");
            var IsekaiProtagonistTalentSelection = Resources.GetModBlueprint<BlueprintFeatureSelection>("IsekaiProtagonistTalentSelection");

            // Feature
            var Icon_Discovery = Resources.GetBlueprint<BlueprintFeatureSelection>("cd86c437488386f438dcc9ae727ea2a6").m_Icon;
            var CharacterDevelopmentSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>("CharacterDevelopmentSelection", bp => {
                bp.SetName("Character Development");
                bp.SetDescription("As you increase your level, you can select powerful character development feats.");
                bp.m_Icon = Icon_Discovery;
                bp.Ranks = 1;
                bp.IsClassFeature = true;

                // The rest of the character development feats are added in later
                bp.m_Features = new BlueprintFeatureReference[] {
                    IsekaiProtagonistBonusFeatSelection.ToReference<BlueprintFeatureReference>(),
                    IsekaiProtagonistTalentSelection.ToReference<BlueprintFeatureReference>()
                };
                bp.m_AllFeatures = new BlueprintFeatureReference[] {
                    IsekaiProtagonistBonusFeatSelection.ToReference<BlueprintFeatureReference>(),
                    IsekaiProtagonistTalentSelection.ToReference<BlueprintFeatureReference>()
                };
            });
        }
        public static void AddToSelection(BlueprintFeature feature)
        {
            var CharacterDevelopmentSelection = Resources.GetModBlueprint<BlueprintFeatureSelection>("CharacterDevelopmentSelection");
            CharacterDevelopmentSelection.m_Features = CharacterDevelopmentSelection.m_Features.AddToArray(feature.ToReference<BlueprintFeatureReference>());
            CharacterDevelopmentSelection.m_AllFeatures = CharacterDevelopmentSelection.m_AllFeatures.AddToArray(feature.ToReference<BlueprintFeatureReference>());
        }
    }
}
