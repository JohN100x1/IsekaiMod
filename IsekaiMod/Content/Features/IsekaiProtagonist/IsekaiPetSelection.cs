using HarmonyLib;
using IsekaiMod.Content.Classes.IsekaiProtagonist;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using TabletopTweaks.Core.Utilities;
using UnityEngine;
using static IsekaiMod.Main;
using static Kingmaker.Blueprints.Classes.BlueprintProgression;

namespace IsekaiMod.Content.Features.IsekaiProtagonist {

    internal class IsekaiPetSelection {
        private static readonly Sprite Icon_FriendToAnimals = BlueprintTools.GetBlueprint<BlueprintFeature>("9a56368c28795544fbeb43fe70e1a40d").m_Icon;
        private static readonly BlueprintFeatureSelection AnimalCompanionSelectionDomain = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("2ecd6c64683b59944a7fe544033bb533");
        private static readonly BlueprintFeatureSelection WitchFamiliarSelection = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("29a333b7ccad3214ea3a51943fa0d8e9");

        public static void Add() {
            var IsekaiNoPetFeature = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "IsekaiNoPetFeature", bp => {
                bp.SetName(IsekaiContext, "None");
                bp.SetDescription(IsekaiContext, "Only a true edgelord would choose to walk alone.");
                bp.IsClassFeature = true;
                bp.Ranks = 1;
            });
            var IsekaiFamiliarSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "IsekaiFamiliarSelection", bp => {
                bp.SetName(IsekaiContext, "Familiar Selection");
                bp.SetDescription(IsekaiContext, "You gain the service of a familiar, which offers you some skill bonuses.");
                bp.m_Icon = Icon_FriendToAnimals;
                bp.IsClassFeature = true;
                bp.Ranks = 1;
                bp.m_AllFeatures = WitchFamiliarSelection.m_AllFeatures;
            });
            var IsekaiPetSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "IsekaiPetSelection", bp => {
                bp.SetName(IsekaiContext, "Pet Selection");
                bp.SetDescription(IsekaiContext, "At 1st level, you gain the service of either an animal companion or familiar, using your class level as your effective druid level.");
                bp.m_Icon = Icon_FriendToAnimals;
                bp.IsClassFeature = true;
                bp.Ranks = 1;
                bp.m_AllFeatures = new BlueprintFeatureReference[] {
                    AnimalCompanionSelectionDomain.ToReference<BlueprintFeatureReference>(),
                    IsekaiFamiliarSelection.ToReference<BlueprintFeatureReference>(),
                };
                bp.m_Features = new BlueprintFeatureReference[] {
                    AnimalCompanionSelectionDomain.ToReference<BlueprintFeatureReference>(),
                    IsekaiFamiliarSelection.ToReference<BlueprintFeatureReference>(),
                };
            });

            PatchDomainAnimalProgression();
        }

        public static void AddToSelection(BlueprintFeature feature) {
            var IsekaiPetSelection = Get();
            IsekaiPetSelection.m_AllFeatures = IsekaiPetSelection.m_AllFeatures.AddToArray(feature.ToReference<BlueprintFeatureReference>());
            IsekaiPetSelection.m_Features = IsekaiPetSelection.m_Features.AddToArray(feature.ToReference<BlueprintFeatureReference>());
        }

        public static BlueprintFeatureSelection Get() {
            return BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "IsekaiPetSelection");
        }

        public static void PatchDomainAnimalProgression() {
            var DomainAnimalProgression = BlueprintTools.GetBlueprint<BlueprintProgression>("125af359f8bc9a145968b5d8fd8159b8");
            DomainAnimalProgression.m_Classes = DomainAnimalProgression.m_Classes.AddToArray(
                new ClassWithLevel() {
                    m_Class = IsekaiProtagonistClass.GetReference(),
                    AdditionalLevel = 0
                });
        }
    }
}