using IsekaiMod.Content.Backgrounds;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Items.Ecnchantments;
using Kingmaker.DialogSystem.Blueprints;
using Kingmaker.Localization;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components.AreaEffects;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Actions;
using System;
using TabletopTweaks.Core.ModLogic;
using TabletopTweaks.Core.Utilities;
using UnityEngine;

namespace IsekaiMod.Utilities {

    internal static class ExtensionMethods {
        public static void AddUnconditionalAuraEffect(this BlueprintScriptableObject obj, BlueprintBuffReference buff) {
            obj.AddComponent<AbilityAreaEffectRunAction>(c => {
                c.UnitEnter = ActionFlow.DoSingle<ContextActionApplyBuff>(b => {
                    b.m_Buff = buff;
                    b.Permanent = true;
                    b.DurationValue = new ContextDurationValue();
                });
                c.UnitExit = ActionFlow.DoSingle<ContextActionRemoveBuff>(b => {
                    b.m_Buff = buff;
                    b.RemoveRank = false;
                    b.ToCaster = false;
                });
                c.UnitMove = ActionFlow.DoNothing();
                c.Round = ActionFlow.DoNothing();
            });
        }

        public static void SetSummonDescription(this BlueprintAbility ability, ModContextBase modContext, string desciption) {
            const string StandardSummonDescription = " Summoned monsters appear where you designate and act according to their "
                + "{g|Encyclopedia:Initiative}initiative{/g} {g|Encyclopedia:Check}check{/g} results. They {g|Encyclopedia:Attack}attack{/g} "
                + "your opponents to the best of their ability.";
            ability.m_Description = Helpers.CreateString(modContext, $"{ability.name}.Description", desciption + StandardSummonDescription, shouldProcess: true);
        }

        public static void SetBackgroundDescription(this BlueprintFeature feature, ModContextBase modContext, string desciption) {
            feature.m_Description = Helpers.CreateString(modContext, $"{feature.name}.Description", desciption + IsekaiBackgroundSelection.DescAppendix, shouldProcess: true);
        }

        public static void SetLocalisedName(this BlueprintUnit Unit, ModContextBase modContext, string name) {
            Unit.LocalizedName = ScriptableObject.CreateInstance<SharedStringAsset>();
            Unit.LocalizedName.String = Helpers.CreateString(modContext, $"{Unit.LocalizedName}.LocalizedName", name);
        }

        public static void AddToSelection(this BlueprintFeatureSelection selection, BlueprintFeature feature) {
            selection.m_AllFeatures = selection.m_AllFeatures.AppendToArray(feature.ToReference<BlueprintFeatureReference>());
        }

        public static void RemoveFromSelection(this BlueprintFeatureSelection selection, BlueprintFeature feature) {
            selection.m_AllFeatures = selection.m_AllFeatures.RemoveFromArray(feature.ToReference<BlueprintFeatureReference>());
        }

        public static void SetText(this BlueprintCue cue, ModContextBase modContext, string text) {
            cue.Text = Helpers.CreateString(modContext, $"{cue.name}.Text", text);
        }

        public static void SetText(this BlueprintAnswer answer, ModContextBase modContext, string text) {
            answer.Text = Helpers.CreateString(modContext, $"{answer.name}.Text", text);
        }

        public static void SetName(this BlueprintWeaponEnchantment enchantment, ModContextBase modContext, string name) {
            enchantment.m_EnchantName = Helpers.CreateString(modContext, $"{enchantment.name}.EnchantName", name);
        }

        public static void SetDescription(this BlueprintWeaponEnchantment enchantment, ModContextBase modContext, string desc) {
            enchantment.m_Description = Helpers.CreateString(modContext, $"{enchantment.name}.Description", desc);
        }
        public static void SetDescription(this BlueprintWeaponEnchantment enchantment, LocalizedString description) {
            enchantment.m_Description = description;
        }

        public static void AddToFirst(this BlueprintFeatureSelection selection, BlueprintFeature feature) {
            BlueprintFeatureReference[] extendedArray = new BlueprintFeatureReference[selection.m_AllFeatures.Length + 1];
            Array.Copy(selection.m_AllFeatures, 0, extendedArray, 1, selection.m_AllFeatures.Length);
            extendedArray[0] = feature.ToReference<BlueprintFeatureReference>();
            selection.m_AllFeatures = extendedArray;
        }
    }
}