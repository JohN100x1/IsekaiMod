using HarmonyLib;
using IsekaiMod.Content.Classes.IsekaiProtagonist;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Designers.Mechanics.Buffs;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.Localization;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Utilities {

    public class StaticReferences {
        // Base Classes
        public static readonly BlueprintCharacterClass[] BaseClasses = new BlueprintCharacterClass[25] {
            ClassTools.Classes.AlchemistClass,
            ClassTools.Classes.ArcanistClass,
            ClassTools.Classes.BarbarianClass,
            ClassTools.Classes.BardClass,
            ClassTools.Classes.BloodragerClass,
            ClassTools.Classes.CavalierClass,
            ClassTools.Classes.ClericClass,
            ClassTools.Classes.DruidClass,
            ClassTools.Classes.FighterClass,
            ClassTools.Classes.HunterClass,
            ClassTools.Classes.InquisitorClass,
            ClassTools.Classes.KineticistClass,
            ClassTools.Classes.MagusClass,
            ClassTools.Classes.MonkClass,
            ClassTools.Classes.OracleClass,
            ClassTools.Classes.PaladinClass,
            ClassTools.Classes.RangerClass,
            ClassTools.Classes.RogueClass,
            ClassTools.Classes.ShamanClass,
            ClassTools.Classes.SkaldClass,
            ClassTools.Classes.SlayerClass,
            ClassTools.Classes.SorcererClass,
            ClassTools.Classes.WarpriestClass,
            ClassTools.Classes.WitchClass,
            ClassTools.Classes.WizardClass
        };

        //Oracle
        public static BlueprintFeatureSelection OracleCurseSelection = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("b0a5118b4fb793241bc7042464b23fab");
        public static BlueprintFeatureSelection OracleMysterySelection = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("5531b975dcdf0e24c98f1ff7e017e741");
        public static BlueprintFeatureSelection OracleRevelationSelection = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("60008a10ad7ad6543b1f63016741a5d2");
        public static BlueprintFeatureSelection OraclePositiveNegativeSelection = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("2cd080fc181122c4a9c5a705abe8ad47");

        //Sorcerer
        public static BlueprintFeatureSelection SorcererBloodlineSelection = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("24bef8d1bee12274686f6da6ccbc8914");
        public static BlueprintFeatureSelection SorcererFeatSelection = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("d6dd06f454b34014ab0903cb1ed2ade3");
        public static BlueprintFeatureSelection SorcererBloodlineArcanaSelection = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("20a2435574bdd7f4e947f405df2b25ce");
        public static readonly BlueprintParametrizedFeature SorcererArcana = BlueprintTools.GetBlueprint<BlueprintParametrizedFeature>("4a2e8388c2f0dd3478811d9c947bebfb");

        private static BlueprintSpellbookReference[] patchableSpellBooks = new BlueprintSpellbookReference[] { };


        public static readonly BlueprintFeatureBase[] FeaturesIgnoredWhenPatching = new BlueprintFeatureBase[] {
            FeatTools.Selections.BasicFeatSelection,
            FeatTools.Selections.FighterFeatSelection,
            FeatTools.Selections.CombatTrick,
            FeatTools.Selections.SkaldFeatSelection,
            FeatTools.Selections.AnimalCompanionSelectionDomain,
            FeatTools.Selections.WarDomainGreaterFeatSelection,
            FeatTools.Selections.MagusFeatSelection,
            FeatTools.Selections.CavalierBonusFeatSelection,
            BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("f1add10c87fa4563ad5f71779eecde19")
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
            prog.LevelEntries = new LevelEntry[] { };
            var referenceUIGroups = refClass.Progression.UIGroups;
            prog.UIGroups = new UIGroup[] { };
            foreach (var referenceUIGroup in referenceUIGroups) {
                prog.UIGroups = prog.UIGroups.AddToArray(referenceUIGroup);
            }
            prog.m_UIDeterminatorsGroup = new BlueprintFeatureBaseReference[] { };
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
            var referenceLevels = refClass.Progression.LevelEntries;
            BlueprintFeatureBase[] MissingUIGroup = new BlueprintFeatureBase[] { };
            foreach (var referenceLevel in referenceLevels) {
                BlueprintFeatureBaseReference[] features = new BlueprintFeatureBaseReference[] { };
                var addItems = referenceLevel.m_Features.ToArray();
                BlueprintFeatureBaseReference[] removed = new BlueprintFeatureBaseReference[] { };
                foreach (var candidate in refArchetype.RemoveFeatures) {
                    if (candidate.Level == referenceLevel.Level) {
                        removed = removed.AddRangeToArray(candidate.m_Features.ToArray());
                    }
                }
                foreach (var feature in addItems) {
                    if (!removed.Contains(feature)) {
                        features = features.AddToArray(feature);
                    }
                }
                BlueprintFeatureBaseReference[] added = new BlueprintFeatureBaseReference[] { };
                foreach (var candidate in refArchetype.AddFeatures) {
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
                    foreach (var candidate in additionalReference) {
                        if (candidate.Level == referenceLevel.Level) {
                            additionalFeatures = candidate;
                        }
                    }
                    if (additionalFeatures != null) {
                        foreach (var feature in additionalFeatures.m_Features) {
                            features = features.AddToArray(feature);
                            if (!MissingUIGroup.Contains(feature)) { MissingUIGroup = MissingUIGroup.AddToArray(feature); }
                        }
                    }
                }
                prog.LevelEntries = prog.LevelEntries.AddToArray(Helpers.CreateLevelEntry(referenceLevel.Level, features));
            };
            //run through them again to get references to levels that had no features previously
            if (additionalReference != null) {
                foreach (var level in additionalReference) {
                    bool found = false;
                    foreach (var refLevel in prog.LevelEntries) {
                        if (refLevel.Level == level.Level) {
                            found = true;
                        }
                    }
                    if (!found) {
                        prog.LevelEntries = prog.LevelEntries.AddToArray(level);
                        foreach (var feature in level.m_Features) { if (!MissingUIGroup.Contains(feature)) { MissingUIGroup = MissingUIGroup.AddToArray(feature); } }
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
                foreach (var levelitem in levelEntry.Features) {
                    if (!features.Contains(levelitem)) { features.Add(levelitem); }
                }
            }
            foreach (BlueprintFeatureBase levelitem in features) {
                if (levelitem is BlueprintProgression progression) {
                    PatchClassIntoFeatureOfReferenceClass(progression, myClass, referenceClass, 0, new BlueprintFeatureBase[] { });
                } else {
                    if (levelitem is BlueprintFeature feature) {
                        PatchClassIntoFeatureOfReferenceClass(feature, myClass, referenceClass, 0, new BlueprintFeatureBase[] { });
                    }
                }
            }
        }

        public static void PatchProgressionFeaturesBasedOnReferenceClass(BlueprintProgression prog, BlueprintCharacterClassReference myClass, BlueprintCharacterClassReference referenceClass) {
            var features = new HashSet<BlueprintFeatureBase>();
            foreach (LevelEntry levelEntry in prog.LevelEntries) {
                foreach (var levelitem in levelEntry.m_Features) {
                    if (!features.Contains(levelitem)) { features.Add(levelitem); }
                }
            }
            foreach (BlueprintFeatureBase levelitem in features) {
                if (levelitem is BlueprintProgression progression) {
                    PatchClassIntoFeatureOfReferenceClass(progression, myClass, referenceClass, 0, new BlueprintFeatureBase[] { });
                } else {
                    if (levelitem is BlueprintFeature feature) {
                        PatchClassIntoFeatureOfReferenceClass(feature, myClass, referenceClass, 0, new BlueprintFeatureBase[] { });
                    }
                }
            }
        }

        public static void PatchClassIntoFeatureOfReferenceClass(BlueprintFeature feature, BlueprintCharacterClassReference myClass, BlueprintCharacterClassReference referenceClass, int level, BlueprintFeatureBase[] loopPrevention) {
            var mylevel = level + 1;
            if (mylevel > 10) {
                IsekaiContext.Logger.LogError("Attempt to patch Progression Tree stopped at Level 10 to prevent endless loop, if you see this message please report so we can figure out if someone created a loop here or if this limit needs to be higher");
                if (feature.Name != null) {
                    IsekaiContext.Logger.LogError("reference class= " + referenceClass.Guid + " Stop Feature= " + feature.AssetGuid + " name= " + feature.Name);
                    foreach (BlueprintFeatureBase calltrace in loopPrevention) {
                        IsekaiContext.Logger.LogError("guid= " + calltrace.AssetGuid);
                    }
                } else {
                    IsekaiContext.Logger.LogError("reference class= " + referenceClass.Guid + " Stop Feature= " + feature.AssetGuid);
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
                IsekaiContext.Logger.Log("reference class= " + referenceClass.Guid + " feature re-encountered at level= " + mylevel + " guid= " + feature.AssetGuid + " name= " + feature.Name);
            } else {
                loopPrevention = loopPrevention.AddToArray(feature);
            }
            try {
                if (feature is BlueprintProgression progression) {
                    progression.GiveFeaturesForPreviousLevels = true;
                    if (progression.m_Classes != null && progression.m_Classes.Length > 0) {
                        progression.AddClass(myClass);
                    }
                    BlueprintFeatureBase[] flatten = new BlueprintFeatureBase[] { };
                    foreach (LevelEntry item in progression.LevelEntries) {
                        foreach (var levelitem in item.Features) {
                            if (levelitem != null && !flatten.Contains(levelitem)) {
                                flatten = flatten.AddToArray(levelitem);
                            }
                        }
                    }
                    foreach (var levelItem in flatten) {
                        if (levelItem is BlueprintProgression progression2) {
                            PatchClassIntoFeatureOfReferenceClass(progression2, myClass, referenceClass, mylevel, loopPrevention);
                        } else {
                            if (levelItem is BlueprintFeature feature2) {
                                PatchClassIntoFeatureOfReferenceClass(feature2, myClass, referenceClass, mylevel, loopPrevention);
                            }
                        }
                    }
                }
                if (feature is BlueprintFeatureSelection selection) {
                    //don't trust selections past a certain size to actually contain class features rather than just a selection of basic feats unless they are selections that are known to be that size for a valid reason(revelations, hexes, rage powers)
                    if (selection.m_AllFeatures.Length > 30 && !(
                        feature.AssetGuid.ToString().Equals("60008a10ad7ad6543b1f63016741a5d2")
                        || feature.AssetGuid.ToString().Equals("c074a5d615200494b8f2a9c845799d93")
                        || feature.AssetGuid.ToString().Equals("4223fe18c75d4d14787af196a04e14e7")
                        || feature.AssetGuid.ToString().Equals("28710502f46848d48b3f0d6132817c4e")
                        || feature.AssetGuid.ToString().Equals("2476514e31791394fa140f1a07941c96")
                        || feature.AssetGuid.ToString().Equals("9846043cf51251a4897728ed6e24e76f")
                        || feature.AssetGuid.ToString().Equals("99999999000900000009000000000001")
                        || feature.AssetGuid.ToString().Equals("58d6f8e9eea63f6418b107ce64f315ea")
                        || feature.AssetGuid.ToString().Equals("5c883ae0cd6d7d5448b7a420f51f8459")
                        )) {
                        IsekaiContext.Logger.LogError("reference class= " + referenceClass.Guid + " Stop Feature= " + feature.AssetGuid + " name= " + feature.Name + " reason= selection contains too many features and thus likely is a basic feat variation");
                        return;
                    }
                    foreach (var feature2 in selection.m_AllFeatures) {
                        PatchClassIntoFeatureOfReferenceClass(feature2, myClass, referenceClass, mylevel, loopPrevention);
                    }
                }
                //components is null for BlueprintProgressions despite the fact that they implement Blueprintfeature, that will cause a nullpointer,
                //and since the cast to Blueptintfeature will work since it "supposedly" implements it checking if the field is null is the safest solution
                if (feature.Components != null) {
                    var mySpellSet = new HashSet<SpellReference>();
                    ContextRankConfig sample = null;
                    SpontaneousSpellConversion[] conversions = new SpontaneousSpellConversion[] { };
                    bool alreadyPatched = false;
                    foreach (var component in feature.Components) {
                        //check if component is addSpell or addFeat
                        HandleComponent(myClass, referenceClass, mylevel, mySpellSet, component, loopPrevention);
                        if (component is ContextRankConfig rankConfig && rankConfig.m_BaseValueType == ContextRankBaseValueType.ClassLevel) {
                            if (rankConfig.m_Class.Contains(referenceClass)) {
                                sample = rankConfig;
                            } else {
                                if (rankConfig.m_Class.Contains(myClass)) {
                                    alreadyPatched = true;
                                }
                            }
                        }
                        if (component is SpontaneousSpellConversion conversion && conversion.m_CharacterClass != null && conversion.m_CharacterClass.Equals(referenceClass)) {
                            conversions = conversions.AddToArray(conversion);
                        }
                    }
                    foreach (var spellReference in mySpellSet) {
                        feature.AddComponent<AddKnownSpell>(c => {
                            c.m_Spell = spellReference.value;
                            c.SpellLevel = spellReference.level;
                            c.m_CharacterClass = myClass;

                        });
                    }
                    if (sample != null && !alreadyPatched) {
                        feature.AddComponent<ContextRankConfig>(c => {
                            c.m_BaseValueType = ContextRankBaseValueType.ClassLevel;
                            c.m_Type = sample.m_Type;
                            c.m_StartLevel = sample.m_StartLevel;
                            c.m_Progression = sample.m_Progression;
                            c.m_Flags = sample.m_Flags;
                            c.m_BuffRankMultiplier = sample.m_BuffRankMultiplier;
                            c.m_Class = new BlueprintCharacterClassReference[] { myClass };
                            c.m_CustomProgression = sample.m_CustomProgression;
                            c.m_Max = sample.m_Max;
                            c.m_Min = sample.m_Min;
                            c.m_Stat = sample.m_Stat;
                            c.m_StepLevel = sample.m_StepLevel;
                            c.m_ExceptClasses = sample.m_ExceptClasses;
                        });
                        //Main.Log("rank progression patched= " + feature.AssetGuid + " added class= " + myClass.Guid + " for ref= " + referenceClass.Guid);
                    }
                    if (conversions.Length > 0) {
                        foreach (var conversion in conversions) {
                            feature.AddComponent<SpontaneousSpellConversion>(c => {
                                c.m_CharacterClass = myClass;
                                c.m_SpellsByLevel = conversion.m_SpellsByLevel;
                            });
                        }
                    }
                }
            } catch (NullReferenceException e) {
                if (feature.Name != null) {
                    IsekaiContext.Logger.LogError("Unpatachable Feature= " + feature.AssetGuid + "name= " + feature.Name + " at level= " + mylevel + " reason= " + e.Message);
                } else {
                    IsekaiContext.Logger.LogError("Unpatachable Feature= " + feature.AssetGuid + " at level= " + mylevel + " reason= " + e.Message);
                }
            }
        }

        private static void HandleComponent(BlueprintCharacterClassReference myClass, BlueprintCharacterClassReference referenceClass, int level, HashSet<SpellReference> mySpellSet, BlueprintComponent component, BlueprintFeatureBase[] loopPrevention) {
            var mylevel = level + 1;
            if (mylevel > 20) {
                IsekaiContext.Logger.LogError("Attempt to patch Progression Tree stopped at Level 20 to prevent endless loop, if you see this message please report so we can figure out if someone created a loop here or if this limit needs to be higher");
                return;
            }
            if (component == null) { return; }
            if (component is AddKnownSpell asSpell) {
                //don't re add spells already added for my class
                if (asSpell.m_CharacterClass == referenceClass) {
                    mySpellSet.Add(new SpellReference(asSpell.SpellLevel, asSpell.m_Spell));
                }
            }
            // we do not have a special spell list, so just add all such spells to spells known
            if (component is AddSpecialSpellList asSpellList && asSpellList.m_CharacterClass == referenceClass) {
                foreach (var level2 in asSpellList.SpellList.SpellsByLevel) {
                    foreach (var spell in level2.m_Spells) {
                        mySpellSet.Add(new SpellReference(level2.SpellLevel, spell));
                    }
                }
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
            //check if component is AddFeature
            if (component is AddFeatureOnClassLevel asFeat) {
                PatchClassIntoFeatureOfReferenceClass(asFeat.m_Feature.Get(), myClass, referenceClass, mylevel, loopPrevention);
                //only add our class as an additional class if the original entry was not valid for all classes but was restricted to the correct base class
                if (asFeat.m_Class != null && asFeat.m_Class == referenceClass
                    && (asFeat.m_AdditionalClasses == null || !asFeat.m_AdditionalClasses.Contains(myClass))) {
                    asFeat.m_AdditionalClasses.AddItem(myClass);
                }
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
                    if (fact is BlueprintUnitFact unitFact) {
                        foreach (var component2 in unitFact.Components) {
                            HandleComponent(myClass, referenceClass, mylevel, mySpellSet, component2, loopPrevention);
                        }
                    }
                }
            }
            // check if component is add facts because features could also be added as facts rather than on level...
            if (component is AddFacts addFact) {
                foreach (var factRef in addFact.Facts) {
                    if (factRef is BlueprintFeature feature2) {
                        PatchClassIntoFeatureOfReferenceClass(feature2, myClass, referenceClass, mylevel, loopPrevention);
                    }
                    if (factRef is BlueprintProgression progression2) {
                        PatchClassIntoFeatureOfReferenceClass(progression2, myClass, referenceClass, mylevel, loopPrevention);
                    }
                    if (factRef is BlueprintUnitFact unitFact) {
                        foreach (var component2 in unitFact.Components) {
                            HandleComponent(myClass, referenceClass, mylevel, mySpellSet, component2, loopPrevention);
                        }
                    }
                    if (factRef is BlueprintAbility ability) {
                        ContextRankConfig sample = null;
                        bool alreadyPatched = false;
                        foreach (var component2 in ability.Components) {
                            if (component2 is ContextRankConfig rankConfig && rankConfig.m_BaseValueType == ContextRankBaseValueType.ClassLevel) {
                                if (rankConfig.m_Class.Contains(referenceClass)) {
                                    sample = rankConfig;
                                } else {
                                    if (rankConfig.m_Class.Contains(myClass)) {
                                        alreadyPatched = true;
                                    }
                                }
                            }
                        }
                        if (sample != null && !alreadyPatched) {
                            ability.AddComponent<ContextRankConfig>(c => {
                                c.m_BaseValueType = ContextRankBaseValueType.ClassLevel;
                                c.m_Type = sample.m_Type;
                                c.m_StartLevel = sample.m_StartLevel;
                                c.m_Progression = sample.m_Progression;
                                c.m_Flags = sample.m_Flags;
                                c.m_BuffRankMultiplier = sample.m_BuffRankMultiplier;
                                c.m_Class = new BlueprintCharacterClassReference[] { myClass };
                                c.m_CustomProgression = sample.m_CustomProgression;
                                c.m_Max = sample.m_Max;
                                c.m_Min = sample.m_Min;
                                c.m_Stat = sample.m_Stat;
                                c.m_StepLevel = sample.m_StepLevel;
                                c.m_ExceptClasses = sample.m_ExceptClasses;
                            });
                            //Main.Log("rank progression patched= " + ability.AssetGuid + " added class= " + myClass.Guid + " for ref= " + referenceClass.Guid);
                        }
                    }
                }
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
                if (p is null) {
                    return false;
                }

                // Optimization for a common success case.
                if (ReferenceEquals(this, p)) {
                    return true;
                }

                // If run-time types are not exactly the same, return false.
                if (GetType() != GetType()) {
                    return false;
                }

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

        internal class FeatureOnLevelReference {
            public int level;
            public BlueprintFeatureReference value;
            public FeatureOnLevelReference(int inLevel, BlueprintFeatureReference inValue) {
                level = inLevel;
                value = inValue;
            }
            public override bool Equals(object p) {
                if (p is null) {
                    return false;
                }

                // Optimization for a common success case.
                if (ReferenceEquals(this, p)) {
                    return true;
                }

                // If run-time types are not exactly the same, return false.
                if (GetType() != GetType()) {
                    return false;
                }

                // Return true if the fields match.
                // Note that the base class is not invoked because it is
                // System.Object, which defines Equals as reference equality.
                return value.Guid.ToString() == ((FeatureOnLevelReference)p).value.Guid.ToString();
            }
            public static bool operator ==(FeatureOnLevelReference left, FeatureOnLevelReference right) {
                if (left is null && right is null) return true;
                if (left is not null) return left.Equals(right);
                return false;
            }
            public static bool operator !=(FeatureOnLevelReference left, FeatureOnLevelReference right) { return !(left == right); }
            public override int GetHashCode() => value.GetHashCode();
        }

        internal static class Strings {
            public static readonly LocalizedString Null = new();

            public static class Duration {
                public static readonly LocalizedString OneDay = new() { m_Key = "b2581d37-9b43-4473-a755-f675929feaa2" };
                public static readonly LocalizedString OneMinute = new() { m_Key = "70e2c2f0-b2c6-423a-b6ec-c05084530366" };
                public static readonly LocalizedString OneMinutePerLevel = new() { m_Key = "00b2e4c2-aafe-487b-b890-d57473373da7" };
                public static readonly LocalizedString OneRoundPerLevel = new() { m_Key = "6250ccf0-1ed0-460f-8ce7-094c2da7e198" };
                public static readonly LocalizedString UntilTargetOfSmiteIsDead = new() { m_Key = "cd623bdb-7aa6-43d2-afdc-865357596efb" };
            }

            public static class SavingThrow {
                public static readonly LocalizedString FortitudeNegates = new() { m_Key = "c8ec9dfb-37ba-485d-8c08-c45a6bfc88f3" };
                public static readonly LocalizedString FortitudePartial = new() { m_Key = "af1a01bb-3924-4663-94e8-79e080287aaa" };
                public static readonly LocalizedString WillNegates = new() { m_Key = "7ac9f1bb-ab14-4d64-8543-4c97a64a71bd" };
                public static readonly LocalizedString WillNegatesSaveEachRound = new() { m_Key = "50f1639f-a789-4939-bab6-557375828c4d" };
            }

            public static class ReplaceSpellbookDescription {
                public static readonly LocalizedString Loremaster = new() { m_Key = "c213f6d4-9760-4939-a9fe-9d34f9747240" };
                public static readonly LocalizedString HellknightSignifier = new() { m_Key = "eb71d1c5-c890-4c44-8790-2fb8c3621e55" };
                public static readonly LocalizedString ArcaneTrickster = new() { m_Key = "bf9c1e4a-5753-4705-9617-1a54ac291dfc" };
                public static readonly LocalizedString MysticTheurgeArcane = new() { m_Key = "296a19d9-bc24-47fd-a608-ba1aad556b9c" };
                public static readonly LocalizedString MysticTheurgeDivine = new() { m_Key = "801d1633-efa1-4ed2-83d1-337231705ae7" };
                public static readonly LocalizedString DragonDisciple = new() { m_Key = "9a186e08-9d9e-4dfb-98b9-d35127bad905" };
                public static readonly LocalizedString EldritchKnight = new() { m_Key = "cf828ba6-8a11-48b0-aa36-2d7972b51a5f" };
                public static readonly LocalizedString WinterWitch = new() { m_Key = "591fbec8-dac1-4198-9a1b-ae7921635af0" };
            }
        }

        internal static class Proficiencies {
            public static readonly BlueprintFeature LightArmorProficiency = BlueprintTools.GetBlueprint<BlueprintFeature>("6d3728d4e9c9898458fe5e9532951132");
            public static readonly BlueprintFeature MediumArmorProficiency = BlueprintTools.GetBlueprint<BlueprintFeature>("46f4fb320f35704488ba3d513397789d");
            public static readonly BlueprintFeature HeavyArmorProficiency = BlueprintTools.GetBlueprint<BlueprintFeature>("1b0f68188dcc435429fb87a022239681");
            public static readonly BlueprintFeature SimpleWeaponProficiency = BlueprintTools.GetBlueprint<BlueprintFeature>("e70ecf1ed95ca2f40b754f1adb22bbdd");
            public static readonly BlueprintFeature MartialWeaponProficiency = BlueprintTools.GetBlueprint<BlueprintFeature>("203992ef5b35c864390b4e4a1e200629");
            public static readonly BlueprintFeature ShieldsProficiency = BlueprintTools.GetBlueprint<BlueprintFeature>("cb8686e7357a68c42bdd9d4e65334633");
            public static readonly BlueprintFeature TowerShieldProficiency = BlueprintTools.GetBlueprint<BlueprintFeature>("6105f450bb2acbd458d277e71e19d835");
            public static BlueprintFeature ExoticWeaponProficiency => BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "ExoticWeaponProficiency");
        }
    }
}
