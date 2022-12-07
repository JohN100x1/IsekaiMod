using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;

namespace IsekaiMod.Components
{
    [ComponentName("Add Extra Attack")]
	[AllowedOn(typeof(BlueprintUnitFact), false)]
	[TypeId("c89e87e7db0a4704b2f7b65b49afa705")]
	public class AddExtraAttack : UnitFactComponentDelegate, IInitiatorRulebookHandler<RuleCalculateAttacksCount>, IRulebookHandler<RuleCalculateAttacksCount>, ISubscriber, IInitiatorRulebookSubscriber
	{
		public int Number = 1;
		public void OnEventAboutToTrigger(RuleCalculateAttacksCount evt)
		{
			evt.AddExtraAttacks(Number * Fact.GetRank(), false, false, null);
		}
		public void OnEventDidTrigger(RuleCalculateAttacksCount evt)
		{
		}
	}
}