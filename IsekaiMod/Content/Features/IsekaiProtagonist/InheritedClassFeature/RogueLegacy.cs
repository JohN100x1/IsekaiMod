﻿using IsekaiMod.Content.Classes.IsekaiProtagonist;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.EdgeLord;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.GodEmperor;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Mastermind;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Overlord;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.InheritedClassFeature {

    internal class RogueLegacy {
        private static BlueprintProgression prog;

        public static void Configure() {
            prog = Helpers.CreateBlueprint<BlueprintProgression>(IsekaiContext, "RogueLegacy", bp => {
                bp.SetName(IsekaiContext, "Rogue Legacy - Supernatural Thief");
                bp.SetDescription(IsekaiContext, "Your reincarnation gave you great power; that is no reason to forget the usefulness of a simple backstab.");
                bp.GiveFeaturesForPreviousLevels = true;
            });

            LegacySelection.RegisterForFeat(prog);
            LegacySelection.Register(prog);
            EdgeLordLegacySelection.Register(prog);
            GodEmperorLegacySelection.Prohibit(prog);
            //HeroLegacySelection.Register(prog);
            MastermindLegacySelection.Register(prog);
            OverlordLegacySelection.Prohibit(prog);
        }
        public static void PatchProgression() {
            if (prog != null) {
                prog = PatchTools.PatchClassProgressionBasedOnRefClass(prog, ClassTools.Classes.RogueClass);
                BlueprintCharacterClassReference myClass = IsekaiProtagonistClass.GetReference();
                PatchTools.PatchProgressionFeaturesBasedOnReferenceClass(prog, myClass, ClassTools.ClassReferences.RogueClass);
            }
        }
        public static BlueprintProgression Get() {
            if (prog != null) return prog;
            return BlueprintTools.GetModBlueprint<BlueprintProgression>(IsekaiContext, "RogueLegacy");
        }
    }
}
