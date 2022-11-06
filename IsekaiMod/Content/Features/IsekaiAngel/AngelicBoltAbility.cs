using IsekaiMod.Utilities;
using IsekaiMod.Extensions;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Commands.Base;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.Visual.Animation.Kingmaker.Actions;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Mechanics.Properties;
using Kingmaker.UnitLogic.Abilities.Components.Base;
using Kingmaker.ResourceLinks;
using Kingmaker.UnitLogic.Mechanics.Components;
using System.Collections.Generic;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.FactLogic;

namespace IsekaiMod.Content.Features.IsekaiAngel
{
    class AngelicBoltAbility
    {
        public static void Add()
        {
            var AasimarSpellLikeResource = Resources.GetBlueprint<BlueprintAbilityResource>("a4ea5b9becd98dd47b51c8742aeb70ec");
            var AngelBoltOfJusticeAbility = Resources.GetBlueprint<BlueprintAbility>("c82168800b665324f8b4807b531fea46");

            // Ability
            var AngelicBoltUnitProperty = Helpers.CreateBlueprint<BlueprintUnitProperty>("AngelicBoltUnitProperty", bp => {
                bp.name = "AngelicBoltUnitProperty";
                bp.AddComponent<SimplePropertyGetter>(c => {
                    c.Property = UnitProperty.Level;
                });
                bp.AddComponent<SimplePropertyGetter>(c => {
                    c.Property = UnitProperty.StatBonusCharisma;
                });
                bp.BaseValue = 10;
                bp.OperationOnComponents = BlueprintUnitProperty.MathOperation.Sum;
            });
            var AngelicBoltAbility = Helpers.CreateBlueprint<BlueprintAbility>("AngelicBoltAbility", bp => {
                bp.SetName("Angelic Bolt");
                bp.SetDescription("You release a powerful stroke of energy that deals {g|Encyclopedia:Dice}2d6{/g} points of holy {g|Encyclopedia:Damage}damage{/g} per "
                    + "character level. The target needs to make a successful Reflex saving throw, or become prone.\n"
                    + "If the target is evil, the {g|Encyclopedia:Spell}spell{/g} instead deals 2d8 points of holy {g|Encyclopedia:Energy_Damage}damage{/g} per character level. "
                    + "The target needs to make a successful Reflex saving throw, or become prone and suffer a -2 {g|Encyclopedia:Penalty}penalty{/g} to {g|Encyclopedia:Armor_Class}AC{/g}, "
                    + "{g|Encyclopedia:Attack}attack rolls{/g} and saving throws.\nIf the target is an evil outsider or an undead creature, the spell instead deals 2d10 points of holy damage "
                    + "per character level. The target needs to make a successful Reflex saving throw, or become prone and suffer a -4 penalty to AC, attack rolls and saving throws.\n"
                    + "If the target is a demon lord, an evil dragon or a lord of undead (a powerful undead creature like liches, undead dragons, nightshades and similar), the spell "
                    + "instead deals 2d12 points of holy damage per character level. The target suffers a -4 penalty to AC, attack rolls and saving throws. It also needs to make a successful "
                    + "Reflex saving throw, or become prone.");
                bp.m_Icon = AngelBoltOfJusticeAbility.m_Icon;
                bp.AddComponent(AngelBoltOfJusticeAbility.GetComponent<AbilityEffectRunAction>());
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.Default;
                    c.m_BaseValueType = ContextRankBaseValueType.CharacterLevel;
                    c.m_Progression = ContextRankProgression.DoublePlusBonusValue;
                    c.m_StepLevel = 0;
                });
                bp.AddComponent<SpellComponent>(c => {
                    c.m_Flags = 0;
                    c.School = SpellSchool.Conjuration;
                });
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.None;
                    c.CheckFact = false;
                });
                bp.AddComponent<AbilityDeliverDelay>(c => {
                    c.m_Flags = 0;
                    c.DelaySeconds = 1.5f;
                });
                bp.AddComponent<AbilitySpawnFx>(c => {
                    c.PrefabLink = new PrefabLink() { AssetId = "5c1ded6985c9c15448f1dc1ad90dbd80" };
                    c.Time = AbilitySpawnFxTime.OnPrecastFinished;
                    c.Anchor = AbilitySpawnFxAnchor.ClickedTarget;
                });
                bp.AddComponent<ContextSetAbilityParams>(c => {
                    c.DC = new ContextValue()
                    {
                        ValueType = ContextValueType.CasterCustomProperty,
                        m_CustomProperty = AngelicBoltUnitProperty.ToReference<BlueprintUnitPropertyReference>()
                    };
                });
                bp.AddComponent<AbilityResourceLogic>(c => {
                    c.m_RequiredResource = AasimarSpellLikeResource.ToReference<BlueprintAbilityResourceReference>();
                    c.m_IsSpendResource = true;
                    c.CostIsCustom = false;
                    c.Amount = 1;
                    c.ResourceCostIncreasingFacts = new List<BlueprintUnitFactReference>();
                    c.ResourceCostDecreasingFacts = new List<BlueprintUnitFactReference>();
                });
                bp.Type = AbilityType.SpellLike;
                bp.Range = AbilityRange.Long;
                bp.m_AllowNonContextActions = false;
                bp.CanTargetPoint = false;
                bp.CanTargetEnemies = true;
                bp.CanTargetFriends = true;
                bp.CanTargetSelf = false;
                bp.SpellResistance = false;
                bp.EffectOnEnemy = AbilityEffectOnUnit.Harmful;
                bp.EffectOnAlly = AbilityEffectOnUnit.Harmful;
                bp.Animation = UnitAnimationActionCastSpell.CastAnimationStyle.Directional;
                bp.ActionType = UnitCommand.CommandType.Standard;
                bp.AvailableMetamagic = Metamagic.Maximize | Metamagic.Empower | Metamagic.CompletelyNormal;
                bp.m_TargetMapObjects = false;
                bp.LocalizedDuration = Helpers.CreateString($"{bp.name}.Duration", "");
                bp.LocalizedSavingThrow = Helpers.CreateString($"{bp.name}.SavingThrow", "");
            });
        }
    }
}
