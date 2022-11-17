using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using UnityEngine;

namespace IsekaiMod.Content.Features.Deathsnatcher
{
    class DeathsnatcherUndeadMaster
    {
        private static readonly Sprite Icon_MasteryOfFlesh = Resources.GetBlueprint<BlueprintAbility>("921ed6a6751d71140b4e75ab7bcb9890").m_Icon;

        public static void Add()
        {
            var DeathsnatcherAnimateDeadResource = Resources.GetModBlueprint<BlueprintAbilityResource>("DeathsnatcherAnimateDeadResource");
            var DeathsnatcherCreateUndeadResource = Resources.GetModBlueprint<BlueprintAbilityResource>("DeathsnatcherCreateUndeadResource");
            var DeathsnatcherFingerOfDeathResource = Resources.GetModBlueprint<BlueprintAbilityResource>("DeathsnatcherFingerOfDeathResource");

            // Feature
            var DeathsnatcherUndeadMaster = Helpers.CreateBlueprint<BlueprintFeature>("DeathsnatcherUndeadMaster", bp => {
                bp.SetName("Undead Master");
                bp.SetDescription("At 19th level, the Deathsnatcher becomes a master of the undead.\n"
                    + "Animate Dead has 5 additional uses per day.\n"
                    + "Create Undead has 2 additional uses per day.\n"
                    + "Finger of Death has 2 additional uses per day.");
                bp.m_Icon = Icon_MasteryOfFlesh;
                bp.IsClassFeature = true;
                bp.AddComponent<IncreaseResourceAmount>(c => {
                    c.m_Resource = DeathsnatcherAnimateDeadResource.ToReference<BlueprintAbilityResourceReference>();
                    c.Value = 5;
                });
                bp.AddComponent<IncreaseResourceAmount>(c => {
                    c.m_Resource = DeathsnatcherCreateUndeadResource.ToReference<BlueprintAbilityResourceReference>();
                    c.Value = 2;
                });
                bp.AddComponent<IncreaseResourceAmount>(c => {
                    c.m_Resource = DeathsnatcherFingerOfDeathResource.ToReference<BlueprintAbilityResourceReference>();
                    c.Value = 2;
                });
            });
        }
    }
}
