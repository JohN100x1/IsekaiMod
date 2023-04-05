using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.GodEmperor {

    internal class GodEmperorAuraSelection {

        public static void Add() {
            var DarkAuraFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "DarkAuraFeature");
            var DivineAuraFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "DivineAuraFeature");

            var GodEmperorAuraSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "GodEmperorAuraSelection", bp => {
                bp.SetName(IsekaiContext, "God Emperor Aura");
                bp.SetDescription(IsekaiContext, "At 10th level, the God Emperor is able to choose an aura.");
                bp.m_Icon = DivineAuraFeature.m_Icon;
                bp.IgnorePrerequisites = true;
                bp.m_AllFeatures = new BlueprintFeatureReference[] {
                    DivineAuraFeature.ToReference<BlueprintFeatureReference>(),
                    DarkAuraFeature.ToReference<BlueprintFeatureReference>(),
                };
            });
        }
    }
}