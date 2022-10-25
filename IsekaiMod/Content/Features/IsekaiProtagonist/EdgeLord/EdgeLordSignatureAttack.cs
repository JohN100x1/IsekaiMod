using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Components;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.EdgeLord
{
    class EdgeLordSignatureAttack
    {
        public static void Add()
        {
            var Icon_SwordSaintWeaponMastery = Resources.GetBlueprint<BlueprintFeature>("5b31af13868166d4c9bb452f19277f19").m_Icon;
            var EdgeLordSignatureAttack = Helpers.CreateBlueprint<BlueprintFeature>("EdgeLordSignatureAttack", bp => {
                bp.SetName("Signature Attack");
                bp.SetDescription("At 4th level, the Edge Lord gains a luck bonus to {g|Encyclopedia:BAB}attack{/g} and damage rolls equal to their character level.");
                bp.m_Icon = Icon_SwordSaintWeaponMastery;
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Luck;
                    c.Stat = StatType.AdditionalAttackBonus;
                    c.Value = new ContextValue()
                    {
                        ValueType = ContextValueType.Rank,
                        ValueRank = AbilityRankType.StatBonus
                    };
                });
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Luck;
                    c.Stat = StatType.AdditionalDamage;
                    c.Value = new ContextValue()
                    {
                        ValueType = ContextValueType.Rank,
                        ValueRank = AbilityRankType.StatBonus
                    };
                });
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.StatBonus;
                    c.m_BaseValueType = ContextRankBaseValueType.CharacterLevel;
                });
                bp.IsClassFeature = true;
                bp.ReapplyOnLevelUp = true;
            });
        }
    }
}
