using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.FactLogic;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.TrainingArc
{
    class TrainingMontage
    {
        public static void Add()
        {
            var Icon_LegendaryProportions = Resources.GetBlueprint<BlueprintAbility>("da1b292d91ba37948893cdbe9ea89e28").m_Icon;
            var TrainingMontage = Helpers.CreateBlueprint<BlueprintFeature>("TrainingMontage", bp => {
                bp.SetName("Training Montage");
                bp.SetDescription("After extensive training sessions, you gain a +8 insight bonus to all attributes.");
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Insight;
                    c.Stat = StatType.Strength;
                    c.Value = 8;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Insight;
                    c.Stat = StatType.Dexterity;
                    c.Value = 8;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Insight;
                    c.Stat = StatType.Constitution;
                    c.Value = 8;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Insight;
                    c.Stat = StatType.Intelligence;
                    c.Value = 8;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Insight;
                    c.Stat = StatType.Wisdom;
                    c.Value = 8;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Insight;
                    c.Stat = StatType.Charisma;
                    c.Value = 8;
                });
                bp.m_Icon = Icon_LegendaryProportions;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
        }
    }
}
