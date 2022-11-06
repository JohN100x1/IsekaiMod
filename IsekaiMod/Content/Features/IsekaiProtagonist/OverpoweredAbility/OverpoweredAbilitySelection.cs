using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
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
            var SuperBuffFeature = Resources.GetModBlueprint<BlueprintFeature>("SuperBuffFeature");
            var WinnerFeature = Resources.GetModBlueprint<BlueprintFeature>("WinnerFeature");

            var OPAbilityList = new BlueprintFeatureReference[] {
                AutoEmpowerFeature.ToReference<BlueprintFeatureReference>(),
                AutoExtendFeature.ToReference<BlueprintFeatureReference>(),
                AutoMaximizeFeature.ToReference<BlueprintFeatureReference>(),
                AutoQuickenFeature.ToReference<BlueprintFeatureReference>(),
                AutoReachFeature.ToReference<BlueprintFeatureReference>(),
                GraspHeartFeature.ToReference<BlueprintFeatureReference>(),
                DupeGoldFeature.ToReference<BlueprintFeatureReference>(),
                PerfectRollFeature.ToReference<BlueprintFeatureReference>(),
                SuperBuffFeature.ToReference<BlueprintFeatureReference>(),
            };

            // Overpowered Ability Selection
            var Icon_TrickFate = Resources.GetBlueprint<BlueprintAbility>("6e109d21da9e1c44fb772a9eca2cafdd").m_Icon;
            var OverpoweredAbilitySelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>("OverpoweredAbilitySelection", bp => {
                bp.SetName("Overpowered Ability");
                bp.SetDescription("At 1st level, you get to select an extremely powerful Overpowered Ability.");
                bp.m_Icon = Icon_TrickFate;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.m_AllFeatures = OPAbilityList.AddToArray(WinnerFeature.ToReference<BlueprintFeatureReference>());
                bp.m_Features = OPAbilityList.AddToArray(WinnerFeature.ToReference<BlueprintFeatureReference>());
            });
            var OverpoweredAbilitySelection2 = Helpers.CreateBlueprint<BlueprintFeatureSelection>("OverpoweredAbilitySelection2", bp => {
                bp.SetName("Another Overpowered Ability");
                bp.SetDescription("You get to select an another extremely powerful Overpowered Ability.");
                bp.m_Icon = Icon_TrickFate;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.m_AllFeatures = OPAbilityList;
                bp.m_Features = OPAbilityList;
            });
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
                bp.m_AllFeatures = OPAbilityList;
                bp.m_Features = OPAbilityList;
            });

            // You can't select a third Overpowered Ability
            OverpoweredAbilityMythicSelection.AddComponent<PrerequisiteNoFeature>(c => { c.m_Feature = OverpoweredAbilityMythicSelection.ToReference<BlueprintFeatureReference>(); });
            // Add selection to mythic ability selection
            var MythicAbilitySelection = Resources.GetBlueprint<BlueprintFeatureSelection>("ba0e5a900b775be4a99702f1ed08914d");
            MythicAbilitySelection.m_AllFeatures = MythicAbilitySelection.m_AllFeatures.AppendToArray(OverpoweredAbilityMythicSelection.ToReference<BlueprintFeatureReference>());
        }
    }
}
