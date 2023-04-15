using HarmonyLib;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.Root;
using Kingmaker.DialogSystem;
using Kingmaker.DialogSystem.Blueprints;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.Localization;
using Kingmaker.ResourceLinks;
using Kingmaker.ResourceManagement;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.Alignments;
using Kingmaker.UnitLogic.Buffs;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Buffs.Components;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TabletopTweaks.Core.Utilities;
using UnityEngine;
using static IsekaiMod.Main;

namespace IsekaiMod.Utilities {

    internal class TTCoreExtensions {
        public static void RegisterClass(BlueprintCharacterClass classToRegister) {
            if (ContainsClass(ClassTools.Classes.AllClasses, classToRegister)) {
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

        public static void RegisterForMythicSpellbook(BlueprintFeatureSelectMythicSpellbook mythicSpellbook, BlueprintSpellbook spellBook) {
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

        public static BlueprintCue CreateCue(string name, Action<BlueprintCue> init = null) {
            var result = Helpers.CreateBlueprint<BlueprintCue>(IsekaiContext, name, bp => {
                bp.ShowOnce = false;
                bp.ShowOnceCurrentDialog = false;
                bp.Conditions = ActionFlow.EmptyCondition();
                bp.Experience = DialogExperience.NoExperience;
                bp.TurnSpeaker = true;
                bp.Animation = DialogAnimation.None;
                bp.OnShow = ActionFlow.DoNothing();
                bp.OnStop = ActionFlow.DoNothing();
                bp.AlignmentShift = new AlignmentShift() { Direction = AlignmentShiftDirection.TrueNeutral, Value = 0, Description = new LocalizedString() };
                bp.Answers = new List<BlueprintAnswerBaseReference>();
                bp.Continue = new CueSelection() {
                    Cues = new List<BlueprintCueBaseReference>(),
                    Strategy = Strategy.First
                };
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

        public static BlueprintFeature CreateToggleBuffFeature(string name, string description, Sprite icon, Action<BlueprintBuff> buffEffect = null) {
            string displayName = string.Concat(name.Select(x => char.IsUpper(x) ? " " + x : x.ToString())).TrimStart(' ');
            return CreateToggleBuffFeature(name, displayName, description, displayName, description, icon, buffEffect);
        }
        
        public static BlueprintFeature CreateToggleBuffFeature(string name, string displayName, string description, Sprite icon, Action<BlueprintBuff> buffEffect = null) {
            return CreateToggleBuffFeature(name, displayName, description, displayName, description, icon, buffEffect);
        }

        public static BlueprintFeature CreateToggleBuffFeature(string name, string displayName, string description, string displayNameBuff, string descriptionBuff, Sprite icon, Action<BlueprintBuff> buffEffect = null) {
            LocalizedString displayDesc = Helpers.CreateString(IsekaiContext, $"{name}.Description", description);
            LocalizedString buffDesc = Helpers.CreateString(IsekaiContext, $"{name}Buff.Description", descriptionBuff);

            var buff = CreateBuff($"{name}Buff", bp => {
                bp.SetName(IsekaiContext, displayNameBuff);
                bp.SetDescription(buffDesc);
                bp.m_Icon = icon;
                bp.IsClassFeature = true;
            });
            buffEffect?.Invoke(buff);
            var ability = CreateActivatableAbility($"{name}Ability", bp => {
                bp.SetName(IsekaiContext, displayName);
                bp.SetDescription(displayDesc);
                bp.m_Icon = icon;
                bp.m_Buff = buff.ToReference<BlueprintBuffReference>();
            });
            var feature = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, $"{name}Feature", bp => {
                bp.SetName(IsekaiContext, displayName);
                bp.SetDescription(displayDesc);
                bp.m_Icon = icon;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] {
                        ability.ToReference<BlueprintUnitFactReference>()
                    };
                });
            });
            return feature;
        }

        public static BlueprintFeature CreateToggleAuraFeature(string name, string description, string descriptionBuff, Sprite icon, BlueprintAbilityAreaEffect.TargetType targetType, Feet auraSize, bool affectEnemies = false, Action<BlueprintBuff> buffEffect = null) {
            LocalizedString displayDescBuff = Helpers.CreateString(IsekaiContext, $"{name}Buff.Description", descriptionBuff);
            return CreateToggleAuraFeature(name, description, displayDescBuff, icon, targetType, auraSize, affectEnemies, buffEffect);
        }

        public static BlueprintFeature CreateToggleAuraFeature(string name, string description, LocalizedString displayDescBuff, Sprite icon, BlueprintAbilityAreaEffect.TargetType targetType, Feet auraSize, bool affectEnemies = false, Action<BlueprintBuff> buffEffect = null) {
            string displayName = string.Concat(name.Select(x => char.IsUpper(x) ? " " + x : x.ToString())).TrimStart(' ');
            return CreateToggleAuraFeature(name, displayName, description, displayDescBuff, icon, targetType, auraSize, affectEnemies, buffEffect);
        }

        public static BlueprintFeature CreateToggleAuraFeature(string name, string displayName, string description, LocalizedString displayDescBuff, Sprite icon, BlueprintAbilityAreaEffect.TargetType targetType, Feet auraSize, bool affectEnemies = false, Action<BlueprintBuff> buffEffect = null) {
            BlueprintBuff buff = CreateBuff($"{name}Buff", bp => {
                bp.SetName(IsekaiContext, displayName);
                bp.SetDescription(displayDescBuff);
                bp.IsClassFeature = true;
                bp.m_Icon = icon;
            });
            buffEffect?.Invoke(buff);
            return CreateToggleAuraFeature(
                name: name,
                displayName: displayName,
                description: description,
                icon: icon,
                areaEffect: bp => {
                    bp.m_TargetType = targetType;
                    bp.Size = auraSize;
                    bp.AffectEnemies = affectEnemies;
                    bp.AddUnconditionalAuraEffect(buff.ToReference<BlueprintBuffReference>());
                });
        }

        public static BlueprintFeature CreateToggleAuraFeature(string name, string displayName, string description, Sprite icon, Action<BlueprintAbilityAreaEffect> areaEffect = null) {
            LocalizedString displayDesc = Helpers.CreateString(IsekaiContext, $"{name}.Description", description);

            BlueprintAbilityAreaEffect area = Helpers.CreateBlueprint<BlueprintAbilityAreaEffect>(IsekaiContext, $"{name}Area", bp => {
                bp.Shape = AreaEffectShape.Cylinder;
                bp.Fx = new PrefabLink();
            });
            areaEffect?.Invoke(area);
            BlueprintBuff areaBuff = CreateBuff($"{name}AreaBuff", bp => {
                bp.SetName(IsekaiContext, displayName);
                bp.SetDescription(displayDesc);
                bp.m_Icon = icon;
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.HiddenInUi;
                bp.AddComponent<AddAreaEffect>(c => {
                    c.m_AreaEffect = area.ToReference<BlueprintAbilityAreaEffectReference>();
                });
            });
            BlueprintActivatableAbility ability = CreateActivatableAbility($"{name}Ability", bp => {
                bp.SetName(IsekaiContext, displayName);
                bp.SetDescription(displayDesc);
                bp.m_Icon = icon;
                bp.m_Buff = areaBuff.ToReference<BlueprintBuffReference>();
                bp.DoNotTurnOffOnRest = true;
            });
            BlueprintFeature feature = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, $"{name}Feature", bp => {
                bp.SetName(IsekaiContext, displayName);
                bp.SetDescription(displayDesc);
                bp.m_Icon = icon;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { ability.ToReference<BlueprintUnitFactReference>() };
                });
            });

            return feature;
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
        public static Sprite LoadPortrait(string imagePath, Vector2Int size) {
            var bytes = File.ReadAllBytes(imagePath);
            var texture = new Texture2D(size.x, size.y, TextureFormat.RGBA32, false) { mipMapBias = 15.0f };
            _ = texture.LoadImage(bytes);
            return Sprite.Create(texture, new Rect(0, 0, size.x, size.y), new Vector2(0, 0));
        }

        public static PortraitData LoadPortraitData(string folder) {
            var imageFolderPath = Path.Combine(IsekaiContext.ModEntry.Path, "Assets", "Portraits", folder);
            var smallImagePath = Path.Combine(imageFolderPath, "Small.png");
            var mediumImagePath = Path.Combine(imageFolderPath, "Medium.png");
            var fullImagePath = Path.Combine(imageFolderPath, "FullLength.png");

            var smallPortraitHandle = CreateCustomPortraitHandle(smallImagePath, PortraitType.SmallPortrait, new Vector2Int(185, 242));
            var mediumPortraitHandle = CreateCustomPortraitHandle(mediumImagePath, PortraitType.HalfLengthPortrait, new Vector2Int(330, 432));
            var fullPortraitHandle = CreateCustomPortraitHandle(fullImagePath, PortraitType.FullLengthPortrait, new Vector2Int(692, 1024));

            return new PortraitData(folder) {
                SmallPortraitHandle = smallPortraitHandle,
                HalfPortraitHandle = mediumPortraitHandle,
                FullPortraitHandle = fullPortraitHandle
            };
        }

        private static CustomPortraitHandle CreateCustomPortraitHandle(string path, PortraitType type, Vector2Int size) {
            return new CustomPortraitHandle(path, type, CustomPortraitsManager.Instance.Storage) {
                Request = new SpriteLoadingRequest(path) {
                    Resource = LoadPortrait(path, size)
                }
            };
        }
    }
}