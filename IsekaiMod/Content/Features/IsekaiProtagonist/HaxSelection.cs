using IsekaiMod.Components;
using IsekaiMod.Content.Features.IsekaiProtagonist.SpecialPower;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.UnitLogic.Mechanics.Components;
using TabletopTweaks.Core.Utilities;
using UnityEngine;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist {
    static class HaxSelection {
        private static readonly Sprite Icon_Hax = AssetLoader.LoadInternal(IsekaiContext, "Features", "ICON_HAX.png");
        public static void Add() {
            var SeriousStrike = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "SeriousStrike", bp => {
                bp.SetName(IsekaiContext, "Serious Strike");
                bp.SetDescription(IsekaiContext, "Enemies die in one hit.");
                bp.m_Icon = Icon_Hax;
                bp.AddComponent<AddOutgoingDamageTrigger>(c => {
                    c.Actions = ActionFlow.DoSingle<ContextActionKill>(c => {
                        c.Dismember = UnitState.DismemberType.LimbsApart;
                    });
                });
            });
            var Invincibility = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "Invincibility", bp => {
                bp.SetName(IsekaiContext, "Invincibility");
                bp.SetDescription(IsekaiContext, "You cannot take damage.");
                bp.m_Icon = Icon_Hax;
                bp.AddComponent<CompleteDamageImmunity>();
            });
            var FasterThanLight = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "FasterThanLight", bp => {
                bp.SetName(IsekaiContext, "Faster than Light");
                bp.SetDescription(IsekaiContext, "Attacks always miss you.");
                bp.m_Icon = Icon_Hax;
                bp.AddComponent<SetAttackerAutoMiss>();
            });
            var HaxSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "HaxSelection", bp => {
                bp.SetName(IsekaiContext, "Hax");
                bp.SetDescription(IsekaiContext, "So this is the result of 100 push-ups, 100 sit-ups, 100 squats and a 10km run...");
                bp.m_Icon = Icon_Hax;
                bp.m_AllFeatures = new BlueprintFeatureReference[] {
                    SeriousStrike.ToReference<BlueprintFeatureReference>(),
                    Invincibility.ToReference<BlueprintFeatureReference>(),
                    FasterThanLight.ToReference<BlueprintFeatureReference>(),
                };
            });
        }
    }
}
