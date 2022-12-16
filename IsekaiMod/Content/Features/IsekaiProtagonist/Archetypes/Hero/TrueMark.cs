using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Buffs;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.Localization;
using Kingmaker.ResourceLinks;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Abilities.Components.Base;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Commands.Base;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.Visual.Animation.Kingmaker.Actions;
using System.Collections.Generic;
using UnityEngine;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Hero
{
    class TrueMark
    {
        private static readonly Sprite Icon_MarkOfJustice = Resources.GetBlueprint<BlueprintFeature>("9f13fdd044ccb8a439f27417481cb00e").m_Icon;
        public static void Add()
        {
            var TrueSmiteResource = Resources.GetModBlueprint<BlueprintAbilityResource>("TrueSmiteResource");

            var TrueMarkBuff = Helpers.CreateBuff("TrueMarkBuff", bp => {
                bp.SetName("True Mark");
                bp.SetDescription("The creature is easier to hit and takes more damage from the hero's allies.");
                bp.m_Icon = Icon_MarkOfJustice;
                bp.AddComponent<AttackBonusAgainstTarget>(c => {
                    c.CheckCasterFriend = true;
                    c.Value = Values.ContextSharedValue(AbilitySharedValue.StatBonus);
                });
                bp.AddComponent<DamageBonusAgainstTarget>(c => {
                    c.CheckCasterFriend = true;
                    c.ApplyToSpellDamage = true;
                    c.Value = Values.ContextSharedValue(AbilitySharedValue.DamageBonus);
                });
                bp.AddComponent<ACBonusAgainstTarget>(c => {
                    c.CheckCasterFriend = true;
                    c.Descriptor = ModifierDescriptor.Deflection;
                    c.Value = Values.ContextSharedValue(AbilitySharedValue.StatBonus);
                });
                bp.AddComponent<IgnoreTargetDR>(c => {
                    c.CheckCasterFriend = true;
                });
                bp.AddComponent<TargetCritAutoconfirm>();
                bp.AddComponent<UniqueBuff>();
                bp.Stacking = StackingType.Replace;
                bp.FxOnStart = new PrefabLink() { AssetId = "5b4cdc22715305949a1bd80fab08302b" };
            });
            var TrueMarkAbility = Helpers.CreateBlueprint<BlueprintAbility>("TrueMarkAbility", bp => {
                bp.SetName("True Mark");
                bp.SetDescription("The hero expends two uses of her true smite ability to grant the ability to true smite to all allies for 1 minute, "
                    + "using her {g|Encyclopedia:Bonus}bonuses{/g}. As a {g|Encyclopedia:Swift_Action}swift action{/g}, the paladin chooses one target within sight to smite. "
                    + "The hero's allies add her {g|Encyclopedia:Charisma}Charisma{/g} bonus (if any) to their {g|Encyclopedia:Attack}attack rolls{/g} and add her character level to "
                    + "all {g|Encyclopedia:Damage}damage rolls{/g} made against the target of her smite. True smite attacks automatically bypass any {g|Encyclopedia:Damage_Reduction}DR{/g} "
                    + "the creature might possess and automatically confirms all critical threats against them. In addition, while true smite is in effect, the hero's allies gain a "
                    + "deflection bonus equal to her Charisma bonus (if any) to their {g|Encyclopedia:Armor_Class}AC{/g} against attacks made by the target of this smite.");
                bp.m_Icon = Icon_MarkOfJustice;
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.Actions = ActionFlow.DoSingle<ContextActionApplyBuff>(c => {
                        c.Permanent = true;
                        c.m_Buff = TrueMarkBuff.ToReference<BlueprintBuffReference>();
                        c.DurationValue = Values.Duration.Zero;
                        c.IsNotDispelable = true;
                    });
                });
                bp.AddComponent<ContextCalculateSharedValue>(c => {
                    c.ValueType = AbilitySharedValue.StatBonus;
                    c.Value = new ContextDiceValue()
                    {
                        DiceType = DiceType.Zero,
                        DiceCountValue = 0,
                        BonusValue = Values.ContextRankValue(AbilityRankType.StatBonus)
                    };
                    c.Modifier = 1;
                });
                bp.AddComponent<ContextCalculateSharedValue>(c => {
                    c.ValueType = AbilitySharedValue.DamageBonus;
                    c.Value = new ContextDiceValue()
                    {
                        DiceType = DiceType.Zero,
                        DiceCountValue = 0,
                        BonusValue = Values.ContextRankValue(AbilityRankType.DamageBonus)
                };
                    c.Modifier = 1;
                });
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.DamageBonus;
                    c.m_BaseValueType = ContextRankBaseValueType.CharacterLevel;
                });
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.StatBonus;
                    c.m_BaseValueType = ContextRankBaseValueType.StatBonus;
                    c.m_Stat = StatType.Charisma;
                });
                bp.AddComponent<AbilitySpawnFx>(c => {
                    c.PrefabLink = new PrefabLink() { AssetId = "6e799a804a9ce4044a70eba38890cf5a" };
                    c.Time = AbilitySpawnFxTime.OnApplyEffect;
                    c.Anchor = AbilitySpawnFxAnchor.SelectedTarget;
                });
                bp.AddComponent<AbilityResourceLogic>(c => {
                    c.m_RequiredResource = TrueSmiteResource.ToReference<BlueprintAbilityResourceReference>();
                    c.m_IsSpendResource = true;
                    c.Amount = 2;
                    c.ResourceCostIncreasingFacts = new List<BlueprintUnitFactReference>();
                    c.ResourceCostDecreasingFacts = new List<BlueprintUnitFactReference>();
                });
                bp.Type = AbilityType.Supernatural;
                bp.Range = AbilityRange.Medium;
                bp.CanTargetEnemies = true;
                bp.CanTargetSelf = true;
                bp.ShouldTurnToTarget = true;
                bp.EffectOnEnemy = AbilityEffectOnUnit.Harmful;
                bp.EffectOnAlly = AbilityEffectOnUnit.None;
                bp.Animation = UnitAnimationActionCastSpell.CastAnimationStyle.Point;
                bp.ActionType = UnitCommand.CommandType.Swift;
                bp.AvailableMetamagic = Metamagic.Extend | Metamagic.Heighten | Metamagic.Reach;
                bp.LocalizedDuration = Helpers.CreateString($"{bp.name}.Duration", "Until the target of the Mark is dead");
                bp.LocalizedSavingThrow = new LocalizedString();
            });
            var TrueMarkFeature = Helpers.CreateFeature("TrueMarkFeature", bp => {
                bp.SetName("True Mark");
                bp.SetDescription("At 11th level, the hero can expend two uses of her true smite ability to grant the ability to true smite to all allies for 1 minute, "
                    + "using her {g|Encyclopedia:Bonus}bonuses{/g}. As a {g|Encyclopedia:Swift_Action}swift action{/g}, the paladin chooses one target within sight to smite. "
                    + "The hero's allies add her {g|Encyclopedia:Charisma}Charisma{/g} bonus (if any) to their {g|Encyclopedia:Attack}attack rolls{/g} and add her character level to "
                    + "all {g|Encyclopedia:Damage}damage rolls{/g} made against the target of her smite. True smite attacks automatically bypass any {g|Encyclopedia:Damage_Reduction}DR{/g} "
                    + "the creature might possess and automatically confirms all critical threats against them. In addition, while true smite is in effect, the hero's allies gain a "
                    + "deflection bonus equal to her Charisma bonus (if any) to their {g|Encyclopedia:Armor_Class}AC{/g} against attacks made by the target of this smite.");
                bp.m_Icon = Icon_MarkOfJustice;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { TrueMarkAbility.ToReference<BlueprintUnitFactReference>() };
                });
            });
        }
    }
}
