using IsekaiMod.Utilities;
using IsekaiMod.Extensions;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.EntitySystem.Stats;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;
using Kingmaker.Blueprints.Classes;

namespace IsekaiMod.Content.Backgrounds
{
    internal class Salaryman
    {
        public static void Add()
        {
            // Background
            var BackgroundSalaryman = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext,"BackgroundSalaryman", bp => {
                bp.SetName(IsekaiContext, "Salaryman");
                bp.SetDescription(IsekaiContext, "The Salaryman adds Perception to the list of her class skills. She can also use her Charisma instead of Wisdom while attempting Perception checks.\n"
                    + "If the character already has the class skill, {g|Encyclopedia:Weapon_Proficiency}weapon proficiency{/g} or armor proficiency granted by the selected background "
                    + "from her class during character creation, then the corresponding {g|Encyclopedia:Bonus}bonuses{/g} from background change to a +1 competence bonus in case of skills, "
                    + "a +1 enhancement bonus in case of weapon proficiency and a -1 Armor {g|Encyclopedia:Check}Check{/g} {g|Encyclopedia:Penalty}Penalty{/g} reduction in case of armor proficiency.");
                bp.AddComponent<AddClassSkill>(c => {
                    c.Skill = StatType.SkillPerception;
                });
                bp.AddComponent<AddBackgroundClassSkill>(c => {
                    c.Skill = StatType.SkillPerception;
                });
                bp.AddComponent<ReplaceStatBaseAttribute>(c => {
                    c.TargetStat = StatType.SkillPerception;
                    c.BaseAttributeReplacement = StatType.Charisma;
                });
            });

            // Register Background
            IsekaiBackgroundSelection.Register(BackgroundSalaryman);
        }
    }
}
