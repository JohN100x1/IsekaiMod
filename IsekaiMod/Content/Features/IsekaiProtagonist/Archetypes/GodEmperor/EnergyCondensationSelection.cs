using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Enums;
using Kingmaker.Enums.Damage;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics.Components;
using TabletopTweaks.Core.Utilities;
using UnityEngine;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.GodEmperor {

    internal class EnergyCondensationSelection {
        private static readonly Sprite Icon_LightEnergyCondensation = AssetLoader.LoadInternal(IsekaiContext, "Features", "ICON_ENERGY_LIGHT.png");
        private static readonly Sprite Icon_DarkEnergyCondensation = AssetLoader.LoadInternal(IsekaiContext, "Features", "ICON_ENERGY_DARK.png");
        public static void Add() {
            var LightEnergyCondensation = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "LightEnergyCondensation", bp => {
                bp.SetName(IsekaiContext, "Light Energy Condensation");
                bp.SetDescription(IsekaiContext, "You gain resistance against all elements (acid, cold, electricity, fire, and sonic) "
                    + "equal to 10 + 2 times your character level. Your physical attacks are treated as good for the purpose of overcoming "
                    + "{g|Encyclopedia:Damage_Reduction}damage reduction{/g}.");
                bp.m_Icon = Icon_LightEnergyCondensation;
                bp.AddComponent<AddDamageResistanceEnergy>(c => {
                    c.Type = DamageEnergyType.Acid;
                    c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                });
                bp.AddComponent<AddDamageResistanceEnergy>(c => {
                    c.Type = DamageEnergyType.Cold;
                    c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                });
                bp.AddComponent<AddDamageResistanceEnergy>(c => {
                    c.Type = DamageEnergyType.Electricity;
                    c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                });
                bp.AddComponent<AddDamageResistanceEnergy>(c => {
                    c.Type = DamageEnergyType.Fire;
                    c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                });
                bp.AddComponent<AddDamageResistanceEnergy>(c => {
                    c.Type = DamageEnergyType.Sonic;
                    c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                });
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.StatBonus;
                    c.m_BaseValueType = ContextRankBaseValueType.CharacterLevel;
                    c.m_Progression = ContextRankProgression.DoublePlusBonusValue;
                    c.m_StepLevel = 10;
                });
                bp.AddComponent<AddOutgoingPhysicalDamageProperty>(c => {
                    c.AddAlignment = true;
                    c.Alignment = DamageAlignment.Good;
                });
                bp.ReapplyOnLevelUp = true;
            });
            var DarkEnergyCondensation = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "DarkEnergyCondensation", bp => {
                bp.SetName(IsekaiContext, "Dark Energy Condensation");
                bp.SetDescription(IsekaiContext, "You gain resistance against all elements (acid, cold, electricity, fire, and sonic) "
                    + "equal to 10 + 2 times your character level. Your physical attacks are treated as evil for the purpose of overcoming "
                    + "{g|Encyclopedia:Damage_Reduction}damage reduction{/g}.");
                bp.m_Icon = Icon_DarkEnergyCondensation;
                bp.AddComponent<AddDamageResistanceEnergy>(c => {
                    c.Type = DamageEnergyType.Acid;
                    c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                });
                bp.AddComponent<AddDamageResistanceEnergy>(c => {
                    c.Type = DamageEnergyType.Cold;
                    c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                });
                bp.AddComponent<AddDamageResistanceEnergy>(c => {
                    c.Type = DamageEnergyType.Electricity;
                    c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                });
                bp.AddComponent<AddDamageResistanceEnergy>(c => {
                    c.Type = DamageEnergyType.Fire;
                    c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                });
                bp.AddComponent<AddDamageResistanceEnergy>(c => {
                    c.Type = DamageEnergyType.Sonic;
                    c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                });
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.StatBonus;
                    c.m_BaseValueType = ContextRankBaseValueType.CharacterLevel;
                    c.m_Progression = ContextRankProgression.DoublePlusBonusValue;
                    c.m_StepLevel = 10;
                });
                bp.AddComponent<AddOutgoingPhysicalDamageProperty>(c => {
                    c.AddAlignment = true;
                    c.Alignment = DamageAlignment.Evil;
                });
                bp.ReapplyOnLevelUp = true;
            });

            var EnergyCondensationSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "EnergyCondensationSelection", bp => {
                bp.SetName(IsekaiContext, "Energy Condensation");
                bp.SetDescription(IsekaiContext, "At 5th level, you are able to condense your own internal energy to form a protective layer "
                    + "around you, giving you resistance against elemental damage.");
                bp.m_Icon = Icon_LightEnergyCondensation;
                bp.IgnorePrerequisites = true;
                bp.m_AllFeatures = new BlueprintFeatureReference[] {
                    LightEnergyCondensation.ToReference<BlueprintFeatureReference>(),
                    DarkEnergyCondensation.ToReference<BlueprintFeatureReference>(),
                };
            });
        }
    }
}