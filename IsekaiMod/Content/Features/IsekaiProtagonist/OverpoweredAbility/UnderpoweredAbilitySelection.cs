using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using TabletopTweaks.Core.Utilities;
using UnityEngine;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.OverpoweredAbility {

    internal class UnderpoweredAbilitySelection {

        public static void Add() {
            Sprite Icon_Haste = BlueprintTools.GetBlueprint<BlueprintAbility>("486eaff58293f6441a5c2759c4872f98").m_Icon;
            Sprite Icon_BelieveInYourselfStrength = BlueprintTools.GetBlueprint<BlueprintAbility>("9f476da1aa712284d8e652fc387ce5bb").m_Icon;
            Sprite Icon_CrystalMind = BlueprintTools.GetBlueprint<BlueprintAbility>("4733d8dd549ff544395f1684ec73c392").m_Icon;
            Sprite Icon_EuphoricTranquility = BlueprintTools.GetBlueprint<BlueprintAbility>("cbf3bafa8375340498b86a3313a11e2f").m_Icon;

            var DodgeMaster = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "DodgeMaster", bp => {
                bp.SetName(IsekaiContext, "Underpowered Ability — Dodge Master");
                bp.SetDescription(IsekaiContext, "You gain a +2 dodge {g|Encyclopedia:Bonus}bonus{/g} to your {g|Encyclopedia:Armor_Class}AC{/g}.");
                bp.m_Icon = Icon_Haste;
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Dodge;
                    c.Stat = StatType.AC;
                    c.Value = 2;
                });
            });

            var BulkMaster = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "BulkMaster", bp => {
                bp.SetName(IsekaiContext, "Underpowered Ability — Bulk Master");
                bp.SetDescription(IsekaiContext, "You gain +10 {g|Encyclopedia:HP}hit points{/g} and a +1 bonus to your Strength.");
                bp.m_Icon = Icon_BelieveInYourselfStrength;
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.UntypedStackable;
                    c.Stat = StatType.HitPoints;
                    c.Value = 10;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.UntypedStackable;
                    c.Stat = StatType.Strength;
                    c.Value = 1;
                });
            });

            var ThoughtMaster = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "ThoughtMaster", bp => {
                bp.SetName(IsekaiContext, "Underpowered Ability — Thought Master");
                bp.SetDescription(IsekaiContext, "You gain a +1 bonus to your {g|Encyclopedia:Intelligence}Intelligence{/g} and {g|Encyclopedia:Wisdom}Wisdom{/g}.");
                bp.m_Icon = Icon_CrystalMind;
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.UntypedStackable;
                    c.Stat = StatType.Intelligence;
                    c.Value = 1;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.UntypedStackable;
                    c.Stat = StatType.Wisdom;
                    c.Value = 1;
                });
            });

            var UnderpoweredAbilitySelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "UnderpoweredAbilitySelection", bp => {
                bp.SetName(IsekaiContext, "Underpowered Ability");
                bp.SetDescription(IsekaiContext, "Sometimes you just want to be reborn into a quiet life.");
                bp.m_Icon = Icon_EuphoricTranquility;
                bp.m_AllFeatures = new BlueprintFeatureReference[] {
                    DodgeMaster.ToReference<BlueprintFeatureReference>(),
                    BulkMaster.ToReference<BlueprintFeatureReference>(),
                    ThoughtMaster.ToReference<BlueprintFeatureReference>(),
                };
            });

            OverpoweredAbilitySelection.AddToSelection(UnderpoweredAbilitySelection);
        }
    }
}