using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.UnitLogic.Abilities;
using TabletopTweaks.Core.Utilities;
using UnityEngine;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.OverpoweredAbility {

    internal class AutoReach {
        private static readonly Sprite Icon_ReachSpell = BlueprintTools.GetBlueprint<BlueprintFeature>("46fad72f54a33dc4692d3b62eca7bb78").m_Icon;

        public static void Add() {

            var AutoReachFeature = TTCoreExtensions.CreateToggleBuffFeature(
                name: "AutoReach",
                displayName: "Overpowered Ability — Auto Reach",
                description: "Every time you cast a spell, it increases its range by one range category, as though using the Reach Spell feat.",
                icon: Icon_ReachSpell,
                buffEffect: bp => {
                    bp.AddComponent<AutoMetamagic>(c => {
                        c.m_AllowedAbilities = AutoMetamagic.AllowedType.SpellOnly;
                        c.Metamagic = Metamagic.Reach;
                    });
                });

            OverpoweredAbilitySelection.AddToAllSelection(AutoReachFeature);
        }
    }
}