using IsekaiMod.Content.Classes.IsekaiProtagonist.Archetypes.Mastermind;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using System;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Classes.IsekaiProtagonist {

    internal class PrestigeClassReplaceSpellbook {
        public static void Patch() {
            PatchIsekai();
            PatchMastermind();
            PatchOverlord();
        }

        public static void PatchIsekai() {
            var LoremasterIsekai = CreateReplaceIsekaiSpellbook("LoremasterIsekai", 3, bp => {
                bp.SetDescription(StaticReferences.Strings.ReplaceSpellbookDescription.Loremaster);
                bp.Groups = new FeatureGroup[] { FeatureGroup.MythicAdditionalProgressions };
            });
            var HellknightSignifierIsekai = CreateReplaceIsekaiSpellbook("HellknightSignifierIsekai", 3, bp => {
                bp.SetDescription(StaticReferences.Strings.ReplaceSpellbookDescription.HellknightSignifier);
                bp.Groups = new FeatureGroup[] { FeatureGroup.HellknightSigniferSpellbook };
            });
            var ArcaneTricksterIsekai = CreateReplaceIsekaiSpellbook("ArcaneTricksterIsekai", 2, bp => {
                bp.SetDescription(StaticReferences.Strings.ReplaceSpellbookDescription.ArcaneTrickster);
                bp.Groups = new FeatureGroup[] { FeatureGroup.ArcaneTricksterSpellbook };
            });
            var MysticTheurgeArcaneIsekai = CreateReplaceIsekaiSpellbook("MysticTheurgeArcaneIsekai", 2, bp => {
                bp.SetDescription(StaticReferences.Strings.ReplaceSpellbookDescription.MysticTheurgeArcane);
                bp.Groups = new FeatureGroup[] { FeatureGroup.MysticTheurgeArcaneSpellbook };
            });
            var MysticTheurgeDivineIsekai = CreateReplaceIsekaiSpellbook("MysticTheurgeDivineIsekai", 2, bp => {
                bp.SetDescription(StaticReferences.Strings.ReplaceSpellbookDescription.MysticTheurgeDivine);
                bp.Groups = new FeatureGroup[] { FeatureGroup.MysticTheurgeDivineSpellbook };
            });
            var DragonDiscipleIsekai = CreateReplaceIsekaiSpellbook("DragonDiscipleIsekai", 2, bp => {
                bp.SetDescription(StaticReferences.Strings.ReplaceSpellbookDescription.DragonDisciple);
                bp.Groups = new FeatureGroup[] { FeatureGroup.DragonDiscipleSpellbook };
            });
            var EldritchKnightIsekai = CreateReplaceIsekaiSpellbook("EldritchKnightIsekai", 2, bp => {
                bp.SetDescription(StaticReferences.Strings.ReplaceSpellbookDescription.EldritchKnight);
                bp.Groups = new FeatureGroup[] { FeatureGroup.EldritchKnightSpellbook };
            });
            var WinterWitchIsekai = CreateReplaceIsekaiSpellbook("WinterWitchIsekai", 2, bp => {
                bp.SetDescription(StaticReferences.Strings.ReplaceSpellbookDescription.WinterWitch);
                bp.Groups = new FeatureGroup[0];
            });


            FeatTools.Selections.LoremasterSpellbookSelection.AddToSelection(LoremasterIsekai);
            FeatTools.Selections.HellknightSigniferSpellbook.AddToSelection(HellknightSignifierIsekai);
            FeatTools.Selections.ArcaneTricksterSpellbookSelection.AddToSelection(ArcaneTricksterIsekai);
            FeatTools.Selections.MysticTheurgeArcaneSpellbookSelection.AddToSelection(MysticTheurgeArcaneIsekai);
            FeatTools.Selections.MysticTheurgeDivineSpellbookSelection.AddToSelection(MysticTheurgeDivineIsekai);
            FeatTools.Selections.DragonDiscipleSpellbookSelection.AddToSelection(DragonDiscipleIsekai);
            FeatTools.Selections.EldritchKnightSpellbookSelection.AddToSelection(EldritchKnightIsekai);
            FeatTools.Selections.WinterWitchSpellbookSelection.AddToSelection(WinterWitchIsekai);
        }

        public static void PatchMastermind() {
            var LoremasterMastermind = CreateReplaceMastermindSpellbook("LoremasterMastermind", 3, bp => {
                bp.SetDescription(StaticReferences.Strings.ReplaceSpellbookDescription.Loremaster);
                bp.Groups = new FeatureGroup[] { FeatureGroup.MythicAdditionalProgressions };
            });
            var HellknightSignifierMastermind = CreateReplaceMastermindSpellbook("HellknightSignifierMastermind", 3, bp => {
                bp.SetDescription(StaticReferences.Strings.ReplaceSpellbookDescription.HellknightSignifier);
                bp.Groups = new FeatureGroup[] { FeatureGroup.HellknightSigniferSpellbook };
            });
            var ArcaneTricksterMastermind = CreateReplaceMastermindSpellbook("ArcaneTricksterMastermind", 2, bp => {
                bp.SetDescription(StaticReferences.Strings.ReplaceSpellbookDescription.ArcaneTrickster);
                bp.Groups = new FeatureGroup[] { FeatureGroup.ArcaneTricksterSpellbook };
            });
            var MysticTheurgeArcaneMastermind = CreateReplaceMastermindSpellbook("MysticTheurgeArcaneMastermind", 2, bp => {
                bp.SetDescription(StaticReferences.Strings.ReplaceSpellbookDescription.MysticTheurgeArcane);
                bp.Groups = new FeatureGroup[] { FeatureGroup.MysticTheurgeArcaneSpellbook };
            });
            var MysticTheurgeDivineMastermind = CreateReplaceMastermindSpellbook("MysticTheurgeDivineMastermind", 2, bp => {
                bp.SetDescription(StaticReferences.Strings.ReplaceSpellbookDescription.MysticTheurgeDivine);
                bp.Groups = new FeatureGroup[] { FeatureGroup.MysticTheurgeDivineSpellbook };
            });
            var DragonDiscipleMastermind = CreateReplaceMastermindSpellbook("DragonDiscipleMastermind", 2, bp => {
                bp.SetDescription(StaticReferences.Strings.ReplaceSpellbookDescription.DragonDisciple);
                bp.Groups = new FeatureGroup[] { FeatureGroup.DragonDiscipleSpellbook };
            });
            var EldritchKnightMastermind = CreateReplaceMastermindSpellbook("EldritchKnightMastermind", 2, bp => {
                bp.SetDescription(StaticReferences.Strings.ReplaceSpellbookDescription.EldritchKnight);
                bp.Groups = new FeatureGroup[] { FeatureGroup.EldritchKnightSpellbook };
            });
            var WinterWitchMastermind = CreateReplaceMastermindSpellbook("WinterWitchMastermind", 2, bp => {
                bp.SetDescription(StaticReferences.Strings.ReplaceSpellbookDescription.WinterWitch);
                bp.Groups = new FeatureGroup[0];
            });


            FeatTools.Selections.LoremasterSpellbookSelection.AddToSelection(LoremasterMastermind);
            FeatTools.Selections.HellknightSigniferSpellbook.AddToSelection(HellknightSignifierMastermind);
            FeatTools.Selections.ArcaneTricksterSpellbookSelection.AddToSelection(ArcaneTricksterMastermind);
            FeatTools.Selections.MysticTheurgeArcaneSpellbookSelection.AddToSelection(MysticTheurgeArcaneMastermind);
            FeatTools.Selections.MysticTheurgeDivineSpellbookSelection.AddToSelection(MysticTheurgeDivineMastermind);
            FeatTools.Selections.DragonDiscipleSpellbookSelection.AddToSelection(DragonDiscipleMastermind);
            FeatTools.Selections.EldritchKnightSpellbookSelection.AddToSelection(EldritchKnightMastermind);
            FeatTools.Selections.WinterWitchSpellbookSelection.AddToSelection(WinterWitchMastermind);
        }

        public static void PatchOverlord() {
            var LoremasterOverlord = CreateReplaceOverlordSpellbook("LoremasterOverlord", 3, bp => {
                bp.SetDescription(StaticReferences.Strings.ReplaceSpellbookDescription.Loremaster);
                bp.Groups = new FeatureGroup[] { FeatureGroup.MythicAdditionalProgressions };
            });
            var HellknightSignifierOverlord = CreateReplaceOverlordSpellbook("HellknightSignifierOverlord", 3, bp => {
                bp.SetDescription(StaticReferences.Strings.ReplaceSpellbookDescription.HellknightSignifier);
                bp.Groups = new FeatureGroup[] { FeatureGroup.HellknightSigniferSpellbook };
            });
            var ArcaneTricksterOverlord = CreateReplaceOverlordSpellbook("ArcaneTricksterOverlord", 2, bp => {
                bp.SetDescription(StaticReferences.Strings.ReplaceSpellbookDescription.ArcaneTrickster);
                bp.Groups = new FeatureGroup[] { FeatureGroup.ArcaneTricksterSpellbook };
            });
            var MysticTheurgeArcaneOverlord = CreateReplaceOverlordSpellbook("MysticTheurgeArcaneOverlord", 2, bp => {
                bp.SetDescription(StaticReferences.Strings.ReplaceSpellbookDescription.MysticTheurgeArcane);
                bp.Groups = new FeatureGroup[] { FeatureGroup.MysticTheurgeArcaneSpellbook };
            });
            var MysticTheurgeDivineOverlord = CreateReplaceOverlordSpellbook("MysticTheurgeDivineOverlord", 2, bp => {
                bp.SetDescription(StaticReferences.Strings.ReplaceSpellbookDescription.MysticTheurgeDivine);
                bp.Groups = new FeatureGroup[] { FeatureGroup.MysticTheurgeDivineSpellbook };
            });
            var DragonDiscipleOverlord = CreateReplaceOverlordSpellbook("DragonDiscipleOverlord", 2, bp => {
                bp.SetDescription(StaticReferences.Strings.ReplaceSpellbookDescription.DragonDisciple);
                bp.Groups = new FeatureGroup[] { FeatureGroup.DragonDiscipleSpellbook };
            });
            var EldritchKnightOverlord = CreateReplaceOverlordSpellbook("EldritchKnightOverlord", 2, bp => {
                bp.SetDescription(StaticReferences.Strings.ReplaceSpellbookDescription.EldritchKnight);
                bp.Groups = new FeatureGroup[] { FeatureGroup.EldritchKnightSpellbook };
            });
            var WinterWitchOverlord = CreateReplaceOverlordSpellbook("WinterWitchOverlord", 2, bp => {
                bp.SetDescription(StaticReferences.Strings.ReplaceSpellbookDescription.WinterWitch);
                bp.Groups = new FeatureGroup[0];
            });


            FeatTools.Selections.LoremasterSpellbookSelection.AddToSelection(LoremasterOverlord);
            FeatTools.Selections.HellknightSigniferSpellbook.AddToSelection(HellknightSignifierOverlord);
            FeatTools.Selections.ArcaneTricksterSpellbookSelection.AddToSelection(ArcaneTricksterOverlord);
            FeatTools.Selections.MysticTheurgeArcaneSpellbookSelection.AddToSelection(MysticTheurgeArcaneOverlord);
            FeatTools.Selections.MysticTheurgeDivineSpellbookSelection.AddToSelection(MysticTheurgeDivineOverlord);
            FeatTools.Selections.DragonDiscipleSpellbookSelection.AddToSelection(DragonDiscipleOverlord);
            FeatTools.Selections.EldritchKnightSpellbookSelection.AddToSelection(EldritchKnightOverlord);
            FeatTools.Selections.WinterWitchSpellbookSelection.AddToSelection(WinterWitchOverlord);
        }

        public static BlueprintFeatureReplaceSpellbook CreateReplaceIsekaiSpellbook(string name, int level, Action<BlueprintFeatureReplaceSpellbook> init = null) {
            var result = Helpers.CreateBlueprint<BlueprintFeatureReplaceSpellbook>(IsekaiContext, name, bp => {
                bp.SetName(IsekaiContext, "Isekai Protagonist");
                bp.HideInUI = true;
                bp.HideNotAvailibleInUI = true;
                bp.HideInCharacterSheetAndLevelUp = false;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.m_Spellbook = IsekaiProtagonistSpellbook.GetReference();
                bp.AddComponent<PrerequisiteClassSpellLevel>(c => {
                    c.Group = Prerequisite.GroupType.All;
                    c.m_CharacterClass = IsekaiProtagonistClass.GetReference();
                    c.RequiredSpellLevel = level;
                });
                bp.AddComponent<PrerequisiteNoArchetype>(c => {
                    c.Group = Prerequisite.GroupType.All;
                    c.m_CharacterClass = IsekaiProtagonistClass.GetReference();
                    c.m_Archetype = Archetypes.MastermindArchetype.GetReference();
                });
                bp.AddComponent<PrerequisiteNoArchetype>(c => {
                    c.Group = Prerequisite.GroupType.All;
                    c.m_CharacterClass = IsekaiProtagonistClass.GetReference();
                    c.m_Archetype = Archetypes.OverlordArchetype.GetReference();
                });
            });
            init?.Invoke(result);
            return result;
        }
        public static BlueprintFeatureReplaceSpellbook CreateReplaceMastermindSpellbook(string name, int level, Action<BlueprintFeatureReplaceSpellbook> init = null) {
            var result = Helpers.CreateBlueprint<BlueprintFeatureReplaceSpellbook>(IsekaiContext, name, bp => {
                bp.SetName(IsekaiContext, "Mastermind");
                bp.HideInUI = true;
                bp.HideNotAvailibleInUI = true;
                bp.HideInCharacterSheetAndLevelUp = false;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.m_Spellbook = MastermindSpellbook.GetReference();
                bp.AddComponent<PrerequisiteClassSpellLevel>(c => {
                    c.Group = Prerequisite.GroupType.All;
                    c.m_CharacterClass = IsekaiProtagonistClass.GetReference();
                    c.RequiredSpellLevel = level;
                });
                bp.AddComponent<PrerequisiteArchetypeLevel>(c => {
                    c.Group = Prerequisite.GroupType.All;
                    c.m_CharacterClass = IsekaiProtagonistClass.GetReference();
                    c.m_Archetype = Archetypes.MastermindArchetype.GetReference();
                    c.Level = 1;
                });
                bp.AddComponent<PrerequisiteNoArchetype>(c => {
                    c.Group = Prerequisite.GroupType.All;
                    c.m_CharacterClass = IsekaiProtagonistClass.GetReference();
                    c.m_Archetype = Archetypes.OverlordArchetype.GetReference();
                });
            });
            init?.Invoke(result);
            return result;
        }
        public static BlueprintFeatureReplaceSpellbook CreateReplaceOverlordSpellbook(string name, int level, Action<BlueprintFeatureReplaceSpellbook> init = null) {
            var result = Helpers.CreateBlueprint<BlueprintFeatureReplaceSpellbook>(IsekaiContext, name, bp => {
                bp.SetName(IsekaiContext, "Overlord");
                bp.HideInUI = true;
                bp.HideNotAvailibleInUI = true;
                bp.HideInCharacterSheetAndLevelUp = false;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.m_Spellbook = MastermindSpellbook.GetReference();
                bp.AddComponent<PrerequisiteClassSpellLevel>(c => {
                    c.Group = Prerequisite.GroupType.All;
                    c.m_CharacterClass = IsekaiProtagonistClass.GetReference();
                    c.RequiredSpellLevel = level;
                });
                bp.AddComponent<PrerequisiteArchetypeLevel>(c => {
                    c.Group = Prerequisite.GroupType.All;
                    c.m_CharacterClass = IsekaiProtagonistClass.GetReference();
                    c.m_Archetype = Archetypes.OverlordArchetype.GetReference();
                    c.Level = 1;
                });
                bp.AddComponent<PrerequisiteNoArchetype>(c => {
                    c.Group = Prerequisite.GroupType.All;
                    c.m_CharacterClass = IsekaiProtagonistClass.GetReference();
                    c.m_Archetype = Archetypes.MastermindArchetype.GetReference();
                });
            });
            init?.Invoke(result);
            return result;
        }
    }
}