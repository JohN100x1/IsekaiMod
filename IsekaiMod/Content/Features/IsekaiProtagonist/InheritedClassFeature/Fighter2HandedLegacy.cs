﻿using IsekaiMod.Content.Classes.IsekaiProtagonist;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Villain;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using TabletopTweaks.Core.Utilities;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.Blueprints.Classes.Prerequisites;
using IsekaiMod.Content.Classes.IsekaiProtagonist.Archetypes;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.EdgeLord;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.GodEmperor;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Hero;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.InheritedClassFeature {
    internal class Fighter2HandedLegacy {
        private static BlueprintArchetype BaseArchetype = BlueprintTools.GetBlueprint<BlueprintArchetype>("84643e02a764bff4a9c1aba333a53c89");

        private static BlueprintProgression prog;

        public static void Configure() {
            prog = Helpers.CreateBlueprint<BlueprintProgression>(IsekaiContext, "Fighter2HandedLegacy", bp => {
                bp.SetName(IsekaiContext, "Fighter Legacy - Two Handed Fighter");
                bp.SetDescription(IsekaiContext,
                    "What is cooler than swinging a sword at a speed the eye can barely follow?\n" +
                    "Swinging a massive two handed sword at that speed and watching your enemy as he runs in fear at the sheer size of your weapon and the speed at which you wield it.\n" +
                    "Even better if it is an elven blade or estoc so you can stack sneak attack on top for some truly critical hits...");
                bp.GiveFeaturesForPreviousLevels = true;
            });

            LegacySelection.Register(prog);
            EdgeLordLegacySelection.Register(prog);
            HeroLegacySelection.Prohibit(prog);
            VillainLegacySelection.Prohibit(prog);
            GodEmperorLegacySelection.Prohibit(prog);
        }
        public static void PatchProgression() {


            BlueprintCharacterClassReference refClass = ClassTools.ClassReferences.FighterClass;
            BlueprintCharacterClassReference myClass = IsekaiProtagonistClass.GetReference();
            prog = StaticReferences.PatchClassProgressionBasedonRefArchetype(prog, ClassTools.Classes.FighterClass, BaseArchetype, null);
            StaticReferences.PatchProgressionFeaturesBasedOnReferenceArchetype(myClass, refClass, BaseArchetype);

            prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = FighterBasicLegacy.Get().ToReference<BlueprintFeatureReference>(); });
            prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = FighterShieldLegacy.Get().ToReference<BlueprintFeatureReference>(); });
        }
        public static BlueprintProgression Get() {
            if (prog != null) return prog;
            return BlueprintTools.GetModBlueprint<BlueprintProgression>(IsekaiContext, "Fighter2HandedLegacy");
        }
    }
}