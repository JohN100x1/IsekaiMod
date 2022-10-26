using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Enums.Damage;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.FactLogic;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.CharacterDevelopment
{
    class ColdImmunity
    {
        public static void Add()
        {
            // Feature
            var Icon_ProtectionFromCold = Resources.GetBlueprint<BlueprintAbility>("021d39c8e0eec384ba69140f4875e166").m_Icon;
            var ColdImmunity = Helpers.CreateBlueprint<BlueprintFeature>("ColdImmunity", bp => {
                bp.SetName("Cold Immunity");
                bp.SetDescription("You gain immunity to Cold.");
                bp.m_Icon = Icon_ProtectionFromCold;
                bp.AddComponent<AddEnergyImmunity>(c => {
                    c.Type = DamageEnergyType.Cold;
                });
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.Cold;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = SpellDescriptor.Cold;
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
        }
    }
}
