using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.Designers.Mechanics.Buffs;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.EdgeLord
{
    class ExtraStrike
    {
        public static void Add()
        {
            var Icon_Extra_Strike = AssetLoader.LoadInternal("Features", "ICON_EXTRA_STRIKE.png");
            var ExtraStrike1 = Helpers.CreateBlueprint<BlueprintFeature>("ExtraStrike1", bp => {
                bp.SetName("Extra Strike I");
                bp.SetDescription("You gain additional attacks based on your level.\n"
                    + "At 5th level, you have 1 additional {g|Encyclopedia:Attack}attack{/g}.\n"
                    + "At 10th level, you have 2 additional {g|Encyclopedia:Attack}attacks{/g}.\n"
                    + "At 15th level, you have 3 additional {g|Encyclopedia:Attack}attacks{/g}.");
            bp.m_Icon = Icon_Extra_Strike;
                bp.AddComponent<BuffExtraAttack>(c => {
                    c.Number = 1;
                    c.Haste = false;
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
            var ExtraStrike2 = Helpers.CreateBlueprint<BlueprintFeature>("ExtraStrike2", bp => {
                bp.SetName("Extra Strike II");
                bp.SetDescription("You gain additional attacks based on your level.\n"
                    + "At 5th level, you have 1 additional {g|Encyclopedia:Attack}attack{/g}.\n"
                    + "At 10th level, you have 2 additional {g|Encyclopedia:Attack}attacks{/g}.\n"
                    + "At 15th level, you have 3 additional {g|Encyclopedia:Attack}attacks{/g}.");
                bp.m_Icon = Icon_Extra_Strike;
                bp.AddComponent<BuffExtraAttack>(c => {
                    c.Number = 2;
                    c.Haste = false;
                });
                bp.AddComponent<RemoveFeatureOnApply>(c => {
                    c.m_Feature = ExtraStrike1.ToReference<BlueprintUnitFactReference>();
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
            var ExtraStrike3 = Helpers.CreateBlueprint<BlueprintFeature>("ExtraStrike3", bp => {
                bp.SetName("Extra Strike III");
                bp.SetDescription("You gain additional attacks based on your level.\n"
                    + "At 5th level, you have 1 additional {g|Encyclopedia:Attack}attack{/g}.\n"
                    + "At 10th level, you have 2 additional {g|Encyclopedia:Attack}attacks{/g}.\n"
                    + "At 15th level, you have 3 additional {g|Encyclopedia:Attack}attacks{/g}.");
                bp.m_Icon = Icon_Extra_Strike;
                bp.AddComponent<BuffExtraAttack>(c => {
                    c.Number = 3;
                    c.Haste = false;
                });
                bp.AddComponent<RemoveFeatureOnApply>(c => {
                    c.m_Feature = ExtraStrike2.ToReference<BlueprintUnitFactReference>();
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
        }
    }
}
