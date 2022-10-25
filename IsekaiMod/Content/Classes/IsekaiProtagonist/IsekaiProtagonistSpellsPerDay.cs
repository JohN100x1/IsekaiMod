using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes.Spells;

namespace IsekaiMod.Content.Classes.IsekaiProtagonist
{
    class IsekaiProtagonistSpellsPerDay
    {
        public static void Add()
        {
            var IsekaiProtagonistSpellsPerDay = Helpers.CreateBlueprint<BlueprintSpellsTable>("IsekaiProtagonistSpellsPerDay", bp => {
                bp.Levels = new SpellsLevelEntry[29] {
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
                    new SpellsLevelEntry() { Count = new int[] { 0, 30, 30, 24, 24, 24, 24, 24, 24, 20 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 30, 30, 24, 24, 24, 24, 24, 24, 20 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 30, 30, 24, 24, 24, 24, 24, 24, 20 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 30, 30, 24, 24, 24, 24, 24, 24, 20 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 30, 30, 24, 24, 24, 24, 24, 24, 20 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 30, 30, 24, 24, 24, 24, 24, 24, 20 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 30, 30, 24, 24, 24, 24, 24, 24, 20 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 30, 30, 24, 24, 24, 24, 24, 24, 20 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, 30, 30, 24, 24, 24, 24, 24, 24, 20, 2 } }
                };
            });
        }
    }
}
