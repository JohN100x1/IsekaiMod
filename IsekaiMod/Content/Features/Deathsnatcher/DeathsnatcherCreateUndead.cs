using IsekaiMod.Content.Classes.Deathsnatcher;
using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Commands.Base;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.Visual.Animation.Kingmaker.Actions;
using UnityEngine;

namespace IsekaiMod.Content.Features.Deathsnatcher
{
    class DeathsnatcherCreateUndead
    {
        private static readonly Sprite Icon_CreateUndead = Resources.GetBlueprint<BlueprintAbility>("76a11b460be25e44ca85904d6806e5a3").m_Icon;

        private static readonly BlueprintAbility CreateUndeadLivingArmor = Resources.GetBlueprint<BlueprintAbility>("43a1ea314c59c4a4eb2c193a1e17b805");
        private static readonly BlueprintAbility CreateUndeadGraveKnight = Resources.GetBlueprint<BlueprintAbility>("9b75cb3bd3108a24c81329a3734f2248");

        public static void Add()
        {
            var DeathsnatcherCreateUndeadResource = Helpers.CreateBlueprint<BlueprintAbilityResource>("DeathsnatcherCreateUndeadResource", bp => {
                bp.m_MaxAmount = new BlueprintAbilityResource.Amount
                {
                    BaseValue = 1,
                    IncreasedByLevel = false,
                    LevelIncrease = 1,
                    IncreasedByLevelStartPlusDivStep = false,
                    StartingLevel = 0,
                    StartingIncrease = 0,
                    LevelStep = 0,
                    PerStepIncrease = 0,
                    MinClassLevelIncrease = 0,
                    OtherClassesModifier = 0,
                    IncreasedByStat = false,
                    ResourceBonusStat = StatType.Unknown,
                };
            });
            var DeathsnatcherCreateUndeadAbility = Helpers.CreateBlueprint<BlueprintAbility>("DeathsnatcherCreateUndeadAbility", bp => {
                bp.SetName("Create Undead");
                bp.SetDescription("This {g|Encyclopedia:Spell}spell{/g} summons a graveknight or a guardian armor. It appears where you designate and acts according to its "
                    + "{g|Encyclopedia:Initiative}initiative{/g} {g|Encyclopedia:Check}check{/g} results. It {g|Encyclopedia:Attack}attacks{/g} your opponents to the best of its ability.");
                bp.m_Icon = Icon_CreateUndead;
                bp.AddComponent<AbilityVariants>(c => {
                    c.m_Variants = new BlueprintAbilityReference[]
                    {
                        CreateUndeadLivingArmor.ToReference<BlueprintAbilityReference>(),
                        CreateUndeadGraveKnight.ToReference<BlueprintAbilityReference>(),
                    };
                });
                bp.AddComponent<SpellComponent>(c => {
                    c.m_Flags = 0;
                    c.School = SpellSchool.Necromancy;
                });
                bp.AddComponent<SpellDescriptorComponent>(c => {
                    c.Descriptor = SpellDescriptor.Evil;
                });
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.Default;
                    c.m_BaseValueType = ContextRankBaseValueType.ClassLevel;
                    c.m_Stat = StatType.Unknown;
                    c.m_SpecificModifier = ModifierDescriptor.None;
                    c.m_Progression = ContextRankProgression.BonusValue;
                    c.m_StepLevel = 1;
                    c.m_Class = new BlueprintCharacterClassReference[] { DeathsnatcherClass.GetReference() };
                });
                bp.AddComponent<AbilityResourceLogic>(c => {
                    c.m_RequiredResource = DeathsnatcherCreateUndeadResource.ToReference<BlueprintAbilityResourceReference>();
                    c.m_IsSpendResource = true;
                });
                bp.Type = AbilityType.SpellLike;
                bp.Range = AbilityRange.Close;
                bp.m_AllowNonContextActions = false;
                bp.CanTargetPoint = true;
                bp.CanTargetEnemies = false;
                bp.CanTargetFriends = false;
                bp.CanTargetSelf = true;
                bp.SpellResistance = false;
                bp.EffectOnEnemy = AbilityEffectOnUnit.None;
                bp.EffectOnAlly = AbilityEffectOnUnit.None;
                bp.Animation = UnitAnimationActionCastSpell.CastAnimationStyle.Point;
                bp.ActionType = UnitCommand.CommandType.Standard;
                bp.AvailableMetamagic = Metamagic.Reach | Metamagic.Quicken | Metamagic.Extend | Metamagic.CompletelyNormal;
                bp.m_TargetMapObjects = false;
                bp.m_IsFullRoundAction = true;
                bp.LocalizedDuration = Helpers.CreateString($"{bp.name}.Duration", "1 round/level");
                bp.LocalizedSavingThrow = Helpers.CreateString($"{bp.name}.SavingThrow", "");
            });
            var DeathsnatcherCreateUndeadFeature = Helpers.CreateBlueprint<BlueprintFeature>("DeathsnatcherCreateUndeadFeature", bp => {
                bp.SetName("Create Undead");
                bp.SetDescription("At 14th level, the Deathsnatcher gains Create Undead as a spell-like ability once per day.");
                bp.m_Icon = Icon_CreateUndead;
                bp.IsClassFeature = true;
                bp.AddComponent<AddAbilityResources>(c => {
                    c.m_Resource = DeathsnatcherCreateUndeadResource.ToReference<BlueprintAbilityResourceReference>();
                    c.RestoreAmount = true;
                });
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { DeathsnatcherCreateUndeadAbility.ToReference<BlueprintUnitFactReference>() };
                });
            });
        }
    }
}
