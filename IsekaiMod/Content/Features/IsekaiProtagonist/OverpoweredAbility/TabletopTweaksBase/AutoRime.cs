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

    internal class AutoRime {
        private const string Name = "Overpowered Ability — Auto Rime";
        private const string Description = "Every time you cast a cold spell, it entangles the target, as though using the Rime Spell feat.";

        private static readonly Sprite Icon_RimeSpell = BlueprintTools.GetBlueprint<BlueprintFeature>("192b00c671a64c4c8643f7c18bd1542e").m_Icon;

        public static void Add() {
            var AutoRimeBuff = TTCoreExtensions.CreateBuff("AutoRimeBuff", bp => {
                bp.SetName(IsekaiContext, Name);
                bp.SetDescription(IsekaiContext, Description);
                bp.m_Icon = Icon_RimeSpell;
                bp.AddComponent<AutoMetamagic>(c => {
                    c.m_AllowedAbilities = AutoMetamagic.AllowedType.SpellOnly;
                    c.Metamagic = (Metamagic)CustomMetamagic.Rime;
                });
                bp.Stacking = StackingType.Replace;
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.StayOnDeath;
            });
            var AutoRimeAbility = TTCoreExtensions.CreateActivatableAbility("AutoRimeAbility", bp => {
                bp.SetName(IsekaiContext, Name);
                bp.SetDescription(IsekaiContext, Description);
                bp.m_Icon = Icon_RimeSpell;
                bp.m_Buff = AutoRimeBuff.ToReference<BlueprintBuffReference>();
            });
            var AutoRimeFeature = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "AutoRimeFeature", bp => {
                bp.SetName(IsekaiContext, Name);
                bp.SetDescription(IsekaiContext, Description);
                bp.m_Icon = Icon_RimeSpell;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { AutoRimeAbility.ToReference<BlueprintUnitFactReference>() };
                });
            });

            OverpoweredAbilitySelection.AddToAllSelection(AutoRimeFeature);
        }
    }
}