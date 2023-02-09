using HarmonyLib;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.OverpoweredAbility {

    internal class OverpoweredAbilitySelection {

        public static void Add() {
            // Overpowered Ability Selection
            var Icon_TrickFate = BlueprintTools.GetBlueprint<BlueprintAbility>("6e109d21da9e1c44fb772a9eca2cafdd").m_Icon;
            var OverpoweredAbilitySelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "OverpoweredAbilitySelection", bp => {
                bp.SetName(IsekaiContext, "Overpowered Ability");
                bp.SetDescription(IsekaiContext, "At 1st level, you get to select an Overpowered Ability.");
                bp.m_Icon = Icon_TrickFate;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.m_AllFeatures = new BlueprintFeatureReference[0];
                bp.m_Features = new BlueprintFeatureReference[0];
            });
            var OverpoweredAbilitySelection2 = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "OverpoweredAbilitySelection2", bp => {
                bp.SetName(IsekaiContext, "Additional Overpowered Ability");
                bp.SetDescription(IsekaiContext, "You get to select an additional Overpowered Ability.");
                bp.m_Icon = Icon_TrickFate;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.m_AllFeatures = new BlueprintFeatureReference[0];
                bp.m_Features = new BlueprintFeatureReference[0];
            });
            var OverpoweredAbilitySelectionVillain = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "OverpoweredAbilitySelectionVillain", bp => {
                bp.SetName(IsekaiContext, "Villainous Overpowered Ability");
                bp.SetDescription(IsekaiContext, "Villains get to select an additional Overpowered Abilities.");
                bp.m_Icon = Icon_TrickFate;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.m_AllFeatures = new BlueprintFeatureReference[0];
                bp.m_Features = new BlueprintFeatureReference[0];
            });
            var OverpoweredAbilityMythicSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "OverpoweredAbilityMythicSelection", bp => {
                bp.SetName(IsekaiContext, "Mythic Overpowered Ability");
                bp.SetDescription(IsekaiContext, "You use your mythic powers to gain an additional Overpowered Ability.");
                bp.m_Icon = Icon_TrickFate;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.m_AllFeatures = new BlueprintFeatureReference[0];
                bp.m_Features = new BlueprintFeatureReference[0];
            });

            // You can't select another Overpowered Ability from Mythic Abilities
            OverpoweredAbilityMythicSelection.AddComponent<PrerequisiteNoFeature>(c => { c.m_Feature = OverpoweredAbilityMythicSelection.ToReference<BlueprintFeatureReference>(); });

            // Add selection to mythic ability selection
            var MythicAbilitySelection = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("ba0e5a900b775be4a99702f1ed08914d");
            MythicAbilitySelection.m_AllFeatures = MythicAbilitySelection.m_AllFeatures.AppendToArray(OverpoweredAbilityMythicSelection.ToReference<BlueprintFeatureReference>());
        }

        public static void AddToSelection(BlueprintFeature feature) {
            var OverpoweredAbilitySelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "OverpoweredAbilitySelection");
            var OverpoweredAbilitySelection2 = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "OverpoweredAbilitySelection2");
            var OverpoweredAbilitySelectionVillain = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "OverpoweredAbilitySelectionVillain");
            var OverpoweredAbilityMythicSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "OverpoweredAbilityMythicSelection");
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