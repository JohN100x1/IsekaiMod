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
    internal class BloodragerChimeraLegacy {
        private static BlueprintProgression prog;
        private static BlueprintFeatureSelection bloodlines;


        public static void Configure() {
            prog = Helpers.CreateBlueprint<BlueprintProgression>(IsekaiContext, "BloodragerChimeraLegacy", bp => {
                bp.SetName(IsekaiContext, "Bloodrager Legacy - Chimeric Rager");
                bp.SetDescription(IsekaiContext,
                    "Much like the Chimera you draw upon the power of inhuman bloodlines and learned how to slowly either awaken or fuse more of them into yourself. \n" +
                    "However, you would rather use that to empower your melee attacks rather than your spells.\n" +
                    "After all, what is the point of draconic claws or a phoenixes burning wings if you only use them as a fallback?");
                bp.GiveFeaturesForPreviousLevels = true;
            });
            bloodlines = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "IsekaiBloodragerSelection", bp => {
                bp.SetName(FeatTools.Selections.BloodragerBloodlineSelection.m_DisplayName);
                bp.SetDescription(FeatTools.Selections.BloodragerBloodlineSelection.m_Description);
                bp.Ranks = 1;
                bp.IgnorePrerequisites = true;
                bp.IsClassFeature = true;
            });

            LegacySelection.RegisterForFeat(prog);
            //LegacySelection.Register(prog);
            EdgeLordLegacySelection.Register(prog);
            GodEmperorLegacySelection.Prohibit(prog);
            HeroLegacySelection.Prohibit(prog);
            MastermindLegacySelection.Prohibit(prog);
            OverlordLegacySelection.Register(prog);
        }

        public static void PatchProgression() {
            if (prog != null) {
                LevelEntry[] addentries = new LevelEntry[] { };
                LevelEntry[] removeentries = new LevelEntry[] { };
                removeentries = removeentries.AppendToArray(Helpers.CreateLevelEntry(1, FeatTools.Selections.BloodragerBloodlineSelection));
                bloodlines.SetFeatures(FeatTools.Selections.BloodragerBloodlineSelection.m_AllFeatures);

                addentries = addentries.AppendToArray<LevelEntry>(Helpers.CreateLevelEntry(1, bloodlines));
                addentries = addentries.AppendToArray<LevelEntry>(Helpers.CreateLevelEntry(5, bloodlines));
                addentries = addentries.AppendToArray<LevelEntry>(Helpers.CreateLevelEntry(10, bloodlines));
                addentries = addentries.AppendToArray<LevelEntry>(Helpers.CreateLevelEntry(15, bloodlines));

                prog = StaticReferences.PatchClassProgressionBasedOnSeparateLists(prog, ClassTools.Classes.BloodragerClass, addentries, removeentries);

                BlueprintCharacterClassReference myClass = IsekaiProtagonistClass.GetReference();
                StaticReferences.PatchProgressionFeaturesBasedOnReferenceClass(prog, myClass, ClassTools.ClassReferences.BloodragerClass);

                prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = SorcererLegacy.Get().ToReference<BlueprintFeatureReference>(); });
                prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = BarbarianLegacy.Get().ToReference<BlueprintFeatureReference>(); });
                prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = SkaldBaseLegacy.Get().ToReference<BlueprintFeatureReference>(); });
                prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = SkaldVoiceLegacy.Get().ToReference<BlueprintFeatureReference>(); });
                prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = SkaldSilverTongueLegacy.Get().ToReference<BlueprintFeatureReference>(); });
            }
        }

        public static BlueprintProgression Get() {
            if (prog != null) return prog;
            return BlueprintTools.GetModBlueprint<BlueprintProgression>(IsekaiContext, "BloodragerChimeraLegacy");
        }
    }
}
