using Kingmaker.Blueprints.Classes;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.FactLogic;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Backgrounds {

    internal class BetaTester {

        public static void Add() {
            // Background
            var BackgroundBetaTester = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "BackgroundBetaTester", bp => {
                bp.SetName(IsekaiContext, "Beta Tester");
                bp.SetDescription(IsekaiContext, "The Beta Tester has a +10 competence bonus to initiative and adds {g|Encyclopedia:Lore_Nature}Lore (Nature){/g}, "
                    + "{g|Encyclopedia:Lore_Religion}Lore (Religion){/g}, {g|Encyclopedia:Knowledge_World}Knowledge (World){/g}, {g|Encyclopedia:Knowledge_Arcana}Knowledge (Arcana){/g}, and "
                    + "{g|Encyclopedia:Perception}Perception{/g}to the list of her class {g|Encyclopedia:Skills}skills{/g}.\n"
                    + "If the character already has the class skill, {g|Encyclopedia:Weapon_Proficiency}weapon proficiency{/g} or armor proficiency granted by the selected background "
                    + "from her class during character creation, then the corresponding {g|Encyclopedia:Bonus}bonuses{/g} from background change to a +1 competence bonus in case of skills, "
                    + "a +1 enhancement bonus in case of weapon proficiency and a -1 Armor {g|Encyclopedia:Check}Check{/g} {g|Encyclopedia:Penalty}Penalty{/g} reduction in case of armor proficiency.");
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Competence;
                    c.Stat = StatType.Initiative;
                    c.Value = 10;
                });
                bp.AddComponent<AddClassSkill>(c => {
                    c.Skill = StatType.SkillKnowledgeArcana;
                });
                bp.AddComponent<AddClassSkill>(c => {
                    c.Skill = StatType.SkillKnowledgeWorld;
                });
                bp.AddComponent<AddClassSkill>(c => {
                    c.Skill = StatType.SkillLoreNature;
                });
                bp.AddComponent<AddClassSkill>(c => {
                    c.Skill = StatType.SkillLoreReligion;
                });
                bp.AddComponent<AddClassSkill>(c => {
                    c.Skill = StatType.SkillPerception;
                });
                bp.AddComponent<AddBackgroundClassSkill>(c => {
                    c.Skill = StatType.SkillKnowledgeArcana;
                });
                bp.AddComponent<AddBackgroundClassSkill>(c => {
                    c.Skill = StatType.SkillKnowledgeWorld;
                });
                bp.AddComponent<AddBackgroundClassSkill>(c => {
                    c.Skill = StatType.SkillLoreNature;
                });
                bp.AddComponent<AddBackgroundClassSkill>(c => {
                    c.Skill = StatType.SkillLoreReligion;
                });
                bp.AddComponent<AddBackgroundClassSkill>(c => {
                    c.Skill = StatType.SkillPerception;
                });
            });

            // Register Background
            IsekaiBackgroundSelection.AddToSelection(BackgroundBetaTester);
        }
    }
}