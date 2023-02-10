using Kingmaker.Blueprints.Classes;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using TabletopTweaks.Core.Utilities;
using UnityEngine;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.SpecialPower {

    internal class TrainingMontage {
        private static readonly Sprite Icon_LegendaryProportions = BlueprintTools.GetBlueprint<BlueprintAbility>("da1b292d91ba37948893cdbe9ea89e28").m_Icon;

        public static void Add() {
            var TrainingMontage = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "TrainingMontage", bp => {
                bp.SetName(IsekaiContext, "Training Montage");
                bp.SetDescription(IsekaiContext, "After extensive training, you gain a +8 bonus to all attributes.");
                bp.m_Icon = Icon_LegendaryProportions;
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.UntypedStackable;
                    c.Stat = StatType.Strength;
                    c.Value = 8;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.UntypedStackable;
                    c.Stat = StatType.Dexterity;
                    c.Value = 8;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.UntypedStackable;
                    c.Stat = StatType.Constitution;
                    c.Value = 8;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.UntypedStackable;
                    c.Stat = StatType.Intelligence;
                    c.Value = 8;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.UntypedStackable;
                    c.Stat = StatType.Wisdom;
                    c.Value = 8;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.UntypedStackable;
                    c.Stat = StatType.Charisma;
                    c.Value = 8;
                });
            });

            SpecialPowerSelection.AddToSelection(TrainingMontage);
        }
    }
}