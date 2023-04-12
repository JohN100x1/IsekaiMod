using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.EdgeLord;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.GodEmperor;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Hero;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Mastermind;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Overlord;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.InheritedClassFeature {
    internal class InquisitorDomainLordLegacy {
        private static BlueprintProgression prog;
        private static BlueprintFeatureSelection domains;

        public static void Configure() {
            prog = Helpers.CreateBlueprint<BlueprintProgression>(IsekaiContext, "InquisitorDomainLordLegacy", bp => {
                bp.SetName(IsekaiContext, "Inquisitor Legacy - Domain Lord");
                bp.SetDescription(IsekaiContext,
                    "Your reincarnation by divine means has strengthened your divine connection above that of normal people. \n" +
                    "The difference might not be easily visible at the beginning. \n" +
                    "But as time passes it will slowly grow, granting you access to more and more domains.");
                bp.GiveFeaturesForPreviousLevels = true;
            });
            domains = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "InquisitorAdditionalDomains", bp => {
                bp.SetName(FeatTools.Selections.DomainsSelection.m_DisplayName);
                bp.SetDescription(FeatTools.Selections.DomainsSelection.m_Description);
                bp.IgnorePrerequisites = true;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });

            LegacySelection.RegisterForFeat(prog);
            //LegacySelection.Register(prog);
            EdgeLordLegacySelection.Prohibit(prog);
            GodEmperorLegacySelection.Register(prog);
            HeroLegacySelection.Register(prog);
            MastermindLegacySelection.Register(prog);
            OverlordLegacySelection.Register(prog);
        }

        public static void PatchProgression() {
            if (prog != null) {
                LevelEntry[] addentries = new LevelEntry[] { };
                LevelEntry[] removeentries = new LevelEntry[] { };

                domains.SetFeatures(FeatTools.Selections.DomainsSelection.m_AllFeatures);

                removeentries = removeentries.AppendToArray(Helpers.CreateLevelEntry(1, FeatTools.Selections.DomainsSelection));
                addentries = addentries.AppendToArray<LevelEntry>(Helpers.CreateLevelEntry(2, InquisitorTacticianLegacy.GetDomains()));
                addentries = addentries.AppendToArray<LevelEntry>(Helpers.CreateLevelEntry(5, domains));
                addentries = addentries.AppendToArray<LevelEntry>(Helpers.CreateLevelEntry(10, domains));
                addentries = addentries.AppendToArray<LevelEntry>(Helpers.CreateLevelEntry(15, domains));
                addentries = addentries.AppendToArray<LevelEntry>(Helpers.CreateLevelEntry(20, domains));

                BlueprintArchetype archetype = BlueprintTools.GetBlueprint<BlueprintArchetype>("0e5e91c17f114d358910e0da4ae29b50");

                removeentries = removeentries.AppendToArray(archetype.RemoveFeatures);

                prog = StaticReferences.PatchClassProgressionBasedOnSeparateLists(prog, ClassTools.Classes.InquisitorClass, addentries, removeentries);

                prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = InquisitorTacticianLegacy.Get().ToReference<BlueprintFeatureReference>(); });
                prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = InquisitorJudgeLegacy.Get().ToReference<BlueprintFeatureReference>(); });
            }
        }

        public static BlueprintProgression Get() {
            if (prog != null) return prog;
            return BlueprintTools.GetModBlueprint<BlueprintProgression>(IsekaiContext, "InquisitorDomainLordLegacy");
        }
    }
}
