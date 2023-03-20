using IsekaiMod.Content.Classes.IsekaiProtagonist;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.EdgeLord;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Hero;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.UnitLogic.FactLogic;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.InheritedClassFeature {
    internal class KineticKnightLegacy {
        private static BlueprintArchetype BaseKnight = BlueprintTools.GetBlueprint<BlueprintArchetype>("7d61d9b2250260a45b18c5634524a8fb");
        private static BlueprintFeature EnergizeWeapon = BlueprintTools.GetBlueprint<BlueprintFeature>("fb9fe27f13934807bcd62dfeec477758");

        private static BlueprintProgression prog;

        public static void ConfigureEmptyShell() {
            prog = Helpers.CreateBlueprint<BlueprintProgression>(IsekaiContext, "KineticKnightLegacy", bp => { });
            }


        public static void configure() {
            var IsekaiKineticistTraining = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiKineticistTraining");

            prog.SetName(IsekaiContext, "Kineticist Legacy - Kinetic Knight");
            prog.SetDescription(IsekaiContext, "Just like all Kinetic Knights your sanity is somewhat questionable, after all you willingly choose to forego fighting at range and instead choose to use energy blasts as melee weapons...\nAnd why? Because the burning blade looked cool.");
            prog.GiveFeaturesForPreviousLevels = true;
            
            prog.AddComponent<AddProficiencies>(c => {
                c.WeaponProficiencies = new Kingmaker.Enums.WeaponCategory[] { Kingmaker.Enums.WeaponCategory.KineticBlast };
            });

            LegacySelection.GetClassFeature().AddFeatures(prog);
            LegacySelection.GetOverwhelmingFeature().AddFeatures(prog);
            EdgeLordLegacySelection.getClassFeature().AddFeatures(prog);
            HeroLegacySelection.getClassFeature().AddFeatures(prog);
        }
        public static void PatchProgression() {
            //please note that this only patches the knight progression so this only works in combination of the already done patch by the other version

            LevelEntry[] additionalReferencedFeats = null;
            if (ModSupport.IsExpandedElementEnabled() && EnergizeWeapon != null) {
                additionalReferencedFeats = new LevelEntry[] { Helpers.CreateLevelEntry(1, EnergizeWeapon) };
            }
            prog = StaticReferences.PatchClassProgressionBasedonRefArchetype(prog, ClassTools.Classes.KineticistClass, BaseKnight, additionalReferencedFeats);
            BlueprintCharacterClassReference refClass = ClassTools.ClassReferences.KineticistClass;
            BlueprintCharacterClassReference myClass = IsekaiProtagonistClass.GetReference();
            StaticReferences.PatchProgressionFeaturesBasedOnReferenceArchetype(myClass, refClass, BaseKnight);
        }
        public static BlueprintProgression Get() {
            if (prog != null) return prog;
            return BlueprintTools.GetModBlueprint<BlueprintProgression>(IsekaiContext, "KineticKnightLegacy");
        }
    }
}
