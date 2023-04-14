using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Enums.Damage;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.Utility;
using TabletopTweaks.Core.Utilities;
using UnityEngine;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.GodEmperor {

    internal class RealmSelection {
        private static readonly Sprite Icon_CelestialRealm = AssetLoader.LoadInternal(IsekaiContext, "Features", "ICON_REALM_CELESTIAL.png");
        private static readonly Sprite Icon_ShadowRealm = AssetLoader.LoadInternal(IsekaiContext, "Features", "ICON_REALM_SHADOW.png");

        public static void Add() {

            var CelestialRealmFeature = TTCoreExtensions.CreateToggleAuraFeature(
                name: "CelestialRealm",
                description: "Allies within 40 feet of you transform their damage type into divine.",
                descriptionBuff: "This character transforms their damage type into divine.",
                icon: Icon_CelestialRealm,
                targetType: BlueprintAbilityAreaEffect.TargetType.Ally,
                auraSize: new Feet(40),
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

            var ShadowRealmFeature = TTCoreExtensions.CreateToggleAuraFeature(
                name: "ShadowRealm",
                description: "Allies within 40 feet of you transform their damage type into unholy.",
                descriptionBuff: "This character transforms their damage type into unholy.",
                icon: Icon_ShadowRealm,
                targetType: BlueprintAbilityAreaEffect.TargetType.Ally,
                auraSize: new Feet(40),
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

            var RealmSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "RealmSelection", bp => {
                bp.SetName(IsekaiContext, "Transcendental Realm");
                bp.SetDescription(IsekaiContext, "At 15th level, you are able to ascend into a higher plane of existence and harness its energies.");
                bp.m_Icon = Icon_CelestialRealm;
                bp.IgnorePrerequisites = true;
                bp.m_AllFeatures = new BlueprintFeatureReference[] {
                    CelestialRealmFeature.ToReference<BlueprintFeatureReference>(),
                    ShadowRealmFeature.ToReference<BlueprintFeatureReference>(),
                };
            });
        }
    }
}