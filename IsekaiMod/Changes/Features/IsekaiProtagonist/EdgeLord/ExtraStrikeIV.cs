using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;

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
                bp.SetDescription("You get 4 additional {g|Encyclopedia:Attack}attacks{/g} per {g|Encyclopedia:Combat_Round}round{/g}.");
                bp.m_Icon = Icon_Extra_Strike;
                bp.AddComponent<WeaponExtraAttack>(c => {
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
