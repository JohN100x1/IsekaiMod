using IsekaiMod.Content.Classes.IsekaiProtagonist;
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
    internal class CavalierKnightOfWall {
        private static string BaseArchetypeId = "112dd0e61f95c3a459ac0a565472e685";
        private static BlueprintArchetype BaseArchetype = BlueprintTools.GetBlueprint<BlueprintArchetype>(BaseArchetypeId);

        private static BlueprintProgression prog;

        public static void Configure() {
            prog = Helpers.CreateBlueprint<BlueprintProgression>(IsekaiContext, "CavalierKnightOfWall", bp => {
                bp.SetName(IsekaiContext, "Cavalier Legacy - Magic Shield");
                bp.SetDescription(IsekaiContext,
                    "What do you mean shields don't stop magic?\n" +
                    "Well I can make my shield work to block magic too, don't blame me if you are not good enough to do it too..."
                    );
                bp.GiveFeaturesForPreviousLevels = true;
            });

            LegacySelection.RegisterForFeat(prog);
            //LegacySelection.Register(prog);
            //EdgeLordLegacySelection.Register(prog);
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

                removeentries = removeentries.AppendToArray(Helpers.CreateLevelEntry(1, FeatTools.Selections.CavalierMountSelection));

                removeentries = removeentries.AppendToArray(BaseArchetype.RemoveFeatures);
                addentries = addentries.AppendToArray(BaseArchetype.AddFeatures);

                prog = StaticReferences.PatchClassProgressionBasedOnSeparateLists(prog, ClassTools.Classes.CavalierClass, addentries, removeentries);

                BlueprintCharacterClassReference myClass = IsekaiProtagonistClass.GetReference();
                foreach (var level in BaseArchetype.AddFeatures) {
                    foreach (var candidate in level.Features) {
                        if (candidate != null && candidate is BlueprintFeatureSelection selection) {
                            StaticReferences.PatchClassIntoFeatureOfReferenceClass(selection, myClass, ClassTools.ClassReferences.CavalierClass, 0, new BlueprintFeatureBase[] { });
                        } else {
                            if (candidate != null && candidate is BlueprintFeature feature) {
                                StaticReferences.PatchClassIntoFeatureOfReferenceClass(feature, myClass, ClassTools.ClassReferences.CavalierClass, 0, new BlueprintFeatureBase[] { });
                            }
                        }
                    }
                }

                prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = CavalierBasicLegacy.Get().ToReference<BlueprintFeatureReference>(); });
                prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = CavalierStandardBearerLegacy.Get().ToReference<BlueprintFeatureReference>(); });
            }
        }
        public static BlueprintProgression Get() {
            if (prog != null) return prog;
            return BlueprintTools.GetModBlueprint<BlueprintProgression>(IsekaiContext, "CavalierKnightOfWall");
        }
    }
}
