using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.FactLogic;

namespace IsekaiMod.Changes.Features.IsekaiProtagonist.CharacterDevelopment
{
    class VigorousWard
    {
        public static void Add()
        {
            var Icon_DeathWard = Resources.GetBlueprint<BlueprintAbility>("0413915f355a38146bc6ad40cdf27b3f").m_Icon;
            var VigorousWard = Helpers.CreateBlueprint<BlueprintFeature>("VigorousWard", bp => {
                bp.SetName("Vigorous Ward");
                bp.SetDescription("You emit an aura of vigorous energy, giving you immunity to {g|Encyclopedia:Ability_Scores}ability score{/g} {g|Encyclopedia:Damage}damage{/g}, energy drain, and negative levels.");
                bp.m_Icon = Icon_DeathWard;
                bp.AddComponent<AddImmunityToAbilityScoreDamage>();
                bp.AddComponent<AddImmunityToEnergyDrain>();
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.NegativeLevel
                    | SpellDescriptor.StatDebuff;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = SpellDescriptor.NegativeLevel
                    | SpellDescriptor.StatDebuff;
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
        }
    }
}
