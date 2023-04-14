using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.Localization;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.Utility;
using TabletopTweaks.Core.Utilities;
using UnityEngine;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist {

    internal class IsekaiAuraSelection {
        private static readonly Sprite Icon_FriendlyAura = AssetLoader.LoadInternal(IsekaiContext, "Features", "ICON_AURA_FRIENDLY.png");
        private static readonly Sprite Icon_DarkAura = AssetLoader.LoadInternal(IsekaiContext, "Features", "ICON_AURA_DARK.png");
        private static readonly Sprite Icon_DivineAura = AssetLoader.LoadInternal(IsekaiContext, "Features", "ICON_AURA_DIVINE.png");

        public static void Add() {

            var FriendlyAuraFeature = TTCoreExtensions.CreateToggleAuraFeature(
                name: "FriendlyAura",
                description: "You emit an aura of friendship that cause enemies to subconsciously hold back.\nEnemies within 40 feet take a –4 penalty on attack and damage rolls.",
                descriptionBuff: "This creature has a –4 penalty on attack {g|Encyclopedia:Dice}rolls{/g}.",
                icon: Icon_FriendlyAura,
                targetType: BlueprintAbilityAreaEffect.TargetType.Enemy,
                auraSize: new Feet(40),
                affectEnemies: true,
                buffEffect: bp => {
                    bp.AddComponent<AddStatBonus>(c => {
                        c.Descriptor = ModifierDescriptor.Penalty;
                        c.Stat = StatType.AdditionalAttackBonus;
                        c.Value = -4;
                    });
                    bp.AddComponent<AddStatBonus>(c => {
                        c.Descriptor = ModifierDescriptor.Penalty;
                        c.Stat = StatType.AdditionalDamage;
                        c.Value = -4;
                    });
                });

            var DarkAuraFeature = TTCoreExtensions.CreateToggleAuraFeature(
                name: "DarkAura",
                description: "You emit an aura of darkness that cause enemies to become uneasy and vulnerable.\nEnemies within 40 feet take a –4 penalty on AC and saving throws.",
                descriptionBuff: "This creature has a –4 penalty on AC and saving throws.",
                icon: Icon_DarkAura,
                targetType: BlueprintAbilityAreaEffect.TargetType.Enemy,
                auraSize: new Feet(40),
                affectEnemies: true,
                buffEffect: bp => {
                    bp.AddComponent<AddStatBonus>(c => {
                        c.Descriptor = ModifierDescriptor.Penalty;
                        c.Stat = StatType.AC;
                        c.Value = -4;
                    });
                    bp.AddComponent<AddStatBonus>(c => {
                        c.Descriptor = ModifierDescriptor.Penalty;
                        c.Stat = StatType.SaveFortitude;
                        c.Value = -4;
                    });
                    bp.AddComponent<AddStatBonus>(c => {
                        c.Descriptor = ModifierDescriptor.Penalty;
                        c.Stat = StatType.SaveReflex;
                        c.Value = -4;
                    });
                    bp.AddComponent<AddStatBonus>(c => {
                        c.Descriptor = ModifierDescriptor.Penalty;
                        c.Stat = StatType.SaveWill;
                        c.Value = -4;
                    });
                });

            var DivineAuraFeature = TTCoreExtensions.CreateToggleAuraFeature(
                name: "DivineAura",
                description: "You emit an aura of divinity that cause enemies to be overcome with feelings of futility.\nEnemies within 40 feet take a –4 penalty on all attributes.",
                descriptionBuff: "This creature has a –4 penalty on all attributes.",
                icon: Icon_DivineAura,
                targetType: BlueprintAbilityAreaEffect.TargetType.Enemy,
                auraSize: new Feet(40),
                affectEnemies: true,
                buffEffect: bp => {
                    bp.AddComponent<AddStatBonus>(c => {
                        c.Descriptor = ModifierDescriptor.Penalty;
                        c.Stat = StatType.Strength;
                        c.Value = -4;
                    });
                    bp.AddComponent<AddStatBonus>(c => {
                        c.Descriptor = ModifierDescriptor.Penalty;
                        c.Stat = StatType.Dexterity;
                        c.Value = -4;
                    });
                    bp.AddComponent<AddStatBonus>(c => {
                        c.Descriptor = ModifierDescriptor.Penalty;
                        c.Stat = StatType.Constitution;
                        c.Value = -4;
                    });
                    bp.AddComponent<AddStatBonus>(c => {
                        c.Descriptor = ModifierDescriptor.Penalty;
                        c.Stat = StatType.Intelligence;
                        c.Value = -4;
                    });
                    bp.AddComponent<AddStatBonus>(c => {
                        c.Descriptor = ModifierDescriptor.Penalty;
                        c.Stat = StatType.Wisdom;
                        c.Value = -4;
                    });
                    bp.AddComponent<AddStatBonus>(c => {
                        c.Descriptor = ModifierDescriptor.Penalty;
                        c.Stat = StatType.Charisma;
                        c.Value = -4;
                    });
                });

            LocalizedString auraDescription = Helpers.CreateString(IsekaiContext, "AuraSelection.Description", "At 10th level, you are able to choose an aura.");
            var IsekaiAuraSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "IsekaiAuraSelection", bp => {
                bp.SetName(IsekaiContext, "Otherworldly Aura");
                bp.SetDescription(auraDescription);
                bp.m_Icon = Icon_FriendlyAura;
                bp.IgnorePrerequisites = true;
                bp.m_AllFeatures = new BlueprintFeatureReference[] {
                    FriendlyAuraFeature.ToReference<BlueprintFeatureReference>(),
                    DarkAuraFeature.ToReference<BlueprintFeatureReference>(),
                    DivineAuraFeature.ToReference<BlueprintFeatureReference>(),
                };
            });
            var GodEmperorAuraSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "GodEmperorAuraSelection", bp => {
                bp.SetName(IsekaiContext, "Regal Aura");
                bp.SetDescription(auraDescription);
                bp.m_Icon = Icon_DivineAura;
                bp.IgnorePrerequisites = true;
                bp.m_AllFeatures = new BlueprintFeatureReference[] {
                    DivineAuraFeature.ToReference<BlueprintFeatureReference>(),
                    DarkAuraFeature.ToReference<BlueprintFeatureReference>(),
                };
            });
            var HeroAuraSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "HeroAuraSelection", bp => {
                bp.SetName(IsekaiContext, "Heroic Aura");
                bp.SetDescription(auraDescription);
                bp.m_Icon = Icon_DivineAura;
                bp.IgnorePrerequisites = true;
                bp.m_AllFeatures = new BlueprintFeatureReference[] {
                    FriendlyAuraFeature.ToReference<BlueprintFeatureReference>(),
                    DivineAuraFeature.ToReference<BlueprintFeatureReference>(),
                };
            });
        }
    }
}