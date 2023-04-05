using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.ResourceLinks;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Buffs.Components;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.Utility;
using TabletopTweaks.Core.Utilities;
using UnityEngine;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.GodEmperor {
    internal class BodyMindAlterSelection {
        private static readonly Sprite Icon_MajesticAura = AssetLoader.LoadInternal(IsekaiContext, "Features", "ICON_AURA_MAJESTIC.png");
        private static readonly Sprite Icon_SiphoningAura = AssetLoader.LoadInternal(IsekaiContext, "Features", "ICON_AURA_SIPHONING.png");
        private static readonly Sprite Icon_HellsSeal = BlueprintTools.GetBlueprint<BlueprintFeature>("b6798b29d36982b4786a32dfd81a914f").m_Icon;
        public static void Add() {
            const string MajesticAuraName = "Majestic Aura";
            const string MajesticAuraDesc = "Allies within 40 feet of you gain a sacred bonus to all attributes equal to 1/2 your character level.";
            const string MajesticAuraDescBuff = "This character has a sacred bonus to all attributes equal to 1/2 your character level.";
            var MajesticAuraBuff = TTCoreExtensions.CreateBuff("MajesticAuraBuff", bp => {
                bp.SetName(IsekaiContext, MajesticAuraName);
                bp.SetDescription(IsekaiContext, MajesticAuraDescBuff);
                bp.IsClassFeature = true;
                bp.m_Icon = Icon_MajesticAura;
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Sacred;
                    c.Stat = StatType.Strength;
                    c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                });
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Sacred;
                    c.Stat = StatType.Dexterity;
                    c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                });
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Sacred;
                    c.Stat = StatType.Constitution;
                    c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                });
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Sacred;
                    c.Stat = StatType.Intelligence;
                    c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                });
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Sacred;
                    c.Stat = StatType.Wisdom;
                    c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                });
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Sacred;
                    c.Stat = StatType.Charisma;
                    c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                });
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.StatBonus;
                    c.m_BaseValueType = ContextRankBaseValueType.CharacterLevel;
                    c.m_Progression = ContextRankProgression.Div2;
                });
            });
            var MajesticAuraArea = Helpers.CreateBlueprint<BlueprintAbilityAreaEffect>(IsekaiContext, "MajesticAuraArea", bp => {
                bp.m_TargetType = BlueprintAbilityAreaEffect.TargetType.Ally;
                bp.SpellResistance = false;
                bp.AggroEnemies = false;
                bp.AffectEnemies = false;
                bp.Shape = AreaEffectShape.Cylinder;
                bp.Size = new Feet(40);
                bp.Fx = new PrefabLink();
                bp.AddComponent(AuraUtils.CreateUnconditionalAuraEffect(MajesticAuraBuff.ToReference<BlueprintBuffReference>()));
            });
            var MajesticAuraAreaBuff = TTCoreExtensions.CreateBuff("MajesticAuraAreaBuff", bp => {
                bp.SetName(IsekaiContext, MajesticAuraName);
                bp.SetDescription(IsekaiContext, MajesticAuraDesc);
                bp.m_Icon = Icon_MajesticAura;
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.HiddenInUi;
                bp.AddComponent<AddAreaEffect>(c => {
                    c.m_AreaEffect = MajesticAuraArea.ToReference<BlueprintAbilityAreaEffectReference>();
                });
            });
            var MajesticAuraAbility = TTCoreExtensions.CreateActivatableAbility("MajesticAuraAbility", bp => {
                bp.SetName(IsekaiContext, MajesticAuraName);
                bp.SetDescription(IsekaiContext, MajesticAuraDesc);
                bp.m_Icon = Icon_MajesticAura;
                bp.m_Buff = MajesticAuraAreaBuff.ToReference<BlueprintBuffReference>();
                bp.DoNotTurnOffOnRest = true;
            });
            var MajesticAuraFeature = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "MajesticAuraFeature", bp => {
                bp.SetName(IsekaiContext, MajesticAuraName);
                bp.SetDescription(IsekaiContext, MajesticAuraDesc);
                bp.m_Icon = Icon_MajesticAura;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { MajesticAuraAbility.ToReference<BlueprintUnitFactReference>() };
                });
            });

            const string SiphoningAuraName = "Siphoning Aura";
            const string SiphoningAuraDesc = "Enemies within 40 feet of you take a penalty on all attributes equal to 1/2 your character level.";
            const string SiphoningAuraDescBuff = "This creature has a penalty on all attributes equal to 1/2 your character level.";
            var SiphoningAuraBuff = TTCoreExtensions.CreateBuff("SiphoningAuraBuff", bp => {
                bp.SetName(IsekaiContext, SiphoningAuraName);
                bp.SetDescription(IsekaiContext, SiphoningAuraDescBuff);
                bp.IsClassFeature = true;
                bp.m_Icon = Icon_HellsSeal;
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Penalty;
                    c.Stat = StatType.Strength;
                    c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                });
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Penalty;
                    c.Stat = StatType.Dexterity;
                    c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                });
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Penalty;
                    c.Stat = StatType.Constitution;
                    c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                });
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Penalty;
                    c.Stat = StatType.Intelligence;
                    c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                });
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Penalty;
                    c.Stat = StatType.Wisdom;
                    c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                });
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Penalty;
                    c.Stat = StatType.Charisma;
                    c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                });
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.StatBonus;
                    c.m_BaseValueType = ContextRankBaseValueType.CharacterLevel;
                    c.m_Progression = ContextRankProgression.DivStep;
                    c.m_StepLevel = -2;
                });
            });
            var SiphoningAuraArea = Helpers.CreateBlueprint<BlueprintAbilityAreaEffect>(IsekaiContext, "SiphoningAuraArea", bp => {
                bp.m_TargetType = BlueprintAbilityAreaEffect.TargetType.Enemy;
                bp.SpellResistance = false;
                bp.AggroEnemies = false;
                bp.AffectEnemies = true;
                bp.Shape = AreaEffectShape.Cylinder;
                bp.Size = new Feet(40);
                bp.Fx = new PrefabLink();
                bp.AddComponent(AuraUtils.CreateUnconditionalAuraEffect(SiphoningAuraBuff.ToReference<BlueprintBuffReference>()));
            });
            var SiphoningAuraAreaBuff = TTCoreExtensions.CreateBuff("SiphoningAuraAreaBuff", bp => {
                bp.SetName(IsekaiContext, SiphoningAuraName);
                bp.SetDescription(IsekaiContext, SiphoningAuraDesc);
                bp.m_Icon = Icon_SiphoningAura;
                bp.IsClassFeature = true;
                bp.AddComponent<AddAreaEffect>(c => {
                    c.m_AreaEffect = SiphoningAuraArea.ToReference<BlueprintAbilityAreaEffectReference>();
                });
            });
            var SiphoningAuraAbility = TTCoreExtensions.CreateActivatableAbility("SiphoningAuraAbility", bp => {
                bp.SetName(IsekaiContext, SiphoningAuraName);
                bp.SetDescription(IsekaiContext, SiphoningAuraDesc);
                bp.m_Icon = Icon_SiphoningAura;
                bp.m_Buff = SiphoningAuraAreaBuff.ToReference<BlueprintBuffReference>();
                bp.DoNotTurnOffOnRest = true;
            });
            var SiphoningAuraFeature = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "SiphoningAuraFeature", bp => {
                bp.SetName(IsekaiContext, SiphoningAuraName);
                bp.SetDescription(IsekaiContext, SiphoningAuraDesc);
                bp.m_Icon = Icon_SiphoningAura;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { SiphoningAuraAbility.ToReference<BlueprintUnitFactReference>() };
                });
            });

            var BodyMindAlterSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "BodyMindAlterSelection", bp => {
                bp.SetName(IsekaiContext, "Alteration of Body and Mind");
                bp.SetDescription(IsekaiContext, "At 10th level, you gain the ability to alter the body and mind of those around you.");
                bp.m_Icon = Icon_MajesticAura;
                bp.IgnorePrerequisites = true;
                bp.m_AllFeatures = new BlueprintFeatureReference[] {
                    MajesticAuraFeature.ToReference<BlueprintFeatureReference>(),
                    SiphoningAuraFeature.ToReference<BlueprintFeatureReference>(),
                };
            });
        }
    }
}
