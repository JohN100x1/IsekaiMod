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

    internal class ShifterBaseLegacy {


        private static BlueprintProgression prog;
        private static BlueprintProgression progAlternate;

        public static void Configure() {

            prog = Helpers.CreateBlueprint<BlueprintProgression>(IsekaiContext, "ShifterBaseLegacy", bp => {
                bp.SetName(IsekaiContext, "Shifter Legacy - Beast Shifter");
                bp.SetDescription(IsekaiContext,
                    "You have a connection to nature, maybe one of your ancestors as a were creature or a druidic circle initiated you into the secrets of shapeshifting, regardless of the source you have a connection to the animal kingdrom enabling you to shapeshift. \n" +
                    "As a result of the nature of your shapeshifter ability you have less choice (you will never be a tree or an elemental) but greater control, allowing for partial shifts."
                    );
                bp.GiveFeaturesForPreviousLevels = true;
                bp.AddComponent<PrerequisiteAlignment>(c => {
                    c.Alignment = Kingmaker.UnitLogic.Alignments.AlignmentMaskType.NeutralEvil
                    | Kingmaker.UnitLogic.Alignments.AlignmentMaskType.NeutralGood
                    | Kingmaker.UnitLogic.Alignments.AlignmentMaskType.ChaoticNeutral
                    | Kingmaker.UnitLogic.Alignments.AlignmentMaskType.LawfulNeutral
                    | Kingmaker.UnitLogic.Alignments.AlignmentMaskType.TrueNeutral;
                });
            });
            progAlternate = Helpers.CreateBlueprint<BlueprintProgression>(IsekaiContext, "ShifterEvilLegacy", bp => {
                bp.SetName(IsekaiContext, "Shifter Legacy - Skinwalker");
                bp.SetDescription(IsekaiContext,
                    "Skinwalkers are rare and dangerous predators that choose to exist above the natural order. \n" +
                    "Rather than communing with nature like the druids, Skinwalkers are known to choose a powerful predator, often times protectors of forests or mountains, before stalking them from the shadows until they find an opportune moment to lay a trap and claim their life. \n" +
                    "They will then ritually skin their prey before donning their hide and using it to transform into a semblance of its once mighty owner. \n" +
                    "Many a novice necromancer has actually looked at you in horror at the realization of just what this ritual skinning involved, because he originally thought he was the evil member of the group."
                    );
                bp.GiveFeaturesForPreviousLevels = true;
                bp.AddComponent<PrerequisiteAlignment>(c => {
                    c.Alignment = Kingmaker.UnitLogic.Alignments.AlignmentMaskType.Evil;
                });
            });
        }
        public static void PatchProgression() {
            if (prog != null) {
                if (ClassTools.Classes.ShifterClass == null) {
                    Main.Log("Shifter Class not present Shifter skipped.");
                    return;
                }
                BlueprintCharacterClassReference myClass = IsekaiProtagonistClass.GetReference();
                prog = StaticReferences.PatchClassProgressionBasedOnRefClass(prog, ClassTools.Classes.ShifterClass);
                StaticReferences.PatchProgressionFeaturesBasedOnReferenceClass(prog, myClass, ClassTools.ClassReferences.ShifterClass);

                progAlternate = StaticReferences.PatchClassProgressionBasedOnRefClass(progAlternate, ClassTools.Classes.ShifterClass);


                LegacySelection.RegisterForFeat(prog);
                LegacySelection.RegisterForFeat(progAlternate);


                LegacySelection.Register(prog);
                EdgeLordLegacySelection.Register(prog);
                GodEmperorLegacySelection.Prohibit(prog);
                HeroLegacySelection.Register(prog);
                MastermindLegacySelection.Prohibit(prog);
                OverlordLegacySelection.Register(prog);
                GodEmperorLegacySelection.Prohibit(prog);

                LegacySelection.Register(progAlternate);
                EdgeLordLegacySelection.Register(progAlternate);
                GodEmperorLegacySelection.Prohibit(progAlternate);
                HeroLegacySelection.Prohibit(progAlternate);
                MastermindLegacySelection.Prohibit(progAlternate);
                OverlordLegacySelection.Register(progAlternate);

                prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = ShifterStingerLegacy.Get().ToReference<BlueprintFeatureReference>(); });
                prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = ShifterDragonLegacy.Get().ToReference<BlueprintFeatureReference>(); });
                prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = ShifterGriffonLegacy.Get().ToReference<BlueprintFeatureReference>(); });
                prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = ShifterHolyLegacy.Get().ToReference<BlueprintFeatureReference>(); });
                prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = DruidBaseLegacy.Get().ToReference<BlueprintFeatureReference>(); });
                prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = progAlternate.ToReference<BlueprintFeatureReference>(); });

                progAlternate.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = ShifterStingerLegacy.Get().ToReference<BlueprintFeatureReference>(); });
                progAlternate.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = ShifterDragonLegacy.Get().ToReference<BlueprintFeatureReference>(); });
                progAlternate.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = ShifterGriffonLegacy.Get().ToReference<BlueprintFeatureReference>(); });
                progAlternate.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = ShifterHolyLegacy.Get().ToReference<BlueprintFeatureReference>(); });
                progAlternate.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = DruidBaseLegacy.Get().ToReference<BlueprintFeatureReference>(); });
                progAlternate.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = prog.ToReference<BlueprintFeatureReference>(); });

            }
        }

        public static BlueprintProgression Get() {
            if (prog != null) return prog;
            return BlueprintTools.GetModBlueprint<BlueprintProgression>(IsekaiContext, "ShifterBaseLegacy");
        }

        public static BlueprintProgression GetEvilAlternate() {
            if (prog != null) return prog;
            return BlueprintTools.GetModBlueprint<BlueprintProgression>(IsekaiContext, "ShifterEvilLegacy");
        }
    }
}
