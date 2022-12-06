using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.UnitLogic.Alignments;

namespace IsekaiMod.Content.Classes.IsekaiProtagonist.Archetypes
{
    class Villain
    {
        public static void Add()
        {
            // Archetype features
            var VillainSpellbook = Resources.GetModBlueprint<BlueprintSpellbook>("VillainSpellbook");
            var VillainProficiencies = Resources.GetModBlueprint<BlueprintFeature>("VillainProficiencies");
            var DarkAuraFeature = Resources.GetModBlueprint<BlueprintFeature>("DarkAuraFeature");
            var SlayerStudyTargetFeature = Resources.GetBlueprint<BlueprintFeature>("09bdd9445ac38044389476689ae8d5a1");
            var SlayerSwiftStudyTargetFeature = Resources.GetBlueprint<BlueprintFeature>("40d4f55a5ac0e4f469d67d36c0dfc40b");
            var OverpoweredAbilitySelectionVillain = Resources.GetModBlueprint<BlueprintFeature>("OverpoweredAbilitySelectionVillain");
            var CorruptAuraFeature = Resources.GetModBlueprint<BlueprintFeature>("CorruptAuraFeature");
            var VillainQuickFooted = Resources.GetModBlueprint<BlueprintFeature>("VillainQuickFooted");
            var SecondFormFeature = Resources.GetModBlueprint<BlueprintFeature>("SecondFormFeature");
            var IsekaiChannelNegativeEnergyFeature = Resources.GetModBlueprint<BlueprintFeature>("IsekaiChannelNegativeEnergyFeature");

            // Removed features
            var SneakAttack = Resources.GetBlueprint<BlueprintFeature>("9b9eac6709e1c084cb18c3a366e0ec87");
            var IsekaiProtagonistProficiencies = Resources.GetModBlueprint<BlueprintFeature>("IsekaiProtagonistProficiencies");
            var FriendlyAuraFeature = Resources.GetModBlueprint<BlueprintFeature>("FriendlyAuraFeature");
            var IsekaiQuickFooted = Resources.GetModBlueprint<BlueprintFeature>("IsekaiQuickFooted");
            var TrueMainCharacter = Resources.GetModBlueprint<BlueprintFeature>("TrueMainCharacter");
            var OverpoweredAbilitySelection2 = Resources.GetModBlueprint<BlueprintFeatureSelection>("OverpoweredAbilitySelection2");
            var SpecialPowerSelection = Resources.GetModBlueprint<BlueprintFeatureSelection>("SpecialPowerSelection");

            // Archetype
            var VillainArchetype = Helpers.CreateBlueprint<BlueprintArchetype>("VillainArchetype", bp => {
                bp.LocalizedName = Helpers.CreateString($"VillainArchetype.Name", "Villain");
                bp.LocalizedDescription = Helpers.CreateString($"VillainArchetype.Description", "After obtaining ungodly amounts of power, some protagonists become villains. "
                    + "They view the new world as theirs to play with, and the new inhabitants as theirs to torment. Villains seek to increase their power even further, "
                    + "often by establishing their own kingdom... or by setting up not-so-ethical research in joyous human farms.");
                bp.LocalizedDescriptionShort = Helpers.CreateString($"VillainArchetype.DescriptionShort", "After obtaining ungodly amounts of power, some protagonists become villains. "
                    + "They view the new world as theirs to play with, and the new inhabitants as theirs to torment. Villains seek to increase their power even further, "
                    + "often by establishing their own kingdom... or by setting up not-so-ethical research in joyous human farms.");
                bp.RemoveSpellbook = false;
                bp.RemoveFeatures = new LevelEntry[] {
                    Helpers.LevelEntry(1, IsekaiProtagonistProficiencies, SneakAttack),
                    Helpers.LevelEntry(3, SpecialPowerSelection),
                    Helpers.LevelEntry(5, SneakAttack, OverpoweredAbilitySelection2),
                    Helpers.LevelEntry(9, SneakAttack, FriendlyAuraFeature),
                    Helpers.LevelEntry(10, OverpoweredAbilitySelection2),
                    Helpers.LevelEntry(13, SneakAttack),
                    Helpers.LevelEntry(15, OverpoweredAbilitySelection2, IsekaiQuickFooted),
                    Helpers.LevelEntry(17, SneakAttack),
                    Helpers.LevelEntry(20, TrueMainCharacter),
                };
                bp.AddFeatures = new LevelEntry[] {
                    Helpers.LevelEntry(1, VillainProficiencies, OverpoweredAbilitySelectionVillain, SlayerStudyTargetFeature),
                    Helpers.LevelEntry(3, IsekaiChannelNegativeEnergyFeature),
                    Helpers.LevelEntry(5, SlayerStudyTargetFeature),
                    Helpers.LevelEntry(7, SlayerSwiftStudyTargetFeature),
                    Helpers.LevelEntry(9, CorruptAuraFeature),
                    Helpers.LevelEntry(10, SlayerStudyTargetFeature, DarkAuraFeature),
                    Helpers.LevelEntry(15, SlayerStudyTargetFeature),
                    Helpers.LevelEntry(16, VillainQuickFooted),
                    Helpers.LevelEntry(20, SlayerStudyTargetFeature, SecondFormFeature),
                };
                bp.OverrideAttributeRecommendations = true;
                bp.AddComponent<PrerequisiteAlignment>(c => {
                    c.Group = Prerequisite.GroupType.Any;
                    c.Alignment = AlignmentMaskType.Evil;
                });
                bp.ChangeCasterType = true;
                bp.IsDivineCaster = true;
                bp.m_ReplaceSpellbook = VillainSpellbook.ToReference<BlueprintSpellbookReference>();
                bp.RecommendedAttributes = new StatType[] { StatType.Intelligence, StatType.Strength };
            });

            // Add Archetype to Class
            IsekaiProtagonistClass.RegisterArchetype(VillainArchetype);
        }
        public static BlueprintArchetype Get()
        {
            return Resources.GetModBlueprint<BlueprintArchetype>("VillainArchetype");
        }
        public static BlueprintArchetypeReference GetReference()
        {
            return Get().ToReference<BlueprintArchetypeReference>();
        }
    }
}
