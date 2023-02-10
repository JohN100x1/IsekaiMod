using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
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
using TabletopTweaks.Core.Utilities;
using UnityEngine;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.SpecialPower {

    internal class SummonBeast {

        // Units
        private static readonly BlueprintUnit CR7_HydraAdvanced = BlueprintTools.GetBlueprint<BlueprintUnit>("e135463f804adb541b402bae3f657af4");

        private static readonly BlueprintUnit CR9_OwlbearAdvanced = BlueprintTools.GetBlueprint<BlueprintUnit>("7d3bd11169778c845b2631d22d27d465");
        private static readonly BlueprintUnit CR9_RocStandard = BlueprintTools.GetBlueprint<BlueprintUnit>("12d33b211fa5b394fb214e202a2db300");
        private static readonly BlueprintUnit CR10_FiendishMinotaur_Guard = BlueprintTools.GetBlueprint<BlueprintUnit>("962427b9ddb354947ac92655dc637e0c");

        private static readonly BlueprintSummonPool SummonMonsterPool = BlueprintTools.GetBlueprint<BlueprintSummonPool>("d94c93e7240f10e41ae41db4c83d1cbe");
        private static readonly BlueprintBuff SummonedCreatureSpawnMonsterVI_IX = BlueprintTools.GetBlueprint<BlueprintBuff>("0dff842f06edace43baf8a2f44207045");
        private static readonly Sprite Icon_SummonMonsterVII = BlueprintTools.GetBlueprint<BlueprintAbility>("ab167fd8203c1314bac6568932f1752f").m_Icon;

        public static void Add() {
            var SummonBeastAbility = CreateSummonAbility("SummonBeastAbility", bp => {
                bp.SetName(IsekaiContext, "Summon Beast");
                bp.SetDescription(IsekaiContext, "This {g|Encyclopedia:Spell}spell{/g} summons a Hydra, an Owlbear, a Roc, or a Minotaur. "
                    + "Summoned monsters appear where you designate and act according to their {g|Encyclopedia:Initiative}initiative{/g} {g|Encyclopedia:Check}check{/g} results. "
                    + "They {g|Encyclopedia:Attack}attack{/g} your opponents to the best of their ability.");
            });
            var SummonHydra = CreateSummonAbility("SummonHydra", bp => {
                bp.SetName(IsekaiContext, "Summon Beast (Hydra)");
                bp.SetDescription(IsekaiContext, "This {g|Encyclopedia:Spell}spell{/g} summons a Hydra. Summoned monsters appear where you designate and act according to their "
                    + "{g|Encyclopedia:Initiative}initiative{/g} {g|Encyclopedia:Check}check{/g} results. They {g|Encyclopedia:Attack}attack{/g} your opponents to the best of their ability.");
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.Actions = SpawnBeast(c => {
                        c.m_Blueprint = CR7_HydraAdvanced.ToReference<BlueprintUnitReference>();
                    });
                });
            });
            var SummonOwlbear = CreateSummonAbility("SummonOwlbear", bp => {
                bp.SetName(IsekaiContext, "Summon Beast (Owlbear)");
                bp.SetDescription(IsekaiContext, "This {g|Encyclopedia:Spell}spell{/g} summons an Owlbear. Summoned monsters appear where you designate and act according to their "
                    + "{g|Encyclopedia:Initiative}initiative{/g} {g|Encyclopedia:Check}check{/g} results. They {g|Encyclopedia:Attack}attack{/g} your opponents to the best of their ability.");
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.Actions = SpawnBeast(c => {
                        c.m_Blueprint = CR9_OwlbearAdvanced.ToReference<BlueprintUnitReference>();
                    });
                });
            });
            var SummonRoc = CreateSummonAbility("SummonRoc", bp => {
                bp.SetName(IsekaiContext, "Summon Beast (Roc)");
                bp.SetDescription(IsekaiContext, "This {g|Encyclopedia:Spell}spell{/g} summons a Roc. Summoned monsters appear where you designate and act according to their "
                    + "{g|Encyclopedia:Initiative}initiative{/g} {g|Encyclopedia:Check}check{/g} results. They {g|Encyclopedia:Attack}attack{/g} your opponents to the best of their ability.");
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.Actions = SpawnBeast(c => {
                        c.m_Blueprint = CR9_RocStandard.ToReference<BlueprintUnitReference>();
                    });
                });
            });
            var SummonMinotaur = CreateSummonAbility("SummonMinotaur", bp => {
                bp.SetName(IsekaiContext, "Summon Beast (Minotaur)");
                bp.SetDescription(IsekaiContext, "This {g|Encyclopedia:Spell}spell{/g} summons a Minotaur. Summoned monsters appear where you designate and act according to their "
                    + "{g|Encyclopedia:Initiative}initiative{/g} {g|Encyclopedia:Check}check{/g} results. They {g|Encyclopedia:Attack}attack{/g} your opponents to the best of their ability.");
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.Actions = SpawnBeast(c => {
                        c.m_Blueprint = CR10_FiendishMinotaur_Guard.ToReference<BlueprintUnitReference>();
                    });
                });
            });
            var SummonBeastFeature = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "SummonBeastFeature", bp => {
                bp.SetName(IsekaiContext, "Summon Beast");
                bp.SetDescription(IsekaiContext, "As a full action, you summon a Hydra, an Owlbear, a Roc, or a Minotaur.");
                bp.m_Icon = Icon_SummonMonsterVII;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { SummonBeastAbility.ToReference<BlueprintUnitFactReference>() };
                });
            });
            SummonBeastAbility.AddComponent<AbilityVariants>(c => {
                c.m_Variants = new BlueprintAbilityReference[] {
                    SummonHydra.ToReference<BlueprintAbilityReference>(),
                    SummonOwlbear.ToReference<BlueprintAbilityReference>(),
                    SummonRoc.ToReference<BlueprintAbilityReference>(),
                    SummonMinotaur.ToReference<BlueprintAbilityReference>(),
                };
            });

            SpecialPowerSelection.AddToSelection(SummonBeastFeature);
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
                bp.m_Icon = Icon_SummonMonsterVII;
                bp.Type = AbilityType.Special;
                bp.Range = AbilityRange.Close;
                bp.CanTargetPoint = true;
                bp.CanTargetSelf = true;
                bp.Animation = UnitAnimationActionCastSpell.CastAnimationStyle.Omni;
                bp.ActionType = UnitCommand.CommandType.Standard;
                bp.AvailableMetamagic = Metamagic.Quicken;
                bp.m_IsFullRoundAction = true;
                bp.LocalizedDuration = Helpers.CreateString(IsekaiContext, $"{bp.name}.Duration", "1 round/level");
                bp.LocalizedSavingThrow = new LocalizedString();
            });
            init?.Invoke(result);
            return result;
        }

        private static ActionList SpawnBeast(Action<ContextActionSpawnMonster> init = null) {
            var t = new ContextActionSpawnMonster() {
                m_SummonPool = SummonMonsterPool.ToReference<BlueprintSummonPoolReference>(),
                DurationValue = new() {
                    Rate = DurationRate.Rounds,
                    DiceType = DiceType.Zero,
                    DiceCountValue = 0,
                    BonusValue = Values.CreateContextRankValue(AbilityRankType.Default),
                    m_IsExtendable = true
                },
                CountValue = new() {
                    DiceType = DiceType.Zero,
                    DiceCountValue = 0,
                    BonusValue = 1
                },
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