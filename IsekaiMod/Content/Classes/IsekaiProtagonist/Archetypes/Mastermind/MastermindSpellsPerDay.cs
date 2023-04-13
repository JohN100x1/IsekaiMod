using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Spells;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Classes.IsekaiProtagonist {

    internal class MastermindSpellsPerDay {

        public static void Add() {
            var MastermindSpellsPerDay = Helpers.CreateBlueprint<BlueprintSpellsTable>(IsekaiContext, "MastermindSpellsPerDay", bp => {
                bp.Levels = new SpellsLevelEntry[29] {
                    new SpellsLevelEntry() { Count = new int[] { } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 3 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 6  } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 9 , 3 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 12, 6  } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 12, 9 , 3 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 12, 12, 6 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 12, 12, 9 , 3 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 12, 12, 12, 6 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 12, 12, 12, 9 , 3 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 12, 12, 12, 12, 6 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 12, 12, 12, 12, 9 , 3 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 12, 12, 12, 12, 12, 6 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 12, 12, 12, 12, 12, 9 , 3 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 12, 12, 12, 12, 12, 12, 6 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 12, 12, 12, 12, 12, 12, 9 , 3 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 12, 12, 12, 12, 12, 12, 12, 6 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 12, 12, 12, 12, 12, 12, 12, 9 , 3 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 12, 12, 12, 12, 12, 12, 12, 12, 6 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 12, 12, 12, 12, 12, 12, 12, 12, 9, 3  } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 12, 12, 12, 12, 12, 12, 12, 12, 12, 7 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 12, 12, 12, 12, 12, 12, 12, 12, 12, 7 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 12, 12, 12, 12, 12, 12, 12, 12, 12, 7 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 12, 12, 12, 12, 12, 12, 12, 12, 12, 7 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 12, 12, 12, 12, 12, 12, 12, 12, 12, 7 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 12, 12, 12, 12, 12, 12, 12, 12, 12, 7 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 12, 12, 12, 12, 12, 12, 12, 12, 12, 7 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 12, 12, 12, 12, 12, 12, 12, 12, 12, 7 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 12, 12, 12, 12, 12, 12, 12, 12, 12, 7 } }
                };
            });
        }

        public static BlueprintSpellsTable Get() {
            return BlueprintTools.GetModBlueprint<BlueprintSpellsTable>(IsekaiContext, "MastermindSpellsPerDay");
        }

        public static BlueprintSpellsTableReference GetReference() {
            return BlueprintTools.GetModBlueprintReference<BlueprintSpellsTableReference>(IsekaiContext, "MastermindSpellsPerDay");
        }
    }
}