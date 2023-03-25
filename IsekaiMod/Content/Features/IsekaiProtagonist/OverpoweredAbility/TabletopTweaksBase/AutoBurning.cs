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
using static TabletopTweaks.Core.MechanicsChanges.MetamagicExtention;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.OverpoweredAbility.TabletopTweaksBase {

    internal class AutoBurning {
        private const string Name = "Overpowered Ability — Auto Burning";
        private const string Description = "Every time you cast a acid of fire spell, it causes acid or fire damage on the next round, as though using the Burning Spell feat.";

        private static readonly Sprite Icon_BurningSpell = BlueprintTools.GetBlueprint<BlueprintFeature>("4732a4b7b53f46848ae34a9dae66dbb2").m_Icon;

        public static void Add() {
            var AutoBurningBuff = ThingsNotHandledByTTTCore.CreateBuff("AutoBurningBuff", bp => {
                bp.SetName(IsekaiContext, Name);
                bp.SetDescription(IsekaiContext, Description);
                bp.m_Icon = Icon_BurningSpell;
                bp.AddComponent<AutoMetamagic>(c => {
                    c.m_AllowedAbilities = AutoMetamagic.AllowedType.SpellOnly;
                    c.Metamagic = (Metamagic)CustomMetamagic.Burning;
                });
                bp.Stacking = StackingType.Replace;
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.StayOnDeath;
            });
            var AutoBurningAbility = ThingsNotHandledByTTTCore.CreateActivatableAbility("AutoBurningAbility", bp => {
                bp.SetName(IsekaiContext, Name);
                bp.SetDescription(IsekaiContext, Description);
                bp.m_Icon = Icon_BurningSpell;
                bp.m_Buff = AutoBurningBuff.ToReference<BlueprintBuffReference>();
            });
            var AutoBurningFeature = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "AutoBurningFeature", bp => {
                bp.SetName(IsekaiContext, Name);
                bp.SetDescription(IsekaiContext, Description);
                bp.m_Icon = Icon_BurningSpell;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { AutoBurningAbility.ToReference<BlueprintUnitFactReference>() };
                });
            });

            OverpoweredAbilitySelection.AddToSelection(AutoBurningFeature);
        }
    }
}