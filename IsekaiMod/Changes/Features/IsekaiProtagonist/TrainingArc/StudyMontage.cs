using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.FactLogic;

namespace IsekaiMod.Changes.Features.IsekaiProtagonist.TrainingArc
{
    class StudyMontage
    {
        public static void Add()
        {
            var Icon_Thoughtsense = Resources.GetBlueprint<BlueprintAbility>("8fb1a1670b6e1f84b89ea846f589b627").m_Icon;
            var StudyMontage = Helpers.CreateBlueprint<BlueprintFeature>("StudyMontage", bp => {
                bp.SetName("Study Montage");
                bp.SetDescription("After extensive study sessions, you gain a +8 insight bonus to Intelligence, Wisdom, and Charisma.");
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
                bp.m_Icon = Icon_Thoughtsense;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
        }
    }
}
