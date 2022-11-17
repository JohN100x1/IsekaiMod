using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using UnityEngine;

namespace IsekaiMod.Content.Features.Deathsnatcher
{
    class DeathsnatcherAnimateDeadAdditionalUse
    {
        private static readonly Sprite Icon_AnimateDead = Resources.GetBlueprint<BlueprintAbility>("4b76d32feb089ad4499c3a1ce8e1ac27").m_Icon;

        public static void Add()
        {
            var DeathsnatcherAnimateDeadResource = Resources.GetModBlueprint<BlueprintAbilityResource>("DeathsnatcherAnimateDeadResource");
            var DeathsnatcherAnimateDeadAdditionalUse = Helpers.CreateBlueprint<BlueprintFeature>("DeathsnatcherAnimateDeadAdditionalUse", bp => {
                bp.SetName("Animate Dead — Additional Uses");
                bp.SetDescription("At 10th level, the Deathsnatcher gains 2 additional uses of Animate Dead per day.");
                bp.m_Icon = Icon_AnimateDead;
                bp.IsClassFeature = true;
                bp.AddComponent<IncreaseResourceAmount>(c => {
                    c.m_Resource = DeathsnatcherAnimateDeadResource.ToReference<BlueprintAbilityResourceReference>();
                    c.Value = 2;
                });
            });
        }
    }
}
