using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;

namespace IsekaiMod.Changes.Features.IsekaiProtagonist.CharacterDevelopment
{
    class CharacterDevelopmentSelection2
    {
        public static void Add()
        {
            // Character development feats
            var AlphaStrike = Resources.GetModBlueprint<BlueprintFeature>("AlphaStrike");
            var BetaStrike = Resources.GetModBlueprint<BlueprintFeature>("BetaStrike");
            var GammaStrike = Resources.GetModBlueprint<BlueprintFeature>("GammaStrike");
            var MundaneAura = Resources.GetModBlueprint<BlueprintFeature>("MundaneAura");

            // Feature
            var Icon_Discovery = Resources.GetBlueprint<BlueprintFeatureSelection>("cd86c437488386f438dcc9ae727ea2a6").m_Icon;
            var CharacterDevelopmentSelection2 = Helpers.CreateBlueprint<BlueprintFeatureSelection>("CharacterDevelopmentSelection2", bp => {
                bp.SetName("Character Development II");
                bp.SetDescription("At 3rd, 7th, 13th, and 19th level, you can select one character development.");
                bp.m_Icon = Icon_Discovery;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.m_AllFeatures = new BlueprintFeatureReference[] {
                    AlphaStrike.ToReference<BlueprintFeatureReference>(),
                    BetaStrike.ToReference<BlueprintFeatureReference>(),
                    GammaStrike.ToReference<BlueprintFeatureReference>(),
                    MundaneAura.ToReference<BlueprintFeatureReference>(),
                };
                bp.m_Features = new BlueprintFeatureReference[] {
                    AlphaStrike.ToReference<BlueprintFeatureReference>(),
                    BetaStrike.ToReference<BlueprintFeatureReference>(),
                    GammaStrike.ToReference<BlueprintFeatureReference>(),
                    MundaneAura.ToReference<BlueprintFeatureReference>(),
                };
            });
        }
    }
}
