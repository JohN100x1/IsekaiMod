using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Spells;
using System.Collections.Generic;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Classes.IsekaiProtagonist {

    internal class MastermindSpellList {

        public static void Add() {
            // Create SpellList here and patch in the spells by level from IsekaiProtagonistSpellList after its merge
            Helpers.CreateBlueprint<BlueprintSpellList>(IsekaiContext, "MastermindSpellList");
        }

        public static BlueprintSpellList Get() {
            return BlueprintTools.GetModBlueprint<BlueprintSpellList>(IsekaiContext, "MastermindSpellList");
        }
        public static BlueprintSpellListReference GetReference() {
            return BlueprintTools.GetModBlueprintReference<BlueprintSpellListReference>(IsekaiContext, "MastermindSpellList");
        }
        public static void PatchMastermindSpellList() {
            var MastermindSpellList = Get();
            MastermindSpellList.SpellsByLevel = IsekaiProtagonistSpellList.Get().SpellsByLevel;
            MastermindSpellList.SpellsByLevel[10] = new SpellLevelList(10) {
                m_Spells = new List<BlueprintAbilityReference> {
                    BlueprintTools.GetBlueprintReference<BlueprintAbilityReference>("483157d358afd1a498c2a4762f4057ba"), // AngelArmyOfHeaven
                    BlueprintTools.GetBlueprintReference<BlueprintAbilityReference>("a948e10ecf1fa674dbae5eaae7f25a7f"), // AngelEyeOfTheSun
                    BlueprintTools.GetBlueprintReference<BlueprintAbilityReference>("af92783492851f445abb2c01d346c376"), // AngelPheonixGift
                    BlueprintTools.GetBlueprintReference<BlueprintAbilityReference>("1b76573f991543145897702b7edc4d7a"), // AngelRekindle
                    BlueprintTools.GetBlueprintReference<BlueprintAbilityReference>("7d721be6d74f07f4d952ee8d6f8f44a0"), // AbsoluteDeath
                    BlueprintTools.GetBlueprintReference<BlueprintAbilityReference>("24067ba8e0e69a14e83ff397826f6c6d"), // DoomOfServitude
                    BlueprintTools.GetBlueprintReference<BlueprintAbilityReference>("cc74245ba989480488925214dd925100")  // PitOfDespair
                }
            };
        }
    }
}