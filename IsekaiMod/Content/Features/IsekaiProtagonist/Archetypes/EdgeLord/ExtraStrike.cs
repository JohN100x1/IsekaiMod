using IsekaiMod.Components;
using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using UnityEngine;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.EdgeLord
{
    class ExtraStrike
    {
        private static readonly Sprite Icon_Extra_Strike = Resources.GetBlueprint<BlueprintAbility>("3e1a13fdca87e9c49b2fac4556e5a948").m_Icon;
        public static void Add()
        {
            var ExtraStrike = Helpers.CreateFeature("ExtraStrike", bp => {
                bp.SetName("Extra Strike");
                bp.SetDescription("You gain additional attacks based on your level.\n"
                    + "At 5th level and every 5 levels thereafter (10th, 15th, and 20th level), you gain 1 additional {g|Encyclopedia:Attack}attack{/g}. "
                    + "This also applies to your off-hand weapon if you are wielding a second weapon.");
                bp.m_Icon = Icon_Extra_Strike;
                bp.AddComponent<AddExtraAttack>(c => {
                    c.Number = 1;
                });
                bp.AddComponent<AddExtraOffHandAttack>(c => {
                    c.Number = 1;
                });
                bp.Ranks = 20;
            });
        }
    }
}
