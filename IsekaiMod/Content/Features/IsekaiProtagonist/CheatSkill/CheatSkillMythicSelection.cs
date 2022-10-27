using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.UnitLogic.Abilities.Blueprints;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.CheatSkill
{
    class CheatSkillMythicSelection
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
            var PerfectRollFeature = Resources.GetModBlueprint<BlueprintFeature>("PerfectRollFeature");
            var Winner = Resources.GetModBlueprint<BlueprintFeature>("Winner");

            // Cheat Skill Selection
            var CheatSkillSelection = Resources.GetModBlueprint<BlueprintFeatureSelection>("CheatSkillSelection");

            // Cheat Skill Mythic Selection
            var Icon_TrickFate = Resources.GetBlueprint<BlueprintAbility>("6e109d21da9e1c44fb772a9eca2cafdd").m_Icon;
            var CheatSkillMythicSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>("CheatSkillMythicSelection", bp => {
                bp.SetName("Second Cheat Skill");
                bp.SetDescription("You use your mythic powers to gain an additional cheat skill.");
                bp.m_Icon = Icon_TrickFate;
                bp.AddComponent<PrerequisiteNoFeature>(c => {
                    c.m_Feature = Winner.ToReference<BlueprintFeatureReference>();
                });
                bp.AddComponent<PrerequisiteFeature>(c => {
                    c.m_Feature = CheatSkillSelection.ToReference<BlueprintFeatureReference>();
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

            // You can't select a third cheat skill
            CheatSkillMythicSelection.AddComponent<PrerequisiteNoFeature>(c => { c.m_Feature = CheatSkillMythicSelection.ToReference<BlueprintFeatureReference>(); });
            // Add selection to mythic ability selection
            var MythicAbilitySelection = Resources.GetBlueprint<BlueprintFeatureSelection>("ba0e5a900b775be4a99702f1ed08914d");
            MythicAbilitySelection.m_AllFeatures = MythicAbilitySelection.m_AllFeatures.AppendToArray(CheatSkillMythicSelection.ToReference<BlueprintFeatureReference>());
        }
    }
}
