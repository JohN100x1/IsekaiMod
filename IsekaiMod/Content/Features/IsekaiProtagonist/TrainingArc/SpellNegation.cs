using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Components;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.TrainingArc
{
    class SpellNegation
    {
        public static void Add()
        {
            var Icon_SpellResistance = Resources.GetBlueprint<BlueprintAbility>("0a5ddfbcfb3989543ac7c936fc256889").m_Icon;
            var SpellNegation = Helpers.CreateBlueprint<BlueprintFeature>("SpellNegation", bp => {
                bp.SetName("Spell Negation");
                bp.SetDescription("After extensive studying of spells, you gain spell resistance equal to 10 + twice your character level.");
                bp.AddComponent<AddSpellResistance>(c => {
                    c.Value = new ContextValue()
                    {
                        ValueType = ContextValueType.Rank,
                        ValueRank = AbilityRankType.StatBonus
                    };
                });
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.StatBonus;
                    c.m_BaseValueType = ContextRankBaseValueType.CharacterLevel;
                    c.m_Progression = ContextRankProgression.DoublePlusBonusValue;
                    c.m_StepLevel = 10;
                });
                bp.m_Icon = Icon_SpellResistance;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.ReapplyOnLevelUp = true;
            });
        }
    }
}
