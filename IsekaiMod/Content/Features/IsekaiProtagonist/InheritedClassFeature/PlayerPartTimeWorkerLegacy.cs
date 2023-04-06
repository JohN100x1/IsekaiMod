using IsekaiMod.Content.Classes.IsekaiProtagonist;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.EdgeLord;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.GodEmperor;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Hero;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Mastermind;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Overlord;
using Kingmaker.Blueprints.Classes;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.InheritedClassFeature {
    internal class PlayerPartTimeWorkerLegacy {
        private static BlueprintProgression prog;

        public static void Configure() {
            prog = Helpers.CreateBlueprint<BlueprintProgression>(IsekaiContext, "PlayerPartTimeWorkerLegacy", bp => {
                BlueprintFeature ArcanaFocus = BlueprintTools.GetBlueprint<BlueprintFeature>("cad1b9175e8c0e64583432a22134d33c");
                bp.SetName(IsekaiContext, "Player Legacy - Part Timer");
                bp.SetDescription(IsekaiContext,
                    "You were a part time worker bouncing from job to job. \n" +
                    "You know how to learn the basics of a new job and ultimately all thse classes are just a different type of job. \n" +
                    "Sure picking up the next one takes a while, but ultimately you will be the master of all.");
                bp.GiveFeaturesForPreviousLevels = false;
                bp.IsClassFeature = true;
                bp.m_Classes = new BlueprintProgression.ClassWithLevel[] {
                    new BlueprintProgression.ClassWithLevel {
                        m_Class = IsekaiProtagonistClass.GetReference(),
                        AdditionalLevel = 0
                    }

                };
                bp.LevelEntries = new LevelEntry[] {
                    Helpers.CreateLevelEntry (5, LegacySelection.GetClassFeature() ),
                    Helpers.CreateLevelEntry (10, LegacySelection.GetClassFeature() ),
                    Helpers.CreateLevelEntry (15, LegacySelection.GetClassFeature() ),
                };
                bp.UIGroups = new UIGroup[] {
                    Helpers.CreateUIGroup( LegacySelection.GetClassFeature()),
                };
            });
            LegacySelection.RegisterForFeat(prog);
            LegacySelection.Register(prog);
            EdgeLordLegacySelection.Register(prog);
            HeroLegacySelection.Register(prog);
            MastermindLegacySelection.Register(prog);
            OverlordLegacySelection.Register(prog);
            GodEmperorLegacySelection.Register(prog);

        }
        public static void PatchProgression() {
        }

        public static BlueprintProgression Get() {
            if (prog != null) return prog;
            return BlueprintTools.GetModBlueprint<BlueprintProgression>(IsekaiContext, "PlayerPartTimeWorkerLegacy");
        }
    }
}
