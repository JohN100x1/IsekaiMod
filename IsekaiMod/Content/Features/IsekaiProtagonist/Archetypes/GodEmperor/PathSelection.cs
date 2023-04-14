using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Enums.Damage;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using TabletopTweaks.Core.Utilities;
using UnityEngine;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.GodEmperor {

    internal class PathSelection {
        private static readonly Sprite Icon_Arbitrament = BlueprintTools.GetBlueprint<BlueprintAbility>("0f5bd128c76dd374b8cb9111e3b5186b").m_Icon;
        private static readonly Sprite Icon_UnjustPath = AssetLoader.LoadInternal(IsekaiContext, "Features", "ICON_UNJUST_PATH.png");

        public static void Add() {
            var RighteousPathFeature = TTCoreExtensions.CreateToggleBuffFeature(
                name: "RighteousPath",
                description: "The damage you deal is now divine damage.",
                icon: Icon_Arbitrament,
                buffEffect: bp => {
                    bp.AddComponent<ChangeOutgoingDamageType>(c => {
                        c.Type = new DamageTypeDescription() {
                            Type = DamageType.Energy,
                            Common = new DamageTypeDescription.CommomData(),
                            Physical = new DamageTypeDescription.PhysicalData(),
                            Energy = DamageEnergyType.Divine
                        };
                    });
                });

            var UnjustPathFeature = TTCoreExtensions.CreateToggleBuffFeature(
                name: "UnjustPath",
                description: "The damage you deal is now unholy damage.",
                icon: Icon_UnjustPath,
                buffEffect: bp => {
                    bp.AddComponent<ChangeOutgoingDamageType>(c => {
                        c.Type = new DamageTypeDescription() {
                            Type = DamageType.Energy,
                            Common = new DamageTypeDescription.CommomData(),
                            Physical = new DamageTypeDescription.PhysicalData(),
                            Energy = DamageEnergyType.Unholy
                        };
                    });
                });

            var PathSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "PathSelection", bp => {
                bp.SetName(IsekaiContext, "Chosen Path");
                bp.SetDescription(IsekaiContext, "At 12th level, you transform the damage you deal into either divine or unholy.");
                bp.m_Icon = Icon_Arbitrament;
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