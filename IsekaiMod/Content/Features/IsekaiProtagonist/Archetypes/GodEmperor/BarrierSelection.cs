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

    internal class BarrierSelection {
        private static readonly Sprite Icon_DivineArray = AssetLoader.LoadInternal(IsekaiContext, "Features", "ICON_DIVINE_ARRAY.png");
        private static readonly Sprite Icon_DarkEnergyBarrier = AssetLoader.LoadInternal(IsekaiContext, "Features", "ICON_DARK_BARRIER.png");
        public static void Add() {
            var DivineArray = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "DivineArray", bp => {
                bp.SetName(IsekaiContext, "Divine Array");
                bp.SetDescription(IsekaiContext, "You gain resistance against all elements (acid, cold, electricity, fire, and sonic) "
                    + "equal to 10 + 2 times your character level. Your physical attacks are treated as good for the purpose of overcoming "
                    + "{g|Encyclopedia:Damage_Reduction}damage reduction{/g}.");
                bp.m_Icon = Icon_DivineArray;
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
            var DarkEnergyBarrier = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "DarkEnergyBarrier", bp => {
                bp.SetName(IsekaiContext, "Dark Energy Barrier");
                bp.SetDescription(IsekaiContext, "You gain resistance against all elements (acid, cold, electricity, fire, and sonic) "
                    + "equal to 10 + 2 times your character level. Your physical attacks are treated as evil for the purpose of overcoming "
                    + "{g|Encyclopedia:Damage_Reduction}damage reduction{/g}.");
                bp.m_Icon = Icon_DarkEnergyBarrier;
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

            var BarrierSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "BarrierSelection", bp => {
                bp.SetName(IsekaiContext, "God Emperor Barrier");
                bp.SetDescription(IsekaiContext, "At 5th level, the God Emperor is able to choose a barrier.");
                bp.m_Icon = Icon_DivineArray;
                bp.IgnorePrerequisites = true;
                bp.m_AllFeatures = new BlueprintFeatureReference[] {
                    DivineArray.ToReference<BlueprintFeatureReference>(),
                    DarkEnergyBarrier.ToReference<BlueprintFeatureReference>(),
                };
            });
        }
    }
}