using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.UnitLogic.Abilities;
using TabletopTweaks.Core.Utilities;
using UnityEngine;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.OverpoweredAbility {

    internal class AutoExtend {
        private static readonly Sprite Icon_ExtendSpell = BlueprintTools.GetBlueprint<BlueprintFeature>("f180e72e4a9cbaa4da8be9bc958132ef").m_Icon;

        public static void Add() {

            var AutoExtendFeature = TTCoreExtensions.CreateToggleBuffFeature(
                name: "AutoExtend",
                displayName: "Overpowered Ability — Auto Extend",
                description: "Every time you cast a spell, it becomes extended, as though using the Extend Spell feat.",
                icon: Icon_ExtendSpell,
                buffEffect: bp => {
                    bp.AddComponent<AutoMetamagic>(c => {
                        c.m_AllowedAbilities = AutoMetamagic.AllowedType.SpellOnly;
                        c.Metamagic = Metamagic.Extend;
                    });
                });

            OverpoweredAbilitySelection.AddToAllSelection(AutoExtendFeature);
        }
    }
}