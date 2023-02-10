using IsekaiMod.Content.Classes.IsekaiProtagonist;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Hero;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.InheritedClassFeature {
    internal class BardLegacy {
        private static BlueprintProgression prog;
        public static void configure() {
            StaticReferences.BardPerformResource.m_MaxAmount.Class.m_Array.AppendToArray(IsekaiProtagonistClass.GetReference());
            var BardPerformResourceFact = BlueprintTools.GetBlueprint<BlueprintFeature>("b92bfc201c6a79e49afd0b5cfbfc269f");
            prog = Helpers.CreateBlueprint<BlueprintProgression>(IsekaiContext, "BardLegacy", bp => {
                bp.SetName(IsekaiContext, "Bard Legacy - Musical Prodige");
                bp.SetDescription(IsekaiContext, "You know what is even more effective in gathering a great harem than being a great hero? \nThat is right, music the language of romance, there is a reason why so many males hate bards...");
                bp.GiveFeaturesForPreviousLevels = true;
                bp.IsClassFeature = true;
                bp.m_Classes = new BlueprintProgression.ClassWithLevel[] {
                    new BlueprintProgression.ClassWithLevel {
                        m_Class = IsekaiProtagonistClass.GetReference(),
                        AdditionalLevel = 0
                    }
                };
                bp.LevelEntries = new LevelEntry[] {
                    Helpers.CreateLevelEntry(1, StaticReferences.BardInspireCourage, BardPerformResourceFact),
                    Helpers.CreateLevelEntry(2, StaticReferences.BardWellVersed),
                    Helpers.CreateLevelEntry(3, StaticReferences.BardInspireCompetence),
                    Helpers.CreateLevelEntry(5, StaticReferences.BardInspireCourage),
                    Helpers.CreateLevelEntry(6, StaticReferences.BardFascinate),
                    Helpers.CreateLevelEntry(7, StaticReferences.BardInspireCompetence, StaticReferences.BardMove),
                    Helpers.CreateLevelEntry(9, StaticReferences.BardInspireGreatness),
                    Helpers.CreateLevelEntry(11, StaticReferences.BardInspireCourage, StaticReferences.BardInspireCompetence),
                    Helpers.CreateLevelEntry(13, StaticReferences.BardSwift),
                    Helpers.CreateLevelEntry(15, StaticReferences.BardInspireCompetence, StaticReferences.BardInspireHeroics),
                    Helpers.CreateLevelEntry(17, StaticReferences.BardInspireCourage),
                    Helpers.CreateLevelEntry(19, StaticReferences.BardInspireCompetence),

            };
                bp.UIGroups = new UIGroup[] {
                    Helpers.CreateUIGroup(StaticReferences.BardInspireCourage, StaticReferences.BardMove, StaticReferences.BardSwift, 
                        StaticReferences.BardWellVersed,StaticReferences.BardFascinate,StaticReferences.BardInspireGreatness, StaticReferences.BardInspireHeroics),
                    Helpers.CreateUIGroup(StaticReferences.BardInspireCompetence)
                };

            });
            LegacySelection.getClassFeature().AddFeatures(prog);
            LegacySelection.getOverwhelmingFeature().AddFeatures(prog);
            HeroLegacySelection.getClassFeature().AddFeatures(prog);
        }
        public static BlueprintProgression Get() {
            if (prog != null) return prog;
            return BlueprintTools.GetModBlueprint<BlueprintProgression>(IsekaiContext, "BardLegacy");
        }
    }
}
