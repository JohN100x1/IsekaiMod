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
            const string FriendlyAuraDesc = "You emit an aura of friendship that cause enemies to subconsciously hold back."
                + "\nEnemies within 40 feet of the Isekai Protagonist take a –4 penalty on attack and damage rolls.";
            const string FriendlyAuraDescBuff = "This creature has a –4 penalty on attack {g|Encyclopedia:Dice}rolls{/g}.";
            var Icon_Friendly_Aura = AssetLoader.LoadInternal(IsekaiContext, "Features", "ICON_FRIENDLY_AURA.png");
            var FriendlyAuraBuff = ThingsNotHandledByTTTCore.CreateBuff("FriendlyAuraBuff", bp => {
                bp.SetName(IsekaiContext, FriendlyAuraName);
                bp.SetDescription(IsekaiContext, FriendlyAuraDescBuff);
                bp.IsClassFeature = true;
                bp.m_Icon = Icon_Friendly_Aura;
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Penalty;
                    c.Stat = StatType.AdditionalAttackBonus;
                    c.Value = -4;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Penalty;
                    c.Stat = StatType.AdditionalDamage;
                    c.Value = -4;
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
            const string DarkAuraDesc = "You emit an aura of darkness that cause enemies to become uneasy and vulnerable."
                + "\nEnemies within 40 feet take a –4 penalty on AC and saving throws.";
            const string DarkAuraDescBuff = "This creature has a –4 penalty on AC and saving throws.";
            var Icon_Dark_Aura = AssetLoader.LoadInternal(IsekaiContext, "Features", "ICON_DARK_AURA.png");
            var DarkAuraBuff = ThingsNotHandledByTTTCore.CreateBuff("DarkAuraBuff", bp => {
                bp.SetName(IsekaiContext, DarkAuraName);
                bp.SetDescription(IsekaiContext, DarkAuraDescBuff);
                bp.IsClassFeature = true;
                bp.m_Icon = Icon_Dark_Aura;
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

            const string DivineAuraName = "Divine Aura";
            const string DivineAuraDesc = "You emit an aura of divinity that cause enemies to be overcome with feelings of futility."
                + "\nEnemies within 40 feet take a –4 penalty on all attributes.";
            const string DivineAuraDescBuff = "This creature has a –4 penalty on all attributes.";
            var Icon_Divine_Aura = AssetLoader.LoadInternal(IsekaiContext, "Features", "ICON_DIVINE_AURA.png");
            var DivineAuraBuff = ThingsNotHandledByTTTCore.CreateBuff("DivineAuraBuff", bp => {
                bp.SetName(IsekaiContext, DivineAuraName);
                bp.SetDescription(IsekaiContext, DivineAuraDescBuff);
                bp.IsClassFeature = true;
                bp.m_Icon = Icon_Divine_Aura;
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Penalty;
                    c.Stat = StatType.Strength;
                    c.Value = -4;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Penalty;
                    c.Stat = StatType.Dexterity;
                    c.Value = -4;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Penalty;
                    c.Stat = StatType.Constitution;
                    c.Value = -4;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Penalty;
                    c.Stat = StatType.Intelligence;
                    c.Value = -4;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Penalty;
                    c.Stat = StatType.Wisdom;
                    c.Value = -4;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Penalty;
                    c.Stat = StatType.Charisma;
                    c.Value = -4;
                });
            });
            var DivineAuraArea = Helpers.CreateBlueprint<BlueprintAbilityAreaEffect>(IsekaiContext, "DivineAuraArea", bp => {
                bp.m_TargetType = BlueprintAbilityAreaEffect.TargetType.Enemy;
                bp.AffectEnemies = true;
                bp.Shape = AreaEffectShape.Cylinder;
                bp.Size = new Feet(40);
                bp.Fx = new PrefabLink();
                bp.AddComponent(AuraUtils.CreateUnconditionalAuraEffect(DivineAuraBuff.ToReference<BlueprintBuffReference>()));
            });
            var DivineAuraAreaBuff = ThingsNotHandledByTTTCore.CreateBuff("DivineAuraAreaBuff", bp => {
                bp.SetName(IsekaiContext, DivineAuraName);
                bp.SetDescription(IsekaiContext, DivineAuraDesc);
                bp.m_Icon = Icon_Divine_Aura;
                bp.IsClassFeature = true;
                bp.AddComponent<AddAreaEffect>(c => {
                    c.m_AreaEffect = DivineAuraArea.ToReference<BlueprintAbilityAreaEffectReference>();
                });
                bp.m_Flags = BlueprintBuff.Flags.HiddenInUi;
            });
            var DivineAuraAbility = ThingsNotHandledByTTTCore.CreateActivatableAbility("DivineAuraAbility", bp => {
                bp.SetName(IsekaiContext, DivineAuraName);
                bp.SetDescription(IsekaiContext, DivineAuraDesc);
                bp.m_Icon = Icon_Divine_Aura;
                bp.m_Buff = DivineAuraAreaBuff.ToReference<BlueprintBuffReference>();
                bp.DoNotTurnOffOnRest = true;
            });
            var DivineAuraFeature = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "DivineAuraFeature", bp => {
                bp.SetName(IsekaiContext, DivineAuraName);
                bp.SetDescription(IsekaiContext, DivineAuraDesc);
                bp.m_Icon = Icon_Divine_Aura;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { DivineAuraAbility.ToReference<BlueprintUnitFactReference>() };
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
                    DivineAuraFeature.ToReference<BlueprintFeatureReference>(),
                };
            });
        }
    }
}