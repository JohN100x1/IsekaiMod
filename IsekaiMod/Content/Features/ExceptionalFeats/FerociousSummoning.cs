using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Designers.Mechanics.Buffs;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Components;

namespace IsekaiMod.Content.Features.ExceptionalFeats
{
    class FerociousSummoning
    {
        public static void Add()
        {
            var Icon_FerociousSummoning = AssetLoader.LoadInternal("Features", "ICON_FEROCIOUS_SUMMONING.png");
            var FerociousSummoningSummonBuff = Helpers.CreateBuff("FerociousSummoningSummonBuff", bp => {
                bp.SetName("Ferocious Summon");
                bp.SetDescription("This creature has 2 additional attacks and gains a +10 bonus to speed. It also gains 1d6 sneak attack per character level. "
                    + "This effect does not stack with other effects that grant additional attack.");
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
                    c.Value = new ContextValue()
                    {
                        ValueType = ContextValueType.Rank,
                        ValueRank = AbilityRankType.StatBonus
                    };
                });
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.StatBonus;
                    c.m_BaseValueType = ContextRankBaseValueType.CharacterLevel;
                    c.m_Progression = ContextRankProgression.AsIs;
                });
            });
            var FerociousSummoningBuff = Helpers.CreateBuff("FerociousSummoningBuff", bp => {
                bp.SetName("Ferocious Summoning");
                bp.SetDescription("Your summoned creatures have 2 additional attacks and gain a +10 bonus to speed. It also gains 1d6 sneak attack per character level. "
                    + "This effect does not stack with other effects that grant additional attack.");
                bp.m_Icon = Icon_FerociousSummoning;
                bp.Stacking = StackingType.Replace;
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.StayOnDeath | BlueprintBuff.Flags.HiddenInUi;
            });
            var FerociousSummoningAbility = Helpers.CreateActivatableAbility("FerociousSummoningAbility", bp => {
                bp.SetName("Ferocious Summoning");
                bp.SetDescription("Your summoned creatures have 2 additional attacks and gain a +10 bonus to speed. It also gains 1d6 sneak attack per character level. "
                    + "This effect does not stack with other effects that grant additional attack.");
                bp.m_Icon = Icon_FerociousSummoning;
                bp.m_Buff = FerociousSummoningBuff.ToReference<BlueprintBuffReference>();
            });
            var FerociousSummoningFeature = Helpers.CreateFeature("FerociousSummoningFeature", bp => {
                bp.SetName("Ferocious Summoning");
                bp.SetDescription("Your summoned creatures have 2 additional attacks and gain a +10 bonus to speed. It also gains 1d6 sneak attack per character level. "
                    + "This effect does not stack with other effects that grant additional attack.");
                bp.m_Icon = Icon_FerociousSummoning;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { FerociousSummoningAbility.ToReference<BlueprintUnitFactReference>() };
                });
                bp.AddComponent<PrerequisiteFeature>(c => {
                    c.Group = Prerequisite.GroupType.All;
                    c.m_Feature = ExceptionalSummoning.GetReference();
                });
                bp.AddComponent<PrerequisiteFeature>(c => {
                    c.Group = Prerequisite.GroupType.All;
                    c.m_Feature = ForbiddenSummoning.GetReference();
                });
                bp.ReapplyOnLevelUp = true;
            });
            FerociousSummoningBuff.AddComponent<OnSpawnBuff>(c => {
                c.m_IfHaveFact = FerociousSummoningFeature.ToReference<BlueprintFeatureReference>();
                c.m_buff = FerociousSummoningSummonBuff.ToReference<BlueprintBuffReference>();
                c.CheckDescriptor = true;
                c.SpellDescriptor = SpellDescriptor.Summoning;
                c.IsInfinity = true;
            });

            ExceptionalFeatSelection.AddToSelection(FerociousSummoningFeature);
        }
    }
}
