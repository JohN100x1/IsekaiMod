using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.ResourceLinks;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Components;
using UnityEngine;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.CharacterDevelopment
{
    class ExtremeSpeedFeature
    {
        private static readonly Sprite Icon_SupersonicSpeed = Resources.GetBlueprint<BlueprintFeature>("505456aa17dd18a4e8bd8172811a4fdc").m_Icon;
        public static void Add()
        {
            var ExtremeSpeedBuff = Helpers.CreateBlueprint<BlueprintBuff>("ExtremeSpeedBuff", bp => {
                bp.SetName("Extreme Speed");
                bp.SetDescription("You gain a +5 {g|Encyclopedia:Bonus}bonus{/g} to your {g|Encyclopedia:Speed}speed{/g} per character level.");
                bp.m_Icon = Icon_SupersonicSpeed;
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.UntypedStackable;
                    c.Stat = StatType.Speed;
                    c.Value = new ContextValue()
                    {
                        ValueType = ContextValueType.Rank,
                        ValueRank = AbilityRankType.StatBonus
                    };
                });
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.StatBonus;
                    c.m_BaseValueType = ContextRankBaseValueType.CharacterLevel;
                    c.m_Progression = ContextRankProgression.MultiplyByModifier;
                    c.m_StepLevel = 5;
                });
                bp.Stacking = StackingType.Replace;
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.StayOnDeath;
                bp.FxOnStart = new PrefabLink();
                bp.FxOnRemove = new PrefabLink();
            });
            var ExtremeSpeedAbility = Helpers.CreateBlueprint<BlueprintActivatableAbility>("ExtremeSpeedAbility", bp => {
                bp.SetName("Extreme Speed");
                bp.SetDescription("You gain a +5 {g|Encyclopedia:Bonus}bonus{/g} to your {g|Encyclopedia:Speed}speed{/g} per character level.");
                bp.m_Icon = Icon_SupersonicSpeed;
                bp.m_Buff = ExtremeSpeedBuff.ToReference<BlueprintBuffReference>();
                bp.Group = ActivatableAbilityGroup.None;
                bp.WeightInGroup = 1;
                bp.IsOnByDefault = true;
                bp.DeactivateImmediately = true;
                bp.ActivationType = AbilityActivationType.Immediately;
            });
            var ExtremeSpeedFeature = Helpers.CreateBlueprint<BlueprintFeature>("ExtremeSpeedFeature", bp => {
                bp.SetName("Extreme Speed");
                bp.SetDescription("You extensive speed training, gain a +5 {g|Encyclopedia:Bonus}bonus{/g} to your {g|Encyclopedia:Speed}speed{/g} per character level.");
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { ExtremeSpeedAbility.ToReference<BlueprintUnitFactReference>() };
                });
                bp.m_Icon = Icon_SupersonicSpeed;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });

            CharacterDevelopmentSelection.AddToSelection(ExtremeSpeedFeature);
        }
    }
}
