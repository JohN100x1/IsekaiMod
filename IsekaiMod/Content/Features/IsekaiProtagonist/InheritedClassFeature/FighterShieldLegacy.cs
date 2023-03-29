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
    internal class FighterShieldLegacy {
        private static BlueprintArchetype BaseArchetype = BlueprintTools.GetBlueprint<BlueprintArchetype>("a599da9a8a6b9e54083b0a4d2a25db59");

        private static BlueprintProgression prog;

        public static void Configure() {
            prog = Helpers.CreateBlueprint<BlueprintProgression>(IsekaiContext, "FighterShieldLegacy", bp => {
                bp.SetName(IsekaiContext, "Fighter Legacy - Guardian Shield");
                bp.SetDescription(IsekaiContext,
                    "You are the shield guarding your party.\n " +
                    "With your trusty shield in hand no enemy can break your defense.\n" +
                    "Just let the fool's try...");
                bp.GiveFeaturesForPreviousLevels = true;
            });

            LegacySelection.Register(prog);
            EdgeLordLegacySelection.Prohibit(prog);
            HeroLegacySelection.Register(prog);
            MastermindLegacySelection.Prohibit(prog);
            OverlordLegacySelection.Register(prog);
            GodEmperorLegacySelection.Prohibit(prog);
        }
        public static void PatchProgression() {
            BlueprintCharacterClassReference refClass = ClassTools.ClassReferences.FighterClass;
            BlueprintCharacterClassReference myClass = IsekaiProtagonistClass.GetReference();
            prog = StaticReferences.PatchClassProgressionBasedonRefArchetype(prog, ClassTools.Classes.FighterClass, BaseArchetype, null);
            StaticReferences.PatchProgressionFeaturesBasedOnReferenceArchetype(myClass, refClass, BaseArchetype);

            prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = FighterBasicLegacy.Get().ToReference<BlueprintFeatureReference>(); });
            prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = Fighter2HandedLegacy.Get().ToReference<BlueprintFeatureReference>(); });
        }
        public static BlueprintProgression Get() {
            if (prog != null) return prog;
            return BlueprintTools.GetModBlueprint<BlueprintProgression>(IsekaiContext, "FighterShieldLegacy");
        }
    }
}
