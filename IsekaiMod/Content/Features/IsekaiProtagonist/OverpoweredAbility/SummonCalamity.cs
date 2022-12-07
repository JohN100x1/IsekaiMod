using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.ElementsSystem;
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
using System;
using UnityEngine;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.OverpoweredAbility
{
    class SummonCalamity
    {
        // Units
        private static readonly BlueprintUnit Devastator = Resources.GetBlueprint<BlueprintUnit>("99c16c4360534129b45706841a7df3fe");
        private static readonly BlueprintUnit PlayfulDarkness = Resources.GetBlueprint<BlueprintUnit>("a1b06220efb4f0545a870ce52fadd678");
        private static readonly BlueprintUnit Baphomet = Resources.GetBlueprint<BlueprintUnit>("f8007503fe211da4eb027e070eeb3f8c");
        private static readonly BlueprintUnit DemonLordDeskari = Resources.GetBlueprint<BlueprintUnit>("5a75db49bf7aeaf4c9f0264cac3eed5c");
        private static readonly BlueprintUnit Nocticula = Resources.GetBlueprint<BlueprintUnit>("0cca8c841d634d84fbec2609c8db3465");
        private static readonly BlueprintUnit Mephistopheles = Resources.GetBlueprint<BlueprintUnit>("c3dfbb136aa27e74eb7a7b5159395a80");

        private static readonly BlueprintSummonPool SummonMonsterPool = Resources.GetBlueprint<BlueprintSummonPool>("d94c93e7240f10e41ae41db4c83d1cbe");
        private static readonly BlueprintBuff SummonedCreatureSpawnMonsterVI_IX = Resources.GetBlueprint<BlueprintBuff>("0dff842f06edace43baf8a2f44207045");
        private static readonly Sprite Icon_SummonMonsterIX = Resources.GetBlueprint<BlueprintAbility>("52b5df2a97df18242aec67610616ded0").m_Icon;

        private static readonly ContextDurationValue RankDuration = new()
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
        private static readonly ContextDiceValue DiceValueOne = new()
        {
            DiceType = DiceType.Zero,
            DiceCountValue = 0,
            BonusValue = 1
        };
        public static void Add()
        {
            var SummonCalamityAbility = CreateSummonAbility("SummonCalamityAbility", bp => {
                bp.SetName("Overpowered Ability — Summon Calamity");
                bp.SetDescription("This {g|Encyclopedia:Spell}spell{/g} summons a Devastator, Playful Darkness, Baphomet, Deskari, Nocticula, or Mephistopheles. "
                    + "Summoned monsters appear where you designate and act according to their {g|Encyclopedia:Initiative}initiative{/g} {g|Encyclopedia:Check}check{/g} results. "
                    + "They {g|Encyclopedia:Attack}attack{/g} your opponents to the best of their ability.");
            });
            var SummonDevastator = CreateSummonAbility("SummonDevastator", bp => {
                bp.SetName("Overpowered Ability — Summon Calamity (Devastator)");
                bp.SetDescription("This {g|Encyclopedia:Spell}spell{/g} summons a Devastator. Summoned monsters appear where you designate and act according to their "
                    + "{g|Encyclopedia:Initiative}initiative{/g} {g|Encyclopedia:Check}check{/g} results. They {g|Encyclopedia:Attack}attack{/g} your opponents to the best of their ability.");
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.Actions = SpawnCalamity(c => {
                        c.m_Blueprint = Devastator.ToReference<BlueprintUnitReference>();
                    });
                });
            });
            var SummonPlayfulDarkness = CreateSummonAbility("SummonPlayfulDarkness", bp => {
                bp.SetName("Overpowered Ability — Summon Calamity (Playful Darkness)");
                bp.SetDescription("This {g|Encyclopedia:Spell}spell{/g} summons Playful Darkness. Summoned monsters appear where you designate and act according to their "
                    + "{g|Encyclopedia:Initiative}initiative{/g} {g|Encyclopedia:Check}check{/g} results. They {g|Encyclopedia:Attack}attack{/g} your opponents to the best of their ability.");
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.Actions = SpawnCalamity(c => {
                        c.m_Blueprint = PlayfulDarkness.ToReference<BlueprintUnitReference>();
                    });
                });
            });
            var SummonBaphomet = CreateSummonAbility("SummonBaphomet", bp => {
                bp.SetName("Overpowered Ability — Summon Calamity (Baphomet)");
                bp.SetDescription("This {g|Encyclopedia:Spell}spell{/g} summons Demon Lord Baphomet. Summoned monsters appear where you designate and act according to their "
                    + "{g|Encyclopedia:Initiative}initiative{/g} {g|Encyclopedia:Check}check{/g} results. They {g|Encyclopedia:Attack}attack{/g} your opponents to the best of their ability.");
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.Actions = SpawnCalamity(c => {
                        c.m_Blueprint = Baphomet.ToReference<BlueprintUnitReference>();
                    });
                });
            });
            var SummonDemonLordDeskari = CreateSummonAbility("SummonDemonLordDeskari", bp => {
                bp.SetName("Overpowered Ability — Summon Calamity (Deskari)");
                bp.SetDescription("This {g|Encyclopedia:Spell}spell{/g} summons Demon Lord Deskari. Summoned monsters appear where you designate and act according to their "
                    + "{g|Encyclopedia:Initiative}initiative{/g} {g|Encyclopedia:Check}check{/g} results. They {g|Encyclopedia:Attack}attack{/g} your opponents to the best of their ability.");
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.Actions = SpawnCalamity(c => {
                        c.m_Blueprint = DemonLordDeskari.ToReference<BlueprintUnitReference>();
                    });
                });
            });
            var SummonDemonNocticula = CreateSummonAbility("SummonDemonNocticula", bp => {
                bp.SetName("Overpowered Ability — Summon Calamity (Nocticula)");
                bp.SetDescription("This {g|Encyclopedia:Spell}spell{/g} summons Demon Lord Nocticula. Summoned monsters appear where you designate and act according to their "
                    + "{g|Encyclopedia:Initiative}initiative{/g} {g|Encyclopedia:Check}check{/g} results. They {g|Encyclopedia:Attack}attack{/g} your opponents to the best of their ability.");
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.Actions = SpawnCalamity(c => {
                        c.m_Blueprint = Nocticula.ToReference<BlueprintUnitReference>();
                    });
                });
            });
            var SummonDemonMephistopheles = CreateSummonAbility("SummonDemonMephistopheles", bp => {
                bp.SetName("Overpowered Ability — Summon Calamity (Mephistopheles)");
                bp.SetDescription("This {g|Encyclopedia:Spell}spell{/g} summons Archdevil Mephistopheles. Summoned monsters appear where you designate and act according to their "
                    + "{g|Encyclopedia:Initiative}initiative{/g} {g|Encyclopedia:Check}check{/g} results. They {g|Encyclopedia:Attack}attack{/g} your opponents to the best of their ability.");
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.Actions = SpawnCalamity(c => {
                        c.m_Blueprint = Mephistopheles.ToReference<BlueprintUnitReference>();
                    });
                });
            });
            var SummonCalamityFeature = Helpers.CreateFeature("SummonCalamityFeature", bp => {
                bp.SetName("Overpowered Ability — Summon Calamity");
                bp.SetDescription("As a full action, you summon a powerful being to bring calamity. You can summon one of the following: Devastator, Playful Darkness, "
                    + "Baphomet, Deskari, Nocticula, or Mephistopheles.");
                bp.m_Icon = Icon_SummonMonsterIX;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { SummonCalamityAbility.ToReference<BlueprintUnitFactReference>() };
                });
            });
            SummonCalamityAbility.AddComponent<AbilityVariants>(c => {
                c.m_Variants = new BlueprintAbilityReference[] {
                    SummonDevastator.ToReference<BlueprintAbilityReference>(),
                    SummonBaphomet.ToReference<BlueprintAbilityReference>(),
                    SummonDemonLordDeskari.ToReference<BlueprintAbilityReference>(),
                    SummonDemonNocticula.ToReference<BlueprintAbilityReference>(),
                    SummonDemonMephistopheles.ToReference<BlueprintAbilityReference>(),
                };
            });

            OverpoweredAbilitySelection.AddToSelection(SummonCalamityFeature);
        }
        private static BlueprintAbility CreateSummonAbility(string name, Action<BlueprintAbility> init = null)
        {
            var result = Helpers.CreateBlueprint<BlueprintAbility>(name, bp => {
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.Default;
                    c.m_BaseValueType = ContextRankBaseValueType.CharacterLevel;
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
                bp.CanTargetSelf = true;
                bp.Animation = UnitAnimationActionCastSpell.CastAnimationStyle.Omni;
                bp.ActionType = UnitCommand.CommandType.Standard;
                bp.AvailableMetamagic = Metamagic.Quicken;
                bp.m_IsFullRoundAction = true;
                bp.LocalizedDuration = Helpers.CreateString($"{bp.name}.Duration", "1 round/level");
                bp.LocalizedSavingThrow = new LocalizedString();
            });
            init?.Invoke(result);
            return result;
        }
        private static ActionList SpawnCalamity(Action<ContextActionSpawnMonster> init = null)
        {
            var t = new ContextActionSpawnMonster()
            {
                m_SummonPool = SummonMonsterPool.ToReference<BlueprintSummonPoolReference>(),
                DurationValue = RankDuration,
                CountValue = DiceValueOne,
                LevelValue = new ContextValue(),
                AfterSpawn = ActionFlow.DoSingle<ContextActionApplyBuff>(c => {
                    c.Permanent = true;
                    c.m_Buff = SummonedCreatureSpawnMonsterVI_IX.ToReference<BlueprintBuffReference>();
                    c.DurationValue = Constants.ZeroDuration;
                    c.IsNotDispelable = true;
                }),
            };
            init?.Invoke(t);
            return Helpers.CreateActionList(t);
        }
    }
}
