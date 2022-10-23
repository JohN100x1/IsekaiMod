using IsekaiMod.Utilities;
using IsekaiMod.Extensions;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.UnitLogic.FactLogic;

namespace IsekaiMod.Changes.Backgrounds
{
    internal class BlackRoseMatriarch
    {
        private static readonly BlueprintFeature ScytheProficiency = Resources.GetBlueprint<BlueprintFeature>("96c174b0ebca7b246b82d4bc4aac4574");

        public static void Add()
        {
            var ICON_BR = AssetLoader.LoadInternal("Backgrounds", "ICON_BLACK_ROSE.png");
            var BackgroundBlackRoseMatriarch = Helpers.CreateBlueprint<BlueprintFeature>("BackgroundBlackRoseMatriarch", bp => {
                bp.SetName("Black Rose Matriarch");
                bp.SetDescription("Black Rose Matriarch adds {g|Encyclopedia:Lore_Nature}Lore (Nature){/g}, {g|Encyclopedia:Lore_Religion}Lore (Religion){/g}, {g|Encyclopedia:Knowledge_World}Knowledge (World){/g} and {g|Encyclopedia:Knowledge_Arcana}Knowledge (Arcana){/g} " +
                    "to the list of her class {g|Encyclopedia:Skills}skills{/g}. She also becomes proficient with scythes and can use her {g|Encyclopedia:Intelligence}Intelligence{/g} instead of {g|Encyclopedia:Wisdom}Wisdom{/g} while attempting Lore (Nature) or Lore (Religion) " +
                    "{g|Encyclopedia:Check}checks{/g}.\n" +
                    "If the character already has the class skill, {g|Encyclopedia:Weapon_Proficiency}weapon proficiency{/g} or armor " +
                    "proficiency granted by the selected background from her class during character creation, then the corresponding {g|Encyclopedia:Bonus}bonuses{/g} " +
                    "from background change to a +1 competence bonus in case of skills, a +1 enhancement bonus in case of weapon proficiency and a -1 Armor {g|Encyclopedia:Check}" +
                    "Check{/g} {g|Encyclopedia:Penalty}Penalty{/g} reduction in case of armor proficiency.");
                bp.m_Icon = ICON_BR;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.m_DescriptionShort = Helpers.CreateString("BackgroundBlackRoseMatriarch.DescriptionShort", "The leader of The Black Roses, an evil syndicate of powerful women plotting to take over Golarion.");
                
                
                // Add Lore (Nature), Lore (Religion), Knowledge (World), and Knowledge (Arcana) to class skills
                bp.AddComponent<AddClassSkill>(c => {
                    c.Skill = Kingmaker.EntitySystem.Stats.StatType.SkillKnowledgeWorld;
                });
                bp.AddComponent<AddBackgroundClassSkill>(c => {
                    c.Skill = Kingmaker.EntitySystem.Stats.StatType.SkillKnowledgeWorld;
                });
                bp.AddComponent<AddClassSkill>(c => {
                    c.Skill = Kingmaker.EntitySystem.Stats.StatType.SkillKnowledgeArcana;
                });
                bp.AddComponent<AddBackgroundClassSkill>(c => {
                    c.Skill = Kingmaker.EntitySystem.Stats.StatType.SkillKnowledgeArcana;
                });
                bp.AddComponent<AddClassSkill>(c => {
                    c.Skill = Kingmaker.EntitySystem.Stats.StatType.SkillLoreReligion;
                });
                bp.AddComponent<AddBackgroundClassSkill>(c => {
                    c.Skill = Kingmaker.EntitySystem.Stats.StatType.SkillLoreReligion;
                });
                bp.AddComponent<AddClassSkill>(c => {
                    c.Skill = Kingmaker.EntitySystem.Stats.StatType.SkillLoreNature;
                });
                bp.AddComponent<AddBackgroundClassSkill>(c => {
                    c.Skill = Kingmaker.EntitySystem.Stats.StatType.SkillLoreNature;
                });


                // Add Scythe Proficiency
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] {
                        ScytheProficiency.ToReference<BlueprintUnitFactReference>(),
                    };
                });


                // Use Intelligence instead of Wisdom for Lore (Nature) and Lore (Religion) for checks
                bp.AddComponent<ReplaceStatBaseAttribute>(c => {
                    c.TargetStat = Kingmaker.EntitySystem.Stats.StatType.SkillLoreNature;
                    c.BaseAttributeReplacement = Kingmaker.EntitySystem.Stats.StatType.Intelligence;
                });
                bp.AddComponent<ReplaceStatBaseAttribute>(c => {
                    c.TargetStat = Kingmaker.EntitySystem.Stats.StatType.SkillLoreReligion;
                    c.BaseAttributeReplacement = Kingmaker.EntitySystem.Stats.StatType.Intelligence;
                });
            });
        }
    }
}
