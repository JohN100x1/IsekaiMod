using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Components;

namespace IsekaiMod.Content.Features.ExceptionalFeats
{
    class ExceptionalSummoning
    {
        public static void Add()
        {
            var Icon_ExceptionalSummoning = AssetLoader.LoadInternal("Features", "ICON_EXCEPTIONAL_SUMMONING.png");
            var ExceptionalSummoningSummonBuff = Helpers.CreateBuff("ExceptionalSummoningSummonBuff", bp => {
                bp.SetName("Exceptional Summon");
                bp.SetDescription("This creature gets a +10 bonus to maximum Hit Points per character level and a +1 bonus to Attack, damage, AC, and saving throws per character level.");
                bp.m_Icon = Icon_ExceptionalSummoning;
                bp.Stacking = StackingType.Replace;
                bp.IsClassFeature = true;
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Stat = StatType.HitPoints;
                    c.Value = new ContextValue()
                    {
                        ValueType = ContextValueType.Rank,
                        ValueRank = AbilityRankType.Default
                    };
                });
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Stat = StatType.AdditionalAttackBonus;
                    c.Value = new ContextValue()
                    {
                        ValueType = ContextValueType.Rank,
                        ValueRank = AbilityRankType.StatBonus
                    };
                });
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Stat = StatType.AdditionalDamage;
                    c.Value = new ContextValue()
                    {
                        ValueType = ContextValueType.Rank,
                        ValueRank = AbilityRankType.StatBonus
                    };
                });
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Stat = StatType.AC;
                    c.Value = new ContextValue()
                    {
                        ValueType = ContextValueType.Rank,
                        ValueRank = AbilityRankType.StatBonus
                    };
                });
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Stat = StatType.SaveFortitude;
                    c.Value = new ContextValue()
                    {
                        ValueType = ContextValueType.Rank,
                        ValueRank = AbilityRankType.StatBonus
                    };
                });
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Stat = StatType.SaveReflex;
                    c.Value = new ContextValue()
                    {
                        ValueType = ContextValueType.Rank,
                        ValueRank = AbilityRankType.StatBonus
                    };
                });
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Stat = StatType.SaveWill;
                    c.Value = new ContextValue()
                    {
                        ValueType = ContextValueType.Rank,
                        ValueRank = AbilityRankType.StatBonus
                    };
                });
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.Default;
                    c.m_BaseValueType = ContextRankBaseValueType.CharacterLevel;
                    c.m_Progression = ContextRankProgression.MultiplyByModifier;
                    c.m_StepLevel = 10;
                });
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.StatBonus;
                    c.m_BaseValueType = ContextRankBaseValueType.CharacterLevel;
                    c.m_Progression = ContextRankProgression.AsIs;
                });
            });
            var ExceptionalSummoningBuff = Helpers.CreateBuff("ExceptionalSummoningBuff", bp => {
                bp.SetName("Exceptional Summoning");
                bp.SetDescription("Your summoned creatures a +10 bonus to maximum Hit Points per character level and a +1 bonus to Attack, damage, AC, and saving throws per character level.");
                bp.m_Icon = Icon_ExceptionalSummoning;
                bp.Stacking = StackingType.Replace;
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.StayOnDeath | BlueprintBuff.Flags.HiddenInUi;
            });
            var ExceptionalSummoningAbility = Helpers.CreateBlueprint<BlueprintActivatableAbility>("ExceptionalSummoningAbility", bp => {
                bp.SetName("Exceptional Summoning");
                bp.SetDescription("Your summoned creatures get a +10 bonus to maximum Hit Points per character level and a +1 bonus to Attack, damage, AC, and saving throws per character level.");
                bp.m_Icon = Icon_ExceptionalSummoning;
                bp.m_Buff = ExceptionalSummoningBuff.ToReference<BlueprintBuffReference>();
                bp.Group = ActivatableAbilityGroup.None;
                bp.WeightInGroup = 1;
                bp.IsOnByDefault = true;
                bp.DeactivateImmediately = true;
                bp.ActivationType = AbilityActivationType.Immediately;
            });
            var ExceptionalSummoningFeature = Helpers.CreateFeature("ExceptionalSummoningFeature", bp => {
                bp.SetName("Exceptional Summoning");
                bp.SetDescription("Your summoned creatures get a +10 bonus to maximum Hit Points per character level and a +1 bonus to Attack, damage, AC, and saving throws per character level.");
                bp.m_Icon = Icon_ExceptionalSummoning;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { ExceptionalSummoningAbility.ToReference<BlueprintUnitFactReference>() };
                });
                bp.ReapplyOnLevelUp = true;
            });
            ExceptionalSummoningBuff.AddComponent<OnSpawnBuff>(c => {
                c.m_IfHaveFact = ExceptionalSummoningFeature.ToReference<BlueprintFeatureReference>();
                c.m_buff = ExceptionalSummoningSummonBuff.ToReference<BlueprintBuffReference>();
                c.CheckDescriptor = true;
                c.SpellDescriptor = SpellDescriptor.Summoning;
                c.IsInfinity = true;
            });

            ExceptionalFeatSelection.AddToSelection(ExceptionalSummoningFeature);
        }
        public static BlueprintFeature Get()
        {
            return Resources.GetModBlueprint<BlueprintFeature>("ExceptionalSummoningFeature");
        }
        public static BlueprintFeatureReference GetReference()
        {
            return Get().ToReference<BlueprintFeatureReference>();
        }
    }
}
