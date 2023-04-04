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

    internal class AutoSelective {
        private static readonly Sprite Icon_SelectiveSpell = BlueprintTools.GetBlueprint<BlueprintFeature>("85f3340093d144dd944fff9a9adfd2f2").m_Icon;

        public static void Add() {
            var AutoSelectiveBuff = TTCoreExtensions.CreateBuff("AutoSelectiveBuff", bp => {
                bp.SetName(IsekaiContext, "Overpowered Ability — Auto Selective");
                bp.SetDescription(IsekaiContext, "Every time you cast a spell, you can exclude targets from the effects of your spell, as though using the Selective Spell feat.");
                bp.m_Icon = Icon_SelectiveSpell;
                bp.AddComponent<AutoMetamagic>(c => {
                    c.m_AllowedAbilities = AutoMetamagic.AllowedType.SpellOnly;
                    c.Metamagic = Metamagic.Selective;
                });
                bp.Stacking = StackingType.Replace;
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.StayOnDeath;
            });
            var AutoSelectiveAbility = TTCoreExtensions.CreateActivatableAbility("AutoSelectiveAbility", bp => {
                bp.SetName(IsekaiContext, "Overpowered Ability — Auto Selective");
                bp.SetDescription(IsekaiContext, "Every time you cast a spell, you can exclude targets from the effects of your spell, as though using the Selective Spell feat.");
                bp.m_Icon = Icon_SelectiveSpell;
                bp.m_Buff = AutoSelectiveBuff.ToReference<BlueprintBuffReference>();
            });
            var AutoSelectiveFeature = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "AutoSelectiveFeature", bp => {
                bp.SetName(IsekaiContext, "Overpowered Ability — Auto Selective");
                bp.SetDescription(IsekaiContext, "Every time you cast a spell, you can exclude targets from the effects of your spell, as though using the Selective Spell feat.");
                bp.m_Icon = Icon_SelectiveSpell;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { AutoSelectiveAbility.ToReference<BlueprintUnitFactReference>() };
                });
            });

            OverpoweredAbilitySelection.AddToAllSelection(AutoSelectiveFeature);
        }
    }
}