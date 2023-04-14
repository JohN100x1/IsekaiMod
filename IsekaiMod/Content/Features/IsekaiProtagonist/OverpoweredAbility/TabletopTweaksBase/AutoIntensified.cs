using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.UnitLogic.Abilities;
using TabletopTweaks.Core.Utilities;
using UnityEngine;
using static TabletopTweaks.Core.MechanicsChanges.MetamagicExtention;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.OverpoweredAbility.TabletopTweaksBase {

    internal class AutoIntensified {
        private static readonly Sprite Icon_IntensifiedSpell = BlueprintTools.GetBlueprint<BlueprintFeature>("b77d7b23bf6d46a5bf80da7ca9674e83").m_Icon;

        public static void Add() {

            var AutoIntensifiedFeature = TTCoreExtensions.CreateToggleBuffFeature(
                name: "AutoIntensified",
                displayName: "Overpowered Ability — Auto Intensified",
                description: "Every time you cast a spell, increase its maximum damage dice by 5, as though using the Intensified Spell feat.",
                icon: Icon_IntensifiedSpell,
                buffEffect: bp => {
                    bp.AddComponent<AutoMetamagic>(c => {
                        c.m_AllowedAbilities = AutoMetamagic.AllowedType.SpellOnly;
                        c.Metamagic = (Metamagic)CustomMetamagic.Intensified;
                    });
                });

            OverpoweredAbilitySelection.AddToAllSelection(AutoIntensifiedFeature);
        }
    }
}