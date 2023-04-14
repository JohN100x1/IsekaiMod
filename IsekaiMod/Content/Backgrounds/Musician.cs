using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.FactLogic;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Backgrounds {

    internal class Musician {

        public static void Add() {
            // Background
            var BackgroundMusician = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "BackgroundMusician", bp => {
                bp.SetName(IsekaiContext, "Musician");
                bp.SetBackgroundDescription(IsekaiContext, "The Musician add Persuasion to the list of her class skills and "
                    + "has a +2 bonus to caster level and DC for Sonic spells.");
                bp.AddComponent<AddClassSkill>(c => {
                    c.Skill = StatType.SkillPersuasion;
                });
                bp.AddComponent<AddBackgroundClassSkill>(c => {
                    c.Skill = StatType.SkillPersuasion;
                });
                bp.AddComponent<IncreaseSpellDescriptorCasterLevel>(c => {
                    c.Descriptor = SpellDescriptor.Sonic;
                    c.BonusCasterLevel = 2;
                    c.ModifierDescriptor = ModifierDescriptor.UntypedStackable;
                });
                bp.AddComponent<IncreaseSpellDescriptorDC>(c => {
                    c.Descriptor = SpellDescriptor.Sonic;
                    c.BonusDC = 2;
                    c.ModifierDescriptor = ModifierDescriptor.UntypedStackable;
                });
            });

            // Register Background
            IsekaiBackgroundSelection.AddToSelection(BackgroundMusician);
        }
    }
}