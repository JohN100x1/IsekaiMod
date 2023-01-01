using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.FactLogic;
using UnityEngine;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.EdgeLord
{
    class EdgeLordFastMovement
    {
        private static readonly Sprite Icon_FastMovement = BlueprintTools.GetBlueprint<BlueprintFeature>("d294a5dddd0120046aae7d4eb6cbc4fc").m_Icon;
        public static void Add()
        {
            var EdgeLordFastMovement = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext ,"EdgeLordFastMovement", bp => {
                bp.SetName(IsekaiContext, "Very Fast Movement");
                bp.SetDescription(IsekaiContext, "At 7th level, you gain an +20 {g|Encyclopedia:Bonus}bonus{/g} to your {g|Encyclopedia:Speed}speed{/g}.");
                bp.m_Icon = Icon_FastMovement;
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.UntypedStackable;
                    c.Stat = StatType.Speed;
                    c.Value = 20;
                });
                bp.ReapplyOnLevelUp = true;
            });
        }
    }
}
