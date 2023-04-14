using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.UnitLogic.FactLogic;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Backgrounds {

    internal class TabletopRPGPlayer {

        public static void Add() {
            // Background
            var BackgroundTabletopRPGPlayer = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "BackgroundTabletopRPGPlayer", bp => {
                bp.SetName(IsekaiContext, "Tabletop RPG Player");
                bp.SetBackgroundDescription(IsekaiContext, "The Tabletop RPG Player adds {g|Encyclopedia:Lore_Nature}Lore (Nature){/g}, "
                    + "{g|Encyclopedia:Lore_Religion}Lore (Religion){/g}, {g|Encyclopedia:Knowledge_World}Knowledge (World){/g} and "
                    + "{g|Encyclopedia:Knowledge_Arcana}Knowledge (Arcana){/g} to the list of her class {g|Encyclopedia:Skills}skills{/g} "
                    + "and can use her {g|Encyclopedia:Charisma}Charisma{/g} instead of {g|Encyclopedia:Intelligence}Intelligence{/g} or "
                    + "{g|Encyclopedia:Wisdom}Wisdom{/g} while attempting Knowledge (World), Knowledge (Arcana), Lore (Religion), or Lore (Nature) "
                    + "{g|Encyclopedia:Check}checks{/g}.");
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
                bp.AddComponent<ReplaceStatBaseAttribute>(c => {
                    c.TargetStat = StatType.SkillKnowledgeWorld;
                    c.BaseAttributeReplacement = StatType.Charisma;
                });
                bp.AddComponent<ReplaceStatBaseAttribute>(c => {
                    c.TargetStat = StatType.SkillKnowledgeArcana;
                    c.BaseAttributeReplacement = StatType.Charisma;
                });
                bp.AddComponent<ReplaceStatBaseAttribute>(c => {
                    c.TargetStat = StatType.SkillLoreReligion;
                    c.BaseAttributeReplacement = StatType.Charisma;
                });
                bp.AddComponent<ReplaceStatBaseAttribute>(c => {
                    c.TargetStat = StatType.SkillLoreNature;
                    c.BaseAttributeReplacement = StatType.Charisma;
                });
            });

            // Register Background
            IsekaiBackgroundSelection.AddToSelection(BackgroundTabletopRPGPlayer);
        }
    }
}