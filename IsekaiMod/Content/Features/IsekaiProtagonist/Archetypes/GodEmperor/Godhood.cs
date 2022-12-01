using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.Enums.Damage;
using Kingmaker.UnitLogic.FactLogic;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.GodEmperor
{
    class Godhood
    {
        public static void Add()
        {
            var Icon_Godhood = AssetLoader.LoadInternal("Features", "ICON_GODHOOD.png");
            var Godhood = Helpers.CreateFeature("Godhood", bp => {
                bp.SetName("Godhood");
                bp.SetDescription("At 20th level, you become a god. You gain 100 spell resistance and are immune acid, cold, electricity, fire, sonic, and all "
                    + "{g|Encyclopedia:Physical_Damage}physical damage{/g}. Your attacks ignore concealment and damage reduction. Any critical threats you make are automatically confirmed. "
                    + "The spells you cast ignore spell resistance and spell immunity.");
                bp.m_Icon = Icon_Godhood;
                bp.AddComponent<AddSpellResistance>(c => {
                    c.Value = 100;
                });
                bp.AddComponent<AddEnergyImmunity>(c => {
                    c.Type = DamageEnergyType.Acid;
                });
                bp.AddComponent<AddEnergyImmunity>(c => {
                    c.Type = DamageEnergyType.Cold;
                });
                bp.AddComponent<AddEnergyImmunity>(c => {
                    c.Type = DamageEnergyType.Electricity;
                });
                bp.AddComponent<AddEnergyImmunity>(c => {
                    c.Type = DamageEnergyType.Fire;
                });
                bp.AddComponent<AddEnergyImmunity>(c => {
                    c.Type = DamageEnergyType.Sonic;
                });
                bp.AddComponent<AddPhysicalImmunity>();
                bp.AddComponent<IgnoreConcealment>();
                bp.AddComponent<IgnoreDamageReductionOnAttack>();
                bp.AddComponent<InitiatorCritAutoconfirm>();
                bp.AddComponent<IgnoreSpellImmunity>(c => {
                    c.SpellDescriptor = SpellDescriptor.None;
                });
                bp.AddComponent<IgnoreSpellResistanceForSpells>(c => {
                    c.m_AbilityList = new BlueprintAbilityReference[0];
                    c.AllSpells = true;
                });
            });
        }
    }
}
