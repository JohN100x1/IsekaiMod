using IsekaiMod.Components;
using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.EntitySystem.Stats;
using UnityEngine;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.OverpoweredAbility
{
    class SupremeBeing
    {
        private static readonly Sprite Icon_KiPowerSelection = Resources.GetBlueprint<BlueprintFeatureSelection>("3049386713ff04245a38b32483362551").m_Icon;
        public static void Add()
        {
            var SupremeBeing = Helpers.CreateFeature("SupremeBeing", bp => {
                bp.SetName("Overpowered Ability — Supreme Being");
                bp.SetDescription("All your attributes have a base value of 30.");
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
