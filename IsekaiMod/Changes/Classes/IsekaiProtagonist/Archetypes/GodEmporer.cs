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
            var Godhood = Resources.GetModBlueprint<BlueprintFeature>("Godhood");
            var GodlyVessel = Resources.GetModBlueprint<BlueprintFeature>("GodlyVessel");
            var SiphoningAuraFeature = Resources.GetModBlueprint<BlueprintFeature>("SiphoningAuraFeature");

            // Removed features
            var SneakAttack = Resources.GetBlueprint<BlueprintFeature>("9b9eac6709e1c084cb18c3a366e0ec87");
            var IsekaiProtagonistProficiencies = Resources.GetModBlueprint<BlueprintFeature>("IsekaiProtagonistProficiencies");
            var PlotArmor = Resources.GetModBlueprint<BlueprintFeature>("PlotArmor");
            var IsekaiFighterTraining = Resources.GetModBlueprint<BlueprintFeature>("IsekaiFighterTraining");
            var SignatureAttack = Resources.GetModBlueprint<BlueprintFeature>("SignatureAttack");
            var FriendlyAuraFeature = Resources.GetModBlueprint<BlueprintFeature>("FriendlyAuraFeature");
            var OtherworldlyStamina = Resources.GetModBlueprint<BlueprintFeature>("OtherworldlyStamina");
            var TrueMainCharacter = Resources.GetModBlueprint<BlueprintFeature>("TrueMainCharacter");

            var TrainingArcSelection = Resources.GetModBlueprint<BlueprintFeatureSelection>("TrainingArcSelection");
            var BeachEpisodeSelection = Resources.GetModBlueprint<BlueprintFeatureSelection>("BeachEpisodeSelection");
            var CharacterDevelopmentSelection1 = Resources.GetModBlueprint<BlueprintFeatureSelection>("CharacterDevelopmentSelection1");
            var CharacterDevelopmentSelection2 = Resources.GetModBlueprint<BlueprintFeatureSelection>("CharacterDevelopmentSelection2");
            var CharacterDevelopmentSelection3 = Resources.GetModBlueprint<BlueprintFeatureSelection>("CharacterDevelopmentSelection3");
            var CharacterDevelopmentSelection4 = Resources.GetModBlueprint<BlueprintFeatureSelection>("CharacterDevelopmentSelection4");

            // Archetype
            var GodEmporerArchetype = Helpers.CreateBlueprint<BlueprintArchetype>("GodEmporerArchetype", bp => {
                bp.LocalizedName = Helpers.CreateString($"GodEmporerArchetype.Name", "God Emporer");
                bp.LocalizedDescription = Helpers.CreateString($"GodEmporerArchetype.Description", "Rather than wandering aimlessly, collecting harems, or defeating demon lords, "
                    + "some protagonists decide to become gods. They sacrifice their character development feats and some sneak attack to gain auras which buff and debuff allies and enemies respectively.");
                bp.LocalizedDescriptionShort = Helpers.CreateString($"GodEmporerArchetype.Description", "Rather than wandering aimlessly, collecting harems, or defeating demon lords, "
                    + "some protagonists decide to become gods. They sacrifice their character development feats and some sneak attack to gain auras which buff and debuff allies and enemies respectively.");
                bp.RemoveSpellbook = true;
                bp.RemoveFeatures = new LevelEntry[] {
                    Helpers.LevelEntry(1, IsekaiProtagonistProficiencies, PlotArmor),
                    Helpers.LevelEntry(3, IsekaiFighterTraining, CharacterDevelopmentSelection1),
                    Helpers.LevelEntry(5, SneakAttack, TrainingArcSelection),
                    Helpers.LevelEntry(6, SignatureAttack),
                    Helpers.LevelEntry(7, CharacterDevelopmentSelection2),
                    Helpers.LevelEntry(9, SneakAttack, FriendlyAuraFeature),
                    Helpers.LevelEntry(10, TrainingArcSelection),
                    Helpers.LevelEntry(12, BeachEpisodeSelection),
                    Helpers.LevelEntry(13, SneakAttack, CharacterDevelopmentSelection3),
                    Helpers.LevelEntry(15, TrainingArcSelection, OtherworldlyStamina),
                    Helpers.LevelEntry(17, SneakAttack),
                    Helpers.LevelEntry(19, CharacterDevelopmentSelection4),
                    Helpers.LevelEntry(20, TrueMainCharacter),
                };
                bp.AddFeatures = new LevelEntry[] {
                    Helpers.LevelEntry(1, GodEmporerProficiencies, GodEmporerPlotArmor),
                    Helpers.LevelEntry(3, NascentApotheosis),
                    Helpers.LevelEntry(4, GodEmporerTraining),
                    Helpers.LevelEntry(6, ProtectiveAuraFeature),
                    Helpers.LevelEntry(7, GodEmporerSignatureAttack),
                    Helpers.LevelEntry(9, GloriousAuraFeature),
                    Helpers.LevelEntry(10, DarkAuraFeature),
                    Helpers.LevelEntry(12, SiphoningAuraFeature),
                    Helpers.LevelEntry(15, GodlyVessel),
                    Helpers.LevelEntry(20, Godhood),
                };
            });

            // Add Archetype to Class
            var IsekaiProtagonistClass = Resources.GetModBlueprint<BlueprintCharacterClass>("IsekaiProtagonistClass");
            IsekaiProtagonistClass.m_Archetypes = IsekaiProtagonistClass.m_Archetypes.AppendToArray(GodEmporerArchetype.ToReference<BlueprintArchetypeReference>());
        }
    }
}
