using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
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

    internal class AuraOfMajesty {

        public static void Add() {
            var Icon_AuraOfMajesty = AssetLoader.LoadInternal(IsekaiContext, "Features", "ICON_AURA_MAJESTY.png");
            var AuraOfMajestyBuff = ThingsNotHandledByTTTCore.CreateBuff("AuraOfMajestyBuff", bp => {
                bp.SetName(IsekaiContext, "Aura of Majesty");
                bp.SetDescription(IsekaiContext, "This character has a sacred bonus to all attributes equal to 1/2 the God Emperor's character level.");
                bp.IsClassFeature = true;
                bp.m_Icon = Icon_AuraOfMajesty;
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Sacred;
                    c.Stat = StatType.Strength;
                    c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                });
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Sacred;
                    c.Stat = StatType.Dexterity;
                    c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                });
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Sacred;
                    c.Stat = StatType.Constitution;
                    c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                });
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Sacred;
                    c.Stat = StatType.Intelligence;
                    c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                });
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Sacred;
                    c.Stat = StatType.Wisdom;
                    c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                });
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Sacred;
                    c.Stat = StatType.Charisma;
                    c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                });
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.StatBonus;
                    c.m_BaseValueType = ContextRankBaseValueType.CharacterLevel;
                    c.m_Progression = ContextRankProgression.Div2;
                });
            });
            var AuraOfMajestyArea = Helpers.CreateBlueprint<BlueprintAbilityAreaEffect>(IsekaiContext, "AuraOfMajestyArea", bp => {
                bp.m_TargetType = BlueprintAbilityAreaEffect.TargetType.Ally;
                bp.SpellResistance = false;
                bp.AggroEnemies = false;
                bp.AffectEnemies = false;
                bp.Shape = AreaEffectShape.Cylinder;
                bp.Size = new Feet(40);
                bp.Fx = new PrefabLink();
                bp.AddComponent(AuraUtils.CreateUnconditionalAuraEffect(AuraOfMajestyBuff.ToReference<BlueprintBuffReference>()));
            });
            var AuraOfMajestyAreaBuff = ThingsNotHandledByTTTCore.CreateBuff("AuraOfMajestyAreaBuff", bp => {
                bp.SetName(IsekaiContext, "Aura of Majesty");
                bp.SetDescription(IsekaiContext, "Allies within 40 feet of the God Emperor gain a sacred bonus to all attributes equal to 1/2 the God Emperor's character level.");
                bp.m_Icon = Icon_AuraOfMajesty;
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.HiddenInUi;
                bp.AddComponent<AddAreaEffect>(c => {
                    c.m_AreaEffect = AuraOfMajestyArea.ToReference<BlueprintAbilityAreaEffectReference>();
                });
            });
            var AuraOfMajestyAbility = ThingsNotHandledByTTTCore.CreateActivatableAbility("AuraOfMajestyAbility", bp => {
                bp.SetName(IsekaiContext, "Aura of Majesty");
                bp.SetDescription(IsekaiContext, "Allies within 40 feet of the God Emperor gain a +4 sacred bonus to all attributes.");
                bp.m_Icon = Icon_AuraOfMajesty;
                bp.m_Buff = AuraOfMajestyAreaBuff.ToReference<BlueprintBuffReference>();
                bp.DoNotTurnOffOnRest = true;
            });
            var AuraOfMajestyFeature = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "AuraOfMajestyFeature", bp => {
                bp.SetName(IsekaiContext, "Aura of Majesty");
                bp.SetDescription(IsekaiContext, "At 9th level, allies within 40 feet of the God Emperor gain a sacred bonus to all attributes equal to 1/2 the God Emperor's character level.");
                bp.m_Icon = Icon_AuraOfMajesty;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { AuraOfMajestyAbility.ToReference<BlueprintUnitFactReference>() };
                });
            });
        }
    }
}