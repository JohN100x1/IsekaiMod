using IsekaiMod.Content.Classes.IsekaiProtagonist;
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
    internal class KineticPsychoLegacy {
        private static string BaseArchetypeId = "f2847dd4b12fffd41beaa3d7120d27ad";
        private static BlueprintArchetype BaseArchetype = BlueprintTools.GetBlueprint<BlueprintArchetype>(BaseArchetypeId);

        private static BlueprintProgression prog;

        public static void Configure() {
            prog = Helpers.CreateBlueprint<BlueprintProgression>(IsekaiContext, "KineticPsychoLegacy", bp => {
                bp.SetName(IsekaiContext, "Kinetic Legacy - Elemental Ascendent");
                bp.SetDescription(IsekaiContext,
                "The unfathomable willpower needed to fuel your own ascenscion allows you to bend the elements as you see fit. \n" +
                "As your divine essence matures you push the limits of your mind ever so far to claim dominion over the fundamental forces of the multiverse, sometimes at the risk of being overwhelmed by them.");
                bp.GiveFeaturesForPreviousLevels = true;
                bp.AddComponent<AddProficiencies>(c => {
                    c.WeaponProficiencies = new Kingmaker.Enums.WeaponCategory[] { Kingmaker.Enums.WeaponCategory.KineticBlast };
                });
            });


            LegacySelection.RegisterForFeat(prog);
            //LegacySelection.Register(prog);
            //EdgeLordLegacySelection.Prohibit(prog);
            GodEmperorLegacySelection.Register(prog);
            //HeroLegacySelection.Register(prog);
            //MastermindLegacySelection.Prohibit(prog);
            //OverlordLegacySelection.Register(prog);
        }
        public static void PatchProgression() {
            if (prog != null) {
                if (BaseArchetype == null) {
                    BaseArchetype = BlueprintTools.GetBlueprint<BlueprintArchetype>(BaseArchetypeId);
                    if (BaseArchetype == null) { return; }
                }


                prog = PatchTools.PatchClassProgressionBasedonRefArchetype(prog, ClassTools.Classes.KineticistClass, BaseArchetype, null);
                BlueprintCharacterClassReference refClass = ClassTools.ClassReferences.KineticistClass;
                BlueprintCharacterClassReference myClass = IsekaiProtagonistClass.GetReference();
                PatchTools.PatchProgressionFeaturesBasedOnReferenceArchetype(myClass, refClass, BaseArchetype);
                prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = KineticDarkElementalistLegacy.Get().ToReference<BlueprintFeatureReference>(); });
                prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = KineticKnightLegacy.Get().ToReference<BlueprintFeatureReference>(); });
                prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = KineticLegacy.Get().ToReference<BlueprintFeatureReference>(); });
                prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = KineticOverwhelmingSoulLegacy.Get().ToReference<BlueprintFeatureReference>(); });
            }
        }
        public static BlueprintProgression Get() {
            if (prog != null) return prog;
            return BlueprintTools.GetModBlueprint<BlueprintProgression>(IsekaiContext, "KineticPsychoLegacy");
        }
    }
}
