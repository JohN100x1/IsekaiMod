using HarmonyLib;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Designers.Mechanics.Buffs;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
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
using Kingmaker.UnitLogic.Mechanics.Properties;
using Kingmaker.Visual.Animation.Kingmaker.Actions;
using TabletopTweaks.Core.Utilities;
using UnityEngine;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Heritages {

    internal class IsekaiDarkElfHeritage {
        private static readonly BlueprintFeature DestinyBeyondBirthMythicFeat = BlueprintTools.GetBlueprint<BlueprintFeature>("325f078c584318849bfe3da9ea245b9d");
        private static readonly BlueprintBuff Unconsious = BlueprintTools.GetBlueprint<BlueprintBuff>("31a468926d0f3ab439b714f15d794a8b");
        private static readonly Sprite Icon_AcidBomb = BlueprintTools.GetBlueprint<BlueprintAbility>("fd101fbc4aacf5d48b76a65e3aa5db6d").m_Icon;

        public static void Add() {
            // Dark Elf Abilities
            var DrowPoisonResource = Helpers.CreateBlueprint<BlueprintAbilityResource>(IsekaiContext, "DrowPoisonResource", bp => {
                bp.m_MaxAmount = new BlueprintAbilityResource.Amount {
                    BaseValue = 0,
                    IncreasedByLevel = false,
                    LevelIncrease = 0,
                    IncreasedByLevelStartPlusDivStep = false,
                    StartingLevel = 0,
                    StartingIncrease = 0,
                    LevelStep = 0,
                    PerStepIncrease = 0,
                    MinClassLevelIncrease = 0,
                    OtherClassesModifier = 0,
                    IncreasedByStat = true,
                    ResourceBonusStat = StatType.Intelligence,
                };
            });
            var DrowPoisonUnitProperty = Helpers.CreateBlueprint<BlueprintUnitProperty>(IsekaiContext, "DrowPoisonUnitProperty", bp => {
                bp.name = "DrowPoisonUnitProperty";
                bp.AddComponent<SimplePropertyGetter>(c => {
                    c.Property = UnitProperty.Level;
                });
                bp.AddComponent<SimplePropertyGetter>(c => {
                    c.Property = UnitProperty.StatBonusIntelligence;
                });
                bp.BaseValue = 10;
                bp.OperationOnComponents = BlueprintUnitProperty.MathOperation.Sum;
            });
            var DrowPoisonBuff = ThingsNotHandledByTTTCore.CreateBuff("DrowPoisonBuff", bp => {
                bp.SetName(IsekaiContext, "Drow Poison");
                bp.SetDescription(IsekaiContext, "Drow Poison causes their target to become unconsious on a failed fortitude save.");
                bp.m_Icon = Icon_AcidBomb;
                bp.IsClassFeature = true;
                bp.Stacking = StackingType.Replace;
                bp.m_Flags = BlueprintBuff.Flags.StayOnDeath;
                bp.AddComponent<AddInitiatorAttackWithWeaponTrigger>(c => {
                    //c.WaitForAttackResolve = true;
                    c.OnlyHit = true;
                    c.Action = Helpers.CreateActionList(
                        new ContextActionSavingThrow() {
                            Type = SavingThrowType.Fortitude,
                            m_ConditionalDCIncrease = new ContextActionSavingThrow.ConditionalDCIncrease[0],
                            HasCustomDC = true,
                            CustomDC = Values.CreateContextCasterCustomPropertyValue(DrowPoisonUnitProperty),
                            FromBuff = false,
                            Actions = ActionFlow.DoSingle<ContextActionConditionalSaved>(c => {
                                c.Succeed = ActionFlow.DoNothing();
                                c.Failed = ActionFlow.DoSingle<ContextActionApplyBuff>(c => {
                                    c.m_Buff = Unconsious.ToReference<BlueprintBuffReference>();
                                    c.DurationValue = new ContextDurationValue() {
                                        Rate = DurationRate.Minutes,
                                        m_IsExtendable = true,
                                        DiceType = DiceType.Zero,
                                        DiceCountValue = 0,
                                        BonusValue = 1,
                                    };
                                });
                            })
                        },
                        new ContextActionRemoveSelf()
                        );
                });
                bp.AddComponent<ContextSetAbilityParams>(c => {
                    c.DC = Values.CreateContextCasterCustomPropertyValue(DrowPoisonUnitProperty);
                });
            });
            var DrowPoisonAbility = Helpers.CreateBlueprint<BlueprintAbility>(IsekaiContext, "DrowPoisonAbility", bp => {
                bp.SetName(IsekaiContext, "Drow Poison");
                bp.SetDescription(IsekaiContext, "As a swift action, you can coat your weapon with a special drow poison. Enemies hit by the poisoned weapon will need to make a Fortitude save "
                    + "or become unconscious for 1 minute. This fortitude save is equal to 10 + your character level + your Intelligence modifier.");
                bp.m_Icon = Icon_AcidBomb;
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.SavingThrowType = SavingThrowType.Fortitude;
                    c.Actions = ActionFlow.DoSingle<ContextActionApplyBuff>(c => {
                        c.m_Buff = DrowPoisonBuff.ToReference<BlueprintBuffReference>();
                        c.Permanent = true;
                        c.DurationValue = Values.Duration.Zero;
                    });
                });
                bp.AddComponent<AbilitySpawnFx>(c => {
                    c.PrefabLink = new PrefabLink() { AssetId = "8de64fbe047abc243a9b4715f643739f" };
                    c.Time = AbilitySpawnFxTime.OnApplyEffect;
                    c.Anchor = AbilitySpawnFxAnchor.Caster;
                });
                bp.AddComponent<ContextSetAbilityParams>(c => {
                    c.DC = Values.CreateContextCasterCustomPropertyValue(DrowPoisonUnitProperty);
                });
                bp.AddComponent<AbilityResourceLogic>(c => {
                    c.m_RequiredResource = DrowPoisonResource.ToReference<BlueprintAbilityResourceReference>();
                    c.m_IsSpendResource = true;
                });
                bp.Type = AbilityType.Special;
                bp.Range = AbilityRange.Personal;
                bp.CanTargetSelf = true;
                bp.Animation = UnitAnimationActionCastSpell.CastAnimationStyle.EnchantWeapon;
                bp.ActionType = UnitCommand.CommandType.Swift;
                bp.AvailableMetamagic = Metamagic.Heighten;
                bp.LocalizedDuration = Helpers.CreateString(IsekaiContext, $"{bp.name}.Duration", "1 minute");
                bp.LocalizedSavingThrow = Helpers.CreateString(IsekaiContext, $"{bp.name}.SavingThrow", "Fortitude negates");
            });

            // Dark Elf Heritage
            var Icon_Dark_Elf = AssetLoader.LoadInternal(IsekaiContext, "Heritages", "ICON_DARK_ELF.png");
            var IsekaiDarkElfHeritage = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiDarkElfHeritage", bp => {
                bp.SetName(IsekaiContext, "Isekai Dark Elf");
                bp.SetDescription(IsekaiContext, "Otherworldly entities who are reincarnated into the world of Golarion as a Dark Elf have both extreme beauty and power. "
                    + "They are a cruel and cunning dark reflection of the elven race.\n"
                    + "The Isekai Dark Elf has a +4 racial {g|Encyclopedia:Bonus}bonus{/g} to {g|Encyclopedia:Intelligence}Intelligence{/g}, a +2 racial bonus to "
                    + "{g|Encyclopedia:Dexterity}Dexterity{/g} and {g|Encyclopedia:Wisdom}Wisdom{/g}, and a -2 penalty to Constitution. "
                    + "They have spell resistance equal to 10 + their character level. "
                    + "They can also use the Drow Poison ability as a swift action a number of times per day equal to their Intelligence modifier.");
                bp.m_Icon = Icon_Dark_Elf;

                // Attributes
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Racial;
                    c.Stat = StatType.Dexterity;
                    c.Value = 2;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Racial;
                    c.Stat = StatType.Intelligence;
                    c.Value = 4;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Racial;
                    c.Stat = StatType.Wisdom;
                    c.Value = 2;
                });
                bp.AddComponent<AddStatBonusIfHasFact>(c => {
                    c.Descriptor = ModifierDescriptor.Racial;
                    c.Stat = StatType.Constitution;
                    c.Value = -2;
                    c.InvertCondition = true;
                    c.m_CheckedFacts = new BlueprintUnitFactReference[] { DestinyBeyondBirthMythicFeat.ToReference<BlueprintUnitFactReference>() };
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

                // Add Resources
                bp.AddComponent<AddAbilityResources>(c => {
                    c.m_Resource = DrowPoisonResource.ToReference<BlueprintAbilityResourceReference>();
                    c.RestoreAmount = true;
                });

                // Add Abilities
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] {
                        DrowPoisonAbility.ToReference<BlueprintUnitFactReference>()
                    };
                });

                bp.Groups = new FeatureGroup[0];
                bp.ReapplyOnLevelUp = true;
            });

            // Add to Elven Heritage Selection
            var ElvenHeritageSelection = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("5482f879dcfd40f9a3168fdb48bc938c");
            ElvenHeritageSelection.m_AllFeatures = ElvenHeritageSelection.m_AllFeatures.AddToArray(IsekaiDarkElfHeritage.ToReference<BlueprintFeatureReference>());
        }
    }
}