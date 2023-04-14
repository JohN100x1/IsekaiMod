using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.UnitLogic.Abilities;
using TabletopTweaks.Core.Utilities;
using UnityEngine;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.OverpoweredAbility {

    internal class AutoEmpower {
        private static readonly Sprite Icon_EmpowerSpell = BlueprintTools.GetBlueprint<BlueprintFeature>("a1de1e4f92195b442adb946f0e2b9d4e").m_Icon;

        public static void Add() {

            var AutoEmpowerFeature = TTCoreExtensions.CreateToggleBuffFeature(
                name: "AutoEmpower",
                displayName: "Overpowered Ability — Auto Empower",
                description: "Every time you cast a spell, it becomes empowered, as though using the Empower Spell feat.",
                icon: Icon_EmpowerSpell,
                buffEffect: bp => {
                    bp.AddComponent<AutoMetamagic>(c => {
                        c.m_AllowedAbilities = AutoMetamagic.AllowedType.SpellOnly;
                        c.Metamagic = Metamagic.Empower;
                    });
                });

            OverpoweredAbilitySelection.AddToAllSelection(AutoEmpowerFeature);
        }
    }
}