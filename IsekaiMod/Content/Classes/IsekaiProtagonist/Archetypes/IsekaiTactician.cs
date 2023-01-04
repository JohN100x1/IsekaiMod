using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.UnitLogic.Alignments;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Classes.IsekaiProtagonist.Archetypes {
    internal class IsekaiTactician {
        public static readonly BlueprintFeature Teamwork = BlueprintTools.GetBlueprint<BlueprintFeature>("01046afc774beee48abde8e35da0f4ba");
        public static readonly BlueprintFeature AnimalTeamwork = BlueprintTools.GetBlueprint<BlueprintFeature>("1b9916f7675d6ef4fb427081250d49de");
        public static readonly BlueprintFeature SummonTactics = BlueprintTools.GetBlueprint<BlueprintFeature>("c3abcce19f9f80640a867c9e75f880b2");
        public static readonly BlueprintFeature SoloTactics = BlueprintTools.GetBlueprint<BlueprintFeature>("87d6de4d30adc7244b7a3427d041dcaa");
        public static readonly BlueprintFeature ForesterTactics = BlueprintTools.GetBlueprint<BlueprintFeature>("994db4abfa0d6194eb3c847605e6f148");

        public static void Add() {
            var AuraOfWrath = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "AuraOfRighteousWrathFeature");

            // Removed features
            var SneakAttack = BlueprintTools.GetBlueprint<BlueprintFeature>("9b9eac6709e1c084cb18c3a366e0ec87");
            var OverpoweredAbilitySelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "OverpoweredAbilitySelection");

            // Archetype
            var myArchetype = Helpers.CreateBlueprint<BlueprintArchetype>(IsekaiContext, "IsekaiTacticianArchetype", bp => {
                bp.LocalizedName = Helpers.CreateString(IsekaiContext, $"IsekaiTacticianArchetype.Name", "Isekai Tactician");
                bp.LocalizedDescription = Helpers.CreateString(IsekaiContext, $"IsekaiTacticianArchetype.Description", "You are used to telling people what to do. \nYou were the tactician that lead your guild to first kill Onyxia. \nThis, as far as you are concerned, is just another raid to conquer with your brilliant tactics and perfect preparation...");
                bp.LocalizedDescriptionShort = bp.LocalizedDescription;
                bp.IsArcaneCaster = true;
                bp.IsDivineCaster = true;
                bp.RemoveFeatures = new LevelEntry[] {
                    Helpers.CreateLevelEntry(1, SneakAttack,OverpoweredAbilitySelection),
                    Helpers.CreateLevelEntry(5, SneakAttack),
                    Helpers.CreateLevelEntry(9, SneakAttack),
                    Helpers.CreateLevelEntry(13, SneakAttack),
                    Helpers.CreateLevelEntry(17, SneakAttack),
                };
                bp.AddFeatures = new LevelEntry[] {
                    Helpers.CreateLevelEntry(1,SoloTactics, AuraOfWrath),
                    Helpers.CreateLevelEntry(2,Teamwork),
                    Helpers.CreateLevelEntry(3,ForesterTactics),
                    Helpers.CreateLevelEntry(4,AnimalTeamwork),
                    Helpers.CreateLevelEntry(5,SummonTactics),
                    Helpers.CreateLevelEntry(6,Teamwork),
                    Helpers.CreateLevelEntry(8,Teamwork),
                    Helpers.CreateLevelEntry(12,Teamwork),
                    Helpers.CreateLevelEntry(16,Teamwork),
                    Helpers.CreateLevelEntry(18,Teamwork),

                };
                bp.OverrideAttributeRecommendations = true;
                bp.RecommendedAttributes = new StatType[] { StatType.Intelligence };
                bp.AddComponent<PrerequisiteAlignment>(c => {
                    c.Group = Prerequisite.GroupType.Any;
                    c.Alignment = AlignmentMaskType.Lawful;
                });
                bp.ChangeCasterType = true;
                bp.m_ReplaceSpellbook = VillainSpellbook.GetReference();
            });

            // Add Archetype to Class
            IsekaiProtagonistClass.RegisterArchetype(myArchetype);
        }
        public static BlueprintArchetype Get() {
            return BlueprintTools.GetModBlueprint<BlueprintArchetype>(IsekaiContext, "IsekaiTacticianArchetype");
        }
        public static BlueprintArchetypeReference GetReference() {
            return Get().ToReference<BlueprintArchetypeReference>();
        }
    }
}
