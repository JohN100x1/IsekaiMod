using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.FactLogic;
using UnityEngine;

namespace IsekaiMod.Content.Features.IsekaiProtagonist
{
    class IsekaiFastMovement
    {
        private static readonly Sprite Icon_FastMovement = Resources.GetBlueprint<BlueprintFeature>("d294a5dddd0120046aae7d4eb6cbc4fc").m_Icon;
        public static void Add()
        {
            var IsekaiFastMovement = Helpers.CreateFeature("IsekaiFastMovement", bp => {
                bp.SetName("Fast Movement");
                bp.SetDescription("At 8th level, you gain a +10 {g|Encyclopedia:Bonus}bonus{/g} to your {g|Encyclopedia:Speed}speed{/g}.");
                bp.m_Icon = Icon_FastMovement;
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.UntypedStackable;
                    c.Stat = StatType.Speed;
                    c.Value = 10;
                });
            });
        }
    }
}
