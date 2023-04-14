using IsekaiMod.Content.Features.IsekaiProtagonist.SpecialPower;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.UnitLogic.FactLogic;
using TabletopTweaks.Core.Utilities;
using UnityEngine;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist {
    static class ReleaseEnergy {
        private static readonly Sprite Icon_AngelfireApostleChannel = BlueprintTools.GetBlueprint<BlueprintFeature>("9d30d6cc7bfcda44aab7505f7ed3f933").m_Icon;
        public static void Add() {
            var IsekaiChannelPositiveEnergyRef = BlueprintTools.GetModBlueprintReference<BlueprintUnitFactReference>(IsekaiContext, "IsekaiChannelPositiveEnergy");
            var IsekaiChannelNegativeEnergyRef = BlueprintTools.GetModBlueprintReference<BlueprintUnitFactReference>(IsekaiContext, "IsekaiChannelNegativeEnergy");

            var ReleaseEnergy = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "ReleaseEnergy", bp => {
                bp.SetName(IsekaiContext, "Release Energy");
                bp.SetDescription(IsekaiContext, "The Isekai Protagonist is able to channel both positive energy and negative energy."
                    + "\nSo this what happens when you channel one percent of your power...");
                bp.m_Icon = Icon_AngelfireApostleChannel;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] {
                        IsekaiChannelPositiveEnergyRef,
                        IsekaiChannelNegativeEnergyRef
                    };
                });
            });
        }
    }
}
