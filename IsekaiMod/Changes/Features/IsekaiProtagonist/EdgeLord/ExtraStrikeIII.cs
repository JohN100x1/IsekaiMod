using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;

namespace IsekaiMod.Changes.Features.IsekaiProtagonist.EdgeLord
{
    class ExtraStrikeIII
    {
        public static void Add()
        {
            var ExtraStrikeII = Resources.GetModBlueprint<BlueprintFeature>("ExtraStrikeII");

            // Feature
            var Icon_Extra_Strike = AssetLoader.LoadInternal("Features", "ICON_EXTRA_STRIKE.png");
            var ExtraStrikeIII = Helpers.CreateBlueprint<BlueprintFeature>("ExtraStrikeIII", bp => {
                bp.SetName("Extra Strike III");
                bp.SetDescription("You get 3 additional {g|Encyclopedia:Attack}attacks{/g} per {g|Encyclopedia:Combat_Round}round{/g}.");
                bp.m_Icon = Icon_Extra_Strike;
                bp.AddComponent<WeaponExtraAttack>(c => {
                    c.Number = 3;
                    c.Haste = false;
                });
                bp.AddComponent<RemoveFeatureOnApply>(c => {
                    c.m_Feature = ExtraStrikeII.ToReference<BlueprintUnitFactReference>();
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
        }
    }
}
