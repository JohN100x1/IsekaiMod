using IsekaiMod.Content.Classes.IsekaiProtagonist;
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
    internal class InquisitorJudgeLegacy {
        private static BlueprintProgression prog;

        public static void Configure() {
            prog = Helpers.CreateBlueprint<BlueprintProgression>(IsekaiContext, "InquisitorJudgeLegacy", bp => {
                bp.SetName(IsekaiContext, "Inquisitor Legacy - Judge");
                bp.SetDescription(IsekaiContext,
                    "You were a judge in your previous world, but you were killed by a corrupt system that twisted the law to serve its own interests. \n" +
                    "You have been reborn in a world where law is often ignored or perverted, and you have sworn to uphold the law and punish the lawbreakers. \n" +
                    "You can use your judgements more often and more effectively than normal inquisitors, enhancing your abilities and weakening your foes. \n" +
                    "You are a champion of law and order, and a scourge of chaos and anarchy.");
                bp.GiveFeaturesForPreviousLevels = true;
                bp.AddPrerequisite<PrerequisiteAlignment>(c => { c.Alignment = Kingmaker.UnitLogic.Alignments.AlignmentMaskType.Lawful; });
            });

            LegacySelection.RegisterForFeat(prog);
            LegacySelection.Register(prog);
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

                removeentries = removeentries.AppendToArray(Helpers.CreateLevelEntry(1, FeatTools.Selections.DomainsSelection));
                addentries = addentries.AppendToArray<LevelEntry>(Helpers.CreateLevelEntry(2, InquisitorTacticianLegacy.GetDomains()));

                BlueprintArchetype archetype = BlueprintTools.GetBlueprint<BlueprintArchetype>("0e5e91c17f114d358910e0da4ae29b50");

                removeentries = removeentries.AppendToArray(archetype.RemoveFeatures);
                addentries = addentries.AppendToArray(archetype.AddFeatures);

                prog = PatchTools.PatchClassProgressionBasedOnSeparateLists(prog, ClassTools.Classes.InquisitorClass, addentries, removeentries);

                BlueprintCharacterClassReference myClass = IsekaiProtagonistClass.GetReference();
                foreach (var level in archetype.AddFeatures) {
                    foreach (var candidate in level.Features) {
                        if (candidate != null && candidate is BlueprintFeatureSelection selection) {
                            PatchTools.PatchClassIntoFeatureOfReferenceClass(selection, myClass, ClassTools.ClassReferences.InquisitorClass);
                        } else {
                            if (candidate != null && candidate is BlueprintFeature feature) {
                                PatchTools.PatchClassIntoFeatureOfReferenceClass(feature, myClass, ClassTools.ClassReferences.InquisitorClass);
                            }
                        }
                    }
                }

                prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = InquisitorTacticianLegacy.Get().ToReference<BlueprintFeatureReference>(); });
                prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = InquisitorDomainLordLegacy.Get().ToReference<BlueprintFeatureReference>(); });
            }
        }

        public static BlueprintProgression Get() {
            if (prog != null) return prog;
            return BlueprintTools.GetModBlueprint<BlueprintProgression>(IsekaiContext, "InquisitorJudgeLegacy");
        }
    }
}
