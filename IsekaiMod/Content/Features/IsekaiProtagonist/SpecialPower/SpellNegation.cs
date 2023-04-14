using IsekaiMod.Utilities;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics.Components;
using TabletopTweaks.Core.Utilities;
using UnityEngine;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.SpecialPower {

    internal class SpellNegation {
        private static readonly Sprite Icon_SpellResistance = BlueprintTools.GetBlueprint<BlueprintAbility>("0a5ddfbcfb3989543ac7c936fc256889").m_Icon;

        public static void Add() {

            var SpellNegationFeature = TTCoreExtensions.CreateToggleBuffFeature(
                name: "SpellNegation",
                description: "You gain spell resistance equal to 10 + twice your character level.",
                icon: Icon_SpellResistance,
                buffEffect: bp => {
                    bp.AddComponent<AddSpellResistance>(c => {
                        c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                    });
                    bp.AddComponent<ContextRankConfig>(c => {
                        c.m_Type = AbilityRankType.StatBonus;
                        c.m_BaseValueType = ContextRankBaseValueType.CharacterLevel;
                        c.m_Progression = ContextRankProgression.DoublePlusBonusValue;
                        c.m_StepLevel = 10;
                    });
                });


            SpecialPowerSelection.AddToSelection(SpellNegationFeature);
        }
    }
}