using IsekaiMod.Components;
using IsekaiMod.Utilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using TabletopTweaks.Core.Utilities;
using UnityEngine;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.SpecialPower {

    internal class Reflect {
        private static readonly Sprite Icon_ShieldOfDawn = BlueprintTools.GetBlueprint<BlueprintAbility>("62888999171921e4dafb46de83f4d67d").m_Icon;

        public static void Add() {

            var ReflectFeature = TTCoreExtensions.CreateToggleBuffFeature(
                name: "Reflect",
                description: "You deal damage to enemies equal to the damage you receive.",
                icon: Icon_ShieldOfDawn,
                buffEffect: bp => {
                    bp.AddComponent<ReflectDamage>();
                });

            SpecialPowerSelection.AddToSelection(ReflectFeature);
        }
    }
}