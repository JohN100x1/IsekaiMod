using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.Utility;
using TabletopTweaks.Core.Utilities;
using UnityEngine;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.SpecialPower {

    internal class ExtremeSpeed {
        private static readonly Sprite Icon_SupersonicSpeed = BlueprintTools.GetBlueprint<BlueprintFeature>("505456aa17dd18a4e8bd8172811a4fdc").m_Icon;

        public static void Add() {

            var ExtremeSpeedFeature = TTCoreExtensions.CreateToggleAuraFeature(
                name: "ExtremeSpeed",
                description: "Allies within 40 feet of you gain a {g|Encyclopedia:Bonus}bonus{/g} to your {g|Encyclopedia:Speed}speed{/g} equal to 5 times your character level.",
                descriptionBuff: "This creature gains a {g|Encyclopedia:Bonus}bonus{/g} to their {g|Encyclopedia:Speed}speed{/g}.",
                icon: Icon_SupersonicSpeed,
                targetType: BlueprintAbilityAreaEffect.TargetType.Ally,
                auraSize: new Feet(120),
                buffEffect: bp => {
                    bp.AddComponent<AddContextStatBonus>(c => {
                        c.Descriptor = ModifierDescriptor.UntypedStackable;
                        c.Stat = StatType.Speed;
                        c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                    });
                    bp.AddComponent<ContextRankConfig>(c => {
                        c.m_Type = AbilityRankType.StatBonus;
                        c.m_BaseValueType = ContextRankBaseValueType.CharacterLevel;
                        c.m_Progression = ContextRankProgression.MultiplyByModifier;
                        c.m_StepLevel = 5;
                    });
                });

            SpecialPowerSelection.AddToSelection(ExtremeSpeedFeature);
        }
    }
}