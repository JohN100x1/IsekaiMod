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
            var AutoEmpower = Resources.GetModBlueprint<BlueprintFeature>("AutoEmpower");
            var AutoExtend = Resources.GetModBlueprint<BlueprintFeature>("AutoExtend");
            var AutoMaximize = Resources.GetModBlueprint<BlueprintFeature>("AutoMaximize");
            var AutoQuicken = Resources.GetModBlueprint<BlueprintFeature>("AutoQuicken");
            var AutoReach = Resources.GetModBlueprint<BlueprintFeature>("AutoReach");
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
                    AutoEmpower.ToReference<BlueprintFeatureReference>(),
                    AutoExtend.ToReference<BlueprintFeatureReference>(),
                    AutoMaximize.ToReference<BlueprintFeatureReference>(),
                    AutoQuicken.ToReference<BlueprintFeatureReference>(),
                    AutoReach.ToReference<BlueprintFeatureReference>(),
                    GraspHeartFeature.ToReference<BlueprintFeatureReference>(),
                    DupeGoldFeature.ToReference<BlueprintFeatureReference>(),
                    Winner.ToReference<BlueprintFeatureReference>(),
                };
                bp.m_Features = new BlueprintFeatureReference[] {
                    AutoEmpower.ToReference<BlueprintFeatureReference>(),
                    AutoExtend.ToReference<BlueprintFeatureReference>(),
                    AutoMaximize.ToReference<BlueprintFeatureReference>(),
                    AutoQuicken.ToReference<BlueprintFeatureReference>(),
                    AutoReach.ToReference<BlueprintFeatureReference>(),
                    GraspHeartFeature.ToReference<BlueprintFeatureReference>(),
                    DupeGoldFeature.ToReference<BlueprintFeatureReference>(),
                    Winner.ToReference<BlueprintFeatureReference>(),
                };
            });
        }
    }
}
