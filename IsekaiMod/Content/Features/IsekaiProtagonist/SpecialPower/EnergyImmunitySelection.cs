using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Enums.Damage;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using System.Linq;
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

            var EnergyImmunityList = new BlueprintFeatureReference[] {
                CreateImmunity("AcidImmunity", "You gain immunity to Acid.", Icon_ProtectionFromAcid, DamageEnergyType.Acid, SpellDescriptor.Acid),
                CreateImmunity("ColdImmunity", "You gain immunity to Cold.", Icon_ProtectionFromCold, DamageEnergyType.Cold, SpellDescriptor.Cold),
                CreateImmunity("FireImmunity", "You gain immunity to Fire.", Icon_ProtectionFromFire, DamageEnergyType.Fire, SpellDescriptor.Fire),
                CreateImmunity("ElectricityImmunity", "You gain immunity to Electricity.", Icon_ProtectionFromElectricity, DamageEnergyType.Electricity, SpellDescriptor.Electricity),
                CreateImmunity("SonicImmunity", "You gain immunity to Sonic.", Icon_ProtectionFromSonic, DamageEnergyType.Sonic, SpellDescriptor.Sonic),
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
        private static BlueprintFeatureReference CreateImmunity(string name, string description, Sprite icon, DamageEnergyType energy, SpellDescriptor descriptor) {
            var feature = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, name, bp => {
                bp.SetName(IsekaiContext, string.Concat(name.Select(x => char.IsUpper(x) ? " " + x : x.ToString())).TrimStart(' '));
                bp.SetDescription(IsekaiContext, description);
                bp.m_Icon = icon;
                bp.AddComponent<AddEnergyImmunity>(c => {
                    c.Type = energy;
                });
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = descriptor;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = descriptor;
                });
            });
            return feature.ToReference<BlueprintFeatureReference>();
        }
    }
}