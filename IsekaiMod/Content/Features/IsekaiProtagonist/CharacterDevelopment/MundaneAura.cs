using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.UnitLogic.FactLogic;
using UnityEngine;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.CharacterDevelopment
{
    class MundaneAura
    {
        private static readonly Sprite Icon_BardLoreMaster = Resources.GetBlueprint<BlueprintFeature>("4bea694e79a87cd4d8c14fb91578059e").m_Icon;
        public static void Add()
        {
            var MundaneAura = Helpers.CreateFeature("MundaneAura", bp => {
                bp.SetName("Mundane Aura");
                bp.SetDescription("You emit a small aura of mundanity, giving you immunity to Sneak attack damage and {g|Encyclopedia:Critical}critical hits{/g}.");
                bp.m_Icon = Icon_BardLoreMaster;
                bp.AddComponent<AddImmunityToCriticalHits>();
                bp.AddComponent<AddImmunityToPrecisionDamage>();
            });

            CharacterDevelopmentSelection.AddToSelection(MundaneAura);
        }
    }
}
