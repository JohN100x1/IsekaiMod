using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.UnitLogic.FactLogic;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Backgrounds {

    internal class EnlightenedSage {

        public static void Add() {
            // Background
            var BackgroundEnlightenedSage = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "BackgroundEnlightenedSage", bp => {
                bp.SetName(IsekaiContext, "Enlightened Sage");
                bp.SetBackgroundDescription(IsekaiContext, "The Enlightened Sage adds {g|Encyclopedia:Lore_Nature}Lore (Nature){/g}, "
                    + "{g|Encyclopedia:Lore_Religion}Lore (Religion){/g}, {g|Encyclopedia:Knowledge_World}Knowledge (World){/g}, "
                    + "{g|Encyclopedia:Knowledge_Arcana}Knowledge (Arcana){/g}, and {g|Encyclopedia:Perception}Perception{/g} to the list of "
                    + "her class {g|Encyclopedia:Skills}skills{/g} and can use the higher of {g|Encyclopedia:Intelligence}Intelligence{/g} and "
                    + "{g|Encyclopedia:Wisdom}Wisdom{/g} while attempting Knowledge (World), Knowledge (Arcana), Lore (Religion), "
                    + "or Lore (Nature) {g|Encyclopedia:Check}checks{/g}.");
                bp.AddComponent<AddClassSkill>(c => {
                    c.Skill = StatType.SkillKnowledgeWorld;
                });
                bp.AddComponent<AddClassSkill>(c => {
                    c.Skill = StatType.SkillKnowledgeArcana;
                });
                bp.AddComponent<AddClassSkill>(c => {
                    c.Skill = StatType.SkillLoreReligion;
                });
                bp.AddComponent<AddClassSkill>(c => {
                    c.Skill = StatType.SkillLoreNature;
                });
                bp.AddComponent<AddClassSkill>(c => {
                    c.Skill = StatType.SkillPerception;
                });
                bp.AddComponent<AddBackgroundClassSkill>(c => {
                    c.Skill = StatType.SkillKnowledgeWorld;
                });
                bp.AddComponent<AddBackgroundClassSkill>(c => {
                    c.Skill = StatType.SkillKnowledgeArcana;
                });
                bp.AddComponent<AddBackgroundClassSkill>(c => {
                    c.Skill = StatType.SkillLoreReligion;
                });
                bp.AddComponent<AddBackgroundClassSkill>(c => {
                    c.Skill = StatType.SkillLoreNature;
                });
                bp.AddComponent<AddBackgroundClassSkill>(c => {
                    c.Skill = StatType.SkillPerception;
                });
                bp.AddComponent<ReplaceStatBaseAttribute>(c => {
                    c.TargetStat = StatType.SkillKnowledgeWorld;
                    c.BaseAttributeReplacement = StatType.Wisdom;
                    c.ReplaceIfHigher = true;
                });
                bp.AddComponent<ReplaceStatBaseAttribute>(c => {
                    c.TargetStat = StatType.SkillKnowledgeArcana;
                    c.BaseAttributeReplacement = StatType.Wisdom;
                    c.ReplaceIfHigher = true;
                });
                bp.AddComponent<ReplaceStatBaseAttribute>(c => {
                    c.TargetStat = StatType.SkillLoreReligion;
                    c.BaseAttributeReplacement = StatType.Intelligence;
                    c.ReplaceIfHigher = true;
                });
                bp.AddComponent<ReplaceStatBaseAttribute>(c => {
                    c.TargetStat = StatType.SkillLoreNature;
                    c.BaseAttributeReplacement = StatType.Intelligence;
                    c.ReplaceIfHigher = true;
                });
                bp.AddComponent<ReplaceStatBaseAttribute>(c => {
                    c.TargetStat = StatType.SkillPerception;
                    c.BaseAttributeReplacement = StatType.Intelligence;
                    c.ReplaceIfHigher = true;
                });
            });

            // Register Background
            IsekaiBackgroundSelection.AddToSelection(BackgroundEnlightenedSage);
        }
    }
}