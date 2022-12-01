using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Designers.Mechanics.Buffs;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using UnityEngine;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.EdgeLord
{
    class ExtraStrike
    {
        private static readonly Sprite Icon_Extra_Strike = Resources.GetBlueprint<BlueprintAbility>("3e1a13fdca87e9c49b2fac4556e5a948").m_Icon;
        public static void Add()
        {
            var ExtraStrike1 = Helpers.CreateFeature("ExtraStrike1", bp => {
                bp.SetName("Extra Strike I");
                bp.SetDescription("You gain additional attacks based on your level.\n"
                    + "At 5th level and every 5 levels thereafter (10th, 15th, and 20th level), you gain 1 additional {g|Encyclopedia:Attack}attack{/g}.");
                bp.m_Icon = Icon_Extra_Strike;
                bp.AddComponent<BuffExtraAttack>(c => {
                    c.Number = 1;
                    c.Haste = false;
                });
            });
            var ExtraStrike2 = Helpers.CreateFeature("ExtraStrike2", bp => {
                bp.SetName("Extra Strike II");
                bp.SetDescription("You gain additional attacks based on your level.\n"
                    + "At 5th level and every 5 levels thereafter (10th, 15th, and 20th level), you gain 1 additional {g|Encyclopedia:Attack}attack{/g}.");
                bp.m_Icon = Icon_Extra_Strike;
                bp.AddComponent<BuffExtraAttack>(c => {
                    c.Number = 2;
                    c.Haste = false;
                });
                bp.AddComponent<RemoveFeatureOnApply>(c => {
                    c.m_Feature = ExtraStrike1.ToReference<BlueprintUnitFactReference>();
                });
            });
            var ExtraStrike3 = Helpers.CreateFeature("ExtraStrike3", bp => {
                bp.SetName("Extra Strike III");
                bp.SetDescription("You gain additional attacks based on your level.\n"
                    + "At 5th level and every 5 levels thereafter (10th, 15th, and 20th level), you gain 1 additional {g|Encyclopedia:Attack}attack{/g}.");
                bp.m_Icon = Icon_Extra_Strike;
                bp.AddComponent<BuffExtraAttack>(c => {
                    c.Number = 3;
                    c.Haste = false;
                });
                bp.AddComponent<RemoveFeatureOnApply>(c => {
                    c.m_Feature = ExtraStrike2.ToReference<BlueprintUnitFactReference>();
                });
            });
            var ExtraStrike4 = Helpers.CreateFeature("ExtraStrike4", bp => {
                bp.SetName("Extra Strike IV");
                bp.SetDescription("You gain additional attacks based on your level.\n"
                    + "At 5th level and every 5 levels thereafter (10th, 15th, and 20th level), you gain 1 additional {g|Encyclopedia:Attack}attack{/g}.");
                bp.m_Icon = Icon_Extra_Strike;
                bp.AddComponent<BuffExtraAttack>(c => {
                    c.Number = 4;
                    c.Haste = false;
                });
                bp.AddComponent<RemoveFeatureOnApply>(c => {
                    c.m_Feature = ExtraStrike3.ToReference<BlueprintUnitFactReference>();
                });
            });
        }
    }
}
