using IsekaiMod.Utilities;
using IsekaiMod.Extensions;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Commands.Base;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.ElementsSystem;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.Visual.Animation.Kingmaker.Actions;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Mechanics.Properties;
using Kingmaker.UnitLogic.Abilities.Components.Base;
using Kingmaker.ResourceLinks;
using Kingmaker.UnitLogic.Mechanics.Components;
using System.Collections.Generic;

namespace IsekaiMod.Content.Features.IsekaiSuccubus
{
    class SuccubusCharmAbility
    {
        public static void Add()
        {
            // Buff
            var DominatePersonBuff = Resources.GetBlueprint<BlueprintBuff>("c0f4e1c24c9cd334ca988ed1bd9d201f");
            var TieflingSpellLikeResource = Resources.GetBlueprint<BlueprintAbilityResource>("803d7e39e05fa2a47a7e2424d0e4b623");

            // Ability
            var Icon_Charm = AssetLoader.LoadInternal("Abilities", "ICON_CHARM.png");
            var SuccubusCharmUnitProperty = Helpers.CreateBlueprint<BlueprintUnitProperty>("SuccubusCharmUnitProperty", bp => {
                bp.name = "SuccubusCharmUnitProperty";
                bp.AddComponent<SimplePropertyGetter>(c => {
                    c.Property = UnitProperty.Level;
                });
                bp.AddComponent<SimplePropertyGetter>(c => {
                    c.Property = UnitProperty.StatBonusCharisma;
                });
                bp.BaseValue = 10;
                bp.OperationOnComponents = BlueprintUnitProperty.MathOperation.Sum;
            });
            var SuccubusCharmAbility = Helpers.CreateBlueprint<BlueprintAbility>("SuccubusCharmAbility", bp => {
                bp.SetName("Succubus Charm");
                bp.SetDescription("You can make any creature fight on your side as if it was your ally. "
                    + "It will {g|Encyclopedia:Attack}attack{/g} your opponents to the best of its ability. "
                    + "However this creature will try to throw off the domination effect, making a {g|Encyclopedia:Saving_Throw}Will save{/g} each {g|Encyclopedia:Combat_Round}round{/g}.");
                bp.m_Icon = Icon_Charm;
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.SavingThrowType = SavingThrowType.Will;
                    c.Actions = Helpers.CreateActionList(
                    new ContextActionConditionalSaved()
                    {
                        Succeed = new ActionList(),
                        Failed = Helpers.CreateActionList(
                        new ContextActionApplyBuff()
                        {
                            m_Buff = DominatePersonBuff.ToReference<BlueprintBuffReference>(),
                            Permanent = false,
                            DurationValue = new ContextDurationValue()
                            {
                                Rate = DurationRate.Minutes,
                                m_IsExtendable = true,
                                DiceCountValue = 0,
                                BonusValue = new ContextValue()
                                {
                                    Value = 0,
                                    ValueType = ContextValueType.Rank
                                }
                            },
                            IsFromSpell = false,
                        }),
                    });
                });
                bp.AddComponent<SpellComponent>(c => {
                    c.m_Flags = 0;
                    c.School = SpellSchool.Enchantment;
                });
                bp.AddComponent<SpellDescriptorComponent>(c => {
                    c.Descriptor = SpellDescriptor.MindAffecting | SpellDescriptor.Compulsion;
                });
                bp.AddComponent<AbilitySpawnFx>(c => {
                    c.PrefabLink = new PrefabLink() { AssetId = "c14a2f46018cb0e41bfeed61463510ff" };
                    c.Time = AbilitySpawnFxTime.OnApplyEffect;
                    c.Anchor = AbilitySpawnFxAnchor.SelectedTarget;
                });
                bp.AddComponent<ContextSetAbilityParams>(c => {
                    c.DC = new ContextValue()
                    {
                        ValueType = ContextValueType.CasterCustomProperty,
                        m_CustomProperty = SuccubusCharmUnitProperty.ToReference<BlueprintUnitPropertyReference>()
                    };
                });
                bp.AddComponent<AbilityResourceLogic>(c => {
                    c.m_RequiredResource = TieflingSpellLikeResource.ToReference<BlueprintAbilityResourceReference>();
                    c.m_IsSpendResource = true;
                    c.CostIsCustom = false;
                    c.Amount = 1;
                    c.ResourceCostIncreasingFacts = new List<BlueprintUnitFactReference>();
                    c.ResourceCostDecreasingFacts = new List<BlueprintUnitFactReference>();
                });
                bp.Type = AbilityType.SpellLike;
                bp.Range = AbilityRange.Medium;
                bp.m_AllowNonContextActions = false;
                bp.CanTargetPoint = false;
                bp.CanTargetEnemies = true;
                bp.CanTargetFriends = true;
                bp.CanTargetSelf = false;
                bp.SpellResistance = false;
                bp.EffectOnEnemy = AbilityEffectOnUnit.None;
                bp.EffectOnAlly = AbilityEffectOnUnit.None;
                bp.Animation = UnitAnimationActionCastSpell.CastAnimationStyle.Directional;
                bp.ActionType = UnitCommand.CommandType.Standard;
                bp.AvailableMetamagic = Metamagic.Heighten | Metamagic.Reach | Metamagic.CompletelyNormal;
                bp.m_TargetMapObjects = false;
                bp.LocalizedDuration = Helpers.CreateString($"{bp.name}.Duration", "1 minute/level");
                bp.LocalizedSavingThrow = Helpers.CreateString($"{bp.name}.SavingThrow", "Will negates");
            });
        }
    }
}
