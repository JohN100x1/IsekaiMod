using IsekaiMod.Components;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics.Components;
using TabletopTweaks.Core.Utilities;
using UnityEngine;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist {

    internal class SignatureMoveSelection {
        private static readonly Sprite Icon_MutagenResource = BlueprintTools.GetBlueprint<BlueprintAbilityResource>("3b163587f010382408142fc8a97852b6").m_Icon;
        private static readonly Sprite Icon_SwordSaintWeaponMastery = BlueprintTools.GetBlueprint<BlueprintFeature>("5b31af13868166d4c9bb452f19277f19").m_Icon;

        public static void Add() {
            var SignatureAttack = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "SignatureAttack", bp => {
                bp.SetName(IsekaiContext, "Signature Attack");
                bp.SetDescription(IsekaiContext, "You gain a luck bonus to {g|Encyclopedia:BAB}attack{/g} and damage rolls equal to 1/2 your character level.");
                bp.m_Icon = Icon_SwordSaintWeaponMastery;
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Luck;
                    c.Stat = StatType.AdditionalAttackBonus;
                    c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                });
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Luck;
                    c.Stat = StatType.AdditionalDamage;
                    c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                });
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.StatBonus;
                    c.m_BaseValueType = ContextRankBaseValueType.CharacterLevel;
                    c.m_Progression = ContextRankProgression.OnePlusDiv2;
                });
                bp.ReapplyOnLevelUp = true;
            });
            var SignatureAbility = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "SignatureAbility", bp => {
                bp.SetName(IsekaiContext, "Signature Ability");
                bp.SetDescription(IsekaiContext, "You gain a bonus to spell DC and spell hit point damage equal to 1/2 your character level.");
                bp.m_Icon = Icon_MutagenResource;
                bp.AddComponent<IncreaseAllSpellsDC>(c => {
                    c.SpellsOnly = true;
                    c.Descriptor = ModifierDescriptor.UntypedStackable;
                    c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                });
                bp.AddComponent<IncreaseSpellDamage>(c => {
                    c.DamageBonus = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                });
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.StatBonus;
                    c.m_BaseValueType = ContextRankBaseValueType.CharacterLevel;
                    c.m_Progression = ContextRankProgression.OnePlusDiv2;
                });
                bp.ReapplyOnLevelUp = true;
            });

            var SignatureMoveSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "SignatureMoveSelection", bp => {
                bp.SetName(IsekaiContext, "Signature Move");
                bp.SetDescription(IsekaiContext, "At 6th level, you choose to have either a signature attack or a signature ability.");
                bp.m_Icon = Icon_SwordSaintWeaponMastery;
                bp.IgnorePrerequisites = true;
                bp.m_AllFeatures = new BlueprintFeatureReference[] {
                    SignatureAttack.ToReference<BlueprintFeatureReference>(),
                    SignatureAbility.ToReference<BlueprintFeatureReference>(),
                };
            });
        }
    }
}