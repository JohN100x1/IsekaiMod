using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Designers.Mechanics.Buffs;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.FactLogic;
using UnityEngine;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;
using Kingmaker.Blueprints.Classes;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.SpecialPower
{
    class BetaStrike
    {
        private static readonly Sprite Icon_ArcaneWeaponSpeed = BlueprintTools.GetBlueprint<BlueprintActivatableAbility>("85742dd6788c6914f96ddc4628b23932").m_Icon;
        public static void Add()
        {
            var BetaStrike = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext,"BetaStrike", bp => {
                bp.SetName(IsekaiContext, "Beta Strike");
                bp.SetDescription(IsekaiContext, "You get an additional {g|Encyclopedia:Attack}attack{/g} per {g|Encyclopedia:Combat_Round}round{/g} but take a –4 penalty to damage rolls.");
                bp.m_Icon = Icon_ArcaneWeaponSpeed;
                bp.AddComponent<BuffExtraAttack>(c => {
                    c.Number = 1;
                    c.Haste = false;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Penalty;
                    c.Stat = StatType.AdditionalDamage;
                    c.Value = -4;
                });
            });
            SpecialPowerSelection.AddToSelection(BetaStrike);
        }
    }
}
