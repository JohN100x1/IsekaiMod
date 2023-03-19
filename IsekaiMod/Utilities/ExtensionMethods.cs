using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Localization;
using TabletopTweaks.Core.ModLogic;
using TabletopTweaks.Core.Utilities;
using UnityEngine;

namespace IsekaiMod.Utilities {
    static class ExtensionMethods {

        public static void SetLocalisedName(this BlueprintUnit Unit, ModContextBase modContext, string name) {
            Unit.LocalizedName = ScriptableObject.CreateInstance<SharedStringAsset>();
            Unit.LocalizedName.String = Helpers.CreateString(modContext, Unit.LocalizedName + "LocalizedName", name);
        }

        public static void AddToSelection(this BlueprintFeatureSelection selection, BlueprintFeature feature) {
            selection.m_AllFeatures = selection.m_AllFeatures.AppendToArray(feature.ToReference<BlueprintFeatureReference>());
        }
    }
}
