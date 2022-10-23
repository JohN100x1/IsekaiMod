using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;

namespace IsekaiMod.Changes.Classes.IsekaiProtagonist.Archetypes
{
    class GodEmporer
    {
        public static void AddGodEmporer()
        {
            var IsekaiProtagonistClass = Resources.GetModBlueprint<BlueprintCharacterClass>("IsekaiProtagonistClass");
            var DarkAuraFeature = Resources.GetModBlueprint<BlueprintFeature>("DarkAuraFeature");
            var FriendlyAuraFeature = Resources.GetModBlueprint<BlueprintFeature>("FriendlyAuraFeature");

             var BackstorySelection = Resources.GetModBlueprint<BlueprintFeatureSelection>("BackstorySelection");
            var TrainingArcSelection = Resources.GetModBlueprint<BlueprintFeatureSelection>("TrainingArcSelection");
            var BeachEpisodeSelection = Resources.GetModBlueprint<BlueprintFeatureSelection>("BeachEpisodeSelection");
            var CharacterDevelopmentSelection1 = Resources.GetModBlueprint<BlueprintFeatureSelection>("CharacterDevelopmentSelection1");
            var CharacterDevelopmentSelection2 = Resources.GetModBlueprint<BlueprintFeatureSelection>("CharacterDevelopmentSelection2");
            var CharacterDevelopmentSelection3 = Resources.GetModBlueprint<BlueprintFeatureSelection>("CharacterDevelopmentSelection3");

            var GodEmporerArchetype = Helpers.CreateBlueprint<BlueprintArchetype>("GodEmporerArchetype", bp => {
                bp.LocalizedName = Helpers.CreateString($"GodEmporerArchetype.Name", "God Emporer");
                bp.LocalizedDescription = Helpers.CreateString($"GodEmporerArchetype.Description", "Drezen today. The whole of Golarion tomorrow.");
                bp.LocalizedDescriptionShort = Helpers.CreateString($"GodEmporerArchetype.Description", "Drezen today. The whole of Golarion tomorrow.");
                bp.RemoveSpellbook = false;
                bp.RemoveFeatures = new LevelEntry[] {
                    Helpers.LevelEntry(1, BackstorySelection),
                    Helpers.LevelEntry(4, TrainingArcSelection),
                    Helpers.LevelEntry(7, CharacterDevelopmentSelection1),
                    Helpers.LevelEntry(9, FriendlyAuraFeature),
                    Helpers.LevelEntry(10, BeachEpisodeSelection),
                    Helpers.LevelEntry(13, CharacterDevelopmentSelection2),
                    Helpers.LevelEntry(16, TrainingArcSelection),
                    Helpers.LevelEntry(19, CharacterDevelopmentSelection3),
                };
                bp.AddFeatures = new LevelEntry[] {
                    Helpers.LevelEntry(9, DarkAuraFeature),
                };
            });
            IsekaiProtagonistClass.m_Archetypes = IsekaiProtagonistClass.m_Archetypes.AppendToArray(GodEmporerArchetype.ToReference<BlueprintArchetypeReference>());
        }
    }
}
