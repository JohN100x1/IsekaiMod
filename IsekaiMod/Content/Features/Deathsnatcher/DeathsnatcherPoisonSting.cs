using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.UnitLogic.FactLogic;

namespace IsekaiMod.Content.Features.Deathsnatcher
{
    class DeathsnatcherPoisonSting
    {
        private static readonly BlueprintFeature DeathsnatcherPoisonFeature = Resources.GetBlueprint<BlueprintFeature>("9547e5db05fa6f143a1867c93b258fe0");
        public static void Add()
        {
            var DeathsnatcherPoisonSting = Helpers.CreateBlueprint<BlueprintFeature>("DeathsnatcherPoisonSting", bp => {
                bp.SetName("Deathsnatcher Poison Sting");
                bp.SetDescription("The Deathsnatcher's sting attack becomes poisonous and inflicts 1d4 Constitution damage if the enemy fails a DC 28 Fortitude save.");
                bp.m_Icon = null;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { DeathsnatcherPoisonFeature.ToReference<BlueprintUnitFactReference>() };
                });
                bp.IsClassFeature = true;
                bp.ReapplyOnLevelUp = true;
            });
        }
    }
}
