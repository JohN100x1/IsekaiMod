using IsekaiMod.Content.Classes.IsekaiProtagonist;
using IsekaiMod.Content.Classes.IsekaiProtagonist.Archetypes;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.EdgeLord;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.GodEmperor;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Hero;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Villain;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.InheritedClassFeature {
    internal class DruidBaseLegacy {
        private static BlueprintProgression prog;


        public static void Configure() {
            prog = Helpers.CreateBlueprint<BlueprintProgression>(IsekaiContext, "DruidBaseLegacy", bp => {
                bp.SetName(IsekaiContext, "Druid Legacy - Nature Mage");
                bp.SetDescription(IsekaiContext, 
                    "You were a nature lover in your previous world, but you lived in a polluted and crowded city that stifled your connection to the natural world. \n" +
                    "You dreamed of escaping to a place where you could be free and wild, and one day you got your wish. \n" +
                    "You have been reincarnated in a world where nature is abundant and diverse, and you have learned how to tap into its primal magic. \n" +
                    "You can cast spells that manipulate the elements, summon creatures, and enhance your own abilities. \n" +
                    "You are a protector of nature and a friend to all living.");
                bp.GiveFeaturesForPreviousLevels = true;
                bp.AddComponent<PrerequisiteAlignment>(c => {
                    c.Alignment = Kingmaker.UnitLogic.Alignments.AlignmentMaskType.NeutralEvil
                    | Kingmaker.UnitLogic.Alignments.AlignmentMaskType.NeutralGood
                    | Kingmaker.UnitLogic.Alignments.AlignmentMaskType.ChaoticNeutral
                    | Kingmaker.UnitLogic.Alignments.AlignmentMaskType.LawfulNeutral
                    | Kingmaker.UnitLogic.Alignments.AlignmentMaskType.TrueNeutral;
                });
            });

            LegacySelection.RegisterForFeat(prog);
            LegacySelection.Register(prog);
            EdgeLordLegacySelection.Prohibit(prog);
            GodEmperorLegacySelection.Prohibit(prog);
            HeroLegacySelection.Register(prog);
            VillainLegacySelection.Prohibit(prog);
        }

        public static void PatchProgression() {
            if (prog != null) {
                LevelEntry[] addentries = new LevelEntry[] { };
                LevelEntry[] removeentries = new LevelEntry[] { };
                removeentries = removeentries.AppendToArray(Helpers.CreateLevelEntry(1, FeatTools.Selections.DruidBondSelection, 
                    BlueprintTools.GetBlueprint<BlueprintFeature>("b296531ffe013c8499ad712f8ae97f6b"), 
                    BlueprintTools.GetBlueprint<BlueprintFeature>("d00ff3791359311449c481126fbf71ce")));

                prog = StaticReferences.PatchClassProgressionBasedOnSeparateLists(prog, ClassTools.Classes.DruidClass,addentries,removeentries);
                BlueprintCharacterClassReference myClass = IsekaiProtagonistClass.GetReference();
                StaticReferences.PatchProgressionFeaturesBasedOnReferenceClass(prog, myClass, ClassTools.ClassReferences.DruidClass);

                prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = ShifterBaseLegacy.Get().ToReference<BlueprintFeatureReference>(); });
                prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = ShifterDragonLegacy.Get().ToReference<BlueprintFeatureReference>(); });
                prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = ShifterStingerLegacy.Get().ToReference<BlueprintFeatureReference>(); });
                prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = ShifterGriffonLegacy.Get().ToReference<BlueprintFeatureReference>(); });
                prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = ShifterHolyLegacy.Get().ToReference<BlueprintFeatureReference>(); });
                prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = ShifterBaseLegacy.GetEvilAlternate().ToReference<BlueprintFeatureReference>(); });
            }
        }

        public static BlueprintProgression Get() {
            if (prog != null) return prog;
            return BlueprintTools.GetModBlueprint<BlueprintProgression>(IsekaiContext, "DruidBaseLegacy");
        }
    }
}
