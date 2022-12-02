using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using UnityEngine;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.CharacterDevelopment
{
    class TrainingMontage
    {
        private static readonly Sprite Icon_LegendaryProportions = Resources.GetBlueprint<BlueprintAbility>("da1b292d91ba37948893cdbe9ea89e28").m_Icon;
        public static void Add()
        {
            var TrainingMontage = Helpers.CreateFeature("TrainingMontage", bp => {
                bp.SetName("Training Montage");
                bp.SetDescription("After extensive training, you gain a +10 bonus to all attributes.");
                bp.m_Icon = Icon_LegendaryProportions;
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.UntypedStackable;
                    c.Stat = StatType.Strength;
                    c.Value = 10;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.UntypedStackable;
                    c.Stat = StatType.Dexterity;
                    c.Value = 10;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.UntypedStackable;
                    c.Stat = StatType.Constitution;
                    c.Value = 10;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.UntypedStackable;
                    c.Stat = StatType.Intelligence;
                    c.Value = 10;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.UntypedStackable;
                    c.Stat = StatType.Wisdom;
                    c.Value = 10;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.UntypedStackable;
                    c.Stat = StatType.Charisma;
                    c.Value = 10;
                });
                bp.AddComponent<PrerequisiteCharacterLevel>(c => {
                    c.Level = 10;
                });
            });

            CharacterDevelopmentSelection.AddToSelection(TrainingMontage);
        }
    }
}