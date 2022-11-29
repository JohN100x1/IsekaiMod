using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.Localization;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Commands.Base;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.Visual.Animation.Kingmaker.Actions;
using UnityEngine;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.OverpoweredAbility
{
    class SummonCalamity
    {
        // Units
        private static readonly BlueprintUnit Devastator = Resources.GetBlueprint<BlueprintUnit>("99c16c4360534129b45706841a7df3fe");
        private static readonly BlueprintUnit Baphomet = Resources.GetBlueprint<BlueprintUnit>("f8007503fe211da4eb027e070eeb3f8c");
        private static readonly BlueprintUnit DemonLordDeskari = Resources.GetBlueprint<BlueprintUnit>("5a75db49bf7aeaf4c9f0264cac3eed5c");

        private static readonly BlueprintSummonPool SummonMonsterPool = Resources.GetBlueprint<BlueprintSummonPool>("d94c93e7240f10e41ae41db4c83d1cbe");
        private static readonly BlueprintBuff SummonedCreatureSpawnMonsterVI_IX = Resources.GetBlueprint<BlueprintBuff>("0dff842f06edace43baf8a2f44207045");
        private static readonly Sprite Icon_SummonMonsterIX = Resources.GetBlueprint<BlueprintAbility>("52b5df2a97df18242aec67610616ded0").m_Icon;
        public static void Add()
        {
            var SummonDevastator = Helpers.CreateBlueprint<BlueprintAbility>("SummonDevastator", bp => {
                bp.SetName("Overpowered Ability — Summon Calamity (Devastator)");
                bp.SetDescription("This {g|Encyclopedia:Spell}spell{/g} summons a Devastator. Summoned monsters appear where you designate and act according to their "
                    + "{g|Encyclopedia:Initiative}initiative{/g} {g|Encyclopedia:Check}check{/g} results. They {g|Encyclopedia:Attack}attack{/g} your opponents to the best of their ability.");
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.SavingThrowType = SavingThrowType.Unknown;
                    c.Actions = ActionFlow.DoSingle<ContextActionSpawnMonster>(c => {
                        c.m_Blueprint = Devastator.ToReference<BlueprintUnitReference>();
                        c.m_SummonPool = SummonMonsterPool.ToReference<BlueprintSummonPoolReference>();
                        c.DurationValue = new ContextDurationValue()
                        {
                            Rate = DurationRate.Rounds,
                            DiceType = DiceType.Zero,
                            DiceCountValue = 0,
                            BonusValue = new ContextValue()
                            {
                                ValueType = ContextValueType.Rank,
                                ValueRank = AbilityRankType.Default
                            },
                            m_IsExtendable = true
                        };
                        c.CountValue = new ContextDiceValue()
                        {
                            DiceType = DiceType.Zero,
                            DiceCountValue = 0,
                            BonusValue = 1
                        };
                        c.LevelValue = 0;
                        c.DoNotLinkToCaster = false;
                        c.IsDirectlyControllable = false;
                        c.AfterSpawn = ActionFlow.DoSingle<ContextActionApplyBuff>(c => {
                            c.Permanent = true;
                            c.m_Buff = SummonedCreatureSpawnMonsterVI_IX.ToReference<BlueprintBuffReference>();
                            c.DurationValue = new ContextDurationValue()
                            {
                                Rate = DurationRate.Rounds,
                                DiceType = DiceType.Zero,
                                DiceCountValue = 0,
                                BonusValue = 0,
                                m_IsExtendable = true
                            };
                            c.IsNotDispelable = true;
                            c.UseDurationSeconds = false;
                            c.DurationSeconds = 0;
                            c.IsFromSpell = false;
                            c.ToCaster = false;
                            c.AsChild = false;
                        });
                    });
                });
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.Default;
                    c.m_BaseValueType = ContextRankBaseValueType.CharacterLevel;
                    c.m_Progression = ContextRankProgression.AsIs;
                });
                bp.AddComponent<SpellComponent>(c => {
                    c.School = SpellSchool.Conjuration;
                });
                bp.AddComponent<SpellDescriptorComponent>(c => {
                    c.Descriptor = SpellDescriptor.Summoning;
                });
                bp.m_Icon = Icon_SummonMonsterIX;
                bp.Type = AbilityType.Special;
                bp.Range = AbilityRange.Close;
                bp.CanTargetPoint = true;
                bp.CanTargetEnemies = false;
                bp.CanTargetFriends = false;
                bp.CanTargetSelf = true;
                bp.SpellResistance = false;
                bp.EffectOnAlly = AbilityEffectOnUnit.None;
                bp.EffectOnEnemy = AbilityEffectOnUnit.None;
                bp.Animation = UnitAnimationActionCastSpell.CastAnimationStyle.Omni;
                bp.ActionType = UnitCommand.CommandType.Standard;
                bp.AvailableMetamagic = Metamagic.Quicken;
                bp.m_TargetMapObjects = false;
                bp.m_IsFullRoundAction = true;
                bp.LocalizedDuration = Helpers.CreateString($"{bp.name}.Duration", "1 round/level");
                bp.LocalizedSavingThrow = new LocalizedString();
            });
            var SummonBaphomet = Helpers.CreateBlueprint<BlueprintAbility>("SummonBaphomet", bp => {
                bp.SetName("Overpowered Ability — Summon Calamity (Baphomet)");
                bp.SetDescription("This {g|Encyclopedia:Spell}spell{/g} summons Demon Lord Baphomet. Summoned monsters appear where you designate and act according to their "
                    + "{g|Encyclopedia:Initiative}initiative{/g} {g|Encyclopedia:Check}check{/g} results. They {g|Encyclopedia:Attack}attack{/g} your opponents to the best of their ability.");
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.SavingThrowType = SavingThrowType.Unknown;
                    c.Actions = ActionFlow.DoSingle<ContextActionSpawnMonster>(c => {
                        c.m_Blueprint = Baphomet.ToReference<BlueprintUnitReference>();
                        c.m_SummonPool = SummonMonsterPool.ToReference<BlueprintSummonPoolReference>();
                        c.DurationValue = new ContextDurationValue()
                        {
                            Rate = DurationRate.Rounds,
                            DiceType = DiceType.Zero,
                            DiceCountValue = 0,
                            BonusValue = new ContextValue()
                            {
                                ValueType = ContextValueType.Rank,
                                ValueRank = AbilityRankType.Default
                            },
                            m_IsExtendable = true
                        };
                        c.CountValue = new ContextDiceValue()
                        {
                            DiceType = DiceType.Zero,
                            DiceCountValue = 0,
                            BonusValue = 1
                        };
                        c.LevelValue = 0;
                        c.DoNotLinkToCaster = false;
                        c.IsDirectlyControllable = false;
                        c.AfterSpawn = ActionFlow.DoSingle<ContextActionApplyBuff>(c => {
                            c.Permanent = true;
                            c.m_Buff = SummonedCreatureSpawnMonsterVI_IX.ToReference<BlueprintBuffReference>();
                            c.DurationValue = new ContextDurationValue()
                            {
                                Rate = DurationRate.Rounds,
                                DiceType = DiceType.Zero,
                                DiceCountValue = 0,
                                BonusValue = 0,
                                m_IsExtendable = true
                            };
                            c.IsNotDispelable = true;
                            c.UseDurationSeconds = false;
                            c.DurationSeconds = 0;
                            c.IsFromSpell = false;
                            c.ToCaster = false;
                            c.AsChild = false;
                        });
                    });
                });
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.Default;
                    c.m_BaseValueType = ContextRankBaseValueType.CharacterLevel;
                    c.m_Progression = ContextRankProgression.AsIs;
                });
                bp.AddComponent<SpellComponent>(c => {
                    c.School = SpellSchool.Conjuration;
                });
                bp.AddComponent<SpellDescriptorComponent>(c => {
                    c.Descriptor = SpellDescriptor.Summoning;
                });
                bp.m_Icon = Icon_SummonMonsterIX;
                bp.Type = AbilityType.Special;
                bp.Range = AbilityRange.Close;
                bp.CanTargetPoint = true;
                bp.CanTargetEnemies = false;
                bp.CanTargetFriends = false;
                bp.CanTargetSelf = true;
                bp.SpellResistance = false;
                bp.EffectOnAlly = AbilityEffectOnUnit.None;
                bp.EffectOnEnemy = AbilityEffectOnUnit.None;
                bp.Animation = UnitAnimationActionCastSpell.CastAnimationStyle.Omni;
                bp.ActionType = UnitCommand.CommandType.Standard;
                bp.AvailableMetamagic = Metamagic.Quicken;
                bp.m_TargetMapObjects = false;
                bp.m_IsFullRoundAction = true;
                bp.LocalizedDuration = Helpers.CreateString($"{bp.name}.Duration", "1 round/level");
                bp.LocalizedSavingThrow = new LocalizedString();
            });
            var SummonDemonLordDeskari = Helpers.CreateBlueprint<BlueprintAbility>("SummonDemonLordDeskari", bp => {
                bp.SetName("Overpowered Ability — Summon Calamity (Deskari)");
                bp.SetDescription("This {g|Encyclopedia:Spell}spell{/g} summons Demon Lord Deskari. Summoned monsters appear where you designate and act according to their "
                    + "{g|Encyclopedia:Initiative}initiative{/g} {g|Encyclopedia:Check}check{/g} results. They {g|Encyclopedia:Attack}attack{/g} your opponents to the best of their ability.");
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.SavingThrowType = SavingThrowType.Unknown;
                    c.Actions = ActionFlow.DoSingle<ContextActionSpawnMonster>(c => {
                        c.m_Blueprint = DemonLordDeskari.ToReference<BlueprintUnitReference>();
                        c.m_SummonPool = SummonMonsterPool.ToReference<BlueprintSummonPoolReference>();
                        c.DurationValue = new ContextDurationValue()
                        {
                            Rate = DurationRate.Rounds,
                            DiceType = DiceType.Zero,
                            DiceCountValue = 0,
                            BonusValue = new ContextValue()
                            {
                                ValueType = ContextValueType.Rank,
                                ValueRank = AbilityRankType.Default
                            },
                            m_IsExtendable = true
                        };
                        c.CountValue = new ContextDiceValue()
                        {
                            DiceType = DiceType.Zero,
                            DiceCountValue = 0,
                            BonusValue = 1
                        };
                        c.LevelValue = 0;
                        c.DoNotLinkToCaster = false;
                        c.IsDirectlyControllable = false;
                        c.AfterSpawn = ActionFlow.DoSingle<ContextActionApplyBuff>(c => {
                            c.Permanent = true;
                            c.m_Buff = SummonedCreatureSpawnMonsterVI_IX.ToReference<BlueprintBuffReference>();
                            c.DurationValue = new ContextDurationValue()
                            {
                                Rate = DurationRate.Rounds,
                                DiceType = DiceType.Zero,
                                DiceCountValue = 0,
                                BonusValue = 0,
                                m_IsExtendable = true
                            };
                            c.IsNotDispelable = true;
                            c.UseDurationSeconds = false;
                            c.DurationSeconds = 0;
                            c.IsFromSpell = false;
                            c.ToCaster = false;
                            c.AsChild = false;
                        });
                    });
                });
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.Default;
                    c.m_BaseValueType = ContextRankBaseValueType.CharacterLevel;
                    c.m_Progression = ContextRankProgression.AsIs;
                });
                bp.AddComponent<SpellComponent>(c => {
                    c.School = SpellSchool.Conjuration;
                });
                bp.AddComponent<SpellDescriptorComponent>(c => {
                    c.Descriptor = SpellDescriptor.Summoning;
                });
                bp.m_Icon = Icon_SummonMonsterIX;
                bp.Type = AbilityType.Special;
                bp.Range = AbilityRange.Close;
                bp.CanTargetPoint = true;
                bp.CanTargetEnemies = false;
                bp.CanTargetFriends = false;
                bp.CanTargetSelf = true;
                bp.SpellResistance = false;
                bp.EffectOnAlly = AbilityEffectOnUnit.None;
                bp.EffectOnEnemy = AbilityEffectOnUnit.None;
                bp.Animation = UnitAnimationActionCastSpell.CastAnimationStyle.Omni;
                bp.ActionType = UnitCommand.CommandType.Standard;
                bp.AvailableMetamagic = Metamagic.Quicken;
                bp.m_TargetMapObjects = false;
                bp.m_IsFullRoundAction = true;
                bp.LocalizedDuration = Helpers.CreateString($"{bp.name}.Duration", "1 round/level");
                bp.LocalizedSavingThrow = new LocalizedString();
            });
            var SummonCalamityAbility = Helpers.CreateBlueprint<BlueprintAbility>("SummonCalamityAbility", bp => {
                bp.SetName("Overpowered Ability — Summon Calamity");
                bp.SetDescription("This {g|Encyclopedia:Spell}spell{/g} summons a Devastator, Baphomet, or Deskari. Summoned monsters appear where you designate and act according to their "
                    + "{g|Encyclopedia:Initiative}initiative{/g} {g|Encyclopedia:Check}check{/g} results. They {g|Encyclopedia:Attack}attack{/g} your opponents to the best of their ability.");
                bp.AddComponent<AbilityVariants>(c => {
                    c.m_Variants = new BlueprintAbilityReference[] {
                        SummonDevastator.ToReference<BlueprintAbilityReference>(),
                        SummonBaphomet.ToReference<BlueprintAbilityReference>(),
                        SummonDemonLordDeskari.ToReference<BlueprintAbilityReference>(),
                    };
                });
                bp.AddComponent<SpellComponent>(c => {
                    c.School = SpellSchool.Conjuration;
                });
                bp.AddComponent<SpellDescriptorComponent>(c => {
                    c.Descriptor = SpellDescriptor.Summoning;
                });
                bp.m_Icon = Icon_SummonMonsterIX;
                bp.Type = AbilityType.Special;
                bp.Range = AbilityRange.Close;
                bp.CanTargetPoint = true;
                bp.CanTargetEnemies = false;
                bp.CanTargetFriends = false;
                bp.CanTargetSelf = true;
                bp.SpellResistance = false;
                bp.EffectOnAlly = AbilityEffectOnUnit.None;
                bp.EffectOnEnemy = AbilityEffectOnUnit.None;
                bp.Animation = UnitAnimationActionCastSpell.CastAnimationStyle.Point;
                bp.ActionType = UnitCommand.CommandType.Standard;
                bp.AvailableMetamagic = Metamagic.Quicken;
                bp.m_TargetMapObjects = false;
                bp.m_IsFullRoundAction = true;
                bp.LocalizedDuration = Helpers.CreateString($"{bp.name}.Duration", "1 round/level");
                bp.LocalizedSavingThrow = new LocalizedString();
            });
            var SummonCalamityFeature = Helpers.CreateBlueprint<BlueprintFeature>("SummonCalamityFeature", bp => {
                bp.SetName("Overpowered Ability — Summon Calamity");
                bp.SetDescription("As a full action, you summon a powerful being to bring calamity. You can summon one of the following: Devastator, Baphomet, or Deskari.");
                bp.m_Icon = Icon_SummonMonsterIX;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { SummonCalamityAbility.ToReference<BlueprintUnitFactReference>() };
                });
            });

            // Set Parents
            SummonDevastator.m_Parent = SummonCalamityAbility.ToReference<BlueprintAbilityReference>();
            SummonBaphomet.m_Parent = SummonCalamityAbility.ToReference<BlueprintAbilityReference>();
            SummonDemonLordDeskari.m_Parent = SummonCalamityAbility.ToReference<BlueprintAbilityReference>();

            OverpoweredAbilitySelection.AddToSelection(SummonCalamityFeature);
        }
    }
}
