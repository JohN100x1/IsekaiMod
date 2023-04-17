using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.FactLogic;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Backgrounds {

    internal class Gamer {

        public static void Add() {
            // Background
            var BackgroundGamer = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "BackgroundGamer", bp => {
                bp.SetName(IsekaiContext, "Gamer");
                bp.SetBackgroundDescription(IsekaiContext, "The Gamer has a +8 competence bonus to all knowledge, lore, and perception checks.");
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Competence;
                    c.Stat = StatType.SkillKnowledgeWorld;
                    c.Value = 8;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Competence;
                    c.Stat = StatType.SkillKnowledgeArcana;
                    c.Value = 8;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Competence;
                    c.Stat = StatType.SkillLoreReligion;
                    c.Value = 8;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Competence;
                    c.Stat = StatType.SkillLoreNature;
                    c.Value = 8;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Competence;
                    c.Stat = StatType.SkillPerception;
                    c.Value = 8;
                });
            });

            // Register Background
            IsekaiBackgroundSelection.AddToSelection(BackgroundGamer);
        }
    }
}