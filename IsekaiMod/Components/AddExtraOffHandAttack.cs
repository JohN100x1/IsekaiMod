using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;

namespace IsekaiMod.Components {

    [ComponentName("Add Extra Off-Hand Attack")]
    [AllowedOn(typeof(BlueprintUnitFact), false)]
    [TypeId("327faf39b9a643c2bbca12c7e8f81ccb")]
    public class AddExtraOffHandAttack : UnitFactComponentDelegate, IInitiatorRulebookHandler<RuleCalculateAttacksCount>, IRulebookHandler<RuleCalculateAttacksCount>, ISubscriber, IInitiatorRulebookSubscriber {
        public int Number = 1;

        public void OnEventAboutToTrigger(RuleCalculateAttacksCount evt) {
            if (!evt.Initiator.Body.PrimaryHand.HasWeapon
                || !evt.Initiator.Body.SecondaryHand.HasWeapon
                || evt.Initiator.Body.PrimaryHand.Weapon.Blueprint.IsNatural
                || evt.Initiator.Body.SecondaryHand.Weapon.Blueprint.IsNatural
                || evt.Initiator.Body.PrimaryHand.Weapon == evt.Initiator.Body.EmptyHandWeapon
                || evt.Initiator.Body.SecondaryHand.Weapon == evt.Initiator.Body.EmptyHandWeapon) {
                return;
            }
            evt.Result.SecondaryHand.AdditionalAttacks += Number * Fact.GetRank();
        }

        public void OnEventDidTrigger(RuleCalculateAttacksCount evt) {
        }
    }
}