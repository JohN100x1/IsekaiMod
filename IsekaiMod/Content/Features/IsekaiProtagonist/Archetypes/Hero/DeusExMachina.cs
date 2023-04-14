using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.ResourceLinks;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components.AreaEffects;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.UnitLogic.Mechanics.Conditions;
using Kingmaker.UnitLogic.Mechanics.Properties;
using Kingmaker.Utility;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Hero {

    internal class DeusExMachina {

        public static void Add() {
            const string DeusExMachinaName = "Deus Ex Machina";
            const string DeusExMachinaDescription = "Once per day, when your {g|Encyclopedia:HP}HP{/g} drops to 0, you are resurrected to full health. "
                + "Allies within 40 feet are then restored to full health while enemies instantly die.";
            var Icon_DeusExMachina = AssetLoader.LoadInternal(IsekaiContext, "Features", "ICON_DEUS_EX_MACHINA.png");
            var DeusExMachinaArea = Helpers.CreateBlueprint<BlueprintAbilityAreaEffect>(IsekaiContext, "DeusExMachinaArea", bp => {
                bp.m_TargetType = BlueprintAbilityAreaEffect.TargetType.Any;
                bp.SpellResistance = false;
                bp.AggroEnemies = false;
                bp.AffectEnemies = true;
                bp.Shape = AreaEffectShape.Cylinder;
                bp.Size = new Feet(40);
                bp.Fx = new PrefabLink() { AssetId = "c152c5cb0af124a40bc94087f9e2bb29" };
                bp.AddComponent<AbilityAreaEffectRunAction>(c => {
                    c.UnitEnter = ActionFlow.DoSingle<Conditional>(c => {
                        c.ConditionsChecker = ActionFlow.IfSingle<ContextConditionIsEnemy>();
                        c.IfTrue = ActionFlow.DoSingle<ContextActionKill>();
                        c.IfFalse = ActionFlow.DoSingle<ContextActionHealTarget>(c => {
                            c.Value = new ContextDiceValue() {
                                DiceType = DiceType.Zero,
                                DiceCountValue = 0,
                                BonusValue = Values.CreateContextTargetPropertyValue(UnitProperty.MaxHP)
                            };
                        });
                    });
                    c.UnitExit = ActionFlow.DoNothing();
                    c.UnitMove = ActionFlow.DoNothing();
                    c.Round = ActionFlow.DoNothing();
                });
            });
            var DeusExMachinaBuff = TTCoreExtensions.CreateBuff("DeusExMachinaBuff", bp => {
                bp.SetName(IsekaiContext, DeusExMachinaName);
                bp.SetDescription(IsekaiContext, DeusExMachinaDescription);
                bp.m_Icon = Icon_DeusExMachina;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.AddComponent<DeathActions>(c => {
                    c.CheckResource = false;
                    c.Actions = Helpers.CreateActionList(
                        new ContextActionResurrect() { FullRestore = true },
                        new ContextActionSpawnFx() {
                            PrefabLink = new PrefabLink() { AssetId = "749ad3759dc93d64dba70a84d48135b5" }
                        },
                        new ContextActionSpawnAreaEffect() {
                            m_AreaEffect = DeusExMachinaArea.ToReference<BlueprintAbilityAreaEffectReference>(),
                            DurationValue = Values.Duration.OneRound
                        },
                        new ContextActionRemoveSelf()
                        );
                });
            });
            var DeusExMachinaFeature = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "DeusExMachinaFeature", bp => {
                bp.SetName(IsekaiContext, DeusExMachinaName);
                bp.SetDescription(IsekaiContext, DeusExMachinaDescription);
                bp.m_Icon = Icon_DeusExMachina;
                bp.AddComponent<AddRestTrigger>(c => {
                    c.Action = ActionFlow.DoSingle<ContextActionApplyBuff>(c => {
                        c.m_Buff = DeusExMachinaBuff.ToReference<BlueprintBuffReference>();
                        c.Permanent = true;
                        c.IsFromSpell = false;
                    });
                });
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { DeusExMachinaBuff.ToReference<BlueprintUnitFactReference>() };
                    c.DoNotRestoreMissingFacts = true;
                });
            });
        }
    }
}