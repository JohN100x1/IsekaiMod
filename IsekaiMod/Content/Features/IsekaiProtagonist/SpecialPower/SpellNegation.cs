using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Components;
using UnityEngine;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.SpecialPower
{
    class SpellNegation
    {
        private static readonly Sprite Icon_SpellResistance = Resources.GetBlueprint<BlueprintAbility>("0a5ddfbcfb3989543ac7c936fc256889").m_Icon;
        public static void Add()
        {
            var SpellNegationBuff = Helpers.CreateBuff("SpellNegationBuff", bp => {
                bp.SetName("Spell Negation");
                bp.SetDescription("You gain spell resistance equal to 10 + twice your character level.");
                bp.m_Icon = Icon_SpellResistance;
                bp.AddComponent<AddSpellResistance>(c => {
                    c.Value = Values.ContextRankValue(AbilityRankType.StatBonus);
                });
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.StatBonus;
                    c.m_BaseValueType = ContextRankBaseValueType.CharacterLevel;
                    c.m_Progression = ContextRankProgression.DoublePlusBonusValue;
                    c.m_StepLevel = 10;
                });
                bp.Stacking = StackingType.Replace;
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.StayOnDeath;
            });
            var SpellNegationAbility = Helpers.CreateActivatableAbility("SpellNegationAbility", bp => {
                bp.SetName("Spell Negation");
                bp.SetDescription("You gain spell resistance equal to 10 + twice your character level.");
                bp.m_Icon = Icon_SpellResistance;
                bp.m_Buff = SpellNegationBuff.ToReference<BlueprintBuffReference>();
            });
            var SpellNegationFeature = Helpers.CreateFeature("SpellNegationFeature", bp => {
                bp.SetName("Spell Negation");
                bp.SetDescription("After extensive studying of spells, you gain spell resistance equal to 10 + twice your character level.");
                bp.m_Icon = Icon_SpellResistance;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { SpellNegationAbility.ToReference<BlueprintUnitFactReference>() };
                });
            });

            SpecialPowerSelection.AddToSelection(SpellNegationFeature);
        }
    }
}
