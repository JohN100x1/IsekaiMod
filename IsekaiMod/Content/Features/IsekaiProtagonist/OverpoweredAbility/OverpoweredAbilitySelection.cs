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

        private static readonly Sprite Icon_AutoMagic = AssetLoader.LoadInternal(IsekaiContext, "Features", "ICON_AUTO_MAGIC.png");
        private static readonly Sprite Icon_TrickFate = BlueprintTools.GetBlueprint<BlueprintAbility>("6e109d21da9e1c44fb772a9eca2cafdd").m_Icon;
        public static void Add() {
            // Overpowered Ability Selection
            var OverpoweredAbilitySelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "OverpoweredAbilitySelection", bp => {
                bp.SetName(IsekaiContext, "Overpowered Ability");
                bp.SetDescription(IsekaiContext, "As a being from another world, you are granted an Overpowered Ability which no ordinary being in this world possess.");
                bp.m_Icon = Icon_TrickFate;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.m_AllFeatures = new BlueprintFeatureReference[0];
                bp.m_Features = new BlueprintFeatureReference[0];
            });
            var OverpoweredAbilitySelectionMastermind = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "OverpoweredAbilitySelectionMastermind", bp => {
                bp.SetName(IsekaiContext, "Mastermind Auto magic");
                bp.SetDescription(IsekaiContext, "Masterminds get to select powerful auto-metamagics.");
                bp.m_Icon = Icon_AutoMagic;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.m_AllFeatures = new BlueprintFeatureReference[0];
                bp.m_Features = new BlueprintFeatureReference[0];
            });
            var OverpoweredAbilitySelectionOverlord = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "OverpoweredAbilitySelectionOverlord", bp => {
                bp.SetName(IsekaiContext, "Overlord Overpowered Ability");
                bp.SetDescription(IsekaiContext, "Overlords get to select an additional Overpowered Abilities.");
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

        public static void AddToNonAutoSelection(BlueprintFeature feature) {
            var OverpoweredAbilitySelections = new BlueprintFeatureSelection[] {
                BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "OverpoweredAbilitySelection"),
                BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "OverpoweredAbilitySelectionOverlord"),
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
                BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "OverpoweredAbilitySelectionOverlord"),
            };
            foreach (BlueprintFeatureSelection selection in OverpoweredAbilitySelections) {
                selection.m_Features = selection.m_Features.AddToArray(feature.ToReference<BlueprintFeatureReference>());
                selection.m_AllFeatures = selection.m_AllFeatures.AddToArray(feature.ToReference<BlueprintFeatureReference>());
            }
        }
        public static void AddToAllSelection(BlueprintFeature feature) {
            var OverpoweredAbilitySelections = new BlueprintFeatureSelection[] {
                BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "OverpoweredAbilitySelection"),
                BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "OverpoweredAbilitySelectionMastermind"),
                BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "OverpoweredAbilitySelectionOverlord"),
                BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "OverpoweredAbilityMythicSelection"),
            };
            foreach (BlueprintFeatureSelection selection in OverpoweredAbilitySelections) {
                selection.m_Features = selection.m_Features.AddToArray(feature.ToReference<BlueprintFeatureReference>());
                selection.m_AllFeatures = selection.m_AllFeatures.AddToArray(feature.ToReference<BlueprintFeatureReference>());
            }
        }
    }
}