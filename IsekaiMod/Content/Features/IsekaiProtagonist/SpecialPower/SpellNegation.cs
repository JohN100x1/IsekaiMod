﻿using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics.Components;
using TabletopTweaks.Core.Utilities;
using UnityEngine;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.SpecialPower {

    internal class SpellNegation {
        private static readonly Sprite Icon_SpellResistance = BlueprintTools.GetBlueprint<BlueprintAbility>("0a5ddfbcfb3989543ac7c936fc256889").m_Icon;

        public static void Add() {
            var SpellNegationBuff = TTCoreExtensions.CreateBuff("SpellNegationBuff", bp => {
                bp.SetName(IsekaiContext, "Spell Negation");
                bp.SetDescription(IsekaiContext, "You gain spell resistance equal to 10 + twice your character level.");
                bp.m_Icon = Icon_SpellResistance;
                bp.AddComponent<AddSpellResistance>(c => {
                    c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                });
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.StatBonus;
                    c.m_BaseValueType = ContextRankBaseValueType.CharacterLevel;
                    c.m_Progression = ContextRankProgression.DoublePlusBonusValue;
                    c.m_StepLevel = 10;
                });
                bp.Stacking = StackingType.Replace;
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.StayOnDeath;
            });
            var SpellNegationAbility = TTCoreExtensions.CreateActivatableAbility("SpellNegationAbility", bp => {
                bp.SetName(IsekaiContext, "Spell Negation");
                bp.SetDescription(IsekaiContext, "You gain spell resistance equal to 10 + twice your character level.");
                bp.m_Icon = Icon_SpellResistance;
                bp.m_Buff = SpellNegationBuff.ToReference<BlueprintBuffReference>();
            });
            var SpellNegationFeature = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "SpellNegationFeature", bp => {
                bp.SetName(IsekaiContext, "Spell Negation");
                bp.SetDescription(IsekaiContext, "After extensive studying of spells, you gain spell resistance equal to 10 + twice your character level.");
                bp.m_Icon = Icon_SpellResistance;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { SpellNegationAbility.ToReference<BlueprintUnitFactReference>() };
                });
            });

            SpecialPowerSelection.AddToSelection(SpellNegationFeature);
        }
    }
}