using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.Designers.Mechanics.Buffs;

namespace IsekaiMod.Changes.Features.IsekaiProtagonist.EdgeLord
{
    class ExtraStrikeIV
    {
        public static void Add()
        {
            var ExtraStrikeIII = Resources.GetModBlueprint<BlueprintFeature>("ExtraStrikeIII");

            // Feature
            var Icon_Extra_Strike = AssetLoader.LoadInternal("Features", "ICON_EXTRA_STRIKE.png");
            var ExtraStrikeIV = Helpers.CreateBlueprint<BlueprintFeature>("ExtraStrikeIV", bp => {
                bp.SetName("Extra Strike IV");
                bp.SetDescription("You gain additional attacks based on your level.\n"
                    + "At 3rd level, you have 1 additional {g|Encyclopedia:Attack}attack{/g}.\n"
                    + "At 7th level, you have 2 additional {g|Encyclopedia:Attack}attacks{/g}.\n"
                    + "At 13th level, you have 3 additional {g|Encyclopedia:Attack}attacks{/g}.\n"
                    + "At 19th level, you have 4 additional {g|Encyclopedia:Attack}attacks{/g}.");
                bp.m_Icon = Icon_Extra_Strike;
                bp.AddComponent<BuffExtraAttack>(c => {
                    c.Number = 4;
                    c.Haste = false;
                });
                bp.AddComponent<RemoveFeatureOnApply>(c => {
                    c.m_Feature = ExtraStrikeIII.ToReference<BlueprintUnitFactReference>();
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
        }
    }
}
