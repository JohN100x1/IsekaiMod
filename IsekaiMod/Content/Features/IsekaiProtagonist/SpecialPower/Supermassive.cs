using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Buffs.Components;
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
                bp.SetDescription(IsekaiContext, "You gain a size bonus to HP equal to your 20 times your Constitution modifier. "
                    + "You have fast healing equal to 5% of your max HP but a -30 penalty to AC.");
                bp.m_Icon = Icon_TricksterMicroscopicProportions;
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Size;
                    c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                });
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.StatBonus;
                    c.m_BaseValueType = ContextRankBaseValueType.BaseStat;
                    c.m_Stat = StatType.Constitution;
                    c.m_Progression = ContextRankProgression.MultiplyByModifier;
                    c.m_StepLevel = 20;
                });
                bp.AddComponent<RecalculateOnStatChange>(c => {
                    c.Stat = StatType.Constitution;
                });
                bp.AddComponent<AddEffectFastHealing>(c => {
                    c.Heal = 0;
                    c.Bonus = Values.CreateContextRankValue(AbilityRankType.Default);
                });
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.Default;
                    c.m_BaseValueType = ContextRankBaseValueType.BaseStat;
                    c.m_Stat = StatType.HitPoints;
                    c.m_Progression = ContextRankProgression.DivStep;
                    c.m_StepLevel = 20;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Penalty;
                    c.Value = -20;
                });
            });

            SpecialPowerSelection.AddToSelection(Supermassive);
        }
    }
}