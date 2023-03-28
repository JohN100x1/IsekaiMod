using IsekaiMod.Content.Classes.IsekaiProtagonist;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Hero;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Villain;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.InheritedClassFeature {

    internal class TacticianLegacy {

        public static void Configure() {
            var prog = Helpers.CreateBlueprint<BlueprintProgression>(IsekaiContext, "TacticianLegacy", bp => {
                bp.SetName(IsekaiContext, "Tactician Legacy - Isekai Tactician");
                bp.SetDescription(IsekaiContext, "Deprecated");
                bp.GiveFeaturesForPreviousLevels = true;
                bp.IsClassFeature = true;
                bp.m_Classes = new BlueprintProgression.ClassWithLevel[] {
                    new BlueprintProgression.ClassWithLevel {
                        m_Class = IsekaiProtagonistClass.GetReference(),
                        AdditionalLevel = 0
                    }
                };
                bp.LevelEntries = new LevelEntry[] {
                    Helpers.CreateLevelEntry(1,StaticReferences.SoloTactics),
                    Helpers.CreateLevelEntry(2,StaticReferences.Teamwork),
                    Helpers.CreateLevelEntry(3,StaticReferences.ForesterTactics),
                    Helpers.CreateLevelEntry(4,StaticReferences.AnimalTeamwork),
                    Helpers.CreateLevelEntry(5,StaticReferences.SummonTactics),
                    Helpers.CreateLevelEntry(6,StaticReferences.Teamwork),
                    Helpers.CreateLevelEntry(8,StaticReferences.Teamwork),
                    Helpers.CreateLevelEntry(12,StaticReferences.Teamwork),
                    Helpers.CreateLevelEntry(16,StaticReferences.Teamwork),
                    Helpers.CreateLevelEntry(18,StaticReferences.Teamwork),
            };
                bp.UIGroups = new UIGroup[] {
                    Helpers.CreateUIGroup(StaticReferences.SoloTactics, StaticReferences.Teamwork, StaticReferences.ForesterTactics, StaticReferences.AnimalTeamwork,StaticReferences.SummonTactics)
                };
            });
        }
    }
}