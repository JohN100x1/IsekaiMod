using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.UnitLogic.Abilities;
using TabletopTweaks.Core.Utilities;
using UnityEngine;
using static TabletopTweaks.Core.MechanicsChanges.MetamagicExtention;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.OverpoweredAbility.TabletopTweaksBase {

    internal class AutoFlaring {
        private static readonly Sprite Icon_FlaringSpell = BlueprintTools.GetBlueprint<BlueprintFeature>("59e1695070ef481aa958d69cb370592b").m_Icon;

        public static void Add() {

            var AutoFlaringFeature = TTCoreExtensions.CreateToggleBuffFeature(
                name: "AutoFlaring",
                displayName: "Overpowered Ability — Auto Flaring",
                description: "Every time you cast a light, fire, or electricity spell, it causes the dazzling condition, as though using the Flaring Spell feat.",
                icon: Icon_FlaringSpell,
                buffEffect: bp => {
                    bp.AddComponent<AutoMetamagic>(c => {
                        c.m_AllowedAbilities = AutoMetamagic.AllowedType.SpellOnly;
                        c.Metamagic = (Metamagic)CustomMetamagic.Flaring;
                    });
                });

            OverpoweredAbilitySelection.AddToAllSelection(AutoFlaringFeature);
        }
    }
}