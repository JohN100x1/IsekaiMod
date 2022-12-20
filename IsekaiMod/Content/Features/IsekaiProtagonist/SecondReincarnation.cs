using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.ResourceLinks;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.UnitLogic.Mechanics.Properties;

namespace IsekaiMod.Content.Features.IsekaiProtagonist
{
    class SecondReincarnation
    {
        public static void Add()
        {
            var Icon_SecondReincarnation = AssetLoader.LoadInternal("Features", "ICON_SECOND_REINCARNATION.png");
            var SecondReincarnationBuff = Helpers.CreateBuff("SecondReincarnationBuff", bp => {
                bp.SetName("Second Reincarnation");
                bp.SetDescription("Once per day, when your {g|Encyclopedia:HP}HP{/g} drops to 0, you are restored to full HP, ability damage, and ability drain.\n"
                    + "Your attacks ignore damage reduction and your spells ignore spell resistance and spell immunity.");
                bp.m_Icon = Icon_SecondReincarnation;
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
                            Value = Values.Dice.Zero
                        },
                        new ContextActionHealStatDamage()
                        {
                            HealDrain = false,
                            m_StatClass = ContextActionHealStatDamage.StatClass.Any,
                            m_HealType = ContextActionHealStatDamage.StatDamageHealType.HealAllDamage,
                            ResultSharedValue = AbilitySharedValue.Heal,
                            Value = Values.Dice.Zero
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
                                BonusValue = Values.CreateContextTargetPropertyValue(UnitProperty.MaxHP)
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
                bp.SetDescription("Once per day, when your {g|Encyclopedia:HP}HP{/g} drops to 0, you are restored to full HP, ability damage, and ability drain.\n"
                    + "Your attacks ignore damage reduction and your spells ignore spell resistance and spell immunity.");
                bp.m_Icon = Icon_SecondReincarnation;
                bp.AddComponent<IgnoreDamageReductionOnAttack>();
                bp.AddComponent<IgnoreSpellImmunity>(c => {
                    c.SpellDescriptor = SpellDescriptor.None;
                });
                bp.AddComponent<IgnoreSpellResistanceForSpells>(c => {
                    c.m_AbilityList = new BlueprintAbilityReference[0];
                    c.AllSpells = true;
                });
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
