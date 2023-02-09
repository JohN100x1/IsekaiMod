using Kingmaker.Blueprints.Classes.Spells;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Classes.IsekaiProtagonist {

    internal class IsekaiProtagonistSpellsKnown {

        public static void Add() {
            var IsekaiProtagonistSpellsKnown = Helpers.CreateBlueprint<BlueprintSpellsTable>(IsekaiContext, "IsekaiProtagonistSpellsKnown", bp => {
                bp.Levels = new SpellsLevelEntry[21] {
                    new SpellsLevelEntry() { Count = new int[] { } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 6 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 12 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 18, 6 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 24, 12 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 24, 18, 6 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 30, 24, 6 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 30, 24, 12, 6 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 30, 30, 18, 6 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 30, 30, 18, 12, 6 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 30, 30, 24, 18, 6 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 30, 30, 24, 18, 12, 6 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 30, 30, 24, 24, 18, 6 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 30, 30, 24, 24, 18, 12, 6 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 30, 30, 24, 24, 24, 18, 6 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 30, 30, 24, 24, 24, 18, 12, 6 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 30, 30, 24, 24, 24, 24, 18, 6 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 30, 30, 24, 24, 24, 24, 18, 12, 6 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 30, 30, 24, 24, 24, 24, 24, 18, 6 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 30, 30, 24, 24, 24, 24, 24, 24, 12 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 30, 30, 24, 24, 24, 24, 24, 24, 20 } }
                };
            });
        }
    }
}