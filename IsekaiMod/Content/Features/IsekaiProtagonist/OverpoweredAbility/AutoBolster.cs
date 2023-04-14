using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.UnitLogic.Abilities;
using TabletopTweaks.Core.Utilities;
using UnityEngine;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.OverpoweredAbility {

    internal class AutoBolster {
        private static readonly Sprite Icon_BolsterSpell = BlueprintTools.GetBlueprint<BlueprintFeature>("fbf5d9ce931f47f3a0c818b3f8ef8414").m_Icon;

        public static void Add() {

            var AutoBolsterFeature = TTCoreExtensions.CreateToggleBuffFeature(
                name: "AutoBolster",
                displayName: "Overpowered Ability — Auto Bolster",
                description: "Every time you cast a spell, it becomes bolstered, as though using the Bolster Spell feat.",
                icon: Icon_BolsterSpell,
                buffEffect: bp => {
                    bp.AddComponent<AutoMetamagic>(c => {
                        c.m_AllowedAbilities = AutoMetamagic.AllowedType.SpellOnly;
                        c.Metamagic = Metamagic.Bolstered;
                    });
                });

            OverpoweredAbilitySelection.AddToAllSelection(AutoBolsterFeature);
        }
    }
}