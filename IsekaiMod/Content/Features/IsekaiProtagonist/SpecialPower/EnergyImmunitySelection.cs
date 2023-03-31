using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Enums.Damage;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using TabletopTweaks.Core.Utilities;
using UnityEngine;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.SpecialPower {

    internal class EnergyImmunitySelection {
        private static readonly Sprite Icon_ProtectionFromAcid = BlueprintTools.GetBlueprint<BlueprintAbility>("3d77ee3fc4913c44b9df7c5bbcdc4906").m_Icon;
        private static readonly Sprite Icon_ProtectionFromCold = BlueprintTools.GetBlueprint<BlueprintAbility>("021d39c8e0eec384ba69140f4875e166").m_Icon;
        private static readonly Sprite Icon_ProtectionFromFire = BlueprintTools.GetBlueprint<BlueprintAbility>("3f9605134d34e1243b096e1f6cb4c148").m_Icon;
        private static readonly Sprite Icon_ProtectionFromElectricity = BlueprintTools.GetBlueprint<BlueprintAbility>("e24ce0c3e8eaaaf498d3656b534093df").m_Icon;
        private static readonly Sprite Icon_ProtectionFromSonic = BlueprintTools.GetBlueprint<BlueprintAbility>("0cee375b4e5265a46a13fc269beb8763").m_Icon;
        private static readonly Sprite Icon_ProtectionFromEnergy = BlueprintTools.GetBlueprint<BlueprintAbility>("d2f116cfe05fcdd4a94e80143b67046f").m_Icon;

        public static void Add() {
            // Features
            var AcidImmunity = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "AcidImmunity", bp => {
                bp.SetName(IsekaiContext, "Acid Immunity");
                bp.SetDescription(IsekaiContext, "You gain immunity to Acid.");
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
            });
            var ColdImmunity = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "ColdImmunity", bp => {
                bp.SetName(IsekaiContext, "Cold Immunity");
                bp.SetDescription(IsekaiContext, "You gain immunity to Cold.");
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
            });
            var FireImmunity = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "FireImmunity", bp => {
                bp.SetName(IsekaiContext, "Fire Immunity");
                bp.SetDescription(IsekaiContext, "You gain immunity to Fire.");
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
            });
            var ElectricityImmunity = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "ElectricityImmunity", bp => {
                bp.SetName(IsekaiContext, "Electricity Immunity");
                bp.SetDescription(IsekaiContext, "You gain immunity to Electricity.");
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
            });
            var SonicImmunity = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "SonicImmunity", bp => {
                bp.SetName(IsekaiContext, "Sonic Immunity");
                bp.SetDescription(IsekaiContext, "You gain immunity to Sonic.");
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
            });

            var EnergyImmunityList = new BlueprintFeatureReference[] {
                AcidImmunity.ToReference<BlueprintFeatureReference>(),
                ColdImmunity.ToReference<BlueprintFeatureReference>(),
                FireImmunity.ToReference<BlueprintFeatureReference>(),
                ElectricityImmunity.ToReference<BlueprintFeatureReference>(),
                SonicImmunity.ToReference<BlueprintFeatureReference>(),
            };

            // Energy Immunity Selection
            var EnergyImmunitySelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "EnergyImmunitySelection", bp => {
                bp.SetName(IsekaiContext, "Energy Immunity");
                bp.SetDescription(IsekaiContext, "You gain energy immunity of a particular type.");
                bp.m_Icon = Icon_ProtectionFromEnergy;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.m_Features = EnergyImmunityList;
                bp.m_AllFeatures = EnergyImmunityList;
            });
            SpecialPowerSelection.AddToSelection(EnergyImmunitySelection);
        }
    }
}