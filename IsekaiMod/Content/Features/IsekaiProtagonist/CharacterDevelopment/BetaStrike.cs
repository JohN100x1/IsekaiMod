using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Buffs;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.FactLogic;
using UnityEngine;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.CharacterDevelopment
{
    class BetaStrike
    {
        private static readonly Sprite Icon_ArcaneWeaponSpeed = Resources.GetBlueprint<BlueprintActivatableAbility>("85742dd6788c6914f96ddc4628b23932").m_Icon;
        public static void Add()
        {
            var BetaStrike = Helpers.CreateBlueprint<BlueprintFeature>("BetaStrike", bp => {
                bp.SetName("Beta Strike");
                bp.SetDescription("You get an additional {g|Encyclopedia:Attack}attack{/g} per {g|Encyclopedia:Combat_Round}round{/g} but take a –4 penalty to damage rolls.");
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
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
            CharacterDevelopmentSelection.AddToSelection(BetaStrike);
        }
    }
}
