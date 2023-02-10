using Kingmaker.Blueprints.Classes;
using Kingmaker.UnitLogic.FactLogic;
using TabletopTweaks.Core.Utilities;
using UnityEngine;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.SpecialPower {

    internal class MundaneAura {
        private static readonly Sprite Icon_BardLoreMaster = BlueprintTools.GetBlueprint<BlueprintFeature>("4bea694e79a87cd4d8c14fb91578059e").m_Icon;

        public static void Add() {
            var MundaneAura = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "MundaneAura", bp => {
                bp.SetName(IsekaiContext, "Mundane Aura");
                bp.SetDescription(IsekaiContext, "You emit a small aura of mundanity, giving you immunity to Sneak attack damage and {g|Encyclopedia:Critical}critical hits{/g}.");
                bp.m_Icon = Icon_BardLoreMaster;
                bp.AddComponent<AddImmunityToCriticalHits>();
                bp.AddComponent<AddImmunityToPrecisionDamage>();
            });

            SpecialPowerSelection.AddToSelection(MundaneAura);
        }
    }
}