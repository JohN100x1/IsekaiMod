using IsekaiMod.Content.Classes.IsekaiProtagonist;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Localization;
using System.Collections.Generic;
using System.Linq;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Classes.Deathsnatcher {

    internal class DeathsnatcherProgression {

        // Animal Rank
        private static readonly BlueprintFeature AnimalCompanionRank = BlueprintTools.GetBlueprint<BlueprintFeature>("1670990255e4fe948a863bafd5dbda5d");

        public static void Add() {
            var Pounce = BlueprintTools.GetBlueprint<BlueprintFeature>("1a8149c09e0bdfc48a305ee6ac3729a8");
            var DeathsnatcherSoulRendFeature = BlueprintTools.GetBlueprint<BlueprintFeature>("c8b468508a76c5140a9a2af00077753d");
            var Evasion = BlueprintTools.GetBlueprint<BlueprintFeature>("576933720c440aa4d8d42b0c54b77e80");
            var ImprovedEvasion = BlueprintTools.GetBlueprint<BlueprintFeature>("ce96af454a6137d47b9c6a1e02e66803");

            var DeathsnatcherPoisonSting = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "DeathsnatcherPoisonSting");
            var DeathsnatcherResistances = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "DeathsnatcherResistances");
            var DeathsnatcherFastHealing = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "DeathsnatcherFastHealing");
            var DeathsnatcherSizeBabyFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "DeathsnatcherSizeBabyFeature");
            var DeathsnatcherCommandUndeadFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "DeathsnatcherCommandUndeadFeature");
            var DeathsnatcherAnimateDeadFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "DeathsnatcherAnimateDeadFeature");
            var DeathsnatcherCreateUndeadFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "DeathsnatcherCreateUndeadFeature");
            var DeathsnatcherFingerOfDeathFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "DeathsnatcherFingerOfDeathFeature");
            var DeathsnatcherAnimateDeadAdditionalUse = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "DeathsnatcherAnimateDeadAdditionalUse");
            var DeathsnatcherUndeadMaster = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "DeathsnatcherUndeadMaster");

            // Deathsnatcher Level Progression
            var DeathsnatcherCompanionProgression = Helpers.CreateBlueprint<BlueprintProgression>(IsekaiContext, "DeathsnatcherCompanionProgression", bp => {
                bp.SetName(StaticReferences.Strings.Null);
                bp.SetDescription(StaticReferences.Strings.Null);
                bp.IsClassFeature = true;
                bp.m_FeaturesRankIncrease = new List<BlueprintFeatureReference>();
                bp.m_Archetypes = new BlueprintProgression.ArchetypeWithLevel[0];
                bp.m_Classes = new BlueprintProgression.ClassWithLevel[] {
                    new BlueprintProgression.ClassWithLevel {
                        m_Class = IsekaiProtagonistClass.GetReference(),
                        AdditionalLevel = 0
                    }
                };
                bp.LevelEntries = Enumerable.Range(2, 20)
                    .Select(i => new LevelEntry {
                        Level = i,
                        m_Features = new List<BlueprintFeatureBaseReference> {
                            AnimalCompanionRank.ToReference<BlueprintFeatureBaseReference>()
                        },
                    })
                    .ToArray();
                bp.UIGroups = new UIGroup[0];
                bp.m_UIDeterminatorsGroup = new BlueprintFeatureBaseReference[0];
                bp.GiveFeaturesForPreviousLevels = true;
            });

            // Deathsnatcher Class Progression
            var DeathsnatcherClassProgression = Helpers.CreateBlueprint<BlueprintProgression>(IsekaiContext, "DeathsnatcherClassProgression", bp => {
                bp.SetName(StaticReferences.Strings.Null);
                bp.SetDescription(IsekaiContext, "This bipedal jackal has vulture wings and a rat tail ending in a scorpion’s stinger. Each of its four arms ends in a clawed hand.");
                bp.IsClassFeature = true;
                bp.m_FeaturesRankIncrease = new List<BlueprintFeatureReference>();
                bp.m_Archetypes = new BlueprintProgression.ArchetypeWithLevel[0];
                bp.m_AlternateProgressionClasses = new BlueprintProgression.ClassWithLevel[0];
                bp.m_Classes = new BlueprintProgression.ClassWithLevel[] {
                    new BlueprintProgression.ClassWithLevel {
                        m_Class = DeathsnatcherClass.GetReference(),
                        AdditionalLevel = 0
                    }
                };
                bp.LevelEntries = new LevelEntry[] {
                    Helpers.CreateLevelEntry(1, DeathsnatcherResistances, /*DeathsnatcherHiddenFacts,*/ DeathsnatcherCommandUndeadFeature, DeathsnatcherSizeBabyFeature),
                    Helpers.CreateLevelEntry(2, Evasion),
                    Helpers.CreateLevelEntry(4, Pounce),
                    Helpers.CreateLevelEntry(7, DeathsnatcherAnimateDeadFeature),
                    Helpers.CreateLevelEntry(10, DeathsnatcherAnimateDeadAdditionalUse, DeathsnatcherPoisonSting),
                    Helpers.CreateLevelEntry(13, DeathsnatcherCreateUndeadFeature),
                    Helpers.CreateLevelEntry(15, DeathsnatcherSoulRendFeature, ImprovedEvasion),
                    Helpers.CreateLevelEntry(16, DeathsnatcherFingerOfDeathFeature),
                    Helpers.CreateLevelEntry(18, DeathsnatcherFastHealing),
                    Helpers.CreateLevelEntry(20, DeathsnatcherUndeadMaster),
                };
                bp.UIGroups = new UIGroup[] {
                    Helpers.CreateUIGroup(DeathsnatcherCommandUndeadFeature, DeathsnatcherAnimateDeadFeature, DeathsnatcherAnimateDeadAdditionalUse, DeathsnatcherCreateUndeadFeature, DeathsnatcherFingerOfDeathFeature, DeathsnatcherUndeadMaster),
                    Helpers.CreateUIGroup(DeathsnatcherSizeBabyFeature, Pounce, DeathsnatcherPoisonSting, DeathsnatcherSoulRendFeature, DeathsnatcherFastHealing),
                };
                bp.m_UIDeterminatorsGroup = new BlueprintFeatureBaseReference[] {
                    DeathsnatcherResistances.ToReference<BlueprintFeatureBaseReference>()
                };
            });

            // Register Deathsnatcher Class Progression
            DeathsnatcherClass.SetProgression(DeathsnatcherClassProgression);
        }

        public static BlueprintProgression GetCompanionProgression() {
            return BlueprintTools.GetModBlueprint<BlueprintProgression>(IsekaiContext, "DeathsnatcherCompanionProgression");
        }
    }
}