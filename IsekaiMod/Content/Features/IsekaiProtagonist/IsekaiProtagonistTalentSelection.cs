using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;

namespace IsekaiMod.Content.Features.IsekaiProtagonist
{
    class IsekaiProtagonistTalentSelection
    {
        public static void Add()
        {
            // Rogure talents
            var CripplingStrike = Resources.GetBlueprint<BlueprintFeature>("b696bd7cb38da194fa3404032483d1db");
            var DispellingAttack = Resources.GetBlueprint<BlueprintFeature>("1b92146b8a9830d4bb97ab694335fa7c");
            var ConfoundingBlades = Resources.GetBlueprint<BlueprintFeature>("ce72662a812b1f242849417b2c784b5e");

            var Opportunist = Resources.GetBlueprint<BlueprintFeature>("5bb6dc5ce00550441880a6ff8ad4c968");
            var FastStealth = Resources.GetBlueprint<BlueprintFeature>("97a6aa2b64dd21a4fac67658a91067d7");
            var FocusingAttackConfused = Resources.GetBlueprint<BlueprintFeature>("955ff81c596c1c3489406d03e81e6087");
            var FocusingAttackShaken = Resources.GetBlueprint<BlueprintFeature>("791f50e199d069d4f8e933996a2ce054");
            var FocusingAttackSickened = Resources.GetBlueprint<BlueprintFeature>("79475c263e538c94f8e23907bd570a35");

            // Feature Selection
            var IsekaiProtagonistTalentSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>("IsekaiProtagonistTalentSelection", bp => {
                bp.SetName("Rogue Talents");
                bp.SetDescription("You can select a rogue talent from a limited set of rogue talents, ignoring any prerequisites for these talents.");
                bp.m_Icon = null;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.Group = FeatureGroup.RogueTalent;
                bp.Group2 = FeatureGroup.None;
                bp.IgnorePrerequisites = true;
                bp.m_AllFeatures = new BlueprintFeatureReference[] {
                    CripplingStrike.ToReference<BlueprintFeatureReference>(),
                    DispellingAttack.ToReference<BlueprintFeatureReference>(),
                    ConfoundingBlades.ToReference<BlueprintFeatureReference>(),
                    Opportunist.ToReference<BlueprintFeatureReference>(),
                    FastStealth.ToReference<BlueprintFeatureReference>(),
                    FocusingAttackConfused.ToReference<BlueprintFeatureReference>(),
                    FocusingAttackShaken.ToReference<BlueprintFeatureReference>(),
                    FocusingAttackSickened.ToReference<BlueprintFeatureReference>(),
                };
            });
        }
    }
}
