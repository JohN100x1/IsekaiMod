using IsekaiMod.Utilities;
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

    internal class AutoReach {
        private static readonly Sprite Icon_ReachSpell = BlueprintTools.GetBlueprint<BlueprintFeature>("46fad72f54a33dc4692d3b62eca7bb78").m_Icon;

        public static void Add() {
            var AutoReachBuff = ThingsNotHandledByTTTCore.CreateBuff("AutoReachBuff", bp => {
                bp.SetName(IsekaiContext, "Overpowered Ability — Auto Reach");
                bp.SetDescription(IsekaiContext, "Every time you cast a spell, it increases its range by one range category, as though using the Reach Spell feat.");
                bp.m_Icon = Icon_ReachSpell;
                bp.AddComponent<AutoMetamagic>(c => {
                    c.m_AllowedAbilities = AutoMetamagic.AllowedType.SpellOnly;
                    c.Metamagic = Metamagic.Reach;
                });
                bp.Stacking = StackingType.Replace;
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.StayOnDeath;
            });
            var AutoReachAbility = ThingsNotHandledByTTTCore.CreateActivatableAbility("AutoReachAbility", bp => {
                bp.SetName(IsekaiContext, "Overpowered Ability — Auto Reach");
                bp.SetDescription(IsekaiContext, "Every time you cast a spell, it increases its range by one range category, as though using the Reach Spell feat.");
                bp.m_Icon = Icon_ReachSpell;
                bp.m_Buff = AutoReachBuff.ToReference<BlueprintBuffReference>();
            });
            var AutoReachFeature = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "AutoReachFeature", bp => {
                bp.SetName(IsekaiContext, "Overpowered Ability — Auto Reach");
                bp.SetDescription(IsekaiContext, "Every time you cast a spell, it increases its range by one range category, as though using the Reach Spell feat.");
                bp.m_Icon = Icon_ReachSpell;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { AutoReachAbility.ToReference<BlueprintUnitFactReference>() };
                });
            });

            OverpoweredAbilitySelection.AddToSelection(AutoReachFeature);
        }
    }
}