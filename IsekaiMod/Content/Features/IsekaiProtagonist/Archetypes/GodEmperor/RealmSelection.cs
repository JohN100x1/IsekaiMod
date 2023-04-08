using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Enums.Damage;
using Kingmaker.ResourceLinks;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Buffs.Components;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.Utility;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.GodEmperor {

    internal class RealmSelection {

        public static void Add() {

            const string CelestialRealmName = "Celestial Realm";
            const string CelestialRealmDesc = "Allies within 40 feet of you transform their damage type into divine.";
            const string CelestialRealmDescBuff = "This character transforms their damage type into divine.";
            var Icon_CelestialRealm = AssetLoader.LoadInternal(IsekaiContext, "Features", "ICON_REALM_CELESTIAL.png");
            var CelestialRealmBuff = TTCoreExtensions.CreateBuff("CelestialRealmBuff", bp => {
                bp.SetName(IsekaiContext, CelestialRealmName);
                bp.SetDescription(IsekaiContext, CelestialRealmDescBuff);
                bp.IsClassFeature = true;
                bp.m_Icon = Icon_CelestialRealm;
                bp.AddComponent<ChangeOutgoingDamageType>(c => {
                    c.Type = new DamageTypeDescription() {
                        Type = DamageType.Energy,
                        Common = new DamageTypeDescription.CommomData(),
                        Physical = new DamageTypeDescription.PhysicalData(),
                        Energy = DamageEnergyType.Divine
                    };
                });
            });
            var CelestialRealmArea = Helpers.CreateBlueprint<BlueprintAbilityAreaEffect>(IsekaiContext, "CelestialRealmArea", bp => {
                bp.m_TargetType = BlueprintAbilityAreaEffect.TargetType.Ally;
                bp.Shape = AreaEffectShape.Cylinder;
                bp.Size = new Feet(40);
                bp.Fx = new PrefabLink();
                bp.AddComponent(AuraUtils.CreateUnconditionalAuraEffect(CelestialRealmBuff.ToReference<BlueprintBuffReference>()));
            });
            var CelestialRealmAreaBuff = TTCoreExtensions.CreateBuff("CelestialRealmAreaBuff", bp => {
                bp.SetName(IsekaiContext, CelestialRealmName);
                bp.SetDescription(IsekaiContext, CelestialRealmDesc);
                bp.m_Icon = Icon_CelestialRealm;
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.HiddenInUi;
                bp.AddComponent<AddAreaEffect>(c => {
                    c.m_AreaEffect = CelestialRealmArea.ToReference<BlueprintAbilityAreaEffectReference>();
                });
            });
            var CelestialRealmAbility = TTCoreExtensions.CreateActivatableAbility("CelestialRealmAbility", bp => {
                bp.SetName(IsekaiContext, CelestialRealmName);
                bp.SetDescription(IsekaiContext, CelestialRealmDesc);
                bp.m_Icon = Icon_CelestialRealm;
                bp.m_Buff = CelestialRealmAreaBuff.ToReference<BlueprintBuffReference>();
                bp.DoNotTurnOffOnRest = true;
            });
            var CelestialRealmFeature = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "CelestialRealmFeature", bp => {
                bp.SetName(IsekaiContext, CelestialRealmName);
                bp.SetDescription(IsekaiContext, CelestialRealmDesc);
                bp.m_Icon = Icon_CelestialRealm;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { CelestialRealmAbility.ToReference<BlueprintUnitFactReference>() };
                });
            });

            const string ShadowRealmName = "Shadow Realm";
            const string ShadowRealmDesc = "Allies within 40 feet of you transform their damage type into unholy.";
            const string ShadowRealmDescBuff = "This character transforms their damage type into unholy.";
            var Icon_ShadowRealm = AssetLoader.LoadInternal(IsekaiContext, "Features", "ICON_REALM_SHADOW.png");
            var ShadowRealmBuff = TTCoreExtensions.CreateBuff("ShadowRealmBuff", bp => {
                bp.SetName(IsekaiContext, ShadowRealmName);
                bp.SetDescription(IsekaiContext, ShadowRealmDescBuff);
                bp.IsClassFeature = true;
                bp.m_Icon = Icon_ShadowRealm;
                bp.AddComponent<ChangeOutgoingDamageType>(c => {
                    c.Type = new DamageTypeDescription() {
                        Type = DamageType.Energy,
                        Common = new DamageTypeDescription.CommomData(),
                        Physical = new DamageTypeDescription.PhysicalData(),
                        Energy = DamageEnergyType.Divine
                    };
                });
            });
            var ShadowRealmArea = Helpers.CreateBlueprint<BlueprintAbilityAreaEffect>(IsekaiContext, "ShadowRealmArea", bp => {
                bp.m_TargetType = BlueprintAbilityAreaEffect.TargetType.Ally;
                bp.Shape = AreaEffectShape.Cylinder;
                bp.Size = new Feet(40);
                bp.Fx = new PrefabLink();
                bp.AddComponent(AuraUtils.CreateUnconditionalAuraEffect(ShadowRealmBuff.ToReference<BlueprintBuffReference>()));
            });
            var ShadowRealmAreaBuff = TTCoreExtensions.CreateBuff("ShadowRealmAreaBuff", bp => {
                bp.SetName(IsekaiContext, ShadowRealmName);
                bp.SetDescription(IsekaiContext, ShadowRealmDesc);
                bp.m_Icon = Icon_ShadowRealm;
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.HiddenInUi;
                bp.AddComponent<AddAreaEffect>(c => {
                    c.m_AreaEffect = ShadowRealmArea.ToReference<BlueprintAbilityAreaEffectReference>();
                });
            });
            var ShadowRealmAbility = TTCoreExtensions.CreateActivatableAbility("ShadowRealmAbility", bp => {
                bp.SetName(IsekaiContext, ShadowRealmName);
                bp.SetDescription(IsekaiContext, ShadowRealmDesc);
                bp.m_Icon = Icon_ShadowRealm;
                bp.m_Buff = ShadowRealmAreaBuff.ToReference<BlueprintBuffReference>();
                bp.DoNotTurnOffOnRest = true;
            });
            var ShadowRealmFeature = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "ShadowRealmFeature", bp => {
                bp.SetName(IsekaiContext, ShadowRealmName);
                bp.SetDescription(IsekaiContext, ShadowRealmDesc);
                bp.m_Icon = Icon_ShadowRealm;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { ShadowRealmAbility.ToReference<BlueprintUnitFactReference>() };
                });
            });

            var RealmSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "RealmSelection", bp => {
                bp.SetName(IsekaiContext, "Transcendental Realm");
                bp.SetDescription(IsekaiContext, "At 17th level, you are able to ascend into a higher plane of existence and harness its energies.");
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