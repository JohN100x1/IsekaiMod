using HarmonyLib;
using IsekaiMod.Content.Classes.IsekaiProtagonist;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using TabletopTweaks.Core.Utilities;
using UnityEngine;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.OverpoweredAbility {

    internal class OverpoweredAbilitySelection {
        private static readonly Sprite Icon_TrickFate = BlueprintTools.GetBlueprint<BlueprintAbility>("6e109d21da9e1c44fb772a9eca2cafdd").m_Icon;
        public static void Add() {
            // Overpowered Ability Selection
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
                bp.SetDescription(IsekaiContext, "You use your mythic powers to gain an additional Overpowered Ability.\nSource: Isekai Mod");
                bp.m_Icon = Icon_TrickFate;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.m_AllFeatures = new BlueprintFeatureReference[0];
                bp.m_Features = new BlueprintFeatureReference[0];
            });

            // If MultipleMythicOPAbility is disabled, Mythic Overpowered Ability can only be selected once
            if (!IsekaiContext.AddedContent.MultipleMythicOPAbility) {
                OverpoweredAbilityMythicSelection.AddComponent<PrerequisiteNoFeature>(c => { c.m_Feature = OverpoweredAbilityMythicSelection.ToReference<BlueprintFeatureReference>(); });
            }

            // If RestrictMythicOPAbility is enabled, Mythic Overpowered Ability can only be selected by the Isekai Protagonist
            if (IsekaiContext.AddedContent.RestrictMythicOPAbility) {
                OverpoweredAbilityMythicSelection.AddPrerequisite<PrerequisiteClassLevel>(c => {
                    c.m_CharacterClass = IsekaiProtagonistClass.GetReference();
                    c.Level = 1;
                });
            }

            FeatTools.Selections.MythicAbilitySelection.AddToSelection(OverpoweredAbilityMythicSelection);
            FeatTools.Selections.ExtraMythicAbilityMythicFeat.AddToSelection(OverpoweredAbilityMythicSelection);
        }

        public static void AddToSelection(BlueprintFeature feature) {
            var OverpoweredAbilitySelections = new BlueprintFeatureSelection[] {
                BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "OverpoweredAbilitySelection"),
                BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "OverpoweredAbilitySelection2"),
                BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "OverpoweredAbilitySelectionVillain"),
                BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "OverpoweredAbilityMythicSelection"),
            };
            foreach (BlueprintFeatureSelection selection in OverpoweredAbilitySelections) {
                selection.m_Features = selection.m_Features.AddToArray(feature.ToReference<BlueprintFeatureReference>());
                selection.m_AllFeatures = selection.m_AllFeatures.AddToArray(feature.ToReference<BlueprintFeatureReference>());
            }
        }
        public static void AddToNonMythicSelection(BlueprintFeature feature) {
            var OverpoweredAbilitySelections = new BlueprintFeatureSelection[] {
                BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "OverpoweredAbilitySelection"),
                BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "OverpoweredAbilitySelection2"),
                BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "OverpoweredAbilitySelectionVillain"),
            };
            foreach (BlueprintFeatureSelection selection in OverpoweredAbilitySelections) {
                selection.m_Features = selection.m_Features.AddToArray(feature.ToReference<BlueprintFeatureReference>());
                selection.m_AllFeatures = selection.m_AllFeatures.AddToArray(feature.ToReference<BlueprintFeatureReference>());
            }
        }
    }
}