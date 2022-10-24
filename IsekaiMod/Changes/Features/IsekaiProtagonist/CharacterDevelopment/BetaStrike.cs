using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.UnitLogic.ActivatableAbilities;

namespace IsekaiMod.Changes.Features.IsekaiProtagonist.CharacterDevelopment
{
    class BetaStrike
    {
        public static void Add()
        {
            var Icon_ArcaneWeaponSpeed = Resources.GetBlueprint<BlueprintActivatableAbility>("85742dd6788c6914f96ddc4628b23932").m_Icon;
            var BetaStrike = Helpers.CreateBlueprint<BlueprintFeature>("BetaStrike", bp => {
                bp.SetName("Beta Strike");
                bp.SetDescription("You get an additional {g|Encyclopedia:Attack}attack{/g} per {g|Encyclopedia:Combat_Round}round{/g}.");
                bp.m_Icon = Icon_ArcaneWeaponSpeed;
                bp.AddComponent<WeaponExtraAttack>(c => {
                    c.Number = 1;
                    c.Haste = false;
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
        }
    }
}
