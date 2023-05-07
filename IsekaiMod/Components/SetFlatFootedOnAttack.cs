using Kingmaker.Blueprints;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.EntitySystem;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic.Mechanics;

namespace IsekaiMod.Components {
    [AllowMultipleComponents]
    [TypeId("ffa9f2123e7f4b949250ca3f1ae9aea0")]
    public class SetFlatFootedOnAttack : EntityFactComponentDelegate, IRulebookHandler<RuleAttackRoll>, IInitiatorRulebookHandler<RuleAttackRoll>, ISubscriber, IInitiatorRulebookSubscriber {

        public void OnEventAboutToTrigger(RuleAttackRoll evt) {
            MechanicsContext maybeContext = Fact.MaybeContext;
            using (maybeContext?.GetDataScope(evt.Target)) {
                evt.ForceFlatFooted = true;
            }
        }

        public void OnEventDidTrigger(RuleAttackRoll evt) {
        }
    }
}
