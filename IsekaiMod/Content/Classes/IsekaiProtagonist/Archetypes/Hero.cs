using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.UnitLogic.Alignments;

namespace IsekaiMod.Content.Classes.IsekaiProtagonist.Archetypes
{
    class Hero
    {
        public static void Add()
        {
            // Archetype features
            var HeroProficiencies = Resources.GetModBlueprint<BlueprintFeature>("HeroProficiencies");
            var GracefulCombat = Resources.GetModBlueprint<BlueprintFeature>("GracefulCombat");
            var TrueSmiteFeature = Resources.GetModBlueprint<BlueprintFeature>("TrueSmiteFeature");
            var TrueSmiteAdditionalUse = Resources.GetModBlueprint<BlueprintFeature>("TrueSmiteAdditionalUse");
            var TrueMarkFeature = Resources.GetModBlueprint<BlueprintFeature>("TrueMarkFeature");
            var HerosPresenceFeature = Resources.GetModBlueprint<BlueprintFeature>("HerosPresenceFeature");
            var IsekaiChannelPositiveEnergyFeature = Resources.GetModBlueprint<BlueprintFeature>("IsekaiChannelPositiveEnergyFeature");
            var AuraOfDivineFuryFeature = Resources.GetModBlueprint<BlueprintFeature>("AuraOfDivineFuryFeature");
            var CelestialRealmFeature = Resources.GetModBlueprint<BlueprintFeature>("CelestialRealmFeature");

            // Removed features
            var IsekaiProtagonistProficiencies = Resources.GetModBlueprint<BlueprintFeature>("IsekaiProtagonistProficiencies");
            var SneakAttack = Resources.GetBlueprint<BlueprintFeature>("9b9eac6709e1c084cb18c3a366e0ec87");
            var OverpoweredAbilitySelection2 = Resources.GetModBlueprint<BlueprintFeatureSelection>("OverpoweredAbilitySelection2");
            var SpecialPowerSelection = Resources.GetModBlueprint<BlueprintFeatureSelection>("SpecialPowerSelection");
            var SecondReincarnation = Resources.GetModBlueprint<BlueprintFeature>("SecondReincarnation");

            // Archetype
            var HeroArchetype = Helpers.CreateBlueprint<BlueprintArchetype>("HeroArchetype", bp => {
                bp.LocalizedName = Helpers.CreateString($"HeroArchetype.Name", "Hero");
                bp.LocalizedDescription = Helpers.CreateString($"HeroArchetype.Description", "Heroes use their newfound powers for good. After realising the suffering and "
                    + "despair of the inhabitants of the new world, the hero sets out to bring knowledge from their old world in order to save them.");
                bp.LocalizedDescriptionShort = Helpers.CreateString($"HeroArchetype.DescriptionShort", "Heroes use their newfound powers for good. After realising the suffering and "
                    + "despair of the inhabitants of the new world, the hero sets out to bring knowledge from their old world in order to save them.");
                bp.IsArcaneCaster = false;
                bp.IsDivineCaster = true;
                bp.RemoveFeatures = new LevelEntry[] {
                    Helpers.LevelEntry(1, IsekaiProtagonistProficiencies, SneakAttack),
                    Helpers.LevelEntry(3, SneakAttack, SpecialPowerSelection),
                    Helpers.LevelEntry(5, SneakAttack),
                    Helpers.LevelEntry(7, SneakAttack),
                    Helpers.LevelEntry(9, SneakAttack),
                    Helpers.LevelEntry(10, OverpoweredAbilitySelection2),
                    Helpers.LevelEntry(11, SneakAttack),
                    Helpers.LevelEntry(13, SneakAttack),
                    Helpers.LevelEntry(15, SneakAttack),
                    Helpers.LevelEntry(17, SneakAttack, SpecialPowerSelection),
                    Helpers.LevelEntry(19, SneakAttack),
                    Helpers.LevelEntry(20, SecondReincarnation),
                };
                bp.AddFeatures = new LevelEntry[] {
                    Helpers.LevelEntry(1, HeroProficiencies, GracefulCombat),
                    Helpers.LevelEntry(2, TrueSmiteFeature),
                    Helpers.LevelEntry(3, IsekaiChannelPositiveEnergyFeature),
                    Helpers.LevelEntry(4, TrueSmiteAdditionalUse),
                    Helpers.LevelEntry(7, TrueSmiteAdditionalUse),
                    Helpers.LevelEntry(10, AuraOfDivineFuryFeature, TrueSmiteAdditionalUse),
                    Helpers.LevelEntry(11, TrueMarkFeature),
                    Helpers.LevelEntry(13, TrueSmiteAdditionalUse),
                    Helpers.LevelEntry(16, TrueSmiteAdditionalUse),
                    Helpers.LevelEntry(17, CelestialRealmFeature),
                    Helpers.LevelEntry(19, TrueSmiteAdditionalUse),
                    Helpers.LevelEntry(20, HerosPresenceFeature),
                };
                bp.AddComponent<PrerequisiteAlignment>(c => {
                    c.Group = Prerequisite.GroupType.Any;
                    c.Alignment = AlignmentMaskType.Good;
                });
                bp.OverrideAttributeRecommendations = true;
                bp.RecommendedAttributes = new StatType[] { StatType.Charisma };
            });

            // Add Archetype to Class
            IsekaiProtagonistClass.RegisterArchetype(HeroArchetype);
        }
    }
}
