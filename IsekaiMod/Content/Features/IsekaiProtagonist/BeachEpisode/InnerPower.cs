using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.FactLogic;
using UnityEngine;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.BeachEpisode
{
    class InnerPower
    {
        private static readonly Sprite Icon_BurningRenewal = Resources.GetBlueprint<BlueprintFeature>("7cf2a6bf35c422e4ea219fcc2eb564f5").m_Icon;
        public static void Add()
        {
            var InnerPower = Helpers.CreateFeature("InnerPower", bp => {
                bp.SetName("Inner Power");
                bp.SetDescription("You gain immunity to shaken, frightened, cowering, fear, death effects, {g|Encyclopedia:Ability_Scores}ability score{/g} drain, energy drain, and negative levels.");
                bp.m_Icon = Icon_BurningRenewal;
                bp.AddComponent<AddImmunityToAbilityScoreDamage>(c => {
                    c.Drain = true;
                });
                bp.AddComponent<AddImmunityToEnergyDrain>();
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Shaken;
                });
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Frightened;
                });
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Cowering;
                });
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.Shaken
                    | SpellDescriptor.Frightened
                    | SpellDescriptor.Fear
                    | SpellDescriptor.NegativeLevel
                    | SpellDescriptor.StatDebuff
                    | SpellDescriptor.Death;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = SpellDescriptor.Shaken
                    | SpellDescriptor.Frightened
                    | SpellDescriptor.Fear
                    | SpellDescriptor.NegativeLevel
                    | SpellDescriptor.StatDebuff
                    | SpellDescriptor.Death;
                });
            });

            BeachEpisodeSelection.AddToSelection(InnerPower);
        }
    }
}
