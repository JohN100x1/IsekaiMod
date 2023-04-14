using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Buffs;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using TabletopTweaks.Core.Utilities;
using UnityEngine;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Hero {

    internal class HandsOfSalvation {
        private static readonly Sprite Icon_BlessingOfLuckAndResolveMass = BlueprintTools.GetBlueprint<BlueprintAbility>("462c21cebf7820c40a87f5e4d03e17cf").m_Icon;

        public static void Add() {
            var HandsOfSalvation = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "HandsOfSalvation", bp => {
                bp.SetName(IsekaiContext, "Hands of Salvation");
                bp.SetDescription(IsekaiContext, "The Hero heals allies for double the amount.");
                bp.m_Icon = Icon_BlessingOfLuckAndResolveMass;
                bp.AddComponent<ModifyOutgoingHealAmount>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[0];
                    c.MultiplierIfHasNoFacts = 2.0f;
                });
            });
        }
    }
}