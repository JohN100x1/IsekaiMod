using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.UnitLogic.Abilities;
using TabletopTweaks.Core.Utilities;
using UnityEngine;
using static TabletopTweaks.Core.MechanicsChanges.MetamagicExtention;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.OverpoweredAbility.TabletopTweaksBase {

    internal class AutoEncouraging {
        private static readonly Sprite Icon_EncouragingSpell = BlueprintTools.GetBlueprint<BlueprintFeature>("392608e8033a409ab96afdfbf315e028").m_Icon;

        public static void Add() {

            var AutoEncouragingFeature = TTCoreExtensions.CreateToggleBuffFeature(
                name: "AutoEncouraging",
                displayName: "Overpowered Ability — Auto Encouraging",
                description: "Every time you cast a spell, increase its morale bonus by 1, as though using the Encouraging Spell feat.",
                icon: Icon_EncouragingSpell,
                buffEffect: bp => {
                    bp.AddComponent<AutoMetamagic>(c => {
                        c.m_AllowedAbilities = AutoMetamagic.AllowedType.SpellOnly;
                        c.Metamagic = (Metamagic)CustomMetamagic.Encouraging;
                    });
                });

            AutoMetamagicSelection.AddToSelection(AutoEncouragingFeature);
        }
    }
}