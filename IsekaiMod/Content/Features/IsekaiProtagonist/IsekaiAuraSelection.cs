using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.ResourceLinks;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Buffs.Components;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.Utility;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist {

    internal class IsekaiAuraSelection {

        public static void Add() {
            const string FriendlyAuraName = "Friendly Aura";
            const string FriendlyAuraDesc = "Enemies within 40 feet of the Isekai Protagonist take a –6 penalty on attack and damage rolls.";
            const string FriendlyAuraDescBuff = "This creature has a –6 penalty on attack {g|Encyclopedia:Dice}rolls{/g}.";
            var Icon_Friendly_Aura = AssetLoader.LoadInternal(IsekaiContext, "Features", "ICON_FRIENDLY_AURA.png");
            var FriendlyAuraBuff = ThingsNotHandledByTTTCore.CreateBuff("FriendlyAuraBuff", bp => {
                bp.SetName(IsekaiContext, FriendlyAuraName);
                bp.SetDescription(IsekaiContext, FriendlyAuraDescBuff);
                bp.IsClassFeature = true;
                bp.m_Icon = Icon_Friendly_Aura;
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Penalty;
                    c.Stat = StatType.AdditionalAttackBonus;
                    c.Value = -6;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Penalty;
                    c.Stat = StatType.AdditionalDamage;
                    c.Value = -6;
                });
            });
            var FriendlyAuraArea = Helpers.CreateBlueprint<BlueprintAbilityAreaEffect>(IsekaiContext, "FriendlyAuraArea", bp => {
                bp.m_TargetType = BlueprintAbilityAreaEffect.TargetType.Enemy;
                bp.AffectEnemies = true;
                bp.Shape = AreaEffectShape.Cylinder;
                bp.Size = new Feet(40);
                bp.Fx = new PrefabLink();
                bp.AddComponent(AuraUtils.CreateUnconditionalAuraEffect(FriendlyAuraBuff.ToReference<BlueprintBuffReference>()));
            });
            var FriendlyAuraAreaBuff = ThingsNotHandledByTTTCore.CreateBuff("FriendlyAuraAreaBuff", bp => {
                bp.SetName(IsekaiContext, FriendlyAuraName);
                bp.SetDescription(IsekaiContext, FriendlyAuraDesc);
                bp.m_Icon = Icon_Friendly_Aura;
                bp.IsClassFeature = true;
                bp.AddComponent<AddAreaEffect>(c => {
                    c.m_AreaEffect = FriendlyAuraArea.ToReference<BlueprintAbilityAreaEffectReference>();
                });
                bp.m_Flags = BlueprintBuff.Flags.HiddenInUi;
            });
            var FriendlyAuraAbility = ThingsNotHandledByTTTCore.CreateActivatableAbility("FriendlyAuraAbility", bp => {
                bp.SetName(IsekaiContext, FriendlyAuraName);
                bp.SetDescription(IsekaiContext, FriendlyAuraDesc);
                bp.m_Icon = Icon_Friendly_Aura;
                bp.m_Buff = FriendlyAuraAreaBuff.ToReference<BlueprintBuffReference>();
                bp.DoNotTurnOffOnRest = true;
            });
            var FriendlyAuraFeature = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "FriendlyAuraFeature", bp => {
                bp.SetName(IsekaiContext, FriendlyAuraName);
                bp.SetDescription(IsekaiContext, FriendlyAuraDesc);
                bp.m_Icon = Icon_Friendly_Aura;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { FriendlyAuraAbility.ToReference<BlueprintUnitFactReference>() };
                });
            });

            const string DarkAuraName = "Dark Aura";
            const string DarkAuraDesc = "Enemies within 40 feet take a –4 penalty on attack {g|Encyclopedia:Dice}rolls{/g}, AC, and saving throws.";
            const string DarkAuraDescBuff = "This creature has a –4 penalty on attack {g|Encyclopedia:Dice}rolls{/g}, AC, and saving throws.";
            var Icon_Dark_Aura = AssetLoader.LoadInternal(IsekaiContext, "Features", "ICON_DARK_AURA.png");
            var DarkAuraBuff = ThingsNotHandledByTTTCore.CreateBuff("DarkAuraBuff", bp => {
                bp.SetName(IsekaiContext, DarkAuraName);
                bp.SetDescription(IsekaiContext, DarkAuraDescBuff);
                bp.IsClassFeature = true;
                bp.m_Icon = Icon_Dark_Aura;
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Penalty;
                    c.Stat = StatType.AdditionalAttackBonus;
                    c.Value = -4;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Penalty;
                    c.Stat = StatType.AC;
                    c.Value = -4;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Penalty;
                    c.Stat = StatType.SaveFortitude;
                    c.Value = -4;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Penalty;
                    c.Stat = StatType.SaveReflex;
                    c.Value = -4;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Penalty;
                    c.Stat = StatType.SaveWill;
                    c.Value = -4;
                });
            });
            var DarkAuraArea = Helpers.CreateBlueprint<BlueprintAbilityAreaEffect>(IsekaiContext, "DarkAuraArea", bp => {
                bp.m_TargetType = BlueprintAbilityAreaEffect.TargetType.Enemy;
                bp.AffectEnemies = true;
                bp.Shape = AreaEffectShape.Cylinder;
                bp.Size = new Feet(40);
                bp.Fx = new PrefabLink();
                bp.AddComponent(AuraUtils.CreateUnconditionalAuraEffect(DarkAuraBuff.ToReference<BlueprintBuffReference>()));
            });
            var DarkAuraAreaBuff = ThingsNotHandledByTTTCore.CreateBuff("DarkAuraAreaBuff", bp => {
                bp.SetName(IsekaiContext, DarkAuraName);
                bp.SetDescription(IsekaiContext, DarkAuraDesc);
                bp.m_Icon = Icon_Dark_Aura;
                bp.IsClassFeature = true;
                bp.AddComponent<AddAreaEffect>(c => {
                    c.m_AreaEffect = DarkAuraArea.ToReference<BlueprintAbilityAreaEffectReference>();
                });
                bp.m_Flags = BlueprintBuff.Flags.HiddenInUi;
            });
            var DarkAuraAbility = ThingsNotHandledByTTTCore.CreateActivatableAbility("DarkAuraAbility", bp => {
                bp.SetName(IsekaiContext, DarkAuraName);
                bp.SetDescription(IsekaiContext, DarkAuraDesc);
                bp.m_Icon = Icon_Dark_Aura;
                bp.m_Buff = DarkAuraAreaBuff.ToReference<BlueprintBuffReference>();
                bp.DoNotTurnOffOnRest = true;
            });
            var DarkAuraFeature = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "DarkAuraFeature", bp => {
                bp.SetName(IsekaiContext, DarkAuraName);
                bp.SetDescription(IsekaiContext, DarkAuraDesc);
                bp.m_Icon = Icon_Dark_Aura;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { DarkAuraAbility.ToReference<BlueprintUnitFactReference>() };
                });
            });

            var IsekaiAuraSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "IsekaiAuraSelection", bp => {
                bp.SetName(IsekaiContext, "Isekai Aura");
                bp.SetDescription(IsekaiContext, "At 10th level, you are able to choose an aura.");
                bp.m_Icon = Icon_Friendly_Aura;
                bp.IgnorePrerequisites = true;
                bp.m_AllFeatures = new BlueprintFeatureReference[] {
                    FriendlyAuraFeature.ToReference<BlueprintFeatureReference>(),
                    DarkAuraFeature.ToReference<BlueprintFeatureReference>(),
                };
            });
        }
    }
}