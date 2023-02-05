using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.ResourceLinks;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Buffs.Components;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.Utility;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.GodEmperor
{
    class AuraOfGoldenProtection
    {
        public static void Add()
        {
            var Icon_AuraOfGoldenProtection = AssetLoader.LoadInternal(IsekaiContext, "Features", "ICON_AURA_GOLDEN_PROTECTION.png");
            var AuraOfGoldenProtectionBuff = ThingsNotHandledByTTTCore.CreateBuff("AuraOfGoldenProtectionBuff", bp => {
                bp.SetName(IsekaiContext, "Aura of Golden Protection");
                bp.SetDescription(IsekaiContext, "This character has a sacred bonus to AC and saving throws equal to 1/2 the God Emperor's character level.");
                bp.IsClassFeature = true;
                bp.m_Icon = Icon_AuraOfGoldenProtection;
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
            var AuraOfGoldenProtectionArea = Helpers.CreateBlueprint<BlueprintAbilityAreaEffect>(IsekaiContext, "AuraOfGoldenProtectionArea", bp => {
                bp.m_TargetType = BlueprintAbilityAreaEffect.TargetType.Ally;
                bp.Shape = AreaEffectShape.Cylinder;
                bp.Size = new Feet(40);
                bp.Fx = new PrefabLink();
                bp.AddComponent(AuraUtils.CreateUnconditionalAuraEffect(AuraOfGoldenProtectionBuff.ToReference<BlueprintBuffReference>()));
            });
            var AuraOfGoldenProtectionAreaBuff = ThingsNotHandledByTTTCore.CreateBuff("AuraOfGoldenProtectionAreaBuff", bp => {
                bp.SetName(IsekaiContext, "Aura of Golden Protection");
                bp.SetDescription(IsekaiContext, "Allies within 40 feet of the God Emperor has a sacred bonus to AC and saving throws equal to 1/2 the God Emperor's character level.");
                bp.m_Icon = Icon_AuraOfGoldenProtection;
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.HiddenInUi;
                bp.AddComponent<AddAreaEffect>(c => {
                    c.m_AreaEffect = AuraOfGoldenProtectionArea.ToReference<BlueprintAbilityAreaEffectReference>();
                });
            });
            var AuraOfGoldenProtectionAbility = Helpers.CreateBlueprint<BlueprintActivatableAbility>(IsekaiContext, "AuraOfGoldenProtectionAbility", bp => {
                bp.SetName(IsekaiContext, "Aura of Golden Protection");
                bp.SetDescription(IsekaiContext, "Allies within 40 feet of the God Emperor has a sacred bonus to AC and saving throws equal to 1/2 the God Emperor's character level.");
                bp.m_Icon = Icon_AuraOfGoldenProtection;
                bp.m_Buff = AuraOfGoldenProtectionAreaBuff.ToReference<BlueprintBuffReference>();
                bp.DoNotTurnOffOnRest = true;
            });
            var AuraOfGoldenProtectionFeature = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext ,"AuraOfGoldenProtectionFeature", bp => {
                bp.SetName(IsekaiContext, "Aura of Golden Protection");
                bp.SetDescription(IsekaiContext, "At 7th level, allies within 40 feet of the God Emperor has a sacred bonus to AC and saving throws equal to 1/2 the God Emperor's character level.");
                bp.m_Icon = Icon_AuraOfGoldenProtection;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { AuraOfGoldenProtectionAbility.ToReference<BlueprintUnitFactReference>() };
                });
            });
        }
    }
}
