using IsekaiMod.Content.Classes.IsekaiProtagonist;
using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using System.Collections.Generic;
using System.Linq;

namespace IsekaiMod.Content.Classes.Deathsnatcher
{
    class DeathsnatcherClassProgression
    {
        // Animal Rank
        private static readonly BlueprintFeature AnimalCompanionRank = Resources.GetBlueprint<BlueprintFeature>("1670990255e4fe948a863bafd5dbda5d");

        public static void Add()
        {
            // TODO: find out why sting attack doesn't work

            // TODO: add missing buffs for deathsnatcher
            // TODO: add scaling natural armor, strength and dexterity (like animal companion)
            // TODO: make deathsnatcher grow from small to medium that gives +10 boost to all attributes

            // 10th level feature
            // TODO: add feature to increase animate dead uses to 10 at 10th level

            // 19t level feature
            // TODO: add feature to increase animate dead uses to infinity at 19th level
            // TODO: add feature to increase create undead uses to 3 at 19th level
            // TODO: add feature to increase finger of death uses to 3 at 19th level

            // TODO: re-order the features in the progression. DONT FORGET BEFORE RELEASE

            var Pounce = Resources.GetBlueprint<BlueprintFeature>("1a8149c09e0bdfc48a305ee6ac3729a8");
            var DeathsnatcherPoisonFeature = Resources.GetBlueprint<BlueprintFeature>("9547e5db05fa6f143a1867c93b258fe0");
            var DeathsnatcherSoulRendFeature = Resources.GetBlueprint<BlueprintFeature>("c8b468508a76c5140a9a2af00077753d");

            var DeathsnatcherSizeBabyFeature = Resources.GetModBlueprint<BlueprintFeature>("DeathsnatcherSizeBabyFeature");
            var DeathsnatcherResistances = Resources.GetModBlueprint<BlueprintFeature>("DeathsnatcherResistances");
            var DeathsnatcherFastHealing = Resources.GetModBlueprint<BlueprintFeature>("DeathsnatcherFastHealing");
            var DeathsnatcherCommandUndeadFeature = Resources.GetModBlueprint<BlueprintFeature>("DeathsnatcherCommandUndeadFeature");
            var DeathsnatcherAnimateDeadFeature = Resources.GetModBlueprint<BlueprintFeature>("DeathsnatcherAnimateDeadFeature");
            var DeathsnatcherCreateUndeadFeature = Resources.GetModBlueprint<BlueprintFeature>("DeathsnatcherCreateUndeadFeature");
            var DeathsnatcherFingerOfDeathFeature = Resources.GetModBlueprint<BlueprintFeature>("DeathsnatcherFingerOfDeathFeature");

            // Deathsnatcher Level Progression
            var DeathsnatcherCompanionProgression = Helpers.CreateBlueprint<BlueprintProgression>("DeathsnatcherCompanionProgression", bp => {
                bp.m_AllowNonContextActions = false;
                bp.SetName("");
                bp.SetDescription("");
                bp.IsClassFeature = true;
                bp.m_Classes = new BlueprintProgression.ClassWithLevel[] {
                    new BlueprintProgression.ClassWithLevel {
                        m_Class = IsekaiProtagonistClass.GetReference(),
                        AdditionalLevel = 0
                    }
                };
                bp.m_Archetypes = new BlueprintProgression.ArchetypeWithLevel[0];
                bp.LevelEntries = Enumerable.Range(2, 20)
                    .Select(i => new LevelEntry
                    {
                        Level = i,
                        m_Features = new List<BlueprintFeatureBaseReference> {
                            AnimalCompanionRank.ToReference<BlueprintFeatureBaseReference>()
                        },
                    })
                    .ToArray();
                bp.ForAllOtherClasses = false;
                bp.GiveFeaturesForPreviousLevels = true;
            });

            // Deathsnatcher Class Progression
            var DeathsnatcherClassProgression = Helpers.CreateBlueprint<BlueprintProgression>("DeathsnatcherClassProgression", bp => {
                bp.SetName("");
                bp.SetDescription("This bipedal jackal has vulture wings and a rat tail ending in a scorpion’s stinger. Each of its four arms ends in a clawed hand.");
                bp.m_AllowNonContextActions = false;
                bp.IsClassFeature = true;
                bp.m_FeaturesRankIncrease = null;
                bp.m_Classes = new BlueprintProgression.ClassWithLevel[] {
                    new BlueprintProgression.ClassWithLevel {
                        m_Class = DeathsnatcherClass.GetReference(),
                        AdditionalLevel = 0
                    }
                };
            });
            DeathsnatcherClassProgression.LevelEntries = new LevelEntry[] {
                Helpers.LevelEntry(1, DeathsnatcherResistances, DeathsnatcherPoisonFeature),
                Helpers.LevelEntry(4, DeathsnatcherCommandUndeadFeature, Pounce, DeathsnatcherSizeBabyFeature),
                Helpers.LevelEntry(7, DeathsnatcherAnimateDeadFeature),
                Helpers.LevelEntry(10, DeathsnatcherSoulRendFeature),
                Helpers.LevelEntry(13, DeathsnatcherCreateUndeadFeature),
                Helpers.LevelEntry(16, DeathsnatcherFingerOfDeathFeature),
                Helpers.LevelEntry(20, DeathsnatcherFastHealing),
            };
            DeathsnatcherClassProgression.UIGroups = new UIGroup[] {
                Helpers.CreateUIGroup(DeathsnatcherCommandUndeadFeature, DeathsnatcherAnimateDeadFeature, DeathsnatcherCreateUndeadFeature, DeathsnatcherFingerOfDeathFeature),
                Helpers.CreateUIGroup(DeathsnatcherResistances, Pounce, DeathsnatcherSoulRendFeature, DeathsnatcherFastHealing),
            };
            DeathsnatcherClassProgression.m_UIDeterminatorsGroup = new BlueprintFeatureBaseReference[] {
                DeathsnatcherResistances.ToReference<BlueprintFeatureBaseReference>()
            };

            // Register Deathsnatcher Class Progression
            DeathsnatcherClass.SetProgression(DeathsnatcherClassProgression);
        }
        public static BlueprintProgression GetCompanionProgression()
        {
            return Resources.GetModBlueprint<BlueprintProgression>("DeathsnatcherCompanionProgression");
        }
    }
}
