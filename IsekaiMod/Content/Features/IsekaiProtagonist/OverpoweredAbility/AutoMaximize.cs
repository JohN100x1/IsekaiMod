﻿using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using TabletopTweaks.Core.Utilities;
using UnityEngine;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.OverpoweredAbility {

    internal class AutoMaximize {
        private static readonly Sprite Icon_MaximizeSpell = BlueprintTools.GetBlueprint<BlueprintFeature>("7f2b282626862e345935bbea5e66424b").m_Icon;

        public static void Add() {
            var AutoMaximizeBuff = ThingsNotHandledByTTTCore.CreateBuff("AutoMaximizeBuff", bp => {
                bp.SetName(IsekaiContext, "Overpowered Ability — Auto Maximize");
                bp.SetDescription(IsekaiContext, "Every time you cast a spell, it becomes maximized, as though using the Maximize Spell feat.");
                bp.m_Icon = Icon_MaximizeSpell;
                bp.AddComponent<AutoMetamagic>(c => {
                    c.m_AllowedAbilities = AutoMetamagic.AllowedType.SpellOnly;
                    c.Metamagic = Metamagic.Maximize;
                });
                bp.Stacking = StackingType.Replace;
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.StayOnDeath;
            });
            var AutoMaximizeAbility = ThingsNotHandledByTTTCore.CreateActivatableAbility("AutoMaximizeAbility", bp => {
                bp.SetName(IsekaiContext, "Overpowered Ability — Auto Maximize");
                bp.SetDescription(IsekaiContext, "Every time you cast a spell, it becomes maximized, as though using the Maximize Spell feat.");
                bp.m_Icon = Icon_MaximizeSpell;
                bp.m_Buff = AutoMaximizeBuff.ToReference<BlueprintBuffReference>();
            });
            var AutoMaximizeFeature = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "AutoMaximizeFeature", bp => {
                bp.SetName(IsekaiContext, "Overpowered Ability — Auto Maximize");
                bp.SetDescription(IsekaiContext, "Every time you cast a spell, it becomes maximized, as though using the Maximize Spell feat.");
                bp.m_Icon = Icon_MaximizeSpell;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { AutoMaximizeAbility.ToReference<BlueprintUnitFactReference>() };
                });
            });

            OverpoweredAbilitySelection.AddToAllSelection(AutoMaximizeFeature);
        }
    }
}