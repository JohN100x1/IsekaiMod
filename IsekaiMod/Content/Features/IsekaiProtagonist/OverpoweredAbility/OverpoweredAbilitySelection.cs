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
            // Overpowered Ability Selection
            var Icon_TrickFate = Resources.GetBlueprint<BlueprintAbility>("6e109d21da9e1c44fb772a9eca2cafdd").m_Icon;
            var OverpoweredAbilitySelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>("OverpoweredAbilitySelection", bp => {
                bp.SetName("Overpowered Ability");
                bp.SetDescription("At 1st level, you get to select an Overpowered Ability.");
                bp.m_Icon = Icon_TrickFate;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.m_AllFeatures = new BlueprintFeatureReference[0];
                bp.m_Features = new BlueprintFeatureReference[0];
            });
            var OverpoweredAbilitySelection2 = Helpers.CreateBlueprint<BlueprintFeatureSelection>("OverpoweredAbilitySelection2", bp => {
                bp.SetName("Additional Overpowered Ability");
                bp.SetDescription("You get to select an additional Overpowered Ability.");
                bp.m_Icon = Icon_TrickFate;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.m_AllFeatures = new BlueprintFeatureReference[0];
                bp.m_Features = new BlueprintFeatureReference[0];
            });
            var OverpoweredAbilitySelectionVillain = Helpers.CreateBlueprint<BlueprintFeatureSelection>("OverpoweredAbilitySelectionVillain", bp => {
                bp.SetName("Villainous Overpowered Ability");
                bp.SetDescription("Villains get to select an additional 1st level Overpowered Ability.");
                bp.m_Icon = Icon_TrickFate;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.m_AllFeatures = new BlueprintFeatureReference[0];
                bp.m_Features = new BlueprintFeatureReference[0];
            });
            var OverpoweredAbilityMythicSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>("OverpoweredAbilityMythicSelection", bp => {
                bp.SetName("Mythic Overpowered Ability");
                bp.SetDescription("You use your mythic powers to gain an additional Overpowered Ability.");
                bp.m_Icon = Icon_TrickFate;
                bp.AddComponent<PrerequisiteFeature>(c => {
                    c.Group = Prerequisite.GroupType.All;
                    c.m_Feature = OverpoweredAbilitySelection.ToReference<BlueprintFeatureReference>();
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.m_AllFeatures = new BlueprintFeatureReference[0];
                bp.m_Features = new BlueprintFeatureReference[0];
            });

            // You can't select another Overpowered Ability from Mythic Abilities
            OverpoweredAbilityMythicSelection.AddComponent<PrerequisiteNoFeature>(c => { c.m_Feature = OverpoweredAbilityMythicSelection.ToReference<BlueprintFeatureReference>(); });

            // Add selection to mythic ability selection
            var MythicAbilitySelection = Resources.GetBlueprint<BlueprintFeatureSelection>("ba0e5a900b775be4a99702f1ed08914d");
            MythicAbilitySelection.m_AllFeatures = MythicAbilitySelection.m_AllFeatures.AppendToArray(OverpoweredAbilityMythicSelection.ToReference<BlueprintFeatureReference>());
        }
        public static void AddToSelection(BlueprintFeature feature)
        {
            var OverpoweredAbilitySelection = Resources.GetModBlueprint<BlueprintFeatureSelection>("OverpoweredAbilitySelection");
            var OverpoweredAbilitySelection2 = Resources.GetModBlueprint<BlueprintFeatureSelection>("OverpoweredAbilitySelection2");
            var OverpoweredAbilitySelectionVillain = Resources.GetModBlueprint<BlueprintFeatureSelection>("OverpoweredAbilitySelectionVillain");
            var OverpoweredAbilityMythicSelection = Resources.GetModBlueprint<BlueprintFeatureSelection>("OverpoweredAbilityMythicSelection");
            OverpoweredAbilitySelection.m_Features = OverpoweredAbilitySelection.m_Features.AddToArray(feature.ToReference<BlueprintFeatureReference>());
            OverpoweredAbilitySelection.m_AllFeatures = OverpoweredAbilitySelection.m_AllFeatures.AddToArray(feature.ToReference<BlueprintFeatureReference>());
            OverpoweredAbilitySelection2.m_Features = OverpoweredAbilitySelection2.m_Features.AddToArray(feature.ToReference<BlueprintFeatureReference>());
            OverpoweredAbilitySelection2.m_AllFeatures = OverpoweredAbilitySelection2.m_AllFeatures.AddToArray(feature.ToReference<BlueprintFeatureReference>());
            OverpoweredAbilitySelectionVillain.m_Features = OverpoweredAbilitySelectionVillain.m_Features.AddToArray(feature.ToReference<BlueprintFeatureReference>());
            OverpoweredAbilitySelectionVillain.m_AllFeatures = OverpoweredAbilitySelectionVillain.m_AllFeatures.AddToArray(feature.ToReference<BlueprintFeatureReference>());
            OverpoweredAbilityMythicSelection.m_Features = OverpoweredAbilityMythicSelection.m_Features.AddToArray(feature.ToReference<BlueprintFeatureReference>());
            OverpoweredAbilityMythicSelection.m_AllFeatures = OverpoweredAbilityMythicSelection.m_AllFeatures.AddToArray(feature.ToReference<BlueprintFeatureReference>());
        }
    }
}
