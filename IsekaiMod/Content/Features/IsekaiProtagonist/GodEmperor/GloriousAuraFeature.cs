using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
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

namespace IsekaiMod.Content.Features.IsekaiProtagonist.GodEmperor
{
    class GloriousAuraFeature
    {
        public static void Add()
        {
            var Icon_Glorious_Aura = AssetLoader.LoadInternal("Features", "ICON_GLORIOUS_AURA.png");
            var GloriousAuraBuff = Helpers.CreateBlueprint<BlueprintBuff>("GloriousAuraBuff", bp => {
                bp.SetName("Glorious Aura");
                bp.SetDescription("This character has a competence bonus on attack {g|Encyclopedia:Dice}rolls{/g} and caster level checks made to overcome spell resistance equal to 1/2 the God Emporer's character level.");
                bp.IsClassFeature = true;
                bp.m_Icon = Icon_Glorious_Aura;
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Competence;
                    c.Stat = StatType.AdditionalAttackBonus;
                    c.Value = new ContextValue()
                    {
                        ValueType = ContextValueType.Rank,
                        ValueRank = AbilityRankType.StatBonus
                    };
                });
                bp.AddComponent<SpellPenetrationBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Competence;
                    c.CheckFact = false;
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
                bp.FxOnStart = new PrefabLink();
                bp.FxOnRemove = new PrefabLink();
            });
            var GloriousAuraArea = Helpers.CreateBlueprint<BlueprintAbilityAreaEffect>("GloriousAuraArea", bp => {
                bp.m_TargetType = BlueprintAbilityAreaEffect.TargetType.Ally;
                bp.SpellResistance = false;
                bp.AggroEnemies = false;
                bp.AffectEnemies = false;
                bp.Shape = AreaEffectShape.Cylinder;
                bp.Size = new Feet() { m_Value = 40 };
                bp.Fx = new PrefabLink();
                bp.AddComponent(AuraUtils.CreateUnconditionalAuraEffect(GloriousAuraBuff.ToReference<BlueprintBuffReference>()));
            });
            var GloriousAuraAreaBuff = Helpers.CreateBlueprint<BlueprintBuff>("GloriousAuraAreaBuff", bp => {
                bp.SetName("Glorious Aura");
                bp.SetDescription("Allies within 40 feet of the God Emperor gain a competence bonus on attack {g|Encyclopedia:Dice}rolls{/g} and caster level checks made to overcome spell resistance equal to 1/2 the God Emporer's character level.");
                bp.m_Icon = Icon_Glorious_Aura;
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.HiddenInUi;
                bp.AddComponent<AddAreaEffect>(c => {
                    c.m_AreaEffect = GloriousAuraArea.ToReference<BlueprintAbilityAreaEffectReference>();
                });
                bp.FxOnStart = new PrefabLink();
                bp.FxOnRemove = new PrefabLink();
            });
            var GloriousAuraAbility = Helpers.CreateBlueprint<BlueprintActivatableAbility>("GloriousAuraAbility", bp => {
                bp.SetName("Glorious Aura");
                bp.SetDescription("Allies within 40 feet of the God Emperor gain a competence bonus on attack {g|Encyclopedia:Dice}rolls{/g} and caster level checks made to overcome spell resistance equal to 1/2 the God Emporer's character level.");
                bp.m_Icon = Icon_Glorious_Aura;
                bp.m_Buff = GloriousAuraAreaBuff.ToReference<BlueprintBuffReference>();
                bp.Group = ActivatableAbilityGroup.None;
                bp.WeightInGroup = 1;
                bp.IsOnByDefault = true;
                bp.DoNotTurnOffOnRest = true;
                bp.DeactivateImmediately = true;
                bp.ActivationType = AbilityActivationType.Immediately;
            });
            var GloriousAuraFeature = Helpers.CreateBlueprint<BlueprintFeature>("GloriousAuraFeature", bp => {
                bp.SetName("Glorious Aura");
                bp.SetDescription("At 9th level, allies within 40 feet of the God Emperor gain a competence bonus on attack {g|Encyclopedia:Dice}rolls{/g} and caster level checks made to overcome spell resistance equal to 1/2 the God Emporer's character level.");
                bp.m_Icon = Icon_Glorious_Aura;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { GloriousAuraAbility.ToReference<BlueprintUnitFactReference>() };
                });
            });
        }
    }
}
