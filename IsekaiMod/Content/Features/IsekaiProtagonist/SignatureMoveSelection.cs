using IsekaiMod.Components;
using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Components;
using UnityEngine;

namespace IsekaiMod.Content.Features.IsekaiProtagonist
{
    class SignatureMoveSelection
    {
        private static readonly Sprite Icon_BatteringBlast = Resources.GetBlueprint<BlueprintAbility>("0a2f7c6aa81bc6548ac7780d8b70bcbc").m_Icon;
        private static readonly Sprite Icon_SwordSaintWeaponMastery = Resources.GetBlueprint<BlueprintFeature>("5b31af13868166d4c9bb452f19277f19").m_Icon;
        public static void Add()
        {
            var SignatureAttack = Helpers.CreateFeature("SignatureAttack", bp => {
                bp.SetName("Signature Attack");
                bp.SetDescription("You gain a luck bonus to {g|Encyclopedia:BAB}attack{/g} and damage rolls equal to 1/2 your character level.");
                bp.m_Icon = Icon_SwordSaintWeaponMastery;
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Luck;
                    c.Stat = StatType.AdditionalAttackBonus;
                    c.Value = new ContextValue()
                    {
                        ValueType = ContextValueType.Rank,
                        ValueRank = AbilityRankType.StatBonus
                    };
                });
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Luck;
                    c.Stat = StatType.AdditionalDamage;
                    c.Value = new ContextValue()
                    {
                        ValueType = ContextValueType.Rank,
                        ValueRank = AbilityRankType.StatBonus
                    };
                });
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.StatBonus;
                    c.m_BaseValueType = ContextRankBaseValueType.CharacterLevel;
                    c.m_Progression = ContextRankProgression.OnePlusDiv2;
                });
                bp.ReapplyOnLevelUp = true;
            });
            var SignatureAbility = Helpers.CreateFeature("SignatureAbility", bp => {
                bp.SetName("Signature Ability");
                bp.SetDescription("You gain a bonus to spell DC and spell hit point damage equal to 1/2 your character level.");
                bp.m_Icon = Icon_BatteringBlast;
                bp.AddComponent<IncreaseAllSpellsDC>(c => {
                    c.SpellsOnly = true;
                    c.Descriptor = ModifierDescriptor.UntypedStackable;
                    c.Value = new ContextValue()
                    {
                        ValueType = ContextValueType.Rank,
                        ValueRank = AbilityRankType.StatBonus
                    };
                });
                bp.AddComponent<IncreaseSpellDamage>(c => {
                    c.DamageBonus = new ContextValue()
                    {
                        ValueType = ContextValueType.Rank,
                        ValueRank = AbilityRankType.StatBonus
                    };
                });
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.StatBonus;
                    c.m_BaseValueType = ContextRankBaseValueType.CharacterLevel;
                    c.m_Progression = ContextRankProgression.OnePlusDiv2;
                });
                bp.ReapplyOnLevelUp = true;
            });

            var SignatureMoveSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>("SignatureMoveSelection", bp => {
                bp.SetName("Signature Move");
                bp.SetDescription("At 6th level, you choose to have either a signature attack or a signature ability.");
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
