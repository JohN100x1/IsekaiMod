using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Mechanics;

namespace IsekaiMod.Utilities
{
    internal static class Constants
    {
        internal static ContextDurationValue ZeroDuration = new()
        {
            Rate = DurationRate.Rounds,
            DiceType = DiceType.Zero,
            DiceCountValue = 0,
            BonusValue = 0,
            m_IsExtendable = true,
        };
    }
}
