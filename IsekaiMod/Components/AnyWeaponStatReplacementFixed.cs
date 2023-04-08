using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;

namespace IsekaiMod.Components {
    [AllowMultipleComponents]
    [ComponentName("Replace damage stat for weapon")]
    [AllowedOn(typeof(BlueprintUnitFact), false)]
    [TypeId("5701cdf3df1845a29ab74c21c3747747")]
    public class AnyWeaponDamageStatReplacementFixed : UnitFactComponentDelegate, IInitiatorRulebookHandler<RuleCalculateWeaponStats>, IRulebookHandler<RuleCalculateWeaponStats>, ISubscriber, IInitiatorRulebookSubscriber {

        public void OnEventAboutToTrigger(RuleCalculateWeaponStats evt) {
            ModifiableValueAttributeStat modifiableValueAttributeStat2 = (evt.DamageBonusStat != null) ? (evt.Initiator.Descriptor.Stats.GetStat(evt.DamageBonusStat.Value) as ModifiableValueAttributeStat) : null;
            bool flag = evt.Initiator.Descriptor.Stats.GetStat(this.Stat) is ModifiableValueAttributeStat modifiableValueAttributeStat && (modifiableValueAttributeStat2 == null || modifiableValueAttributeStat.Bonus > modifiableValueAttributeStat2.Bonus);
            if (flag) {
                evt.OverrideDamageBonusStat(Stat);
                evt.TwoHandedStatReplacement = true;

                // Fix: apply the 1.5x two-handed bonus on non-strength, non-dexterity damage stat
                if (Stat == StatType.Strength || Stat == StatType.Dexterity) return;
                if (evt.Weapon.HoldInTwoHands || (evt.SlotToInsert != null && evt.Weapon.ShouldHoldInTwoHands(evt.SlotToInsert))) {
                    evt.OverrideDamageBonusStatMultiplier(1.5f);
                }
            }
        }

        public void OnEventDidTrigger(RuleCalculateWeaponStats evt) {
        }

        public StatType Stat;
    }
}