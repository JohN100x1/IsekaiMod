using IsekaiMod.Content.Classes.IsekaiProtagonist;
using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using static Kingmaker.Blueprints.Classes.BlueprintProgression;

namespace IsekaiMod.Content.Features.IsekaiProtagonist
{
    class IsekaiPetSelection
    {
        public static void Add()
        {
            var Icon_FriendToAnimals = Resources.GetBlueprint<BlueprintFeature>("9a56368c28795544fbeb43fe70e1a40d").m_Icon;

            var AnimalCompanionSelectionDomain = Resources.GetBlueprint<BlueprintFeatureSelection>("2ecd6c64683b59944a7fe544033bb533");
            var WitchFamiliarSelection = Resources.GetBlueprint<BlueprintFeatureSelection>("29a333b7ccad3214ea3a51943fa0d8e9");

            var IsekaiFamiliarSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>("IsekaiFamiliarSelection", bp => {
                bp.SetName("Familiar Selection");
                bp.SetDescription("You gain the service of a familiar, which offers you some skill bonuses.");
                bp.m_Icon = Icon_FriendToAnimals;
                bp.IsClassFeature = true;
                bp.Ranks = 1;
                bp.m_AllFeatures = WitchFamiliarSelection.m_AllFeatures;
            });
            var IsekaiPetSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>("IsekaiPetSelection", bp => {
                bp.SetName("Pet Selection");
                bp.SetDescription("At 1st level, you gain the service of either an animal companion or familiar, using your class level as your effective druid level.");
                bp.m_Icon = Icon_FriendToAnimals;
                bp.IsClassFeature = true;
                bp.Ranks = 1;
                bp.m_AllFeatures = new BlueprintFeatureReference[] {
                    AnimalCompanionSelectionDomain.ToReference<BlueprintFeatureReference>(),
                    WitchFamiliarSelection.ToReference<BlueprintFeatureReference>(),
                };
                bp.m_Features = new BlueprintFeatureReference[] {
                    AnimalCompanionSelectionDomain.ToReference<BlueprintFeatureReference>(),
                    WitchFamiliarSelection.ToReference<BlueprintFeatureReference>(),
                };
            });

            // Fix Animal Companion Progression
            var DomainAnimalProgression = Resources.GetBlueprint<BlueprintProgression>("125af359f8bc9a145968b5d8fd8159b8");
            DomainAnimalProgression.m_Classes = DomainAnimalProgression.m_Classes.AddToArray(
                new ClassWithLevel() {
                    m_Class = IsekaiProtagonistClass.GetReference(),
                    AdditionalLevel = 0
                });
        }
    }
}
