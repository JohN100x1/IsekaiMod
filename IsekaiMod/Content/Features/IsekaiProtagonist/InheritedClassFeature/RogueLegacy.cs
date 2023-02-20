using IsekaiMod.Content.Classes.IsekaiProtagonist;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.EdgeLord;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Villain;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.InheritedClassFeature {

    internal class RogueLegacy {
        private static BlueprintProgression prog;

        public static void Configure() {
            prog = Helpers.CreateBlueprint<BlueprintProgression>(IsekaiContext, "RogueLegacy", bp => {
                bp.SetName(IsekaiContext, "Rogue Legacy - Supernatural Thief");
                bp.SetDescription(IsekaiContext, "Your reincarnation gave you great power, that is no reason to forget the usefulness of a simple backstab.");
                bp.GiveFeaturesForPreviousLevels = true;
                bp.IsClassFeature = true;
                bp.m_Classes = new BlueprintProgression.ClassWithLevel[] {
                    new BlueprintProgression.ClassWithLevel {
                        m_Class = IsekaiProtagonistClass.GetReference(),
                        AdditionalLevel = 0
                    }
                };
                bp.LevelEntries = new LevelEntry[] {
                    Helpers.CreateLevelEntry(1, StaticReferences.RogueSneakAttack),
                    Helpers.CreateLevelEntry(2, StaticReferences.RogueUncannyDodge, StaticReferences.RogueTalentSelection),
                    Helpers.CreateLevelEntry(3, StaticReferences.RogueSneakAttack, StaticReferences.RogueEvasion),
                    Helpers.CreateLevelEntry(4, StaticReferences.RogueTalentSelection),
                    Helpers.CreateLevelEntry(5, StaticReferences.RogueSneakAttack, StaticReferences.RogueImprovedUncannyDodge),
                    Helpers.CreateLevelEntry(6, StaticReferences.RogueTalentSelection),
                    Helpers.CreateLevelEntry(7, StaticReferences.RogueSneakAttack),
                    Helpers.CreateLevelEntry(8, StaticReferences.RogueTalentSelection),
                    Helpers.CreateLevelEntry(9, StaticReferences.RogueSneakAttack),
                    Helpers.CreateLevelEntry(10, StaticReferences.RogueImprovedEvasion, StaticReferences.RogueAdvancedTalents),
                    Helpers.CreateLevelEntry(11, StaticReferences.RogueSneakAttack),
                    Helpers.CreateLevelEntry(12, StaticReferences.RogueTalentSelection),
                    Helpers.CreateLevelEntry(13, StaticReferences.RogueSneakAttack),
                    Helpers.CreateLevelEntry(14, StaticReferences.RogueTalentSelection),
                    Helpers.CreateLevelEntry(15, StaticReferences.RogueSneakAttack),
                    Helpers.CreateLevelEntry(17, StaticReferences.RogueSneakAttack),
                    Helpers.CreateLevelEntry(18, StaticReferences.RogueTalentSelection),
                    Helpers.CreateLevelEntry(19, StaticReferences.RogueSneakAttack),
                };
                bp.UIGroups = new UIGroup[] {
                    Helpers.CreateUIGroup(StaticReferences.RogueSneakAttack, StaticReferences.RogueTalentSelection, StaticReferences.RogueAdvancedTalents),
                    Helpers.CreateUIGroup(StaticReferences.RogueUncannyDodge, StaticReferences.RogueEvasion, StaticReferences.RogueImprovedUncannyDodge, StaticReferences.RogueImprovedEvasion)
                };

            });
            LegacySelection.GetClassFeature().AddFeatures(prog);
            LegacySelection.GetOverwhelmingFeature().AddFeatures(prog);

            EdgeLordLegacySelection.getClassFeature().AddFeatures(prog);
            VillainLegacySelection.getClassFeature().AddFeatures(prog);
        }
        public static BlueprintProgression Get() {
            if (prog != null) return prog;
            return BlueprintTools.GetModBlueprint<BlueprintProgression>(IsekaiContext, "RogueLegacy");
        }
    }
}
