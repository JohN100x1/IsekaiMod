using HarmonyLib;
using IsekaiMod.Content.Classes.IsekaiProtagonist;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.Dungeon.Blueprints;
using Kingmaker.UI.MVVM._PCView.Rest;
using Kingmaker.UnitLogic.FactLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Utilities {

    public class StaticReferences {
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

        //Tactician
        public static BlueprintFeature Teamwork = BlueprintTools.GetBlueprint<BlueprintFeature>("01046afc774beee48abde8e35da0f4ba");
        public static BlueprintFeature AnimalTeamwork = BlueprintTools.GetBlueprint<BlueprintFeature>("1b9916f7675d6ef4fb427081250d49de");
        public static BlueprintFeature SummonTactics = BlueprintTools.GetBlueprint<BlueprintFeature>("c3abcce19f9f80640a867c9e75f880b2");
        public static BlueprintFeature SoloTactics = BlueprintTools.GetBlueprint<BlueprintFeature>("87d6de4d30adc7244b7a3427d041dcaa");
        public static BlueprintFeature ForesterTactics = BlueprintTools.GetBlueprint<BlueprintFeature>("994db4abfa0d6194eb3c847605e6f148");

        //bard
        public static BlueprintAbilityResource BardPerformResource = BlueprintTools.GetBlueprint<BlueprintAbilityResource>("e190ba276831b5c4fa28737e5e49e6a6");
        public static BlueprintFeature BardInspireCourage = BlueprintTools.GetBlueprint<BlueprintFeature>("acb4df34b25ca9043a6aba1a4c92bc69");
        public static BlueprintFeature BardInspireCompetence = BlueprintTools.GetBlueprint<BlueprintFeature>("6d3fcfab6d935754c918eb0e004b5ef7");
        public static BlueprintFeature BardInspireGreatness = BlueprintTools.GetBlueprint<BlueprintFeature>("9ae0f32c72f8df84dab023d1b34641dc");
        public static BlueprintFeature BardInspireHeroics = BlueprintTools.GetBlueprint<BlueprintFeature>("199d6fa0de149d044a8ab622a542cc79");
        public static BlueprintFeature BardWellVersed = BlueprintTools.GetBlueprint<BlueprintFeature>("8f4060852a4c8604290037365155662f");
        public static BlueprintFeature BardFascinate = BlueprintTools.GetBlueprint<BlueprintFeature>("ddaec3a5845bc7d4191792529b687d65");
        public static BlueprintFeature BardMove = BlueprintTools.GetBlueprint<BlueprintFeature>("36931765983e96d4bb07ce7844cd897e");
        public static BlueprintFeature BardSwift = BlueprintTools.GetBlueprint<BlueprintFeature>("fd4ec50bc895a614194df6b9232004b9");

        //barbarian
        public static BlueprintAbilityResource BarbarianRageResource = BlueprintTools.GetBlueprint<BlueprintAbilityResource>("24353fcf8096ea54684a72bf58dedbc9");
        public static BlueprintFeature BarbarianRage = BlueprintTools.GetBlueprint<BlueprintFeature>("2479395977cfeeb46b482bc3385f4647");
        public static BlueprintFeature BarbarianRageGreater = BlueprintTools.GetBlueprint<BlueprintFeature>("ce49c579fe0bcc647a32c96929fae982");
        public static BlueprintFeature BarbarianRageTireless = BlueprintTools.GetBlueprint<BlueprintFeature>("ca9343d75a83a2745a22fa11c383153a");
        public static BlueprintFeature BarbarianRagePower = BlueprintTools.GetBlueprint<BlueprintFeature>("28710502f46848d48b3f0d6132817c4e");
        public static BlueprintFeature BarbarianDamageReduction = BlueprintTools.GetBlueprint<BlueprintFeature>("cffb5cddefab30140ac133699d52a8f8");

        public static void PatchClassIntoFeatureOfReferenceClass(BlueprintFeature feature, BlueprintCharacterClassReference myClass, BlueprintCharacterClassReference referenceClass, int level) {
            level = level++;
            if (level > 20) {
                IsekaiContext.Logger.LogError("Attempt to patch Progression Tree stopped at Level 20 to prevent endless loop, if you see this message please report so we can figure out if someone created a loop here or if this limit needs to be higher");
                return;
            }
            if (feature == null || myClass == null || referenceClass == null) {
                IsekaiContext.Logger.LogError("Call to add feature but one of the three parameters is null");
                return;
            }
            if (feature is BlueprintProgression progression) {
                progression.GiveFeaturesForPreviousLevels = true;
                progression.AddClass(myClass);
                foreach (LevelEntry item in progression.LevelEntries) {
                    foreach (var levelitem in item.Features) {
                        if (levelitem is BlueprintProgression progression2) {
                            PatchClassIntoFeatureOfReferenceClass(progression2, myClass, referenceClass, level);
                        } else {
                            if (levelitem is BlueprintFeature feature2) {
                                PatchClassIntoFeatureOfReferenceClass(feature2, myClass, referenceClass, level);
                            }
                        }
                    }

                }
            }
            if (feature is BlueprintFeatureSelection selection) {
                foreach (var feature2 in selection.m_AllFeatures) {
                    PatchClassIntoFeatureOfReferenceClass(feature2, myClass, referenceClass, level);
                }
            }
            //components is null for BlueprintProgressions despite the fact that they implement Blueprintfeature, that will cause a nullpointer,
            //and since the cast to Blueptintfeature will work since it "supposedly" implements it checking if the field is null is the safest solution
            if (feature.Components != null) {
                var mySpellSet = new HashSet<SpellReference>();
                foreach (var component in feature.Components) {
                    //check if component is addSpell
                    if (component is AddKnownSpell asSpell) {
                        //don't re add spells already added for my class
                        if (asSpell.m_CharacterClass != myClass) {
                            mySpellSet.Add(new SpellReference(asSpell.SpellLevel, asSpell.m_Spell));
                        }
                    }
                    //check if component is AddFeature
                    if (component is AddFeatureOnClassLevel asFeat) {
                        PatchClassIntoFeatureOfReferenceClass(asFeat.m_Feature.Get(), myClass, referenceClass, level);
                        //only add our class as an additional class if the original entry was not valid for all classes but was restricted to the correct base class
                        if (asFeat.m_Class != null && asFeat.m_Class == referenceClass
                            && (asFeat.m_AdditionalClasses == null || !asFeat.m_AdditionalClasses.Contains<BlueprintCharacterClassReference>(myClass))) {
                            asFeat.m_AdditionalClasses.AddItem(myClass);
                        }
                    }
                }
                foreach (var spellReference in mySpellSet) {
                    feature.AddComponent<AddKnownSpell>(c => {
                        c.m_Spell = spellReference.value;
                        c.SpellLevel = spellReference.level;
                        c.m_CharacterClass = myClass;

                    });
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


}
