using Kingmaker.Blueprints.Classes;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.FactLogic;
using TabletopTweaks.Core.Utilities;
using UnityEngine;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist {

    internal class IsekaiFastMovement {
        private static readonly Sprite Icon_FastMovement = BlueprintTools.GetBlueprint<BlueprintFeature>("d294a5dddd0120046aae7d4eb6cbc4fc").m_Icon;

        public static void Add() {
            var IsekaiFastMovement = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiFastMovement", bp => {
                bp.SetName(IsekaiContext, "Fast Movement");
                bp.SetDescription(IsekaiContext, "At 8th level, you gain a +10 {g|Encyclopedia:Bonus}bonus{/g} to your {g|Encyclopedia:Speed}speed{/g}.");
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