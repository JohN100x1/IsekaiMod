using HarmonyLib;
using IsekaiMod.Content.Classes.IsekaiProtagonist;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using TabletopTweaks.Core.Utilities;
using UnityEngine;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.SpecialPower {

    internal class SpecialPowerSelection {
        private static readonly Sprite Icon_ForetellAidBuff = BlueprintTools.GetBlueprint<BlueprintBuff>("faf473e3a977fd4428cd3f1a526346d2").m_Icon;

        public static void Add() {
            BlueprintFeatureReference[] Features = new BlueprintFeatureReference[] {
                IsekaiChannelNegativeEnergy.GetReference(),
                IsekaiChannelPositiveEnergy.GetReference(),
            };

            var SpecialPowerSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "SpecialPowerSelection", bp => {
                bp.SetName(IsekaiContext, "Special Power");
                bp.SetDescription(IsekaiContext, "As you increase your level, you gain special powers that allow you to wreck your enemies more easily.");
                bp.m_Icon = Icon_ForetellAidBuff;
                bp.Ranks = 1;
                bp.IsClassFeature = true;

                // Special Powers are added in later (IsekaiProtagonistTalentSelection is added here because it was defined before SpecialPowerSelection)
                bp.m_Features = Features;
                bp.m_AllFeatures = Features;
            });
            var SpecialPowerMythicSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "SpecialPowerMythicSelection", bp => {
                bp.SetName(IsekaiContext, "Mythic Special Power");
                bp.SetDescription(IsekaiContext, "You use your mythic powers to gain an additional special power.\nSource: Isekai Mod");
                bp.m_Icon = Icon_ForetellAidBuff;
                bp.Ranks = 1;
                bp.IsClassFeature = true;

                // Special Powers are added in later (IsekaiProtagonistTalentSelection is added here because it was defined before SpecialPowerSelection)
                bp.m_Features = Features;
                bp.m_AllFeatures = Features;
            });

            // If MultipleMythicSpecialPower is disabled, Mythic Special Power can only be selected once
            if (!IsekaiContext.AddedContent.MultipleMythicSpecialPower) {
                SpecialPowerMythicSelection.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = SpecialPowerMythicSelection.ToReference<BlueprintFeatureReference>(); });
            }

            // If RestrictMythicSpecialPower is enabled, Mythic Special Power can only be selected by the Isekai Protagonist
            if (IsekaiContext.AddedContent.RestrictMythicSpecialPower) {
                SpecialPowerMythicSelection.AddPrerequisite<PrerequisiteClassLevel>(c => {
                    c.m_CharacterClass = IsekaiProtagonistClass.GetReference();
                    c.Level = 1;
                });
            }

            FeatTools.Selections.MythicAbilitySelection.AddToSelection(SpecialPowerMythicSelection);
            FeatTools.Selections.ExtraMythicAbilityMythicFeat.AddToSelection(SpecialPowerMythicSelection);
        }

        public static void AddToSelection(BlueprintFeature feature) {
            var SpecialPowerSelections = new BlueprintFeatureSelection[] {
                BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "SpecialPowerSelection"),
                BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "SpecialPowerMythicSelection"),
            };
            foreach (BlueprintFeatureSelection selection in SpecialPowerSelections) {
                selection.m_Features = selection.m_Features.AddToArray(feature.ToReference<BlueprintFeatureReference>());
                selection.m_AllFeatures = selection.m_AllFeatures.AddToArray(feature.ToReference<BlueprintFeatureReference>());
            }
        }
        public static void AddToNonMythicSelection(BlueprintFeature feature) {
            BlueprintFeatureSelection selection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "SpecialPowerSelection");
            selection.m_Features = selection.m_Features.AddToArray(feature.ToReference<BlueprintFeatureReference>());
            selection.m_AllFeatures = selection.m_AllFeatures.AddToArray(feature.ToReference<BlueprintFeatureReference>());
        }

        public static BlueprintFeatureSelection Get() {
            return BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "SpecialPowerSelection");
        }
    }
}