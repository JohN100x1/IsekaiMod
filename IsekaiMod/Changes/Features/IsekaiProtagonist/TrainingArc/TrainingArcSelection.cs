using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;

namespace IsekaiMod.Changes.Features.IsekaiProtagonist.TrainingArc
{
    class TrainingArcSelection
    {
        public static void Add()
        {
            //Training Arc
            var StudyMontage = Resources.GetModBlueprint<BlueprintFeature>("StudyMontage");
            var TrainingMontage = Resources.GetModBlueprint<BlueprintFeature>("TrainingMontage");
            var BodyStrengthening = Resources.GetModBlueprint<BlueprintFeature>("BodyStrengthening");
            var SpellNegation = Resources.GetModBlueprint<BlueprintFeature>("SpellNegation");

            // Feature
            var Icon_PerfectStrike = Resources.GetBlueprint<BlueprintFeature>("9ff65b68c09567e48af9b33848b23323").m_Icon;
            var TrainingArcSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>("TrainingArcSelection", bp => {
                bp.SetName("Training Arc");
                bp.SetDescription("At 4th and 16th level, you train yourself intensely and gain insight into your own abilities.");
                bp.m_Icon = Icon_PerfectStrike;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.m_AllFeatures = new BlueprintFeatureReference[] {
                    StudyMontage.ToReference<BlueprintFeatureReference>(),
                    TrainingMontage.ToReference<BlueprintFeatureReference>(),
                    BodyStrengthening.ToReference<BlueprintFeatureReference>(),
                    SpellNegation.ToReference<BlueprintFeatureReference>(),
                };
                bp.m_Features = new BlueprintFeatureReference[] {
                    StudyMontage.ToReference<BlueprintFeatureReference>(),
                    TrainingMontage.ToReference<BlueprintFeatureReference>(),
                    BodyStrengthening.ToReference<BlueprintFeatureReference>(),
                    SpellNegation.ToReference<BlueprintFeatureReference>(),
                };
            });
        }
    }
}
