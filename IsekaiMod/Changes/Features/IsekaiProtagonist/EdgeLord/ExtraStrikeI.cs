using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;

namespace IsekaiMod.Changes.Features.IsekaiProtagonist.EdgeLord
{
    class ExtraStrikeI
    {
        public static void Add()
        {
            var Icon_Extra_Strike = AssetLoader.LoadInternal("Features", "ICON_EXTRA_STRIKE.png");
            var ExtraStrikeI = Helpers.CreateBlueprint<BlueprintFeature>("ExtraStrikeI", bp => {
                bp.SetName("Extra Strike I");
                bp.SetDescription("You get an additional {g|Encyclopedia:Attack}attack{/g} per {g|Encyclopedia:Combat_Round}round{/g}.");
                bp.m_Icon = Icon_Extra_Strike;
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
