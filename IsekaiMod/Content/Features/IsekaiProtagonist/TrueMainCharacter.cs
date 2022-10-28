using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.UnitLogic.FactLogic;

namespace IsekaiMod.Content.Features.IsekaiProtagonist
{
    class TrueMainCharacter
    {
        public static void Add()
        {
            var Icon_TrueMainCharacter = AssetLoader.LoadInternal("Features", "ICON_TRUE_MAIN_CHARACTER.png");
            var TrueMainCharacter = Helpers.CreateBlueprint<BlueprintFeature>("TrueMainCharacter", bp => {
                bp.SetName("True Main Character");
                bp.SetDescription("You are the true main character of this world. Your health cannot go below 1 HP.\n"
                    + "Your attacks ignore {g|Encyclopedia:Damage_Reduction}damage reduction{/g}. "
                    + "The {g|Encyclopedia:Spell}spells{/g} you cast ignore {g|Encyclopedia:Spell_Resistance}spell resistance{/g} and spell immunity.");
                bp.m_Icon = Icon_TrueMainCharacter;
                bp.AddComponent<IgnoreSpellImmunity>();
                bp.AddComponent<IgnoreSpellResistanceForSpells>();
                bp.AddComponent<IgnoreDamageReductionOnAttack>();
                bp.AddComponent<UnitHealthGuard>(c => {
                    c.HealthPercent = 0;
                });
                bp.IsClassFeature = true;
            });
        }
    }
}
