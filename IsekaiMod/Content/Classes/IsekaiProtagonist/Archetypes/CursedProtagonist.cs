using IsekaiMod.Content.Feats;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.UnitLogic.FactLogic;
using System;
using System.Collections.Generic;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Classes.IsekaiProtagonist.Archetypes {
    internal class CursedProtagonist {
        internal static void Configure() {
            var OracleSelection = ExtraOracleSelection.Get();


            // Removed features
            var SneakAttack = BlueprintTools.GetBlueprint<BlueprintFeature>("9b9eac6709e1c084cb18c3a366e0ec87");

            // Archetype
            var myArchetype = Helpers.CreateBlueprint<BlueprintArchetype>(IsekaiContext, "IsekaiOracleArchetype", bp => {
                bp.LocalizedName = Helpers.CreateString(IsekaiContext, "IsekaiOracleArchetype.Name", "Seeker of Truth");
                bp.LocalizedDescription = Helpers.CreateString(IsekaiContext, "IsekaiOracleArchetype.Description", "Seekers of Truth are driven by a desire to uncover the secrets behind the fundamental forces of nature. \nBecause of their unique perspective as otherworlders, they are able to approach the world with a fresh and unbiased eye, allowing them to see beyond the surface of things and seek out the deeper truth behind the world around them. \nThey are driven by a desire to uncover the secrets of the world that would otherwise remain hidden, and are not satisfied with simply accepting things at face value. \nThis allows them to uncover the secrets of the world that are often only revealed to mortals through revelations.");
                bp.LocalizedDescriptionShort = bp.LocalizedDescription;
                bp.RemoveFeatures = new LevelEntry[] {
                    Helpers.CreateLevelEntry(1, SneakAttack),
                    Helpers.CreateLevelEntry(5, SneakAttack),
                    Helpers.CreateLevelEntry(9, SneakAttack),
                    Helpers.CreateLevelEntry(13, SneakAttack),
                    Helpers.CreateLevelEntry(17, SneakAttack),
                };
                bp.AddFeatures = new LevelEntry[] {
                    Helpers.CreateLevelEntry(1, StaticReferences.OracleCurseSelection, OracleSelection),
                Helpers.CreateLevelEntry(3, OracleSelection),
                Helpers.CreateLevelEntry(6, OracleSelection),
                Helpers.CreateLevelEntry(9, OracleSelection),
                Helpers.CreateLevelEntry(12, OracleSelection),
                Helpers.CreateLevelEntry(15, OracleSelection),
                Helpers.CreateLevelEntry(18, OracleSelection),


                };
                bp.OverrideAttributeRecommendations = true;
                bp.IsDivineCaster = true;
                bp.IsArcaneCaster = true;
                bp.RecommendedAttributes = new StatType[] { StatType.Charisma };
            });

            // Add Archetype to Class
            IsekaiProtagonistClass.RegisterArchetype(myArchetype);
        }

        internal static BlueprintArchetype Get() {
            return BlueprintTools.GetModBlueprint<BlueprintArchetype>(IsekaiContext, "IsekaiOracleArchetype");
        }

        internal static void PatchArchetypeIntoOracleSelection(BlueprintArchetype myArchetype, BlueprintCharacterClass myClass) {
            IsekaiContext.Logger.Log("trying to patch oracle features:");
            var myClassRef = myClass.ToReference<BlueprintCharacterClassReference>();
            foreach (BlueprintProgression prog in StaticReferences.OracleCurseSelection.m_AllFeatures) {
                prog.AddClass(myClass);
                //check all levelentries of the progression and their features
                foreach (var levelItem in prog.LevelEntries) {
                    foreach (var potentialFeature in levelItem.m_Features) {
                        if (potentialFeature.Get() is BlueprintFeature feature) {
                            var mySet = new HashSet<SpellReference>();
                            foreach (var component in feature.Components) {
                                //if so are any of its components adding known spells
                                if (component is AddKnownSpell asSpell) {
                                    //don't re add spells already added for my archetype
                                    if (asSpell.Archetype == null || asSpell.Archetype != myArchetype) {
                                        mySet.Add(new SpellReference(asSpell.SpellLevel, asSpell.m_Spell));
                                    }
                                }
                            }
                            foreach (var spellReference in mySet) {
                                feature.AddComponent<AddKnownSpell>(c => {
                                    c.m_Archetype = myArchetype.ToReference<BlueprintArchetypeReference>();
                                    c.m_Spell = spellReference.value;
                                    c.SpellLevel = spellReference.level;
                                    c.m_CharacterClass = myClassRef;

                                });
                            }
                        }

                    }
                }
            }
            foreach (BlueprintFeature mystery in StaticReferences.OracleMysterySelection.m_AllFeatures) {
                foreach (var component in mystery.Components) {
                    if (component is AddFeatureOnClassLevel levelFeature) {
                        //levelFeature.m_Archetypes = levelFeature.m_Archetypes.AppendToArray(myArchetype.ToReference<BlueprintArchetypeReference>());
                        levelFeature.m_AdditionalClasses = levelFeature.m_AdditionalClasses.AppendToArray(myClass.ToReference<BlueprintCharacterClassReference>());
                        BlueprintFeature addedFeature = levelFeature.m_Feature.Get();
                        var mySet = new HashSet<SpellReference>();
                        foreach (var featcomponent in addedFeature.Components) {
                            //if so are any of its components adding known spells
                            if (featcomponent is AddKnownSpell asSpell) {
                                //don't re add spells already added for my class
                                if (asSpell.Archetype == null || asSpell.Archetype != myArchetype) {
                                    mySet.Add(new SpellReference(asSpell.SpellLevel, asSpell.m_Spell));
                                }
                            }
                        }
                        foreach (var spellReference in mySet) {
                            addedFeature.AddComponent<AddKnownSpell>(c => {
                                c.m_Archetype = myArchetype.ToReference<BlueprintArchetypeReference>();
                                c.m_Spell = spellReference.value;
                                c.SpellLevel = spellReference.level;
                                c.m_CharacterClass = myClassRef;

                            });
                        }
                    }
                }
            }
            foreach (BlueprintFeature mystery in StaticReferences.OraclePositiveNegativeSelection.m_AllFeatures) {
                var mySet = new HashSet<SpellReference>();
                foreach (var component in mystery.Components) {
                    if (component is AddKnownSpell asSpell) {
                        if (asSpell.m_CharacterClass != myClassRef) {
                            mySet.Add(new SpellReference(asSpell.SpellLevel, asSpell.m_Spell));
                        }
                    }
                }
                foreach (var spellReference in mySet) {
                    mystery.AddComponent<AddKnownSpell>(c => {
                        c.m_Spell = spellReference.value;
                        c.SpellLevel = spellReference.level;
                        c.m_CharacterClass = myClassRef;

                    });
                }
            }
        }
    }
    internal class ExtraOracleSelection {
        public static void Configure() {

            var CurseSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "IsekaiOracleCurseSelection", bp => {
                bp.SetName(IsekaiContext, "Divine Curse");
                bp.SetDescription(IsekaiContext, "Gain a curse, but some curses are blessings in disguise.");
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.m_AllFeatures = StaticReferences.OracleCurseSelection.m_AllFeatures;
            });
            var MysterySelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "IsekaiOracleMysterySelection", bp => {
                bp.SetName(IsekaiContext, "Divine Mystery");
                bp.SetDescription(IsekaiContext, "Master another part of reality...");
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.m_AllFeatures = StaticReferences.OracleMysterySelection.m_AllFeatures;
            });

            var PrimarySelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "IsekaiOracleSelection", bp => {
                bp.SetName(IsekaiContext, "Divine Inheritance");
                bp.SetDescription(IsekaiContext, "As you get closer and closer to the truth of divinity you gain a new Mystery, Revelation, or perhaps a curse from a jealous god?");
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.m_AllFeatures = new BlueprintFeatureReference[] {
                    CurseSelection.ToReference<BlueprintFeatureReference>(),
                    MysterySelection.ToReference<BlueprintFeatureReference>(),
                    StaticReferences.OracleRevelationSelection.ToReference<BlueprintFeatureReference>(),
                    StaticReferences.OraclePositiveNegativeSelection.ToReference<BlueprintFeatureReference>()
                };
            });

        }
        public static BlueprintFeatureSelection Get() {
            return BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "IsekaiOracleSelection");
        }
        public static BlueprintFeatureReference GetReference() {
            return Get().ToReference<BlueprintFeatureReference>();
        }
    }
}
