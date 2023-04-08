using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.Enums.Damage;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Mechanics.Components;
using System.Collections.Generic;

namespace IsekaiMod.Components {

    [ComponentName("Split Outgoing Damage")]
    [TypeId("3087b91778c1411a809a66524556c2e0")]
    [AllowedOn(typeof(BlueprintUnitFact), false)]
    public class SplitOutgoingDamage : UnitFactComponentDelegate, IAfterRulebookEventTriggerHandler<RulePrepareDamage>, IGlobalSubscriber {
        public DamageEnergyType Element;

        public void OnAfterRulebookEventTrigger(RulePrepareDamage evt) {
            if (evt.Reason.Fact == Fact || Fact is not IFactContextOwner) return;
            ApplyDamageSplit(evt);
        }

        private void ApplyDamageSplit(RulePrepareDamage evt) {
            List<EnergyDamage> toAdd = new List<EnergyDamage>();
            foreach (BaseDamage baseDamage in evt.DamageBundle) {
                if (baseDamage is EnergyDamage energyDamage && energyDamage.EnergyType == Element) { continue; }

                // Split Damage here
                if (baseDamage.Half) {
                    baseDamage.Durability *= 0.5f;
                } else {
                    baseDamage.Half.Set(true, Fact);
                }
                EnergyDamage newDamage = new EnergyDamage(baseDamage.Dice.ModifiedValue, Element);
                newDamage.CopyFrom(baseDamage);
                newDamage.SourceFact = Fact;
                toAdd.Add(newDamage);
            }
            foreach (EnergyDamage addedDamage in toAdd) {
                evt.Add(addedDamage);
            }
        }
    }
}