using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.EntitySystem;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.PubSubSystem;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Buffs.Components;
using Kingmaker.UnitLogic.Mechanics;
using UnityEngine;

namespace IsekaiMod.Components {

    [TypeId("ef3cfeb920ad4483a7ab34d00f006bf4")]
    [ComponentName("Add stat bonus if owner does not have any Facts")]
    [AllowedOn(typeof(BlueprintBuff), false)]
    [AllowMultipleComponents]
    public class AddStatBonusIfNotHasFact : UnitBuffComponentDelegate, IUnitGainFactHandler, IUnitSubscriber, ISubscriber, IUnitLostFactHandler {
        public ModifierDescriptor Descriptor;
        public StatType Stat;
        public ContextValue Value;

        [SerializeField]
        public BlueprintUnitFactReference[] m_CheckedFacts;

        public ReferenceArrayProxy<BlueprintUnitFact, BlueprintUnitFactReference> CheckedFacts {
            get {
                return m_CheckedFacts;
            }
        }

        public override void OnTurnOn() {
            Update();
        }

        public override void OnTurnOff() {
            Cancel();
        }

        public bool ShouldApplyBonus() {
            foreach (BlueprintUnitFact blueprint in CheckedFacts) {
                if (Owner.HasFact(blueprint)) {
                    return false;
                }
            }
            return true;
        }

        public void Update() {
            if (ShouldApplyBonus()) {
                int value = Value.Calculate(Context);
                Owner.Stats.GetStat(Stat).AddModifierUnique(value, Runtime, Descriptor);
                return;
            }
            Cancel();
        }

        public void Cancel() {
            ModifiableValue stat = Owner.Stats.GetStat(Stat);
            if (stat == null) {
                return;
            }
            stat.RemoveModifiersFrom(Runtime);
        }

        public void HandleUnitGainFact(EntityFact fact) {
            if (fact.Blueprint is BlueprintUnitFact blueprintUnitFact && CheckedFacts.HasReference(blueprintUnitFact)) {
                Update();
            }
        }

        public void HandleUnitLostFact(EntityFact fact) {
            if (fact.Blueprint is BlueprintUnitFact blueprintUnitFact && CheckedFacts.HasReference(blueprintUnitFact)) {
                Update();
            }
        }
    }
}