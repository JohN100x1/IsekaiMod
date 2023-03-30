using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.EdgeLord;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.GodEmperor;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Hero;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Mastermind;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Overlord;
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
                bp.SetDescription(IsekaiContext, "First, I joined the bardic college of Wintermoon. \n" +
                    "Then 3 years later, when I got bored with that, I accidentally stumbled into the theives' guild of Whitesnow...\n" +
                    "Whatever the backstory is, you get access to another legacy class feature.");
                bp.m_Icon = Icon_AllSkilled;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.IgnorePrerequisites = false;
                bp.m_AllFeatures = new BlueprintFeatureReference[0];
                bp.m_Features = new BlueprintFeatureReference[0];
            });
            AbilitySelection.AddComponent<PrerequisiteNoFeature>(c => { c.m_Feature = AbilitySelection.ToReference<BlueprintFeatureReference>(); });

            MastermindLegacySelection.Configure();
            OverlordLegacySelection.Configure();
            EdgeLordLegacySelection.Configure();
            HeroLegacySelection.Configure();
            GodEmperorLegacySelection.Configure();
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

        public static void Register(BlueprintProgression prog) {
            ClassSelection.AddFeatures(prog);
            AbilitySelection.AddFeatures(prog);
        }

        public static void ConfigureStep2() {
            OracleLegacy.Configure();
            SorcererLegacy.Configure();
            RogueLegacy.Configure();
            KineticLegacy.Configure();
            BardLegacy.Configure();
            BarbarianLegacy.Configure();
            DruidBaseLegacy.Configure();
            WitchBaseLegacy.Configure();
            FighterBasicLegacy.Configure();
            Fighter2HandedLegacy.Configure();
            FighterShieldLegacy.Configure();
            PaladinBaseLegacy.Configure();
            MonkLegacy.Configure();
            HeroicLegacy.Configure();
            ShamanLegacy.Configure();
            MagusLegacy.Configure();
            SkaldBaseLegacy.Configure();
            ShifterBaseLegacy.Configure();
            DreadKnightLegacy.Configure();
            KineticKnightLegacy.Configure();
            KineticOverwhelmingSoulLegacy.Configure();
            KineticDarkElementalistLegacy.Configure();
            MonkScaledFistLegacy.Configure();
            SkaldSilverTongueLegacy.Configure();
            SkaldVoiceLegacy.Configure();
            ShifterStingerLegacy.Configure();
            ShifterDragonLegacy.Configure();
            InquisitorTacticianLegacy.Configure();
            InquisitorJudgeLegacy.Configure();
            InquisitorDomainLordLegacy.Configure();
            BloodragerChimeraLegacy.Configure();
            PlayerComputerNerdLegacy.Configure();
            PlayerPartTimeWorkerLegacy.Configure();
            //always do this last to ensure any legacy that might get an arcana goes before
            ArcanaSelection.Configure();
            OverpoweredAbilitySelection.AddToSelection(GetOverwhelmingFeature());

        }

        public static void ConfigureStep3() {
            BarbarianLegacy.PatchProgression();
            BardLegacy.PatchProgression();
            FighterBasicLegacy.PatchProgression();
            Fighter2HandedLegacy.PatchProgression();
            FighterShieldLegacy.PatchProgression();
            MonkLegacy.PatchProgression();
            MonkScaledFistLegacy.PatchProgression();
            RogueLegacy.PatchProgression();
            DruidBaseLegacy.PatchProgression();
            WitchBaseLegacy.PatchProgression();
            SkaldBaseLegacy.PatchProgression();
            SkaldSilverTongueLegacy.PatchProgression();
            SkaldVoiceLegacy.PatchProgression();
            KineticLegacy.PatchProgression();
            KineticKnightLegacy.PatchProgression();
            KineticOverwhelmingSoulLegacy.PatchProgression();
            KineticDarkElementalistLegacy.PatchProgression();
            ShifterBaseLegacy.PatchProgression();
            ShifterStingerLegacy.PatchProgression();
            ShifterDragonLegacy.PatchProgression();
            OracleLegacy.PatchProgression();
            SorcererLegacy.PatchProgression();
            ShamanLegacy.PatchProgression();
            PaladinBaseLegacy.PatchProgression();
            InquisitorTacticianLegacy.PatchProgression();
            InquisitorJudgeLegacy.PatchProgression();
            InquisitorDomainLordLegacy.PatchProgression();
            BloodragerChimeraLegacy.PatchProgression();
            PlayerComputerNerdLegacy.PatchProgression();
            PlayerPartTimeWorkerLegacy.PatchProgression();

            LegacySelection.Finish();
            MastermindLegacySelection.Finish();
            OverlordLegacySelection.Finish();
            EdgeLordLegacySelection.Finish();
            HeroLegacySelection.Finish();
            GodEmperorLegacySelection.Finish();
        }

        public static void Finish() {
            AbilitySelection.AddPrerequisite<PrerequisiteClassLevel>(c => {
                c.m_CharacterClass = Classes.IsekaiProtagonist.IsekaiProtagonistClass.GetReference();
                c.Level = 5;
            });
        }
    }
}
