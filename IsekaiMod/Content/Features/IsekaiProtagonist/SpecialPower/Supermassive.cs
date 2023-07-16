using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics.Components;
using TabletopTweaks.Core.Utilities;
using UnityEngine;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.SpecialPower {

    internal class Supermassive {
        private static readonly Sprite Icon_TricksterMicroscopicProportions = BlueprintTools.GetBlueprint<BlueprintAbility>("d6042abe75df262498b6021eb8cc07a5").m_Icon;

        public static void Add() {
            var Supermassive = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "Supermassive", bp => {
                bp.SetName(IsekaiContext, "Supermassive");
                bp.SetDescription(IsekaiContext, "You gain a size bonus to HP equal to your 10 times your Constitution modifier.");
                bp.m_Icon = Icon_TricksterMicroscopicProportions;
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Size;
                    c.Stat = StatType.HitPoints;
                    c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                    c.Multiplier = 10;
                });
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.StatBonus;
                    c.m_BaseValueType = ContextRankBaseValueType.StatBonus;
                    c.m_Stat = StatType.Constitution;
                });
                bp.AddComponent<RecalculateOnStatChange>(c => {
                    c.Stat = StatType.Constitution;
                });
            });

            SpecialPowerSelection.AddToSelection(Supermassive);
        }
    }
}