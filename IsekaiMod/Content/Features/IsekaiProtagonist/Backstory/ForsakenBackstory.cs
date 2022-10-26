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
    class ForsakenBackstory
    {
        public static void Add()
        {
            // Icons
            var Icon_ResistSonic = Resources.GetBlueprint<BlueprintAbility>("8d3b10f92387c84429ced317b06ad001").m_Icon;
            var Icon_ProtectionFromSonic = Resources.GetBlueprint<BlueprintAbility>("0cee375b4e5265a46a13fc269beb8763").m_Icon;
            var Icon_OverwhelmingGrief = Resources.GetBlueprint<BlueprintAbility>("dd2918e4a77c50044acba1ac93494c36").m_Icon;

            // Class
            var IsekaiProtagonistClass = Resources.GetModBlueprint<BlueprintCharacterClass>("IsekaiProtagonistClass");

            // Features
            var VulnerabilitySonicFeat = Helpers.CreateBlueprint<BlueprintFeature>("VulnerabilitySonicFeat", bp => {
                bp.SetName("Sonic Vulnerability");
                bp.SetDescription("You are vulnerable to Sonic.");
                bp.m_Icon = IsekaiProtagonistSpellList.EarPiercingScreamAbility.m_Icon;
                bp.AddComponent<AddEnergyVulnerability>(c => {
                    c.Type = DamageEnergyType.Sonic;
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
            var ResistanceSonic10 = Helpers.CreateBlueprint<BlueprintFeature>("ResistanceSonic10", bp => {
                bp.SetName("Sonic Resistance 10");
                bp.SetDescription("You gain sonic resistance 10.");
                bp.m_Icon = Icon_ResistSonic;
                bp.AddComponent<AddDamageResistanceEnergy>(c => {
                    c.Type = DamageEnergyType.Sonic;
                    c.Value = 10;
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
            var ImmunityToSonicFeat = Helpers.CreateBlueprint<BlueprintFeature>("ImmunityToSonicFeat", bp => {
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
            var ForsakenBackstory = Helpers.CreateBlueprint<BlueprintFeature>("ForsakenBackstory", bp => {
                bp.SetName("Forsaken Backstory");
                bp.SetDescription("Your past life was lonely and devoid. Your only friend was the sound of silence.\n" +
                    "At 1st level, you are vulnerable to sonic.\n" +
                    "At 4th level, you are no longer vulnerable to sonic.\n" +
                    "At 7th level, you gain sonic resistance 10.\n" +
                    "At 10th level, you are immune to sonic.\n");
                bp.m_Icon = Icon_OverwhelmingGrief;
                bp.AddComponent<AddFeatureOnClassLevel>(c => {
                    c.Level = 4;
                    c.BeforeThisLevel = true;
                    c.m_Feature = VulnerabilitySonicFeat.ToReference<BlueprintFeatureReference>();
                    c.m_Class = IsekaiProtagonistClass.ToReference<BlueprintCharacterClassReference>();
                    c.m_AdditionalClasses = new BlueprintCharacterClassReference[0];
                    c.m_Archetypes = new BlueprintArchetypeReference[0];
                });
                bp.AddComponent<AddFeatureOnClassLevel>(c => {
                    c.Level = 7;
                    c.BeforeThisLevel = false;
                    c.m_Feature = ResistanceSonic10.ToReference<BlueprintFeatureReference>();
                    c.m_Class = IsekaiProtagonistClass.ToReference<BlueprintCharacterClassReference>();
                    c.m_AdditionalClasses = new BlueprintCharacterClassReference[0];
                    c.m_Archetypes = new BlueprintArchetypeReference[0];
                });
                bp.AddComponent<AddFeatureOnClassLevel>(c => {
                    c.Level = 10;
                    c.BeforeThisLevel = false;
                    c.m_Feature = ImmunityToSonicFeat.ToReference<BlueprintFeatureReference>();
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
