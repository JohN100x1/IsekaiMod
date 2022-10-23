using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;

namespace IsekaiMod.Changes.Features.IsekaiProtagonist.Backstory
{
    class BackstorySelection
    {
        public static void Add()
        {
            // Backstories
            var HopelessBackstory = Resources.GetModBlueprint<BlueprintFeature>("HopelessBackstory");
            var TragicBackstory = Resources.GetModBlueprint<BlueprintFeature>("TragicBackstory");
            var PainfulBackstory = Resources.GetModBlueprint<BlueprintFeature>("PainfulBackstory");
            var VengefulBackstory = Resources.GetModBlueprint<BlueprintFeature>("VengefulBackstory");
            var ForsakenBackstory = Resources.GetModBlueprint<BlueprintFeature>("ForsakenBackstory");

            // Backstory Selection
            var Icon_Backstory = AssetLoader.LoadInternal("Features", "ICON_BACKSTORY.png");
            var BackstorySelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>("BackstorySelection", bp => {
                bp.SetName("Backstory");
                bp.SetDescription("At 1st level, you get to select a backstory. These will develop over time as you increase your level.");
                bp.m_Icon = Icon_Backstory;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.m_AllFeatures = new BlueprintFeatureReference[] {
                    HopelessBackstory.ToReference<BlueprintFeatureReference>(),
                    TragicBackstory.ToReference<BlueprintFeatureReference>(),
                    PainfulBackstory.ToReference<BlueprintFeatureReference>(),
                    VengefulBackstory.ToReference<BlueprintFeatureReference>(),
                    ForsakenBackstory.ToReference<BlueprintFeatureReference>(),
                };
                bp.m_Features = new BlueprintFeatureReference[] {
                    HopelessBackstory.ToReference<BlueprintFeatureReference>(),
                    TragicBackstory.ToReference<BlueprintFeatureReference>(),
                    PainfulBackstory.ToReference<BlueprintFeatureReference>(),
                    VengefulBackstory.ToReference<BlueprintFeatureReference>(),
                    ForsakenBackstory.ToReference<BlueprintFeatureReference>(),
                };
            });
        }
    }
}
