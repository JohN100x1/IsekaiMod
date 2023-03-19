using HarmonyLib;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.Enums.Damage;
using Kingmaker.Localization;
using Kingmaker.ResourceLinks;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Abilities.Components.Base;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.Commands.Base;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.UnitLogic.Mechanics.Properties;
using Kingmaker.Visual.Animation.Kingmaker.Actions;
using System.Collections.Generic;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Heritages {

    internal class IsekaiAngelHeritage {

        public static void Add() {
            var AasimarSpellLikeResource = BlueprintTools.GetBlueprint<BlueprintAbilityResource>("a4ea5b9becd98dd47b51c8742aeb70ec");
            var AngelBoltOfJusticeAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("c82168800b665324f8b4807b531fea46");
            var AngelWingsFeature = BlueprintTools.GetBlueprint<BlueprintFeature>("d9bd0fde6deb2e44a93268f2dfb3e169");
            var BlackWingsAbility = BlueprintTools.GetModBlueprint<BlueprintActivatableAbility>(IsekaiContext, "BlackWingsAbility");
            var GhostWingsAbility = BlueprintTools.GetModBlueprint<BlueprintActivatableAbility>(IsekaiContext, "GhostWingsAbility");

            // Ability
            var AngelicBoltUnitProperty = Helpers.CreateBlueprint<BlueprintUnitProperty>(IsekaiContext, "AngelicBoltUnitProperty", bp => {
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
            var AngelicBoltAbility = Helpers.CreateBlueprint<BlueprintAbility>(IsekaiContext, "AngelicBoltAbility", bp => {
                bp.SetName(IsekaiContext, "Angelic Bolt");
                bp.SetDescription(IsekaiContext, "You release a powerful stroke of energy that deals {g|Encyclopedia:Dice}2d6{/g} points of holy {g|Encyclopedia:Damage}damage{/g} per "
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
                });
                bp.AddComponent<SpellComponent>(c => {
                    c.School = SpellSchool.Conjuration;
                });
                bp.AddComponent<AbilityDeliverDelay>(c => {
                    c.DelaySeconds = 1.5f;
                });
                bp.AddComponent<AbilitySpawnFx>(c => {
                    c.PrefabLink = new PrefabLink() { AssetId = "5c1ded6985c9c15448f1dc1ad90dbd80" };
                    c.Time = AbilitySpawnFxTime.OnPrecastFinished;
                    c.Anchor = AbilitySpawnFxAnchor.ClickedTarget;
                });
                bp.AddComponent<ContextSetAbilityParams>(c => {
                    c.DC = Values.CreateContextCasterCustomPropertyValue(AngelicBoltUnitProperty);
                });
                bp.AddComponent<AbilityResourceLogic>(c => {
                    c.m_RequiredResource = AasimarSpellLikeResource.ToReference<BlueprintAbilityResourceReference>();
                    c.m_IsSpendResource = true;
                    c.Amount = 1;
                    c.ResourceCostIncreasingFacts = new List<BlueprintUnitFactReference>();
                    c.ResourceCostDecreasingFacts = new List<BlueprintUnitFactReference>();
                });
                bp.Type = AbilityType.SpellLike;
                bp.Range = AbilityRange.Long;
                bp.CanTargetEnemies = true;
                bp.CanTargetFriends = true;
                bp.EffectOnEnemy = AbilityEffectOnUnit.Harmful;
                bp.EffectOnAlly = AbilityEffectOnUnit.Harmful;
                bp.Animation = UnitAnimationActionCastSpell.CastAnimationStyle.Directional;
                bp.ActionType = UnitCommand.CommandType.Standard;
                bp.AvailableMetamagic = AngelBoltOfJusticeAbility.AvailableMetamagic;
                bp.LocalizedDuration = new LocalizedString();
                bp.LocalizedSavingThrow = new LocalizedString();
            });

            // Angel Heritage
            var Icon_Angel = AssetLoader.LoadInternal(IsekaiContext, "Heritages", "ICON_ANGEL.png");
            var IsekaiAngelHeritage = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiAngelHeritage", bp => {
                bp.SetName(IsekaiContext, "Isekai Angel");
                bp.SetDescription(IsekaiContext, "Otherworldly entities who are reincarnated into the world of Golarion as an Angel have both extreme beauty and power. "
                    + "They serve as exemplars of good and light regardless of the myriad forms they may take.\n"
                    + "The Isekai Angel has a +4 racial {g|Encyclopedia:Bonus}bonus{/g} to {g|Encyclopedia:Strength}Strength{/g} and {g|Encyclopedia:Charisma}Charisma{/g}, "
                    + "and a +2 racial bonus on {g|Encyclopedia:Persuasion}Persuasion{/g} and {g|Encyclopedia:Lore_Religion}Lore (religion){/g} checks. "
                    + "They have DR 10/Evil, and have spell resistance equal to 10 + their character level. "
                    + "They have immunity to acid, cold, and petrification as well as fire and electricity resistance 20. "
                    + "They can also use the Angelic Bolt spell once per day.");
                bp.m_Icon = Icon_Angel;

                // Attributes
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Racial;
                    c.Stat = StatType.Strength;
                    c.Value = 4;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Racial;
                    c.Stat = StatType.Charisma;
                    c.Value = 4;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Racial;
                    c.Stat = StatType.SkillLoreReligion;
                    c.Value = 2;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Racial;
                    c.Stat = StatType.SkillPersuasion;
                    c.Value = 2;
                });

                // Add DR/Evil
                bp.AddComponent<AddDamageResistancePhysical>(c => {
                    c.Or = true;
                    c.Value = 10;
                    c.BypassedByAlignment = true;
                    c.Alignment = DamageAlignment.Evil;
                });

                // Add Spell Resistance
                bp.AddComponent<AddSpellResistance>(c => {
                    c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                });
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.StatBonus;
                    c.m_BaseValueType = ContextRankBaseValueType.CharacterLevel;
                    c.m_Progression = ContextRankProgression.BonusValue;
                    c.m_StepLevel = 10;
                });

                // Add Resistance and Immunities
                bp.AddComponent<AddDamageResistanceEnergy>(c => {
                    c.Type = DamageEnergyType.Acid;
                    c.Value = 20;
                });
                bp.AddComponent<AddDamageResistanceEnergy>(c => {
                    c.Type = DamageEnergyType.Cold;
                    c.Value = 20;
                });
                bp.AddComponent<AddDamageResistanceEnergy>(c => {
                    c.Type = DamageEnergyType.Fire;
                    c.Value = 20;
                });
                bp.AddComponent<AddDamageResistanceEnergy>(c => {
                    c.Type = DamageEnergyType.Electricity;
                    c.Value = 20;
                });
                bp.AddComponent<AddEnergyImmunity>(c => {
                    c.Type = DamageEnergyType.Acid;
                });
                bp.AddComponent<AddEnergyImmunity>(c => {
                    c.Type = DamageEnergyType.Cold;
                });
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.Petrified
                    | SpellDescriptor.Acid
                    | SpellDescriptor.Cold;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = SpellDescriptor.Petrified
                    | SpellDescriptor.Acid
                    | SpellDescriptor.Cold;
                });

                // Add Abilities
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] {
                        AngelicBoltAbility.ToReference<BlueprintUnitFactReference>(),
                        AngelWingsFeature.ToReference<BlueprintUnitFactReference>(),
                        BlackWingsAbility.ToReference<BlueprintUnitFactReference>(),
                        GhostWingsAbility.ToReference<BlueprintUnitFactReference>(),
                    };
                });

                bp.Groups = new FeatureGroup[] { FeatureGroup.Racial, FeatureGroup.AasimarHeritage };
                bp.ReapplyOnLevelUp = true;
            });

            StaticReferences.Selections.AasimarHeritageSelection.AddToSelection(IsekaiAngelHeritage);
        }
    }
}