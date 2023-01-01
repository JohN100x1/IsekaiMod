using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.Enums;
using UnityEngine;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.SpecialPower
{
    class OmegaStrike
    {
        private static readonly Sprite Icon_LethalStance = BlueprintTools.GetBlueprint<BlueprintFeature>("e4450dd9c06dc034fb7c0c08abcc202b").m_Icon;
        public static void Add()
        {
            var OmegaStrike = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext,"OmegaStrike", bp => {
                bp.SetName(IsekaiContext, "Omega Strike");
                bp.SetDescription(IsekaiContext, "Any {g|Encyclopedia:Attack}attacks{/g} you make have their {g|Encyclopedia:Damage}damage{/g} multiplier increased by 1 (×2 becomes ×3, for example).");
                bp.m_Icon = Icon_LethalStance;
                bp.AddComponent<AttackTypeCriticalMultiplierIncrease>(c => {
                    c.Type = WeaponRangeType.Melee;
                    c.AdditionalMultiplier = 1;
                });
                bp.AddComponent<AttackTypeCriticalMultiplierIncrease>(c => {
                    c.Type = WeaponRangeType.Ranged;
                    c.AdditionalMultiplier = 1;
                });
            });
            SpecialPowerSelection.AddToSelection(OmegaStrike);
        }
    }
}
