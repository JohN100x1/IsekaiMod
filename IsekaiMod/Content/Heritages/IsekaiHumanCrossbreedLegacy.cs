using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using System.Linq;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Heritages {
    internal class IsekaiHumanCrossbreedLegacy {
        private static BlueprintFeature ourHeritage;

        public static void Add() {
            ourHeritage = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiHumanCrossbreedLegacy", bp => {
                bp.SetName(IsekaiContext, "Isekai Crossbreed Human");
                bp.SetDescription(IsekaiContext,
                    "Let us be honest, there is a reason why for any mixed race classification it is always enough to name the non human options. \n" +
                    "Because generally it is simply save to assume that the other part of it will be human. \n" +
                    "There is no other race, except for dragons, that is as flexible when it comes to its choice of bed partners and none as flexible when it comes to being fertile when crossbreeding and realistically by now there are no true pure humans left because everyone is at least (1/2)^100 something else. \n" +
                    "And no matter how close to 0 that number is it is not 0 and for some reason in you all that blood became active in a way that allows you access to some of your ancestors powers.");


                bp.Groups = new FeatureGroup[0];
                bp.ReapplyOnLevelUp = true;
            });

            HumanHeritageSelection.Register(ourHeritage);
        }

        public static void Patch() {
            var races = new BlueprintFeatureReference[] {
                BlueprintTools.GetBlueprintReference<BlueprintFeatureReference>("b7f02ba92b363064fb873963bec275ee"),
                        BlueprintTools.GetBlueprintReference<BlueprintFeatureReference>("64e8b7d5f1ae91d45bbf1e56a3fdff01"),
                        BlueprintTools.GetBlueprintReference<BlueprintFeatureReference>("c4faf439f0e70bd40b5e36ee80d06be7"),
                        BlueprintTools.GetBlueprintReference<BlueprintFeatureReference>("25a5878d125338244896ebd3238226c8"),
                        BlueprintTools.GetBlueprintReference<BlueprintFeatureReference>("ef35a22c9a27da345a4528f0d5889157"),
                        BlueprintTools.GetBlueprintReference<BlueprintFeatureReference>("1dc20e195581a804890ddc74218bfd8e"),
                        BlueprintTools.GetBlueprintReference<BlueprintFeatureReference>("fd188bb7bb0002e49863aec93bfb9d99"),
                        BlueprintTools.GetBlueprintReference<BlueprintFeatureReference>("4d4555326b9b7144f93be1ea61337cd7"),
                        BlueprintTools.GetBlueprintReference<BlueprintFeatureReference>("5c4e42124dc2b4647af6e36cf2590500")
            }.ToList();
            if (ourHeritage != null) {
                foreach (var print in FeatTools.Selections.BasicFeatSelection.m_AllFeatures) {
                    if (print != null && print.Get() != null && print.Get() is BlueprintFeature feature) {
                        bool toPatch = false;
                        if (feature.Components != null && feature.Components.Length > 0) {
                            foreach (var component in feature.Components) {
                                if (component != null && component is PrerequisiteFeature prereq) {
                                    if (prereq.m_Feature != null && races.Contains(prereq.m_Feature)) {
                                        toPatch = true;
                                        if (prereq.Group.Equals(Prerequisite.GroupType.All)) {
                                            prereq.Group = Prerequisite.GroupType.Any;
                                        }
                                    }
                                }
                            }
                        }
                        if (toPatch) {
                            feature.AddComponent<PrerequisiteFeature>(c => {
                                c.Group = Prerequisite.GroupType.Any;
                                c.CheckInProgression = false;
                                c.HideInUI = false;
                                c.m_Feature = ourHeritage.ToReference<BlueprintFeatureReference>();
                            });
                        }

                    }
                }
            }

        }
    }
}
