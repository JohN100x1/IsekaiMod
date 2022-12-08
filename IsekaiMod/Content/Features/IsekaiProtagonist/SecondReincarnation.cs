using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Enums;
using Kingmaker.ResourceLinks;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.UnitLogic.Mechanics.Properties;
using UnityEngine;

namespace IsekaiMod.Content.Features.IsekaiProtagonist
{
    class SecondReincarnation
    {
        private static readonly Sprite Icon_AngelPhoenixGift = Resources.GetBlueprint<BlueprintAbility>("af92783492851f445abb2c01d346c376").m_Icon;
        public static void Add()
        {
            var SecondReincarnationBuff = Helpers.CreateBuff("SecondReincarnationBuff", bp => {
                bp.SetName("Second Reincarnation");
                bp.SetDescription("Once per day, when your {g|Encyclopedia:HP}HP{/g} drops to 0, you are restored to full HP, ability damage, and ability drain.");
                bp.m_Icon = Icon_AngelPhoenixGift;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.AddComponent<AddImmortality>();
                bp.AddComponent<AddIncomingDamageTrigger>(c => {
                    c.ReduceBelowZero = true;
                    c.Actions = Helpers.CreateActionList(
                        new ContextActionHealStatDamage()
                        {
                            HealDrain = true,
                            m_StatClass = ContextActionHealStatDamage.StatClass.Any,
                            m_HealType = ContextActionHealStatDamage.StatDamageHealType.HealAllDamage,
                            ResultSharedValue = AbilitySharedValue.Heal,
                            Value = Constants.ZeroDiceValue
                        },
                        new ContextActionHealStatDamage()
                        {
                            HealDrain = false,
                            m_StatClass = ContextActionHealStatDamage.StatClass.Any,
                            m_HealType = ContextActionHealStatDamage.StatDamageHealType.HealAllDamage,
                            ResultSharedValue = AbilitySharedValue.Heal,
                            Value = Constants.ZeroDiceValue
                        },
                        new ContextActionHealEnergyDrain()
                        {
                            TemporaryNegativeLevelsHeal = EnergyDrainHealType.All,
                            PermanentNegativeLevelsHeal = EnergyDrainHealType.All,
                        },
                        new ContextActionHealTarget()
                        {
                            Value = new ContextDiceValue()
                            {
                                DiceType = DiceType.Zero,
                                DiceCountValue = 0,
                                BonusValue = new ContextValue()
                                {
                                    ValueRank = AbilityRankType.Default,
                                    ValueType = ContextValueType.TargetProperty,
                                    Property = UnitProperty.MaxHP
                                }
                            }
                        },
                        new ContextActionSpawnFx()
                        {
                            PrefabLink = new PrefabLink() { AssetId = "749ad3759dc93d64dba70a84d48135b5" }
                        },
                        new ContextActionRemoveSelf()
                        );
                });
                bp.m_Flags = BlueprintBuff.Flags.StayOnDeath;
            });
            var SecondReincarnation = Helpers.CreateFeature("SecondReincarnation", bp => {
                bp.SetName("Second Reincarnation");
                bp.SetDescription("Once per day, when your {g|Encyclopedia:HP}HP{/g} drops to 0, you are restored to full HP, ability damage, and ability drain.");
                bp.m_Icon = Icon_AngelPhoenixGift;
                bp.AddComponent<AddRestTrigger>(c => {
                    c.Action = ActionFlow.DoSingle<ContextActionApplyBuff>(c => {
                        c.m_Buff = SecondReincarnationBuff.ToReference<BlueprintBuffReference>();
                        c.Permanent = true;
                        c.IsFromSpell = false;
                    });
                });
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { SecondReincarnationBuff.ToReference<BlueprintUnitFactReference>() };
                    c.DoNotRestoreMissingFacts = true;
                });
            });
        }
    }
}
