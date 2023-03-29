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

    internal class AutoSolidShadows {
        private const string Name = "Overpowered Ability — Auto Solid Shadows";
        private const string Description = "Every time you cast a shadow spell, it becomes 20% more real, as though using the Solid Shadows Spell feat.";

        private static readonly Sprite Icon_SolidShadowsSpell = BlueprintTools.GetBlueprint<BlueprintFeature>("48cba171d3bc4042ae2a18d503816b50").m_Icon;

        public static void Add() {
            var AutoSolidShadowsBuff = ThingsNotHandledByTTTCore.CreateBuff("AutoSolidShadowsBuff", bp => {
                bp.SetName(IsekaiContext, Name);
                bp.SetDescription(IsekaiContext, Description);
                bp.m_Icon = Icon_SolidShadowsSpell;
                bp.AddComponent<AutoMetamagic>(c => {
                    c.m_AllowedAbilities = AutoMetamagic.AllowedType.SpellOnly;
                    c.Metamagic = (Metamagic)CustomMetamagic.SolidShadows;
                });
                bp.Stacking = StackingType.Replace;
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.StayOnDeath;
            });
            var AutoSolidShadowsAbility = ThingsNotHandledByTTTCore.CreateActivatableAbility("AutoSolidShadowsAbility", bp => {
                bp.SetName(IsekaiContext, Name);
                bp.SetDescription(IsekaiContext, Description);
                bp.m_Icon = Icon_SolidShadowsSpell;
                bp.m_Buff = AutoSolidShadowsBuff.ToReference<BlueprintBuffReference>();
            });
            var AutoSolidShadowsFeature = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "AutoSolidShadowsFeature", bp => {
                bp.SetName(IsekaiContext, Name);
                bp.SetDescription(IsekaiContext, Description);
                bp.m_Icon = Icon_SolidShadowsSpell;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { AutoSolidShadowsAbility.ToReference<BlueprintUnitFactReference>() };
                });
            });

            OverpoweredAbilitySelection.AddToAllSelection(AutoSolidShadowsFeature);
        }
    }
}