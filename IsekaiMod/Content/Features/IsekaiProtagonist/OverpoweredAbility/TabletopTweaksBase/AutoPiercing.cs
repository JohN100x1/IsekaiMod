using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.UnitLogic.Abilities;
using TabletopTweaks.Core.Utilities;
using UnityEngine;
using static TabletopTweaks.Core.MechanicsChanges.MetamagicExtention;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.OverpoweredAbility.TabletopTweaksBase {

    internal class AutoPiercing {
        private static readonly Sprite Icon_PiercingSpell = BlueprintTools.GetBlueprint<BlueprintFeature>("fc6bc9b9c2e54bbba96e074070d3c5be").m_Icon;

        public static void Add() {

            var AutoPiercingFeature = TTCoreExtensions.CreateToggleBuffFeature(
                name: "AutoPiercing",
                displayName: "Overpowered Ability — Auto Piercing",
                description: "Every time you cast a spell against a target, it treats the spell resistance of the target as 5 lower than its actual SR, as though using the Piercing Spell feat.",
                icon: Icon_PiercingSpell,
                buffEffect: bp => {
                    bp.AddComponent<AutoMetamagic>(c => {
                        c.m_AllowedAbilities = AutoMetamagic.AllowedType.SpellOnly;
                        c.Metamagic = (Metamagic)CustomMetamagic.Piercing;
                    });
                });

            AutoMetamagicSelection.AddToSelection(AutoPiercingFeature);
        }
    }
}