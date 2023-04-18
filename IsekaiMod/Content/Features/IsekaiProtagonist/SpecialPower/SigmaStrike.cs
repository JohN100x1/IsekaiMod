using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using TabletopTweaks.Core.Utilities;
using UnityEngine;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.SpecialPower {

    internal class SigmaStrike {
        private static readonly Sprite Icon_OracleRevelationMightyPebbleAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("2ae123c190625644e889517e15e8f640").m_Icon;

        public static void Add() {
            var SigmaStrike = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "SigmaStrike", bp => {
                bp.SetName(IsekaiContext, "Sigma Strike");
                bp.SetDescription(IsekaiContext, "Your critical threat range is increased by 2.");
                bp.m_Icon = Icon_OracleRevelationMightyPebbleAbility;
                bp.AddComponent<WeaponCriticalEdgeIncreaseStackable>(c => {
                    c.Value = 2;
                });
            });
            SpecialPowerSelection.AddToSelection(SigmaStrike);
        }
    }
}