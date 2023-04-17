using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.UnitLogic.Abilities;
using TabletopTweaks.Core.Utilities;
using UnityEngine;
using static TabletopTweaks.Core.MechanicsChanges.MetamagicExtention;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.OverpoweredAbility.TabletopTweaksBase {

    internal class AutoSolidShadows {
        private static readonly Sprite Icon_SolidShadowsSpell = BlueprintTools.GetBlueprint<BlueprintFeature>("48cba171d3bc4042ae2a18d503816b50").m_Icon;

        public static void Add() {

            var AutoSolidShadowsFeature = TTCoreExtensions.CreateToggleBuffFeature(
                name: "AutoSolidShadows",
                displayName: "Overpowered Ability — Auto Solid Shadows",
                description: "Every time you cast a shadow spell, it becomes 20% more real, as though using the Solid Shadows Spell feat.",
                icon: Icon_SolidShadowsSpell,
                buffEffect: bp => {
                    bp.AddComponent<AutoMetamagic>(c => {
                        c.m_AllowedAbilities = AutoMetamagic.AllowedType.SpellOnly;
                        c.Metamagic = (Metamagic)CustomMetamagic.SolidShadows;
                    });
                });

            AutoMetamagicSelection.AddToSelection(AutoSolidShadowsFeature);
        }
    }
}