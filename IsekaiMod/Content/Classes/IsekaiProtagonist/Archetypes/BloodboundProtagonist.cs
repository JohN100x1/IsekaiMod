using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Localization;
using Kingmaker.UnitLogic.FactLogic;
using System.Collections.Generic;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Classes.IsekaiProtagonist.Archetypes {
    internal class BloodboundProtagonist {
        public static readonly BlueprintFeatureSelection BloodlineSelection = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("24bef8d1bee12274686f6da6ccbc8914");
        public static readonly BlueprintFeatureSelection FeatSelection = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("d6dd06f454b34014ab0903cb1ed2ade3");

        public static void Add() {


            // Removed features
            var SneakAttack = BlueprintTools.GetBlueprint<BlueprintFeature>("9b9eac6709e1c084cb18c3a366e0ec87");

            // Archetype
            var myArchetype = Helpers.CreateBlueprint<BlueprintArchetype>(IsekaiContext, "IsekaiSorcererArchetype", bp => {
                bp.LocalizedName = Helpers.CreateString(IsekaiContext, $"IsekaiSorcererArchetype.Name", "Isekaid Sorcerer");
                bp.LocalizedDescription = Helpers.CreateString(IsekaiContext, $"IsekaiSorcererArchetype.Description", "When god asked you what you wanted the most as a starting cheat you immediatly knew what to ask for.\nAn epic bloodline worthy of the new you! \nI hope it is all you wished for.");
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
                    Helpers.CreateLevelEntry(7, FeatSelection),
                    Helpers.CreateLevelEntry(13, FeatSelection),
                    Helpers.CreateLevelEntry(19, FeatSelection),


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
            public bool Equals(SpellReference other) {
                return other != null && other.value.Guid.Equals(this.value.Guid);
            }
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
                                IsekaiContext.Logger.Log("patched spell= " + spellReference.value.Guid + " level= " + spellReference.level + " name= " + feature.Name);
                                
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
}
