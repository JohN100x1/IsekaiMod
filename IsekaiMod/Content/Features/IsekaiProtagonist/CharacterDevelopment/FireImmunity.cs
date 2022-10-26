using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Enums.Damage;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.FactLogic;


namespace IsekaiMod.Content.Features.IsekaiProtagonist.CharacterDevelopment
{
    class FireImmunity
    {
        public static void Add()
        {
            // Feature
            var Icon_ProtectionFromFire = Resources.GetBlueprint<BlueprintAbility>("3f9605134d34e1243b096e1f6cb4c148").m_Icon;
            var FireImmunity = Helpers.CreateBlueprint<BlueprintFeature>("FireImmunity", bp => {
                bp.SetName("Fire Immunity");
                bp.SetDescription("You gain immunity to Fire.");
                bp.m_Icon = Icon_ProtectionFromFire;
                bp.AddComponent<AddEnergyImmunity>(c => {
                    c.Type = DamageEnergyType.Fire;
                });
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.Fire;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = SpellDescriptor.Fire;
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
        }
    }
}
