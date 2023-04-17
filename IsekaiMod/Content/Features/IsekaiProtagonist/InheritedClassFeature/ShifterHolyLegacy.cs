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
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.InheritedClassFeature {
    internal class ShifterHolyLegacy {
        private static string BaseArchetypeId = "0aa6bd7be7fb4bcaabe38cbc82d296e1";
        private static BlueprintArchetype BaseArchetype = BlueprintTools.GetBlueprint<BlueprintArchetype>(BaseArchetypeId);

        private static BlueprintProgression prog;

        public static void Configure() {
            if (ClassTools.Classes.ShifterClass == null) { return; }
            prog = Helpers.CreateBlueprint<BlueprintProgression>(IsekaiContext, "ShifterHolyLegacy", bp => {
                bp.SetName(IsekaiContext, "Shifter Legacy - Divine Beast");
                bp.SetDescription(IsekaiContext,
                    "Your reincarnation was the action of a god. \n" +
                    "They send you to this world to be a hero, so while you feel a connection to nature this connection is in a way \"tainted\" by that divine connection. \n" +
                    "Your kin are not the normal animals roaming the woods but the divine beasts of your deities realm."
                    );
                bp.GiveFeaturesForPreviousLevels = true;
                bp.AddComponent<PrerequisiteAlignment>(c => { c.Alignment = Kingmaker.UnitLogic.Alignments.AlignmentMaskType.Good; });
            });


        }
        public static void PatchProgression() {
            if (ClassTools.Classes.ShifterClass == null) { return; }

            if (BaseArchetype == null) {
                BaseArchetype = BlueprintTools.GetBlueprint<BlueprintArchetype>(BaseArchetypeId);
                if (BaseArchetype == null) return;
            }


            LegacySelection.RegisterForFeat(prog);
            LegacySelection.Register(prog);
            EdgeLordLegacySelection.Prohibit(prog);
            GodEmperorLegacySelection.Register(prog);
            HeroLegacySelection.Register(prog);
            MastermindLegacySelection.Prohibit(prog);
            OverlordLegacySelection.Register(prog);

            prog = PatchTools.PatchClassProgressionBasedonRefArchetype(prog, ClassTools.Classes.ShifterClass, BaseArchetype, null);
            BlueprintCharacterClassReference refClass = ClassTools.ClassReferences.ShifterClass;
            BlueprintCharacterClassReference myClass = IsekaiProtagonistClass.GetReference();
            PatchTools.PatchProgressionFeaturesBasedOnReferenceArchetype(myClass, refClass, BaseArchetype);

            prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = ShifterBaseLegacy.Get().ToReference<BlueprintFeatureReference>(); });
            prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = ShifterBaseLegacy.GetEvilAlternate().ToReference<BlueprintFeatureReference>(); });
            prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = ShifterStingerLegacy.Get().ToReference<BlueprintFeatureReference>(); });
            prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = ShifterGriffonLegacy.Get().ToReference<BlueprintFeatureReference>(); });
            prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = ShifterDragonLegacy.Get().ToReference<BlueprintFeatureReference>(); });
            prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = DruidBaseLegacy.Get().ToReference<BlueprintFeatureReference>(); });
        }
        public static BlueprintProgression Get() {
            if (prog != null) return prog;
            return BlueprintTools.GetModBlueprint<BlueprintProgression>(IsekaiContext, "ShifterHolyLegacy");
        }
    }
}
