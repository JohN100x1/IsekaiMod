using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.Localization;
using Kingmaker.UnitLogic.Abilities;
using TabletopTweaks.Core.Utilities;
using UnityEngine;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.OverpoweredAbility {

    internal class AutoMetamagicSelection {

        public static void Add() {
            Sprite Icon_AutoMagic = AssetLoader.LoadInternal(IsekaiContext, "Features", "ICON_AUTO_MAGIC.png");
            Sprite Icon_BolsterSpell = BlueprintTools.GetBlueprint<BlueprintFeature>("fbf5d9ce931f47f3a0c818b3f8ef8414").m_Icon;
            Sprite Icon_EmpowerSpell = BlueprintTools.GetBlueprint<BlueprintFeature>("a1de1e4f92195b442adb946f0e2b9d4e").m_Icon;
            Sprite Icon_ExtendSpell = BlueprintTools.GetBlueprint<BlueprintFeature>("f180e72e4a9cbaa4da8be9bc958132ef").m_Icon;
            Sprite Icon_MaximizeSpell = BlueprintTools.GetBlueprint<BlueprintFeature>("7f2b282626862e345935bbea5e66424b").m_Icon;
            Sprite Icon_QuickenSpell = BlueprintTools.GetBlueprint<BlueprintFeature>("ef7ece7bb5bb66a41b256976b27f424e").m_Icon;
            Sprite Icon_ReachSpell = BlueprintTools.GetBlueprint<BlueprintFeature>("46fad72f54a33dc4692d3b62eca7bb78").m_Icon;
            Sprite Icon_SelectiveSpell = BlueprintTools.GetBlueprint<BlueprintFeature>("85f3340093d144dd944fff9a9adfd2f2").m_Icon;

            var AutoBolsterFeature = CreateAutoMetamagicFeature(
                name: "AutoBolster",
                displayName: "Overpowered Ability — Auto Bolster",
                description: "Every time you cast a spell, it becomes bolstered, as though using the Bolster Spell feat.",
                icon: Icon_BolsterSpell,
                metamagic: Metamagic.Bolstered
                );
            var AutoEmpowerFeature = CreateAutoMetamagicFeature(
                name: "AutoEmpower",
                displayName: "Overpowered Ability — Auto Empower",
                description: "Every time you cast a spell, it becomes empowered, as though using the Empower Spell feat.",
                icon: Icon_EmpowerSpell,
                metamagic: Metamagic.Empower
                );
            var AutoExtendFeature = CreateAutoMetamagicFeature(
                name: "AutoExtend",
                displayName: "Overpowered Ability — Auto Extend",
                description: "Every time you cast a spell, it becomes extended, as though using the Extend Spell feat.",
                icon: Icon_ExtendSpell,
                metamagic: Metamagic.Extend
                );
            var AutoMaximizeFeature = CreateAutoMetamagicFeature(
                name: "AutoMaximize",
                displayName: "Overpowered Ability — Auto Maximize",
                description: "Every time you cast a spell, it becomes maximized, as though using the Maximize Spell feat.",
                icon: Icon_MaximizeSpell,
                metamagic: Metamagic.Maximize
                );
            var AutoQuickenFeature = CreateAutoMetamagicFeature(
                name: "AutoQuicken",
                displayName: "Overpowered Ability — Auto Quicken",
                description: "Every time you cast a spell, it becomes quickened, as though using the Quicken Spell feat.",
                icon: Icon_QuickenSpell,
                metamagic: Metamagic.Quicken
                );
            var AutoReachFeature = CreateAutoMetamagicFeature(
                name: "AutoReach",
                displayName: "Overpowered Ability — Auto Reach",
                description: "Every time you cast a spell, it increases its range by one range category, as though using the Reach Spell feat.",
                icon: Icon_ReachSpell,
                metamagic: Metamagic.Reach
                );
            var AutoSelectiveFeature = CreateAutoMetamagicFeature(
                name: "AutoSelective",
                displayName: "Overpowered Ability — Auto Selective",
                description: "Every time you cast a spell, you can exclude targets from the effects of your spell, as though using the Selective Spell feat.",
                icon: Icon_SelectiveSpell,
                metamagic: Metamagic.Selective
                );


            LocalizedString AutoMetamagicDesc = Helpers.CreateString(IsekaiContext, "AutometamagicSelection.Description",
                "You gain powerful metamagic effects that automatically apply to your spells.");
            var AutoMetamagicSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "AutoMetamagicSelection", bp => {
                bp.SetName(IsekaiContext, "Overpowered Ability — Auto Metamagic");
                bp.SetDescription(AutoMetamagicDesc);
                bp.m_Icon = Icon_AutoMagic;
                bp.m_AllFeatures = new BlueprintFeatureReference[] {
                    AutoBolsterFeature.ToReference<BlueprintFeatureReference>(),
                    AutoEmpowerFeature.ToReference<BlueprintFeatureReference>(),
                    AutoExtendFeature.ToReference<BlueprintFeatureReference>(),
                    AutoMaximizeFeature.ToReference<BlueprintFeatureReference>(),
                    AutoQuickenFeature.ToReference<BlueprintFeatureReference>(),
                    AutoReachFeature.ToReference<BlueprintFeatureReference>(),
                    AutoSelectiveFeature.ToReference<BlueprintFeatureReference>(),
                };
            });
            var AutoMetamagicSelectionMastermind = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "AutoMetamagicSelectionMastermind", bp => {
                bp.SetName(IsekaiContext, "Auto Metamagic");
                bp.SetDescription(AutoMetamagicDesc);
                bp.m_Icon = Icon_AutoMagic;
                bp.m_AllFeatures = new BlueprintFeatureReference[] {
                    AutoBolsterFeature.ToReference<BlueprintFeatureReference>(),
                    AutoEmpowerFeature.ToReference<BlueprintFeatureReference>(),
                    AutoExtendFeature.ToReference<BlueprintFeatureReference>(),
                    AutoMaximizeFeature.ToReference<BlueprintFeatureReference>(),
                    AutoQuickenFeature.ToReference<BlueprintFeatureReference>(),
                    AutoReachFeature.ToReference<BlueprintFeatureReference>(),
                    AutoSelectiveFeature.ToReference<BlueprintFeatureReference>(),
                };
            });

            OverpoweredAbilitySelection.AddToSelection(AutoMetamagicSelection);
        }
        public static void AddToSelection(BlueprintFeature feature) {
            var AutoMetamagicSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "AutoMetamagicSelection");
            var AutoMetamagicSelectionMastermind = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "AutoMetamagicSelectionMastermind");
            AutoMetamagicSelection.AddToSelection(feature);
            AutoMetamagicSelectionMastermind.AddToSelection(feature);
        }
        private static BlueprintFeature CreateAutoMetamagicFeature(string name, string displayName, string description, Sprite icon, Metamagic metamagic) {
            return TTCoreExtensions.CreateToggleBuffFeature(
                name: name,
                displayName: displayName,
                description: description,
                icon: icon,
                buffEffect: bp => {
                    bp.AddComponent<AutoMetamagic>(c => {
                        c.m_AllowedAbilities = AutoMetamagic.AllowedType.SpellOnly;
                        c.Metamagic = metamagic;
                    });
                });
        }
    }
}