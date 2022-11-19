using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;

namespace IsekaiMod.Content.Classes.IsekaiProtagonist.Archetypes
{
    class GodEmperor
    {
        public static void Add()
        {
            // Archetype features
            var GodEmperorProficiencies = Resources.GetModBlueprint<BlueprintFeature>("GodEmperorProficiencies");
            var NascentApotheosis = Resources.GetModBlueprint<BlueprintFeature>("NascentApotheosis");
            var ProtectiveAuraFeature = Resources.GetModBlueprint<BlueprintFeature>("ProtectiveAuraFeature");
            var DarkAuraFeature = Resources.GetModBlueprint<BlueprintFeature>("DarkAuraFeature");
            var GloriousAuraFeature = Resources.GetModBlueprint<BlueprintFeature>("GloriousAuraFeature");
            var Godhood = Resources.GetModBlueprint<BlueprintFeature>("Godhood");
            var GodlyVessel = Resources.GetModBlueprint<BlueprintFeature>("GodlyVessel");
            var SiphoningAuraFeature = Resources.GetModBlueprint<BlueprintFeature>("SiphoningAuraFeature");
            var OverpoweredAbilitySelection2 = Resources.GetModBlueprint<BlueprintFeatureSelection>("OverpoweredAbilitySelection2");

            // Removed features
            var SneakAttack = Resources.GetBlueprint<BlueprintFeature>("9b9eac6709e1c084cb18c3a366e0ec87");
            var IsekaiProtagonistProficiencies = Resources.GetModBlueprint<BlueprintFeature>("IsekaiProtagonistProficiencies");
            var FriendlyAuraFeature = Resources.GetModBlueprint<BlueprintFeature>("FriendlyAuraFeature");
            var OtherworldlyStamina = Resources.GetModBlueprint<BlueprintFeature>("OtherworldlyStamina");
            var TrueMainCharacter = Resources.GetModBlueprint<BlueprintFeature>("TrueMainCharacter");

            var BeachEpisodeSelection = Resources.GetModBlueprint<BlueprintFeatureSelection>("BeachEpisodeSelection");
            var CharacterDevelopmentSelection = Resources.GetModBlueprint<BlueprintFeatureSelection>("CharacterDevelopmentSelection");

            // Archetype
            var GodEmperorArchetype = Helpers.CreateBlueprint<BlueprintArchetype>("GodEmperorArchetype", bp => {
                bp.LocalizedName = Helpers.CreateString($"GodEmperorArchetype.Name", "God Emperor");
                bp.LocalizedDescription = Helpers.CreateString($"GodEmperorArchetype.Description", "Rather than wandering aimlessly, collecting harems, or defeating demon lords, "
                    + "some protagonists decide to become gods. They sacrifice their character development feats and some sneak attack to gain auras which buff and debuff allies and enemies respectively.");
                bp.LocalizedDescriptionShort = Helpers.CreateString($"GodEmperorArchetype.Description", "Rather than wandering aimlessly, collecting harems, or defeating demon lords, "
                    + "some protagonists decide to become gods. They sacrifice their character development feats and some sneak attack to gain auras which buff and debuff allies and enemies respectively.");
                bp.RemoveSpellbook = false;
                bp.RemoveFeatures = new LevelEntry[] {
                    Helpers.LevelEntry(1, IsekaiProtagonistProficiencies),
                    Helpers.LevelEntry(3, CharacterDevelopmentSelection),
                    Helpers.LevelEntry(5, SneakAttack),
                    Helpers.LevelEntry(7, CharacterDevelopmentSelection),
                    Helpers.LevelEntry(9, SneakAttack, FriendlyAuraFeature),
                    Helpers.LevelEntry(10, OverpoweredAbilitySelection2),
                    Helpers.LevelEntry(12, BeachEpisodeSelection),
                    Helpers.LevelEntry(13, SneakAttack, CharacterDevelopmentSelection),
                    Helpers.LevelEntry(15, OverpoweredAbilitySelection2, OtherworldlyStamina),
                    Helpers.LevelEntry(17, SneakAttack, CharacterDevelopmentSelection),
                    Helpers.LevelEntry(20, CharacterDevelopmentSelection, TrueMainCharacter),
                };
                bp.AddFeatures = new LevelEntry[] {
                    Helpers.LevelEntry(1, GodEmperorProficiencies),
                    Helpers.LevelEntry(3, NascentApotheosis),
                    Helpers.LevelEntry(7, ProtectiveAuraFeature),
                    Helpers.LevelEntry(9, GloriousAuraFeature),
                    Helpers.LevelEntry(10, DarkAuraFeature),
                    Helpers.LevelEntry(12, SiphoningAuraFeature),
                    Helpers.LevelEntry(15, GodlyVessel),
                    Helpers.LevelEntry(18, OverpoweredAbilitySelection2),
                    Helpers.LevelEntry(20, Godhood),
                };
            });

            // Add Archetype to Class
            IsekaiProtagonistClass.RegisterArchetype(GodEmperorArchetype);
        }
    }
}
