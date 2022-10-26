using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Enums.Damage;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.FactLogic;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.CharacterDevelopment
{
    class SonicImmunity
    {
        public static void Add()
        {
            // Features
            var Icon_ProtectionFromSonic = Resources.GetBlueprint<BlueprintAbility>("0cee375b4e5265a46a13fc269beb8763").m_Icon;
            var SonicImmunity = Helpers.CreateBlueprint<BlueprintFeature>("SonicImmunity", bp => {
                bp.SetName("Sonic Immunity");
                bp.SetDescription("You gain immunity to Sonic.");
                bp.m_Icon = Icon_ProtectionFromSonic;
                bp.AddComponent<AddEnergyImmunity>(c => {
                    c.Type = DamageEnergyType.Sonic;
                });
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.Sonic;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = SpellDescriptor.Sonic;
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
        }
    }
}
