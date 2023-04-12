using IsekaiMod.Content.Classes.IsekaiProtagonist;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.EdgeLord;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Hero;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Mastermind;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Overlord;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using TabletopTweaks.Core.NewComponents.AbilitySpecific;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.InheritedClassFeature {
    internal class MagusBasicLegacy {
        private static BlueprintProgression prog;


        public static void Configure() {
            prog = Helpers.CreateBlueprint<BlueprintProgression>(IsekaiContext, "MagusBasicLegacy", bp => {
                bp.SetName(IsekaiContext, "Magus Legacy - Magus");
                bp.SetDescription(IsekaiContext,
                    "You blend the powers of martial traning and spellcasting into a single style. \n" +
                    "After all hundrets of anime/games/books taught you just how dangerous overspecialisation in either art can be."
                    );
                bp.GiveFeaturesForPreviousLevels = true;
            });

            LegacySelection.RegisterForFeat(prog);
            LegacySelection.Register(prog);
            EdgeLordLegacySelection.Register(prog);
            //GodEmperorLegacySelection.Prohibit(prog);
            HeroLegacySelection.Register(prog);
            MastermindLegacySelection.Prohibit(prog);
            OverlordLegacySelection.Register(prog);
        }

        public static void PatchProgression() {
            if (prog != null) {
                prog = StaticReferences.PatchClassProgressionBasedOnRefClass(prog, ClassTools.Classes.MagusClass);
                BlueprintCharacterClassReference myClass = IsekaiProtagonistClass.GetReference();
                StaticReferences.PatchProgressionFeaturesBasedOnReferenceClass(prog, myClass, ClassTools.ClassReferences.MagusClass);

                prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = MagusArcherLegacy.Get().ToReference<BlueprintFeatureReference>(); });
                prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = MagusDancerLegacy.Get().ToReference<BlueprintFeatureReference>(); });
                prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = MagusSpellbladeLegacy.Get().ToReference<BlueprintFeatureReference>(); });
            }
        }

        public static BlueprintProgression Get() {
            if (prog != null) return prog;
            return BlueprintTools.GetModBlueprint<BlueprintProgression>(IsekaiContext, "MagusBasicLegacy");
        }

        public static void PatchForBroadStudy() {
            if (prog != null) {
                prog.AddComponent<BroadStudyComponent>(c => {
                    c.CharacterClass = IsekaiProtagonistClass.GetReference();
                });
            }
            if (MagusArcherLegacy.Get() != null) {
                MagusArcherLegacy.Get().AddComponent<BroadStudyComponent>(c => {
                    c.CharacterClass = IsekaiProtagonistClass.GetReference();
                });
            }
            if (MagusDancerLegacy.Get() != null) {
                MagusDancerLegacy.Get().AddComponent<BroadStudyComponent>(c => {
                    c.CharacterClass = IsekaiProtagonistClass.GetReference();
                });
            }
            if (MagusSpellbladeLegacy.Get() != null) {
                MagusSpellbladeLegacy.Get().AddComponent<BroadStudyComponent>(c => {
                    c.CharacterClass = IsekaiProtagonistClass.GetReference();
                });
            }
        }
    }
}
