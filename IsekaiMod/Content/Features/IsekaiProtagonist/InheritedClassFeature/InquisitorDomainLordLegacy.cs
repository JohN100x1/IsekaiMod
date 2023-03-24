using IsekaiMod.Content.Classes.IsekaiProtagonist;
using IsekaiMod.Content.Classes.IsekaiProtagonist.Archetypes;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.EdgeLord;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.GodEmperor;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Hero;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Villain;
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

        public static void Configure() {
            prog = Helpers.CreateBlueprint<BlueprintProgression>(IsekaiContext, "InquisitorDomainLordLegacy", bp => {
                bp.SetName(IsekaiContext, "Inquisitor Legacy - Domain Lord");
                bp.SetDescription(IsekaiContext,
                    "Your reincarnation by divine means has strengthened your divine connection above that of normal people. \n" +
                    "The difference might not be easily visible at the beginning. \n" +
                    "But as time passes it will slowly grow, granting you access to more and more domains.");
                bp.GiveFeaturesForPreviousLevels = true;
                bp.AddPrerequisite<PrerequisiteAlignment>(c => { c.Alignment = Kingmaker.UnitLogic.Alignments.AlignmentMaskType.Lawful; });
            });

            LegacySelection.Register(prog);
            EdgeLordLegacySelection.Prohibit(prog);
            HeroLegacySelection.Register(prog);
            VillainLegacySelection.Register(prog);
            GodEmperorLegacySelection.Register(prog);
        }

        public static void PatchProgression() {
            if (prog != null) {
                LevelEntry[] addentries = new LevelEntry[] { };
                LevelEntry[] removeentries = new LevelEntry[] { };

                removeentries = removeentries.AppendToArray(Helpers.CreateLevelEntry(1, FeatTools.Selections.DomainsSelection));
                addentries = addentries.AppendToArray<LevelEntry>(Helpers.CreateLevelEntry(1, InquisitorTacticianLegacy.GetDomains()));
                addentries = addentries.AppendToArray<LevelEntry>(Helpers.CreateLevelEntry(5, InquisitorTacticianLegacy.GetDomains()));
                addentries = addentries.AppendToArray<LevelEntry>(Helpers.CreateLevelEntry(10, InquisitorTacticianLegacy.GetDomains()));
                addentries = addentries.AppendToArray<LevelEntry>(Helpers.CreateLevelEntry(15, InquisitorTacticianLegacy.GetDomains()));
                addentries = addentries.AppendToArray<LevelEntry>(Helpers.CreateLevelEntry(20, InquisitorTacticianLegacy.GetDomains()));

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
