using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.EntitySystem.Stats;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.CharacterDevelopment
{
    class SecondBackground
    {
        public static void Add()
        {
            var BackgroundSelection = Resources.GetBlueprint<BlueprintFeatureSelection>("f926dabeee7f8a54db8f2010b323383c");

            // Feature
            var SecondBackground = Helpers.CreateBlueprint<BlueprintFeatureSelection>("SecondBackground", bp => {
                bp.SetName("Second Background");
                bp.SetDescription("Your life is more lively and varied than most. You are able to select a second background.");
                bp.m_Icon = null;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.AddComponent<PrerequisiteIsPet>(c => {
                    c.Group = Prerequisite.GroupType.All;
                    c.CheckInProgression = true;
                    c.HideInUI = true;
                    c.Not = true;
                });
                bp.AddComponent<PrerequisiteStatValue>(c => {
                    c.Group = Prerequisite.GroupType.All;
                    c.CheckInProgression = true;
                    c.Stat = StatType.Intelligence;
                    c.Value = 3;
                });
                bp.HideInCharacterSheetAndLevelUp = true;
                bp.Mode = SelectionMode.Default;
                bp.Group = FeatureGroup.BackgroundSelection;
                bp.Group2 = FeatureGroup.None;
                bp.m_Features = new BlueprintFeatureReference[0];
                bp.m_AllFeatures = BackgroundSelection.m_AllFeatures;
                bp.ShowThisSelection = false;
            });

            // You can't select a third background
            SecondBackground.AddComponent<PrerequisiteNoFeature>(c => { c.m_Feature = SecondBackground.ToReference<BlueprintFeatureReference>(); });
        }
    }
}
