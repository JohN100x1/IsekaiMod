using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.CharacterDevelopment
{
    class CharacterDevelopmentSelection3
    {
        public static void Add()
        {
            // Character development feats
            var AlphaStrike = Resources.GetModBlueprint<BlueprintFeature>("AlphaStrike");
            var BetaStrike = Resources.GetModBlueprint<BlueprintFeature>("BetaStrike");
            var GammaStrike = Resources.GetModBlueprint<BlueprintFeature>("GammaStrike");
            var MundaneAura = Resources.GetModBlueprint<BlueprintFeature>("MundaneAura");
            var CripplingStrike = Resources.GetBlueprint<BlueprintFeature>("b696bd7cb38da194fa3404032483d1db");
            var DispellingAttack = Resources.GetBlueprint<BlueprintFeature>("1b92146b8a9830d4bb97ab694335fa7c");
            var HealthyBody = Resources.GetModBlueprint<BlueprintFeature>("HealthyBody");
            var InnerPower = Resources.GetModBlueprint<BlueprintFeature>("InnerPower");
            var MasterSelf = Resources.GetModBlueprint<BlueprintFeature>("MasterSelf");
            var Unstoppable = Resources.GetModBlueprint<BlueprintFeature>("Unstoppable");

            // Feature
            var Icon_Discovery = Resources.GetBlueprint<BlueprintFeatureSelection>("cd86c437488386f438dcc9ae727ea2a6").m_Icon;
            var CharacterDevelopmentSelection3 = Helpers.CreateBlueprint<BlueprintFeatureSelection>("CharacterDevelopmentSelection3", bp => {
                bp.SetName("Character Development III");
                bp.SetDescription("As you increase your level, you can select powerful character development feats.");
                bp.m_Icon = Icon_Discovery;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.m_AllFeatures = new BlueprintFeatureReference[] {
                    AlphaStrike.ToReference<BlueprintFeatureReference>(),
                    BetaStrike.ToReference<BlueprintFeatureReference>(),
                    GammaStrike.ToReference<BlueprintFeatureReference>(),
                    MundaneAura.ToReference<BlueprintFeatureReference>(),
                    CripplingStrike.ToReference<BlueprintFeatureReference>(),
                    DispellingAttack.ToReference<BlueprintFeatureReference>(),
                    HealthyBody.ToReference<BlueprintFeatureReference>(),
                    InnerPower.ToReference<BlueprintFeatureReference>(),
                    MasterSelf.ToReference<BlueprintFeatureReference>(),
                    Unstoppable.ToReference<BlueprintFeatureReference>(),
                };
                bp.m_Features = new BlueprintFeatureReference[] {
                    AlphaStrike.ToReference<BlueprintFeatureReference>(),
                    BetaStrike.ToReference<BlueprintFeatureReference>(),
                    GammaStrike.ToReference<BlueprintFeatureReference>(),
                    MundaneAura.ToReference<BlueprintFeatureReference>(),
                    CripplingStrike.ToReference<BlueprintFeatureReference>(),
                    DispellingAttack.ToReference<BlueprintFeatureReference>(),
                    HealthyBody.ToReference<BlueprintFeatureReference>(),
                    InnerPower.ToReference<BlueprintFeatureReference>(),
                    MasterSelf.ToReference<BlueprintFeatureReference>(),
                    Unstoppable.ToReference<BlueprintFeatureReference>(),
                };
            });
        }
    }
}
