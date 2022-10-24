using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.UnitLogic.FactLogic;

namespace IsekaiMod.Changes.Features.IsekaiProtagonist
{
    class Godhood
    {
        public static void Add()
        {
            var Icon_Godhood = AssetLoader.LoadInternal("Features", "ICON_GODHOOD.png");
            var Godhood = Helpers.CreateBlueprint<BlueprintFeature>("Godhood", bp => {
                bp.SetName("Godhood");
                bp.SetDescription("At 19th level, you become a god. You are immune to all {g|Encyclopedia:Physical_Damage}physical damage{/g}.");
                bp.m_Icon = Icon_Godhood;
                bp.AddComponent<AddPhysicalImmunity>();
                bp.IsClassFeature = true;
            });
        }
    }
}
