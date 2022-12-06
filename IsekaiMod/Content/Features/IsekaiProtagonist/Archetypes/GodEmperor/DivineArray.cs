using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Components;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.GodEmperor
{
    class DivineArray
    {
        public static void Add()
        {
            var Icon_DivineArray = AssetLoader.LoadInternal("Features", "ICON_ENERGY_ARRAY.png");
            var DivineArray = Helpers.CreateFeature("DivineArray", bp => {
                bp.SetName("Divine Array");
                bp.SetDescription("At 3rd level, the God Emperor gains resistance to acid, cold, electricity, fire, and sonic equal to 10 + twice their character level.");
                bp.m_Icon = Icon_DivineArray;
                bp.AddComponent<AddDamageResistanceEnergy>(c => {
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
                bp.ReapplyOnLevelUp = true;
            });
        }
    }
}
