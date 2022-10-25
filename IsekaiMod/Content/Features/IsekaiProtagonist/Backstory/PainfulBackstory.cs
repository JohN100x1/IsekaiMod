using IsekaiMod.Content.Classes.IsekaiProtagonist;
using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.Enums.Damage;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.FactLogic;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.Backstory
{
    class PainfulBackstory
    {
        public static void Add()
        {
            // Icons
            var Icon_ResistElectricity = Resources.GetBlueprint<BlueprintAbility>("90987584f54ab7a459c56c2d2f22cee2").m_Icon;
            var Icon_ProtectionFromElectricity = Resources.GetBlueprint<BlueprintAbility>("e24ce0c3e8eaaaf498d3656b534093df").m_Icon;
            var Icon_Daze = Resources.GetBlueprint<BlueprintAbility>("55f14bc84d7c85446b07a1b5dd6b2b4c").m_Icon;

            // Class
            var IsekaiProtagonistClass = Resources.GetModBlueprint<BlueprintCharacterClass>("IsekaiProtagonistClass");

            // Features
            var VulnerabilityElectricityFeat = Helpers.CreateBlueprint<BlueprintFeature>("VulnerabilityElectricityFeat", bp => {
                bp.SetName("Electricity Vulnerability");
                bp.SetDescription("You are vulnerable to Electricity.");
                bp.m_Icon = IsekaiProtagonistSpellList.LightningBoltAbility.m_Icon;
                bp.AddComponent<AddEnergyVulnerability>(c => {
                    c.Type = DamageEnergyType.Electricity;
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
            var ResistanceElectricity10 = Helpers.CreateBlueprint<BlueprintFeature>("ResistanceElectricity10", bp => {
                bp.SetName("Electricity Resistance 10");
                bp.SetDescription("You gain electricity resistance 10.");
                bp.m_Icon = Icon_ResistElectricity;
                bp.AddComponent<AddDamageResistanceEnergy>(c => {
                    c.Type = DamageEnergyType.Electricity;
                    c.Value = 10;
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
            var ImmunityToElectricityFeat = Helpers.CreateBlueprint<BlueprintFeature>("ImmunityToElectricityFeat", bp => {
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
            var PainfulBackstory = Helpers.CreateBlueprint<BlueprintFeature>("PainfulBackstory", bp => {
                bp.SetName("Painful Backstory");
                bp.SetDescription("You were subjected to unspeakable creulty in the past, leaving you traumatised to the slightest shock of pain.\n" +
                    "At 1st level, you are vulnerable to electricity.\n" +
                    "At 4th level, you are no longer vulnerable to electricity.\n" +
                    "At 7th level, you gain electricity resistance 10.\n" +
                    "At 10th level, you are immune to electricity.\n");
                bp.m_Icon = Icon_Daze;
                bp.AddComponent<AddFeatureOnClassLevel>(c => {
                    c.Level = 4;
                    c.BeforeThisLevel = true;
                    c.m_Feature = VulnerabilityElectricityFeat.ToReference<BlueprintFeatureReference>();
                    c.m_Class = IsekaiProtagonistClass.ToReference<BlueprintCharacterClassReference>();
                });
                bp.AddComponent<AddFeatureOnClassLevel>(c => {
                    c.Level = 7;
                    c.BeforeThisLevel = false;
                    c.m_Feature = ResistanceElectricity10.ToReference<BlueprintFeatureReference>();
                    c.m_Class = IsekaiProtagonistClass.ToReference<BlueprintCharacterClassReference>();
                });
                bp.AddComponent<AddFeatureOnClassLevel>(c => {
                    c.Level = 10;
                    c.BeforeThisLevel = false;
                    c.m_Feature = ImmunityToElectricityFeat.ToReference<BlueprintFeatureReference>();
                    c.m_Class = IsekaiProtagonistClass.ToReference<BlueprintCharacterClassReference>();
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
        }
    }
}
