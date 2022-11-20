using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Enums;
using Kingmaker.ResourceLinks;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Components;
using UnityEngine;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.CharacterDevelopment
{
    class SpellNegation
    {
        private static readonly Sprite Icon_SpellResistance = Resources.GetBlueprint<BlueprintAbility>("0a5ddfbcfb3989543ac7c936fc256889").m_Icon;
        public static void Add()
        {
            var SpellNegationBuff = Helpers.CreateBlueprint<BlueprintBuff>("SpellNegationBuff", bp => {
                bp.SetName("Spell Negation");
                bp.SetDescription("You gain spell resistance equal to 10 + twice your character level.");
                bp.m_Icon = Icon_SpellResistance;
                bp.AddComponent<AddSpellResistance>(c => {
                    c.Value = new ContextValue()
                    {
                        ValueType = ContextValueType.Rank,
                        ValueRank = AbilityRankType.StatBonus
                    };
                });
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.StatBonus;
                    c.m_BaseValueType = ContextRankBaseValueType.CharacterLevel;
                    c.m_Progression = ContextRankProgression.DoublePlusBonusValue;
                    c.m_StepLevel = 10;
                });
                bp.Stacking = StackingType.Replace;
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.StayOnDeath;
                bp.FxOnStart = new PrefabLink();
                bp.FxOnRemove = new PrefabLink();
            });
            var SpellNegationAbility = Helpers.CreateBlueprint<BlueprintActivatableAbility>("SpellNegationAbility", bp => {
                bp.SetName("Spell Negation");
                bp.SetDescription("You gain spell resistance equal to 10 + twice your character level.");
                bp.m_Icon = Icon_SpellResistance;
                bp.m_Buff = SpellNegationBuff.ToReference<BlueprintBuffReference>();
                bp.Group = ActivatableAbilityGroup.None;
                bp.WeightInGroup = 1;
                bp.IsOnByDefault = true;
                bp.DeactivateImmediately = true;
                bp.ActivationType = AbilityActivationType.Immediately;
            });
            var SpellNegationFeature = Helpers.CreateBlueprint<BlueprintFeature>("SpellNegationFeature", bp => {
                bp.SetName("Spell Negation");
                bp.SetDescription("After extensive studying of spells, you gain spell resistance equal to 10 + twice your character level.");
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { SpellNegationAbility.ToReference<BlueprintUnitFactReference>() };
                });
                bp.m_Icon = Icon_SpellResistance;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });

            CharacterDevelopmentSelection.AddToSelection(SpellNegationFeature);
        }
    }
}
