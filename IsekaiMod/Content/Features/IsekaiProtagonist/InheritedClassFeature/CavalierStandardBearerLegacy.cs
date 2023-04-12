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
    internal class CavalierStandardBearerLegacy {
        private static string BaseArchetypeId = "07db3fec753209546a792a7942288998";
        private static BlueprintArchetype BaseArchetype = BlueprintTools.GetBlueprint<BlueprintArchetype>(BaseArchetypeId);

        private static BlueprintProgression prog;

        public static void Configure() {
            prog = Helpers.CreateBlueprint<BlueprintProgression>(IsekaiContext, "CavalierStandardBearerLegacy", bp => {
                bp.SetName(IsekaiContext, "Cavalier Legacy - Backline Leader");
                bp.SetDescription(IsekaiContext,
                    "Some lead from the front, but while you can charge ahead you prefer to lead from the back.\n" +
                    "After all the backline grants you a much better strategic position to evaluate where the problems in the formation are. \n" +
                    "Also, at your core you are a caster, so why should you charge into the thick of things?"
                    );
                bp.GiveFeaturesForPreviousLevels = true;
            });

            LegacySelection.RegisterForFeat(prog);
            LegacySelection.Register(prog);
            EdgeLordLegacySelection.Prohibit(prog);
            GodEmperorLegacySelection.Register(prog);
            HeroLegacySelection.Register(prog);
            MastermindLegacySelection.Prohibit(prog);
            OverlordLegacySelection.Register(prog);
        }
        public static void PatchProgression() {
            if (prog != null) {
                if (BaseArchetype == null) {
                    BaseArchetype = BlueprintTools.GetBlueprint<BlueprintArchetype>(BaseArchetypeId);
                    if (BaseArchetype == null) { return; }
                }
                LevelEntry[] addentries = new LevelEntry[] { };
                LevelEntry[] removeentries = new LevelEntry[] { };

                removeentries = removeentries.AppendToArray(Helpers.CreateLevelEntry(5, FeatTools.Selections.CavalierMountSelection));

                removeentries = removeentries.AppendToArray(BaseArchetype.RemoveFeatures);
                addentries = addentries.AppendToArray(BaseArchetype.AddFeatures);

                // Animal Teamwork, Solo Tactics
                addentries = addentries.AppendToArray<LevelEntry>(Helpers.CreateLevelEntry(3,
                    BlueprintTools.GetBlueprint<BlueprintFeature>("1b9916f7675d6ef4fb427081250d49de"),
                    BlueprintTools.GetBlueprint<BlueprintFeature>("a318fa1af8424638ab10c4f98c11ee6a")));
                //Summon Tactics
                addentries = addentries.AppendToArray<LevelEntry>(Helpers.CreateLevelEntry(5, BlueprintTools.GetBlueprint<BlueprintFeature>("c3abcce19f9f80640a867c9e75f880b2"), BlueprintTools.GetBlueprint<BlueprintFeature>("7bc55b5e381358c45b42153b8b2603a6")));

                addentries = addentries.AppendToArray<LevelEntry>(Helpers.CreateLevelEntry(15, BlueprintTools.GetBlueprint<BlueprintFeature>("7bc55b5e381358c45b42153b8b2603a6")));

                // 7bc55b5e381358c45b42153b8b2603a6

                prog = PatchTools.PatchClassProgressionBasedOnSeparateLists(prog, ClassTools.Classes.CavalierClass, addentries, removeentries);

                BlueprintCharacterClassReference myClass = IsekaiProtagonistClass.GetReference();
                foreach (var level in BaseArchetype.AddFeatures) {
                    foreach (var candidate in level.Features) {
                        if (candidate != null && candidate is BlueprintFeatureSelection selection) {
                            PatchTools.PatchClassIntoFeatureOfReferenceClass(selection, myClass, ClassTools.ClassReferences.CavalierClass, 0, new BlueprintFeatureBase[] { });
                        } else {
                            if (candidate != null && candidate is BlueprintFeature feature) {
                                PatchTools.PatchClassIntoFeatureOfReferenceClass(feature, myClass, ClassTools.ClassReferences.CavalierClass, 0, new BlueprintFeatureBase[] { });
                            }
                        }
                    }
                }

                prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = InquisitorTacticianLegacy.Get().ToReference<BlueprintFeatureReference>(); });
                prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = CavalierBasicLegacy.Get().ToReference<BlueprintFeatureReference>(); });
                prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = CavalierKnightOfWall.Get().ToReference<BlueprintFeatureReference>(); });
            }
        }
        public static BlueprintProgression Get() {
            if (prog != null) return prog;
            return BlueprintTools.GetModBlueprint<BlueprintProgression>(IsekaiContext, "CavalierStandardBearerLegacy");
        }
    }
}
