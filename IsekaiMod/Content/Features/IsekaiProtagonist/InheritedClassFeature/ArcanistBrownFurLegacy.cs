using IsekaiMod.Content.Classes.IsekaiProtagonist;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using TabletopTweaks.Core.Utilities;
using Kingmaker.Blueprints.Classes.Prerequisites;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.EdgeLord;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.GodEmperor;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Hero;
using static IsekaiMod.Main;
using Kingmaker.Blueprints.Classes.Selection;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Mastermind;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Overlord;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.InheritedClassFeature {
    internal class ArcanistBrownFurLegacy {
        private static string BaseArchetypeId = "ce63b2df8c6c12649b02c278e73d8bfa";
        private static BlueprintArchetype BaseArchetype = BlueprintTools.GetBlueprint<BlueprintArchetype>(BaseArchetypeId);

        private static BlueprintProgression prog;

        public static void Configure() {
            prog = Helpers.CreateBlueprint<BlueprintProgression>(IsekaiContext, "ArcanistBrownFurLegacy", bp => {
                bp.SetName(IsekaiContext, "Arcanist Legacy - Brown Fur Transmuter");
                bp.SetDescription(IsekaiContext,
                    "TBD"
                    );
                bp.GiveFeaturesForPreviousLevels = true;
            });

            LegacySelection.RegisterForFeat(prog);
            //LegacySelection.Register(prog);
            //EdgeLordLegacySelection.Register(prog);
            //GodEmperorLegacySelection.Prohibit(prog);
            //HeroLegacySelection.Prohibit(prog);
            //MastermindLegacySelection.Prohibit(prog);
            //OverlordLegacySelection.Register(prog);
        }
        public static void PatchProgression() {
            if (prog != null) {
                if (BaseArchetype == null) {
                    BaseArchetype = BlueprintTools.GetBlueprint<BlueprintArchetype>(BaseArchetypeId);
                    if (BaseArchetype == null) { return; }
                }
                LevelEntry[] addentries = new LevelEntry[] { };
                LevelEntry[] removeentries = new LevelEntry[] { };

                removeentries = removeentries.AppendToArray(BaseArchetype.RemoveFeatures);
                addentries = addentries.AppendToArray(BaseArchetype.AddFeatures);
                prog.SetDescription(BaseArchetype.LocalizedDescription);

                prog = StaticReferences.PatchClassProgressionBasedOnSeparateLists(prog, ClassTools.Classes.ArcanistClass, addentries, removeentries);

                BlueprintCharacterClassReference myClass = IsekaiProtagonistClass.GetReference();
                foreach (var level in BaseArchetype.AddFeatures) {
                    foreach (var candidate in level.Features) {
                        if (candidate != null && candidate is BlueprintFeatureSelection selection) {
                            StaticReferences.PatchClassIntoFeatureOfReferenceClass(selection, myClass, ClassTools.ClassReferences.ArcanistClass, 0, new BlueprintFeatureBase[] { });
                        } else {
                            if (candidate != null && candidate is BlueprintFeature feature) {
                                StaticReferences.PatchClassIntoFeatureOfReferenceClass(feature, myClass, ClassTools.ClassReferences.ArcanistClass, 0, new BlueprintFeatureBase[] { });
                            }
                        }
                    }
                }

                prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = ArcanistBasicLegacy.Get().ToReference<BlueprintFeatureReference>(); });
                prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = ArcanistEldritchFontLegacy.Get().ToReference<BlueprintFeatureReference>(); });
            }
        }
        public static BlueprintProgression Get() {
            if (prog != null) return prog;
            return BlueprintTools.GetModBlueprint<BlueprintProgression>(IsekaiContext, "ArcanistBrownFurLegacy");
        }
    }
}
