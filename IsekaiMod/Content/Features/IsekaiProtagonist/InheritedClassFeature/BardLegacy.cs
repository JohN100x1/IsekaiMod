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

    internal class BardLegacy {
        private static BlueprintProgression prog;


        public static void Configure() {
            prog = Helpers.CreateBlueprint<BlueprintProgression>(IsekaiContext, "BardLegacy", bp => {
                bp.SetName(IsekaiContext, "Bard Legacy - Musical Prodige");
                bp.SetDescription(IsekaiContext,
                    "You know what is even more effective in gathering a great harem than being a great hero? \n" +
                    "That is right, music the language of romance, there is a reason why so many males hate bards..."
                    );
                bp.GiveFeaturesForPreviousLevels = true;
            });

            LegacySelection.RegisterForFeat(prog);
            LegacySelection.Register(prog);
            EdgeLordLegacySelection.Prohibit(prog);
            GodEmperorLegacySelection.Prohibit(prog);
            HeroLegacySelection.Register(prog);
            MastermindLegacySelection.Prohibit(prog);
            OverlordLegacySelection.Prohibit(prog);
        }

        public static void PatchProgression() {
            if (prog != null) {
                prog = PatchTools.PatchClassProgressionBasedOnRefClass(prog, ClassTools.Classes.BardClass);
                BlueprintCharacterClassReference myClass = IsekaiProtagonistClass.GetReference();
                PatchTools.PatchProgressionFeaturesBasedOnReferenceClass(prog, myClass, ClassTools.ClassReferences.BardClass);

                prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = SkaldBaseLegacy.Get().ToReference<BlueprintFeatureReference>(); });
                prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = SkaldVoiceLegacy.Get().ToReference<BlueprintFeatureReference>(); });
                prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = SkaldSilverTongueLegacy.Get().ToReference<BlueprintFeatureReference>(); });
            }
        }

        public static BlueprintProgression Get() {
            if (prog != null) return prog;
            return BlueprintTools.GetModBlueprint<BlueprintProgression>(IsekaiContext, "BardLegacy");
        }
    }
}
