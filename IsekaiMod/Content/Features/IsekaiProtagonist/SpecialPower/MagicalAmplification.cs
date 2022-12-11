using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using UnityEngine;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.SpecialPower
{
    class MagicalAmplification
    {
        private static readonly Sprite Icon_TelekineticStrike = Resources.GetBlueprint<BlueprintFeature>("1a33199538c31a14db23318fdb6e10cb").m_Icon;
        public static void Add()
        {
            var MagicalAmplification = Helpers.CreateFeature("MagicalAmplification", bp => {
                bp.SetName("Magical Amplification");
                bp.SetDescription("Any {g|Encyclopedia:Spell}spells{/g} dealing {g|Encyclopedia:Damage}damage{/g} now change their dice to d12, if it was not d12 or greater. "
                    + "If it already was d12 or greater, instead the spell deals one additional point of damage per dice rolled.");
                bp.m_Icon = Icon_TelekineticStrike;
                bp.AddComponent<PromoteSpellDices>(c => {
                    c.MinDice = Kingmaker.RuleSystem.DiceType.D12;
                    c.Bonus = 1;
                });
            });
            SpecialPowerSelection.AddToSelection(MagicalAmplification);
        }
    }
}
