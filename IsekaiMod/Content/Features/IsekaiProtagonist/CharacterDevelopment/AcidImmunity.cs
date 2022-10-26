using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Enums.Damage;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.FactLogic;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.CharacterDevelopment
{
    class AcidImmunity
    {
        public static void Add()
        {
            // Features
            var Icon_ProtectionFromAcid = Resources.GetBlueprint<BlueprintAbility>("3d77ee3fc4913c44b9df7c5bbcdc4906").m_Icon;
            var AcidImmunity = Helpers.CreateBlueprint<BlueprintFeature>("AcidImmunity", bp => {
                bp.SetName("Acid Immunity");
                bp.SetDescription("You gain immunity to Acid.");
                bp.m_Icon = Icon_ProtectionFromAcid;
                bp.AddComponent<AddEnergyImmunity>(c => {
                    c.Type = DamageEnergyType.Acid;
                });
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.Acid;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = SpellDescriptor.Acid;
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
        }
    }
}
