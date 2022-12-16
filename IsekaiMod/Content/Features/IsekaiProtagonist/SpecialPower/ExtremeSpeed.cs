using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Components;
using UnityEngine;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.SpecialPower
{
    class ExtremeSpeed
    {
        private static readonly Sprite Icon_SupersonicSpeed = Resources.GetBlueprint<BlueprintFeature>("505456aa17dd18a4e8bd8172811a4fdc").m_Icon;
        public static void Add()
        {
            var ExtremeSpeedBuff = Helpers.CreateBuff("ExtremeSpeedBuff", bp => {
                bp.SetName("Extreme Speed");
                bp.SetDescription("You gain a {g|Encyclopedia:Bonus}bonus{/g} to your {g|Encyclopedia:Speed}speed{/g} equal to 5 times your character level.");
                bp.m_Icon = Icon_SupersonicSpeed;
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.UntypedStackable;
                    c.Stat = StatType.Speed;
                    c.Value = Values.ContextRankValue(AbilityRankType.StatBonus);
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
            });
            var ExtremeSpeedAbility = Helpers.CreateActivatableAbility("ExtremeSpeedAbility", bp => {
                bp.SetName("Extreme Speed");
                bp.SetDescription("You gain a {g|Encyclopedia:Bonus}bonus{/g} to your {g|Encyclopedia:Speed}speed{/g} equal to 5 times your character level.");
                bp.m_Icon = Icon_SupersonicSpeed;
                bp.m_Buff = ExtremeSpeedBuff.ToReference<BlueprintBuffReference>();
            });
            var ExtremeSpeedFeature = Helpers.CreateFeature("ExtremeSpeedFeature", bp => {
                bp.SetName("Extreme Speed");
                bp.SetDescription("After extensive speed training, you gain a {g|Encyclopedia:Bonus}bonus{/g} to your {g|Encyclopedia:Speed}speed{/g} equal to 5 times your character level.");
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { ExtremeSpeedAbility.ToReference<BlueprintUnitFactReference>() };
                });
                bp.m_Icon = Icon_SupersonicSpeed;
            });

            SpecialPowerSelection.AddToSelection(ExtremeSpeedFeature);
        }
    }
}
