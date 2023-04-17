using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Abilities.Blueprints;
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
        public static void Add() {

            var MajesticAuraFeature = TTCoreExtensions.CreateToggleAuraBuffFeature(
                name: "MajesticAura",
                description: "Allies within 40 feet of you gain a sacred bonus to all attributes equal to 1/2 your character level.",
                descriptionBuff: "This character has a sacred bonus to all attributes equal to 1/2 your character level.",
                icon: Icon_MajesticAura,
                targetType: BlueprintAbilityAreaEffect.TargetType.Ally,
                auraSize: new Feet(40),
                buffEffect: bp => {
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

            var SiphoningAuraFeature = TTCoreExtensions.CreateToggleAuraBuffFeature(
                name: "SiphoningAura",
                description: "Enemies within 40 feet of you take a penalty on all attributes equal to 1/2 your character level.",
                descriptionBuff: "This creature has a penalty on all attributes equal to 1/2 your character level.",
                icon: Icon_SiphoningAura,
                targetType: BlueprintAbilityAreaEffect.TargetType.Enemy,
                auraSize: new Feet(40),
                affectEnemies: true,
                buffEffect: bp => {
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

            var BodyMindAlterSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "BodyMindAlterSelection", bp => {
                bp.SetName(IsekaiContext, "Alteration of Body and Mind");
                bp.SetDescription(IsekaiContext, "At 10th level, you gain the ability to alter the bodies and minds of those around you.");
                bp.m_Icon = Icon_MajesticAura;
                bp.m_AllFeatures = new BlueprintFeatureReference[] {
                    MajesticAuraFeature.ToReference<BlueprintFeatureReference>(),
                    SiphoningAuraFeature.ToReference<BlueprintFeatureReference>(),
                };
            });

            SecretPowerSelection.AddToSelection(MajesticAuraFeature);
            SecretPowerSelection.AddToSelection(SiphoningAuraFeature);
        }
    }
}
