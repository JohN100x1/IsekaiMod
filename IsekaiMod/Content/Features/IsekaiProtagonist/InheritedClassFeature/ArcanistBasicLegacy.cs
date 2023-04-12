using IsekaiMod.Content.Classes.IsekaiProtagonist;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.InheritedClassFeature {
    internal class ArcanistBasicLegacy {
        private static BlueprintProgression prog;


        public static void Configure() {
            prog = Helpers.CreateBlueprint<BlueprintProgression>(IsekaiContext, "ArcanistBasicLegacy", bp => {
                bp.SetName(IsekaiContext, "Arcanist Legacy - Arcanist");
                bp.SetDescription(IsekaiContext,
                    "Your otherworldy background allows you to  easily graps some of the exploits available within the laws of magic. \n" +
                    "This allows you to shape the magic around you in specific ways that might  be similar to spells but are not quite spells."
                    );
                bp.GiveFeaturesForPreviousLevels = true;
            });

            LegacySelection.RegisterForFeat(prog);
            //LegacySelection.Register(prog);
            //EdgeLordLegacySelection.Prohibit(prog);
            //GodEmperorLegacySelection.Prohibit(prog);
            //HeroLegacySelection.Register(prog);
            //MastermindLegacySelection.Prohibit(prog);
            //OverlordLegacySelection.Register(prog);
        }

        public static void PatchProgression() {
            if (prog != null) {
                prog = PatchTools.PatchClassProgressionBasedOnRefClass(prog, ClassTools.Classes.ArcanistClass);
                BlueprintCharacterClassReference myClass = IsekaiProtagonistClass.GetReference();
                PatchTools.PatchProgressionFeaturesBasedOnReferenceClass(prog, myClass, ClassTools.ClassReferences.ArcanistClass);

                prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = ArcanistBrownFurLegacy.Get().ToReference<BlueprintFeatureReference>(); });
                prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = ArcanistEldritchFontLegacy.Get().ToReference<BlueprintFeatureReference>(); });
            }
        }

        public static BlueprintProgression Get() {
            if (prog != null) return prog;
            return BlueprintTools.GetModBlueprint<BlueprintProgression>(IsekaiContext, "ArcanistBasicLegacy");
        }

    }
}
