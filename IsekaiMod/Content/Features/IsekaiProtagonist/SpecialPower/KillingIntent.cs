using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Localization;
using Kingmaker.ResourceLinks;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components.AreaEffects;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Buffs.Components;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.Utility;
using TabletopTweaks.Core.Utilities;
using UnityEngine;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.SpecialPower {

    internal class KillingIntent {
        private static readonly Sprite Icon_ConsumeFear = BlueprintTools.GetBlueprint<BlueprintAbility>("644d2c0d029e54d4188bc34216d9d8c0").m_Icon;
        private static readonly BlueprintBuff Shaken = BlueprintTools.GetBlueprint<BlueprintBuff>("25ec6cb6ab1845c48a95f9c20b034220");
        private static readonly BlueprintBuff Frightened = BlueprintTools.GetBlueprint<BlueprintBuff>("f08a7239aa961f34c8301518e71d4cdf");
        private static readonly BlueprintBuff Cowering = BlueprintTools.GetBlueprint<BlueprintBuff>("6062e3a8206a4284d867cbb7120dc091");

        public static void Add() {
            const string KillingIntentName = "Killing Intent";
            LocalizedString KingmakerIntentDesc = Helpers.CreateString(IsekaiContext, "KillingIntent.Description",
                "Enemies within 40 feet of you become shaken, frightened, and cowering.");

            var KillingIntentArea = Helpers.CreateBlueprint<BlueprintAbilityAreaEffect>(IsekaiContext, "KillingIntentArea", bp => {
                bp.m_TargetType = BlueprintAbilityAreaEffect.TargetType.Enemy;
                bp.Shape = AreaEffectShape.Cylinder;
                bp.Size = new Feet(40);
                bp.AffectEnemies = true;
                bp.Fx = new PrefabLink();
                bp.AddComponent<AbilityAreaEffectRunAction>(c => {
                    c.UnitEnter = Helpers.CreateActionList(
                        new ContextActionApplyBuff() {
                            m_Buff = Shaken.ToReference<BlueprintBuffReference>(),
                            DurationValue = new() {
                                Rate = DurationRate.Rounds,
                                DiceType = DiceType.D4,
                                DiceCountValue = 1,
                                BonusValue = 0,
                                m_IsExtendable = true,
                            }
                        },
                        new ContextActionApplyBuff() {
                            m_Buff = Frightened.ToReference<BlueprintBuffReference>(),
                            DurationValue = new() {
                                Rate = DurationRate.Rounds,
                                DiceType = DiceType.D4,
                                DiceCountValue = 1,
                                BonusValue = 0,
                                m_IsExtendable = true,
                            }
                        },
                        new ContextActionApplyBuff() {
                            m_Buff = Cowering.ToReference<BlueprintBuffReference>(),
                            DurationValue = new() {
                                Rate = DurationRate.Rounds,
                                DiceType = DiceType.D4,
                                DiceCountValue = 1,
                                BonusValue = 0,
                                m_IsExtendable = true,
                            }
                        });
                    c.UnitExit = Helpers.CreateActionList(
                        new ContextActionRemoveBuff() {
                            m_Buff = Shaken.ToReference<BlueprintBuffReference>(),
                            OnlyFromCaster = true,
                        },
                        new ContextActionRemoveBuff() {
                            m_Buff = Frightened.ToReference<BlueprintBuffReference>(),
                            OnlyFromCaster = true,
                        },
                        new ContextActionRemoveBuff() {
                            m_Buff = Cowering.ToReference<BlueprintBuffReference>(),
                            OnlyFromCaster = true,
                        });
                    c.UnitMove = ActionFlow.DoNothing();
                    c.Round = ActionFlow.DoSingle<ContextActionSpawnFx>(c => {
                        c.PrefabLink = new PrefabLink() { AssetId = "d80d51c0a08f35140b10dd1526e540c4" };
                    });
                });
            });
            var KillingIntentAreaBuff = TTCoreExtensions.CreateBuff($"KillingIntentAreaBuff", bp => {
                bp.SetName(IsekaiContext, KillingIntentName);
                bp.SetDescription(KingmakerIntentDesc);
                bp.m_Icon = Icon_ConsumeFear;
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.HiddenInUi;
                bp.AddComponent<AddAreaEffect>(c => {
                    c.m_AreaEffect = KillingIntentArea.ToReference<BlueprintAbilityAreaEffectReference>();
                });
            });
            var KillingIntentAbility = TTCoreExtensions.CreateActivatableAbility("KillingIntentAbility", bp => {
                bp.SetName(IsekaiContext, KillingIntentName);
                bp.SetDescription(KingmakerIntentDesc);
                bp.m_Icon = Icon_ConsumeFear;
                bp.m_Buff = KillingIntentAreaBuff.ToReference<BlueprintBuffReference>();
                bp.DoNotTurnOffOnRest = true;
            });
            var KillingIntentFeature = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "KillingIntentFeature", bp => {
                bp.SetName(IsekaiContext, KillingIntentName);
                bp.SetDescription(KingmakerIntentDesc);
                bp.m_Icon = Icon_ConsumeFear;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] {
                        KillingIntentAbility.ToReference<BlueprintUnitFactReference>(),
                    };
                });
            });

            // Add to selection
            SpecialPowerSelection.AddToSelection(KillingIntentFeature);
        }
    }
}