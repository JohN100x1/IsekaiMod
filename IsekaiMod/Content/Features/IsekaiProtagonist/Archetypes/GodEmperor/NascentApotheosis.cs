using IsekaiMod.Content.Classes.IsekaiProtagonist;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics.Components;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.GodEmperor {

    internal class NascentApotheosis {

        public static void Add() {
            var Icon_Serenity = BlueprintTools.GetBlueprint<BlueprintAbility>("d316d3d94d20c674db2c24d7de96f6a7").m_Icon;
            var NascentApotheosis = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "NascentApotheosis", bp => {
                bp.SetName(IsekaiContext, "Nascent Apotheosis");
                bp.SetDescription(IsekaiContext, "The God Emperor gains an inherent bonus to all attributes equal to 1/2 their character level "
                    + "and {g|Encyclopedia:Damage_Reduction}DR{/g}/— and spell resistance equal to their character level."
                    + "\nAs they increase their level, they gain more immunities.");
                bp.m_Icon = Icon_Serenity;
                bp.ReapplyOnLevelUp = true;
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Inherent;
                    c.Stat = StatType.Strength;
                    c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                });
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Inherent;
                    c.Stat = StatType.Dexterity;
                    c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                });
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Inherent;
                    c.Stat = StatType.Constitution;
                    c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                });
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Inherent;
                    c.Stat = StatType.Intelligence;
                    c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                });
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Inherent;
                    c.Stat = StatType.Wisdom;
                    c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                });
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Inherent;
                    c.Stat = StatType.Charisma;
                    c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                });
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.StatBonus;
                    c.m_BaseValueType = ContextRankBaseValueType.CharacterLevel;
                    c.m_Progression = ContextRankProgression.Div2;
                });
                bp.AddComponent<AddDamageResistancePhysical>(c => {
                    c.Value = Values.CreateContextRankValue(AbilityRankType.Default);
                });
                bp.AddComponent<AddSpellResistance>(c => {
                    c.Value = Values.CreateContextRankValue(AbilityRankType.Default);
                });
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.Default;
                    c.m_BaseValueType = ContextRankBaseValueType.CharacterLevel;
                });
                bp.AddComponent<AddFeatureOnClassLevel>(c => {
                    c.m_Class = IsekaiProtagonistClass.GetReference();
                    c.Level = 1;
                    c.m_Feature = BlueprintTools.GetModBlueprintReference<BlueprintFeatureReference>(IsekaiContext, "BlindImmunity");
                });
                bp.AddComponent<AddFeatureOnClassLevel>(c => {
                    c.m_Class = IsekaiProtagonistClass.GetReference();
                    c.Level = 1;
                    c.m_Feature = BlueprintTools.GetModBlueprintReference<BlueprintFeatureReference>(IsekaiContext, "DazzledImmunity");
                });
                bp.AddComponent<AddFeatureOnClassLevel>(c => {
                    c.m_Class = IsekaiProtagonistClass.GetReference();
                    c.Level = 2;
                    c.m_Feature = BlueprintTools.GetModBlueprintReference<BlueprintFeatureReference>(IsekaiContext, "ShakenImmunity");
                });
                bp.AddComponent<AddFeatureOnClassLevel>(c => {
                    c.m_Class = IsekaiProtagonistClass.GetReference();
                    c.Level = 2;
                    c.m_Feature = BlueprintTools.GetModBlueprintReference<BlueprintFeatureReference>(IsekaiContext, "SickenedImmunity");
                });
                bp.AddComponent<AddFeatureOnClassLevel>(c => {
                    c.m_Class = IsekaiProtagonistClass.GetReference();
                    c.Level = 3;
                    c.m_Feature = BlueprintTools.GetModBlueprintReference<BlueprintFeatureReference>(IsekaiContext, "SlowImmunity");
                });
                bp.AddComponent<AddFeatureOnClassLevel>(c => {
                    c.m_Class = IsekaiProtagonistClass.GetReference();
                    c.Level = 3;
                    c.m_Feature = BlueprintTools.GetModBlueprintReference<BlueprintFeatureReference>(IsekaiContext, "EntangledImmunity");
                });
                bp.AddComponent<AddFeatureOnClassLevel>(c => {
                    c.m_Class = IsekaiProtagonistClass.GetReference();
                    c.Level = 4;
                    c.m_Feature = BlueprintTools.GetModBlueprintReference<BlueprintFeatureReference>(IsekaiContext, "StaggeredImmunity");
                });
                bp.AddComponent<AddFeatureOnClassLevel>(c => {
                    c.m_Class = IsekaiProtagonistClass.GetReference();
                    c.Level = 4;
                    c.m_Feature = BlueprintTools.GetModBlueprintReference<BlueprintFeatureReference>(IsekaiContext, "FrightenedImmunity");
                });
                bp.AddComponent<AddFeatureOnClassLevel>(c => {
                    c.m_Class = IsekaiProtagonistClass.GetReference();
                    c.Level = 5;
                    c.m_Feature = BlueprintTools.GetModBlueprintReference<BlueprintFeatureReference>(IsekaiContext, "PoisonImmunity");
                });
                bp.AddComponent<AddFeatureOnClassLevel>(c => {
                    c.m_Class = IsekaiProtagonistClass.GetReference();
                    c.Level = 5;
                    c.m_Feature = BlueprintTools.GetModBlueprintReference<BlueprintFeatureReference>(IsekaiContext, "DiseaseImmunity");
                });
                bp.AddComponent<AddFeatureOnClassLevel>(c => {
                    c.m_Class = IsekaiProtagonistClass.GetReference();
                    c.Level = 6;
                    c.m_Feature = BlueprintTools.GetModBlueprintReference<BlueprintFeatureReference>(IsekaiContext, "BleedImmunity");
                });
                bp.AddComponent<AddFeatureOnClassLevel>(c => {
                    c.m_Class = IsekaiProtagonistClass.GetReference();
                    c.Level = 6;
                    c.m_Feature = BlueprintTools.GetModBlueprintReference<BlueprintFeatureReference>(IsekaiContext, "StunImmunity");
                });
                bp.AddComponent<AddFeatureOnClassLevel>(c => {
                    c.m_Class = IsekaiProtagonistClass.GetReference();
                    c.Level = 7;
                    c.m_Feature = BlueprintTools.GetModBlueprintReference<BlueprintFeatureReference>(IsekaiContext, "ConfusionImmunity");
                });
                bp.AddComponent<AddFeatureOnClassLevel>(c => {
                    c.m_Class = IsekaiProtagonistClass.GetReference();
                    c.Level = 7;
                    c.m_Feature = BlueprintTools.GetModBlueprintReference<BlueprintFeatureReference>(IsekaiContext, "SleepImmunity");
                });
                bp.AddComponent<AddFeatureOnClassLevel>(c => {
                    c.m_Class = IsekaiProtagonistClass.GetReference();
                    c.Level = 8;
                    c.m_Feature = BlueprintTools.GetModBlueprintReference<BlueprintFeatureReference>(IsekaiContext, "MovementImpairingImmunity");
                });
                bp.AddComponent<AddFeatureOnClassLevel>(c => {
                    c.m_Class = IsekaiProtagonistClass.GetReference();
                    c.Level = 8;
                    c.m_Feature = BlueprintTools.GetModBlueprintReference<BlueprintFeatureReference>(IsekaiContext, "CoweringImmunity");
                });
                bp.AddComponent<AddFeatureOnClassLevel>(c => {
                    c.m_Class = IsekaiProtagonistClass.GetReference();
                    c.Level = 9;
                    c.m_Feature = BlueprintTools.GetModBlueprintReference<BlueprintFeatureReference>(IsekaiContext, "FearImmunity");
                });
                bp.AddComponent<AddFeatureOnClassLevel>(c => {
                    c.m_Class = IsekaiProtagonistClass.GetReference();
                    c.Level = 9;
                    c.m_Feature = BlueprintTools.GetModBlueprintReference<BlueprintFeatureReference>(IsekaiContext, "StatDamageNegativeLevelImmunity");
                });
                bp.AddComponent<AddFeatureOnClassLevel>(c => {
                    c.m_Class = IsekaiProtagonistClass.GetReference();
                    c.Level = 10;
                    c.m_Feature = BlueprintTools.GetModBlueprintReference<BlueprintFeatureReference>(IsekaiContext, "SneakAttackImmunity");
                });
                bp.AddComponent<AddFeatureOnClassLevel>(c => {
                    c.m_Class = IsekaiProtagonistClass.GetReference();
                    c.Level = 10;
                    c.m_Feature = BlueprintTools.GetModBlueprintReference<BlueprintFeatureReference>(IsekaiContext, "CriticalHitImmunity");
                });
                bp.AddComponent<AddFeatureOnClassLevel>(c => {
                    c.m_Class = IsekaiProtagonistClass.GetReference();
                    c.Level = 11;
                    c.m_Feature = BlueprintTools.GetModBlueprintReference<BlueprintFeatureReference>(IsekaiContext, "CharmImmunity");
                });
                bp.AddComponent<AddFeatureOnClassLevel>(c => {
                    c.m_Class = IsekaiProtagonistClass.GetReference();
                    c.Level = 11;
                    c.m_Feature = BlueprintTools.GetModBlueprintReference<BlueprintFeatureReference>(IsekaiContext, "CurseImmunity");
                });
                bp.AddComponent<AddFeatureOnClassLevel>(c => {
                    c.m_Class = IsekaiProtagonistClass.GetReference();
                    c.Level = 12;
                    c.m_Feature = BlueprintTools.GetModBlueprintReference<BlueprintFeatureReference>(IsekaiContext, "CompulsionImmunity");
                });
                bp.AddComponent<AddFeatureOnClassLevel>(c => {
                    c.m_Class = IsekaiProtagonistClass.GetReference();
                    c.Level = 12;
                    c.m_Feature = BlueprintTools.GetModBlueprintReference<BlueprintFeatureReference>(IsekaiContext, "MindAffectingImmunity");
                });
                bp.AddComponent<AddFeatureOnClassLevel>(c => {
                    c.m_Class = IsekaiProtagonistClass.GetReference();
                    c.Level = 13;
                    c.m_Feature = BlueprintTools.GetModBlueprintReference<BlueprintFeatureReference>(IsekaiContext, "DazedImmunity");
                });
                bp.AddComponent<AddFeatureOnClassLevel>(c => {
                    c.m_Class = IsekaiProtagonistClass.GetReference();
                    c.Level = 13;
                    c.m_Feature = BlueprintTools.GetModBlueprintReference<BlueprintFeatureReference>(IsekaiContext, "NauseatedImmunity");
                });
                bp.AddComponent<AddFeatureOnClassLevel>(c => {
                    c.m_Class = IsekaiProtagonistClass.GetReference();
                    c.Level = 14;
                    c.m_Feature = BlueprintTools.GetModBlueprintReference<BlueprintFeatureReference>(IsekaiContext, "HexImmunity");
                });
                bp.AddComponent<AddFeatureOnClassLevel>(c => {
                    c.m_Class = IsekaiProtagonistClass.GetReference();
                    c.Level = 14;
                    c.m_Feature = BlueprintTools.GetModBlueprintReference<BlueprintFeatureReference>(IsekaiContext, "DeathImmunity");
                });
                bp.AddComponent<AddFeatureOnClassLevel>(c => {
                    c.m_Class = IsekaiProtagonistClass.GetReference();
                    c.Level = 15;
                    c.m_Feature = BlueprintTools.GetModBlueprintReference<BlueprintFeatureReference>(IsekaiContext, "ParalyzedImmunity");
                });
                bp.AddComponent<AddFeatureOnClassLevel>(c => {
                    c.m_Class = IsekaiProtagonistClass.GetReference();
                    c.Level = 15;
                    c.m_Feature = BlueprintTools.GetModBlueprintReference<BlueprintFeatureReference>(IsekaiContext, "PetrifiedImmunity");
                });
            });
        }
    }
}