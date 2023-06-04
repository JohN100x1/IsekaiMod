using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Spells;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Classes.IsekaiProtagonist {

    internal class IsekaiProtagonistSpellsKnown {

        public static void Add() {
            var x = IsekaiContext.AddedContent.IsekaiSpellsKnownIncrement;
            var x2 = 2*x;
            var x3 = 3*x;
            var x34 = (int)3.4 * x;
            var x4 = 4*x;
            var x5 = 5*x;
            var IsekaiProtagonistSpellsKnown = Helpers.CreateBlueprint<BlueprintSpellsTable>(IsekaiContext, "IsekaiProtagonistSpellsKnown", bp => {
                bp.Levels = new SpellsLevelEntry[21] {
                    new SpellsLevelEntry() { Count = new int[] { } },
                    new SpellsLevelEntry() { Count = new int[] { 0, x } },
                    new SpellsLevelEntry() { Count = new int[] { 0, x2 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, x3, x } },
                    new SpellsLevelEntry() { Count = new int[] { 0, x4, x2 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, x4, x3, x } },
                    new SpellsLevelEntry() { Count = new int[] { 0, x5, x4, x } },
                    new SpellsLevelEntry() { Count = new int[] { 0, x5, x4, x2, x } },
                    new SpellsLevelEntry() { Count = new int[] { 0, x5, x5, x3, x } },
                    new SpellsLevelEntry() { Count = new int[] { 0, x5, x5, x3, x2, x } },
                    new SpellsLevelEntry() { Count = new int[] { 0, x5, x5, x4, x3, x } },
                    new SpellsLevelEntry() { Count = new int[] { 0, x5, x5, x4, x3, x2, x } },
                    new SpellsLevelEntry() { Count = new int[] { 0, x5, x5, x4, x4, x3, x } },
                    new SpellsLevelEntry() { Count = new int[] { 0, x5, x5, x4, x4, x3, x2, x } },
                    new SpellsLevelEntry() { Count = new int[] { 0, x5, x5, x4, x4, x4, x3, x } },
                    new SpellsLevelEntry() { Count = new int[] { 0, x5, x5, x4, x4, x4, x3, x2, x } },
                    new SpellsLevelEntry() { Count = new int[] { 0, x5, x5, x4, x4, x4, x4, x3, x } },
                    new SpellsLevelEntry() { Count = new int[] { 0, x5, x5, x4, x4, x4, x4, x3, x2, x } },
                    new SpellsLevelEntry() { Count = new int[] { 0, x5, x5, x4, x4, x4, x4, x4, x3, x } },
                    new SpellsLevelEntry() { Count = new int[] { 0, x5, x5, x4, x4, x4, x4, x4, x4, x2 } },
                    new SpellsLevelEntry() { Count = new int[] { 0, x5, x5, x4, x4, x4, x4, x4, x4, x34 } }
                };
            });
        }

        public static BlueprintSpellsTable Get() {
            return BlueprintTools.GetModBlueprint<BlueprintSpellsTable>(IsekaiContext, "IsekaiProtagonistSpellsKnown");
        }

        public static BlueprintSpellsTableReference GetReference() {
            return BlueprintTools.GetModBlueprintReference<BlueprintSpellsTableReference>(IsekaiContext, "IsekaiProtagonistSpellsKnown");
        }
    }
}