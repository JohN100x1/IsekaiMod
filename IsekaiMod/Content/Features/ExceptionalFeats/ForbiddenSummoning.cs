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
    class ForbiddenSummoning
    {
        public static void Add()
        {
            var Icon_ForbiddenSummoning = AssetLoader.LoadInternal("Features", "ICON_FORBIDDEN_SUMMONING.png");
            var ForbiddenSummoningSummonBuff = Helpers.CreateBuff("ForbiddenSummoningSummonBuff", bp => {
                bp.SetName("Forbidden Summon");
                bp.SetDescription("This creature gains a +10 bonus to maximum Hit Points per character level and a +1 bonus to all attributes per character level.");
                bp.m_Icon = Icon_ForbiddenSummoning;
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
                    c.Stat = StatType.Strength;
                    c.Value = new ContextValue()
                    {
                        ValueType = ContextValueType.Rank,
                        ValueRank = AbilityRankType.StatBonus
                    };
                });
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Stat = StatType.Dexterity;
                    c.Value = new ContextValue()
                    {
                        ValueType = ContextValueType.Rank,
                        ValueRank = AbilityRankType.StatBonus
                    };
                });
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Stat = StatType.Constitution;
                    c.Value = new ContextValue()
                    {
                        ValueType = ContextValueType.Rank,
                        ValueRank = AbilityRankType.StatBonus
                    };
                });
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Stat = StatType.Intelligence;
                    c.Value = new ContextValue()
                    {
                        ValueType = ContextValueType.Rank,
                        ValueRank = AbilityRankType.StatBonus
                    };
                });
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Stat = StatType.Wisdom;
                    c.Value = new ContextValue()
                    {
                        ValueType = ContextValueType.Rank,
                        ValueRank = AbilityRankType.StatBonus
                    };
                });
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Stat = StatType.Charisma;
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
            var ForbiddenSummoningBuff = Helpers.CreateBuff("ForbiddenSummoningBuff", bp => {
                bp.SetName("Forbidden Summoning");
                bp.SetDescription("Your summoned creatures gain a +10 bonus to hit points per character level and a +1 bonus to all attributes per character level.");
                bp.m_Icon = Icon_ForbiddenSummoning;
                bp.Stacking = StackingType.Replace;
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.StayOnDeath | BlueprintBuff.Flags.HiddenInUi;
            });
            var ForbiddenSummoningAbility = Helpers.CreateBlueprint<BlueprintActivatableAbility>("ForbiddenSummoningAbility", bp => {
                bp.SetName("Forbidden Summoning");
                bp.SetDescription("Your summoned creatures gain a +10 bonus to hit points per character level and a +1 bonus to all attributes per character level.");
                bp.m_Icon = Icon_ForbiddenSummoning;
                bp.m_Buff = ForbiddenSummoningBuff.ToReference<BlueprintBuffReference>();
                bp.Group = ActivatableAbilityGroup.None;
                bp.WeightInGroup = 1;
                bp.IsOnByDefault = true;
                bp.DeactivateImmediately = true;
                bp.ActivationType = AbilityActivationType.Immediately;
            });
            var ForbiddenSummoningFeature = Helpers.CreateBlueprint<BlueprintFeature>("ForbiddenSummoningFeature", bp => {
                bp.SetName("Forbidden Summoning");
                bp.SetDescription("Your summoned creatures gain a +10 bonus to hit points per character level and a +1 bonus to all attributes per character level.");
                bp.m_Icon = Icon_ForbiddenSummoning;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { ForbiddenSummoningAbility.ToReference<BlueprintUnitFactReference>() };
                });
                bp.IsClassFeature = true;
                bp.ReapplyOnLevelUp = true;
            });
            ForbiddenSummoningBuff.AddComponent<OnSpawnBuff>(c => {
                c.m_IfHaveFact = ForbiddenSummoningFeature.ToReference<BlueprintFeatureReference>();
                c.m_buff = ForbiddenSummoningSummonBuff.ToReference<BlueprintBuffReference>();
                c.CheckDescriptor = true;
                c.SpellDescriptor = SpellDescriptor.Summoning;
                c.IsInfinity = true;
            });

            ExceptionalFeatSelection.AddToSelection(ForbiddenSummoningFeature);
        }
        public static BlueprintFeature Get()
        {
            return Resources.GetModBlueprint<BlueprintFeature>("ForbiddenSummoningFeature");
        }
        public static BlueprintFeatureReference GetReference()
        {
            return Get().ToReference<BlueprintFeatureReference>();
        }
    }
}
