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
            MastermindLegacySelection.Prohibit(prog);
            OverlordLegacySelection.Prohibit(prog);
        }
        public static void PatchProgression() {
            if (prog != null) {
                LevelEntry[] addentries = new LevelEntry[] {
                    Helpers.CreateLevelEntry(1, BlueprintTools.GetBlueprint<BlueprintFeature>("24e78475f0a243e1a810452d14d0a1bd"))
                };
                LevelEntry[] removeentries = new LevelEntry[] {
                    Helpers.CreateLevelEntry(1, BlueprintTools.GetBlueprint<BlueprintFeature>("f8c91c0135d5fc3458fcc131c4b77e96"))
                };

                //prog = PatchTools.PatchClassProgressionBasedOnRefClass(prog, ClassTools.Classes.PaladinClass);

                prog = PatchTools.PatchClassProgressionBasedOnSeparateLists(prog, ClassTools.Classes.PaladinClass, addentries, removeentries);
                BlueprintCharacterClassReference myClass = IsekaiProtagonistClass.GetReference();
                PatchTools.PatchProgressionFeaturesBasedOnReferenceClass(prog, myClass, ClassTools.ClassReferences.PaladinClass);
            }
        }
        public static BlueprintProgression Get() {
            if (prog != null) return prog;
            return BlueprintTools.GetModBlueprint<BlueprintProgression>(IsekaiContext, "PaladinBaseLegacy");
        }

    }
}
