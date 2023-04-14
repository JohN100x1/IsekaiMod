﻿using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using TabletopTweaks.Core.Utilities;
using UnityEngine;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Mastermind {

    internal class MastermindQuickFooted {
        private static readonly Sprite Icon_ExpeditiousRetreat = BlueprintTools.GetBlueprint<BlueprintAbility>("4f8181e7a7f1d904fbaea64220e83379").m_Icon;

        public static void Add() {
            var MastermindQuickFooted = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "MastermindQuickFooted", bp => {
                bp.SetName(IsekaiContext, "Quick-Footed");
                bp.SetDescription(IsekaiContext, "At 15th level, you gain a competence {g|Encyclopedia:Bonus}bonus{/g} to your {g|Encyclopedia:Initiative}initiative{/g} "
                    + "{g|Encyclopedia:Check}checks{/g} equal to your {g|Encyclopedia:Intelligence}Intelligence{/g} modifier.");
                bp.m_Icon = Icon_ExpeditiousRetreat;
                bp.AddComponent<DerivativeStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Competence;
                    c.BaseStat = StatType.Intelligence;
                    c.DerivativeStat = StatType.Initiative;
                });
                bp.AddComponent<RecalculateOnStatChange>(c => {
                    c.Stat = StatType.Intelligence;
                });
            });
        }
    }
}