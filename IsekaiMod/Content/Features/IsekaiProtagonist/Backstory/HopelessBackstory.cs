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
    class HopelessBackstory
    {
        public static void Add()
        {
            // Icons
            var Icon_ResistAcid = Resources.GetBlueprint<BlueprintAbility>("fedc77de9b7aad54ebcc43b4daf8decd").m_Icon;
            var Icon_ProtectionFromAcid = Resources.GetBlueprint<BlueprintAbility>("3d77ee3fc4913c44b9df7c5bbcdc4906").m_Icon;
            var Icon_PredictionOfFailure = Resources.GetBlueprint<BlueprintAbility>("0e67fa8f011662c43934d486acc50253").m_Icon;

            // Class
            var IsekaiProtagonistClass = Resources.GetModBlueprint<BlueprintCharacterClass>("IsekaiProtagonistClass");

            // Features
            var VulnerabilityAcidFeat = Helpers.CreateBlueprint<BlueprintFeature>("VulnerabilityAcidFeat", bp => {
                bp.SetName("Acid Vulnerability");
                bp.SetDescription("You are vulnerable to Acid.");
                bp.m_Icon = IsekaiProtagonistSpellList.AcidSplashAbility.m_Icon;
                bp.AddComponent<AddEnergyVulnerability>(c => {
                    c.Type = DamageEnergyType.Acid;
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
            var ResistanceAcid10 = Helpers.CreateBlueprint<BlueprintFeature>("ResistanceAcid10", bp => {
                bp.SetName("Acid Resistance 10");
                bp.SetDescription("You gain acid resistance 10.");
                bp.m_Icon = Icon_ResistAcid;
                bp.AddComponent<AddDamageResistanceEnergy>(c => {
                    c.Type = DamageEnergyType.Acid;
                    c.Value = 10;
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
            var ImmunityToAcidFeat = Helpers.CreateBlueprint<BlueprintFeature>("ImmunityToAcidFeat", bp => {
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
            var HopelessBackstory = Helpers.CreateBlueprint<BlueprintFeature>("HopelessBackstory", bp => {
                bp.SetName("Hopeless Backstory");
                bp.SetDescription("You were a hopeless and untalented side character in the past, envious of what others had which you did not. Your inner insecurities leave you vulnerable to toxicity.\n" +
                    "At 1st level, you are vulnerable to acid.\n" +
                    "At 4th level, you are no longer vulnerable to acid.\n" +
                    "At 7th level, you gain acid resistance 10.\n" +
                    "At 10th level, you are immune to acid.\n");
                bp.m_Icon = Icon_PredictionOfFailure;
                bp.AddComponent<AddFeatureOnClassLevel>(c => {
                    c.Level = 4;
                    c.BeforeThisLevel = true;
                    c.m_Feature = VulnerabilityAcidFeat.ToReference<BlueprintFeatureReference>();
                    c.m_Class = IsekaiProtagonistClass.ToReference<BlueprintCharacterClassReference>();
                    c.m_AdditionalClasses = new BlueprintCharacterClassReference[0];
                    c.m_Archetypes = new BlueprintArchetypeReference[0];
                });
                bp.AddComponent<AddFeatureOnClassLevel>(c => {
                    c.Level = 7;
                    c.BeforeThisLevel = false;
                    c.m_Feature = ResistanceAcid10.ToReference<BlueprintFeatureReference>();
                    c.m_Class = IsekaiProtagonistClass.ToReference<BlueprintCharacterClassReference>();
                    c.m_AdditionalClasses = new BlueprintCharacterClassReference[0];
                    c.m_Archetypes = new BlueprintArchetypeReference[0];
                });
                bp.AddComponent<AddFeatureOnClassLevel>(c => {
                    c.Level = 10;
                    c.BeforeThisLevel = false;
                    c.m_Feature = ImmunityToAcidFeat.ToReference<BlueprintFeatureReference>();
                    c.m_Class = IsekaiProtagonistClass.ToReference<BlueprintCharacterClassReference>();
                    c.m_AdditionalClasses = new BlueprintCharacterClassReference[0];
                    c.m_Archetypes = new BlueprintArchetypeReference[0];
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
        }
    }
}
