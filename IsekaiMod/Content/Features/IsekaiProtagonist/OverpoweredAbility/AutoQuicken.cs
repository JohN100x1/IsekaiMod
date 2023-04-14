using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.UnitLogic.Abilities;
using TabletopTweaks.Core.Utilities;
using UnityEngine;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.OverpoweredAbility {

    internal class AutoQuicken {
        private static readonly Sprite Icon_QuickenSpell = BlueprintTools.GetBlueprint<BlueprintFeature>("ef7ece7bb5bb66a41b256976b27f424e").m_Icon;

        public static void Add() {

            var AutoQuickenFeature = TTCoreExtensions.CreateToggleBuffFeature(
                name: "AutoQuicken",
                displayName: "Overpowered Ability — Auto Quicken",
                description: "Every time you cast a spell, it becomes quickened, as though using the Quicken Spell feat.",
                icon: Icon_QuickenSpell,
                buffEffect: bp => {
                    bp.AddComponent<AutoMetamagic>(c => {
                        c.m_AllowedAbilities = AutoMetamagic.AllowedType.SpellOnly;
                        c.Metamagic = Metamagic.Quicken;
                    });
                });

            OverpoweredAbilitySelection.AddToAllSelection(AutoQuickenFeature);
        }
    }
}