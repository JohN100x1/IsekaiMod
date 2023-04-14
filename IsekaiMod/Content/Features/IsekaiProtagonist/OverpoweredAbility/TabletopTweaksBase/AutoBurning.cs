using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.UnitLogic.Abilities;
using TabletopTweaks.Core.Utilities;
using UnityEngine;
using static TabletopTweaks.Core.MechanicsChanges.MetamagicExtention;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.OverpoweredAbility.TabletopTweaksBase {

    internal class AutoBurning {
        private static readonly Sprite Icon_BurningSpell = BlueprintTools.GetBlueprint<BlueprintFeature>("4732a4b7b53f46848ae34a9dae66dbb2").m_Icon;

        public static void Add() {

            var AutoBurningFeature = TTCoreExtensions.CreateToggleBuffFeature(
                name: "AutoBurning",
                displayName: "Overpowered Ability — Auto Burning",
                description: "Every time you cast a acid of fire spell, it causes acid or fire damage on the next round, as though using the Burning Spell feat.",
                icon: Icon_BurningSpell,
                buffEffect: bp => {
                    bp.AddComponent<AutoMetamagic>(c => {
                        c.m_AllowedAbilities = AutoMetamagic.AllowedType.SpellOnly;
                        c.Metamagic = (Metamagic)CustomMetamagic.Burning;
                    });
                });

            OverpoweredAbilitySelection.AddToAllSelection(AutoBurningFeature);
        }
    }
}