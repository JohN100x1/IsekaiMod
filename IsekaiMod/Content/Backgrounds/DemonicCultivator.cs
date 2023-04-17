using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.UnitLogic.FactLogic;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Backgrounds {

    internal class DemonicCultivator {

        public static void Add() {
            // Background
            var BackgroundDemonicCultivator = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "BackgroundDemonicCultivator", bp => {
                bp.SetName(IsekaiContext, "Demonic Cultivator");
                bp.SetBackgroundDescription(IsekaiContext, "The Demonic Cultivator adds Athletics and Mobility to the list of her class skills and "
                    + "uses the higher of Strength and Dexterity while attempting Athletics and Mobility Checks.");
                bp.AddComponent<AddClassSkill>(c => {
                    c.Skill = StatType.SkillAthletics;
                });
                bp.AddComponent<AddClassSkill>(c => {
                    c.Skill = StatType.SkillMobility;
                });
                bp.AddComponent<AddBackgroundClassSkill>(c => {
                    c.Skill = StatType.SkillAthletics;
                });
                bp.AddComponent<AddBackgroundClassSkill>(c => {
                    c.Skill = StatType.SkillMobility;
                });
                bp.AddComponent<ReplaceStatBaseAttribute>(c => {
                    c.TargetStat = StatType.SkillAthletics;
                    c.BaseAttributeReplacement = StatType.Dexterity;
                    c.ReplaceIfHigher = true;
                });
                bp.AddComponent<ReplaceStatBaseAttribute>(c => {
                    c.TargetStat = StatType.SkillMobility;
                    c.BaseAttributeReplacement = StatType.Strength;
                    c.ReplaceIfHigher = true;
                });
            });

            // Register Background
            IsekaiBackgroundSelection.AddToSelection(BackgroundDemonicCultivator);
        }
    }
}