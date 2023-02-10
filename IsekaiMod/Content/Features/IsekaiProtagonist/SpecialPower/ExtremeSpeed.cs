using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.ResourceLinks;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Buffs.Components;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.Utility;
using TabletopTweaks.Core.Utilities;
using UnityEngine;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.SpecialPower {

    internal class ExtremeSpeed {
        private static readonly Sprite Icon_SupersonicSpeed = BlueprintTools.GetBlueprint<BlueprintFeature>("505456aa17dd18a4e8bd8172811a4fdc").m_Icon;

        public static void Add() {
            var ExtremeSpeedBuff = ThingsNotHandledByTTTCore.CreateBuff("ExtremeSpeedBuff", bp => {
                bp.SetName(IsekaiContext, "Extreme Speed");
                bp.SetDescription(IsekaiContext, "This creature gains a {g|Encyclopedia:Bonus}bonus{/g} to their {g|Encyclopedia:Speed}speed{/g}.");
                bp.IsClassFeature = true;
                bp.m_Icon = Icon_SupersonicSpeed;
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
            var ExtremeSpeedArea = Helpers.CreateBlueprint<BlueprintAbilityAreaEffect>(IsekaiContext, "ExtremeSpeedArea", bp => {
                bp.m_TargetType = BlueprintAbilityAreaEffect.TargetType.Ally;
                bp.Shape = AreaEffectShape.Cylinder;
                bp.Size = new Feet(40);
                bp.Fx = new PrefabLink();
                bp.AddComponent(AuraUtils.CreateUnconditionalAuraEffect(ExtremeSpeedBuff.ToReference<BlueprintBuffReference>()));
            });
            var ExtremeSpeedAreaBuff = ThingsNotHandledByTTTCore.CreateBuff("ExtremeSpeedAreaBuff", bp => {
                bp.SetName(IsekaiContext, "Extreme Speed");
                bp.SetDescription(IsekaiContext, "Allies within 40 feet of you gain a {g|Encyclopedia:Bonus}bonus{/g} to your {g|Encyclopedia:Speed}speed{/g} equal to 5 times your character level.");
                bp.m_Icon = Icon_SupersonicSpeed;
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.HiddenInUi;
                bp.AddComponent<AddAreaEffect>(c => {
                    c.m_AreaEffect = ExtremeSpeedArea.ToReference<BlueprintAbilityAreaEffectReference>();
                });
            });
            var ExtremeSpeedAbility = ThingsNotHandledByTTTCore.CreateActivatableAbility("ExtremeSpeedAbility", bp => {
                bp.SetName(IsekaiContext, "Extreme Speed");
                bp.SetDescription(IsekaiContext, "Allies within 40 feet of you gain a {g|Encyclopedia:Bonus}bonus{/g} to your {g|Encyclopedia:Speed}speed{/g} equal to 5 times your character level.");
                bp.m_Icon = Icon_SupersonicSpeed;
                bp.m_Buff = ExtremeSpeedAreaBuff.ToReference<BlueprintBuffReference>();
                bp.DoNotTurnOffOnRest = true;
            });
            var ExtremeSpeedFeature = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "ExtremeSpeedFeature", bp => {
                bp.SetName(IsekaiContext, "Extreme Speed");
                bp.SetDescription(IsekaiContext, "Allies within 40 feet of you gain a {g|Encyclopedia:Bonus}bonus{/g} to your {g|Encyclopedia:Speed}speed{/g} equal to 5 times your character level.");
                bp.m_Icon = Icon_SupersonicSpeed;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { ExtremeSpeedAbility.ToReference<BlueprintUnitFactReference>() };
                });
            });

            SpecialPowerSelection.AddToSelection(ExtremeSpeedFeature);
        }
    }
}