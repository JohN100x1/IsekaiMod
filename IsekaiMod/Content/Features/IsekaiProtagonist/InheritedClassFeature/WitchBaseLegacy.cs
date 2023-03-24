using HarmonyLib;
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
    internal class WitchBaseLegacy {
        private static BlueprintProgression prog;


        public static void Configure() {
            prog = Helpers.CreateBlueprint<BlueprintProgression>(IsekaiContext, "WitchBaseLegacy", bp => {
                bp.SetName(IsekaiContext, "Witch Legacy - Pactmaker");
                bp.SetDescription(IsekaiContext,
                    "You were once an ordinary person in your original world, until you were summoned by a mysterious entity to another world full of magic and monsters. \n" +
                    "There, you learned how to make pacts with various beings, from spirits and demons to dragons and gods. \n" +
                    "You use your pacts to gain power, knowledge, and allies in this strange new world. \n" +
                    "But beware, for every pact has a price, and some beings may not be so willing to cooperate with you.");
                bp.GiveFeaturesForPreviousLevels = true;
            });
            WitchPatronSelection.Configure();

            LegacySelection.Register(prog);
            EdgeLordLegacySelection.Register(prog);
            HeroLegacySelection.Register(prog);
            VillainLegacySelection.Register(prog);
            GodEmperorLegacySelection.Prohibit(prog);
        }

        public static void PatchProgression() {
            if (prog != null) {
                prog = StaticReferences.PatchClassProgressionBasedOnRefClass(prog, ClassTools.Classes.WitchClass);
                BlueprintCharacterClassReference myClass = IsekaiProtagonistClass.GetReference();
                StaticReferences.PatchProgressionFeaturesBasedOnReferenceClass(prog, myClass, ClassTools.ClassReferences.WitchClass);
                prog.LevelEntries.AddItem(Helpers.CreateLevelEntry(5, WitchPatronSelection.Get()));
                prog.LevelEntries.AddItem(Helpers.CreateLevelEntry(10, WitchPatronSelection.Get()));
                prog.LevelEntries.AddItem(Helpers.CreateLevelEntry(15, WitchPatronSelection.Get()));
                prog.LevelEntries.AddItem(Helpers.CreateLevelEntry(20, WitchPatronSelection.Get()));

                prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = ShamanLegacy.Get().ToReference<BlueprintFeatureReference>(); });
                WitchPatronSelection.Get().AddFeatures(FeatTools.Selections.WitchPatronSelection.m_AllFeatures);
            }
        }

        public static BlueprintProgression Get() {
            if (prog != null) return prog;
            return BlueprintTools.GetModBlueprint<BlueprintProgression>(IsekaiContext, "WitchBaseLegacy");
        }
    }
    internal class  WitchPatronSelection {
        private static BlueprintFeatureSelection myfeat;

        public static void Configure() {  

            myfeat = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "IsekaiWitchSelection", bp => {
                bp.SetName(IsekaiContext, "Patrons Blessing");
                bp.SetDescription(IsekaiContext, "As you grow so does your ability to make new pacts with otherworldy beings other gain other benefits from your existing ones.");
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.m_AllFeatures = new BlueprintFeatureReference[] {
                };
            });
        }

        public static BlueprintFeatureSelection Get() {
            if (myfeat != null) return myfeat;
            return BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "IsekaiWitchSelection");
        }
    }
}
