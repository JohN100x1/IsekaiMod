using IsekaiMod.Content.Classes.IsekaiProtagonist;
using IsekaiMod.Content.Classes.IsekaiProtagonist.Archetypes;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.EdgeLord;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.GodEmperor;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Hero;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Mastermind;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Overlord;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.UnitLogic.FactLogic;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.InheritedClassFeature {

    internal class KineticLegacy {
        

        private static BlueprintProgression prog;

        public static void Configure() {
            prog = Helpers.CreateBlueprint<BlueprintProgression>(IsekaiContext, "KineticLegacy", bp => {
                bp.SetName(IsekaiContext, "Kinetic Legacy - Kinetic Lord");
                bp.SetDescription(IsekaiContext, "Most Protagonists only occasionally use kinetic blasts when they think they would look cool.\n But you really love them, and given that there is no other cantrip this overpowered why not?");
                bp.GiveFeaturesForPreviousLevels = true;
                bp.AddComponent<AddProficiencies>(c => {
                    c.WeaponProficiencies = new Kingmaker.Enums.WeaponCategory[] { Kingmaker.Enums.WeaponCategory.KineticBlast };
                });
                bp.AddComponent<PrerequisiteNoArchetype>(c => { c.m_Archetype = EdgeLord.GetReference(); });
            });
            LegacySelection.Register(prog);
            EdgeLordLegacySelection.Prohibit(prog);
            HeroLegacySelection.Register(prog);
            MastermindLegacySelection.Prohibit(prog);
            OverlordLegacySelection.Register(prog);
            GodEmperorLegacySelection.Prohibit(prog);
        }
        public static void PatchProgression() {
            if (prog != null) {
                prog = StaticReferences.PatchClassProgressionBasedOnRefClass(prog, ClassTools.Classes.KineticistClass);
                BlueprintCharacterClassReference myClass = IsekaiProtagonistClass.GetReference();
                StaticReferences.PatchProgressionFeaturesBasedOnReferenceClass(prog, myClass, ClassTools.ClassReferences.KineticistClass);

                prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = KineticDarkElementalistLegacy.Get().ToReference<BlueprintFeatureReference>(); });
                prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = KineticKnightLegacy.Get().ToReference<BlueprintFeatureReference>(); });
                prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = KineticOverwhelmingSoulLegacy.Get().ToReference<BlueprintFeatureReference>(); });
            }            
        }

        public static BlueprintProgression Get() {
            if (prog != null) return prog;
            return BlueprintTools.GetModBlueprint<BlueprintProgression>(IsekaiContext, "KineticLegacy");
        }
    }
}
