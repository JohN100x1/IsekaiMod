using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.ResourceLinks;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components.AreaEffects;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Buffs.Components;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.UnitLogic.Mechanics.Conditions;
using Kingmaker.Utility;
using TabletopTweaks.Core.Utilities;
using UnityEngine;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.GodEmperor {

    internal class BarrierSelection {

        private static readonly Sprite Icon_GoldBarrier = AssetLoader.LoadInternal(IsekaiContext, "Features", "ICON_AURA_BARRIER_GOLD.png");
        private static readonly Sprite Icon_VoidBarrier = AssetLoader.LoadInternal(IsekaiContext, "Features", "ICON_AURA_BARRIER_VOID.png");

        private static readonly BlueprintBuff HeroismGreaterBuff = BlueprintTools.GetBlueprint<BlueprintBuff>("b8da3ec045ec04845a126948e1f4fc1a");

        public static void Add() {

            // Extra effects for Hero progression
            var GoldBarrierHeroism = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "GoldBarrierHeroism", bp => {
                bp.SetName(IsekaiContext, "Greater Gold Barrier");
                bp.SetDescription(IsekaiContext, "At 10th level, Gold Barrier now also grants Greater Heroism to your allies.");
                bp.m_Icon = Icon_GoldBarrier;
            });
            var GoldBarrierFastHealing = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "GoldBarrierFastHealing", bp => {
                bp.SetName(IsekaiContext, "Grand Gold Barrier");
                bp.SetDescription(IsekaiContext, "At 12th level, Gold Barrier now also grants fast healing equal to your character level.");
                bp.m_Icon = Icon_GoldBarrier;
            });
            var GoldBarrierFastHealingBuff = TTCoreExtensions.CreateBuff("GoldBarrierFastHealingBuff", bp => {
                bp.SetName(IsekaiContext, "Grand Gold Barrier");
                bp.SetDescription(IsekaiContext, "This character has fast healing equal to your character level.");
                bp.m_Icon = Icon_GoldBarrier;
                bp.AddComponent<AddEffectFastHealing>(c => {
                    c.Heal = 0;
                    c.Bonus = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                });
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.StatBonus;
                    c.m_BaseValueType = ContextRankBaseValueType.CharacterLevel;
                });
            });

            const string GoldBarrierName = "Gold Barrier";
            const string GoldBarrierDescription = "Allies within 40 feet of you gain a sacred bonus to AC and saving throws equal to 1/2 your character level.";
            const string GoldBarrierDescriptionBuff = "This character has a sacred bonus to AC and saving throws equal to 1/2 your character level.";
            var GoldBarrierBuff = TTCoreExtensions.CreateBuff("GoldBarrierBuff", bp => {
                bp.SetName(IsekaiContext, GoldBarrierName);
                bp.SetDescription(IsekaiContext, GoldBarrierDescriptionBuff);
                bp.IsClassFeature = true;
                bp.m_Icon = Icon_GoldBarrier;
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Sacred;
                    c.Stat = StatType.AC;
                    c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                });
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Sacred;
                    c.Stat = StatType.SaveFortitude;
                    c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                });
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Sacred;
                    c.Stat = StatType.SaveReflex;
                    c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                });
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Sacred;
                    c.Stat = StatType.SaveWill;
                    c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                });
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.StatBonus;
                    c.m_BaseValueType = ContextRankBaseValueType.CharacterLevel;
                    c.m_Progression = ContextRankProgression.Div2;
                });
            });
            var GoldBarrierArea = Helpers.CreateBlueprint<BlueprintAbilityAreaEffect>(IsekaiContext, "GoldBarrierArea", bp => {
                bp.m_TargetType = BlueprintAbilityAreaEffect.TargetType.Ally;
                bp.Shape = AreaEffectShape.Cylinder;
                bp.Size = new Feet(40);
                bp.Fx = new PrefabLink();
                bp.AddComponent<AbilityAreaEffectRunAction>(c => {
                    c.UnitEnter = Helpers.CreateActionList(
                        new ContextActionApplyBuff {
                            m_Buff = GoldBarrierBuff.ToReference<BlueprintBuffReference>(),
                            Permanent = true,
                            DurationValue = Values.Duration.Zero,
                        },
                        new Conditional {
                            ConditionsChecker = ActionFlow.IfSingle<ContextConditionCasterHasFact>(c => {
                                c.m_Fact = GoldBarrierFastHealing.ToReference<BlueprintUnitFactReference>();
                                c.Not = false;
                            }),
                            IfTrue = ActionFlow.DoSingle<ContextActionApplyBuff>(c => {
                                c.m_Buff = GoldBarrierFastHealingBuff.ToReference<BlueprintBuffReference>();
                                c.Permanent = true;
                                c.DurationValue = Values.Duration.Zero;
                            }),
                            IfFalse = ActionFlow.DoNothing()
                        },
                        new Conditional {
                            ConditionsChecker = ActionFlow.IfSingle<ContextConditionCasterHasFact>(c => {
                                c.m_Fact = GoldBarrierHeroism.ToReference<BlueprintUnitFactReference>();
                                c.Not = false;
                            }),
                            IfTrue = ActionFlow.DoSingle<ContextActionApplyBuff>(c => {
                                c.m_Buff = HeroismGreaterBuff.ToReference<BlueprintBuffReference>();
                                c.Permanent = true;
                                c.DurationValue = Values.Duration.Zero;
                            }),
                            IfFalse = ActionFlow.DoNothing()
                        }
                        );
                    c.UnitExit = Helpers.CreateActionList(
                        new ContextActionRemoveBuff {
                            m_Buff = GoldBarrierBuff.ToReference<BlueprintBuffReference>(),
                            RemoveRank = false,
                            ToCaster = false,
                            OnlyFromCaster = true
                        },
                        new ContextActionRemoveBuff {
                            m_Buff = GoldBarrierFastHealingBuff.ToReference<BlueprintBuffReference>(),
                            RemoveRank = false,
                            ToCaster = false,
                            OnlyFromCaster = true
                        },
                        new ContextActionRemoveBuff {
                            m_Buff = HeroismGreaterBuff.ToReference<BlueprintBuffReference>(),
                            RemoveRank = false,
                            ToCaster = false,
                            OnlyFromCaster = true
                        }
                        );
                    c.UnitMove = ActionFlow.DoNothing();
                    c.Round = ActionFlow.DoNothing();
                });
            });
            var GoldBarrierAreaBuff = TTCoreExtensions.CreateBuff("GoldBarrierAreaBuff", bp => {
                bp.SetName(IsekaiContext, GoldBarrierName);
                bp.SetDescription(IsekaiContext, GoldBarrierDescription);
                bp.m_Icon = Icon_GoldBarrier;
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.HiddenInUi;
                bp.AddComponent<AddAreaEffect>(c => {
                    c.m_AreaEffect = GoldBarrierArea.ToReference<BlueprintAbilityAreaEffectReference>();
                });
            });
            var GoldBarrierAbility = TTCoreExtensions.CreateActivatableAbility("GoldBarrierAbility", bp => {
                bp.SetName(IsekaiContext, GoldBarrierName);
                bp.SetDescription(IsekaiContext, GoldBarrierDescription);
                bp.m_Icon = Icon_GoldBarrier;
                bp.m_Buff = GoldBarrierAreaBuff.ToReference<BlueprintBuffReference>();
                bp.DoNotTurnOffOnRest = true;
            });
            var GoldBarrierFeature = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "GoldBarrierFeature", bp => {
                bp.SetName(IsekaiContext, GoldBarrierName);
                bp.SetDescription(IsekaiContext, GoldBarrierDescription);
                bp.m_Icon = Icon_GoldBarrier;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { GoldBarrierAbility.ToReference<BlueprintUnitFactReference>() };
                });
            });

            const string VoidBarrierName = "Void Barrier";
            const string VoidBarrierDescription = "Allies within 40 feet of you gain a profane bonus to AC and saving throws equal to 1/2 your character level.";
            const string VoidBarrierDescriptionBuff = "This character has a profane bonus to AC and saving throws equal to 1/2 your character level.";
            var VoidBarrierBuff = TTCoreExtensions.CreateBuff("VoidBarrierBuff", bp => {
                bp.SetName(IsekaiContext, VoidBarrierName);
                bp.SetDescription(IsekaiContext, VoidBarrierDescriptionBuff);
                bp.IsClassFeature = true;
                bp.m_Icon = Icon_VoidBarrier;
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Profane;
                    c.Stat = StatType.AC;
                    c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                });
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Profane;
                    c.Stat = StatType.SaveFortitude;
                    c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                });
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Profane;
                    c.Stat = StatType.SaveReflex;
                    c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                });
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Profane;
                    c.Stat = StatType.SaveWill;
                    c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                });
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.StatBonus;
                    c.m_BaseValueType = ContextRankBaseValueType.CharacterLevel;
                    c.m_Progression = ContextRankProgression.Div2;
                });
            });
            var VoidBarrierArea = Helpers.CreateBlueprint<BlueprintAbilityAreaEffect>(IsekaiContext, "VoidBarrierArea", bp => {
                bp.m_TargetType = BlueprintAbilityAreaEffect.TargetType.Ally;
                bp.Shape = AreaEffectShape.Cylinder;
                bp.Size = new Feet(40);
                bp.Fx = new PrefabLink();
                bp.AddComponent(AuraUtils.CreateUnconditionalAuraEffect(VoidBarrierBuff.ToReference<BlueprintBuffReference>()));
            });
            var VoidBarrierAreaBuff = TTCoreExtensions.CreateBuff("VoidBarrierAreaBuff", bp => {
                bp.SetName(IsekaiContext, VoidBarrierName);
                bp.SetDescription(IsekaiContext, VoidBarrierDescription);
                bp.m_Icon = Icon_VoidBarrier;
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.HiddenInUi;
                bp.AddComponent<AddAreaEffect>(c => {
                    c.m_AreaEffect = VoidBarrierArea.ToReference<BlueprintAbilityAreaEffectReference>();
                });
            });
            var VoidBarrierAbility = TTCoreExtensions.CreateActivatableAbility("VoidBarrierAbility", bp => {
                bp.SetName(IsekaiContext, VoidBarrierName);
                bp.SetDescription(IsekaiContext, VoidBarrierDescription);
                bp.m_Icon = Icon_VoidBarrier;
                bp.m_Buff = VoidBarrierAreaBuff.ToReference<BlueprintBuffReference>();
                bp.DoNotTurnOffOnRest = true;
            });
            var VoidBarrierFeature = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "VoidBarrierFeature", bp => {
                bp.SetName(IsekaiContext, VoidBarrierName);
                bp.SetDescription(IsekaiContext, VoidBarrierDescription);
                bp.m_Icon = Icon_VoidBarrier;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { VoidBarrierAbility.ToReference<BlueprintUnitFactReference>() };
                });
            });

            var BarrierSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "BarrierSelection", bp => {
                bp.SetName(IsekaiContext, "Energy Barrier");
                bp.SetDescription(IsekaiContext, "At 7th level, you are able to channel your energy to form a solid barrier to shield allies "
                    + "from physical and magical attacks.");
                bp.m_Icon = Icon_GoldBarrier;
                bp.IgnorePrerequisites = true;
                bp.m_AllFeatures = new BlueprintFeatureReference[] {
                    GoldBarrierFeature.ToReference<BlueprintFeatureReference>(),
                    VoidBarrierFeature.ToReference<BlueprintFeatureReference>(),
                };
            });
        }
    }
}