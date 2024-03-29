﻿using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.GodEmperor {
    internal class GodEmperorLegacySelection {
        private static BlueprintFeatureSelection ClassSelection;
        private static BlueprintProgression[] registered = new BlueprintProgression[] { };
        private static BlueprintProgression[] prohibited = new BlueprintProgression[] { };

        public static void Configure() {
            if (ClassSelection != null) {
                IsekaiContext.Logger.LogWarning("repeated configuration of =GodEmperorLegacySelection");
                return;
            }
            ClassSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "GodEmperorLegacySelection", bp => {
                bp.SetName(IsekaiContext, "Divine Legacy");
                bp.SetDescription(IsekaiContext, "Your increasing divine power also manifests as the following features from a lesser class.");
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
            return BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "GodEmperorLegacySelection");
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
                BlueprintArchetypeReference archetypeRef = Classes.IsekaiProtagonist.Archetypes.GodEmperorArchetype.GetReference();
                foreach (BlueprintFeature feature in prohibited) {
                    feature.AddComponent<PrerequisiteNoArchetype>(c => {
                        c.m_Archetype = archetypeRef;
                        c.m_CharacterClass = Classes.IsekaiProtagonist.IsekaiProtagonistClass.GetReference();
                    });
                }
            }
        }
    }
}
