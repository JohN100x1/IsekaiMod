using HarmonyLib;
using IsekaiMod.Content.Classes.IsekaiProtagonist;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Facts;
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

        //Rogue
        public static BlueprintFeature RogueSneakAttack = BlueprintTools.GetBlueprint<BlueprintFeature>("9b9eac6709e1c084cb18c3a366e0ec87");
        public static BlueprintFeature RogueUncannyDodge = BlueprintTools.GetBlueprint<BlueprintFeature>("3c08d842e802c3e4eb19d15496145709");
        public static BlueprintFeature RogueImprovedUncannyDodge = BlueprintTools.GetBlueprint<BlueprintFeature>("485a18c05792521459c7d06c63128c79");
        public static BlueprintFeature RogueEvasion = BlueprintTools.GetBlueprint<BlueprintFeature>("576933720c440aa4d8d42b0c54b77e80");
        public static BlueprintFeature RogueImprovedEvasion = BlueprintTools.GetBlueprint<BlueprintFeature>("ce96af454a6137d47b9c6a1e02e66803");
        public static BlueprintFeatureSelection RogueTalentSelection = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("c074a5d615200494b8f2a9c845799d93");
        public static BlueprintFeature RogueAdvancedTalents = BlueprintTools.GetBlueprint<BlueprintFeature>("a33b99f95322d6741af83e9381b2391c");

        //Tactician
        public static BlueprintFeature Teamwork = BlueprintTools.GetBlueprint<BlueprintFeature>("01046afc774beee48abde8e35da0f4ba");
        public static BlueprintFeature AnimalTeamwork = BlueprintTools.GetBlueprint<BlueprintFeature>("1b9916f7675d6ef4fb427081250d49de");
        public static BlueprintFeature SummonTactics = BlueprintTools.GetBlueprint<BlueprintFeature>("c3abcce19f9f80640a867c9e75f880b2");
        public static BlueprintFeature SoloTactics = BlueprintTools.GetBlueprint<BlueprintFeature>("87d6de4d30adc7244b7a3427d041dcaa");
        public static BlueprintFeature ForesterTactics = BlueprintTools.GetBlueprint<BlueprintFeature>("994db4abfa0d6194eb3c847605e6f148");

        public static readonly BlueprintFeatureBase[] FeaturesIgnoredWhenPatching = new BlueprintFeatureBase[] { 
            FeatTools.Selections.BasicFeatSelection, 
            FeatTools.Selections.FighterFeatSelection, 
            FeatTools.Selections.CombatTrick, 
            FeatTools.Selections.SkaldFeatSelection,
            FeatTools.Selections.AnimalCompanionSelectionDomain,
            FeatTools.Selections.WarDomainGreaterFeatSelection
        };

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
                var addItems = referenceLevel.m_Features.ToArray() ;
                BlueprintFeatureBaseReference[] removed = new BlueprintFeatureBaseReference[] { };
                foreach (var candidate in refArchetype.RemoveFeatures) {
                    if(candidate.Level == referenceLevel.Level) {
                        removed = removed.AddRangeToArray(candidate.m_Features.ToArray());
                    }
                }
                foreach ( var feature in addItems) {
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
                    LevelEntry additionalFeatures= null;
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
                        if (refLevel.Level== level.Level) {
                            found = true;
                        }
                    }
                    if (!found) {
                        prog.LevelEntries = prog.LevelEntries.AddToArray(level);
                        foreach (var feature in level.m_Features) { if (!MissingUIGroup.Contains(feature)) { MissingUIGroup = MissingUIGroup.AddToArray(feature); } }
                    }
                }
            }
            if (MissingUIGroup.Length> 0) {
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

        public static void PatchClassIntoFeatureOfReferenceClass(BlueprintFeature feature, BlueprintCharacterClassReference myClass, BlueprintCharacterClassReference referenceClass, int level, BlueprintFeatureBase[] loopPrevention) {
            var mylevel = level+1;
            if (mylevel > 10) {
                IsekaiContext.Logger.LogError("Attempt to patch Progression Tree stopped at Level 10 to prevent endless loop, if you see this message please report so we can figure out if someone created a loop here or if this limit needs to be higher");
                if (feature.Name != null) {
                    IsekaiContext.Logger.LogError("reference class= "+ referenceClass.Guid+" Stop Feature= " + feature.AssetGuid + " name= " + feature.Name);
                    foreach(BlueprintFeatureBase calltrace in loopPrevention) {
                        IsekaiContext.Logger.LogError("guid= "+calltrace.AssetGuid);
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
                //these lists are to be ignored by definition because they are essentially the basic feat list granted by specific classes
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
                    foreach (LevelEntry item in progression.LevelEntries) {
                        foreach (var levelitem in item.Features) {
                            if (levelitem is BlueprintProgression progression2) {
                                PatchClassIntoFeatureOfReferenceClass(progression2, myClass, referenceClass, mylevel, loopPrevention);
                            } else {
                                if (levelitem is BlueprintFeature feature2) {
                                    PatchClassIntoFeatureOfReferenceClass(feature2, myClass, referenceClass, mylevel, loopPrevention);
                                }
                            }
                        }
                    }
                }
                if (feature is BlueprintFeatureSelection selection) {
                    foreach (var feature2 in selection.m_AllFeatures) {
                        PatchClassIntoFeatureOfReferenceClass(feature2, myClass, referenceClass, mylevel, loopPrevention);
                    }
                }
                //components is null for BlueprintProgressions despite the fact that they implement Blueprintfeature, that will cause a nullpointer,
                //and since the cast to Blueptintfeature will work since it "supposedly" implements it checking if the field is null is the safest solution
                if (feature.Components != null) {
                    var mySpellSet = new HashSet<SpellReference>();
                    foreach (var component in feature.Components) {
                        //check if component is addSpell or addFeat
                        HandleComponent(myClass, referenceClass, mylevel, mySpellSet, component, loopPrevention);
                    }
                    foreach (var spellReference in mySpellSet) {
                        feature.AddComponent<AddKnownSpell>(c => {
                            c.m_Spell = spellReference.value;
                            c.SpellLevel = spellReference.level;
                            c.m_CharacterClass = myClass;

                        });
                    }
                }
            } catch(NullReferenceException e)  {
                if (feature.Name != null) { 
                    IsekaiContext.Logger.LogError("Unpatachable Feature= " + feature.AssetGuid + "name= "+feature.Name+" at level= " + mylevel + " reason= " + e.Message); 
                } else { 
                    IsekaiContext.Logger.LogError("Unpatachable Feature= " + feature.AssetGuid + " at level= " + mylevel + " reason= " + e.Message); 
                }
            }
        }

        private static void HandleComponent(BlueprintCharacterClassReference myClass, BlueprintCharacterClassReference referenceClass, int level, HashSet<SpellReference> mySpellSet, BlueprintComponent component, BlueprintFeatureBase[] loopPrevention) {
            var mylevel = level+1;
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
            //check if component is AddFeature
            if (component is AddFeatureOnClassLevel asFeat) {
                PatchClassIntoFeatureOfReferenceClass(asFeat.m_Feature.Get(), myClass, referenceClass, mylevel, loopPrevention);
                //only add our class as an additional class if the original entry was not valid for all classes but was restricted to the correct base class
                if (asFeat.m_Class != null && asFeat.m_Class == referenceClass
                    && (asFeat.m_AdditionalClasses == null || !asFeat.m_AdditionalClasses.Contains(myClass))) {
                    asFeat.m_AdditionalClasses.AddItem(myClass);
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
                            if (component2 is ContextRankConfig rankConfig && rankConfig.m_BaseValueType == ContextRankBaseValueType.ClassLevel && rankConfig.m_Class.Contains(referenceClass)) {
                                sample = rankConfig;
                                bool classlocked = false;
                                
                                if (rankConfig.m_Class != null && rankConfig.m_Class.Length > 0) {
                                    if (rankConfig.m_Class.Contains(referenceClass)) {
                                        classlocked = true;
                                    }
                                    if (rankConfig.m_Class.Contains(myClass)) {
                                        alreadyPatched = true;
                                    }
                                }
                                if (classlocked && !alreadyPatched) {
                                    rankConfig.m_Class.AddItem(myClass);

                                    
                                }
                            } else {
                                if (component2 is ContextRankConfig rankConfig2 && rankConfig2.m_BaseValueType == ContextRankBaseValueType.ClassLevel && rankConfig2.m_Class.Contains(myClass)) {
                                    alreadyPatched = true;
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
                                c.m_CustomProgression= sample.m_CustomProgression;
                                c.m_Max = sample.m_Max;
                                c.m_Min = sample.m_Min;
                                c.m_Stat= sample.m_Stat;
                                c.m_StepLevel= sample.m_StepLevel;
                                c.m_ExceptClasses= sample.m_ExceptClasses;
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
                    if (res.m_MaxAmount.m_ClassDiv != null && res.m_MaxAmount.m_ClassDiv.Contains(referenceClass)) {
                        classlocked = true;
                    }
                    if (res.m_MaxAmount.m_ClassDiv != null && res.m_MaxAmount.m_ClassDiv.Contains(myClass)) {
                        alreadyPatched = true;
                    }
                    if (classlocked && !alreadyPatched) { 
                        res.m_MaxAmount.m_ClassDiv.AddItem(myClass); 
                        //Main.Log("class resource patched= " + resRef.Guid); 
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
                if (!(left is null)) {
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
                if (!(left is null)) {
                    return left.Equals(right);
                }
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
