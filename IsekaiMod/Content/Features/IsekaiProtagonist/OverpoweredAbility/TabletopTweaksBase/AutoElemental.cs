using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.Designers.Mechanics.Recommendations;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.FactLogic;
using TabletopTweaks.Core.Utilities;
using UnityEngine;
using static TabletopTweaks.Core.MechanicsChanges.MetamagicExtention;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.OverpoweredAbility.TabletopTweaksBase {

    internal class AutoElemental {
        private static readonly Sprite Icon_ElementalAcidSpell = BlueprintTools.GetBlueprint<BlueprintFeature>("0114e94ae4ba4e1890d245a579ff871a").m_Icon;
        private static readonly Sprite Icon_ElementalColdSpell = BlueprintTools.GetBlueprint<BlueprintFeature>("5eeda1e5fcd04784a2b7b9724eebe04a").m_Icon;
        private static readonly Sprite Icon_ElementalElectricitySpell = BlueprintTools.GetBlueprint<BlueprintFeature>("579b8f5e9ad6417781a39b3dae147da2").m_Icon;
        private static readonly Sprite Icon_ElementalFireSpell = BlueprintTools.GetBlueprint<BlueprintFeature>("e5cd7ebbf00b4a0bbc80e623924bf7b6").m_Icon;

        private static readonly BlueprintActivatableAbility ElementalSpellSplitAbility = BlueprintTools.GetBlueprint<BlueprintActivatableAbility>("36a26221b979415584190e8197adcd0c");

        public static void Add() {

            var AutoElementalAcidFeature = TTCoreExtensions.CreateToggleBuffFeature(
                name: "AutoElementalAcid",
                displayName: "Overpowered Ability — Auto Elemental (Acid)",
                description: "Every time you cast a spell, you can replace or split its damage with acid damage, as though using the Elemental Spell (Acid) feat.",
                icon: Icon_ElementalAcidSpell,
                buffEffect: bp => {
                    bp.AddComponent<AutoMetamagic>(c => {
                        c.m_AllowedAbilities = AutoMetamagic.AllowedType.SpellOnly;
                        c.Metamagic = (Metamagic)CustomMetamagic.ElementalAcid;
                    });
                });

            var AutoElementalColdFeature = TTCoreExtensions.CreateToggleBuffFeature(
                name: "AutoElementalCold",
                displayName: "Overpowered Ability — Auto Elemental (Cold)",
                description: "Every time you cast a spell, you can replace or split its damage with cold damage, as though using the Elemental Spell (Cold) feat.",
                icon: Icon_ElementalColdSpell,
                buffEffect: bp => {
                    bp.AddComponent<AutoMetamagic>(c => {
                        c.m_AllowedAbilities = AutoMetamagic.AllowedType.SpellOnly;
                        c.Metamagic = (Metamagic)CustomMetamagic.ElementalCold;
                    });
                });

            var AutoElementalElectricityFeature = TTCoreExtensions.CreateToggleBuffFeature(
                name: "AutoElementalElectricity",
                displayName: "Overpowered Ability — Auto Elemental (Electricity)",
                description: "Every time you cast a spell, you can replace or split its damage with electricity damage, as though using the Elemental Spell (Electricity) feat.",
                icon: Icon_ElementalElectricitySpell,
                buffEffect: bp => {
                    bp.AddComponent<AutoMetamagic>(c => {
                        c.m_AllowedAbilities = AutoMetamagic.AllowedType.SpellOnly;
                        c.Metamagic = (Metamagic)CustomMetamagic.ElementalElectricity;
                    });
                });

            var AutoElementalFireFeature = TTCoreExtensions.CreateToggleBuffFeature(
                name: "AutoElementalFire",
                displayName: "Overpowered Ability — Auto Elemental (Fire)",
                description: "Every time you cast a spell, you can replace or split its damage with fire damage, as though using the Elemental Spell (Fire) feat.",
                icon: Icon_ElementalFireSpell,
                buffEffect: bp => {
                    bp.AddComponent<AutoMetamagic>(c => {
                        c.m_AllowedAbilities = AutoMetamagic.AllowedType.SpellOnly;
                        c.Metamagic = (Metamagic)CustomMetamagic.ElementalFire;
                    });
                });

            var autoElementalFeatures = new BlueprintFeature[] {
                AutoElementalAcidFeature,
                AutoElementalColdFeature,
                AutoElementalElectricityFeature,
                AutoElementalFireFeature
            };

            foreach (BlueprintFeature feature in autoElementalFeatures) {
                feature.Ranks = 1;
                feature.ReapplyOnLevelUp = true;
                feature.IsClassFeature = true;
                feature.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] {
                        ElementalSpellSplitAbility.ToReference<BlueprintUnitFactReference>(),
                    };
                });
                feature.AddPrerequisite<PrerequisiteStatValue>(c => {
                    c.Stat = StatType.Intelligence;
                    c.Value = 3;
                });
                feature.AddComponent<RecommendationRequiresSpellbook>();
            }

            AutoMetamagicSelection.AddToSelection(AutoElementalAcidFeature);
            AutoMetamagicSelection.AddToSelection(AutoElementalColdFeature);
            AutoMetamagicSelection.AddToSelection(AutoElementalElectricityFeature);
            AutoMetamagicSelection.AddToSelection(AutoElementalFireFeature);
        }
    }
}