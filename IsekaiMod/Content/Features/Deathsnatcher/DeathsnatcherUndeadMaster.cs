using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.FactLogic;
using System.Collections.Generic;
using UnityEngine;

namespace IsekaiMod.Content.Features.Deathsnatcher
{
    class DeathsnatcherUndeadMaster
    {
        private static readonly Sprite Icon_MasteryOfFlesh = Resources.GetBlueprint<BlueprintAbility>("921ed6a6751d71140b4e75ab7bcb9890").m_Icon;

        public static void Add()
        {
            var DeathsnatcherCommandUndeadAbility = Resources.GetModBlueprint<BlueprintAbility>("DeathsnatcherCommandUndeadAbility");
            var DeathsnatcherAnimateDeadAbility = Resources.GetModBlueprint<BlueprintAbility>("DeathsnatcherAnimateDeadAbility");
            var DeathsnatcherCreateUndeadResource = Resources.GetModBlueprint<BlueprintAbilityResource>("DeathsnatcherCreateUndeadResource");
            var DeathsnatcherFingerOfDeathResource = Resources.GetModBlueprint<BlueprintAbilityResource>("DeathsnatcherFingerOfDeathResource");

            // Feature
            var DeathsnatcherUndeadMaster = Helpers.CreateFeature("DeathsnatcherUndeadMaster", bp => {
                bp.SetName("Undead Master");
                bp.SetDescription("At 20th level, the Deathsnatcher becomes a master of the undead.\n"
                    + "Command Undead has unlimited uses.\n"
                    + "Animate Dead has unlimited uses.\n"
                    + "Create Undead has 2 additional uses per day.\n"
                    + "Finger of Death has 2 additional uses per day.");
                bp.m_Icon = Icon_MasteryOfFlesh;
                bp.AddComponent<IncreaseResourceAmount>(c => {
                    c.m_Resource = DeathsnatcherCreateUndeadResource.ToReference<BlueprintAbilityResourceReference>();
                    c.Value = 2;
                });
                bp.AddComponent<IncreaseResourceAmount>(c => {
                    c.m_Resource = DeathsnatcherFingerOfDeathResource.ToReference<BlueprintAbilityResourceReference>();
                    c.Value = 2;
                });
            });
            DeathsnatcherCommandUndeadAbility.GetComponent<AbilityResourceLogic>().ResourceCostDecreasingFacts = new List<BlueprintUnitFactReference>() { DeathsnatcherUndeadMaster.ToReference<BlueprintUnitFactReference>() };
            DeathsnatcherAnimateDeadAbility.GetComponent<AbilityResourceLogic>().ResourceCostDecreasingFacts = new List<BlueprintUnitFactReference>() { DeathsnatcherUndeadMaster.ToReference<BlueprintUnitFactReference>() };
        }
    }
}
