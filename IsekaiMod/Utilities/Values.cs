using Kingmaker.Blueprints;
using Kingmaker.Enums;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Properties;

namespace IsekaiMod.Utilities
{
    internal static class Values
    {
        internal static class Duration
        {
            public static readonly ContextDurationValue Zero = new()
            {
                Rate = DurationRate.Rounds,
                DiceType = DiceType.Zero,
                DiceCountValue = 0,
                BonusValue = 0,
                m_IsExtendable = true,
            };
            public static readonly ContextDurationValue OneRound = new()
            {
                Rate = DurationRate.Rounds,
                DiceType = DiceType.Zero,
                DiceCountValue = 0,
                BonusValue = 1,
                m_IsExtendable = true,
            };
            public static readonly ContextDurationValue OneDay = new()
            {
                Rate = DurationRate.Hours,
                DiceType = DiceType.Zero,
                DiceCountValue = 0,
                BonusValue = 24,
                m_IsExtendable = true,
            };
        }
        internal static class Dice
        {
            public static readonly ContextDiceValue Zero = new()
            {
                DiceType = DiceType.Zero,
                DiceCountValue = 0,
                BonusValue = 0,
            };
            public static readonly ContextDiceValue One = new()
            {
                DiceType = DiceType.Zero,
                DiceCountValue = 0,
                BonusValue = 1,
            };
        }
        public static ContextValue CreateContextRankValue(AbilityRankType rankType, int value = 0)
        {
            return new ContextValue()
            {
                ValueType = ContextValueType.Rank,
                ValueRank = rankType,
                Value = value
            };
        }
        public static ContextValue CreateContextSharedValue(AbilitySharedValue sharedType)
        {
            return new ContextValue()
            {
                ValueType = ContextValueType.Shared,
                ValueShared = sharedType
            };
        }
        public static ContextValue CreateContextTargetPropertyValue(UnitProperty unitProperty)
        {
            return new ContextValue()
            {
                ValueType = ContextValueType.TargetProperty,
                Property = unitProperty
            };
        }
        public static ContextValue CreateContextCasterCustomPropertyValue(BlueprintUnitProperty unitProperty)
        {
            return new ContextValue()
            {
                ValueType = ContextValueType.CasterCustomProperty,
                m_CustomProperty = unitProperty.ToReference<BlueprintUnitPropertyReference>()
            };
        }
    }
}
