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
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.Utility;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.GodEmperor
{
    class ProtectiveAuraFeature
    {
        public static void Add()
        {
            var Icon_Protective_Aura = AssetLoader.LoadInternal("Features", "ICON_PROTECTIVE_AURA.png");
            var ProtectiveAuraBuff = Helpers.CreateBuff("ProtectiveAuraBuff", bp => {
                bp.SetName("Protective Aura");
                bp.SetDescription("This character has a sacred bonus to AC and saving throws equal to 1/2 the God Emporer's character level.");
                bp.IsClassFeature = true;
                bp.m_Icon = Icon_Protective_Aura;
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Sacred;
                    c.Stat = StatType.AC;
                    c.Value = new ContextValue()
                    {
                        ValueType = ContextValueType.Rank,
                        ValueRank = AbilityRankType.StatBonus
                    };
                });
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Sacred;
                    c.Stat = StatType.SaveFortitude;
                    c.Value = new ContextValue()
                    {
                        ValueType = ContextValueType.Rank,
                        ValueRank = AbilityRankType.StatBonus
                    };
                });
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Sacred;
                    c.Stat = StatType.SaveReflex;
                    c.Value = new ContextValue()
                    {
                        ValueType = ContextValueType.Rank,
                        ValueRank = AbilityRankType.StatBonus
                    };
                });
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Sacred;
                    c.Stat = StatType.SaveWill;
                    c.Value = new ContextValue()
                    {
                        ValueType = ContextValueType.Rank,
                        ValueRank = AbilityRankType.StatBonus
                    };
                });
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.StatBonus;
                    c.m_BaseValueType = ContextRankBaseValueType.CharacterLevel;
                    c.m_Progression = ContextRankProgression.Div2;
                });
            });
            var ProtectiveAuraArea = Helpers.CreateBlueprint<BlueprintAbilityAreaEffect>("ProtectiveAuraArea", bp => {
                bp.m_TargetType = BlueprintAbilityAreaEffect.TargetType.Ally;
                bp.SpellResistance = false;
                bp.AggroEnemies = false;
                bp.AffectEnemies = false;
                bp.Shape = AreaEffectShape.Cylinder;
                bp.Size = new Feet(40);
                bp.Fx = new PrefabLink();
                bp.AddComponent(AuraUtils.CreateUnconditionalAuraEffect(ProtectiveAuraBuff.ToReference<BlueprintBuffReference>()));
            });
            var ProtectiveAuraAreaBuff = Helpers.CreateBuff("ProtectiveAuraAreaBuff", bp => {
                bp.SetName("Protective Aura");
                bp.SetDescription("Allies within 40 feet of the God Emperor has a sacred bonus to AC and saving throws equal to 1/2 the God Emporer's character level.");
                bp.m_Icon = Icon_Protective_Aura;
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.HiddenInUi;
                bp.AddComponent<AddAreaEffect>(c => {
                    c.m_AreaEffect = ProtectiveAuraArea.ToReference<BlueprintAbilityAreaEffectReference>();
                });
            });
            var ProtectiveAuraAbility = Helpers.CreateBlueprint<BlueprintActivatableAbility>("ProtectiveAuraAbility", bp => {
                bp.SetName("Protective Aura");
                bp.SetDescription("Allies within 40 feet of the God Emperor has a sacred bonus to AC and saving throws equal to 1/2 the God Emporer's character level.");
                bp.m_Icon = Icon_Protective_Aura;
                bp.m_Buff = ProtectiveAuraAreaBuff.ToReference<BlueprintBuffReference>();
                bp.Group = ActivatableAbilityGroup.None;
                bp.WeightInGroup = 1;
                bp.IsOnByDefault = true;
                bp.DoNotTurnOffOnRest = true;
                bp.DeactivateImmediately = true;
                bp.ActivationType = AbilityActivationType.Immediately;
            });
            var ProtectiveAuraFeature = Helpers.CreateFeature("ProtectiveAuraFeature", bp => {
                bp.SetName("Protective Aura");
                bp.SetDescription("At 7th level, allies within 40 feet of the God Emperor has a sacred bonus to AC and saving throws equal to 1/2 the God Emporer's character level.");
                bp.m_Icon = Icon_Protective_Aura;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { ProtectiveAuraAbility.ToReference<BlueprintUnitFactReference>() };
                });
            });
        }
    }
}
