using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using System;
using TabletopTweaks.Core.Utilities;

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

        //Rogue
        public static BlueprintFeature RogueSneakAttack = BlueprintTools.GetBlueprint<BlueprintFeature>("9b9eac6709e1c084cb18c3a366e0ec87");
        public static BlueprintFeature RogueUncannyDodge = BlueprintTools.GetBlueprint<BlueprintFeature>("3c08d842e802c3e4eb19d15496145709");
        public static BlueprintFeature RogueImprovedUncannyDodge = BlueprintTools.GetBlueprint<BlueprintFeature>("485a18c05792521459c7d06c63128c79");
        public static BlueprintFeature RogueEvasion = BlueprintTools.GetBlueprint<BlueprintFeature>("576933720c440aa4d8d42b0c54b77e80");
        public static BlueprintFeature RogueImprovedEvasion = BlueprintTools.GetBlueprint<BlueprintFeature>("ce96af454a6137d47b9c6a1e02e66803");
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
}
