using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Buffs;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.ResourceLinks;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Buffs.Components;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.UnitLogic.Mechanics.Properties;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Villain
{
    class SecondFormFeature
    {
        public static void Add()
        {
            var Icon_SecondForm = AssetLoader.LoadInternal("Features", "ICON_SECOND_FORM.png");
            var Icon_SecondFormInactive = AssetLoader.LoadInternal("Features", "ICON_SECOND_FORM_INACTIVE.png");
            var SecondFormBuffEffect = Helpers.CreateBlueprint<BlueprintBuff>("SecondFormBuffEffect", bp => {
                bp.SetName("Second Form");
                bp.SetDescription("You gain a +10 profane bonus to all attributes and your size increases by one size category for 24 hours.");
                bp.m_Icon = Icon_SecondForm;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.StayOnDeath;
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Profane;
                    c.Stat = StatType.Strength;
                    c.Value = 10;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Profane;
                    c.Stat = StatType.Dexterity;
                    c.Value = 10;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Profane;
                    c.Stat = StatType.Constitution;
                    c.Value = 10;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Profane;
                    c.Stat = StatType.Intelligence;
                    c.Value = 10;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Profane;
                    c.Stat = StatType.Wisdom;
                    c.Value = 10;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Profane;
                    c.Stat = StatType.Charisma;
                    c.Value = 10;
                });
                bp.AddComponent<ChangeUnitSize>(c => {
                    c.m_Type = ChangeUnitSize.ChangeType.Delta;
                    c.SizeDelta = 1;
                    c.Size = Size.Fine;
                });
                bp.AddComponent<AddGenericStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Size;
                    c.Stat = StatType.Strength;
                    c.Value = 2;
                });
                bp.AddComponent<AddGenericStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Size;
                    c.Stat = StatType.Dexterity;
                    c.Value = -2;
                });
                bp.Stacking = StackingType.Replace;
                bp.FxOnStart = new PrefabLink();
                bp.FxOnRemove = new PrefabLink();
            });
            var SecondFormBuffTrigger = Helpers.CreateBlueprint<BlueprintBuff>("SecondFormBuffTrigger", bp => {
                bp.SetName("Second Form Trigger");
                bp.SetDescription("");
                bp.m_Icon = null;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.StayOnDeath | BlueprintBuff.Flags.HiddenInUi;
                bp.FxOnStart = new PrefabLink();
                bp.FxOnRemove = new PrefabLink();
            });
            var SecondFormBuff = Helpers.CreateBlueprint<BlueprintBuff>("SecondFormBuff", bp => {
                bp.SetName("Second Form");
                bp.SetDescription("Once per day, when your {g|Encyclopedia:HP}HP{/g} drops to 0, you are restored to full HP, ability damage, and ability drain. "
                    + "You also gain a +10 profane bonus to all attributes and your size also increases by one size category for 24 hours.");
                bp.m_Icon = Icon_SecondFormInactive;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.AddComponent<UnitHealthGuard>(c => {
                    c.HealthPercent = 0;
                });
                bp.AddComponent<BuffOnHealthTickingTrigger>(c => {
                    c.HealthPercent = 0.001f;
                    c.m_TriggeredBuff = SecondFormBuffTrigger.ToReference<BlueprintBuffReference>();
                });
                bp.AddComponent<AddFactContextActions>(c => {
                    c.Activated = ActionFlow.DoSingle<ContextActionRemoveBuff>(c => {
                        c.m_Buff = SecondFormBuffEffect.ToReference<BlueprintBuffReference>();
                        c.ToCaster = false;
                        c.RemoveRank = false;
                    });
                    c.Deactivated = ActionFlow.DoNothing();
                    c.NewRound = ActionFlow.DoNothing();
                });
                bp.m_Flags = BlueprintBuff.Flags.StayOnDeath;
                bp.FxOnStart = new PrefabLink();
                bp.FxOnRemove = new PrefabLink();
            });
            SecondFormBuffTrigger.AddComponent<AddFactContextActions>(c => {
                c.Activated = Helpers.CreateActionList(
                    new ContextActionRemoveBuff()
                    {
                        m_Buff = SecondFormBuff.ToReference<BlueprintBuffReference>(),
                        ToCaster = false,
                        RemoveRank = false
                    },
                    new ContextActionHealStatDamage()
                    {
                        m_StatClass = ContextActionHealStatDamage.StatClass.Any,
                        m_HealType = ContextActionHealStatDamage.StatDamageHealType.HealAllDamage,
                        HealDrain = true,
                        WriteResultToSharedValue = false,
                        ResultSharedValue = AbilitySharedValue.Heal,
                        Value = new ContextDiceValue()
                        {
                            DiceType = DiceType.Zero,
                            DiceCountValue = 0,
                            BonusValue = 0,
                        }
                    },
                    new ContextActionHealStatDamage()
                    {
                        m_StatClass = ContextActionHealStatDamage.StatClass.Any,
                        m_HealType = ContextActionHealStatDamage.StatDamageHealType.HealAllDamage,
                        HealDrain = false,
                        WriteResultToSharedValue = false,
                        ResultSharedValue = AbilitySharedValue.Heal,
                        Value = new ContextDiceValue()
                        {
                            DiceType = DiceType.Zero,
                            DiceCountValue = 0,
                            BonusValue = 0,
                        }
                    },
                    new ContextActionHealEnergyDrain()
                    {
                        TemporaryNegativeLevelsHeal = EnergyDrainHealType.All,
                        PermanentNegativeLevelsHeal = EnergyDrainHealType.All,
                    },
                    new ContextActionRemoveDeathDoor(),
                    new ContextActionSpawnFx()
                    {
                        PrefabLink = new PrefabLink() { AssetId = "14ba08b903ee28b41a779a616d905397" }
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
                    new ContextActionApplyBuff()
                    {
                        m_Buff = SecondFormBuffEffect.ToReference<BlueprintBuffReference>(),
                        Permanent = false,
                        DurationValue = new ContextDurationValue()
                        {
                            Rate = DurationRate.Hours,
                            DiceType = DiceType.Zero,
                            DiceCountValue = 0,
                            BonusValue = 24,
                            m_IsExtendable = true
                        },
                        UseDurationSeconds = false,
                        DurationSeconds = 0,
                        IsFromSpell = false,
                        ToCaster = false,
                        AsChild = false
                    },
                    new ContextActionRemoveSelf()
                    );
                c.Deactivated = ActionFlow.DoNothing();
                c.NewRound = ActionFlow.DoNothing();
            });
            var SecondFormFeature = Helpers.CreateBlueprint<BlueprintFeature>("SecondFormFeature", bp => {
                bp.SetName("Second Form");
                bp.SetDescription("At 20th level, you become a boss. Once per day, when your {g|Encyclopedia:HP}HP{/g} drops to 0, you are restored to full HP, ability damage, and ability drain. "
                    + "You also gain a +10 profane bonus to all attributes and your size also increases by one size category for 24 hours.");
                bp.m_Icon = Icon_SecondForm;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.AddComponent<AddRestTrigger>(c => {
                    c.Action = ActionFlow.DoSingle<ContextActionApplyBuff>(c => {
                        c.m_Buff = SecondFormBuff.ToReference<BlueprintBuffReference>();
                        c.Permanent = true;
                        c.IsFromSpell = false;
                    });
                });
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { SecondFormBuff.ToReference<BlueprintUnitFactReference>() };
                    c.DoNotRestoreMissingFacts = true;
                });
            });
        }
    }
}
