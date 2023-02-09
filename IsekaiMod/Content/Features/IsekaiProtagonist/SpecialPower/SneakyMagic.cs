using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.Designers.Mechanics.Prerequisites;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using TabletopTweaks.Core.Utilities;
using UnityEngine;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.SpecialPower {

    internal class SneakyMagic {
        private static readonly Sprite Icon_InvisibilityAlmostGreater = BlueprintTools.GetBlueprint<BlueprintAbility>("8dcb9c02148a704489948eaf84ab04bf").m_Icon;

        public static void Add() {
            var SneakyMagic = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "SneakyMagic", bp => {
                bp.SetName(IsekaiContext, "Sneaky Magic");
                bp.SetDescription(IsekaiContext, "You can add your sneak {g|Encyclopedia:Attack}attack{/g} {g|Encyclopedia:Damage}damage{/g} to any {g|Encyclopedia:Spell}spell{/g} that deals damage, "
                    + "if the targets are {g|Encyclopedia:Flat_Footed}flat-footed{/g}. This additional damage only applies to spells that deal hit point damage, and the additional damage "
                    + "is of the same type as the spell. If the spell allows a {g|Encyclopedia:Saving_Throw}saving throw{/g} to negate or halve the damage, it also negates or halves "
                    + "the sneak attack damage.");
                bp.m_Icon = Icon_InvisibilityAlmostGreater;
                bp.AddComponent<SurpriseSpells>();
                bp.AddComponent<PrerequisiteFullStatValue>(c => {
                    c.Stat = StatType.SneakAttack;
                    c.Value = 1;
                });
            });
            SpecialPowerSelection.AddToSelection(SneakyMagic);
        }
    }
}