using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.UnitLogic.Abilities;
using TabletopTweaks.Core.Utilities;
using UnityEngine;
using static TabletopTweaks.Core.MechanicsChanges.MetamagicExtention;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.OverpoweredAbility.TabletopTweaksBase {

    internal class AutoRime {
        private static readonly Sprite Icon_RimeSpell = BlueprintTools.GetBlueprint<BlueprintFeature>("192b00c671a64c4c8643f7c18bd1542e").m_Icon;

        public static void Add() {

            var AutoRimeFeature = TTCoreExtensions.CreateToggleBuffFeature(
                name: "AutoRime",
                displayName: "Overpowered Ability — Auto Rime",
                description: "Every time you cast a cold spell, it entangles the target, as though using the Rime Spell feat.",
                icon: Icon_RimeSpell,
                buffEffect: bp => {
                    bp.AddComponent<AutoMetamagic>(c => {
                        c.m_AllowedAbilities = AutoMetamagic.AllowedType.SpellOnly;
                        c.Metamagic = (Metamagic)CustomMetamagic.Rime;
                    });
                });

            OverpoweredAbilitySelection.AddToAllSelection(AutoRimeFeature);
        }
    }
}