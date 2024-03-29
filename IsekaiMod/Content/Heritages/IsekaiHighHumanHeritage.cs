﻿using Kingmaker.Blueprints.Classes;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.FactLogic;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Heritages {
    internal class IsekaiHighHumanHeritage {

        public static void Add() {
            var ourHeritage = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiHighHumanHeritage", bp => {
                bp.SetName(IsekaiContext, "Isekai High Human");
                bp.SetDescription(IsekaiContext,
                    "Otherworldly entities who are reincarnated into the world of Golarion as a High Human have both extreme beauty and power. "
                    + "They possess exceptional drive and a great capacity to endure and expand.\n"
                    + "The Isekai High Humans have a +2 racial bonus to all attributes.");

                // Attributes
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Racial;
                    c.Stat = StatType.Dexterity;
                    c.Value = 2;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Racial;
                    c.Stat = StatType.Strength;
                    c.Value = 2;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Racial;
                    c.Stat = StatType.Constitution;
                    c.Value = 2;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Racial;
                    c.Stat = StatType.Intelligence;
                    c.Value = 2;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Racial;
                    c.Stat = StatType.Wisdom;
                    c.Value = 2;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Racial;
                    c.Stat = StatType.Charisma;
                    c.Value = 2;
                });

                bp.Groups = new FeatureGroup[0];
                bp.ReapplyOnLevelUp = true;
            });

            HumanHeritageSelection.Register(ourHeritage);
        }
    }
}
