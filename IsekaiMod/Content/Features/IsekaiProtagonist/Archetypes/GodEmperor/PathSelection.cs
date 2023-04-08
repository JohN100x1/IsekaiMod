using IsekaiMod.Components;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Enums.Damage;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Alignments;
using Kingmaker.UnitLogic.FactLogic;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.GodEmperor {

    internal class PathSelection {

        public static void Add() {
            const string RighteousPathName = "Righteous Path";
            const string RighteousPathDescription = "You transform half the damage you deal into divine damage.";
            var Icon_RighteousPath = BlueprintTools.GetBlueprint<BlueprintAbility>("0f5bd128c76dd374b8cb9111e3b5186b").m_Icon;
            var RighteousPathBuff = TTCoreExtensions.CreateBuff("RighteousPathBuff", bp => {
                bp.SetName(IsekaiContext, RighteousPathName);
                bp.SetDescription(IsekaiContext, RighteousPathDescription);
                bp.IsClassFeature = true;
                bp.m_Icon = Icon_RighteousPath;
                bp.AddComponent<SplitOutgoingDamage>(c => {
                    c.Element = DamageEnergyType.Divine;
                });
            });
            var RighteousPathAbility = TTCoreExtensions.CreateActivatableAbility("RighteousPathAbility", bp => {
                bp.SetName(IsekaiContext, RighteousPathName);
                bp.SetDescription(IsekaiContext, RighteousPathDescription);
                bp.m_Icon = Icon_RighteousPath;
                bp.m_Buff = RighteousPathBuff.ToReference<BlueprintBuffReference>();
                bp.DoNotTurnOffOnRest = true;
            });
            var RighteousPathFeature = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "RighteousPathFeature", bp => {
                bp.SetName(IsekaiContext, RighteousPathName);
                bp.SetDescription(IsekaiContext, RighteousPathDescription);
                bp.m_Icon = Icon_RighteousPath;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { RighteousPathAbility.ToReference<BlueprintUnitFactReference>() };
                });
            });

            const string UnjustPathName = "Unjust Path";
            const string UnjustPathDescription = "You transform half the damage you deal into unholy damage.";
            var Icon_UnjustPath = AssetLoader.LoadInternal(IsekaiContext, "Features", "ICON_UNJUST_PATH.png");
            var UnjustPathBuff = TTCoreExtensions.CreateBuff("UnjustPathBuff", bp => {
                bp.SetName(IsekaiContext, UnjustPathName);
                bp.SetDescription(IsekaiContext, UnjustPathDescription);
                bp.IsClassFeature = true;
                bp.m_Icon = Icon_UnjustPath;
                bp.AddComponent<SplitOutgoingDamage>(c => {
                    c.Element = DamageEnergyType.Unholy;
                });
            });
            var UnjustPathAbility = TTCoreExtensions.CreateActivatableAbility("UnjustPathAbility", bp => {
                bp.SetName(IsekaiContext, UnjustPathName);
                bp.SetDescription(IsekaiContext, UnjustPathDescription);
                bp.m_Icon = Icon_UnjustPath;
                bp.m_Buff = UnjustPathBuff.ToReference<BlueprintBuffReference>();
                bp.DoNotTurnOffOnRest = true;
            });
            var UnjustPathFeature = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "UnjustPathFeature", bp => {
                bp.SetName(IsekaiContext, UnjustPathName);
                bp.SetDescription(IsekaiContext, UnjustPathDescription);
                bp.m_Icon = Icon_UnjustPath;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { UnjustPathAbility.ToReference<BlueprintUnitFactReference>() };
                });
            });

            var PathSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "PathSelection", bp => {
                bp.SetName(IsekaiContext, "Chosen Path");
                bp.SetDescription(IsekaiContext, "At 12th level, you transform half the damage you deal into either divine or unholy.");
                bp.m_Icon = Icon_RighteousPath;
                bp.IgnorePrerequisites = true;
                bp.m_AllFeatures = new BlueprintFeatureReference[] {
                    RighteousPathFeature.ToReference<BlueprintFeatureReference>(),
                    UnjustPathFeature.ToReference<BlueprintFeatureReference>(),
                };
            });
        }
    }
}