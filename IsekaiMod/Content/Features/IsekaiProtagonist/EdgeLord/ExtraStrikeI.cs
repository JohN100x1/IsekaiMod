using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Buffs;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.EdgeLord
{
    class ExtraStrikeI
    {
        public static void Add()
        {
            var Icon_Extra_Strike = AssetLoader.LoadInternal("Features", "ICON_EXTRA_STRIKE.png");
            var ExtraStrikeI = Helpers.CreateBlueprint<BlueprintFeature>("ExtraStrikeI", bp => {
                bp.SetName("Extra Strike I");
                bp.SetDescription("You gain additional attacks based on your level.\n"
                    + "At 3rd level, you have 1 additional {g|Encyclopedia:Attack}attack{/g}.\n"
                    + "At 7th level, you have 2 additional {g|Encyclopedia:Attack}attacks{/g}.\n"
                    + "At 13th level, you have 3 additional {g|Encyclopedia:Attack}attacks{/g}.\n"
                    + "At 19th level, you have 4 additional {g|Encyclopedia:Attack}attacks{/g}.");
            bp.m_Icon = Icon_Extra_Strike;
                bp.AddComponent<BuffExtraAttack>(c => {
                    c.Number = 1;
                    c.Haste = false;
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
        }
    }
}
