using Kingmaker.Blueprints;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.EntitySystem;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic.Mechanics;

namespace IsekaiMod.Components {
    [AllowMultipleComponents]
    [TypeId("f9cdd93e34a149349a64dfec5b0b6deb")]
    public class SetAttackerAutoMiss : BlueprintComponent, IRuntimeEntityFactComponentProvider {

        public EntityFactComponent CreateRuntimeFactComponent() {
            return new Runtime();
        }

        public class Runtime : EntityFactComponent<UnitEntityData, SetAttackerAutoMiss>, IRulebookHandler<RuleAttackRoll>, ITargetRulebookHandler<RuleAttackRoll>, ISubscriber, ITargetRulebookSubscriber {

            public override void OnTurnOn() {
            }

            public override void OnTurnOff() {
            }

            public void OnEventAboutToTrigger(RuleAttackRoll evt) {
                MechanicsContext maybeContext = Fact.MaybeContext;
                using (maybeContext?.GetDataScope(evt.Initiator)) {
                    evt.AutoMiss = true; // TODO: use evt.ForceFlatFooted for forcing flat footed
                }
            }

            public void OnEventDidTrigger(RuleAttackRoll evt) {
            }

        }
    }
}
