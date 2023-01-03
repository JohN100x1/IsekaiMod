using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.Enums;
using UnityEngine;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.SpecialPower
{
    class OmegaStrike
    {
        private static readonly Sprite Icon_LethalStance = Resources.GetBlueprint<BlueprintFeature>("e4450dd9c06dc034fb7c0c08abcc202b").m_Icon;
        public static void Add()
        {
            var OmegaStrike = Helpers.CreateFeature("OmegaStrike", bp => {
                bp.SetName("Omega Strike");
                bp.SetDescription("Any {g|Encyclopedia:Attack}attacks{/g} you make have their {g|Encyclopedia:Damage}damage{/g} multiplier increased by 1 (×2 becomes ×3, for example).");
                bp.m_Icon = Icon_LethalStance;
                bp.AddComponent<AttackTypeCriticalMultiplierIncrease>(c => {
                    c.Type = WeaponRangeType.Melee;
                    c.AdditionalMultiplier = 1;
                });
                bp.AddComponent<AttackTypeCriticalMultiplierIncrease>(c => {
                    c.Type = WeaponRangeType.Ranged;
                    c.AdditionalMultiplier = 1;
                });
                bp.AddComponent<AttackTypeCriticalMultiplierIncrease>(c => {
                    c.Type = WeaponRangeType.Touch;
                    c.AdditionalMultiplier = 1;
                });
            });
            SpecialPowerSelection.AddToSelection(OmegaStrike);
        }
    }
}
