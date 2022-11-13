using IsekaiMod.Utilities;
using IsekaiMod.Extensions;
using Kingmaker.Blueprints.Classes;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.EntitySystem.Stats;

namespace IsekaiMod.Content.Backgrounds
{
    internal class Otaku
    {
        public static void Add()
        {
            // Background
            var BackgroundOtaku = Helpers.CreateBlueprint<BlueprintFeature>("BackgroundOtaku", bp => {
                bp.SetName("Otaku");
                bp.SetDescription("The Otaku adds all skills to the list of her class skills except Persuasion.\n"
                    + "If the character already has the class skill, {g|Encyclopedia:Weapon_Proficiency}weapon proficiency{/g} or armor proficiency granted by the selected background "
                    + "from her class during character creation, then the corresponding {g|Encyclopedia:Bonus}bonuses{/g} from background change to a +1 competence bonus in case of skills, "
                    + "a +1 enhancement bonus in case of weapon proficiency and a -1 Armor {g|Encyclopedia:Check}Check{/g} {g|Encyclopedia:Penalty}Penalty{/g} reduction in case of armor proficiency.");
                bp.m_Icon = null;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.AddComponent<AddClassSkill>(c => {
                    c.Skill = StatType.SkillAthletics;
                });
                bp.AddComponent<AddClassSkill>(c => {
                    c.Skill = StatType.SkillMobility;
                });
                bp.AddComponent<AddClassSkill>(c => {
                    c.Skill = StatType.SkillThievery;
                });
                bp.AddComponent<AddClassSkill>(c => {
                    c.Skill = StatType.SkillStealth;
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
                bp.AddComponent<AddClassSkill>(c => {
                    c.Skill = StatType.SkillUseMagicDevice;
                });
                bp.AddComponent<AddBackgroundClassSkill>(c => {
                    c.Skill = StatType.SkillAthletics;
                });
                bp.AddComponent<AddBackgroundClassSkill>(c => {
                    c.Skill = StatType.SkillMobility;
                });
                bp.AddComponent<AddBackgroundClassSkill>(c => {
                    c.Skill = StatType.SkillThievery;
                });
                bp.AddComponent<AddBackgroundClassSkill>(c => {
                    c.Skill = StatType.SkillStealth;
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
                bp.AddComponent<AddBackgroundClassSkill>(c => {
                    c.Skill = StatType.SkillUseMagicDevice;
                });
            });

            // Register Background
            IsekaiBackgroundSelection.Register(BackgroundOtaku);
        }
    }
}
