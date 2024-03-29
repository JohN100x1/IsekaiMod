﻿using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.UnitLogic.Mechanics.Components;
using TabletopTweaks.Core.Utilities;
using UnityEngine;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.OverpoweredAbility {

    internal class MetaLuck {
        private static readonly Sprite Icon_Fortune = BlueprintTools.GetBlueprint<BlueprintAbility>("eaf7077a8ff35644883df6d4f7b2084c").m_Icon;

        public static void Add() {

            const string MetaLuckDesc = "Everyone mistakes you for a prodigal genius, treating every action you make as a calculated move "
                + "in your 1000 year plan. Enemies tremble in fear as meet you, hallucinating a universe-sized gap between them your power level."
                + "\nBenefit: You always take the higher of two d20 rolls. Enemies that attack you take the lower of two d20 rolls for one round.";

            var MetaLuckDebuff = TTCoreExtensions.CreateBuff("MetaLuckDebuff", bp => {
                bp.SetName(IsekaiContext, "Meta Luck (Debuff)");
                bp.SetDescription(IsekaiContext, "This creature takes the lower of two d20 rolls.");
                bp.m_Icon = Icon_Fortune;
                bp.AddComponent<ModifyD20>(c => {
                    c.Rule = RuleType.All;
                    c.RollsAmount = 1;
                });
                bp.Stacking = StackingType.Replace;
                bp.IsClassFeature = true;
            });

            var MetaLuckFeature = TTCoreExtensions.CreateToggleBuffFeature(
                name: "MetaLuck",
                displayName: "Overpowered Ability — Meta Luck",
                description: MetaLuckDesc,
                displayNameBuff: "Meta Luck",
                descriptionBuff: "This character always takes the higher of two d20 rolls.",
                icon: Icon_Fortune,
                buffEffect: bp => {
                    bp.AddComponent<ModifyD20>(c => {
                        c.Rule = RuleType.All;
                        c.RollsAmount = 1;
                        c.TakeBest = true;
                    });
                    bp.AddComponent<AddTargetBeforeAttackRollTrigger>(c => {
                        c.ActionsOnAttacker = ActionFlow.DoSingle<ContextActionApplyBuff>(c => {
                            c.m_Buff = MetaLuckDebuff.ToReference<BlueprintBuffReference>();
                            c.DurationValue = Values.Duration.OneRound;
                        });
                        c.ActionOnSelf = ActionFlow.DoNothing();
                    });
                });

            OverpoweredAbilitySelection.AddToSelection(MetaLuckFeature);
        }
    }
}