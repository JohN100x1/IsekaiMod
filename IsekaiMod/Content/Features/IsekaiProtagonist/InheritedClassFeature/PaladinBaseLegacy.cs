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
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.InheritedClassFeature {
    internal class PaladinBaseLegacy {
        private static BlueprintProgression prog;

        public static void Configure() {
            
            prog = Helpers.CreateBlueprint<BlueprintProgression>(IsekaiContext, "PaladinBaseLegacy", bp => {
                bp.SetName(IsekaiContext, "Paladin Legacy - Hero of Light");
                bp.SetDescription(IsekaiContext, 
                    "You are a true hero, representing all that is good and holy in the world.\n" +
                    "Protecting the innocent and smiting the evil.\n" +
                    "Less benevolent people might actually throw up a little just from talking to you just because of how inherently good you are.");
                bp.GiveFeaturesForPreviousLevels = true;
                bp.AddComponent<PrerequisiteAlignment>(c => { c.Alignment = Kingmaker.UnitLogic.Alignments.AlignmentMaskType.Good; });
            });


            LegacySelection.RegisterForFeat(prog);
            LegacySelection.Register(prog);
            EdgeLordLegacySelection.Prohibit(prog);
            GodEmperorLegacySelection.Register(prog);
            HeroLegacySelection.Register(prog);
            VillainLegacySelection.Prohibit(prog);
        }
        public static void PatchProgression() {
            BlueprintFeature TrueSmiteFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "TrueSmiteFeature");
            BlueprintFeature TrueSmiteAdditionalUse = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "TrueSmiteAdditionalUse");
            BlueprintFeature TrueMarkFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "TrueMarkFeature");
            if (prog != null) {
                LevelEntry[] addentries = new LevelEntry[] {
                    Helpers.CreateLevelEntry(1, TrueSmiteFeature),
                    Helpers.CreateLevelEntry(4, TrueSmiteAdditionalUse),
                    Helpers.CreateLevelEntry(7, TrueSmiteAdditionalUse),
                    Helpers.CreateLevelEntry(10, TrueSmiteAdditionalUse),
                    Helpers.CreateLevelEntry(11, TrueMarkFeature),
                    Helpers.CreateLevelEntry(13, TrueSmiteAdditionalUse),
                    Helpers.CreateLevelEntry(16, TrueSmiteAdditionalUse),
                    Helpers.CreateLevelEntry(19, TrueSmiteAdditionalUse),

                };
                LevelEntry[] removeentries = new LevelEntry[] { };
                addentries = addentries.AppendToArray<LevelEntry>(Helpers.CreateLevelEntry(1, BlueprintTools.GetBlueprint<BlueprintFeature>("24e78475f0a243e1a810452d14d0a1bd")));
                removeentries = removeentries.AppendToArray<LevelEntry>(Helpers.CreateLevelEntry(1, BlueprintTools.GetBlueprint<BlueprintFeature>("f8c91c0135d5fc3458fcc131c4b77e96")));

                //prog = StaticReferences.PatchClassProgressionBasedOnRefClass(prog, ClassTools.Classes.PaladinClass);

                prog = StaticReferences.PatchClassProgressionBasedOnSeparateLists(prog, ClassTools.Classes.PaladinClass, addentries, removeentries);
                BlueprintCharacterClassReference myClass = IsekaiProtagonistClass.GetReference();
                StaticReferences.PatchProgressionFeaturesBasedOnReferenceClass(prog, myClass, ClassTools.ClassReferences.PaladinClass);
            }
        }
        public static BlueprintProgression Get() {
            if (prog != null) return prog;
            return BlueprintTools.GetModBlueprint<BlueprintProgression>(IsekaiContext, "PaladinBaseLegacy");
        }

    }
}
