using IsekaiMod.Content.Classes.IsekaiProtagonist;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.EdgeLord;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.GodEmperor;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Hero;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Villain;
using Kingmaker.Blueprints.Classes;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.InheritedClassFeature {
    internal class PlayerComputerNerdLegacy {
        private static BlueprintProgression prog;

        public static void Configure() {
            prog = Helpers.CreateBlueprint<BlueprintProgression>(IsekaiContext, "PlayerComputerNerdLegacy", bp => {
                BlueprintFeature ArcanaFocus = BlueprintTools.GetBlueprint<BlueprintFeature>("cad1b9175e8c0e64583432a22134d33c");
                bp.SetName(IsekaiContext, "Player Legacy - Computer Nerd");
                bp.SetDescription(IsekaiContext,
                    "You were a computer nerd in your last life, you get a +10 Bonus to Knowledge(Programming) and +5 to your MMORPG Skill.\n" +
                    "Wait what do you mean there are no computers in this world and all that knowledge and skill is useless?\n" +
                    "Well at least some of the theoretical knowledge about magic is applicable in this world...");
                bp.GiveFeaturesForPreviousLevels = false;
                bp.IsClassFeature = true;
                bp.m_Classes = new BlueprintProgression.ClassWithLevel[] {
                    new BlueprintProgression.ClassWithLevel {
                        m_Class = IsekaiProtagonistClass.GetReference(),
                        AdditionalLevel = 0
                    }

                };
                bp.LevelEntries = new LevelEntry[] {
                    Helpers.CreateLevelEntry (1, ArcanaFocus ),
                };
                bp.UIGroups = new UIGroup[] {
                    Helpers.CreateUIGroup( ArcanaFocus),
                };
            });
            LegacySelection.RegisterForFeat(prog);
            LegacySelection.Register(prog);
            EdgeLordLegacySelection.Register(prog);
            HeroLegacySelection.Register(prog);
            VillainLegacySelection.Register(prog);
            GodEmperorLegacySelection.Register(prog);

        }
        public static void PatchProgression() {            
        }

        public static BlueprintProgression Get() {
            if (prog != null) return prog;
            return BlueprintTools.GetModBlueprint<BlueprintProgression>(IsekaiContext, "PlayerComputerNerdLegacy");
        }
    }
}
