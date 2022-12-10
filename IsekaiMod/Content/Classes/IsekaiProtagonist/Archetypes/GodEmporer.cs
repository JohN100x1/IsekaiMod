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
            var DivineArray = Resources.GetModBlueprint<BlueprintFeature>("DivineArray");
            var GodEmperorEnergySelection = Resources.GetModBlueprint<BlueprintFeature>("GodEmperorEnergySelection");
            var AuraOfGoldenProtectionFeature = Resources.GetModBlueprint<BlueprintFeature>("AuraOfGoldenProtectionFeature");
            var DarkAuraFeature = Resources.GetModBlueprint<BlueprintFeature>("DarkAuraFeature");
            var AuraOfMajestyFeature = Resources.GetModBlueprint<BlueprintFeature>("AuraOfMajestyFeature");
            var CelestialRealmFeature = Resources.GetModBlueprint<BlueprintFeature>("CelestialRealmFeature");
            var Godhood = Resources.GetModBlueprint<BlueprintFeature>("Godhood");
            var GodlyVessel = Resources.GetModBlueprint<BlueprintFeature>("GodlyVessel");
            var SiphoningAuraFeature = Resources.GetModBlueprint<BlueprintFeature>("SiphoningAuraFeature");
            var OverpoweredAbilitySelection2 = Resources.GetModBlueprint<BlueprintFeatureSelection>("OverpoweredAbilitySelection2");

            // Removed features
            var SneakAttack = Resources.GetBlueprint<BlueprintFeature>("9b9eac6709e1c084cb18c3a366e0ec87");
            var IsekaiProtagonistProficiencies = Resources.GetModBlueprint<BlueprintFeature>("IsekaiProtagonistProficiencies");
            var FriendlyAuraFeature = Resources.GetModBlueprint<BlueprintFeature>("FriendlyAuraFeature");
            var OtherworldlyStamina = Resources.GetModBlueprint<BlueprintFeature>("OtherworldlyStamina");
            var SecondReincarnation = Resources.GetModBlueprint<BlueprintFeature>("SecondReincarnation");

            var BeachEpisodeSelection = Resources.GetModBlueprint<BlueprintFeatureSelection>("BeachEpisodeSelection");
            var SpecialPowerSelection = Resources.GetModBlueprint<BlueprintFeatureSelection>("SpecialPowerSelection");

            // Archetype
            var GodEmperorArchetype = Helpers.CreateBlueprint<BlueprintArchetype>("GodEmperorArchetype", bp => {
                bp.LocalizedName = Helpers.CreateString($"GodEmperorArchetype.Name", "God Emperor");
                bp.LocalizedDescription = Helpers.CreateString($"GodEmperorArchetype.Description", "Rather than wandering aimlessly, collecting harems, or defeating demon lords, "
                    + "some protagonists decide to become gods. They sacrifice their special powers and sneak attack to gain powerful auras and a journey towards godhood.");
                bp.LocalizedDescriptionShort = Helpers.CreateString($"GodEmperorArchetype.DescriptionShort", "Rather than wandering aimlessly, collecting harems, or defeating demon lords, "
                    + "some protagonists decide to become gods. They sacrifice their special powers and sneak attack to gain powerful auras and a journey towards godhood.");
                bp.IsArcaneCaster = false;
                bp.IsDivineCaster = true;
                bp.RemoveFeatures = new LevelEntry[] {
                    Helpers.LevelEntry(1, SneakAttack, IsekaiProtagonistProficiencies),
                    Helpers.LevelEntry(3, SneakAttack, SpecialPowerSelection),
                    Helpers.LevelEntry(5, SneakAttack, OverpoweredAbilitySelection2),
                    Helpers.LevelEntry(7, SneakAttack, SpecialPowerSelection),
                    Helpers.LevelEntry(9, SneakAttack, SpecialPowerSelection, FriendlyAuraFeature),
                    Helpers.LevelEntry(11, SneakAttack, SpecialPowerSelection),
                    Helpers.LevelEntry(12, BeachEpisodeSelection),
                    Helpers.LevelEntry(13, SneakAttack, SpecialPowerSelection),
                    Helpers.LevelEntry(15, SneakAttack, OverpoweredAbilitySelection2, OtherworldlyStamina),
                    Helpers.LevelEntry(17, SneakAttack, SpecialPowerSelection),
                    Helpers.LevelEntry(19, SneakAttack, SpecialPowerSelection),
                    Helpers.LevelEntry(20, SecondReincarnation),
                };
                bp.AddFeatures = new LevelEntry[] {
                    Helpers.LevelEntry(1, NascentApotheosis, GodEmperorProficiencies),
                    Helpers.LevelEntry(3, DivineArray),
                    Helpers.LevelEntry(5, GodEmperorEnergySelection, SpecialPowerSelection),
                    Helpers.LevelEntry(7, AuraOfGoldenProtectionFeature),
                    Helpers.LevelEntry(9, AuraOfMajestyFeature),
                    Helpers.LevelEntry(10, DarkAuraFeature),
                    Helpers.LevelEntry(12, SiphoningAuraFeature),
                    Helpers.LevelEntry(15, GodlyVessel, SpecialPowerSelection),
                    Helpers.LevelEntry(17, CelestialRealmFeature),
                    Helpers.LevelEntry(20, Godhood),
                };
            });

            // Add Archetype to Class
            IsekaiProtagonistClass.RegisterArchetype(GodEmperorArchetype);
        }
    }
}
