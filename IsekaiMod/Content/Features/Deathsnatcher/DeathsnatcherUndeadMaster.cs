using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.FactLogic;
using System.Collections.Generic;
using UnityEngine;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;
using Kingmaker.Blueprints.Classes;

namespace IsekaiMod.Content.Features.Deathsnatcher
{
    class DeathsnatcherUndeadMaster
    {
        private static readonly Sprite Icon_MasteryOfFlesh = BlueprintTools.GetBlueprint<BlueprintAbility>("921ed6a6751d71140b4e75ab7bcb9890").m_Icon;

        public static void Add()
        {
            var DeathsnatcherCommandUndeadAbility = BlueprintTools.GetModBlueprint<BlueprintAbility>(IsekaiContext, "DeathsnatcherCommandUndeadAbility");
            var DeathsnatcherAnimateDeadAbility = BlueprintTools.GetModBlueprint<BlueprintAbility>(IsekaiContext, "DeathsnatcherAnimateDeadAbility");
            var DeathsnatcherCreateUndeadResource = BlueprintTools.GetModBlueprint<BlueprintAbilityResource>(IsekaiContext, "DeathsnatcherCreateUndeadResource");
            var DeathsnatcherFingerOfDeathResource = BlueprintTools.GetModBlueprint<BlueprintAbilityResource>(IsekaiContext, "DeathsnatcherFingerOfDeathResource");

            // Feature
            var DeathsnatcherUndeadMaster = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext,"DeathsnatcherUndeadMaster", bp => {
                bp.SetName(IsekaiContext, "Undead Master");
                bp.SetDescription(IsekaiContext, "At 20th level, the Deathsnatcher becomes a master of the undead.\n"
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
