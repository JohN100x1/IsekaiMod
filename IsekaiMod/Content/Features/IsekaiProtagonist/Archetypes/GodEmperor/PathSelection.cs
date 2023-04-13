using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Enums.Damage;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.GodEmperor {

    internal class PathSelection {

        public static void Add() {
            const string RighteousPathName = "Righteous Path";
            const string RighteousPathDescription = "The damage you deal is now divine damage.";
            var Icon_RighteousPath = BlueprintTools.GetBlueprint<BlueprintAbility>("0f5bd128c76dd374b8cb9111e3b5186b").m_Icon;
            var RighteousPathBuff = TTCoreExtensions.CreateBuff("RighteousPathBuff", bp => {
                bp.SetName(IsekaiContext, RighteousPathName);
                bp.SetDescription(IsekaiContext, RighteousPathDescription);
                bp.IsClassFeature = true;
                bp.m_Icon = Icon_RighteousPath;
                bp.AddComponent<ChangeOutgoingDamageType>(c => {
                    c.Type = new DamageTypeDescription() {
                        Type = DamageType.Energy,
                        Common = new DamageTypeDescription.CommomData(),
                        Physical = new DamageTypeDescription.PhysicalData(),
                        Energy = DamageEnergyType.Divine
                    };
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
            const string UnjustPathDescription = "The damage you deal is now unholy damage.";
            var Icon_UnjustPath = AssetLoader.LoadInternal(IsekaiContext, "Features", "ICON_UNJUST_PATH.png");
            var UnjustPathBuff = TTCoreExtensions.CreateBuff("UnjustPathBuff", bp => {
                bp.SetName(IsekaiContext, UnjustPathName);
                bp.SetDescription(IsekaiContext, UnjustPathDescription);
                bp.IsClassFeature = true;
                bp.m_Icon = Icon_UnjustPath;
                bp.AddComponent<ChangeOutgoingDamageType>(c => {
                    c.Type = new DamageTypeDescription() {
                        Type = DamageType.Energy,
                        Common = new DamageTypeDescription.CommomData(),
                        Physical = new DamageTypeDescription.PhysicalData(),
                        Energy = DamageEnergyType.Unholy
                    };
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
                bp.SetDescription(IsekaiContext, "At 12th level, you transform the damage you deal into either divine or unholy.");
                bp.m_Icon = Icon_RighteousPath;
                bp.IgnorePrerequisites = true;
                bp.m_AllFeatures = new BlueprintFeatureReference[] {
                    RighteousPathFeature.ToReference<BlueprintFeatureReference>(),
                    UnjustPathFeature.ToReference<BlueprintFeatureReference>(),
                };
            });

            SecretPowerSelection.AddToSelection(RighteousPathFeature);
            SecretPowerSelection.AddToSelection(UnjustPathFeature);
        }
    }
}