using IsekaiMod.Components;
using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
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

namespace IsekaiMod.Content.Features.ExceptionalFeats
{
    class ExceptionalSummoningSelection
    {
        public static void Add()
        {
            // Mighty Summoning
            var Icon_ExceptionalSummoning = AssetLoader.LoadInternal("Features", "ICON_EXCEPTIONAL_SUMMONING.png");
            var MightySummoningSummonBuff = Helpers.CreateBuff("MightySummoningSummonBuff", bp => {
                bp.SetName("Mighty Summon");
                bp.SetDescription("This creature gets a +5 bonus to maximum Hit Points per character level and a +1 bonus to Attack, damage, and AC per character level.");
                bp.m_Icon = Icon_ExceptionalSummoning;
                bp.Stacking = StackingType.Replace;
                bp.IsClassFeature = true;
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Stat = StatType.HitPoints;
                    c.Value = Values.CreateContextRankValue(AbilityRankType.Default);
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
                    c.m_Type = AbilityRankType.Default;
                    c.m_BaseValueType = ContextRankBaseValueType.CharacterLevel;
                    c.m_Progression = ContextRankProgression.MultiplyByModifier;
                    c.m_StepLevel = 5;
                });
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.StatBonus;
                    c.m_BaseValueType = ContextRankBaseValueType.CharacterLevel;
                    c.m_Progression = ContextRankProgression.AsIs;
                });
            });
            var MightySummoningBuff = Helpers.CreateBuff("MightySummoningBuff", bp => {
                bp.SetName("Mighty Summoning");
                bp.m_Description = new LocalizedString();
                bp.m_Icon = Icon_ExceptionalSummoning;
                bp.Stacking = StackingType.Replace;
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.StayOnDeath | BlueprintBuff.Flags.HiddenInUi;
            });
            var MightySummoningAbility = Helpers.CreateActivatableAbility("MightySummoningAbility", bp => {
                bp.SetName("Mighty Summoning");
                bp.SetDescription("Your summoned creatures get a +5 bonus to maximum Hit Points per character level and a +1 bonus to Attack, damage, and AC per character level.");
                bp.m_Icon = Icon_ExceptionalSummoning;
                bp.m_Buff = MightySummoningBuff.ToReference<BlueprintBuffReference>();
            });
            var MightySummoningFeature = Helpers.CreateFeature("MightySummoningFeature", bp => {
                bp.SetName("Mighty Summoning");
                bp.SetDescription("Your summoned creatures get a +5 bonus to maximum Hit Points per character level and a +1 bonus to Attack, damage, and AC per character level.");
                bp.m_Icon = Icon_ExceptionalSummoning;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { MightySummoningAbility.ToReference<BlueprintUnitFactReference>() };
                });
                bp.ReapplyOnLevelUp = true;
            });
            MightySummoningBuff.AddComponent<OnSpawnBuff>(c => {
                c.m_IfHaveFact = MightySummoningFeature.ToReference<BlueprintFeatureReference>();
                c.m_buff = MightySummoningSummonBuff.ToReference<BlueprintBuffReference>();
                c.IsInfinity = true;
            });

            // Magical Summoning
            var MagicalSummoningSummonBuff = Helpers.CreateBuff("MagicalSummoningSummonBuff", bp => {
                bp.SetName("Magical Summon");
                bp.SetDescription("This creature gets a +5 bonus to maximum Hit Points per character level and a +1 bonus to spell penetration, spell DC, spell damage, "
                    + "and saving throws per character level.");
                bp.m_Icon = Icon_ExceptionalSummoning;
                bp.Stacking = StackingType.Replace;
                bp.IsClassFeature = true;
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Stat = StatType.HitPoints;
                    c.Value = Values.CreateContextRankValue(AbilityRankType.Default);
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
                    c.m_Type = AbilityRankType.Default;
                    c.m_BaseValueType = ContextRankBaseValueType.CharacterLevel;
                    c.m_Progression = ContextRankProgression.MultiplyByModifier;
                    c.m_StepLevel = 5;
                });
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.StatBonus;
                    c.m_BaseValueType = ContextRankBaseValueType.CharacterLevel;
                    c.m_Progression = ContextRankProgression.AsIs;
                });
            });
            var MagicalSummoningBuff = Helpers.CreateBuff("MagicalSummoningBuff", bp => {
                bp.SetName("Magical Summoning");
                bp.m_Description = new LocalizedString();
                bp.m_Icon = Icon_ExceptionalSummoning;
                bp.Stacking = StackingType.Replace;
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.StayOnDeath | BlueprintBuff.Flags.HiddenInUi;
            });
            var MagicalSummoningAbility = Helpers.CreateActivatableAbility("MagicalSummoningAbility", bp => {
                bp.SetName("Magical Summoning");
                bp.SetDescription("Your summoned creatures get a +5 bonus to maximum Hit Points per character level and a +1 bonus to spell penetration, spell DC, spell damage, "
                    + "and saving throws per character level.");
                bp.m_Icon = Icon_ExceptionalSummoning;
                bp.m_Buff = MagicalSummoningBuff.ToReference<BlueprintBuffReference>();
            });
            var MagicalSummoningFeature = Helpers.CreateFeature("MagicalSummoningFeature", bp => {
                bp.SetName("Magical Summoning");
                bp.SetDescription("Your summoned creatures get a +5 bonus to maximum Hit Points per character level and a +1 bonus to spell penetration, spell DC, spell damage, "
                    + "and saving throws per character level.");
                bp.m_Icon = Icon_ExceptionalSummoning;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { MagicalSummoningAbility.ToReference<BlueprintUnitFactReference>() };
                });
                bp.ReapplyOnLevelUp = true;
            });
            MagicalSummoningBuff.AddComponent<OnSpawnBuff>(c => {
                c.m_IfHaveFact = MagicalSummoningFeature.ToReference<BlueprintFeatureReference>();
                c.m_buff = MagicalSummoningSummonBuff.ToReference<BlueprintBuffReference>();
                c.IsInfinity = true;
            });

            // Forbidden Summoning
            var Icon_ForbiddenSummoning = AssetLoader.LoadInternal("Features", "ICON_FORBIDDEN_SUMMONING.png");
            var ForbiddenSummoningSummonBuff = Helpers.CreateBuff("ForbiddenSummoningSummonBuff", bp => {
                bp.SetName("Forbidden Summon");
                bp.SetDescription("This creature gains a +10 bonus to maximum Hit Points per character level and a +1 bonus to all attributes per character level.");
                bp.m_Icon = Icon_ForbiddenSummoning;
                bp.Stacking = StackingType.Replace;
                bp.IsClassFeature = true;
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Stat = StatType.HitPoints;
                    c.Value = Values.CreateContextRankValue(AbilityRankType.Default);
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
                    c.m_Type = AbilityRankType.Default;
                    c.m_BaseValueType = ContextRankBaseValueType.CharacterLevel;
                    c.m_Progression = ContextRankProgression.MultiplyByModifier;
                    c.m_StepLevel = 10;
                });
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.StatBonus;
                    c.m_BaseValueType = ContextRankBaseValueType.CharacterLevel;
                    c.m_Progression = ContextRankProgression.AsIs;
                });
            });
            var ForbiddenSummoningBuff = Helpers.CreateBuff("ForbiddenSummoningBuff", bp => {
                bp.SetName("Forbidden Summoning");
                bp.m_Description = new LocalizedString();
                bp.m_Icon = Icon_ForbiddenSummoning;
                bp.Stacking = StackingType.Replace;
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.StayOnDeath | BlueprintBuff.Flags.HiddenInUi;
            });
            var ForbiddenSummoningAbility = Helpers.CreateActivatableAbility("ForbiddenSummoningAbility", bp => {
                bp.SetName("Forbidden Summoning");
                bp.SetDescription("Your summoned creatures gain a +10 bonus to hit points per character level and a +1 bonus to all attributes per character level.");
                bp.m_Icon = Icon_ForbiddenSummoning;
                bp.m_Buff = ForbiddenSummoningBuff.ToReference<BlueprintBuffReference>();
            });
            var ForbiddenSummoningFeature = Helpers.CreateFeature("ForbiddenSummoningFeature", bp => {
                bp.SetName("Forbidden Summoning");
                bp.SetDescription("Your summoned creatures gain a +10 bonus to hit points per character level and a +1 bonus to all attributes per character level.");
                bp.m_Icon = Icon_ForbiddenSummoning;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { ForbiddenSummoningAbility.ToReference<BlueprintUnitFactReference>() };
                });
                bp.AddComponent<PrerequisiteFeature>(c => {
                    c.Group = Prerequisite.GroupType.All;
                    c.m_Feature = MightySummoningFeature.ToReference<BlueprintFeatureReference>();
                });
                bp.AddComponent<PrerequisiteFeature>(c => {
                    c.Group = Prerequisite.GroupType.All;
                    c.m_Feature = MagicalSummoningFeature.ToReference<BlueprintFeatureReference>();
                });
                bp.ReapplyOnLevelUp = true;
            });
            ForbiddenSummoningBuff.AddComponent<OnSpawnBuff>(c => {
                c.m_IfHaveFact = ForbiddenSummoningFeature.ToReference<BlueprintFeatureReference>();
                c.m_buff = ForbiddenSummoningSummonBuff.ToReference<BlueprintBuffReference>();
                c.IsInfinity = true;
            });

            // Ferocious Summoning
            var Icon_FerociousSummoning = AssetLoader.LoadInternal("Features", "ICON_FEROCIOUS_SUMMONING.png");
            var FerociousSummoningSummonBuff = Helpers.CreateBuff("FerociousSummoningSummonBuff", bp => {
                bp.SetName("Ferocious Summon");
                bp.SetDescription("This creature has 2 additional attacks and gains a +10 bonus to speed. It also gains 1d6 sneak attack per character level.");
                bp.m_Icon = Icon_FerociousSummoning;
                bp.Stacking = StackingType.Replace;
                bp.IsClassFeature = true;
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
            var FerociousSummoningBuff = Helpers.CreateBuff("FerociousSummoningBuff", bp => {
                bp.SetName("Ferocious Summoning");
                bp.m_Description = new LocalizedString();
                bp.m_Icon = Icon_FerociousSummoning;
                bp.Stacking = StackingType.Replace;
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.StayOnDeath | BlueprintBuff.Flags.HiddenInUi;
            });
            var FerociousSummoningAbility = Helpers.CreateActivatableAbility("FerociousSummoningAbility", bp => {
                bp.SetName("Ferocious Summoning");
                bp.SetDescription("Your summoned creatures have 2 additional attacks and gain a +10 bonus to speed. It also gains 1d6 sneak attack per character level.");
                bp.m_Icon = Icon_FerociousSummoning;
                bp.m_Buff = FerociousSummoningBuff.ToReference<BlueprintBuffReference>();
            });
            var FerociousSummoningFeature = Helpers.CreateFeature("FerociousSummoningFeature", bp => {
                bp.SetName("Ferocious Summoning");
                bp.SetDescription("Your summoned creatures have 2 additional attacks and gain a +10 bonus to speed. It also gains 1d6 sneak attack per character level.");
                bp.m_Icon = Icon_FerociousSummoning;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { FerociousSummoningAbility.ToReference<BlueprintUnitFactReference>() };
                });
                bp.AddComponent<PrerequisiteFeature>(c => {
                    c.Group = Prerequisite.GroupType.All;
                    c.m_Feature = ForbiddenSummoningFeature.ToReference<BlueprintFeatureReference>();
                });
                bp.ReapplyOnLevelUp = true;
            });
            FerociousSummoningBuff.AddComponent<OnSpawnBuff>(c => {
                c.m_IfHaveFact = FerociousSummoningFeature.ToReference<BlueprintFeatureReference>();
                c.m_buff = FerociousSummoningSummonBuff.ToReference<BlueprintBuffReference>();
                c.IsInfinity = true;
            });

            var ExceptionalSummoingFeatures = new BlueprintFeatureReference[]
            {
                MightySummoningFeature.ToReference<BlueprintFeatureReference>(),
                MagicalSummoningFeature.ToReference<BlueprintFeatureReference>(),
                ForbiddenSummoningFeature.ToReference<BlueprintFeatureReference>(),
                FerociousSummoningFeature.ToReference<BlueprintFeatureReference>(),
            };

            // Exceptional Summoning Selection
            var ExceptionalSummoningSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>("ExceptionalSummoningSelection", bp => {
                bp.SetName("Exceptional Summoning");
                bp.SetDescription("Your summons become more powerful as you increase your level.");
                bp.m_Icon = Icon_ExceptionalSummoning;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.m_AllFeatures = ExceptionalSummoingFeatures;
            });
            var ExceptionalSummoningBonusSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>("ExceptionalSummoningBonusSelection", bp => {
                bp.SetName("Exceptional Summoning");
                bp.SetDescription("Your summons become more powerful as you increase your level.");
                bp.m_Icon = Icon_ExceptionalSummoning;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.m_AllFeatures = ExceptionalSummoingFeatures;
            });

            ExceptionalFeatSelection.AddToSelection(ExceptionalSummoningSelection, ExceptionalSummoningBonusSelection);
        }
    }
}
