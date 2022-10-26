using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Enums.Damage;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.FactLogic;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.CharacterDevelopment
{
    class ElectricityImmunity
    {
        public static void Add()
        {
            // Feature
            var Icon_ProtectionFromElectricity = Resources.GetBlueprint<BlueprintAbility>("e24ce0c3e8eaaaf498d3656b534093df").m_Icon;
            var ElectricityImmunity = Helpers.CreateBlueprint<BlueprintFeature>("ElectricityImmunity", bp => {
                bp.SetName("Electricity Immunity");
                bp.SetDescription("You gain immunity to Electricity.");
                bp.m_Icon = Icon_ProtectionFromElectricity;
                bp.AddComponent<AddEnergyImmunity>(c => {
                    c.Type = DamageEnergyType.Electricity;
                });
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.Electricity;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = SpellDescriptor.Electricity;
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
        }
    }
}
