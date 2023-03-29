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
    internal class DreadKnightLegacy {

        private static BlueprintProgression prog;

        public static void Configure() {
            //Configure an empty shell during the blueprint phase, otherwise the game will always want to remove the blueprint as unused since we are technically only creating it at a stage where that should no longer be done
            prog = Helpers.CreateBlueprint<BlueprintProgression>(IsekaiContext, "DreadKnightLegacy", bp => {
            });
         }


        public static void PatchProgression() {
            BlueprintCharacterClass DreadKnight = BlueprintTools.GetBlueprint<BlueprintCharacterClass>("d0eb4ca44e11417c9b2f0208491067a0");
            //only add this stereotype if the Dread Knight Class has been added
            if (!ModSupport.IsExpandedContentEnabled() || DreadKnight == null) return;

            prog.SetName(IsekaiContext, "Dread Knight Legacy - Dread Lord");
            prog.SetDescription(IsekaiContext, "*Blinks and slowly backs away*, Uhm are you certain you want to play this? I mean Dread Knights are kind of evil, you know? \n As in the they are the opposite of anything a paladin represents...");
            prog.GiveFeaturesForPreviousLevels = true;
            prog.AddComponent<PrerequisiteAlignment>(c => { c.Alignment = Kingmaker.UnitLogic.Alignments.AlignmentMaskType.Evil; });
            prog = StaticReferences.PatchClassProgressionBasedOnRefClass(prog, DreadKnight);
            BlueprintCharacterClassReference myClass = IsekaiProtagonistClass.GetReference();
            //KJK: given when we actually initialize this there is no point in patching later
            StaticReferences.PatchProgressionFeaturesBasedOnReferenceClass(prog, myClass, DreadKnight.ToReference<BlueprintCharacterClassReference>());


            LegacySelection.Register(prog);
            EdgeLordLegacySelection.Register(prog);
            HeroLegacySelection.Prohibit(prog);
            MastermindLegacySelection.Register(prog);
            OverlordLegacySelection.Register(prog);
            GodEmperorLegacySelection.Register(prog);
        }

        public static BlueprintProgression Get() {
            if (prog != null) return prog;
            return BlueprintTools.GetModBlueprint<BlueprintProgression>(IsekaiContext, "DreadKnightLegacy");
        }
    }
}
