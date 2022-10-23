using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.UnitLogic.FactLogic;

namespace IsekaiMod.Changes.Features.IsekaiProtagonist
{
    class Invincible
    {
        public static void Add()
        {
            var Icon_Invincible = AssetLoader.LoadInternal("Features", "ICON_INVINCIBLE.png");
            var Invincible = Helpers.CreateBlueprint<BlueprintFeature>("Invincible", bp => {
                bp.SetName("Invincible");
                bp.SetDescription("You are immune to all {g|Encyclopedia:Physical_Damage}physical damage{/g}.");
                bp.m_Icon = Icon_Invincible;
                bp.AddComponent<AddPhysicalImmunity>();
                bp.IsClassFeature = true;
            });
        }
    }
}
