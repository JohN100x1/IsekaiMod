using HarmonyLib;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.Root;
using Kingmaker.DialogSystem;
using Kingmaker.DialogSystem.Blueprints;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Localization;
using Kingmaker.ResourceLinks;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.Alignments;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using System;
using System.Collections.Generic;
using System.IO;
using TabletopTweaks.Core.ModLogic;
using TabletopTweaks.Core.Utilities;
using UnityEngine;
using static IsekaiMod.Main;

namespace IsekaiMod.Utilities {

    //Classname is a partial lie, some are just not handled well *coughs*
    internal class ThingsNotHandledByTTTCore {
        public static void RegisterClass(BlueprintCharacterClass classToRegister) {
            var existingClasses = ClassTools.Classes.AllClasses;
            if (ContainsClass(existingClasses, classToRegister)) {
                IsekaiContext.Logger.LogWarning("class already registered= " + classToRegister.name + " gui id=" + classToRegister.AssetGuid.m_Guid.ToString("N"));
                return;
            }
            BlueprintRoot.Instance.Progression.m_CharacterClasses = ClassTools.ClassReferences.AllClasses.AddToArray(classToRegister.ToReference<BlueprintCharacterClassReference>());
        }

        public static void RegisterSpell(BlueprintSpellList list, BlueprintAbility spell, int level) {
            // Core method check if spell already exists uses a simple contains check that fails if multiple instances of the spell were created (for example if it exists in multiple spellbooks)
            // the Core method does a few other nice things though, like correctly adding the spell to specialist lists so should be called after ones own security check
            if (ListContainsSpell(list, spell)) {
                //Comment back in if you are trying to fix bugs in the spelllist but otherwise this just blows up the log for no good purpose
                //IsekaiContext.Logger.LogWarning("spell already registered= " + spell.name + " gui id=" + spell.AssetGuid.m_Guid.ToString("N"));
                return;
            }
            spell.AddToSpellList(list, level);
        }

        public static void RegisterForPrestigeSpellbook(BlueprintFeatureSelectMythicSpellbook mythicSpellbook, BlueprintSpellbook spellBook) {
            if (ContainsSpellbook(mythicSpellbook.AllowedSpellbooks, spellBook)) {
                IsekaiContext.Logger.LogWarning("spellbook already registered= " + spellBook.name + " gui id=" + spellBook.AssetGuid.m_Guid.ToString("N") + " for mythic= " + mythicSpellbook.Name);
                return;
            }
            mythicSpellbook.m_AllowedSpellbooks = mythicSpellbook.m_AllowedSpellbooks.AddToArray(spellBook.ToReference<BlueprintSpellbookReference>());
        }

        public static BlueprintAnswer CreateAnswer(string name, Action<BlueprintAnswer> init = null) {
            var result = Helpers.CreateBlueprint<BlueprintAnswer>(IsekaiContext, name, bp => {
                bp.NextCue = new CueSelection() {
                    Cues = new List<BlueprintCueBaseReference>(),
                    Strategy = Strategy.First
                };
                bp.ShowOnce = false;
                bp.ShowOnceCurrentDialog = false;
                bp.ShowCheck = new ShowCheck() { Type = StatType.Unknown, DC = 0 };
                bp.Experience = DialogExperience.NoExperience;
                bp.DebugMode = false;
                bp.CharacterSelection = new CharacterSelection() { SelectionType = CharacterSelection.Type.Clear, ComparisonStats = new StatType[0] };
                bp.ShowConditions = ActionFlow.EmptyCondition();
                bp.SelectConditions = ActionFlow.EmptyCondition();
                bp.RequireValidCue = false;
                bp.AddToHistory = true;
                bp.OnSelect = ActionFlow.DoNothing();
                bp.FakeChecks = new CheckData[0];
                bp.AlignmentShift = new AlignmentShift() { Direction = AlignmentShiftDirection.TrueNeutral, Value = 0, Description = new LocalizedString() };
            });
            init?.Invoke(result);
            return result;
        }

        public static BlueprintBuff CreateBuff(string name, Action<BlueprintBuff> init = null) {
            var result = Helpers.CreateBlueprint<BlueprintBuff>(IsekaiContext, name, bp => {
                bp.FxOnStart = new PrefabLink();
                bp.FxOnRemove = new PrefabLink();
            });
            init?.Invoke(result);
            return result;
        }

        public static BlueprintActivatableAbility CreateActivatableAbility(string name, Action<BlueprintActivatableAbility> init = null) {
            var result = Helpers.CreateBlueprint<BlueprintActivatableAbility>(IsekaiContext, name, bp => {
                bp.IsOnByDefault = true;
                bp.DeactivateImmediately = true;
                bp.ActivationType = AbilityActivationType.Immediately;
            });
            init?.Invoke(result);
            return result;
        }

        private static bool ListContainsSpell(BlueprintSpellList list, BlueprintAbility spell) {
            foreach (var level in list.SpellsByLevel) {
                foreach (var comparespell in level.Spells) {
                    if (spell.AssetGuid.m_Guid.ToString("N").Equals(comparespell.AssetGuid.m_Guid.ToString("N"))) {
                        return true;
                    }
                }
            }
            return false;
        }

        private static bool ContainsClass(BlueprintCharacterClass[] array, BlueprintCharacterClass classToCheck) {
            foreach (var arrayClass in array) {
                if (arrayClass.AssetGuid.m_Guid.ToString("N").Equals(classToCheck.AssetGuid.m_Guid.ToString("N"))) { return true; }
            }
            return false;
        }

        private static bool ContainsSpellbook(BlueprintSpellbookReference[] array, BlueprintSpellbook classToCheck) {
            foreach (var arrayClass in array) {
                if (arrayClass != null && arrayClass.Guid != null) {
                    if (arrayClass.Guid.Equals(classToCheck.AssetGuid.m_Guid.ToString("N"))) { return true; }
                } else {
                    IsekaiContext.Logger.LogWarning("prestige class spellbook array contained null value");
                }
            }
            return false;
        }
    }

    internal class AssetLoaderExtension : AssetLoader {

        public static Sprite LoadInternal(ModContextBase modContext, string folder, string file, Vector2Int size) {
            return Image2SpriteExtension.Create($"{modContext.ModEntry.Path}Assets{Path.DirectorySeparatorChar}{folder}{Path.DirectorySeparatorChar}{file}", size);
        }

        public static class Image2SpriteExtension {
            public static string icons_folder = "";

            public static Sprite Create(string filePath, Vector2Int size) {
                var bytes = File.ReadAllBytes(icons_folder + filePath);
                var texture = new Texture2D(size.x, size.y, TextureFormat.RGBA32, false) { mipMapBias = 15.0f };
                _ = texture.LoadImage(bytes);
                return Sprite.Create(texture, new Rect(0, 0, size.x, size.y), new Vector2(0, 0));
            }
        }
    }
}