using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.UnitLogic;

namespace IsekaiMod.Components
{
    [TypeId("6a0e920f5f664d6eb5449def3542208b")]
	[AllowedOn(typeof(BlueprintFeature), false)]
	public class ArmorNoSpeedPenalty : UnitFactComponentDelegate
	{
		public override void OnTurnOn()
		{
			base.OnTurnOn();
			Owner.State.Features.ImmunityToMediumArmorSpeedPenalty.Release();
			Owner.State.Features.ImmuneToArmorSpeedPenalty.Release();
			if (Owner.Body.Armor.HasArmor)
			{
				Owner.Body.Armor.Armor.RecalculateStats();
			}
		}
		public override void OnTurnOff()
		{
			base.OnTurnOff();
			Owner.State.Features.ImmunityToMediumArmorSpeedPenalty.Release();
			Owner.State.Features.ImmuneToArmorSpeedPenalty.Release();
			if (Owner.Body.Armor.HasArmor)
			{
				Owner.Body.Armor.Armor.RecalculateStats();
			}
		}
	}
}