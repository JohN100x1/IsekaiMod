using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.UnitLogic.Abilities.Blueprints;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.OverpoweredAbility
{
    class OverpoweredAbilityMythicSelection
    {
        public static void Add()
        {
            // Overpowered Abilities
            var AutoEmpowerFeature = Resources.GetModBlueprint<BlueprintFeature>("AutoEmpowerFeature");
            var AutoExtendFeature = Resources.GetModBlueprint<BlueprintFeature>("AutoExtendFeature");
            var AutoMaximizeFeature = Resources.GetModBlueprint<BlueprintFeature>("AutoMaximizeFeature");
            var AutoQuickenFeature = Resources.GetModBlueprint<BlueprintFeature>("AutoQuickenFeature");
            var AutoReachFeature = Resources.GetModBlueprint<BlueprintFeature>("AutoReachFeature");
            var GraspHeartFeature = Resources.GetModBlueprint<BlueprintFeature>("GraspHeartFeature");
            var DupeGoldFeature = Resources.GetModBlueprint<BlueprintFeature>("DupeGoldFeature");
            var PerfectRollFeature = Resources.GetModBlueprint<BlueprintFeature>("PerfectRollFeature");
            var WinnerFeature = Resources.GetModBlueprint<BlueprintFeature>("WinnerFeature");

            // Overpowered Ability Selection
            var OverpoweredAbilitySelection = Resources.GetModBlueprint<BlueprintFeatureSelection>("OverpoweredAbilitySelection");

            // Overpowered Ability Mythic Selection
            var Icon_TrickFate = Resources.GetBlueprint<BlueprintAbility>("6e109d21da9e1c44fb772a9eca2cafdd").m_Icon;
            var OverpoweredAbilityMythicSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>("OverpoweredAbilityMythicSelection", bp => {
                bp.SetName("Second Overpowered Ability");
                bp.SetDescription("You use your mythic powers to gain an additional Overpowered Ability.");
                bp.m_Icon = Icon_TrickFate;
                bp.AddComponent<PrerequisiteNoFeature>(c => {
                    c.m_Feature = WinnerFeature.ToReference<BlueprintFeatureReference>();
                });
                bp.AddComponent<PrerequisiteFeature>(c => {
                    c.m_Feature = OverpoweredAbilitySelection.ToReference<BlueprintFeatureReference>();
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.m_AllFeatures = new BlueprintFeatureReference[] {
                    AutoEmpowerFeature.ToReference<BlueprintFeatureReference>(),
                    AutoExtendFeature.ToReference<BlueprintFeatureReference>(),
                    AutoMaximizeFeature.ToReference<BlueprintFeatureReference>(),
                    AutoQuickenFeature.ToReference<BlueprintFeatureReference>(),
                    AutoReachFeature.ToReference<BlueprintFeatureReference>(),
                    GraspHeartFeature.ToReference<BlueprintFeatureReference>(),
                    DupeGoldFeature.ToReference<BlueprintFeatureReference>(),
                    PerfectRollFeature.ToReference<BlueprintFeatureReference>(),
                };
                bp.m_Features = new BlueprintFeatureReference[] {
                    AutoEmpowerFeature.ToReference<BlueprintFeatureReference>(),
                    AutoExtendFeature.ToReference<BlueprintFeatureReference>(),
                    AutoMaximizeFeature.ToReference<BlueprintFeatureReference>(),
                    AutoQuickenFeature.ToReference<BlueprintFeatureReference>(),
                    AutoReachFeature.ToReference<BlueprintFeatureReference>(),
                    GraspHeartFeature.ToReference<BlueprintFeatureReference>(),
                    DupeGoldFeature.ToReference<BlueprintFeatureReference>(),
                    PerfectRollFeature.ToReference<BlueprintFeatureReference>(),
                };
            });

            // You can't select a third Overpowered Ability
            OverpoweredAbilityMythicSelection.AddComponent<PrerequisiteNoFeature>(c => { c.m_Feature = OverpoweredAbilityMythicSelection.ToReference<BlueprintFeatureReference>(); });
            // Add selection to mythic ability selection
            var MythicAbilitySelection = Resources.GetBlueprint<BlueprintFeatureSelection>("ba0e5a900b775be4a99702f1ed08914d");
            MythicAbilitySelection.m_AllFeatures = MythicAbilitySelection.m_AllFeatures.AppendToArray(OverpoweredAbilityMythicSelection.ToReference<BlueprintFeatureReference>());
        }
    }
}
