using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.ElementsSystem;
using Kingmaker.Enums;
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
using TabletopTweaks.Core.Utilities;
using UnityEngine;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.OverpoweredAbility {

    internal class SummonCalamity {
        private static readonly BlueprintUnit Devastator = BlueprintTools.GetBlueprint<BlueprintUnit>("99c16c4360534129b45706841a7df3fe");
        private static readonly BlueprintUnit PlayfulDarkness = BlueprintTools.GetBlueprint<BlueprintUnit>("a1b06220efb4f0545a870ce52fadd678");
        private static readonly BlueprintUnit Baphomet = BlueprintTools.GetBlueprint<BlueprintUnit>("f8007503fe211da4eb027e070eeb3f8c");
        private static readonly BlueprintUnit DemonLordDeskari = BlueprintTools.GetBlueprint<BlueprintUnit>("5a75db49bf7aeaf4c9f0264cac3eed5c");
        private static readonly BlueprintUnit Nocticula = BlueprintTools.GetBlueprint<BlueprintUnit>("0cca8c841d634d84fbec2609c8db3465");
        private static readonly BlueprintUnit Mephistopheles = BlueprintTools.GetBlueprint<BlueprintUnit>("c3dfbb136aa27e74eb7a7b5159395a80");
        private static readonly BlueprintUnit Areshkagal = BlueprintTools.GetBlueprint<BlueprintUnit>("7a1b0862dd2443b49adaba36b194e5de");

        private static readonly BlueprintSummonPool SummonMonsterPool = BlueprintTools.GetBlueprint<BlueprintSummonPool>("d94c93e7240f10e41ae41db4c83d1cbe");
        private static readonly BlueprintBuff SummonedCreatureSpawnMonsterVI_IX = BlueprintTools.GetBlueprint<BlueprintBuff>("0dff842f06edace43baf8a2f44207045");
        private static readonly Sprite Icon_SummonMonsterIX = BlueprintTools.GetBlueprint<BlueprintAbility>("52b5df2a97df18242aec67610616ded0").m_Icon;

        public static void Add() {
            var SummonCalamityAbility = CreateSummonAbility("SummonCalamityAbility", bp => {
                bp.SetName(IsekaiContext, "Overpowered Ability — Summon Calamity");
                bp.SetSummonDescription(IsekaiContext, "This {g|Encyclopedia:Spell}spell{/g} summons a Devastator, Playful Darkness, "
                    + "Baphomet, Deskari, Nocticula, Mephistopheles, or Areshkagal.");
            });
            var SummonDevastator = CreateSummonAbility("SummonDevastator", bp => {
                bp.SetName(IsekaiContext, "Overpowered Ability — Summon Calamity (Devastator)");
                bp.SetSummonDescription(IsekaiContext, "This {g|Encyclopedia:Spell}spell{/g} summons a Devastator.");
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.Actions = SpawnCalamity(c => {
                        c.m_Blueprint = Devastator.ToReference<BlueprintUnitReference>();
                    });
                });
            });
            var SummonPlayfulDarkness = CreateSummonAbility("SummonPlayfulDarkness", bp => {
                bp.SetName(IsekaiContext, "Overpowered Ability — Summon Calamity (Playful Darkness)");
                bp.SetSummonDescription(IsekaiContext, "This {g|Encyclopedia:Spell}spell{/g} summons Playful Darkness.");
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.Actions = SpawnCalamity(c => {
                        c.m_Blueprint = PlayfulDarkness.ToReference<BlueprintUnitReference>();
                    });
                });
            });
            var SummonBaphomet = CreateSummonAbility("SummonBaphomet", bp => {
                bp.SetName(IsekaiContext, "Overpowered Ability — Summon Calamity (Baphomet)");
                bp.SetSummonDescription(IsekaiContext, "This {g|Encyclopedia:Spell}spell{/g} summons Demon Lord Baphomet.");
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.Actions = SpawnCalamity(c => {
                        c.m_Blueprint = Baphomet.ToReference<BlueprintUnitReference>();
                    });
                });
            });
            var SummonDemonLordDeskari = CreateSummonAbility("SummonDemonLordDeskari", bp => {
                bp.SetName(IsekaiContext, "Overpowered Ability — Summon Calamity (Deskari)");
                bp.SetSummonDescription(IsekaiContext, "This {g|Encyclopedia:Spell}spell{/g} summons Demon Lord Deskari.");
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.Actions = SpawnCalamity(c => {
                        c.m_Blueprint = DemonLordDeskari.ToReference<BlueprintUnitReference>();
                    });
                });
            });
            var SummonDemonNocticula = CreateSummonAbility("SummonDemonNocticula", bp => {
                bp.SetName(IsekaiContext, "Overpowered Ability — Summon Calamity (Nocticula)");
                bp.SetSummonDescription(IsekaiContext, "This {g|Encyclopedia:Spell}spell{/g} summons Demon Lord Nocticula.");
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.Actions = SpawnCalamity(c => {
                        c.m_Blueprint = Nocticula.ToReference<BlueprintUnitReference>();
                    });
                });
            });
            var SummonDemonMephistopheles = CreateSummonAbility("SummonDemonMephistopheles", bp => {
                bp.SetName(IsekaiContext, "Overpowered Ability — Summon Calamity (Mephistopheles)");
                bp.SetSummonDescription(IsekaiContext, "This {g|Encyclopedia:Spell}spell{/g} summons Archdevil Mephistopheles.");
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.Actions = SpawnCalamity(c => {
                        c.m_Blueprint = Mephistopheles.ToReference<BlueprintUnitReference>();
                    });
                });
            });
            var SummonAreshkagal = CreateSummonAbility("SummonAreshkagal", bp => {
                bp.SetName(IsekaiContext, "Overpowered Ability — Summon Calamity (Areshkagal)");
                bp.SetSummonDescription(IsekaiContext, "This {g|Encyclopedia:Spell}spell{/g} summons Areshkagal.");
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.Actions = SpawnCalamity(c => {
                        c.m_Blueprint = Areshkagal.ToReference<BlueprintUnitReference>();
                    });
                });
            });
            var SummonCalamityFeature = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "SummonCalamityFeature", bp => {
                bp.SetName(IsekaiContext, "Overpowered Ability — Summon Calamity");
                bp.SetDescription(IsekaiContext, "There is nothing you cannot summon. Your calls are heeded; your commands are absolute. "
                    + "Even demon lords show no negligence... and tremblingly obey."
                    + "\nBenefit: As a full action, you summon a powerful being to bring calamity. "
                    + "You can summon one of the following: Devastator, Playful Darkness, Baphomet, Deskari, Nocticula, Mephistopheles, or Areshkagal.");
                bp.m_Icon = Icon_SummonMonsterIX;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { SummonCalamityAbility.ToReference<BlueprintUnitFactReference>() };
                });
            });
            SummonCalamityAbility.AddComponent<AbilityVariants>(c => {
                c.m_Variants = new BlueprintAbilityReference[] {
                    SummonDevastator.ToReference<BlueprintAbilityReference>(),
                    SummonPlayfulDarkness.ToReference<BlueprintAbilityReference>(),
                    SummonBaphomet.ToReference<BlueprintAbilityReference>(),
                    SummonDemonLordDeskari.ToReference<BlueprintAbilityReference>(),
                    SummonDemonNocticula.ToReference<BlueprintAbilityReference>(),
                    SummonDemonMephistopheles.ToReference<BlueprintAbilityReference>(),
                    SummonAreshkagal.ToReference<BlueprintAbilityReference>(),
                };
            });

            OverpoweredAbilitySelection.AddToNonAutoSelection(SummonCalamityFeature);
        }

        private static BlueprintAbility CreateSummonAbility(string name, Action<BlueprintAbility> init = null) {
            var result = Helpers.CreateBlueprint<BlueprintAbility>(IsekaiContext, name, bp => {
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
                bp.LocalizedDuration = StaticReferences.Strings.Duration.OneRoundPerLevel;
                bp.LocalizedSavingThrow = StaticReferences.Strings.Null;
            });
            init?.Invoke(result);
            return result;
        }

        private static ActionList SpawnCalamity(Action<ContextActionSpawnMonster> init = null) {
            var t = new ContextActionSpawnMonster() {
                m_SummonPool = SummonMonsterPool.ToReference<BlueprintSummonPoolReference>(),
                DurationValue = new() {
                    Rate = DurationRate.Rounds,
                    DiceType = DiceType.Zero,
                    DiceCountValue = 0,
                    BonusValue = Values.CreateContextRankValue(AbilityRankType.Default),
                    m_IsExtendable = true
                },
                CountValue = Values.Dice.One,
                LevelValue = 0,
                AfterSpawn = ActionFlow.DoSingle<ContextActionApplyBuff>(c => {
                    c.Permanent = true;
                    c.m_Buff = SummonedCreatureSpawnMonsterVI_IX.ToReference<BlueprintBuffReference>();
                    c.DurationValue = Values.Duration.Zero;
                    c.IsNotDispelable = true;
                }),
            };
            init?.Invoke(t);
            return Helpers.CreateActionList(t);
        }
    }
}