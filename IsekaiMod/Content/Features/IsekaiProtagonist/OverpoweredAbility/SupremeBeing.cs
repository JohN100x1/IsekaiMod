using IsekaiMod.Components;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.EntitySystem.Stats;
using TabletopTweaks.Core.Utilities;
using UnityEngine;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.OverpoweredAbility {

    internal class SupremeBeing {
        private static readonly Sprite Icon_KiPowerSelection = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("3049386713ff04245a38b32483362551").m_Icon;

        public static void Add() {
            var SupremeBeing = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "SupremeBeing", bp => {
                bp.SetName(IsekaiContext, "Overpowered Ability — Supreme Being");
                bp.SetDescription(IsekaiContext, "You have forgotten the hardships of mortality and what sort of person you were before. "
                    + "Were you stupid? Were you weak? It matters no longer. Here in this new world, you are perfect."
                    + "\nBenefit: All your attributes have at least a base value of 30.");
                bp.m_Icon = Icon_KiPowerSelection;
                bp.AddComponent<SetBaseStat>(c => {
                    c.Stat = StatType.Strength;
                    c.Value = 30;
                });
                bp.AddComponent<SetBaseStat>(c => {
                    c.Stat = StatType.Dexterity;
                    c.Value = 30;
                });
                bp.AddComponent<SetBaseStat>(c => {
                    c.Stat = StatType.Constitution;
                    c.Value = 30;
                });
                bp.AddComponent<SetBaseStat>(c => {
                    c.Stat = StatType.Intelligence;
                    c.Value = 30;
                });
                bp.AddComponent<SetBaseStat>(c => {
                    c.Stat = StatType.Wisdom;
                    c.Value = 30;
                });
                bp.AddComponent<SetBaseStat>(c => {
                    c.Stat = StatType.Charisma;
                    c.Value = 30;
                });
            });

            OverpoweredAbilitySelection.AddToSelection(SupremeBeing);
        }
    }
}