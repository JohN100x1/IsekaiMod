﻿using IsekaiMod.Content.Classes.IsekaiProtagonist;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.EdgeLord;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.GodEmperor;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Hero;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Mastermind;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Overlord;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.InheritedClassFeature {

    internal class OracleLegacy {
        private static BlueprintProgression prog;

        public static void Configure() {
            ExtraOracleSelection.Configure();
            var OracleSelection = ExtraOracleSelection.Get();

            prog = Helpers.CreateBlueprint<BlueprintProgression>(IsekaiContext, "OracleLegacyProgression", bp => {
                bp.SetName(IsekaiContext, "Oracle Legacy - Seeker of Truth");
                bp.SetDescription(IsekaiContext, "Seekers of Truth are driven by a desire to uncover the secrets behind the fundamental forces of nature. \n" +
                    "Because of their unique perspective as otherworlders, they are able to approach the world with a fresh and unbiased eye, allowing them to see beyond the surface of things and seek out the deeper truth behind the world around them. \n" +
                    "They are driven by a desire to uncover the secrets of the world that would otherwise remain hidden, and are not satisfied with simply accepting things at face value. \n" +
                    "This allows them to uncover the secrets of the world that are often only revealed to mortals through revelations.");
                bp.GiveFeaturesForPreviousLevels = false;
                bp.IsClassFeature = true;
                bp.m_Classes = new BlueprintProgression.ClassWithLevel[] {
                    new BlueprintProgression.ClassWithLevel {
                        m_Class = IsekaiProtagonistClass.GetReference(),
                        AdditionalLevel = 0
                    }
                };
                bp.LevelEntries = new LevelEntry[] {
                    Helpers.CreateLevelEntry(1,  OracleSelection),
                    Helpers.CreateLevelEntry(3, OracleSelection),
                    Helpers.CreateLevelEntry(6, OracleSelection),
                    Helpers.CreateLevelEntry(9, OracleSelection),
                    Helpers.CreateLevelEntry(12, OracleSelection),
                    Helpers.CreateLevelEntry(15, OracleSelection),
                    Helpers.CreateLevelEntry(18, OracleSelection),
                };
                bp.UIGroups = new UIGroup[] {
                    Helpers.CreateUIGroup(OracleSelection)
                };

            });
            LegacySelection.RegisterForFeat(prog);
            LegacySelection.Register(prog);
            EdgeLordLegacySelection.Register(prog);
            GodEmperorLegacySelection.Register(prog);
            HeroLegacySelection.Register(prog);
            MastermindLegacySelection.Register(prog);
            OverlordLegacySelection.Prohibit(prog);
        }

        public static void PatchProgression() {
            BlueprintCharacterClassReference myClass = IsekaiProtagonistClass.GetReference();
            BlueprintCharacterClassReference refClass = ClassTools.Classes.OracleClass.ToReference<BlueprintCharacterClassReference>();
            PatchTools.PatchClassIntoFeatureOfReferenceClass(FeatTools.Selections.OracleCurseSelection, myClass, refClass, 0, new BlueprintFeatureBase[] { });
            PatchTools.PatchClassIntoFeatureOfReferenceClass(FeatTools.Selections.OracleMysterySelection, myClass, refClass, 0, new BlueprintFeatureBase[] { });
            PatchTools.PatchClassIntoFeatureOfReferenceClass(FeatTools.Selections.OracleRevelationSelection, myClass, refClass, 0, new BlueprintFeatureBase[] { });
            PatchTools.PatchClassIntoFeatureOfReferenceClass(FeatTools.Selections.OracleCureOrInflictSelection, myClass, refClass, 0, new BlueprintFeatureBase[] { });
        }
        public static BlueprintProgression Get() {
            if (prog != null) return prog;
            return BlueprintTools.GetModBlueprint<BlueprintProgression>(IsekaiContext, "OracleLegacyProgression");
        }
    }
    internal class ExtraOracleSelection {
        public static void Configure() {

            var CurseSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "IsekaiOracleCurseSelection", bp => {
                bp.SetName(IsekaiContext, "Divine Curse");
                bp.SetDescription(IsekaiContext, "Gain a curse, but some curses are blessings in disguise.");
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.m_AllFeatures = FeatTools.Selections.OracleCurseSelection.m_AllFeatures;
            });
            var MysterySelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "IsekaiOracleMysterySelection", bp => {
                bp.SetName(IsekaiContext, "Divine Mystery");
                bp.SetDescription(IsekaiContext, "Master another part of reality...");
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.m_AllFeatures = FeatTools.Selections.OracleMysterySelection.m_AllFeatures;
            });

            var PrimarySelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "IsekaiOracleSelection", bp => {
                bp.SetName(IsekaiContext, "Divine Inheritance");
                bp.SetDescription(IsekaiContext, "As you get closer and closer to the truth of divinity you gain a new Mystery, Revelation, or perhaps a curse from a jealous god?");
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.m_AllFeatures = new BlueprintFeatureReference[] {
                    CurseSelection.ToReference<BlueprintFeatureReference>(),
                    MysterySelection.ToReference<BlueprintFeatureReference>(),
                    FeatTools.Selections.OracleRevelationSelection.ToReference<BlueprintFeatureReference>(),
                    FeatTools.Selections.OracleCureOrInflictSelection.ToReference<BlueprintFeatureReference>()
                };
            });

        }
        public static BlueprintFeatureSelection Get() {
            return BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "IsekaiOracleSelection");
        }
        public static BlueprintFeatureReference GetReference() {
            return Get().ToReference<BlueprintFeatureReference>();
        }
    }
}
