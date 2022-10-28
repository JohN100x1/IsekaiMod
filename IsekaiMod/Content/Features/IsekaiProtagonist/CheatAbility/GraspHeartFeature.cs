using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.ResourceLinks;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Abilities.Components.Base;
using Kingmaker.UnitLogic.Abilities.Components.TargetCheckers;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Commands.Base;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.UnitLogic.Mechanics.Properties;
using Kingmaker.Visual.Animation.Kingmaker.Actions;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.CheatAbility
{
    class GraspHeartFeature
    {
        public static void Add()
        {
            // Checked facts
            var UndeadType = Resources.GetBlueprint<BlueprintFeature>("734a29b693e9ec346ba2951b27987e33");
            var ConstructType = Resources.GetBlueprint<BlueprintFeature>("fd389783027d63343b4a5634bd81645f");

            // Buffs
            var StunnedBuff = Resources.GetBlueprint<BlueprintBuff>("09d39b38bb7c6014394b6daced9bacd3");

            // Feature
            var Icon_DeathClutch = Resources.GetBlueprint<BlueprintAbility>("c3d2294a6740bc147870fff652f3ced5").m_Icon;
            var GraspHeartUnitProperty = Helpers.CreateBlueprint<BlueprintUnitProperty>("GraspHeartUnitProperty", bp => {
                bp.name = "GraspHeartUnitProperty";
                bp.AddComponent<SimplePropertyGetter>(c => {
                    c.Property = UnitProperty.Level;
                });
                bp.AddComponent<SimplePropertyGetter>(c => {
                    c.Property = UnitProperty.StatBonusCharisma;
                });
                bp.BaseValue = 10;
                bp.OperationOnComponents = BlueprintUnitProperty.MathOperation.Sum;
            });
            var GraspHeartAbility = Helpers.CreateBlueprint<BlueprintAbility>("GraspHeartAbility", bp => {
                bp.SetName("Cheat Ability — Grasp Heart");
                bp.SetDescription("Any creature that fails a Fortitude {g|Encyclopedia:Saving_Throw}saving throw{/g} is instantly killed, otherwise they are stunned for 1 round. "
                    + "The DC of the Fortitude save is 10 + your character level + your Charisma modifier.");
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.Actions = Helpers.CreateActionList(
                        new ContextActionSavingThrow()
                        {
                            Type = SavingThrowType.Fortitude,
                            Actions = Helpers.CreateActionList(
                                new ContextActionConditionalSaved()
                                {
                                    Succeed = Helpers.CreateActionList(
                                        new ContextActionApplyBuff()
                                        {
                                            Permanent = false,
                                            m_Buff = StunnedBuff.ToReference<BlueprintBuffReference>(),
                                            DurationValue = new ContextDurationValue()
                                            {
                                                Rate = DurationRate.Rounds,
                                                DiceType = DiceType.Zero,
                                                DiceCountValue = 0,
                                                BonusValue = new ContextValue()
                                                {
                                                    ValueType = ContextValueType.Simple,
                                                    Value = 1,
                                                    ValueRank = AbilityRankType.Default
                                                },
                                                m_IsExtendable = true
                                            },
                                            UseDurationSeconds = false,
                                            DurationSeconds = 0,
                                            IsFromSpell = false,
                                            ToCaster = false,
                                            AsChild = false,
                                        }),
                                    Failed = Helpers.CreateActionList(
                                        new ContextActionKill()
                                        {
                                            name = "$ContextActionKillTarget$b7b2090a-504e-493f-b66e-fd1d53e1c681"
                                        })
                                })
                        });
                });
                bp.AddComponent<SpellComponent>(c => {
                    c.School = SpellSchool.Necromancy;
                });
                bp.AddComponent<SpellDescriptorComponent>(c => {
                    c.Descriptor = SpellDescriptor.Evil | SpellDescriptor.Death;
                });
                bp.AddComponent<AbilitySpawnFx>(c => {
                    c.PrefabLink = new PrefabLink() { AssetId = "cc9120c1d1e64e1478b859f14a200404" };
                    c.Time = AbilitySpawnFxTime.OnApplyEffect;
                    c.Anchor = AbilitySpawnFxAnchor.SelectedTarget;
                });
                bp.AddComponent<AbilityTargetHasFact>(c => {
                    c.m_CheckedFacts = new BlueprintUnitFactReference[] {
                        UndeadType.ToReference<BlueprintUnitFactReference>(),
                        ConstructType.ToReference<BlueprintUnitFactReference>(),
                    };
                    c.Inverted = true;
                });
                bp.AddComponent<ContextSetAbilityParams>(c => {
                    c.DC = new ContextValue()
                    {
                        ValueType = ContextValueType.CasterCustomProperty,
                        m_CustomProperty = GraspHeartUnitProperty.ToReference<BlueprintUnitPropertyReference>()
                    };
                });
                bp.m_Icon = Icon_DeathClutch;
                bp.Type = AbilityType.SpellLike;
                bp.Range = AbilityRange.Medium;
                bp.CanTargetPoint = false;
                bp.CanTargetEnemies = true;
                bp.CanTargetFriends = true;
                bp.CanTargetSelf = true;
                bp.SpellResistance = true;
                bp.EffectOnAlly = AbilityEffectOnUnit.Harmful;
                bp.EffectOnEnemy = AbilityEffectOnUnit.Harmful;
                bp.Animation = UnitAnimationActionCastSpell.CastAnimationStyle.Directional;
                bp.ActionType = UnitCommand.CommandType.Standard;
                bp.AvailableMetamagic = Metamagic.Reach | Metamagic.Quicken;
                bp.m_TargetMapObjects = false;
                bp.LocalizedDuration = Helpers.CreateString($"{bp.name}.Duration", "");
                bp.LocalizedSavingThrow = Helpers.CreateString($"{bp.name}.SavingThrow", "Fortitude negates death");
            });
            var GraspHeartFeature = Helpers.CreateBlueprint<BlueprintFeature>("GraspHeartFeature", bp => {
                bp.SetName("Cheat Ability — Grasp Heart");
                bp.SetDescription("You gain the Grasp Heart ability which can kill any creature that fails a Fortitude {g|Encyclopedia:Saving_Throw}saving throw{/g}, "
                    + "otherwise they are stunned for 1 round. The DC of the Fortitude save is 10 + your character level + your Charisma modifier.");
                bp.m_Icon = Icon_DeathClutch;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { GraspHeartAbility.ToReference<BlueprintUnitFactReference>() };
                });
            });
        }
    }
}
