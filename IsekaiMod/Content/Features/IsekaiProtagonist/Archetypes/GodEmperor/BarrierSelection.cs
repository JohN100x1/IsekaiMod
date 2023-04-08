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
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.Utility;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.GodEmperor {

    internal class BarrierSelection {

        public static void Add() {
            const string GoldBarrierName = "Gold Barrier";
            const string GoldBarrierDescription = "Allies within 40 feet of you gain a sacred bonus to AC and saving throws equal to 1/2 your character level.";
            const string GoldBarrierDescriptionBuff = "This character has a sacred bonus to AC and saving throws equal to 1/2 your character level.";
            var Icon_GoldBarrier = AssetLoader.LoadInternal(IsekaiContext, "Features", "ICON_AURA_BARRIER_GOLD.png");
            var GoldBarrierBuff = TTCoreExtensions.CreateBuff("GoldBarrierBuff", bp => {
                bp.SetName(IsekaiContext, GoldBarrierName);
                bp.SetDescription(IsekaiContext, GoldBarrierDescriptionBuff);
                bp.IsClassFeature = true;
                bp.m_Icon = Icon_GoldBarrier;
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Sacred;
                    c.Stat = StatType.AC;
                    c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                });
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Sacred;
                    c.Stat = StatType.SaveFortitude;
                    c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                });
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Sacred;
                    c.Stat = StatType.SaveReflex;
                    c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                });
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Sacred;
                    c.Stat = StatType.SaveWill;
                    c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                });
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.StatBonus;
                    c.m_BaseValueType = ContextRankBaseValueType.CharacterLevel;
                    c.m_Progression = ContextRankProgression.Div2;
                });
            });
            var GoldBarrierArea = Helpers.CreateBlueprint<BlueprintAbilityAreaEffect>(IsekaiContext, "GoldBarrierArea", bp => {
                bp.m_TargetType = BlueprintAbilityAreaEffect.TargetType.Ally;
                bp.Shape = AreaEffectShape.Cylinder;
                bp.Size = new Feet(40);
                bp.Fx = new PrefabLink();
                bp.AddComponent(AuraUtils.CreateUnconditionalAuraEffect(GoldBarrierBuff.ToReference<BlueprintBuffReference>()));
            });
            var GoldBarrierAreaBuff = TTCoreExtensions.CreateBuff("GoldBarrierAreaBuff", bp => {
                bp.SetName(IsekaiContext, GoldBarrierName);
                bp.SetDescription(IsekaiContext, GoldBarrierDescription);
                bp.m_Icon = Icon_GoldBarrier;
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.HiddenInUi;
                bp.AddComponent<AddAreaEffect>(c => {
                    c.m_AreaEffect = GoldBarrierArea.ToReference<BlueprintAbilityAreaEffectReference>();
                });
            });
            var GoldBarrierAbility = TTCoreExtensions.CreateActivatableAbility("GoldBarrierAbility", bp => {
                bp.SetName(IsekaiContext, GoldBarrierName);
                bp.SetDescription(IsekaiContext, GoldBarrierDescription);
                bp.m_Icon = Icon_GoldBarrier;
                bp.m_Buff = GoldBarrierAreaBuff.ToReference<BlueprintBuffReference>();
                bp.DoNotTurnOffOnRest = true;
            });
            var GoldBarrierFeature = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "GoldBarrierFeature", bp => {
                bp.SetName(IsekaiContext, GoldBarrierName);
                bp.SetDescription(IsekaiContext, GoldBarrierDescription);
                bp.m_Icon = Icon_GoldBarrier;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { GoldBarrierAbility.ToReference<BlueprintUnitFactReference>() };
                });
            });

            const string VoidBarrierName = "Void Barrier";
            const string VoidBarrierDescription = "Allies within 40 feet of you gain a profane bonus to AC and saving throws equal to 1/2 your character level.";
            const string VoidBarrierDescriptionBuff = "This character has a profane bonus to AC and saving throws equal to 1/2 your character level.";
            var Icon_VoidBarrier = AssetLoader.LoadInternal(IsekaiContext, "Features", "ICON_AURA_BARRIER_VOID.png");
            var VoidBarrierBuff = TTCoreExtensions.CreateBuff("VoidBarrierBuff", bp => {
                bp.SetName(IsekaiContext, VoidBarrierName);
                bp.SetDescription(IsekaiContext, VoidBarrierDescriptionBuff);
                bp.IsClassFeature = true;
                bp.m_Icon = Icon_VoidBarrier;
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Profane;
                    c.Stat = StatType.AC;
                    c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                });
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Profane;
                    c.Stat = StatType.SaveFortitude;
                    c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                });
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Profane;
                    c.Stat = StatType.SaveReflex;
                    c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                });
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Profane;
                    c.Stat = StatType.SaveWill;
                    c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                });
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.StatBonus;
                    c.m_BaseValueType = ContextRankBaseValueType.CharacterLevel;
                    c.m_Progression = ContextRankProgression.Div2;
                });
            });
            var VoidBarrierArea = Helpers.CreateBlueprint<BlueprintAbilityAreaEffect>(IsekaiContext, "VoidBarrierArea", bp => {
                bp.m_TargetType = BlueprintAbilityAreaEffect.TargetType.Ally;
                bp.Shape = AreaEffectShape.Cylinder;
                bp.Size = new Feet(40);
                bp.Fx = new PrefabLink();
                bp.AddComponent(AuraUtils.CreateUnconditionalAuraEffect(VoidBarrierBuff.ToReference<BlueprintBuffReference>()));
            });
            var VoidBarrierAreaBuff = TTCoreExtensions.CreateBuff("VoidBarrierAreaBuff", bp => {
                bp.SetName(IsekaiContext, VoidBarrierName);
                bp.SetDescription(IsekaiContext, VoidBarrierDescription);
                bp.m_Icon = Icon_VoidBarrier;
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.HiddenInUi;
                bp.AddComponent<AddAreaEffect>(c => {
                    c.m_AreaEffect = VoidBarrierArea.ToReference<BlueprintAbilityAreaEffectReference>();
                });
            });
            var VoidBarrierAbility = TTCoreExtensions.CreateActivatableAbility("VoidBarrierAbility", bp => {
                bp.SetName(IsekaiContext, VoidBarrierName);
                bp.SetDescription(IsekaiContext, VoidBarrierDescription);
                bp.m_Icon = Icon_VoidBarrier;
                bp.m_Buff = VoidBarrierAreaBuff.ToReference<BlueprintBuffReference>();
                bp.DoNotTurnOffOnRest = true;
            });
            var VoidBarrierFeature = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "VoidBarrierFeature", bp => {
                bp.SetName(IsekaiContext, VoidBarrierName);
                bp.SetDescription(IsekaiContext, VoidBarrierDescription);
                bp.m_Icon = Icon_VoidBarrier;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { VoidBarrierAbility.ToReference<BlueprintUnitFactReference>() };
                });
            });

            var BarrierSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "BarrierSelection", bp => {
                bp.SetName(IsekaiContext, "Energy Barrier");
                bp.SetDescription(IsekaiContext, "At 7th level, you are able to channel your energy to form a solid barrier to shield allies "
                    + "from physical and magical attacks.");
                bp.m_Icon = Icon_GoldBarrier;
                bp.IgnorePrerequisites = true;
                bp.m_AllFeatures = new BlueprintFeatureReference[] {
                    GoldBarrierFeature.ToReference<BlueprintFeatureReference>(),
                    VoidBarrierFeature.ToReference<BlueprintFeatureReference>(),
                };
            });
        }
    }
}