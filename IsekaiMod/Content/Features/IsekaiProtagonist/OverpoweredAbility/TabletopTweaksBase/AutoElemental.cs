using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.Designers.Mechanics.Recommendations;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.FactLogic;
using TabletopTweaks.Core.Utilities;
using UnityEngine;
using static IsekaiMod.Main;
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

            var AutoElementalSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "AutoElementalSelection", bp => {
                bp.SetName(IsekaiContext, "Overpowered Ability — Auto Elemental");
                bp.SetDescription(IsekaiContext, "You can manipulate the elemental nature of your spells.\n" +
                    "Benefit: Choose one energy type: acid, cold, electricity, or fire. You may replace a spell’s normal damage with that energy type " +
                    "or split the spell’s damage, so that half is of that energy type and half is of its normal type.\n" +
                    "Special: You can gain this feat multiple times. Each time you must choose a different energy type.");
                bp.m_Icon = ElementalSpellSplitAbility.m_Icon;
                bp.Ranks = 1;
                bp.ReapplyOnLevelUp = true;
                bp.IsClassFeature = true;
                bp.Groups = new FeatureGroup[0];
                bp.AddFeatures(
                    AutoElementalAcidFeature,
                    AutoElementalColdFeature,
                    AutoElementalElectricityFeature,
                    AutoElementalFireFeature
                );
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] {
                        ElementalSpellSplitAbility.ToReference<BlueprintUnitFactReference>(),
                    };
                });
                bp.AddPrerequisite<PrerequisiteStatValue>(c => {
                    c.Stat = StatType.Intelligence;
                    c.Value = 3;
                });
                bp.AddComponent<RecommendationRequiresSpellbook>();
            });

            OverpoweredAbilitySelection.AddToAllSelection(AutoElementalSelection);
        }
    }
}