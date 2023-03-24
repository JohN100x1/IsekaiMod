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

    internal class BarbarianLegacy {
        private static BlueprintProgression prog;

        public static void Configure() {
            var IsekaiBarbarianTraining = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "BarbarianTraining", bp => {
                bp.SetName(IsekaiContext, "Deprecated");
                bp.SetDescription(IsekaiContext, "Old Feature, reference kept so your save won't crash!");
                bp.m_Icon = StaticReferences.SorcererArcana.m_Icon;
            });
            prog = Helpers.CreateBlueprint<BlueprintProgression>(IsekaiContext, "BarbarianLegacy", bp => {
                bp.SetName(IsekaiContext, "Barbarian Legacy - Ball of Rage");
                bp.SetDescription(IsekaiContext, "You really are just a walking bundle of issues waiting to explode at anyone getting too close, aren't you?");
                bp.GiveFeaturesForPreviousLevels = true;
            });


            LegacySelection.Register(prog);
            EdgeLordLegacySelection.Register(prog);
            //HeroLegacySelection.Prohibit(prog);
            VillainLegacySelection.Prohibit(prog);
            GodEmperorLegacySelection.Prohibit(prog);
        }
        public static void PatchProgression() {
            if (prog != null) {
                prog = StaticReferences.PatchClassProgressionBasedOnRefClass(prog, ClassTools.Classes.BarbarianClass);
                BlueprintCharacterClassReference myClass = IsekaiProtagonistClass.GetReference();
                StaticReferences.PatchProgressionFeaturesBasedOnReferenceClass(prog, myClass, ClassTools.ClassReferences.BarbarianClass);
                prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = SkaldBaseLegacy.Get().ToReference<BlueprintFeatureReference>(); });
                prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = SkaldVoiceLegacy.Get().ToReference<BlueprintFeatureReference>(); });
                prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = SkaldSilverTongueLegacy.Get().ToReference<BlueprintFeatureReference>(); });
            }
        }
        public static BlueprintProgression Get() {
            if (prog != null) return prog;
            return BlueprintTools.GetModBlueprint<BlueprintProgression>(IsekaiContext, "BarbarianLegacy");
        }
    }
}
