using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.UnitLogic.FactLogic;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.Deathsnatcher {

    internal class DeathsnatcherPoisonSting {
        private static readonly BlueprintFeature DeathsnatcherPoisonFeature = BlueprintTools.GetBlueprint<BlueprintFeature>("9547e5db05fa6f143a1867c93b258fe0");

        public static void Add() {
            var DeathsnatcherPoisonSting = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "DeathsnatcherPoisonSting", bp => {
                bp.SetName(IsekaiContext, "Deathsnatcher Poison Sting");
                bp.SetDescription(IsekaiContext, "The Deathsnatcher's sting attack becomes poisonous and inflicts 1d4 Constitution damage if the enemy fails a DC 28 Fortitude save.");
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { DeathsnatcherPoisonFeature.ToReference<BlueprintUnitFactReference>() };
                });
            });
        }
    }
}