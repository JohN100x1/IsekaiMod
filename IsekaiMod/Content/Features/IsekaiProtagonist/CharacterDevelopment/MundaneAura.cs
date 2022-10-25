using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.UnitLogic.FactLogic;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.CharacterDevelopment
{
    class MundaneAura
    {
        public static void Add()
        {
            var Icon_BardLoreMaster = Resources.GetBlueprint<BlueprintFeature>("4bea694e79a87cd4d8c14fb91578059e").m_Icon;
            var MundaneAura = Helpers.CreateBlueprint<BlueprintFeature>("MundaneAura", bp => {
                bp.SetName("Mundane Aura");
                bp.SetDescription("You emit a small aura of mundanity, giving you immunity to Sneak attack damage and {g|Encyclopedia:Critical}critical hits{/g}.");
                bp.m_Icon = Icon_BardLoreMaster;
                bp.AddComponent<AddImmunityToCriticalHits>();
                bp.AddComponent<AddImmunityToPrecisionDamage>();
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
        }
    }
}
