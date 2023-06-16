using HarmonyLib;
using IsekaiMod.Components;
using IsekaiMod.Content.Classes.IsekaiProtagonist;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Designers.Mechanics.Buffs;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.UnitLogic.Parts;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Utilities {
    internal static class PatchTools {
        // Spellbooks to patch
        private static BlueprintSpellbookReference[] patchableSpellBooks = new BlueprintSpellbookReference[0];

        // Features to ignore during patching
        public static readonly BlueprintFeatureBase[] FeaturesIgnoredWhenPatching = new BlueprintFeatureBase[] {
            FeatTools.Selections.BasicFeatSelection,
            FeatTools.Selections.FighterFeatSelection,
            FeatTools.Selections.CombatTrick,
            FeatTools.Selections.SkaldFeatSelection,
            FeatTools.Selections.AnimalCompanionSelectionDomain,
            FeatTools.Selections.WarDomainGreaterFeatSelection,
            FeatTools.Selections.MagusFeatSelection,
            FeatTools.Selections.CavalierBonusFeatSelection,
            BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("f1add10c87fa4563ad5f71779eecde19") // GriffonheartShifterFeatSelection
        };

        public static void RegisterSpellbook(BlueprintSpellbook spellbook) {
            if (spellbook == null) return;
            BlueprintSpellbookReference spellbookRef = spellbook.ToReference<BlueprintSpellbookReference>();
            if (patchableSpellBooks.Contains(spellbookRef)) return;
            patchableSpellBooks = patchableSpellBooks.AddToArray(spellbookRef);

            // Allow Spellbook to be merged with angel and lich
            var AngelIncorporateSpellBook = BlueprintTools.GetBlueprint<BlueprintFeatureSelectMythicSpellbook>("e1fbb0e0e610a3a4d91e5e5284587939");
            var LichIncorporateSpellBook = BlueprintTools.GetBlueprint<BlueprintFeatureSelectMythicSpellbook>("3f16e9caf7c683c40884c7c455ed26af");
            TTCoreExtensions.RegisterForMythicSpellbook(AngelIncorporateSpellBook, spellbook);
            TTCoreExtensions.RegisterForMythicSpellbook(LichIncorporateSpellBook, spellbook);
        }

        private static BlueprintProgression PatchPatchClassProgressionBasedOnRefClassStep1(BlueprintProgression prog, BlueprintCharacterClass refClass) {
            prog.IsClassFeature = true;
            prog.m_Classes = new BlueprintProgression.ClassWithLevel[] {
                new BlueprintProgression.ClassWithLevel {
                    m_Class = IsekaiProtagonistClass.GetReference(),
                    AdditionalLevel = 0
                }
            };
            prog.AddComponent<ClassLevelsForPrerequisites>(c => {
                c.m_FakeClass = refClass.ToReference<BlueprintCharacterClassReference>();
                c.m_ActualClass = IsekaiProtagonistClass.GetReference();
                c.Modifier = 1.0;
            });
            prog.LevelEntries = new LevelEntry[0];
            var referenceUIGroups = refClass.Progression.UIGroups;
            prog.UIGroups = new UIGroup[0];
            foreach (var referenceUIGroup in referenceUIGroups) {
                prog.UIGroups = prog.UIGroups.AddToArray(referenceUIGroup);
            }
            prog.m_UIDeterminatorsGroup = new BlueprintFeatureBaseReference[0];
            var referenceUIDeterminators = refClass.Progression.UIDeterminatorsGroup;
            foreach (var UIDetermin in referenceUIDeterminators) {
                prog.m_UIDeterminatorsGroup = prog.m_UIDeterminatorsGroup.AddToArray(UIDetermin.ToReference<BlueprintFeatureBaseReference>());
            }
            return prog;
        }

        public static BlueprintProgression PatchClassProgressionBasedOnRefClass(BlueprintProgression prog, BlueprintCharacterClass refClass) {
            prog = PatchPatchClassProgressionBasedOnRefClassStep1(prog, refClass);
            var referenceLevels = refClass.Progression.LevelEntries;
            foreach (var referenceLevel in referenceLevels) {
                BlueprintFeatureBaseReference[] features = referenceLevel.m_Features.ToArray();
                prog.LevelEntries = prog.LevelEntries.AddToArray(Helpers.CreateLevelEntry(referenceLevel.Level, features));
            };
            return prog;
        }

        public static BlueprintProgression PatchClassProgressionBasedOnSeparateLists(BlueprintProgression prog, BlueprintCharacterClass refClass, LevelEntry[] additionalReference, LevelEntry[] removedReference) {
            BlueprintArchetype archetype = new BlueprintArchetype {
                RemoveFeatures = removedReference,
                AddFeatures = additionalReference
            };
            return PatchClassProgressionBasedonRefArchetype(prog, refClass, archetype, null);
        }

        public static BlueprintProgression PatchClassProgressionBasedonRefArchetype(BlueprintProgression prog, BlueprintCharacterClass refClass, BlueprintArchetype refArchetype, LevelEntry[] additionalReference) {
            prog = PatchPatchClassProgressionBasedOnRefClassStep1(prog, refClass);
            LevelEntry[] referenceLevels = refClass.Progression.LevelEntries;
            BlueprintFeatureBase[] MissingUIGroup = new BlueprintFeatureBase[0];
            foreach (LevelEntry referenceLevel in referenceLevels) {
                BlueprintFeatureBaseReference[] features = new BlueprintFeatureBaseReference[0];
                BlueprintFeatureBaseReference[] addItems = referenceLevel.m_Features.ToArray();
                BlueprintFeatureBaseReference[] removed = new BlueprintFeatureBaseReference[0];
                foreach (LevelEntry candidate in refArchetype.RemoveFeatures) {
                    if (candidate.Level == referenceLevel.Level) {
                        removed = removed.AddRangeToArray(candidate.m_Features.ToArray());
                    }
                }
                foreach (BlueprintFeatureBaseReference feature in addItems) {
                    if (!removed.Contains(feature)) {
                        features = features.AddToArray(feature);
                    }
                }
                BlueprintFeatureBaseReference[] added = new BlueprintFeatureBaseReference[0];
                foreach (LevelEntry candidate in refArchetype.AddFeatures) {
                    if (candidate.Level == referenceLevel.Level) {
                        added = added.AddRangeToArray(candidate.m_Features.ToArray());
                    }
                }
                if (added != null && added.Length > 0) {
                    foreach (var feature in added) {
                        features = features.AddToArray(feature);
                        if (!MissingUIGroup.Contains(feature)) { MissingUIGroup = MissingUIGroup.AddToArray(feature); }
                    }
                }
                if (additionalReference != null) {
                    LevelEntry additionalFeatures = null;
                    foreach (LevelEntry candidate in additionalReference) {
                        if (candidate.Level == referenceLevel.Level) {
                            additionalFeatures = candidate;
                        }
                    }
                    if (additionalFeatures != null) {
                        foreach (BlueprintFeatureBaseReference feature in additionalFeatures.m_Features) {
                            features = features.AddToArray(feature);
                            if (!MissingUIGroup.Contains(feature)) { MissingUIGroup = MissingUIGroup.AddToArray(feature); }
                        }
                    }
                }
                prog.LevelEntries = prog.LevelEntries.AddToArray(Helpers.CreateLevelEntry(referenceLevel.Level, features));
            };
            //run through them again to get references to levels that had no features previously
            if (additionalReference != null) {
                foreach (LevelEntry level in additionalReference) {
                    bool found = false;
                    foreach (LevelEntry refLevel in prog.LevelEntries) {
                        if (refLevel.Level == level.Level) {
                            found = true;
                        }
                    }
                    if (!found) {
                        prog.LevelEntries = prog.LevelEntries.AddToArray(level);
                        foreach (BlueprintFeatureBaseReference feature in level.m_Features) {
                            if (!MissingUIGroup.Contains(feature)) {
                                MissingUIGroup = MissingUIGroup.AddToArray(feature);
                            }
                        }
                    }
                }
            }
            if (MissingUIGroup.Length > 0) {
                prog.UIGroups = prog.UIGroups.AddToArray(Helpers.CreateUIGroup(MissingUIGroup));
            }
            return prog;
        }

        public static void PatchProgressionFeaturesBasedOnReferenceArchetype(BlueprintCharacterClassReference myClass, BlueprintCharacterClassReference referenceClass, BlueprintArchetype refArchetype) {
            var features = new HashSet<BlueprintFeatureBase>();
            foreach (LevelEntry levelEntry in refArchetype.AddFeatures) {
                foreach (BlueprintFeatureBase levelitem in levelEntry.Features) {
                    if (!features.Contains(levelitem)) { features.Add(levelitem); }
                }
            }
            foreach (BlueprintFeatureBase levelitem in features) {
                if (levelitem is BlueprintProgression progression) {
                    PatchClassIntoFeatureOfReferenceClass(progression, myClass, referenceClass);
                } else if (levelitem is BlueprintFeature feature) {
                    PatchClassIntoFeatureOfReferenceClass(feature, myClass, referenceClass);
                }
            }
        }

        public static void PatchProgressionFeaturesBasedOnReferenceClass(BlueprintProgression prog, BlueprintCharacterClassReference myClass, BlueprintCharacterClassReference referenceClass) {
            var features = new HashSet<BlueprintFeatureBase>();
            foreach (LevelEntry levelEntry in prog.LevelEntries) {
                foreach (BlueprintFeatureBaseReference levelitem in levelEntry.m_Features) {
                    if (!features.Contains(levelitem)) { features.Add(levelitem); }
                }
            }
            foreach (BlueprintFeatureBase levelitem in features) {
                if (levelitem is BlueprintProgression progression) {
                    PatchClassIntoFeatureOfReferenceClass(progression, myClass, referenceClass);
                } else if (levelitem is BlueprintFeature feature) {
                    PatchClassIntoFeatureOfReferenceClass(feature, myClass, referenceClass);
                }
            }
        }

        public static void PatchClassIntoFeatureOfReferenceClass(BlueprintFact feature, BlueprintCharacterClassReference myClass, BlueprintCharacterClassReference referenceClass, int level = 0, HashSet<BlueprintFact> loopPrevention = null) {
            loopPrevention ??= new();
            int mylevel = level + 1;
            if (mylevel > 10) {
                IsekaiContext.Logger.LogError("Attempt to patch Progression Tree stopped at Level 10 to prevent endless loop, if you see this message please report so we can figure out if someone created a loop here or if this limit needs to be higher");
                if (feature.name != null) {
                    IsekaiContext.Logger.LogError($"reference class={referenceClass.Guid} Stop Feature={feature.AssetGuid} name={feature.name}");
                    foreach (BlueprintFeatureBase calltrace in loopPrevention) {
                        IsekaiContext.Logger.LogError($"guid={calltrace.AssetGuid}");
                    }
                } else {
                    IsekaiContext.Logger.LogError($"reference class={referenceClass.Guid} Stop Feature={feature.AssetGuid}");
                }
                return;
            }
            if (feature == null || myClass == null || referenceClass == null) {
                IsekaiContext.Logger.LogError("Call to add feature but one of the three parameters is null");
                return;
            }
            if (FeaturesIgnoredWhenPatching.Contains(feature)) {
                //these lists are to be ignored because they are known to be massive but are mostly subsets of the basic feat list or other things that should never contain something class specific that needs patching
                return;
            }
            if (loopPrevention.Contains(feature)) {
                IsekaiContext.Logger.Log($"reference class={referenceClass.Guid} feature re-encountered at level={mylevel} guid={feature.AssetGuid} name={feature.name}");
                return;
            } else {
                loopPrevention.Add(feature);
            }
            try {
                if (feature is BlueprintProgression progression) {
                    PatchClassProgression(progression, myClass, referenceClass, mylevel, loopPrevention);
                }
                if (feature is BlueprintFeatureSelection selection) {
                    PatchClassSelection(selection, myClass, referenceClass, mylevel, loopPrevention);
                }
                //components is null for BlueprintProgressions despite the fact that they implement Blueprintfeature, that will cause a nullpointer,
                //and since the cast to Blueptintfeature will work since it "supposedly" implements it checking if the field is null is the safest solution
                if (feature.Components != null && feature.Components.Length > 0) {
                    HashSet<SpellReference> mySpellSet = new HashSet<SpellReference>();
                    List<SpontaneousSpellConversion> conversions = new List<SpontaneousSpellConversion>();
                    List<CannyDefensePermanent> cannyDefenses = new List<CannyDefensePermanent>();
                    List<AddFeatureOnClassLevel> addFeatureOnClassLevels = new List<AddFeatureOnClassLevel>();
                    foreach (var component in feature.Components) {
                        if (component == null) continue;
                        //check if component is addSpell or addFeat
                        HandleComponent(feature.AssetGuid, myClass, referenceClass, mylevel, mySpellSet, component, loopPrevention);
                        if (component is ContextRankConfig rankConfig && (
                            rankConfig.m_BaseValueType == ContextRankBaseValueType.ClassLevel ||
                            rankConfig.m_BaseValueType == ContextRankBaseValueType.SummClassLevelWithArchetype)) {
                            if (rankConfig.m_Class.Contains(myClass)) {
                                //already patched return
                                return;
                            }
                            if (rankConfig.m_Class.Contains(referenceClass)) {
                                rankConfig.m_Class = rankConfig.m_Class.AddToArray(myClass);
                                //test at level 20 if needed
                                //rankConfig.m_BaseValueType = ContextRankBaseValueType.SummClassLevelWithArchetype;
                            }
                        }
                        else if (component is SpontaneousSpellConversion conversion && conversion.m_CharacterClass != null && conversion.m_CharacterClass.Equals(referenceClass)) {
                            conversions.Add(conversion);
                        }
                        else if (component is CannyDefensePermanent cannyDefense && cannyDefense.m_CharacterClass != null && cannyDefense.m_CharacterClass.Equals(referenceClass)) {
                            cannyDefenses.Add(cannyDefense);
                        }
                        else if (component is AddFeatureOnClassLevel addFeatureOnLevel) {
                            PatchClassIntoFeatureOfReferenceClass(addFeatureOnLevel.m_Feature.Get(), myClass, referenceClass, mylevel, loopPrevention);
                            if (addFeatureOnLevel.m_Class != null && addFeatureOnLevel.m_Class.Equals(referenceClass)) {
                                addFeatureOnClassLevels.Add(addFeatureOnLevel);
                            }
                        }
                    }
                    foreach (var spellReference in mySpellSet) {
                        feature.AddComponent<AddKnownSpell>(c => {
                            c.m_CharacterClass = myClass;
                            c.m_Spell = spellReference.value;
                            c.SpellLevel = spellReference.level;

                        });
                    }
                    foreach (SpontaneousSpellConversion conversion in conversions) {
                        feature.AddComponent<SpontaneousSpellConversion>(c => {
                            c.m_CharacterClass = myClass;
                            c.m_SpellsByLevel = conversion.m_SpellsByLevel;
                        });
                    }
                    foreach (CannyDefensePermanent cannyDefense in cannyDefenses) {
                        feature.AddComponent<CannyDefensePermanent>(c => {
                            c.m_CharacterClass = myClass;
                            c.RequiresKensai = cannyDefense.RequiresKensai;
                            c.m_ChosenWeaponBlueprint = cannyDefense.m_ChosenWeaponBlueprint;
                        });
                    }
                    foreach (AddFeatureOnClassLevel addFeatureOnClassLevel in addFeatureOnClassLevels) {
                        feature.AddComponent<AddFeatureOnClassLevel>(c => {
                            c.m_Class = myClass;
                            c.Level = addFeatureOnClassLevel.Level;
                            c.BeforeThisLevel = addFeatureOnClassLevel.BeforeThisLevel;
                            c.m_Feature = addFeatureOnClassLevel.m_Feature;
                            c.m_AdditionalClasses = addFeatureOnClassLevel.m_AdditionalClasses;
                            c.m_Archetypes = addFeatureOnClassLevel.m_Archetypes;
                        });
                    }
                }
            } catch (NullReferenceException e) {
                if (feature.name != null) {
                    IsekaiContext.Logger.LogError($"Unpatachable Feature={feature.AssetGuid} name={feature.name} at level={mylevel} reason={e.Message}");
                } else {
                    IsekaiContext.Logger.LogError($"Unpatachable Feature={feature.AssetGuid} at level={mylevel} reason={e.Message}");
                }
            }
        }

        private static void PatchClassProgression(BlueprintProgression progression, BlueprintCharacterClassReference myClass, BlueprintCharacterClassReference referenceClass, int mylevel, HashSet<BlueprintFact> loopPrevention) {
            progression.GiveFeaturesForPreviousLevels = true;
            if (progression.m_Classes != null && progression.m_Classes.Length > 0) {
                foreach (var refClass in progression.m_Classes) {
                    if (refClass != null && myClass.Equals(refClass.m_Class)) return;
                }
                progression.AddClass(myClass);
            }
            HashSet<BlueprintFeatureBase> features = new();
            foreach (LevelEntry levelEntry in progression.LevelEntries) {
                foreach (BlueprintFeatureBase levelitem in levelEntry.Features) {
                    if (levelitem != null && !features.Contains(levelitem)) {
                        features.Add(levelitem);
                    }
                }
            }
            foreach (BlueprintFeatureBase feature in features) {
                PatchClassIntoFeatureOfReferenceClass(feature, myClass, referenceClass, mylevel, loopPrevention);
            }
        }

        private static void PatchClassSelection(BlueprintFeatureSelection selection, BlueprintCharacterClassReference myClass, BlueprintCharacterClassReference referenceClass, int mylevel, HashSet<BlueprintFact> loopPrevention) {
            //don't trust selections past a certain size to actually contain class features rather than just a selection of basic feats unless they are selections that are known to be that size for a valid reason(revelations, hexes, rage powers)
            string selectionGuid = selection.AssetGuid.ToString();
            if (selection.m_AllFeatures.Length > 30 && !(
                selectionGuid.Equals("60008a10ad7ad6543b1f63016741a5d2") // OracleRevelationSelection
                || selectionGuid.Equals("c074a5d615200494b8f2a9c845799d93") // RogueTalentSelection
                || selectionGuid.Equals("4223fe18c75d4d14787af196a04e14e7") // ShamanHexSelection
                || selectionGuid.Equals("28710502f46848d48b3f0d6132817c4e") // RagePowerSelection
                || selectionGuid.Equals("2476514e31791394fa140f1a07941c96") // SkaldRagePowerSelection
                || selectionGuid.Equals("9846043cf51251a4897728ed6e24e76f") // WitchHexSelection
                || selectionGuid.Equals("99999999000900000009000000000001") // InquisitorDomains (In our mod)
                || selectionGuid.Equals("58d6f8e9eea63f6418b107ce64f315ea") // InfusionSelection
                || selectionGuid.Equals("5c883ae0cd6d7d5448b7a420f51f8459") // WildTalentSelection
                )) {
                IsekaiContext.Logger.LogError($"reference class={referenceClass.Guid} Stop Feature={selectionGuid} name={selection.name} reason=selection contains too many features and thus likely is a basic feat variation");
                return;
            }
            foreach (BlueprintFeatureReference featureRef in selection.m_AllFeatures) {
                PatchClassIntoFeatureOfReferenceClass(featureRef?.Get(), myClass, referenceClass, mylevel, loopPrevention);
            }
        }

        private static void HandleComponent(BlueprintGuid featureGuid, BlueprintCharacterClassReference myClass, BlueprintCharacterClassReference referenceClass, int level, HashSet<SpellReference> mySpellSet, BlueprintComponent component, HashSet<BlueprintFact> loopPrevention) {
            var mylevel = level + 1;
            if (mylevel > 20) {
                IsekaiContext.Logger.LogError("Attempt to patch Progression Tree stopped at Level 20 to prevent endless loop, if you see this message please report so we can figure out if someone created a loop here or if this limit needs to be higher");
                return;
            }
            if (component == null) { return; }

            try {
                if (component is AddKnownSpell asSpell && asSpell.m_CharacterClass != null && asSpell.m_CharacterClass.Equals(referenceClass)) {
                    mySpellSet.Add(new SpellReference(asSpell.SpellLevel, asSpell.m_Spell));
                }
            } catch (NullReferenceException) {
                IsekaiContext.Logger.LogError($"{featureGuid} component cast asSpell failed due to Nullpointer");
            }

            try {
                // we do not have a special spell list, so just add all such spells to spells known
                if (component is AddSpecialSpellList asSpellList && asSpellList.m_CharacterClass.Equals(referenceClass)) {
                    foreach (var level2 in asSpellList.SpellList.SpellsByLevel) {
                        foreach (var spell in level2.m_Spells) {
                            mySpellSet.Add(new SpellReference(level2.SpellLevel, spell));
                        }
                    }
                }
            } catch (NullReferenceException) {
                IsekaiContext.Logger.LogError($"{featureGuid} component cast AddSpecialSpellList failed due to Nullpointer");
            }
            if (component is AddAbilityUseTrigger trigger && trigger.m_Spellbooks != null && trigger.m_Spellbooks.Length > 0) {
                trigger.m_Spellbooks = trigger.m_Spellbooks.AddRangeToArray(patchableSpellBooks);
            }
            if (component is AddCasterLevelForSpellbook cl && cl.m_Spellbooks != null && cl.m_Spellbooks.Length > 0) {
                cl.m_Spellbooks = cl.m_Spellbooks.AddRangeToArray(patchableSpellBooks);
            }
            if (component is IncreaseSpellSpellbookDC cdc && cdc.m_Spellbooks != null && cdc.m_Spellbooks.Length > 0) {
                cdc.m_Spellbooks = cdc.m_Spellbooks.AddRangeToArray(patchableSpellBooks);
            }
            if (component is MonkNoArmorFeatureUnlock addUnarmedFact) {
                var fact = addUnarmedFact.m_NewFact.Get();
                if (fact != null) {
                    if (fact is BlueprintFeature feature2) {
                        PatchClassIntoFeatureOfReferenceClass(feature2, myClass, referenceClass, mylevel, loopPrevention);
                    }
                    if (fact is BlueprintProgression progression2) {
                        PatchClassIntoFeatureOfReferenceClass(progression2, myClass, referenceClass, mylevel, loopPrevention);
                    }
                    if (fact is BlueprintUnitFact unitFact2) {
                        foreach (var component2 in unitFact2.Components) {
                            HandleComponent(unitFact2.AssetGuid, myClass, referenceClass, mylevel, mySpellSet, component2, loopPrevention);
                        }
                    }
                }
            }
            if (component is AddFeatureIfHasFact addIfFact) {
                PatchClassIntoFeatureOfReferenceClass(addIfFact.m_Feature, myClass, referenceClass, mylevel, loopPrevention);
            }

            try {
                // check if component is add facts because features could also be added as facts rather than on level...
                if (component is AddFacts addFact) {
                    foreach (BlueprintUnitFact factRef in addFact.Facts) {
                        if (factRef != null) {
                            if (factRef is BlueprintFeature feature2) {
                                PatchClassIntoFeatureOfReferenceClass(feature2, myClass, referenceClass, mylevel, loopPrevention);
                            }
                            if (factRef is BlueprintProgression progression2) {
                                PatchClassIntoFeatureOfReferenceClass(progression2, myClass, referenceClass, mylevel, loopPrevention);
                            }
                            if (factRef is BlueprintUnitFact unitFact2 && unitFact2.Components != null && unitFact2.Components.Length > 0) {
                                foreach (var component2 in unitFact2.Components) {
                                    HandleComponent(unitFact2.AssetGuid, myClass, referenceClass, mylevel, mySpellSet, component2, loopPrevention);
                                }
                            }
                            if (factRef is BlueprintAbility ability && ability.Components != null && ability.Components.Length > 0) {
                                foreach (var component2 in ability.Components) {
                                    if (component2 is ContextRankConfig rankConfig && (
                                        rankConfig.m_BaseValueType == ContextRankBaseValueType.ClassLevel ||
                                        rankConfig.m_BaseValueType == ContextRankBaseValueType.SummClassLevelWithArchetype)) {
                                        if (rankConfig.m_Class.Contains(myClass)) {
                                            //already patched return
                                            return;
                                        }
                                        if (rankConfig.m_Class.Contains(referenceClass)) {
                                            //rankConfig.m_BaseValueType = ContextRankBaseValueType.SummClassLevelWithArchetype;
                                            rankConfig.m_Class = rankConfig.m_Class.AddToArray(myClass);
                                        }
                                    }
                                }
                            }
                        } else {
                            IsekaiContext.Logger.LogError($"{featureGuid} component cast AddFacts factRef was null");
                        }
                    }
                }
            } catch (NullReferenceException) {
                IsekaiContext.Logger.LogError($"{featureGuid} component cast AddFacts failed due to Nullpointer");
            }
            if (component is AddAbilityResources addResource) {
                BlueprintAbilityResourceReference resRef = addResource.m_Resource;
                if (resRef != null) {
                    BlueprintAbilityResource res = resRef.Get();
                    bool classlocked = false;
                    bool alreadyPatched = false;
                    if (res.m_MaxAmount.m_ClassDiv != null && res.m_MaxAmount.m_ClassDiv.Length > 0) {
                        if (res.m_MaxAmount.m_ClassDiv.Contains(referenceClass)) {
                            classlocked = true;
                        }
                        if (res.m_MaxAmount.m_ClassDiv.Contains(myClass)) {
                            alreadyPatched = true;
                        }
                        if (classlocked && !alreadyPatched) {
                            res.m_MaxAmount.m_ClassDiv.AddItem(myClass);
                            //Main.Log("class resource patched= " + resRef.Guid);
                        }
                    }
                    if (!classlocked && res.m_MaxAmount.m_Class != null && res.m_MaxAmount.m_Class.Length > 0) {
                        if (res.m_MaxAmount.m_Class.Contains(referenceClass)) {
                            classlocked = true;
                        }
                        if (res.m_MaxAmount.m_Class.Contains(myClass)) {
                            alreadyPatched = true;
                        }
                        if (classlocked && !alreadyPatched) {
                            res.m_MaxAmount.m_Class.AddItem(myClass);
                            //Main.Log("class resource patched= " + resRef.Guid);
                        }
                    }
                }
            }
        }

        internal class SpellReference {
            public int level;
            public BlueprintAbilityReference value;
            public SpellReference(int inLevel, BlueprintAbilityReference inValue) {
                level = inLevel;
                value = inValue;
            }
            public override bool Equals(object p) {
                if (p is null) return false;

                // Optimization for a common success case.
                if (ReferenceEquals(this, p)) return true;

                // If run-time types are not exactly the same, return false.
                if (GetType() != GetType()) return false;

                // Return true if the fields match.
                // Note that the base class is not invoked because it is
                // System.Object, which defines Equals as reference equality.
                return value.Guid.ToString() == ((SpellReference)p).value.Guid.ToString();
            }
            public static bool operator ==(SpellReference left, SpellReference right) {
                if (left is null && right is null) return true;
                if (left is not null) {
                    return left.Equals(right);
                }
                return false;
            }
            public static bool operator !=(SpellReference left, SpellReference right) { return !(left == right); }
            public override int GetHashCode() => value.GetHashCode();
        }

        internal static void PatchResource(BlueprintAbilityResource resource, BlueprintCharacterClassReference classRef) {
            if (resource.m_MaxAmount.m_Class != null && resource.m_MaxAmount.m_Class.Length != 0) {
                resource.m_MaxAmount.m_Class = resource.m_MaxAmount.m_Class.AppendToArray(classRef);
            }
            if (resource.m_MaxAmount.m_ClassDiv != null && resource.m_MaxAmount.m_ClassDiv.Length != 0) {
                resource.m_MaxAmount.m_ClassDiv = resource.m_MaxAmount.m_ClassDiv.AppendToArray(classRef);
            }
        }
        internal static void PatchAbility(BlueprintAbility ability, BlueprintCharacterClassReference classRef) {
            foreach (BlueprintComponent comp in ability.Components) {
                if (comp is ContextRankConfig rankConfig && rankConfig.m_Class != null && rankConfig.m_Class.Length > 0) {
                    rankConfig.m_Class = rankConfig.m_Class.AppendToArray(classRef);
                }
            }
        }
        private static void PatchBuff(BlueprintBuff buff, BlueprintSpellbookReference spellbookRef) {
            foreach (BlueprintComponent comp in buff.Components) {
                if (comp is AddAbilityUseTrigger triggerComp) {
                    triggerComp.m_Spellbooks = triggerComp.m_Spellbooks.AppendToArray(spellbookRef);
                } else if (comp is AddCasterLevelForSpellbook casterLevelComp) {
                    casterLevelComp.m_Spellbooks = casterLevelComp.m_Spellbooks.AppendToArray(spellbookRef);
                } else if (comp is IncreaseSpellSpellbookDC increaseSpellComp) {
                    increaseSpellComp.m_Spellbooks = increaseSpellComp.m_Spellbooks.AppendToArray(spellbookRef);
                }
            }
        }
        private static void PatchBuff(BlueprintBuff buff, BlueprintCharacterClassReference classRef) {
            foreach (BlueprintComponent comp in buff.Components) {
                if (comp is ContextRankConfig rankConfig && rankConfig.m_Class != null && rankConfig.m_Class.Length > 0) {
                    rankConfig.m_Class = rankConfig.m_Class.AppendToArray(classRef);
                }
            }
        }

        internal static class ArcanistPatcher {
            public static void Patch(BlueprintCharacterClassReference classRef, BlueprintSpellbookReference spellbookRef) {
                PatchArcaneResrvoir(classRef, spellbookRef);
                PatchConsumeSpells(classRef);
                PatchArcanistExploits(classRef);
            }
            private static void PatchArcaneResrvoir(BlueprintCharacterClassReference classRef, BlueprintSpellbookReference spellbookRef) {
                var ArcanistArcaneReservoirResource = BlueprintTools.GetBlueprint<BlueprintAbilityResource>("cac948cbbe79b55459459dd6a8fe44ce");
                var ArcanistArcaneReservoirResourceBuff = BlueprintTools.GetBlueprint<BlueprintBuff>("1dd776b7b27dcd54ab3cedbbaf440cf3");
                PatchBuff(ArcanistArcaneReservoirResourceBuff, classRef);
                PatchResource(ArcanistArcaneReservoirResource, classRef);
                PatchArcaneReservoirBuffs(spellbookRef);
            }
            private static void PatchConsumeSpells(BlueprintCharacterClassReference classRef) {
                var ArcanistConsumeSpellsResource = BlueprintTools.GetBlueprint<BlueprintAbilityResource>("d67ddd98ad019854d926f3d6a4e681c5");
                PatchResource(ArcanistConsumeSpellsResource, classRef);
            }
            private static void PatchArcanistExploits(BlueprintCharacterClassReference classRef) {
                var ArcanistExploitSelection = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("b8bf3d5023f2d8c428fdf6438cecaea7");
                foreach (BlueprintFeature feature in ArcanistExploitSelection.AllFeatures) {
                    AddFacts addFacts = feature.GetComponent<AddFacts>();
                    if (addFacts == null) continue;
                    foreach (BlueprintUnitFact fact in addFacts.Facts) {
                        if (fact is BlueprintAbility ability) {
                            PatchAbility(ability, classRef);
                        }
                    }
                }
                BlueprintBuff[] buffs = new BlueprintBuff[] {
                    BlueprintTools.GetBlueprint<BlueprintBuff>("d3361a1d65825aa4a952476639248792"), // ArcanistExploitLingeringAcidBuff
                    BlueprintTools.GetBlueprint<BlueprintBuff>("d3a217dba1100f9449e7f249d2916f86"), // ArcanistExploitSpellResistanceBuff
                    BlueprintTools.GetBlueprint<BlueprintBuff>("7b392a6348fe3ef4d907ce168a4c7773"), // ArcanistExploitSpellResistanceGreaterBuff
                };
                foreach (BlueprintBuff buff in buffs) {
                    PatchBuff(buff, classRef);
                }
            }
            private static void PatchArcaneReservoirBuffs(BlueprintSpellbookReference spellbookRef) {
                BlueprintBuff[] buffs = new BlueprintBuff[] {
                    BlueprintTools.GetBlueprint<BlueprintBuff>("33e0c3a2a54c0e7489fa4ec4d79a581b"), // ArcanistArcaneReservoirCLBuff
                    BlueprintTools.GetBlueprint<BlueprintBuff>("db4b91a8a297c4247b13cfb6ea228bf3"), // ArcanistArcaneReservoirDCBuff
                    BlueprintTools.GetBlueprint<BlueprintBuff>("ea01ddf2c1878354990000d1c7fc5ce4"), // ArcanistArcaneReservoirCLPotentBuff
                    BlueprintTools.GetBlueprint<BlueprintBuff>("6fea993ed5782054a88fa54037a3e6dd"), // ArcanistArcaneReservoirDCPotentBuff
                    BlueprintTools.GetBlueprint<BlueprintBuff>("a27a3c5e45f9416428ce983e0d4bd2d2"), // EldritchFontEldritchSurgeCLBuff
                    BlueprintTools.GetBlueprint<BlueprintBuff>("91b2762997f0d8044baeeef0871eac6f"), // EldritchFontEldritchSurgeDCBuff
                    BlueprintTools.GetBlueprint<BlueprintBuff>("9aab299fb44ff3c49af5b8527a23fcf7"), // EldritchFontImprovedEldritchSurgeAttackBuff
                    BlueprintTools.GetBlueprint<BlueprintBuff>("4425d831546249647b8c9ad06d7ed0e7"), // EldritchFontGreaterSurgeBuff
                };
                foreach (BlueprintBuff buff in buffs) {
                    PatchBuff(buff, spellbookRef);
                }
            }
        }

        internal static class KineticistPatcher {
            public static void Patch(BlueprintCharacterClassReference classRef) {
                // TODO: base blasts added by mods would need to be patched here
                BlueprintAbility[] baseAbilities = new BlueprintAbility[] {
                    BlueprintTools.GetBlueprint<BlueprintAbility>("0ab1552e2ebdacf44bb7b20f5393366d"), // AirBlastBase
                    BlueprintTools.GetBlueprint<BlueprintAbility>("403bcf42f08ca70498432cf62abee434"), // IceBlastBase
                    BlueprintTools.GetBlueprint<BlueprintAbility>("e2610c88664e07343b4f3fb6336f210c"), // MudBlastBase
                    BlueprintTools.GetBlueprint<BlueprintAbility>("83d5873f306ac954cad95b6aeeeb2d8c"), // FireBlastBase
                    BlueprintTools.GetBlueprint<BlueprintAbility>("7980e876b0749fc47ac49b9552e259c1"), // ColdBlastBase
                    BlueprintTools.GetBlueprint<BlueprintAbility>("e53f34fb268a7964caf1566afb82dadd"), // EarthBlastBase
                    BlueprintTools.GetBlueprint<BlueprintAbility>("3baf01649a92ae640927b0f633db7c11"), // SteamBlastBase
                    BlueprintTools.GetBlueprint<BlueprintAbility>("8c25f52fce5113a4491229fd1265fc3c"), // MagmaBlastBase
                    BlueprintTools.GetBlueprint<BlueprintAbility>("6276881783962284ea93298c1fe54c48"), // MetalBlastBase
                    BlueprintTools.GetBlueprint<BlueprintAbility>("d663a8d40be1e57478f34d6477a67270"), // WaterBlastBase
                    BlueprintTools.GetBlueprint<BlueprintAbility>("9afdc3eeca49c594aa7bf00e8e9803ac"), // PlasmaBlastBase
                    BlueprintTools.GetBlueprint<BlueprintAbility>("45eb571be891c4c4581b6fcddda72bcd"), // ElectricBlastBase
                    BlueprintTools.GetBlueprint<BlueprintAbility>("b93e1f0540a4fa3478a6b47ae3816f32"), // SandstormBlastBase
                    BlueprintTools.GetBlueprint<BlueprintAbility>("4e2e066dd4dc8de4d8281ed5b3f4acb6"),  // ChargedWaterBlastBase
                    BlueprintTools.GetBlueprint<BlueprintAbility>("b813ceb82d97eed4486ddd86d3f7771b"),  // ThunderstormBlastBase
                    BlueprintTools.GetBlueprint<BlueprintAbility>("ba2113cfed0c2c14b93c20e7625a4c74"),  // BloodBlastBase
                    BlueprintTools.GetBlueprint<BlueprintAbility>("16617b8c20688e4438a803effeeee8a6"),  // BlizzardBlastBase
                    BlueprintTools.GetBlueprint<BlueprintAbility>("d29186edb20be6449b23660b39435398"),  // BlueFlameBlastBase
                };
                foreach (BlueprintAbility baseAbility in baseAbilities) {
                    foreach (BlueprintAbilityReference abilityRef in baseAbility.GetComponent<AbilityVariants>().m_Variants) {
                        var ability = abilityRef.Get();
                        for (int i = 0; i < ability.ComponentsArray.Length; i++) {
                            BlueprintComponent component = ability.ComponentsArray[i];
                            if (component is ContextCalculateAbilityParamsBasedOnClass paramsComponent) {
                                ability.ComponentsArray[i] = new ContextCalculateAbilityParamsBasedOnClasses() {
                                    m_CharacterClasses = new BlueprintCharacterClassReference[] { paramsComponent.m_CharacterClass, classRef },
                                    StatType = paramsComponent.StatType
                                };
                            }
                        }
                    }
                }
            }
        }

        internal static class ShifterPatcher {
            public static void Patch(BlueprintCharacterClassReference classRef) {
                BlueprintBuff[] aspectBuffs = new BlueprintBuff[] {
                    BlueprintTools.GetBlueprint<BlueprintBuff>("a237792fc2644a4ebc6eefa2d325f181"), // ShifterAspectBearBuff
                    BlueprintTools.GetBlueprint<BlueprintBuff>("0fdc579eafbf4fceae649beed8188a5c"), // ShifterAspectBoarBuff
                    BlueprintTools.GetBlueprint<BlueprintBuff>("4a981c46dc60474cad17549a2b9f7f65"), // ShifterAspectDinosaurBuff
                    BlueprintTools.GetBlueprint<BlueprintBuff>("0bdfd34b7e5a4639bf6b716fa2ac0098"), // ShifterAspectHorseBuff
                    BlueprintTools.GetBlueprint<BlueprintBuff>("29c0e16558b043278f061b128b9d180c"), // ShifterAspectLizardBuff
                    BlueprintTools.GetBlueprint<BlueprintBuff>("c4c39e7078224b6caaf3c8a02032b5cb"), // ShifterAspectElephantBuff
                    BlueprintTools.GetBlueprint<BlueprintBuff>("49e196492d2c4aa588bafffea6db8c43"), // ShifterAspectSpiderBuff
                    BlueprintTools.GetBlueprint<BlueprintBuff>("0555960c7ab8431d86de4e7db0c22160"), // ShifterAspectTigerBuff
                    BlueprintTools.GetBlueprint<BlueprintBuff>("d61bd26255d4425d929d73e57ef0e6dd"), // ShifterAspectWolfBuff
                    BlueprintTools.GetBlueprint<BlueprintBuff>("e0b35a32cf234381ab13c831106937f1"), // ShifterAspectWolverineBuff
                };
                foreach (BlueprintBuff buff in aspectBuffs) {
                    foreach(ContextRankConfig rankConfig in buff.GetComponents<ContextRankConfig>()) {
                        if (rankConfig.m_BaseValueType != ContextRankBaseValueType.ClassLevel) continue;
                        rankConfig.m_Class = rankConfig.m_Class.AddToArray(classRef);
                    }
                }

                BlueprintAbilityResource[] resources = new BlueprintAbilityResource[] {
                    BlueprintTools.GetBlueprint<BlueprintAbilityResource>("2210cea8cc94431a911dc5d4b6d72cbd"), // ShifterWildShapeResource
                    BlueprintTools.GetBlueprint<BlueprintAbilityResource>("80923bd575dc48f5813c2343517414cf"), // DragonbloodShifterResource
                    BlueprintTools.GetBlueprint<BlueprintAbilityResource>("72e7ec0822604f7da75c3dd32e93d5ea"), // DragonbloodShifterBreathResource
                };
                foreach (BlueprintAbilityResource resource in resources) {
                    PatchResource(resource, classRef);
                }

                var shifterClassRef = BlueprintTools.GetBlueprintReference<BlueprintCharacterClassReference>("a406d6ebea5c46bba3160246be03e96f");
                BlueprintAbility[] abilities = new BlueprintAbility[] {
                    BlueprintTools.GetBlueprint<BlueprintAbility>("c35a9830c7684f76a704aff424128851"), // ShifterDragonForm20Neutral
                    BlueprintTools.GetBlueprint<BlueprintAbility>("2d52be9832e542bc88b1959be2f3b2e2"), // ShifterDragonForm20Good
                    BlueprintTools.GetBlueprint<BlueprintAbility>("f619bb36520a48478f900431b20d50c4"), // ShifterDragonForm20Evil
                };
                foreach (BlueprintAbility ability in abilities) {
                    PatchClassIntoFeatureOfReferenceClass(ability, classRef, shifterClassRef);
                }

                BlueprintBuff[] dragonAspectBuffs = new BlueprintBuff[] {
                    BlueprintTools.GetBlueprint<BlueprintBuff>("ace35704bf744216b142adcbd5c58d13"), // DragonbloodShifterBlackBuff
                    BlueprintTools.GetBlueprint<BlueprintBuff>("627c3f3256494000b3cba6f461b2c44c"), // DragonbloodShifterBlueBuff
                    BlueprintTools.GetBlueprint<BlueprintBuff>("e850db860994442b83e964d3a43e9358"), // DragonbloodShifterGreenBuff
                    BlueprintTools.GetBlueprint<BlueprintBuff>("fb71be7bcbc648539d57171b0d0baf79"), // DragonbloodShifterRedBuff
                    BlueprintTools.GetBlueprint<BlueprintBuff>("cd34e74f0d2844e3ab5580c1dbe3ff7d"), // DragonbloodShifterWhiteBuff
                    BlueprintTools.GetBlueprint<BlueprintBuff>("ed9ac87aaac7419095395304c7b5d813"), // DragonbloodShifterBrassBuff
                    BlueprintTools.GetBlueprint<BlueprintBuff>("233617f6876a42ef973de8af502d4fed"), // DragonbloodShifterBronzeBuff
                    BlueprintTools.GetBlueprint<BlueprintBuff>("566474477be14eaeb860086b82e5e9cf"), // DragonbloodShifterCopperBuff
                    BlueprintTools.GetBlueprint<BlueprintBuff>("e36d67f4b25a4d5ebf9add1e2bc52e74"), // DragonbloodShifterGoldBuff
                    BlueprintTools.GetBlueprint<BlueprintBuff>("d9de1c4f6e68416196c193ac87962993"), // DragonbloodShifterSilverBuff
                };
                foreach (BlueprintBuff dragonBuff in dragonAspectBuffs) {
                    PatchClassIntoFeatureOfReferenceClass(dragonBuff, classRef, shifterClassRef);
                }
            }
        }

        [HarmonyPatch(typeof(UnitPartMagus), "get_Spellbook")]
        public static class UnitPartMagusPatcher {
            public static bool Prefix(UnitPartMagus __instance, ref Spellbook __result) {
                ClassData classData = __instance.Owner.Progression.GetClassData(IsekaiProtagonistClass.Get());
                if (classData == null) {
                    return false;
                }
                BlueprintSpellbook blueprintSpellbook;
                if ((blueprintSpellbook = (classData?.Spellbook.Or(null))) == null) {
                    BlueprintCharacterClass blueprintCharacterClass = __instance.Class.Or(null);
                    blueprintSpellbook = (blueprintCharacterClass?.Spellbook);
                }
                BlueprintSpellbook blueprintSpellbook2 = blueprintSpellbook;
                __instance.m_Spellbook = ((blueprintSpellbook2 != null) ? __instance.Owner.GetSpellbook(blueprintSpellbook2) : null);
                if (__instance.m_Spellbook == null) {
                    __instance.m_Spellbook = __result;
                    return false;
                } else {
                    __result = __instance.m_Spellbook;
                    return true;
                }
            }
        }
    }
}
