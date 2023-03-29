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

    internal class AutoEmpower {
        private static readonly Sprite Icon_EmpowerSpell = BlueprintTools.GetBlueprint<BlueprintFeature>("a1de1e4f92195b442adb946f0e2b9d4e").m_Icon;

        public static void Add() {
            var AutoEmpowerBuff = ThingsNotHandledByTTTCore.CreateBuff("AutoEmpowerBuff", bp => {
                bp.SetName(IsekaiContext, "Overpowered Ability — Auto Empower");
                bp.SetDescription(IsekaiContext, "Every time you cast a spell, it becomes empowered, as though using the Empower Spell feat.");
                bp.m_Icon = Icon_EmpowerSpell;
                bp.AddComponent<AutoMetamagic>(c => {
                    c.m_AllowedAbilities = AutoMetamagic.AllowedType.SpellOnly;
                    c.Metamagic = Metamagic.Empower;
                });
                bp.Stacking = StackingType.Replace;
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.StayOnDeath;
            });
            var AutoEmpowerAbility = ThingsNotHandledByTTTCore.CreateActivatableAbility("AutoEmpowerAbility", bp => {
                bp.SetName(IsekaiContext, "Overpowered Ability — Auto Empower");
                bp.SetDescription(IsekaiContext, "Every time you cast a spell, it becomes empowered, as though using the Empower Spell feat.");
                bp.m_Icon = Icon_EmpowerSpell;
                bp.m_Buff = AutoEmpowerBuff.ToReference<BlueprintBuffReference>();
            });
            var AutoEmpowerFeature = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "AutoEmpowerFeature", bp => {
                bp.SetName(IsekaiContext, "Overpowered Ability — Auto Empower");
                bp.SetDescription(IsekaiContext, "Every time you cast a spell, it becomes empowered, as though using the Empower Spell feat.");
                bp.m_Icon = Icon_EmpowerSpell;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { AutoEmpowerAbility.ToReference<BlueprintUnitFactReference>() };
                });
            });

            OverpoweredAbilitySelection.AddToAllSelection(AutoEmpowerFeature);
        }
    }
}