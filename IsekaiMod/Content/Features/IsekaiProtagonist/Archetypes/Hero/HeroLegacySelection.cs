﻿using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Hero {

    internal class HeroLegacySelection {
        private static BlueprintFeatureSelection ClassSelection;
        private static BlueprintProgression[] registered = new BlueprintProgression[] { };
        private static BlueprintProgression[] prohibited = new BlueprintProgression[] { };

        public static void Configure() {
            if (ClassSelection != null) {
                IsekaiContext.Logger.LogWarning("repeated configuration of =HeroLegacy");
                return;
            }
            ClassSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "HeroLegacySelection", bp => {
                bp.SetName(IsekaiContext, "Heroic Legacy");
                bp.SetDescription(IsekaiContext, "You are a shining beacon of Light. The beacon that shows the way through the darkness and your legacy reflects that.");
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.IgnorePrerequisites = false;
                bp.m_AllFeatures = new BlueprintFeatureReference[0];
                bp.m_Features = new BlueprintFeatureReference[0];
            });
        }

        public static BlueprintFeatureSelection getClassFeature() {
            if (ClassSelection != null) {
                return ClassSelection;
            }
            return BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "HeroLegacySelection");
        }
        public static void Register(BlueprintProgression prog) {
            registered = registered.AppendToArray(prog);
        }
        public static void Prohibit(BlueprintProgression prog) {
            prohibited = prohibited.AppendToArray(prog);
        }

        public static void Finish() {
            foreach (BlueprintFeature feature in registered) {
                ClassSelection.AddFeatures(feature);
            }
            if (IsekaiContext.AddedContent.Other.IsDisabled("Relax Legacy Choices")) {
                BlueprintArchetypeReference myRef = Classes.IsekaiProtagonist.Archetypes.Hero.GetReference();
                foreach (BlueprintFeature feature in prohibited) {
                    feature.AddComponent<PrerequisiteNoArchetype>(c => { c.m_Archetype = myRef; });
                }
            }
        }
    }
}