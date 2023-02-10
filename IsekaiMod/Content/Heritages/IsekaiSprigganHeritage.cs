using HarmonyLib;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Designers.Mechanics.Buffs;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Buffs.Components;
using Kingmaker.UnitLogic.Commands.Base;
using Kingmaker.UnitLogic.FactLogic;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Heritages {

    internal class IsekaiSprigganHeritage {

        public static void Add() {
            // Spriggan Abilities
            var Icon_Spriggan = AssetLoader.LoadInternal(IsekaiContext, "Heritages", "ICON_SPRIGGAN.png");
            var SizeAlterationBuff = ThingsNotHandledByTTTCore.CreateBuff("SizeAlterationBuff", bp => {
                bp.SetName(IsekaiContext, "Size Alteration");
                bp.SetDescription(IsekaiContext, "This creature's size is increased by two size categories and they gain +10 Speed, +12 Strength, -2 Dexterity, +6 Constitution, and a -2 penalty to AC.");
                bp.m_Icon = Icon_Spriggan;
                bp.AddComponent<ChangeUnitSize>(c => {
                    c.m_Type = ChangeUnitSize.ChangeType.Delta;
                    c.SizeDelta = 2;
                    c.Size = Size.Fine;
                });
                bp.AddComponent<AddGenericStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Size;
                    c.Stat = StatType.Speed;
                    c.Value = 10;
                });
                bp.AddComponent<AddGenericStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Size;
                    c.Stat = StatType.Strength;
                    c.Value = 12;
                });
                bp.AddComponent<AddGenericStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Size;
                    c.Stat = StatType.Dexterity;
                    c.Value = -2;
                });
                bp.AddComponent<AddGenericStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Size;
                    c.Stat = StatType.Constitution;
                    c.Value = 6;
                });
                bp.AddComponent<AddGenericStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Penalty;
                    c.Stat = StatType.AC;
                    c.Value = -2;
                });
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.StayOnDeath;
            });
            var SizeAlterationAbility = ThingsNotHandledByTTTCore.CreateActivatableAbility("SizeAlterationAbility", bp => {
                bp.SetName(IsekaiContext, "Size Alteration");
                bp.SetDescription(IsekaiContext, "As a standard action, increase your size by two size categories and gain +10 Speed, +12 Strength, -2 Dexterity, +6 Constitution, and a -2 penalty to AC.");
                bp.m_Icon = Icon_Spriggan;
                bp.m_Buff = SizeAlterationBuff.ToReference<BlueprintBuffReference>();
                bp.ActivationType = AbilityActivationType.WithUnitCommand;
                bp.m_ActivateWithUnitCommand = UnitCommand.CommandType.Standard;
            });

            // Spriggan Heritage
            var IsekaiSprigganHeritage = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiSprigganHeritage", bp => {
                bp.SetName(IsekaiContext, "Isekai Spriggan");
                bp.SetDescription(IsekaiContext, "Otherworldly entities who are reincarnated into the world of Golarion as a Spriggan have both extreme beauty and power. "
                    + "Their shape changing abilities allow them to easily defeat everyone who would underestimate their power.\n"
                    + "The Isekai Spriggan gains a +1 racial bonus on concentration checks and on the {g|Encyclopedia:DC}DC{/g} of all "
                    + "{g|Encyclopedia:Spell}spells{/g} they cast. "
                    + "They add Athletics, Trickery, Stealth, and Perception to the list of their class skills. "
                    + "They are also able to use the Size alteration ability to increase their size by two size categories and gain +10 Speed, +12 Strength, -2 Dexterity, +6 Constitution, "
                    + "and a -2 penalty to AC.");
                bp.m_Icon = Icon_Spriggan;

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
            var GnomeHeritageSelection = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("584d8b50817b49b2bb7aab3d6add8d3a");
            GnomeHeritageSelection.m_AllFeatures = GnomeHeritageSelection.m_AllFeatures.AddToArray(IsekaiSprigganHeritage.ToReference<BlueprintFeatureReference>());
        }
    }
}