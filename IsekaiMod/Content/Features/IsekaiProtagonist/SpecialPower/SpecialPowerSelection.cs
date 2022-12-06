using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using UnityEngine;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.SpecialPower
{
    class SpecialPowerSelection
    {
        private static readonly Sprite Icon_ForetellAidBuff = Resources.GetBlueprint<BlueprintBuff>("faf473e3a977fd4428cd3f1a526346d2").m_Icon;
        public static void Add()
        {
            var IsekaiProtagonistTalentSelection = Resources.GetModBlueprint<BlueprintFeatureSelection>("IsekaiProtagonistTalentSelection");
            var SpecialPowerSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>("SpecialPowerSelection", bp => {
                bp.SetName("Special Power");
                bp.SetDescription("As you increase your level, you gain special powers that allow you to wreck your enemies more easily.");
                bp.m_Icon = Icon_ForetellAidBuff;
                bp.Ranks = 1;
                bp.IsClassFeature = true;

                // Special Powers are added in later
                bp.m_Features = new BlueprintFeatureReference[] { IsekaiProtagonistTalentSelection.ToReference<BlueprintFeatureReference>() };
                bp.m_AllFeatures = new BlueprintFeatureReference[] { IsekaiProtagonistTalentSelection.ToReference<BlueprintFeatureReference>() };
            });
        }
        public static void AddToSelection(BlueprintFeature feature)
        {
            var SpecialPowerSelection = Resources.GetModBlueprint<BlueprintFeatureSelection>("SpecialPowerSelection");
            SpecialPowerSelection.m_Features = SpecialPowerSelection.m_Features.AddToArray(feature.ToReference<BlueprintFeatureReference>());
            SpecialPowerSelection.m_AllFeatures = SpecialPowerSelection.m_AllFeatures.AddToArray(feature.ToReference<BlueprintFeatureReference>());
        }
    }
}
