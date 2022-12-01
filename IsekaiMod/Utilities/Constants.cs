using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Mechanics;

namespace IsekaiMod.Utilities
{
    internal static class Constants
    {
        public static readonly ContextDurationValue ZeroDuration = new()
        {
            Rate = DurationRate.Rounds,
            DiceType = DiceType.Zero,
            DiceCountValue = 0,
            BonusValue = 0,
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
        public static readonly ContextDiceValue ZeroDiceValue = new()
        {
            DiceType = DiceType.Zero,
            DiceCountValue = 0,
            BonusValue = 0,
        };
    }
}
