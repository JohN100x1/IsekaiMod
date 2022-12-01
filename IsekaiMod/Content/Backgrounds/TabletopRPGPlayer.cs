using IsekaiMod.Utilities;
using IsekaiMod.Extensions;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.EntitySystem.Stats;

namespace IsekaiMod.Content.Backgrounds
{
    internal class TabletopRPGPlayer
    {
        public static void Add()
        {
            // Background
            var BackgroundTabletopRPGPlayer = Helpers.CreateFeature("BackgroundTabletopRPGPlayer", bp => {
                bp.SetName("Tabletop RPG Player");
                bp.SetDescription("The Tabletop RPG Player adds {g|Encyclopedia:Lore_Nature}Lore (Nature){/g}, {g|Encyclopedia:Lore_Religion}Lore (Religion){/g}, "
                    + "{g|Encyclopedia:Knowledge_World}Knowledge (World){/g} and {g|Encyclopedia:Knowledge_Arcana}Knowledge (Arcana){/g} to the list of her class {g|Encyclopedia:Skills}skills{/g} "
                    + "and can use her {g|Encyclopedia:Charisma}Charisma{/g} instead of {g|Encyclopedia:Intelligence}Intelligence{/g} or {g|Encyclopedia:Wisdom}Wisdom{/g} while attempting "
                    + "Knowledge (World), Knowledge (Arcana), Lore (Religion), or Lore (Nature) {g|Encyclopedia:Check}checks{/g}.\n"
                    + "If the character already has the class skill, {g|Encyclopedia:Weapon_Proficiency}weapon proficiency{/g} or armor proficiency granted by the selected background "
                    + "from her class during character creation, then the corresponding {g|Encyclopedia:Bonus}bonuses{/g} from background change to a +1 competence bonus in case of skills, "
                    + "a +1 enhancement bonus in case of weapon proficiency and a -1 Armor {g|Encyclopedia:Check}Check{/g} {g|Encyclopedia:Penalty}Penalty{/g} reduction in case of armor proficiency.");
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
            IsekaiBackgroundSelection.Register(BackgroundTabletopRPGPlayer);
        }
    }
}
