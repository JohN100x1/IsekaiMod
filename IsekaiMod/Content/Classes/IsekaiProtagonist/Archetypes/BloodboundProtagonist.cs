using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.UnitLogic.FactLogic;
using System;
using System.Collections.Generic;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Classes.IsekaiProtagonist.Archetypes {
    internal class BloodboundProtagonist {
        public static readonly BlueprintFeatureSelection BloodlineSelection = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("24bef8d1bee12274686f6da6ccbc8914");
        public static readonly BlueprintFeatureSelection FeatSelection = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("d6dd06f454b34014ab0903cb1ed2ade3");

        public static void Add() {
            //Added Feature
            ExtraBloodlineSelection.Configure();
            var ExtraSelection = ExtraBloodlineSelection.Get();


            // Removed features
            var SneakAttack = BlueprintTools.GetBlueprint<BlueprintFeature>("9b9eac6709e1c084cb18c3a366e0ec87");

            // Archetype
            var myArchetype = Helpers.CreateBlueprint<BlueprintArchetype>(IsekaiContext, "IsekaiSorcererArchetype", bp => {
                bp.LocalizedName = Helpers.CreateString(IsekaiContext, "IsekaiSorcererArchetype.Name", "Chimera");
                bp.LocalizedDescription = Helpers.CreateString(IsekaiContext, "IsekaiSorcererArchetype.Description", "Their otherworldly knowledge and point of view allows Chimeras to imbue themselves with different bloodlines in order to gain power and strength. \nThe Chimera is constantly seeking out new sources of power, and their ability to absorb and incorporate these different bloodlines allows them to become truly formidable foes. \nHowever, their constant experimentation with bloodlines can also lead to confusion and uncertainty about their own heritage and identity, as their original ancestry becomes harder to discern over time.");
                bp.LocalizedDescriptionShort = bp.LocalizedDescription;
                bp.RemoveFeatures = new LevelEntry[] {
                    Helpers.CreateLevelEntry(1, SneakAttack),
                    Helpers.CreateLevelEntry(5, SneakAttack),
                    Helpers.CreateLevelEntry(9, SneakAttack),
                    Helpers.CreateLevelEntry(13, SneakAttack),
                    Helpers.CreateLevelEntry(17, SneakAttack),
                };
                bp.AddFeatures = new LevelEntry[] {
                    Helpers.CreateLevelEntry(1, BloodlineSelection),
                    Helpers.CreateLevelEntry(5, ExtraSelection),
                    Helpers.CreateLevelEntry(9, ExtraSelection),
                    Helpers.CreateLevelEntry(13, ExtraSelection),
                    Helpers.CreateLevelEntry(18, ExtraSelection),


                };
                bp.OverrideAttributeRecommendations = true;
                bp.IsDivineCaster = true;
                bp.IsArcaneCaster= true;
                bp.RecommendedAttributes = new StatType[] { StatType.Charisma };
            });

            // Add Archetype to Class
            IsekaiProtagonistClass.RegisterArchetype(myArchetype);
        }
        public static BlueprintArchetype Get() {
            return BlueprintTools.GetModBlueprint<BlueprintArchetype>(IsekaiContext, "IsekaiSorcererArchetype");
        }
        public static BlueprintArchetypeReference GetReference() {
            return Get().ToReference<BlueprintArchetypeReference>();
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
                if (Object.ReferenceEquals(this, p)) {
                    return true;
                }

                // If run-time types are not exactly the same, return false.
                if (this.GetType() != p.GetType()) {
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

        /**
         * Patching the spellbook requires both the archetype and the class as a reference, technically just the class would be enough but then it is not limited to the archetype, 
         * so for multi class characters the other class would get it too, this differs from progression were you can enter just an archetype or just a class
         */
        public static void PatchArchetypeIntoBloodlineSelection(BlueprintArchetype myArchetype, BlueprintCharacterClass myClass) {
            IsekaiContext.Logger.Log("trying to patch bloodlines:");
            foreach (BlueprintProgression prog in BloodlineSelection.m_AllFeatures) {
                prog.AddArchetype(myArchetype);
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
                                    c.m_CharacterClass = myClass.ToReference<BlueprintCharacterClassReference>();
                                    
                                });
                            }
                        }

                    }
                }
            }
        }
    }

    internal class ExtraBloodlineSelection {
        public static void Configure() {
            var IsekaiBloodlineSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "IsekaiBloodlineSelection", bp => {
                bp.SetName(IsekaiContext, "Bloodline");
                bp.SetDescription(IsekaiContext, "You can pick additional bloodlines as your chimera blood becomes stronger.");
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.Group = FeatureGroup.BloodLine;
                bp.m_AllFeatures = BloodboundProtagonist.BloodlineSelection.m_AllFeatures;
            });
            var IsekaiSorcererSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "IsekaiSorcererSelection", bp => {
                bp.SetName(IsekaiContext, "Bloodline Evolution");
                bp.SetDescription(IsekaiContext, "As your chimera blood evolves you can pick a new bloodline feat or a new bloodline.");
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.Group = FeatureGroup.BloodLine;
                bp.m_AllFeatures = new BlueprintFeatureReference[] { IsekaiBloodlineSelection.ToReference<BlueprintFeatureReference>(), BloodboundProtagonist.FeatSelection.ToReference<BlueprintFeatureReference>(), BlueprintTools.GetModBlueprintReference<BlueprintFeatureReference>(IsekaiContext, "IsekaiProtagonistArcana") };
            });

        }
        public static BlueprintFeatureSelection Get() {
            return BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "IsekaiSorcererSelection");
        }
        public static BlueprintFeatureReference GetReference() {
            return Get().ToReference<BlueprintFeatureReference>();
        }
    }
}
