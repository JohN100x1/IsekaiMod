using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic;
using Kingmaker.Utility;
using System;

namespace IsekaiMod.Components {
    [ClassInfoBox("If Owner summons, it summons additional units")]
    [TypeId("d104b3fcf9094fae838ad3793767348c")]
    public class ExtraSummonCount : UnitFactComponentDelegate, ISubscriber, IGlobalSubscriber, ICalculateSummonUnitsCount {
        public int Count;
        public void HandleCalculateSummonUnitsCount(UnitEntityData unit, DiceType diceType, int diceCount, int diceBonus, ref int count) {
            if (unit != Owner) {
                return;
            }
            count += GetMaxStat();
        }
        public int GetMaxStat() {
            int intelligence = Owner.Stats.GetAttribute(StatType.Intelligence).Bonus;
            int wisdom = Owner.Stats.GetAttribute(StatType.Wisdom).Bonus;
            int charisma = Owner.Stats.GetAttribute(StatType.Charisma).Bonus;
            return Math.Max(intelligence, Math.Max(wisdom, charisma));
        }
    }
}