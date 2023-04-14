using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.UnitLogic.Abilities;
using TabletopTweaks.Core.Utilities;
using UnityEngine;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.OverpoweredAbility {

    internal class AutoSelective {
        private static readonly Sprite Icon_SelectiveSpell = BlueprintTools.GetBlueprint<BlueprintFeature>("85f3340093d144dd944fff9a9adfd2f2").m_Icon;

        public static void Add() {

            var AutoSelectiveFeature = TTCoreExtensions.CreateToggleBuffFeature(
                name: "AutoSelective",
                displayName: "Overpowered Ability — Auto Selective",
                description: "Every time you cast a spell, you can exclude targets from the effects of your spell, as though using the Selective Spell feat.",
                icon: Icon_SelectiveSpell,
                buffEffect: bp => {
                    bp.AddComponent<AutoMetamagic>(c => {
                        c.m_AllowedAbilities = AutoMetamagic.AllowedType.SpellOnly;
                        c.Metamagic = Metamagic.Selective;
                    });
                });

            OverpoweredAbilitySelection.AddToAllSelection(AutoSelectiveFeature);
        }
    }
}