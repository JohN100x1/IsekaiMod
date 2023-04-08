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

    internal class AutoIntensified {
        private const string Name = "Overpowered Ability — Auto Intensified";
        private const string Description = "Every time you cast a spell, increase its maximum damage dice by 5, as though using the Intensified Spell feat.";

        private static readonly Sprite Icon_IntensifiedSpell = BlueprintTools.GetBlueprint<BlueprintFeature>("b77d7b23bf6d46a5bf80da7ca9674e83").m_Icon;

        public static void Add() {
            var AutoIntensifiedBuff = TTCoreExtensions.CreateBuff("AutoIntensifiedBuff", bp => {
                bp.SetName(IsekaiContext, Name);
                bp.SetDescription(IsekaiContext, Description);
                bp.m_Icon = Icon_IntensifiedSpell;
                bp.AddComponent<AutoMetamagic>(c => {
                    c.m_AllowedAbilities = AutoMetamagic.AllowedType.SpellOnly;
                    c.Metamagic = (Metamagic)CustomMetamagic.Intensified;
                });
                bp.Stacking = StackingType.Replace;
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.StayOnDeath;
            });
            var AutoIntensifiedAbility = TTCoreExtensions.CreateActivatableAbility("AutoIntensifiedAbility", bp => {
                bp.SetName(IsekaiContext, Name);
                bp.SetDescription(IsekaiContext, Description);
                bp.m_Icon = Icon_IntensifiedSpell;
                bp.m_Buff = AutoIntensifiedBuff.ToReference<BlueprintBuffReference>();
            });
            var AutoIntensifiedFeature = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "AutoIntensifiedFeature", bp => {
                bp.SetName(IsekaiContext, Name);
                bp.SetDescription(IsekaiContext, Description);
                bp.m_Icon = Icon_IntensifiedSpell;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { AutoIntensifiedAbility.ToReference<BlueprintUnitFactReference>() };
                });
            });

            OverpoweredAbilitySelection.AddToAllSelection(AutoIntensifiedFeature);
        }
    }
}