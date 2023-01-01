using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using UnityEngine;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;
using Kingmaker.Blueprints.Classes;

namespace IsekaiMod.Content.Features.IsekaiProtagonist
{
    class IsekaiQuickFooted
    {
        private static readonly Sprite Icon_ExpeditiousRetreat = BlueprintTools.GetBlueprint<BlueprintAbility>("4f8181e7a7f1d904fbaea64220e83379").m_Icon;
        public static void Add()
        {
            var IsekaiQuickFooted = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext,"IsekaiQuickFooted", bp => {
                bp.SetName(IsekaiContext, "Quick-Footed");
                bp.SetDescription(IsekaiContext, "At 15th level, you gain a competence {g|Encyclopedia:Bonus}bonus{/g} to your {g|Encyclopedia:Initiative}initiative{/g} {g|Encyclopedia:Check}checks{/g} equal to your {g|Encyclopedia:Charisma}Charisma{/g} modifier.");
                bp.m_Icon = Icon_ExpeditiousRetreat;
                bp.AddComponent<DerivativeStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Competence;
                    c.BaseStat = StatType.Charisma;
                    c.DerivativeStat = StatType.Initiative;
                });
                bp.AddComponent<RecalculateOnStatChange>(c => {
                    c.Stat = StatType.Charisma;
                });
            });
        }
    }
}
