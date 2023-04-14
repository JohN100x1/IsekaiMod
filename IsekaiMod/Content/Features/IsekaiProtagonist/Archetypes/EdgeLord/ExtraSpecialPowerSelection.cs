using IsekaiMod.Content.Features.IsekaiProtagonist.SpecialPower;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using TabletopTweaks.Core.Utilities;
using UnityEngine;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.EdgeLord {

    static class ExtraSpecialPowerSelection {
        private static readonly Sprite Icon_ForetellAidBuff = BlueprintTools.GetBlueprint<BlueprintBuff>("faf473e3a977fd4428cd3f1a526346d2").m_Icon;
        public static void Add() {
            var ExtraSpecialPowerSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "ExtraSpecialPowerSelection", bp => {
                bp.SetName(IsekaiContext, "Extra Special Power");
                bp.SetDescription(IsekaiContext, "You gain an additional Special Power.");
                bp.m_Icon = Icon_ForetellAidBuff;
                bp.m_AllFeatures = SpecialPowerSelection.Get().m_AllFeatures;
            });

            SecretPowerSelection.AddToSelection(ExtraSpecialPowerSelection);
        }
    }
}