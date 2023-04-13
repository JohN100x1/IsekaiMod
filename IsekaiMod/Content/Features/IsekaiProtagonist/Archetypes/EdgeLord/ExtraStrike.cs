using IsekaiMod.Components;
using Kingmaker.Blueprints.Classes;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using TabletopTweaks.Core.Utilities;
using UnityEngine;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.EdgeLord {

    internal class ExtraStrike {
        private static readonly Sprite Icon_Extra_Strike = BlueprintTools.GetBlueprint<BlueprintAbility>("3e1a13fdca87e9c49b2fac4556e5a948").m_Icon;

        public static void Add() {
            var ExtraStrike = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "ExtraStrike", bp => {
                bp.SetName(IsekaiContext, "Extra Strike");
                bp.SetDescription(IsekaiContext, "You gain additional attacks based on your level.\n"
                    + "At 5th level and every 5 levels thereafter (10th, 15th, and 20th level), you gain 1 additional {g|Encyclopedia:Attack}attack{/g}. "
                    + "This also applies to your off-hand weapon if you are wielding a second weapon.");
                bp.m_Icon = Icon_Extra_Strike;
                bp.AddComponent<AddExtraAttack>(c => {
                    c.Number = 1;
                });
                bp.AddComponent<AddExtraOffHandAttack>(c => {
                    c.Number = 1;
                });
                bp.Ranks = 20;
            });

            SecretPowerSelection.AddToSelection(ExtraStrike);
        }
    }
}