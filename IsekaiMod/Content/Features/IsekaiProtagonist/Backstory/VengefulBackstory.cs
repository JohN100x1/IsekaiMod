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
    class VengefulBackstory
    {
        public static void Add()
        {
            // Icons
            var Icon_ResistFire = Resources.GetBlueprint<BlueprintAbility>("ddfb4ac970225f34dbff98a10a4a8844").m_Icon;
            var Icon_ProtectionFromFire = Resources.GetBlueprint<BlueprintAbility>("3f9605134d34e1243b096e1f6cb4c148").m_Icon;
            var Icon_Rage = Resources.GetBlueprint<BlueprintAbility>("97b991256e43bb140b263c326f690ce2").m_Icon;

            // Class
            var IsekaiProtagonistClass = Resources.GetModBlueprint<BlueprintCharacterClass>("IsekaiProtagonistClass");

            // Features
            var VulnerabilityFireFeat = Helpers.CreateBlueprint<BlueprintFeature>("VulnerabilityFireFeat", bp => {
                bp.SetName("Fire Vulnerability");
                bp.SetDescription("You are vulnerable to Fire.");
                bp.m_Icon = IsekaiProtagonistSpellList.FireballAbility.m_Icon;
                bp.AddComponent<AddEnergyVulnerability>(c => {
                    c.Type = DamageEnergyType.Fire;
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
            var ResistanceFire10 = Helpers.CreateBlueprint<BlueprintFeature>("ResistanceFire10", bp => {
                bp.SetName("Fire Resistance 10");
                bp.SetDescription("You gain fire resistance 10.");
                bp.m_Icon = Icon_ResistFire;
                bp.AddComponent<AddDamageResistanceEnergy>(c => {
                    c.Type = DamageEnergyType.Fire;
                    c.Value = 10;
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
            var ImmunityToFireFeat = Helpers.CreateBlueprint<BlueprintFeature>("ImmunityToFireFeat", bp => {
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
            var VengefulBackstory = Helpers.CreateBlueprint<BlueprintFeature>("VengefulBackstory", bp => {
                bp.SetName("Vengeful Backstory");
                bp.SetDescription("You were betrayed by a some-one you trusted, leaving your heart full of burning rage and vengeance.\n" +
                    "At 1st level, you are vulnerable to fire.\n" +
                    "At 4th level, you are no longer vulnerable to fire.\n" +
                    "At 7th level, you gain fire resistance 10.\n" +
                    "At 10th level, you are immune to fire.\n");
                bp.m_Icon = Icon_Rage;
                bp.AddComponent<AddFeatureOnClassLevel>(c => {
                    c.Level = 4;
                    c.BeforeThisLevel = true;
                    c.m_Feature = VulnerabilityFireFeat.ToReference<BlueprintFeatureReference>();
                    c.m_Class = IsekaiProtagonistClass.ToReference<BlueprintCharacterClassReference>();
                    c.m_AdditionalClasses = new BlueprintCharacterClassReference[0];
                    c.m_Archetypes = new BlueprintArchetypeReference[0];
                });
                bp.AddComponent<AddFeatureOnClassLevel>(c => {
                    c.Level = 7;
                    c.BeforeThisLevel = false;
                    c.m_Feature = ResistanceFire10.ToReference<BlueprintFeatureReference>();
                    c.m_Class = IsekaiProtagonistClass.ToReference<BlueprintCharacterClassReference>();
                    c.m_AdditionalClasses = new BlueprintCharacterClassReference[0];
                    c.m_Archetypes = new BlueprintArchetypeReference[0];
                });
                bp.AddComponent<AddFeatureOnClassLevel>(c => {
                    c.Level = 10;
                    c.BeforeThisLevel = false;
                    c.m_Feature = ImmunityToFireFeat.ToReference<BlueprintFeatureReference>();
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
