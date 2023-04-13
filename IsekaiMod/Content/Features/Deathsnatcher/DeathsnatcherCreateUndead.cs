using IsekaiMod.Content.Classes.Deathsnatcher;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Commands.Base;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.Visual.Animation.Kingmaker.Actions;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.Deathsnatcher {

    internal class DeathsnatcherCreateUndead {
        private static readonly BlueprintAbility CreateUndeadAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("76a11b460be25e44ca85904d6806e5a3");
        private static readonly BlueprintAbility CreateUndeadLivingArmor = BlueprintTools.GetBlueprint<BlueprintAbility>("43a1ea314c59c4a4eb2c193a1e17b805");
        private static readonly BlueprintAbility CreateUndeadGraveKnight = BlueprintTools.GetBlueprint<BlueprintAbility>("9b75cb3bd3108a24c81329a3734f2248");

        public static void Add() {
            var DeathsnatcherCreateUndeadResource = Helpers.CreateBlueprint<BlueprintAbilityResource>(IsekaiContext, "DeathsnatcherCreateUndeadResource", bp => {
                bp.m_MaxAmount = new BlueprintAbilityResource.Amount {
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
            var DeathsnatcherCreateUndeadAbility = Helpers.CreateBlueprint<BlueprintAbility>(IsekaiContext, "DeathsnatcherCreateUndeadAbility", bp => {
                bp.m_DisplayName = CreateUndeadAbility.m_DisplayName;
                bp.m_Description = CreateUndeadAbility.m_Description;
                bp.m_Icon = CreateUndeadAbility.m_Icon;
                bp.AddComponent<AbilityVariants>(c => {
                    c.m_Variants = new BlueprintAbilityReference[]
                    {
                        CreateUndeadLivingArmor.ToReference<BlueprintAbilityReference>(),
                        CreateUndeadGraveKnight.ToReference<BlueprintAbilityReference>(),
                    };
                });
                bp.AddComponent<SpellComponent>(c => {
                    c.School = SpellSchool.Necromancy;
                });
                bp.AddComponent<SpellDescriptorComponent>(c => {
                    c.Descriptor = SpellDescriptor.Evil;
                });
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.Default;
                    c.m_BaseValueType = ContextRankBaseValueType.ClassLevel;
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
                bp.CanTargetPoint = true;
                bp.CanTargetSelf = true;
                bp.Animation = UnitAnimationActionCastSpell.CastAnimationStyle.Point;
                bp.ActionType = UnitCommand.CommandType.Standard;
                bp.AvailableMetamagic = CreateUndeadAbility.AvailableMetamagic;
                bp.m_IsFullRoundAction = true;
                bp.LocalizedDuration = StaticReferences.Strings.Duration.OneRoundPerLevel;
                bp.LocalizedSavingThrow = StaticReferences.Strings.Null;
            });
            var DeathsnatcherCreateUndeadFeature = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "DeathsnatcherCreateUndeadFeature", bp => {
                bp.SetName(IsekaiContext, "Create Undead");
                bp.SetDescription(IsekaiContext, "At 13th level, the Deathsnatcher gains Create Undead as a spell-like ability once per day.");
                bp.m_Icon = CreateUndeadAbility.m_Icon;
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