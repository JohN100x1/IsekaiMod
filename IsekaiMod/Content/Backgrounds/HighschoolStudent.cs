using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.FactLogic;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Backgrounds {

    internal class HighschoolStudent {

        public static void Add() {
            // Background
            var BackgroundHighschoolStudent = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "BackgroundHighschoolStudent", bp => {
                bp.SetName(IsekaiContext, "Highschool Student");
                bp.SetBackgroundDescription(IsekaiContext, "The Highschool Student gains a +1 bonus to all attributes.");
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Trait;
                    c.Stat = StatType.Strength;
                    c.Value = 1;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Trait;
                    c.Stat = StatType.Dexterity;
                    c.Value = 1;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Trait;
                    c.Stat = StatType.Constitution;
                    c.Value = 1;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Trait;
                    c.Stat = StatType.Intelligence;
                    c.Value = 1;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Trait;
                    c.Stat = StatType.Wisdom;
                    c.Value = 1;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Trait;
                    c.Stat = StatType.Charisma;
                    c.Value = 1;
                });
            });

            // Register Background
            IsekaiBackgroundSelection.AddToSelection(BackgroundHighschoolStudent);
        }
    }
}