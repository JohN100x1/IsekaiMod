using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.UnitLogic.Abilities.Blueprints;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.CheatSkill
{
    class CheatSkillSelection
    {
        public static void Add()
        {
            // Cheat Skills
            var AutoEmpowerFeature = Resources.GetModBlueprint<BlueprintFeature>("AutoEmpowerFeature");
            var AutoExtendFeature = Resources.GetModBlueprint<BlueprintFeature>("AutoExtendFeature");
            var AutoMaximizeFeature = Resources.GetModBlueprint<BlueprintFeature>("AutoMaximizeFeature");
            var AutoQuickenFeature = Resources.GetModBlueprint<BlueprintFeature>("AutoQuickenFeature");
            var AutoReachFeature = Resources.GetModBlueprint<BlueprintFeature>("AutoReachFeature");
            var GraspHeartFeature = Resources.GetModBlueprint<BlueprintFeature>("GraspHeartFeature");
            var DupeGoldFeature = Resources.GetModBlueprint<BlueprintFeature>("DupeGoldFeature");
            var Winner = Resources.GetModBlueprint<BlueprintFeature>("Winner");

            // Cheat Skill Selection
            var Icon_TrickFate = Resources.GetBlueprint<BlueprintAbility>("6e109d21da9e1c44fb772a9eca2cafdd").m_Icon;
            var CheatSkillSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>("CheatSkillSelection", bp => {
                bp.SetName("Cheat Skill");
                bp.SetDescription("At 1st level, you get to select an extremely powerful cheat skill.");
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
                    Winner.ToReference<BlueprintFeatureReference>(),
                };
                bp.m_Features = new BlueprintFeatureReference[] {
                    AutoEmpowerFeature.ToReference<BlueprintFeatureReference>(),
                    AutoExtendFeature.ToReference<BlueprintFeatureReference>(),
                    AutoMaximizeFeature.ToReference<BlueprintFeatureReference>(),
                    AutoQuickenFeature.ToReference<BlueprintFeatureReference>(),
                    AutoReachFeature.ToReference<BlueprintFeatureReference>(),
                    GraspHeartFeature.ToReference<BlueprintFeatureReference>(),
                    DupeGoldFeature.ToReference<BlueprintFeatureReference>(),
                    Winner.ToReference<BlueprintFeatureReference>(),
                };
            });
        }
    }
}
