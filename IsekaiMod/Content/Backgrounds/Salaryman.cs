using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.UnitLogic.FactLogic;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Backgrounds {

    internal class Salaryman {

        public static void Add() {
            // Background
            var BackgroundSalaryman = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "BackgroundSalaryman", bp => {
                bp.SetName(IsekaiContext, "Salaryman");
                bp.SetBackgroundDescription(IsekaiContext, "The Salaryman adds Perception to the list of her class skills. "
                    + "She can also use her Charisma instead of Wisdom while attempting Perception checks.");
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
            IsekaiBackgroundSelection.AddToSelection(BackgroundSalaryman);
        }
    }
}