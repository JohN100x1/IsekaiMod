using IsekaiMod.Components;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Designers.Mechanics.Buffs;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.Localization;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics.Components;
using System;
using System.Linq;
using TabletopTweaks.Core.Utilities;
using UnityEngine;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.ExceptionalFeats {

    internal class ExceptionalSummoningSelection {

        public static void Add() {
            var Icon_ExceptionalSummoning = AssetLoader.LoadInternal(IsekaiContext, "Features", "ICON_EXCEPTIONAL_SUMMONING.png");
            var Icon_ForbiddenSummoning = AssetLoader.LoadInternal(IsekaiContext, "Features", "ICON_FORBIDDEN_SUMMONING.png");
            var Icon_FerociousSummoning = AssetLoader.LoadInternal(IsekaiContext, "Features", "ICON_FEROCIOUS_SUMMONING.png");

            var MightySummoningFeature = CreateSummonBuffToggleFeature(
                name: "MightySummoning",
                description: "Your summoned creatures get a +5 bonus to maximum Hit Points per character level and a +1 bonus to Attack, damage, and AC per character level.",
                descriptionBuff: "This creature gets a +5 bonus to maximum Hit Points per character level and a +1 bonus to Attack, damage, and AC per character level.",
                icon: Icon_ExceptionalSummoning,
                summonBuffEffect: bp => {
                    bp.AddComponent<AddContextStatBonus>(c => {
                        c.Stat = StatType.HitPoints;
                        c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                        c.Multiplier = 5;
                    });
                    bp.AddComponent<AddContextStatBonus>(c => {
                        c.Stat = StatType.AdditionalAttackBonus;
                        c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                    });
                    bp.AddComponent<AddContextStatBonus>(c => {
                        c.Stat = StatType.AdditionalDamage;
                        c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                    });
                    bp.AddComponent<AddContextStatBonus>(c => {
                        c.Stat = StatType.AC;
                        c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                    });
                    bp.AddComponent<ContextRankConfig>(c => {
                        c.m_Type = AbilityRankType.StatBonus;
                        c.m_BaseValueType = ContextRankBaseValueType.CharacterLevel;
                        c.m_Progression = ContextRankProgression.AsIs;
                    });
                });

            var MagicalSummoningFeature = CreateSummonBuffToggleFeature(
                name: "MagicalSummoning",
                description: "Your summoned creatures get a +5 bonus to maximum Hit Points per character level and a +1 bonus to spell penetration, spell DC, spell damage, and saving throws per character level.",
                descriptionBuff: "This creature gets a +5 bonus to maximum Hit Points per character level and a +1 bonus to spell penetration, spell DC, spell damage, and saving throws per character level.",
                icon: Icon_ExceptionalSummoning,
                summonBuffEffect: bp => {
                    bp.AddComponent<AddContextStatBonus>(c => {
                        c.Stat = StatType.HitPoints;
                        c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                        c.Multiplier = 5;
                    });
                    bp.AddComponent<SpellPenetrationBonus>(c => {
                        c.Descriptor = ModifierDescriptor.UntypedStackable;
                        c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                    });
                    bp.AddComponent<IncreaseAllSpellsDC>(c => {
                        c.SpellsOnly = true;
                        c.Descriptor = ModifierDescriptor.UntypedStackable;
                        c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                    });
                    bp.AddComponent<IncreaseSpellDamage>(c => {
                        c.DamageBonus = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                    });
                    bp.AddComponent<AddContextStatBonus>(c => {
                        c.Stat = StatType.SaveFortitude;
                        c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                    });
                    bp.AddComponent<AddContextStatBonus>(c => {
                        c.Stat = StatType.SaveReflex;
                        c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                    });
                    bp.AddComponent<AddContextStatBonus>(c => {
                        c.Stat = StatType.SaveWill;
                        c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                    });
                    bp.AddComponent<ContextRankConfig>(c => {
                        c.m_Type = AbilityRankType.StatBonus;
                        c.m_BaseValueType = ContextRankBaseValueType.CharacterLevel;
                        c.m_Progression = ContextRankProgression.AsIs;
                    });
                });

            var ForbiddenSummoningFeature = CreateSummonBuffToggleFeature(
                name: "ForbiddenSummoning",
                description: "Your summoned creatures gain a +10 bonus to hit points per character level and a +1 bonus to all attributes per character level.",
                descriptionBuff: "This creature gains a +10 bonus to maximum Hit Points per character level and a +1 bonus to all attributes per character level.",
                icon: Icon_ForbiddenSummoning,
                summonBuffEffect: bp => {
                    bp.AddComponent<AddContextStatBonus>(c => {
                        c.Stat = StatType.HitPoints;
                        c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                        c.Multiplier = 5;
                    });
                    bp.AddComponent<AddContextStatBonus>(c => {
                        c.Stat = StatType.Strength;
                        c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                    });
                    bp.AddComponent<AddContextStatBonus>(c => {
                        c.Stat = StatType.Dexterity;
                        c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                    });
                    bp.AddComponent<AddContextStatBonus>(c => {
                        c.Stat = StatType.Constitution;
                        c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                    });
                    bp.AddComponent<AddContextStatBonus>(c => {
                        c.Stat = StatType.Intelligence;
                        c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                    });
                    bp.AddComponent<AddContextStatBonus>(c => {
                        c.Stat = StatType.Wisdom;
                        c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                    });
                    bp.AddComponent<AddContextStatBonus>(c => {
                        c.Stat = StatType.Charisma;
                        c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                    });
                    bp.AddComponent<ContextRankConfig>(c => {
                        c.m_Type = AbilityRankType.StatBonus;
                        c.m_BaseValueType = ContextRankBaseValueType.CharacterLevel;
                        c.m_Progression = ContextRankProgression.AsIs;
                    });
                });
            ForbiddenSummoningFeature.AddComponent<PrerequisiteFeature>(c => {
                c.Group = Prerequisite.GroupType.All;
                c.m_Feature = MightySummoningFeature.ToReference<BlueprintFeatureReference>();
            });
            ForbiddenSummoningFeature.AddComponent<PrerequisiteFeature>(c => {
                c.Group = Prerequisite.GroupType.All;
                c.m_Feature = MagicalSummoningFeature.ToReference<BlueprintFeatureReference>();
            });

            var FerociousSummoningFeature = CreateSummonBuffToggleFeature(
                name: "FerociousSummoning",
                description: "Your summoned creatures have 2 additional attacks and gain a +10 bonus to speed. It also gains 1d6 sneak attack per character level.",
                descriptionBuff: "This creature has 2 additional attacks and gains a +10 bonus to speed. It also gains 1d6 sneak attack per character level.",
                icon: Icon_FerociousSummoning,
                summonBuffEffect: bp => {
                    bp.AddComponent<BuffExtraAttack>(c => {
                        c.Number = 2;
                        c.Haste = false;
                    });
                    bp.AddComponent<AddStatBonus>(c => {
                        c.Stat = StatType.Speed;
                        c.Value = 10;
                    });
                    bp.AddComponent<AddContextStatBonus>(c => {
                        c.Stat = StatType.SneakAttack;
                        c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                    });
                    bp.AddComponent<ContextRankConfig>(c => {
                        c.m_Type = AbilityRankType.StatBonus;
                        c.m_BaseValueType = ContextRankBaseValueType.CharacterLevel;
                        c.m_Progression = ContextRankProgression.AsIs;
                    });
                });
            FerociousSummoningFeature.AddComponent<PrerequisiteFeature>(c => {
                c.Group = Prerequisite.GroupType.All;
                c.m_Feature = ForbiddenSummoningFeature.ToReference<BlueprintFeatureReference>();
            });

            var ExceptionalSummoingFeatures = new BlueprintFeatureReference[] {
                MightySummoningFeature.ToReference<BlueprintFeatureReference>(),
                MagicalSummoningFeature.ToReference<BlueprintFeatureReference>(),
                ForbiddenSummoningFeature.ToReference<BlueprintFeatureReference>(),
                FerociousSummoningFeature.ToReference<BlueprintFeatureReference>(),
            };

            LocalizedString ExceptionalSummoningDesc = Helpers.CreateString(IsekaiContext, "ExceptionalSummoningSelection.Description",
                "Your summons become more powerful as you increase your level.");

            var ExceptionalSummoningSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "ExceptionalSummoningSelection", bp => {
                bp.SetName(IsekaiContext, "Exceptional Summoning");
                bp.SetDescription(ExceptionalSummoningDesc);
                bp.m_Icon = Icon_ExceptionalSummoning;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.m_AllFeatures = ExceptionalSummoingFeatures;
            });
            var ExceptionalSummoningBonusSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "ExceptionalSummoningBonusSelection", bp => {
                bp.SetName(IsekaiContext, "Exceptional Summoning");
                bp.SetDescription(ExceptionalSummoningDesc);
                bp.m_Icon = Icon_ExceptionalSummoning;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.m_AllFeatures = ExceptionalSummoingFeatures;
            });

            ExceptionalFeatSelection.AddToSelection(ExceptionalSummoningSelection, ExceptionalSummoningBonusSelection);
        }

        private static BlueprintFeature CreateSummonBuffToggleFeature(string name, string description, string descriptionBuff, Sprite icon, Action<BlueprintBuff> summonBuffEffect = null) {
            string displayName = string.Concat(name.Select(x => char.IsUpper(x) ? " " + x : x.ToString())).TrimStart(' ');
            LocalizedString displayDesc = Helpers.CreateString(IsekaiContext, $"{name}.Description", description);
            LocalizedString buffDesc = Helpers.CreateString(IsekaiContext, $"{name}SummonBuff.Description", descriptionBuff);

            var summonBuff = TTCoreExtensions.CreateBuff($"{name}SummonBuff", bp => {
                bp.SetName(IsekaiContext, displayName);
                bp.SetDescription(buffDesc);
                bp.m_Icon = icon;
                bp.Stacking = StackingType.Replace;
                bp.IsClassFeature = true;
            });
            summonBuffEffect?.Invoke(summonBuff);
            var buff = TTCoreExtensions.CreateBuff($"{name}Buff", bp => {
                bp.SetName(IsekaiContext, displayName);
                bp.m_Description = StaticReferences.Strings.Null;
                bp.m_Icon = icon;
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.StayOnDeath | BlueprintBuff.Flags.HiddenInUi;
            });
            var ability = TTCoreExtensions.CreateActivatableAbility($"{name}Ability", bp => {
                bp.SetName(IsekaiContext, displayName);
                bp.SetDescription(displayDesc);
                bp.m_Icon = icon;
                bp.m_Buff = buff.ToReference<BlueprintBuffReference>();
            });
            var feature = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, $"{name}Feature", bp => {
                bp.SetName(IsekaiContext, displayName);
                bp.SetDescription(displayDesc);
                bp.m_Icon = icon;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { ability.ToReference<BlueprintUnitFactReference>() };
                });
                bp.ReapplyOnLevelUp = true;
            });
            buff.AddComponent<OnSpawnBuff>(c => {
                c.m_IfHaveFact = feature.ToReference<BlueprintFeatureReference>();
                c.m_buff = summonBuff.ToReference<BlueprintBuffReference>();
                c.IsInfinity = true;
            });
            return feature;
        }
    }
}