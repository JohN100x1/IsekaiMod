using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Enums.Damage;
using Kingmaker.ResourceLinks;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Buffs.Components;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.Utility;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.GodEmperor
{
    class CelestialRealm
    {
        public static void Add()
        {
            var Icon_CelestialRealm = AssetLoader.LoadInternal(IsekaiContext, "Features", "ICON_CELESTIAL_REALM.png");
            var CelestialRealmBuff = Helpers.CreateBlueprint<BlueprintBuff>(IsekaiContext, "CelestialRealmBuff", bp => {
                bp.SetName(IsekaiContext, "Celestial Realm");
                bp.SetDescription(IsekaiContext, "This character transforms their damage type into divine.");
                bp.IsClassFeature = true;
                bp.m_Icon = Icon_CelestialRealm;
                bp.AddComponent<ChangeOutgoingDamageType>(c => {
                    c.Type = new DamageTypeDescription()
                    {
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
            var CelestialRealmAreaBuff = Helpers.CreateBlueprint<BlueprintBuff>(IsekaiContext, "CelestialRealmAreaBuff", bp => {
                bp.SetName(IsekaiContext, "Celestial Realm");
                bp.SetDescription(IsekaiContext, "Allies within 40 feet of you transform their damage type into divine.");
                bp.m_Icon = Icon_CelestialRealm;
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.HiddenInUi;
                bp.AddComponent<AddAreaEffect>(c => {
                    c.m_AreaEffect = CelestialRealmArea.ToReference<BlueprintAbilityAreaEffectReference>();
                });
            });
            var CelestialRealmAbility = Helpers.CreateBlueprint<BlueprintActivatableAbility>(IsekaiContext, "CelestialRealmAbility", bp => {
                bp.SetName(IsekaiContext, "Celestial Realm");
                bp.SetDescription(IsekaiContext, "Allies within 40 feet of you transform their damage type into divine.");
                bp.m_Icon = Icon_CelestialRealm;
                bp.m_Buff = CelestialRealmAreaBuff.ToReference<BlueprintBuffReference>();
                bp.DoNotTurnOffOnRest = true;
            });
            var CelestialRealmFeature = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext ,"CelestialRealmFeature", bp => {
                bp.SetName(IsekaiContext, "Celestial Realm");
                bp.SetDescription(IsekaiContext, "At 17th level, allies within 40 feet of you transform their damage type into divine.");
                bp.m_Icon = Icon_CelestialRealm;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { CelestialRealmAbility.ToReference<BlueprintUnitFactReference>() };
                });
            });
        }
    }
}
