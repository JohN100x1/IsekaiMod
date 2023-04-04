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

    internal class AutoExtend {
        private static readonly Sprite Icon_ExtendSpell = BlueprintTools.GetBlueprint<BlueprintFeature>("f180e72e4a9cbaa4da8be9bc958132ef").m_Icon;

        public static void Add() {
            var AutoExtendBuff = TTCoreExtensions.CreateBuff("AutoExtendBuff", bp => {
                bp.SetName(IsekaiContext, "Overpowered Ability — Auto Extend");
                bp.SetDescription(IsekaiContext, "Every time you cast a spell, it becomes extended, as though using the Extend Spell feat.");
                bp.m_Icon = Icon_ExtendSpell;
                bp.AddComponent<AutoMetamagic>(c => {
                    c.m_AllowedAbilities = AutoMetamagic.AllowedType.SpellOnly;
                    c.Metamagic = Metamagic.Extend;
                });
                bp.Stacking = StackingType.Replace;
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.StayOnDeath;
            });
            var AutoExtendAbility = TTCoreExtensions.CreateActivatableAbility("AutoExtendAbility", bp => {
                bp.SetName(IsekaiContext, "Overpowered Ability — Auto Extend");
                bp.SetDescription(IsekaiContext, "Every time you cast a spell, it becomes extended, as though using the Extend Spell feat.");
                bp.m_Icon = Icon_ExtendSpell;
                bp.m_Buff = AutoExtendBuff.ToReference<BlueprintBuffReference>();
            });
            var AutoExtendFeature = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "AutoExtendFeature", bp => {
                bp.SetName(IsekaiContext, "Overpowered Ability — Auto Extend");
                bp.SetDescription(IsekaiContext, "Every time you cast a spell, it becomes extended, as though using the Extend Spell feat.");
                bp.m_Icon = Icon_ExtendSpell;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { AutoExtendAbility.ToReference<BlueprintUnitFactReference>() };
                });
            });

            OverpoweredAbilitySelection.AddToAllSelection(AutoExtendFeature);
        }
    }
}