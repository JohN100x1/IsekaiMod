using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Components;

namespace IsekaiMod.Changes.Features.IsekaiProtagonist
{
    class GodEmporerPlotArmor
    {
        public static void Add()
        {
            var Icon_EdictOfImpenetrableFortress = Resources.GetBlueprint<BlueprintAbility>("d7741c08ccf699e4a8a8f8ab2ed345f8").m_Icon;
            var GodEmporerPlotArmor = Helpers.CreateBlueprint<BlueprintFeature>("GodEmporerPlotArmor", bp => {
                bp.SetName("Godly Plot Armor");
                bp.SetDescription("The God Emporer gains a luck bonus to {g|Encyclopedia:Armor_Class}AC{/g} and all {g|Encyclopedia:Saving_Throw}saving throws{/g} equal to twice their character level.");
                bp.m_DescriptionShort = Helpers.CreateString("PlotArmor.DescriptionShort", "The God Emporer gains a luck bonus to {g|Encyclopedia:Armor_Class}AC{/g} and all {g|Encyclopedia:Saving_Throw}saving throws{/g} equal to twice their character level.");
                bp.m_Icon = Icon_EdictOfImpenetrableFortress;
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Luck;
                    c.Stat = StatType.AC;
                    c.Value = new ContextValue()
                    {
                        ValueType = ContextValueType.Rank,
                        ValueRank = AbilityRankType.StatBonus
                    };
                });
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Luck;
                    c.Stat = StatType.SaveFortitude;
                    c.Value = new ContextValue()
                    {
                        ValueType = ContextValueType.Rank,
                        ValueRank = AbilityRankType.StatBonus
                    };
                });
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Luck;
                    c.Stat = StatType.SaveReflex;
                    c.Value = new ContextValue()
                    {
                        ValueType = ContextValueType.Rank,
                        ValueRank = AbilityRankType.StatBonus
                    };
                });
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Luck;
                    c.Stat = StatType.SaveWill;
                    c.Value = new ContextValue()
                    {
                        ValueType = ContextValueType.Rank,
                        ValueRank = AbilityRankType.StatBonus
                    };
                });
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.StatBonus;
                    c.m_BaseValueType = ContextRankBaseValueType.CharacterLevel;
                    c.m_Progression = ContextRankProgression.MultiplyByModifier;
                    c.m_StepLevel = 2;
                });
                bp.IsClassFeature = true;
                bp.ReapplyOnLevelUp = true;
            });
        }
    }
}
