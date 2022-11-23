using IsekaiMod.Utilities;
using IsekaiMod.Extensions;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.UnitLogic.ActivatableAbilities;

namespace IsekaiMod.Content.Heritages.IsekaiSpriggan
{
    internal class IsekaiSprigganHeritage
    {
        public static void Add()
        {
            // Spriggan Abilities
            var SizeAlterationAbility = Resources.GetModBlueprint<BlueprintActivatableAbility>("SizeAlterationAbility");

            // Spriggan Heritage
            var Icon_Spriggan = AssetLoader.LoadInternal("Heritages", "ICON_SPRIGGAN.png");
            var IsekaiSprigganHeritage = Helpers.CreateBlueprint<BlueprintFeature>("IsekaiSprigganHeritage", bp => {
                bp.SetName("Isekai Spriggan");
                bp.SetDescription("Otherworldly entities who are reincarnated into the world of Golarion as a Spriggan have both extreme beauty and power. "
                    + "Their shape changing abilities allow them to easily defeat everyone who would underestimate their power.\n"
                    + "The Isekai Spriggan gains a +1 racial bonus on concentration checks and on the {g|Encyclopedia:DC}DC{/g} of all "
                    + "{g|Encyclopedia:Spell}spells{/g} they cast. "
                    + "They add Athletics, Trickery, Stealth, and Perception to the list of their class skills. "
                    + "They are also able to use the Size alteration ability to increase their size by two size categories and gain +10 Speed, +12 Strength, -2 Dexterity, +6 Constitution, "
                    + "and a -2 penalty to AC.");
                bp.m_Icon = Icon_Spriggan;
                bp.Ranks = 1;
                bp.IsClassFeature = true;

                bp.AddComponent<ConcentrationBonus>(c => {
                    c.CheckFact = false;
                    c.Value = 1;
                });
                bp.AddComponent<IncreaseAllSpellsDC>(c => {
                    c.Value = 1;
                    c.Descriptor = ModifierDescriptor.Racial;
                });

                bp.AddComponent<AddClassSkill>(c => {
                    c.Skill = StatType.SkillAthletics;
                });
                bp.AddComponent<AddClassSkill>(c => {
                    c.Skill = StatType.SkillThievery;
                });
                bp.AddComponent<AddClassSkill>(c => {
                    c.Skill = StatType.SkillStealth;
                });
                bp.AddComponent<AddClassSkill>(c => {
                    c.Skill = StatType.SkillPerception;
                });

                // Add Abilities
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] {
                        SizeAlterationAbility.ToReference<BlueprintUnitFactReference>()
                    };
                });

                bp.Groups = new FeatureGroup[0];
            });

            // Add to Gnome Heritage Selection
            var GnomeHeritageSelection = Resources.GetBlueprint<BlueprintFeatureSelection>("584d8b50817b49b2bb7aab3d6add8d3a");
            GnomeHeritageSelection.m_AllFeatures = GnomeHeritageSelection.m_AllFeatures.AddToArray(IsekaiSprigganHeritage.ToReference<BlueprintFeatureReference>());
        }
    }
}
