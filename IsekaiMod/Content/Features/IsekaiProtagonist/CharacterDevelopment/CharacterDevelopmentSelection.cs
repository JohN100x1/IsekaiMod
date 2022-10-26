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
            // Character development feats
            var AlphaStrike = Resources.GetModBlueprint<BlueprintFeature>("AlphaStrike");
            var BetaStrike = Resources.GetModBlueprint<BlueprintFeature>("BetaStrike");
            var GammaStrike = Resources.GetModBlueprint<BlueprintFeature>("GammaStrike");
            var MundaneAura = Resources.GetModBlueprint<BlueprintFeature>("MundaneAura");
            var HealthyBody = Resources.GetModBlueprint<BlueprintFeature>("HealthyBody");
            var InnerPower = Resources.GetModBlueprint<BlueprintFeature>("InnerPower");
            var MasterSelf = Resources.GetModBlueprint<BlueprintFeature>("MasterSelf");
            var Unstoppable = Resources.GetModBlueprint<BlueprintFeature>("Unstoppable");
            var IsekaiProtagonistBonusFeatSelection = Resources.GetModBlueprint<BlueprintFeatureSelection>("IsekaiProtagonistBonusFeatSelection");
            var IsekaiProtagonistTalentSelection = Resources.GetModBlueprint<BlueprintFeatureSelection>("IsekaiProtagonistTalentSelection");

            // Feature
            var Icon_Discovery = Resources.GetBlueprint<BlueprintFeatureSelection>("cd86c437488386f438dcc9ae727ea2a6").m_Icon;
            var CharacterDevelopmentSelection1 = Helpers.CreateBlueprint<BlueprintFeatureSelection>("CharacterDevelopmentSelection1", bp => {
                bp.SetName("Character Development I");
                bp.SetDescription("As you increase your level, you can select powerful character development feats.");
                bp.m_Icon = Icon_Discovery;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.m_AllFeatures = new BlueprintFeatureReference[] {
                    IsekaiProtagonistBonusFeatSelection.ToReference<BlueprintFeatureReference>(),
                    IsekaiProtagonistTalentSelection.ToReference<BlueprintFeatureReference>(),
                    AlphaStrike.ToReference<BlueprintFeatureReference>(),
                    BetaStrike.ToReference<BlueprintFeatureReference>(),
                    GammaStrike.ToReference<BlueprintFeatureReference>(),
                    MundaneAura.ToReference<BlueprintFeatureReference>(),
                };
                bp.m_Features = new BlueprintFeatureReference[] {
                    IsekaiProtagonistBonusFeatSelection.ToReference<BlueprintFeatureReference>(),
                    IsekaiProtagonistTalentSelection.ToReference<BlueprintFeatureReference>(),
                    AlphaStrike.ToReference<BlueprintFeatureReference>(),
                    BetaStrike.ToReference<BlueprintFeatureReference>(),
                    GammaStrike.ToReference<BlueprintFeatureReference>(),
                    MundaneAura.ToReference<BlueprintFeatureReference>(),
                };
            });
            var CharacterDevelopmentSelection2 = Helpers.CreateBlueprint<BlueprintFeatureSelection>("CharacterDevelopmentSelection2", bp => {
                bp.SetName("Character Development II");
                bp.SetDescription("As you increase your level, you can select powerful character development feats.");
                bp.m_Icon = Icon_Discovery;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.m_AllFeatures = new BlueprintFeatureReference[] {
                    IsekaiProtagonistBonusFeatSelection.ToReference<BlueprintFeatureReference>(),
                    IsekaiProtagonistTalentSelection.ToReference<BlueprintFeatureReference>(),
                    AlphaStrike.ToReference<BlueprintFeatureReference>(),
                    BetaStrike.ToReference<BlueprintFeatureReference>(),
                    GammaStrike.ToReference<BlueprintFeatureReference>(),
                    MundaneAura.ToReference<BlueprintFeatureReference>(),
                };
                bp.m_Features = new BlueprintFeatureReference[] {
                    IsekaiProtagonistBonusFeatSelection.ToReference<BlueprintFeatureReference>(),
                    IsekaiProtagonistTalentSelection.ToReference<BlueprintFeatureReference>(),
                    AlphaStrike.ToReference<BlueprintFeatureReference>(),
                    BetaStrike.ToReference<BlueprintFeatureReference>(),
                    GammaStrike.ToReference<BlueprintFeatureReference>(),
                    MundaneAura.ToReference<BlueprintFeatureReference>(),
                };
            });
            var CharacterDevelopmentSelection3 = Helpers.CreateBlueprint<BlueprintFeatureSelection>("CharacterDevelopmentSelection3", bp => {
                bp.SetName("Character Development III");
                bp.SetDescription("As you increase your level, you can select powerful character development feats.");
                bp.m_Icon = Icon_Discovery;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.m_AllFeatures = new BlueprintFeatureReference[] {
                    IsekaiProtagonistBonusFeatSelection.ToReference<BlueprintFeatureReference>(),
                    IsekaiProtagonistTalentSelection.ToReference<BlueprintFeatureReference>(),
                    AlphaStrike.ToReference<BlueprintFeatureReference>(),
                    BetaStrike.ToReference<BlueprintFeatureReference>(),
                    GammaStrike.ToReference<BlueprintFeatureReference>(),
                    MundaneAura.ToReference<BlueprintFeatureReference>(),
                    HealthyBody.ToReference<BlueprintFeatureReference>(),
                    InnerPower.ToReference<BlueprintFeatureReference>(),
                    MasterSelf.ToReference<BlueprintFeatureReference>(),
                    Unstoppable.ToReference<BlueprintFeatureReference>(),
                };
                bp.m_Features = new BlueprintFeatureReference[] {
                    IsekaiProtagonistBonusFeatSelection.ToReference<BlueprintFeatureReference>(),
                    IsekaiProtagonistTalentSelection.ToReference<BlueprintFeatureReference>(),
                    AlphaStrike.ToReference<BlueprintFeatureReference>(),
                    BetaStrike.ToReference<BlueprintFeatureReference>(),
                    GammaStrike.ToReference<BlueprintFeatureReference>(),
                    MundaneAura.ToReference<BlueprintFeatureReference>(),
                    HealthyBody.ToReference<BlueprintFeatureReference>(),
                    InnerPower.ToReference<BlueprintFeatureReference>(),
                    MasterSelf.ToReference<BlueprintFeatureReference>(),
                    Unstoppable.ToReference<BlueprintFeatureReference>(),
                };
            });
            var CharacterDevelopmentSelection4 = Helpers.CreateBlueprint<BlueprintFeatureSelection>("CharacterDevelopmentSelection4", bp => {
                bp.SetName("Character Development IV");
                bp.SetDescription("As you increase your level, you can select powerful character development feats.");
                bp.m_Icon = Icon_Discovery;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.m_AllFeatures = new BlueprintFeatureReference[] {
                    IsekaiProtagonistBonusFeatSelection.ToReference<BlueprintFeatureReference>(),
                    IsekaiProtagonistTalentSelection.ToReference<BlueprintFeatureReference>(),
                    AlphaStrike.ToReference<BlueprintFeatureReference>(),
                    BetaStrike.ToReference<BlueprintFeatureReference>(),
                    GammaStrike.ToReference<BlueprintFeatureReference>(),
                    MundaneAura.ToReference<BlueprintFeatureReference>(),
                    HealthyBody.ToReference<BlueprintFeatureReference>(),
                    InnerPower.ToReference<BlueprintFeatureReference>(),
                    MasterSelf.ToReference<BlueprintFeatureReference>(),
                    Unstoppable.ToReference<BlueprintFeatureReference>(),
                };
                bp.m_Features = new BlueprintFeatureReference[] {
                    IsekaiProtagonistBonusFeatSelection.ToReference<BlueprintFeatureReference>(),
                    IsekaiProtagonistTalentSelection.ToReference<BlueprintFeatureReference>(),
                    AlphaStrike.ToReference<BlueprintFeatureReference>(),
                    BetaStrike.ToReference<BlueprintFeatureReference>(),
                    GammaStrike.ToReference<BlueprintFeatureReference>(),
                    MundaneAura.ToReference<BlueprintFeatureReference>(),
                    HealthyBody.ToReference<BlueprintFeatureReference>(),
                    InnerPower.ToReference<BlueprintFeatureReference>(),
                    MasterSelf.ToReference<BlueprintFeatureReference>(),
                    Unstoppable.ToReference<BlueprintFeatureReference>(),
                };
            });
        }
    }
}
