using IsekaiMod.Content.Features.IsekaiProtagonist.OverpoweredAbility;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Selection;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.InheritedClassFeature {

    internal class LegacySelection {
        private static BlueprintFeatureSelection ClassSelection;
        private static BlueprintFeatureSelection AbilitySelection;

        public static void ConfigureStep1() {

            if (ClassSelection != null) {
                IsekaiContext.Logger.LogWarning("repeated configuration of =LegacyClassSelection");
                return;
            }
            ClassSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "LegacyClassSelection", bp => {
                bp.SetName(IsekaiContext, "Legacy Class Feature");
                bp.SetDescription(IsekaiContext, "If not for the gods reincarnating you as an Isekai Hero with great mystic power you would have been...");
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.IgnorePrerequisites = false;
                bp.m_AllFeatures = new BlueprintFeatureReference[0];
                bp.m_Features = new BlueprintFeatureReference[0];
            });
            AbilitySelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "LegacyAbilitySelection", bp => {
                bp.SetName(IsekaiContext, "Legacy Class Feature");
                bp.SetDescription(IsekaiContext, "If not for the gods reincarnating you as an Isekai Hero with great mystic power you would have been...");
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.IgnorePrerequisites = false;
                bp.m_AllFeatures = new BlueprintFeatureReference[0];
                bp.m_Features = new BlueprintFeatureReference[0];
            });

        }
        public static BlueprintFeatureSelection GetClassFeature() {
            if (ClassSelection != null) {
                return ClassSelection;
            }
            return BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "LegacyClassSelection");
        }
        public static BlueprintFeatureSelection GetOverwhelmingFeature() {
            if (AbilitySelection != null) {
                return AbilitySelection;
            }
            return BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "LegacyAbilitySelection");
        }

        public static void ConfigureStep2() {
            OracleLegacy.Configure();
            SorcererLegacy.Configure();
            RogueLegacy.Configure();
            TacticianLegacy.Configure();
            KineticLegacy.Configure();
            BardLegacy.Configure();
            BarbarianLegacy.Configure();
            HeroicLegacy.Configure();
            ShamanLegacy.Configure();
            MagusLegacy.Configure();
            //always do this last to ensure any legacy that might get an arcana goes before
            ArcanaSelection.Configure();
            OverpoweredAbilitySelection.AddToSelection(GetOverwhelmingFeature());
            SpecialPower.SpecialPowerSelection.AddToSelection(GetOverwhelmingFeature());
            
        }
    }
}
