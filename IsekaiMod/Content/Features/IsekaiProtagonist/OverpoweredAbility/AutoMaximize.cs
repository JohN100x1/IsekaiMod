using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.UnitLogic.Abilities;
using TabletopTweaks.Core.Utilities;
using UnityEngine;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.OverpoweredAbility {

    internal class AutoMaximize {
        private static readonly Sprite Icon_MaximizeSpell = BlueprintTools.GetBlueprint<BlueprintFeature>("7f2b282626862e345935bbea5e66424b").m_Icon;

        public static void Add() {

            var AutoMaximizeFeature = TTCoreExtensions.CreateToggleBuffFeature(
                name: "AutoMaximize",
                displayName: "Overpowered Ability — Auto Maximize",
                description: "Every time you cast a spell, it becomes maximized, as though using the Maximize Spell feat.",
                icon: Icon_MaximizeSpell,
                buffEffect: bp => {
                    bp.AddComponent<AutoMetamagic>(c => {
                        c.m_AllowedAbilities = AutoMetamagic.AllowedType.SpellOnly;
                        c.Metamagic = Metamagic.Maximize;
                    });
                });

            OverpoweredAbilitySelection.AddToAllSelection(AutoMaximizeFeature);
        }
    }
}