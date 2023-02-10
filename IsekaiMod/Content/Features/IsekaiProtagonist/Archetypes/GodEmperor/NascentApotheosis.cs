using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics.Components;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.GodEmperor {

    internal class NascentApotheosis {

        public static void Add() {
            var Icon_Serenity = BlueprintTools.GetBlueprint<BlueprintAbility>("d316d3d94d20c674db2c24d7de96f6a7").m_Icon;
            var NascentApotheosis = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "NascentApotheosis", bp => {
                bp.SetName(IsekaiContext, "Nascent Apotheosis");
                bp.SetDescription(IsekaiContext, "The God Emperor gains an inherent bonus to all attributes and spell penetration equal to 1/2 their character level and "
                    + "{g|Encyclopedia:Damage_Reduction}DR{/g}/— equal to their character level.");
                bp.m_Icon = Icon_Serenity;
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Inherent;
                    c.Stat = StatType.Strength;
                    c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                });
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Inherent;
                    c.Stat = StatType.Dexterity;
                    c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                });
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Inherent;
                    c.Stat = StatType.Constitution;
                    c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                });
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Inherent;
                    c.Stat = StatType.Intelligence;
                    c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                });
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Inherent;
                    c.Stat = StatType.Wisdom;
                    c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                });
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Inherent;
                    c.Stat = StatType.Charisma;
                    c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                });
                bp.AddComponent<SpellPenetrationBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Inherent;
                    c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                });
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.StatBonus;
                    c.m_BaseValueType = ContextRankBaseValueType.CharacterLevel;
                    c.m_Progression = ContextRankProgression.Div2;
                });
                bp.AddComponent<AddDamageResistancePhysical>(c => {
                    c.Value = Values.CreateContextRankValue(AbilityRankType.Default);
                });
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.Default;
                    c.m_BaseValueType = ContextRankBaseValueType.CharacterLevel;
                });
                bp.ReapplyOnLevelUp = true;
            });
        }
    }
}