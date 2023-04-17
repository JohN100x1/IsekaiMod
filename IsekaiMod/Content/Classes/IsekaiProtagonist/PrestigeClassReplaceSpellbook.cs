using IsekaiMod.Content.Classes.IsekaiProtagonist.Archetypes;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Localization;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Classes.IsekaiProtagonist {

    internal class PrestigeClassReplaceSpellbook {

        private struct PrestigeSpellbookData {
            public string name;
            public LocalizedString description;
            public int requiredLevel;
            public FeatureGroup[] featureGroups;
            public BlueprintFeatureSelection selection;
        }

        private struct ReplaceSpellbookData {
            public string name;
            public string displayName;
            public BlueprintCharacterClassReference characterClassReference;
            public BlueprintSpellbookReference spellbookReference;
            public BlueprintArchetypeReference includedArchetype;
            public BlueprintArchetypeReference[] excludedArchetypes;
        }

        public static void Patch() {
            PrestigeSpellbookData[] PrestigeSpellbooks = new PrestigeSpellbookData[] {
            new PrestigeSpellbookData {
                name = "Loremaster",
                description = StaticReferences.Strings.ReplaceSpellbookDescription.Loremaster,
                requiredLevel = 3,
                featureGroups = new FeatureGroup[] { FeatureGroup.MythicAdditionalProgressions },
                selection = FeatTools.Selections.LoremasterSpellbookSelection
            },
            new PrestigeSpellbookData {
                name = "HellknightSignifier",
                description = StaticReferences.Strings.ReplaceSpellbookDescription.HellknightSignifier,
                requiredLevel = 3,
                featureGroups = new FeatureGroup[] { FeatureGroup.HellknightSigniferSpellbook },
                selection = FeatTools.Selections.HellknightSigniferSpellbook
            },
            new PrestigeSpellbookData {
                name = "ArcaneTrickster",
                description = StaticReferences.Strings.ReplaceSpellbookDescription.ArcaneTrickster,
                requiredLevel = 2,
                featureGroups = new FeatureGroup[] { FeatureGroup.ArcaneTricksterSpellbook },
                selection = FeatTools.Selections.ArcaneTricksterSpellbookSelection
            },
            new PrestigeSpellbookData {
                name = "MysticTheurgeArcane",
                description = StaticReferences.Strings.ReplaceSpellbookDescription.MysticTheurgeArcane,
                requiredLevel = 2,
                featureGroups = new FeatureGroup[] { FeatureGroup.MysticTheurgeArcaneSpellbook },
                selection = FeatTools.Selections.MysticTheurgeArcaneSpellbookSelection
            },
            new PrestigeSpellbookData {
                name = "MysticTheurgeDivine",
                description = StaticReferences.Strings.ReplaceSpellbookDescription.MysticTheurgeDivine,
                requiredLevel = 2,
                featureGroups = new FeatureGroup[] { FeatureGroup.MysticTheurgeDivineSpellbook },
                selection = FeatTools.Selections.MysticTheurgeDivineSpellbookSelection
            },
            new PrestigeSpellbookData {
                name = "DragonDisciple",
                description = StaticReferences.Strings.ReplaceSpellbookDescription.DragonDisciple,
                requiredLevel = 2,
                featureGroups = new FeatureGroup[] { FeatureGroup.DragonDiscipleSpellbook },
                selection = FeatTools.Selections.DragonDiscipleSpellbookSelection
            },
            new PrestigeSpellbookData {
                name = "EldritchKnight",
                description = StaticReferences.Strings.ReplaceSpellbookDescription.EldritchKnight,
                requiredLevel = 2,
                featureGroups = new FeatureGroup[] { FeatureGroup.EldritchKnightSpellbook },
                selection = FeatTools.Selections.EldritchKnightSpellbookSelection
            },
            new PrestigeSpellbookData {
                name = "WinterWitch",
                description = StaticReferences.Strings.ReplaceSpellbookDescription.WinterWitch,
                requiredLevel = 2,
                featureGroups = new FeatureGroup[0],
                selection = FeatTools.Selections.WinterWitchSpellbookSelection
            },
        };
            ReplaceSpellbookData[] IsekaiSpellbooks = new ReplaceSpellbookData[] {
                new ReplaceSpellbookData {
                    name = "Isekai",
                    displayName = "Isekai Protagonist",
                    characterClassReference = IsekaiProtagonistClass.GetReference(),
                    spellbookReference = IsekaiProtagonistSpellbook.GetReference(),
                    includedArchetype = null,
                    excludedArchetypes = new BlueprintArchetypeReference[] {
                        GodEmperorArchetype.GetReference(),
                        MastermindArchetype.GetReference(),
                        OverlordArchetype.GetReference(),
                    }
                },
                new ReplaceSpellbookData {
                    name = "GodEmperor",
                    displayName = "God Emperor",
                    characterClassReference = IsekaiProtagonistClass.GetReference(),
                    spellbookReference = GodEmperorSpellbook.GetReference(),
                    includedArchetype = GodEmperorArchetype.GetReference(),
                    excludedArchetypes = new BlueprintArchetypeReference[] {
                        MastermindArchetype.GetReference(),
                        OverlordArchetype.GetReference(),
                    }
                },
                new ReplaceSpellbookData {
                    name = "Mastermind",
                    displayName = "Mastermind",
                    characterClassReference = IsekaiProtagonistClass.GetReference(),
                    spellbookReference = MastermindSpellbook.GetReference(),
                    includedArchetype = MastermindArchetype.GetReference(),
                    excludedArchetypes = new BlueprintArchetypeReference[] {
                        GodEmperorArchetype.GetReference(),
                        OverlordArchetype.GetReference(),
                    }
                },
                new ReplaceSpellbookData {
                    name = "Overlord",
                    displayName = "Overlord",
                    characterClassReference = IsekaiProtagonistClass.GetReference(),
                    spellbookReference = OverlordSpellbook.GetReference(),
                    includedArchetype = OverlordArchetype.GetReference(),
                    excludedArchetypes = new BlueprintArchetypeReference[] {
                        GodEmperorArchetype.GetReference(),
                        MastermindArchetype.GetReference(),
                    }
                },
            };

            foreach (PrestigeSpellbookData prestigeSpellbook in PrestigeSpellbooks) {
                foreach (ReplaceSpellbookData isekaiSpellbook in IsekaiSpellbooks) {
                    AddPrestigeSpellbook(isekaiSpellbook, prestigeSpellbook);
                }
            }
        }

        private static void AddPrestigeSpellbook(ReplaceSpellbookData replaceSpellbookData, PrestigeSpellbookData prestigeSpellbookData) {
            string combinedName = $"{prestigeSpellbookData.name}{replaceSpellbookData.name}";

            var feature = Helpers.CreateBlueprint<BlueprintFeatureReplaceSpellbook>(IsekaiContext, combinedName, bp => {
                bp.SetName(IsekaiContext, replaceSpellbookData.displayName);
                bp.SetDescription(prestigeSpellbookData.description);
                bp.Groups = prestigeSpellbookData.featureGroups;
                bp.HideInUI = true;
                bp.HideNotAvailibleInUI = true;
                bp.HideInCharacterSheetAndLevelUp = false;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.m_Spellbook = replaceSpellbookData.spellbookReference;
                bp.AddComponent<PrerequisiteClassSpellLevel>(c => {
                    c.Group = Prerequisite.GroupType.All;
                    c.m_CharacterClass = replaceSpellbookData.characterClassReference;
                    c.RequiredSpellLevel = prestigeSpellbookData.requiredLevel;
                });

                if (replaceSpellbookData.includedArchetype != null) {
                    bp.AddComponent<PrerequisiteArchetypeLevel>(c => {
                        c.Group = Prerequisite.GroupType.All;
                        c.m_CharacterClass = replaceSpellbookData.characterClassReference;
                        c.m_Archetype = replaceSpellbookData.includedArchetype;
                        c.Level = 1;
                    });
                }

                foreach (BlueprintArchetypeReference archetypeReference in replaceSpellbookData.excludedArchetypes) {
                    bp.AddComponent<PrerequisiteNoArchetype>(c => {
                        c.Group = Prerequisite.GroupType.All;
                        c.m_CharacterClass = replaceSpellbookData.characterClassReference;
                        c.m_Archetype = archetypeReference;
                    });
                }
            });
            prestigeSpellbookData.selection.AddToSelection(feature);
        }
    }
}