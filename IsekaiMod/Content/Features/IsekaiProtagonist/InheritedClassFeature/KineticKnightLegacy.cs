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
    internal class KineticKnightLegacy {
        private static BlueprintArchetype BaseKnight = BlueprintTools.GetBlueprint<BlueprintArchetype>("7d61d9b2250260a45b18c5634524a8fb");

        private static BlueprintProgression prog;

        public static void Configure() {
            prog = Helpers.CreateBlueprint<BlueprintProgression>(IsekaiContext, "KineticKnightLegacy", bp => { });
        }



        public static void PatchProgression() {
            prog.SetName(IsekaiContext, "Kinetic Legacy - Kinetic Knight");
            prog.SetDescription(IsekaiContext, "Just like all Kinetic Knights your sanity is somewhat questionable, after all you willingly choose to forego fighting at range and instead choose to use energy blasts as melee weapons...\n" +
                "And why? Because the burning blade looked cool.");
            prog.GiveFeaturesForPreviousLevels = true;

            prog.AddComponent<AddProficiencies>(c => {
                c.WeaponProficiencies = new Kingmaker.Enums.WeaponCategory[] { Kingmaker.Enums.WeaponCategory.KineticBlast };
            });

            LegacySelection.RegisterForFeat(prog);
            //LegacySelection.Register(prog);
            EdgeLordLegacySelection.Register(prog);
            GodEmperorLegacySelection.Prohibit(prog);
            HeroLegacySelection.Register(prog);
            MastermindLegacySelection.Prohibit(prog);
            OverlordLegacySelection.Register(prog);

            BlueprintFeature EnergizeWeapon = BlueprintTools.GetBlueprint<BlueprintFeature>("fb9fe27f13934807bcd62dfeec477758");
            LevelEntry[] additionalReferencedFeats = null;
            if (ModSupport.IsExpandedElementEnabled && EnergizeWeapon != null) {
                additionalReferencedFeats = new LevelEntry[] { Helpers.CreateLevelEntry(1, EnergizeWeapon) };
            }
            prog = StaticReferences.PatchClassProgressionBasedonRefArchetype(prog, ClassTools.Classes.KineticistClass, BaseKnight, additionalReferencedFeats);
            BlueprintCharacterClassReference refClass = ClassTools.ClassReferences.KineticistClass;
            BlueprintCharacterClassReference myClass = IsekaiProtagonistClass.GetReference();
            StaticReferences.PatchProgressionFeaturesBasedOnReferenceArchetype(myClass, refClass, BaseKnight);

            prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = KineticDarkElementalistLegacy.Get().ToReference<BlueprintFeatureReference>(); });
            prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = KineticLegacy.Get().ToReference<BlueprintFeatureReference>(); });
            prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = KineticOverwhelmingSoulLegacy.Get().ToReference<BlueprintFeatureReference>(); });
        }
        public static BlueprintProgression Get() {
            if (prog != null) return prog;
            return BlueprintTools.GetModBlueprint<BlueprintProgression>(IsekaiContext, "KineticKnightLegacy");
        }
    }
}
