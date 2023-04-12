using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Overlord {

    internal class OverlordLegacySelection {
        private static BlueprintFeatureSelection ClassSelection;
        private static BlueprintProgression[] registered;
        private static BlueprintProgression[] prohibited;

        public static void Configure() {
            if (ClassSelection != null) {
                IsekaiContext.Logger.LogWarning("repeated configuration of =OverlordLegacySelection");
                return;
            }
            ClassSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "OverlordLegacySelection", bp => {
                bp.SetName(IsekaiContext, "Overlord Legacy");
                bp.SetDescription(IsekaiContext, "This is neither disney, nor are you the kind to lose your mind...");
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.IgnorePrerequisites = false;
                bp.m_AllFeatures = new BlueprintFeatureReference[0];
                bp.m_Features = new BlueprintFeatureReference[0];
            });
            registered = new BlueprintProgression[] { };
            prohibited = new BlueprintProgression[] { };
        }

        public static BlueprintFeatureSelection getClassFeature() {
            if (ClassSelection != null) {
                return ClassSelection;
            }
            return BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "OverlordLegacySelection");
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
                BlueprintArchetypeReference archetypeRef = Classes.IsekaiProtagonist.Archetypes.OverlordArchetype.GetReference();
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