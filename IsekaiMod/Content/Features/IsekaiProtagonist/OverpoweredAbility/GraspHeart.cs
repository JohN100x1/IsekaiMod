using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Localization;
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
using Kingmaker.Visual.Animation.Kingmaker.Actions;
using UnityEngine;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.OverpoweredAbility
{
    class GraspHeart
    {
        // Checked facts
        private static readonly BlueprintFeature UndeadType = Resources.GetBlueprint<BlueprintFeature>("734a29b693e9ec346ba2951b27987e33");
        private static readonly BlueprintFeature ConstructType = Resources.GetBlueprint<BlueprintFeature>("fd389783027d63343b4a5634bd81645f");

        // Buff
        private static readonly BlueprintBuff Stunned = Resources.GetBlueprint<BlueprintBuff>("09d39b38bb7c6014394b6daced9bacd3");

        // Icon
        private static readonly Sprite Icon_DeathClutch = Resources.GetBlueprint<BlueprintAbility>("c3d2294a6740bc147870fff652f3ced5").m_Icon;
        public static void Add()
        {
            var GraspHeartAbility = Helpers.CreateBlueprint<BlueprintAbility>("GraspHeartAbility", bp => {
                bp.SetName("Overpowered Ability — Grasp Heart");
                bp.SetDescription("Kills the targeted creature if they fail a DC 99 fortitude saving throw, otherwise they are stunned for 1 round.");
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.Actions = ActionFlow.DoSingle<ContextActionSavingThrow>(c => {
                        c.Type = SavingThrowType.Fortitude;
                        c.m_ConditionalDCIncrease = new ContextActionSavingThrow.ConditionalDCIncrease[0];
                        c.HasCustomDC = false;
                        c.CustomDC = 0;
                        c.Actions = ActionFlow.DoSingle<ContextActionConditionalSaved>(c => {
                            c.Succeed = ActionFlow.DoSingle<ContextActionApplyBuff>(c => {
                                c.m_Buff = Stunned.ToReference<BlueprintBuffReference>();
                                c.DurationValue = Values.Duration.OneRound;
                            });
                            c.Failed = ActionFlow.DoSingle<ContextActionKill>();
                        });
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
                    c.DC = 99;
                });
                bp.m_Icon = Icon_DeathClutch;
                bp.Type = AbilityType.SpellLike;
                bp.Range = AbilityRange.Medium;
                bp.CanTargetEnemies = true;
                bp.CanTargetFriends = true;
                bp.CanTargetSelf = true;
                bp.SpellResistance = true;
                bp.EffectOnAlly = AbilityEffectOnUnit.Harmful;
                bp.EffectOnEnemy = AbilityEffectOnUnit.Harmful;
                bp.Animation = UnitAnimationActionCastSpell.CastAnimationStyle.Directional;
                bp.ActionType = UnitCommand.CommandType.Standard;
                bp.AvailableMetamagic = Metamagic.Reach | Metamagic.Quicken;
                bp.LocalizedDuration = new LocalizedString();
                bp.LocalizedSavingThrow = new LocalizedString();
            });
            var GraspHeartFeature = Helpers.CreateFeature("GraspHeartFeature", bp => {
                bp.SetName("Overpowered Ability — Grasp Heart");
                bp.SetDescription("You gain the Grasp Heart ability which can kill any creature if they fail a DC 99 fortitude saving throw, otherwise they are stunned for 1 round.");
                bp.m_Icon = Icon_DeathClutch;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { GraspHeartAbility.ToReference<BlueprintUnitFactReference>() };
                });
            });

            OverpoweredAbilitySelection.AddToSelection(GraspHeartFeature);
        }
    }
}
