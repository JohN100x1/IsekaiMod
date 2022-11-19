using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.UnitLogic.Alignments;

namespace IsekaiMod.Content.Classes.IsekaiProtagonist.Archetypes
{
    class Hero
    {
        public static void Add()
        {
            // Archetype features
            var GracefulCombat = Resources.GetModBlueprint<BlueprintFeature>("GracefulCombat");

            // Removed features
            var SneakAttack = Resources.GetBlueprint<BlueprintFeature>("9b9eac6709e1c084cb18c3a366e0ec87");


            // Archetype
            var HeroArchetype = Helpers.CreateBlueprint<BlueprintArchetype>("HeroArchetype", bp => {
                bp.LocalizedName = Helpers.CreateString($"HeroArchetype.Name", "Hero");
                bp.LocalizedDescription = Helpers.CreateString($"HeroArchetype.Description", "Heroes use their newfound powers for good. After realising the suffering and "
                    + "despair of the inhabitants of the new world, the hero sets out to bring knowledge from their old world in order to save them.");
                bp.LocalizedDescriptionShort = Helpers.CreateString($"HeroArchetype.Description", "Heroes use their newfound powers for good. After realising the suffering and "
                    + "despair of the inhabitants of the new world, the hero sets out to bring knowledge from their old world in order to save them.");
                bp.RemoveSpellbook = false;
                bp.RemoveFeatures = new LevelEntry[] {
                    Helpers.LevelEntry(1, SneakAttack),
                    Helpers.LevelEntry(3, SneakAttack),
                    Helpers.LevelEntry(5, SneakAttack),
                    Helpers.LevelEntry(7, SneakAttack),
                    Helpers.LevelEntry(9, SneakAttack),
                    Helpers.LevelEntry(11, SneakAttack),
                    Helpers.LevelEntry(13, SneakAttack),
                    Helpers.LevelEntry(15, SneakAttack),
                    Helpers.LevelEntry(17, SneakAttack),
                    Helpers.LevelEntry(19, SneakAttack),
                };
                bp.AddFeatures = new LevelEntry[] {
                    Helpers.LevelEntry(1, GracefulCombat),
                };
                bp.AddComponent<PrerequisiteAlignment>(c => {
                    c.Group = Prerequisite.GroupType.Any;
                    c.Alignment = AlignmentMaskType.Good;
                });
            });

            // Add Archetype to Class
            IsekaiProtagonistClass.RegisterArchetype(HeroArchetype);
        }
        public static BlueprintArchetype Get()
        {
            return Resources.GetModBlueprint<BlueprintArchetype>("HeroArchetype");
        }
        public static BlueprintArchetypeReference GetReference()
        {
            return Get().ToReference<BlueprintArchetypeReference>();
        }
    }
}
