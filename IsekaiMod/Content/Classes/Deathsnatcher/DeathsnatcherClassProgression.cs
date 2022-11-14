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
            var Pounce = Resources.GetBlueprint<BlueprintFeature>("1a8149c09e0bdfc48a305ee6ac3729a8");
            var DeathsnatcherSoulRendFeature = Resources.GetBlueprint<BlueprintFeature>("c8b468508a76c5140a9a2af00077753d");
            var ColdResistance30 = Resources.GetBlueprint<BlueprintFeature>("317b2de0512c81d47bb7895e44eddc60");
            var FireResistance30 = Resources.GetBlueprint<BlueprintFeature>("4c7bf052b24c61b4d8da4e42785f2ea3");

            var DeathSnatcherFastHealing = Resources.GetModBlueprint<BlueprintFeature>("DeathSnatcherFastHealing");

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
                Helpers.LevelEntry(1, DeathsnatcherSoulRendFeature),
                Helpers.LevelEntry(3, ColdResistance30, FireResistance30),
                Helpers.LevelEntry(7, Pounce),
                Helpers.LevelEntry(20, DeathSnatcherFastHealing),
            };
            DeathsnatcherClassProgression.UIGroups = new UIGroup[0];
            DeathsnatcherClassProgression.m_UIDeterminatorsGroup = new BlueprintFeatureBaseReference[0];

            // Register Deathsnatcher Class Progression
            DeathsnatcherClass.SetProgression(DeathsnatcherClassProgression);
        }
        public static BlueprintProgression GetCompanionProgression()
        {
            return Resources.GetModBlueprint<BlueprintProgression>("DeathsnatcherCompanionProgression");
        }
    }
}
