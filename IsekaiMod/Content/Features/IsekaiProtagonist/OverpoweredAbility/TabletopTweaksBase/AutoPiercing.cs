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

    internal class AutoPiercing {
        private const string Name = "Overpowered Ability — Auto Piercing";
        private const string Description = "Every time you cast a spell against a target, "
            + "it treats the spell resistance of the target as 5 lower than its actual SR, "
            + "as though using the Piercing Spell feat.";

        private static readonly Sprite Icon_PiercingSpell = BlueprintTools.GetBlueprint<BlueprintFeature>("fc6bc9b9c2e54bbba96e074070d3c5be").m_Icon;

        public static void Add() {
            var AutoPiercingBuff = ThingsNotHandledByTTTCore.CreateBuff("AutoPiercingBuff", bp => {
                bp.SetName(IsekaiContext, Name);
                bp.SetDescription(IsekaiContext, Description);
                bp.m_Icon = Icon_PiercingSpell;
                bp.AddComponent<AutoMetamagic>(c => {
                    c.m_AllowedAbilities = AutoMetamagic.AllowedType.SpellOnly;
                    c.Metamagic = (Metamagic)CustomMetamagic.Piercing;
                });
                bp.Stacking = StackingType.Replace;
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.StayOnDeath;
            });
            var AutoPiercingAbility = ThingsNotHandledByTTTCore.CreateActivatableAbility("AutoPiercingAbility", bp => {
                bp.SetName(IsekaiContext, Name);
                bp.SetDescription(IsekaiContext, Description);
                bp.m_Icon = Icon_PiercingSpell;
                bp.m_Buff = AutoPiercingBuff.ToReference<BlueprintBuffReference>();
            });
            var AutoPiercingFeature = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "AutoPiercingFeature", bp => {
                bp.SetName(IsekaiContext, Name);
                bp.SetDescription(IsekaiContext, Description);
                bp.m_Icon = Icon_PiercingSpell;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { AutoPiercingAbility.ToReference<BlueprintUnitFactReference>() };
                });
            });

            OverpoweredAbilitySelection.AddToSelection(AutoPiercingFeature);
        }
    }
}