using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Items;
using Kingmaker.UnitLogic.FactLogic;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.OverpoweredAbility
{
    class InterdimensionalBagFeature
    {
        public static void Add()
        {
            var Icon_LargeBagOfHolding = Resources.GetBlueprint<BlueprintItem>("6deaab0e39c6f16468c38ff8a32f57a1").m_Icon;
            var InterdimensionalBagFeature = Helpers.CreateBlueprint<BlueprintFeature>("InterdimensionalBagFeature", bp => {
                bp.SetName("Overpowered Ability — Interdimensional Bag");
                bp.SetDescription("You have an infinite carry capacity.");
                bp.m_Icon = Icon_LargeBagOfHolding;
                bp.IsClassFeature = true;
                bp.AddComponent<AddPartyEncumbrance>(c => {
                    c.Value = 1000000;
                });
            });
        }
    }
}
