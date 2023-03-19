using IsekaiMod.Content.Features.IsekaiProtagonist.OverpoweredAbility;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using TabletopTweaks.Core.Utilities;
using UnityEngine;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.InheritedClassFeature {

    internal class LegacySelection {
        private static readonly Sprite Icon_AllSkilled = BlueprintTools.GetBlueprint<BlueprintFeature>("f3bc6f9c855b2fb4e9aea364b8163aca").m_Icon;
        private static BlueprintFeatureSelection ClassSelection;
        private static BlueprintFeatureSelection AbilitySelection;

        public static void ConfigureStep1() {

            if (ClassSelection != null) {
                IsekaiContext.Logger.LogWarning("repeated configuration of =LegacyClassSelection");
                return;
            }
            ClassSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "LegacyClassSelection", bp => {
                bp.SetName(IsekaiContext, "Legacy");
                bp.SetDescription(IsekaiContext, "If not for the gods reincarnating you as an Isekai Hero with great mystic power you would have been...");
                bp.m_Icon = Icon_AllSkilled;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.IgnorePrerequisites = false;
                bp.m_AllFeatures = new BlueprintFeatureReference[0];
                bp.m_Features = new BlueprintFeatureReference[0];
            });
            AbilitySelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "LegacyAbilitySelection", bp => {
                bp.SetName(IsekaiContext, "Dual Legacy");
                bp.SetDescription(IsekaiContext, "So first I joined the bardic college of Wintermoon, then 3 years leater when I got bored with that I accidentally stumbled into the thiefs guild of Whitesnow...\nWhatever the backstory is, you get access to another legacy class feature.\nOr if you are a God Emperor your first.");
                bp.m_Icon = Icon_AllSkilled;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.IgnorePrerequisites = false;
                bp.m_AllFeatures = new BlueprintFeatureReference[0];
                bp.m_Features = new BlueprintFeatureReference[0];
            });
            AbilitySelection.AddComponent<PrerequisiteNoFeature>(c => { c.m_Feature = AbilitySelection.ToReference<BlueprintFeatureReference>(); });
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
            FighterBasicLegacy.Configure();
            HeroicLegacy.Configure();
            ShamanLegacy.Configure();
            MagusLegacy.Configure();
            //always do this last to ensure any legacy that might get an arcana goes before
            ArcanaSelection.Configure();
            OverpoweredAbilitySelection.AddToSelection(GetOverwhelmingFeature());
            SpecialPower.SpecialPowerSelection.AddToSelection(GetOverwhelmingFeature());

            //declaration solely to get guid, real configure follows later
            DreadKnightLegacy.ConfigureEmptyShell();
            KineticKnightLegacy.ConfigureEmptyShell();
            
        }
    }
}
