﻿using IsekaiMod.Content.Classes.IsekaiProtagonist;
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
    internal class SkaldVoiceLegacy {
        private static string BaseArchetypeId = "db942e7040084ea289c6be2bfeb3d0a8";
        private static BlueprintArchetype BaseArchetype = BlueprintTools.GetBlueprint<BlueprintArchetype>(BaseArchetypeId);

        private static BlueprintProgression prog;

        public static void Configure() {
            prog = Helpers.CreateBlueprint<BlueprintProgression>(IsekaiContext, "SkaldVoiceLegacy", bp => {
                bp.SetName(IsekaiContext, "Skald Legacy - The Voice");
                bp.SetDescription(IsekaiContext,
                    "You had a hidden passion for karaoke and were devastated seeing that no such thing exist in Golarion. \n" +
                    "As an ever - ready person you decide to train nonetheless since killing demonic armies only with your voice would show your talent to the entire world.");
                bp.GiveFeaturesForPreviousLevels = true;
            });

            LegacySelection.RegisterForFeat(prog);
            LegacySelection.Register(prog);
            EdgeLordLegacySelection.Register(prog);
            GodEmperorLegacySelection.Prohibit(prog);
            HeroLegacySelection.Register(prog);
            MastermindLegacySelection.Prohibit(prog);
            OverlordLegacySelection.Prohibit(prog);
        }

        public static void PatchProgression() {
            if (prog != null) {
                if (BaseArchetype == null) {
                    BaseArchetype = BlueprintTools.GetBlueprint<BlueprintArchetype>(BaseArchetypeId);
                    if (BaseArchetype == null) { return; }
                }


                prog = PatchTools.PatchClassProgressionBasedonRefArchetype(prog, ClassTools.Classes.SkaldClass, BaseArchetype, null);
                BlueprintCharacterClassReference refClass = ClassTools.ClassReferences.KineticistClass;
                BlueprintCharacterClassReference myClass = IsekaiProtagonistClass.GetReference();
                PatchTools.PatchProgressionFeaturesBasedOnReferenceArchetype(myClass, refClass, BaseArchetype);

                prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = BardLegacy.Get().ToReference<BlueprintFeatureReference>(); });
                prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = BarbarianLegacy.Get().ToReference<BlueprintFeatureReference>(); });
                prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = SkaldSilverTongueLegacy.Get().ToReference<BlueprintFeatureReference>(); });
                prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = SkaldBaseLegacy.Get().ToReference<BlueprintFeatureReference>(); });
                prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = BloodragerChimeraLegacy.Get().ToReference<BlueprintFeatureReference>(); });
            }
        }

        public static BlueprintProgression Get() {
            if (prog != null) return prog;
            return BlueprintTools.GetModBlueprint<BlueprintProgression>(IsekaiContext, "SkaldVoiceLegacy");
        }
    }
}
