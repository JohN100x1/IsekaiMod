using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.UnitLogic.Abilities.Blueprints;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.OverpoweredAbility
{
    class OverpoweredAbilitySelection
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
            var Icon_TrickFate = Resources.GetBlueprint<BlueprintAbility>("6e109d21da9e1c44fb772a9eca2cafdd").m_Icon;
            var OverpoweredAbilitySelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>("OverpoweredAbilitySelection", bp => {
                bp.SetName("Overpowered Ability");
                bp.SetDescription("At 1st level, you get to select an extremely powerful Overpowered Ability.");
                bp.m_Icon = Icon_TrickFate;
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
                    WinnerFeature.ToReference<BlueprintFeatureReference>(),
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
                    WinnerFeature.ToReference<BlueprintFeatureReference>(),
                };
            });
            var OverpoweredAbilitySelection2 = Helpers.CreateBlueprint<BlueprintFeatureSelection>("OverpoweredAbilitySelection2", bp => {
                bp.SetName("Another Overpowered Ability");
                bp.SetDescription("You get to select an another extremely powerful Overpowered Ability.");
                bp.m_Icon = Icon_TrickFate;
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
        }
    }
}
