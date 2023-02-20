using HarmonyLib;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Utility;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Deities {
    internal class IsekaiDeitySelection {
        private static BlueprintFeatureSelection DeitySelection = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("59e7a76987fe3b547b9cce045f4db3e4");
        public static void Add() {
            // Isekai Background Selection
            var IsekaiDeitySelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "IsekaiDeitySelection", bp => {
                bp.SetName(IsekaiContext, "Isekai");
                bp.SetDescription(IsekaiContext, "Gods from another world.");
                bp.m_Icon = null;
                bp.m_AllFeatures = new BlueprintFeatureReference[] { }; // Added upon blueprint creation
                bp.Groups = new FeatureGroup[] { FeatureGroup.Deities };
                bp.Group = FeatureGroup.Deities;
            });

            // Add to Deity Selection
            
            DeitySelection.AddFeatures(IsekaiDeitySelection);
        }

        /** wasn't us that broke it but I am adding the patch here anyway 
         * because one of my other mods seriously messed with this and created a recursion that adds the selection to itself and every subselection and it is really irritating because of bloating,
         * so we might as well be the good guys and fix it for them */
        public static void PatchDeitySelection() {       
            
            var myDeityList = new Dictionary<int, HashSet<BlueprintFeatureSelection>>();
            var levelList = new HashSet<BlueprintFeatureSelection>();
            levelList.Add(DeitySelection);
            myDeityList.Add(1,levelList);
            var knownDeities = new HashSet<BlueprintFeature>();
            FlattenSelection(myDeityList, knownDeities, 1);
            
            //if (IsekaiContext.AddedContent.Deities.IsDisabled("Isekai Deities")) return;
            //any potential god patches that are not the above bugfix should go here, after commenting the if clause in
        }
        private static bool isKnownSelection(BlueprintFeatureSelection selection, Dictionary<int, HashSet<BlueprintFeatureSelection>> knownselections) {
            foreach (var key in knownselections.Keys) {
                foreach (var checkselection in knownselections.Get(key)) { if (checkselection.AssetGuid == selection.AssetGuid) { return true; } }
            }
            return false;
        }

        private static void FlattenSelection(Dictionary<int, HashSet<BlueprintFeatureSelection>> knownselections, HashSet<BlueprintFeature> knownDeities, int level) {
            var currentLevel = knownselections.Get(level);
            var nextLevel = new HashSet<BlueprintFeatureSelection>();
            foreach (var selection in currentLevel) {
                foreach (var item in selection.m_AllFeatures) {
                    var unRef = item.Get();
                    if (unRef != null) {
                        if (unRef is BlueprintFeatureSelection selection2) {
                            if (isKnownSelection(selection2, knownselections)) {
                                //IsekaiContext.Logger.Log("Duplicate Deity Selection=" + unRef.AssetGuid);
                                selection.RemoveFeatures(selection2);
                            } else {
                                nextLevel.Add(selection2);
                            }

                        } else {
                            if (knownDeities.Contains(unRef)) {
                                //IsekaiContext.Logger.Log("Duplicate Deity Entry=" + unRef.AssetGuid);
                                selection.RemoveFeatures(unRef);
                            } else {
                                knownDeities.Add(unRef);
                            }
                        }
                    } else {
                        IsekaiContext.Logger.Log("Null Value in selection of="+selection.AssetGuid);
                    }
                }
            }
            if (nextLevel.Count == 0) { 
                return; 
            }
            level++;
            if (level > 10) {
                IsekaiContext.Logger.LogError("Deity List Patching has reached 10 levels of depth, emergency aborting attempt to fix the levels, even with recursion this should not be possible unless someone purposfully fucked with the deity list, please doublecheck ingame");
                return;
            }
            knownselections.Add(level,nextLevel);
            FlattenSelection(knownselections, knownDeities, level);
        }

        public static void AddToSelection(BlueprintFeature deityFeature) {
            var IsekaiDeitySelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "IsekaiDeitySelection");
            IsekaiDeitySelection.m_AllFeatures = IsekaiDeitySelection.m_AllFeatures.AddToArray(deityFeature.ToReference<BlueprintFeatureReference>());
        }
    }
}