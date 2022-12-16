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
            var IsekaiProtagonistBonusFeatSelection = Resources.GetModBlueprint<BlueprintFeatureSelection>("IsekaiProtagonistBonusFeatSelection");
            var IsekaiProtagonistProficiencies = Resources.GetModBlueprint<BlueprintFeature>("IsekaiProtagonistProficiencies");
            var FriendlyAuraFeature = Resources.GetModBlueprint<BlueprintFeature>("FriendlyAuraFeature");
            var IsekaiQuickFooted = Resources.GetModBlueprint<BlueprintFeature>("IsekaiQuickFooted");
            var SecondReincarnation = Resources.GetModBlueprint<BlueprintFeature>("SecondReincarnation");
            var OverpoweredAbilitySelection2 = Resources.GetModBlueprint<BlueprintFeatureSelection>("OverpoweredAbilitySelection2");
            var SpecialPowerSelection = Resources.GetModBlueprint<BlueprintFeatureSelection>("SpecialPowerSelection");

            // Archetype
            var VillainArchetype = Helpers.CreateBlueprint<BlueprintArchetype>("VillainArchetype", bp => {
                bp.LocalizedName = Helpers.CreateString($"VillainArchetype.Name", "Villain");
                bp.LocalizedDescription = Helpers.CreateString($"VillainArchetype.Description", "After obtaining ungodly amounts of power, some protagonists become villains. "
                    + "They view the new world as theirs to play with, and the new inhabitants as theirs to torment. Villains seek to increase their power even further, "
                    + "often by establishing their own kingdom.\nYou cast spells like an Arcanist with a number of slots equal to your spells per day.");
                bp.LocalizedDescriptionShort = Helpers.CreateString($"VillainArchetype.DescriptionShort", "After obtaining ungodly amounts of power, some protagonists become villains. "
                    + "They view the new world as theirs to play with, and the new inhabitants as theirs to torment. Villains seek to increase their power even further, "
                    + "often by establishing their own kingdom.\nYou cast spells like an Arcanist with a number of slots equal to your spells per day.");
                bp.IsArcaneCaster = true;
                bp.IsDivineCaster = true;
                bp.RemoveFeatures = new LevelEntry[] {
                    Helpers.LevelEntry(1, IsekaiProtagonistBonusFeatSelection, IsekaiProtagonistProficiencies, SneakAttack),
                    Helpers.LevelEntry(2, IsekaiProtagonistBonusFeatSelection),
                    Helpers.LevelEntry(3, SpecialPowerSelection),
                    Helpers.LevelEntry(4, IsekaiProtagonistBonusFeatSelection),
                    Helpers.LevelEntry(5, SneakAttack),
                    Helpers.LevelEntry(6, IsekaiProtagonistBonusFeatSelection),
                    Helpers.LevelEntry(8, IsekaiProtagonistBonusFeatSelection),
                    Helpers.LevelEntry(9, SneakAttack, FriendlyAuraFeature),
                    Helpers.LevelEntry(10, IsekaiProtagonistBonusFeatSelection, OverpoweredAbilitySelection2),
                    Helpers.LevelEntry(12, IsekaiProtagonistBonusFeatSelection),
                    Helpers.LevelEntry(13, SneakAttack),
                    Helpers.LevelEntry(14, IsekaiProtagonistBonusFeatSelection),
                    Helpers.LevelEntry(15, IsekaiQuickFooted),
                    Helpers.LevelEntry(16, IsekaiProtagonistBonusFeatSelection),
                    Helpers.LevelEntry(17, SneakAttack),
                    Helpers.LevelEntry(18, IsekaiProtagonistBonusFeatSelection),
                    Helpers.LevelEntry(20, IsekaiProtagonistBonusFeatSelection, SecondReincarnation),
                };
                bp.AddFeatures = new LevelEntry[] {
                    Helpers.LevelEntry(1, VillainProficiencies, OverpoweredAbilitySelectionVillain, SlayerStudyTargetFeature),
                    Helpers.LevelEntry(3, IsekaiChannelNegativeEnergyFeature),
                    Helpers.LevelEntry(5, SlayerStudyTargetFeature, OverpoweredAbilitySelectionVillain),
                    Helpers.LevelEntry(7, SlayerSwiftStudyTargetFeature),
                    Helpers.LevelEntry(9, OverpoweredAbilitySelectionVillain),
                    Helpers.LevelEntry(10, CorruptAuraFeature, SlayerStudyTargetFeature, DarkAuraFeature),
                    Helpers.LevelEntry(13, OverpoweredAbilitySelectionVillain),
                    Helpers.LevelEntry(15, SlayerStudyTargetFeature, VillainQuickFooted),
                    Helpers.LevelEntry(17, OverpoweredAbilitySelectionVillain),
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
