using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Items.Ecnchantments;
using Kingmaker.DialogSystem.Blueprints;
using Kingmaker.Localization;
using System;
using TabletopTweaks.Core.ModLogic;
using TabletopTweaks.Core.Utilities;
using UnityEngine;

namespace IsekaiMod.Utilities {
    static class ExtensionMethods {

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

        public static void SetText(this BlueprintCue Cue, ModContextBase modContext, string name) {
            Cue.Text = Helpers.CreateString(modContext, $"{Cue.name}.Text", name);
        }
        public static void SetText(this BlueprintAnswer Cue, ModContextBase modContext, string name) {
            Cue.Text = Helpers.CreateString(modContext, $"{Cue.name}.Text", name);
        }

        public static void SetName(this BlueprintWeaponEnchantment enchantment, ModContextBase modContext, string name) {
            enchantment.m_EnchantName = Helpers.CreateString(modContext, $"{enchantment.name}.EnchantName", name);
        }
        public static void SetDescription(this BlueprintWeaponEnchantment enchantment, ModContextBase modContext, string name) {
            enchantment.m_Description = Helpers.CreateString(modContext, $"{enchantment.name}.Description", name);
        }

        public static void AddToFirst(this BlueprintFeatureSelection selection, BlueprintFeature feature) {
            BlueprintFeatureReference itemToBeAdded = feature.ToReference<BlueprintFeatureReference>();
            BlueprintFeatureReference[] array = selection.m_AllFeatures;
            BlueprintFeatureReference[] extendedArray = new BlueprintFeatureReference[array.Length + 1];
            Array.Copy(array, 0, extendedArray, 1, array.Length);
            extendedArray[0] = itemToBeAdded;
            selection.m_AllFeatures = extendedArray;
        }
    }
}
