using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.FactLogic;
using TabletopTweaks.Core.Utilities;
using UnityEngine;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist {

    internal class Gifted {
        private static readonly string Name = "Gifted";
        private static readonly string Description = "You are an actual prodigal genius, and every action you take is a calculated move "
            + "in your 1000 year plan.\nYou gain a +4 competence bonus to all skills and you always take the higher of two d20 rolls.";

        private static readonly Sprite Icon_Gifted = AssetLoader.LoadInternal(IsekaiContext, "Features", "ICON_GIFTED.png");

        public static void Add() {
            var Gifted = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "Gifted", bp => {
                bp.SetName(IsekaiContext, Name);
                bp.SetDescription(IsekaiContext, Description);
                bp.m_Icon = Icon_Gifted;
                bp.AddComponent<ModifyD20>(c => {
                    c.Rule = RuleType.All;
                    c.RollsAmount = 1;
                    c.TakeBest = true;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Competence;
                    c.Stat = StatType.SkillAthletics;
                    c.Value = 4;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Competence;
                    c.Stat = StatType.SkillMobility;
                    c.Value = 4;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Competence;
                    c.Stat = StatType.SkillThievery;
                    c.Value = 4;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Competence;
                    c.Stat = StatType.SkillStealth;
                    c.Value = 4;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Competence;
                    c.Stat = StatType.SkillKnowledgeArcana;
                    c.Value = 4;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Competence;
                    c.Stat = StatType.SkillKnowledgeWorld;
                    c.Value = 4;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Competence;
                    c.Stat = StatType.SkillLoreNature;
                    c.Value = 4;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Competence;
                    c.Stat = StatType.SkillLoreReligion;
                    c.Value = 4;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Competence;
                    c.Stat = StatType.SkillPerception;
                    c.Value = 4;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Competence;
                    c.Stat = StatType.SkillPersuasion;
                    c.Value = 4;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Competence;
                    c.Stat = StatType.SkillUseMagicDevice;
                    c.Value = 4;
                });
            });
        }
    }
}