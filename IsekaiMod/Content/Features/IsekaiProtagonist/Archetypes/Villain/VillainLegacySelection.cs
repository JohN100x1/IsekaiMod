using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Selection;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Villain {
    internal class VillainLegacySelection {
        private static BlueprintFeatureSelection ClassSelection;

        public static void Configure() {

            if (ClassSelection != null) {
                IsekaiContext.Logger.LogWarning("repeated configuration of =VillainLegacySelection");
                return;
            }
            ClassSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "VillainLegacySelection", bp => {
                bp.SetName(IsekaiContext, "Villainous Legacy");
                bp.SetDescription(IsekaiContext, "This is neither disney, nor are you the kind to lose your mind...");
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
            return BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "VillainLegacySelection");
        }
    }
}
