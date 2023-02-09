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
                bp.SetDescription(IsekaiContext, "The Highschool Student gains a +1 bonus to all attributes.\n"
                    + "If the character already has the class skill, {g|Encyclopedia:Weapon_Proficiency}weapon proficiency{/g} or armor proficiency granted by the selected background "
                    + "from her class during character creation, then the corresponding {g|Encyclopedia:Bonus}bonuses{/g} from background change to a +1 competence bonus in case of skills, "
                    + "a +1 enhancement bonus in case of weapon proficiency and a -1 Armor {g|Encyclopedia:Check}Check{/g} {g|Encyclopedia:Penalty}Penalty{/g} reduction in case of armor proficiency.");
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
            IsekaiBackgroundSelection.Register(BackgroundHighschoolStudent);
        }
    }
}