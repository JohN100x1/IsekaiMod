using IsekaiMod.Content.Classes.IsekaiProtagonist;
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
    internal class ShifterDragonLegacy {
        private static string BaseArchetypeId = "2d5b06e413a9408cbd5bb999b5a4cc4a";
        private static BlueprintArchetype BaseArchetype = BlueprintTools.GetBlueprint<BlueprintArchetype>(BaseArchetypeId);

        private static BlueprintProgression prog;

        public static void Configure() {
            if (ClassTools.Classes.ShifterClass == null) { return; }
            prog = Helpers.CreateBlueprint<BlueprintProgression>(IsekaiContext, "ShifterDragonLegacy", bp => {
                bp.SetName(IsekaiContext, "Shifter Legacy - Shapeshifted Baby Dragon");
                bp.SetDescription(IsekaiContext,
                    "When reincaranting you wanted to be a dragon. \n" +
                    "Because dragons are cool! \n" +
                    "But sadly  that would have been too balancebreaking according to the god of reincarnation. \n" +
                    "Weirdly enough being a shapeshifted baby dragon that learns to reassume his natural form with time is not. \n" +
                    "So one day you will soar through the sky in your draconic form. \n" +
                    "Dragon Claws are useful in the meantime...");
                bp.GiveFeaturesForPreviousLevels = true;
            });


        }
        public static void PatchProgression() {
            if (ClassTools.Classes.ShifterClass == null) { return; }

            if (BaseArchetype == null) {
                BaseArchetype = BlueprintTools.GetBlueprint<BlueprintArchetype>(BaseArchetypeId);
                if (BaseArchetype == null) { return; }
            }


            LegacySelection.RegisterForFeat(prog);
            LegacySelection.Register(prog);
            //EdgeLordLegacySelection.Register(prog);
            GodEmperorLegacySelection.Prohibit(prog);
            HeroLegacySelection.Register(prog);
            MastermindLegacySelection.Prohibit(prog);
            OverlordLegacySelection.Register(prog);

            prog = StaticReferences.PatchClassProgressionBasedonRefArchetype(prog, ClassTools.Classes.ShifterClass, BaseArchetype, null);
            BlueprintCharacterClassReference refClass = ClassTools.ClassReferences.ShifterClass;
            BlueprintCharacterClassReference myClass = IsekaiProtagonistClass.GetReference();
            StaticReferences.PatchProgressionFeaturesBasedOnReferenceArchetype(myClass, refClass, BaseArchetype);

            prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = ShifterBaseLegacy.Get().ToReference<BlueprintFeatureReference>(); });
            prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = ShifterBaseLegacy.GetEvilAlternate().ToReference<BlueprintFeatureReference>(); });
            prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = ShifterGriffonLegacy.Get().ToReference<BlueprintFeatureReference>(); });
            prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = ShifterHolyLegacy.Get().ToReference<BlueprintFeatureReference>(); });
            prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = ShifterStingerLegacy.Get().ToReference<BlueprintFeatureReference>(); });
            prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = DruidBaseLegacy.Get().ToReference<BlueprintFeatureReference>(); });
        }
        public static BlueprintProgression Get() {
            if (prog != null) return prog;
            return BlueprintTools.GetModBlueprint<BlueprintProgression>(IsekaiContext, "ShifterDragonLegacy");
        }
    }
}
