using IsekaiMod.Utilities;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using TabletopTweaks.Core.Utilities;
using UnityEngine;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.SpecialPower {

    internal class MagicalAmplification {
        public static void Add() {
            string MagicalAmplificationDesc = "Any {g|Encyclopedia:Spell}spells{/g} dealing {g|Encyclopedia:Damage}damage{/g} now change their dice to d10, "
                + "if it was not d10 or greater. If it already was d10 or greater, instead the spell deals one additional point of damage per dice rolled.";
            Sprite Icon_TelekineticStrike = BlueprintTools.GetBlueprint<BlueprintAbility>("1a33199538c31a14db23318fdb6e10cb").m_Icon;

            var MagicalAmplificationFeature = TTCoreExtensions.CreateToggleBuffFeature(
                name: "MagicalAmplification",
                description: MagicalAmplificationDesc,
                icon: Icon_TelekineticStrike,
                buffEffect: bp => {
                    bp.AddComponent<PromoteSpellDices>(c => {
                        c.MinDice = Kingmaker.RuleSystem.DiceType.D10;
                        c.Bonus = 1;
                    });
                });
            SpecialPowerSelection.AddToSelection(MagicalAmplificationFeature);
        }
    }
}