using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.UnitLogic.FactLogic;
using UnityEngine;

namespace IsekaiMod.Content.Features.IsekaiProtagonist
{
    class TrueMainCharacter
    {
        private static readonly Sprite Icon_PowerOfFaithTier1Feature = Resources.GetBlueprint<BlueprintFeature>("6a585dce1d94c9b4c8cf95dede6b0568").m_Icon;
        public static void Add()
        {
            var TrueMainCharacter = Helpers.CreateBlueprint<BlueprintFeature>("TrueMainCharacter", bp => {
                bp.SetName("True Main Character");
                bp.SetDescription("You are the true main character of this world. Your health cannot go below 1 HP.\n"
                    + "Your attacks ignore {g|Encyclopedia:Damage_Reduction}damage reduction{/g}. "
                    + "The {g|Encyclopedia:Spell}spells{/g} you cast ignore {g|Encyclopedia:Spell_Resistance}spell resistance{/g} and spell immunity.");
                bp.m_Icon = Icon_PowerOfFaithTier1Feature;
                bp.AddComponent<IgnoreSpellImmunity>();
                bp.AddComponent<IgnoreSpellResistanceForSpells>();
                bp.AddComponent<IgnoreDamageReductionOnAttack>();
                bp.AddComponent<UnitHealthGuard>(c => { c.HealthPercent = 0; });
                bp.IsClassFeature = true;
            });
        }
    }
}
