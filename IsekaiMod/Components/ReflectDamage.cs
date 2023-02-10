using IsekaiMod.Utilities;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.ElementsSystem;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Components;

namespace IsekaiMod.Components {

    [TypeId("823bcefa4de241ed88a61db6886e16fb")]
    public class ReflectDamage : UnitFactComponentDelegate, ITargetRulebookSubscriber, IRulebookHandler<RuleDealDamage>, ISubscriber, ITargetRulebookHandler<RuleDealDamage> {

        public void TryRunAction(RuleDealDamage e) {
            if (e.Reason.Fact == Fact || Fact is not IFactContextOwner factContextOwner) {
                return;
            }
            ActionList dealDamageActionList = ActionFlow.DealDamage(c => {
                c.DamageType = new DamageTypeDescription() {
                    Type = DamageType.Direct,
                    Physical = new DamageTypeDescription.PhysicalData(),
                    Common = new DamageTypeDescription.CommomData()
                };
                c.Value = new ContextDiceValue() {
                    DiceType = Kingmaker.RuleSystem.DiceType.Zero,
                    DiceCountValue = 0,
                    BonusValue = e.Result
                };
            });
            factContextOwner.RunActionInContext(dealDamageActionList, e.Initiator);
        }

        public void OnEventAboutToTrigger(RuleDealDamage evt) {
        }

        public void OnEventDidTrigger(RuleDealDamage evt) {
            TryRunAction(evt);
        }
    }
}