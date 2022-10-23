using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.FactLogic;

namespace IsekaiMod.Changes.Features.IsekaiProtagonist.CharacterDevelopment
{
    class MundaneArmor
    {
        public static void Add()
        {
            var Icon_MageArmor = Resources.GetBlueprint<BlueprintAbility>("9e1ad5d6f87d19e4d8883d63a6e35568").m_Icon;
            var MundaneArmor = Helpers.CreateBlueprint<BlueprintFeature>("MundaneArmor", bp => {
                bp.SetName("Mundane Armor");
                bp.SetDescription("You emit a small aura of mundanity, giving you immunity to Sneak attack damage and {g|Encyclopedia:Critical}critical hits{/g}.");
                bp.m_Icon = Icon_MageArmor;
                bp.AddComponent<AddImmunityToCriticalHits>();
                bp.AddComponent<AddImmunityToPrecisionDamage>();
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
        }
    }
}
