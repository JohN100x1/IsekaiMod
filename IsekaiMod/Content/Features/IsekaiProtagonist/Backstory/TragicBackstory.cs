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
    class TragicBackstory
    {
        public static void Add()
        {
            // Icons
            var Icon_ResistCold = Resources.GetBlueprint<BlueprintAbility>("5368cecec375e1845ae07f48cdc09dd1").m_Icon;
            var Icon_ProtectionFromCold = Resources.GetBlueprint<BlueprintAbility>("021d39c8e0eec384ba69140f4875e166").m_Icon;
            var Icon_CrushingDespair = Resources.GetBlueprint<BlueprintAbility>("4baf4109145de4345861fe0f2209d903").m_Icon;

            // Class
            var IsekaiProtagonistClass = Resources.GetModBlueprint<BlueprintCharacterClass>("IsekaiProtagonistClass");

            // Features
            var VulnerabilityColdFeat = Helpers.CreateBlueprint<BlueprintFeature>("VulnerabilityColdFeat", bp => {
                bp.SetName("Cold Vulnerability");
                bp.SetDescription("You are vulnerable to Cold.");
                bp.m_Icon = IsekaiProtagonistSpellList.IceStormAbility.m_Icon;
                bp.AddComponent<AddEnergyVulnerability>(c => {
                    c.Type = DamageEnergyType.Cold;
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
            var ResistanceCold10 = Helpers.CreateBlueprint<BlueprintFeature>("ResistanceCold10", bp => {
                bp.SetName("Cold Resistance 10");
                bp.SetDescription("You gain cold resistance 10.");
                bp.m_Icon = Icon_ResistCold;
                bp.AddComponent<AddDamageResistanceEnergy>(c => {
                    c.Type = DamageEnergyType.Cold;
                    c.Value = 10;
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
            var ImmunityToColdFeat = Helpers.CreateBlueprint<BlueprintFeature>("ImmunityToColdFeat", bp => {
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
            var TragicBackstory = Helpers.CreateBlueprint<BlueprintFeature>("TragicBackstory", bp => {
                bp.SetName("Tragic Backstory");
                bp.SetDescription("You had a heart-breaking and emotionally tragic past, leaving you vulnerable to the coldness in your heart.\n" +
                    "At 1st level, you are vulnerable to cold.\n" +
                    "At 4th level, you are no longer vulnerable to cold.\n" +
                    "At 7th level, you gain cold resistance 10.\n" +
                    "At 10th level, you are immune to cold.\n");
                bp.m_Icon = Icon_CrushingDespair;
                bp.AddComponent<AddFeatureOnClassLevel>(c => {
                    c.Level = 4;
                    c.BeforeThisLevel = true;
                    c.m_Feature = VulnerabilityColdFeat.ToReference<BlueprintFeatureReference>();
                    c.m_Class = IsekaiProtagonistClass.ToReference<BlueprintCharacterClassReference>();
                    c.m_AdditionalClasses = new BlueprintCharacterClassReference[0];
                    c.m_Archetypes = new BlueprintArchetypeReference[0];
                });
                bp.AddComponent<AddFeatureOnClassLevel>(c => {
                    c.Level = 7;
                    c.BeforeThisLevel = false;
                    c.m_Feature = ResistanceCold10.ToReference<BlueprintFeatureReference>();
                    c.m_Class = IsekaiProtagonistClass.ToReference<BlueprintCharacterClassReference>();
                    c.m_AdditionalClasses = new BlueprintCharacterClassReference[0];
                    c.m_Archetypes = new BlueprintArchetypeReference[0];
                });
                bp.AddComponent<AddFeatureOnClassLevel>(c => {
                    c.Level = 10;
                    c.BeforeThisLevel = false;
                    c.m_Feature = ImmunityToColdFeat.ToReference<BlueprintFeatureReference>();
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
