using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;

namespace IsekaiMod.Changes.Features.IsekaiProtagonist.EdgeLord
{
    class ExtraStrikeII
    {
        public static void Add()
        {
            var ExtraStrikeI = Resources.GetModBlueprint<BlueprintFeature>("ExtraStrikeI");

            // Feature
            var Icon_Extra_Strike = AssetLoader.LoadInternal("Features", "ICON_EXTRA_STRIKE.png");
            var ExtraStrikeII = Helpers.CreateBlueprint<BlueprintFeature>("ExtraStrikeII", bp => {
                bp.SetName("Extra Strike II");
                bp.SetDescription("You get 2 additional {g|Encyclopedia:Attack}attacks{/g} per {g|Encyclopedia:Combat_Round}round{/g}.");
                bp.m_Icon = Icon_Extra_Strike;
                bp.AddComponent<WeaponExtraAttack>(c => {
                    c.Number = 2;
                    c.Haste = false;
                });
                bp.AddComponent<RemoveFeatureOnApply>(c => {
                    c.m_Feature = ExtraStrikeI.ToReference<BlueprintUnitFactReference>();
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
        }
    }
}
