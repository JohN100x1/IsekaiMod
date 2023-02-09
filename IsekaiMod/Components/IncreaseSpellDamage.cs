using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Mechanics;

namespace IsekaiMod.Components {

    [AllowMultipleComponents]
    [ComponentName("Increase spell damage")]
    [TypeId("35ca7b8440554218931bdee77ead0b92")]
    [AllowedOn(typeof(BlueprintUnitFact), false)]
    public class IncreaseSpellDamage : UnitFactComponentDelegate, IInitiatorRulebookHandler<RuleCalculateDamage>, IRulebookHandler<RuleCalculateDamage>, ISubscriber, IInitiatorRulebookSubscriber {
        public ContextValue DamageBonus;

        public void OnEventAboutToTrigger(RuleCalculateDamage evt) {
            if (evt.Reason.Ability == null) {
                return;
            }
            BaseDamage first = evt.DamageBundle.First;
            if (first == null) {
                return;
            }
            first.AddModifier(DamageBonus.Calculate(Context), Fact);
        }

        public void OnEventDidTrigger(RuleCalculateDamage evt) {
        }
    }
}