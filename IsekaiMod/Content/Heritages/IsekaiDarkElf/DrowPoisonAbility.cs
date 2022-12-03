using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.ResourceLinks;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Abilities.Components.Base;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Commands.Base;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.UnitLogic.Mechanics.Properties;
using Kingmaker.Visual.Animation.Kingmaker.Actions;

namespace IsekaiMod.Content.Heritages.IsekaiDarkElf
{
    internal class DrowPoisonAbility
    {
        private static readonly BlueprintBuff Unconsious = Resources.GetBlueprint<BlueprintBuff>("31a468926d0f3ab439b714f15d794a8b");
        public static void Add()
        {
            // Spriggan Heritage
            var Icon_DrowPoison = AssetLoader.LoadInternal("Features", "ICON_DROW_POISON.png");
            var DrowPoisonResource = Helpers.CreateBlueprint<BlueprintAbilityResource>("DrowPoisonResource", bp => {
                bp.m_MaxAmount = new BlueprintAbilityResource.Amount
                {
                    BaseValue = 0,
                    IncreasedByLevel = false,
                    LevelIncrease = 0,
                    IncreasedByLevelStartPlusDivStep = false,
                    StartingLevel = 0,
                    StartingIncrease = 0,
                    LevelStep = 0,
                    PerStepIncrease = 0,
                    MinClassLevelIncrease = 0,
                    OtherClassesModifier = 0,
                    IncreasedByStat = true,
                    ResourceBonusStat = StatType.Intelligence,
                };
            });
            var DrowPoisonUnitProperty = Helpers.CreateBlueprint<BlueprintUnitProperty>("DrowPoisonUnitProperty", bp => {
                bp.name = "DrowPoisonUnitProperty";
                bp.AddComponent<SimplePropertyGetter>(c => {
                    c.Property = UnitProperty.Level;
                });
                bp.AddComponent<SimplePropertyGetter>(c => {
                    c.Property = UnitProperty.StatBonusIntelligence;
                });
                bp.BaseValue = 10;
                bp.OperationOnComponents = BlueprintUnitProperty.MathOperation.Sum;
            });
            var DrowPoisonBuff = Helpers.CreateBuff("DrowPoisonBuff", bp => {
                bp.SetName("Drow Poison");
                bp.SetDescription("Drow Poison causes their target to become unconsious on a failed fortitude save.");
                bp.m_Icon = Icon_DrowPoison;
                bp.IsClassFeature = true;
                bp.Stacking = StackingType.Replace;
                bp.m_Flags = BlueprintBuff.Flags.StayOnDeath;
                bp.AddComponent<AddInitiatorAttackWithWeaponTrigger>(c => {
                    c.WaitForAttackResolve = true;
                    c.OnlyHit = true;
                    c.Action = Helpers.CreateActionList(
                        new ContextActionSavingThrow()
                        {
                            Type = SavingThrowType.Fortitude,
                            m_ConditionalDCIncrease = new ContextActionSavingThrow.ConditionalDCIncrease[0],
                            HasCustomDC = true,
                            CustomDC = new ContextValue()
                            {
                                ValueType = ContextValueType.CasterCustomProperty,
                                m_CustomProperty = DrowPoisonUnitProperty.ToReference<BlueprintUnitPropertyReference>()
                            },
                            FromBuff = false,
                            Actions = ActionFlow.DoSingle<ContextActionConditionalSaved>(c => {
                                c.Succeed = ActionFlow.DoNothing();
                                c.Failed = ActionFlow.DoSingle<ContextActionApplyBuff>(c => {
                                    c.m_Buff = Unconsious.ToReference<BlueprintBuffReference>();
                                    c.DurationValue = new ContextDurationValue()
                                    {
                                        Rate = DurationRate.Minutes,
                                        m_IsExtendable = true,
                                        DiceType = DiceType.Zero,
                                        DiceCountValue = 0,
                                        BonusValue = 1,
                                    };
                                });
                            })
                        },
                        new ContextActionRemoveSelf()
                        );
                });
                bp.AddComponent<ContextSetAbilityParams>(c => {
                    c.DC = new ContextValue()
                    {
                        ValueType = ContextValueType.CasterCustomProperty,
                        m_CustomProperty = DrowPoisonUnitProperty.ToReference<BlueprintUnitPropertyReference>()
                    };
                });
            });
            var DrowPoisonAbility = Helpers.CreateBlueprint<BlueprintAbility>("DrowPoisonAbility", bp => {
                bp.SetName("Drow Poison");
                bp.SetDescription("As a swift action, you can coat your weapon with a special drow poison. Enemies hit by the poisoned weapon will need to make a Fortitude save "
                    + "or become unconscious for 1 minute. This fortitude save is equal to 10 + your character level + your Intelligence modifier.");
                bp.m_Icon = Icon_DrowPoison;
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.SavingThrowType = SavingThrowType.Fortitude;
                    c.Actions = ActionFlow.DoSingle<ContextActionApplyBuff>(c => {
                        c.m_Buff = DrowPoisonBuff.ToReference<BlueprintBuffReference>();
                        c.Permanent = true;
                        c.DurationValue = Constants.ZeroDuration;
                    });
                });
                bp.AddComponent<AbilitySpawnFx>(c => {
                    c.PrefabLink = new PrefabLink() { AssetId = "8de64fbe047abc243a9b4715f643739f" };
                    c.Time = AbilitySpawnFxTime.OnApplyEffect;
                    c.Anchor = AbilitySpawnFxAnchor.Caster;
                });
                bp.AddComponent<ContextSetAbilityParams>(c => {
                    c.DC = new ContextValue()
                    {
                        ValueType = ContextValueType.CasterCustomProperty,
                        m_CustomProperty = DrowPoisonUnitProperty.ToReference<BlueprintUnitPropertyReference>()
                    };
                });
                bp.AddComponent<AbilityResourceLogic>(c => {
                    c.m_RequiredResource = DrowPoisonResource.ToReference<BlueprintAbilityResourceReference>();
                    c.m_IsSpendResource = true;
                });
                bp.Type = AbilityType.Special;
                bp.Range = AbilityRange.Personal;
                bp.CanTargetSelf = true;
                bp.Animation = UnitAnimationActionCastSpell.CastAnimationStyle.EnchantWeapon;
                bp.ActionType = UnitCommand.CommandType.Swift;
                bp.AvailableMetamagic = Metamagic.Heighten;
                bp.LocalizedDuration = Helpers.CreateString($"{bp.name}.Duration", "1 minute");
                bp.LocalizedSavingThrow = Helpers.CreateString($"{bp.name}.SavingThrow", "Fortitude negates");
            });
        }
    }
}
