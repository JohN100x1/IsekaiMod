using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;

namespace IsekaiMod.Changes.Classes.IsekaiProtagonist.Archetypes
{
    class GodEmporer
    {
        public static void Add()
        {
            // Archetype features
            var GodEmporerProficiencies = Resources.GetModBlueprint<BlueprintFeature>("GodEmporerProficiencies");
            var GodEmporerPlotArmor = Resources.GetModBlueprint<BlueprintFeature>("GodEmporerPlotArmor");
            var NascentApotheosis = Resources.GetModBlueprint<BlueprintFeature>("NascentApotheosis");
            var GodEmporerTraining = Resources.GetModBlueprint<BlueprintFeature>("GodEmporerTraining");
            var ProtectiveAuraFeature = Resources.GetModBlueprint<BlueprintFeature>("ProtectiveAuraFeature");
            var GodEmporerSignatureAttack = Resources.GetModBlueprint<BlueprintFeature>("GodEmporerSignatureAttack");
            var DarkAuraFeature = Resources.GetModBlueprint<BlueprintFeature>("DarkAuraFeature");
            var GloriousAuraFeature = Resources.GetModBlueprint<BlueprintFeature>("GloriousAuraFeature");
            var Invincible = Resources.GetModBlueprint<BlueprintFeature>("Invincible");
            var GodlyBody = Resources.GetModBlueprint<BlueprintFeature>("GodlyBody");

            // Removed features
            var IsekaiProtagonistProficiencies = Resources.GetModBlueprint<BlueprintFeature>("IsekaiProtagonistProficiencies");
            var PlotArmor = Resources.GetModBlueprint<BlueprintFeature>("PlotArmor");
            var IsekaiFighterTraining = Resources.GetModBlueprint<BlueprintFeature>("IsekaiFighterTraining");
            var SignatureAttack = Resources.GetModBlueprint<BlueprintFeature>("SignatureAttack");
            var FriendlyAuraFeature = Resources.GetModBlueprint<BlueprintFeature>("FriendlyAuraFeature");
            var OtherworldlyStamina = Resources.GetModBlueprint<BlueprintFeature>("OtherworldlyStamina");

            var BackstorySelection = Resources.GetModBlueprint<BlueprintFeatureSelection>("BackstorySelection");
            var TrainingArcSelection = Resources.GetModBlueprint<BlueprintFeatureSelection>("TrainingArcSelection");
            var BeachEpisodeSelection = Resources.GetModBlueprint<BlueprintFeatureSelection>("BeachEpisodeSelection");
            var CharacterDevelopmentSelection1 = Resources.GetModBlueprint<BlueprintFeatureSelection>("CharacterDevelopmentSelection1");
            var CharacterDevelopmentSelection2 = Resources.GetModBlueprint<BlueprintFeatureSelection>("CharacterDevelopmentSelection2");
            var CharacterDevelopmentSelection3 = Resources.GetModBlueprint<BlueprintFeatureSelection>("CharacterDevelopmentSelection3");

            // Archetype
            var GodEmporerArchetype = Helpers.CreateBlueprint<BlueprintArchetype>("GodEmporerArchetype", bp => {
                bp.LocalizedName = Helpers.CreateString($"GodEmporerArchetype.Name", "God Emporer");
                bp.LocalizedDescription = Helpers.CreateString($"GodEmporerArchetype.Description", "Drezen today. The whole of Golarion tomorrow.");
                bp.LocalizedDescriptionShort = Helpers.CreateString($"GodEmporerArchetype.Description", "Drezen today. The whole of Golarion tomorrow.");
                bp.RemoveSpellbook = false;
                bp.RemoveFeatures = new LevelEntry[] {
                    Helpers.LevelEntry(1, IsekaiProtagonistProficiencies, PlotArmor),
                    Helpers.LevelEntry(3, IsekaiFighterTraining),
                    Helpers.LevelEntry(4, TrainingArcSelection),
                    Helpers.LevelEntry(6, SignatureAttack),
                    Helpers.LevelEntry(7, CharacterDevelopmentSelection1),
                    Helpers.LevelEntry(9, FriendlyAuraFeature),
                    Helpers.LevelEntry(10, BeachEpisodeSelection),
                    Helpers.LevelEntry(13, CharacterDevelopmentSelection2),
                    Helpers.LevelEntry(15, OtherworldlyStamina),
                    Helpers.LevelEntry(16, TrainingArcSelection),
                    Helpers.LevelEntry(19, CharacterDevelopmentSelection3),
                };
                bp.AddFeatures = new LevelEntry[] {
                    Helpers.LevelEntry(1, GodEmporerProficiencies, GodEmporerPlotArmor),
                    Helpers.LevelEntry(3, NascentApotheosis),
                    Helpers.LevelEntry(4, GodEmporerTraining),
                    Helpers.LevelEntry(6, ProtectiveAuraFeature),
                    Helpers.LevelEntry(7, GodEmporerSignatureAttack),
                    Helpers.LevelEntry(9, DarkAuraFeature),
                    Helpers.LevelEntry(10, GodlyBody),
                    Helpers.LevelEntry(13, GloriousAuraFeature),
                    Helpers.LevelEntry(19, Invincible),
                };
            });

            // Add Archetype to Class
            var IsekaiProtagonistClass = Resources.GetModBlueprint<BlueprintCharacterClass>("IsekaiProtagonistClass");
            IsekaiProtagonistClass.m_Archetypes = IsekaiProtagonistClass.m_Archetypes.AppendToArray(GodEmporerArchetype.ToReference<BlueprintArchetypeReference>());
        }
    }
}
