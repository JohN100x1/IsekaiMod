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
    class BodyStrengthening
    {
        public static void Add()
        {
            var Icon_IronBody = Resources.GetBlueprint<BlueprintAbility>("198fcc43490993f49899ed086fe723c1").m_Icon;
            var BodyStrengthening = Helpers.CreateBlueprint<BlueprintFeature>("BodyStrengthening", bp => {
                bp.SetName("Body Strengthening");
                bp.SetDescription("After extensive strengthening of your body, you gain {g|Encyclopedia:Damage_Reduction}DR{/g}/— equal to 10 + your character level.");
                bp.AddComponent<AddDamageResistancePhysical>(c => {
                    c.Value = new ContextValue()
                    {
                        ValueType = ContextValueType.Rank,
                        ValueRank = AbilityRankType.StatBonus
                    };
                });
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.StatBonus;
                    c.m_BaseValueType = ContextRankBaseValueType.CharacterLevel;
                    c.m_Progression = ContextRankProgression.BonusValue;
                    c.m_StepLevel = 10;
                });
                bp.m_Icon = Icon_IronBody;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.ReapplyOnLevelUp = true;
            });
        }
    }
}
