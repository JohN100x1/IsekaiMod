using IsekaiMod.Content.Classes.IsekaiProtagonist;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Designers.EventConditionActionSystem.Conditions;
using Kingmaker.DialogSystem;
using Kingmaker.DialogSystem.Blueprints;
using System.Collections.Generic;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Dialogue {

    internal class IsekaiMinagho {

        // Next Cue and Etude
        private static readonly BlueprintUnit IrabethTirabladeGG = BlueprintTools.GetBlueprint<BlueprintUnit>("e778129f817a5fa4286e64b061df84a5");
        private static readonly BlueprintUnit Seelah = BlueprintTools.GetBlueprint<BlueprintUnit>("54be53f0b35bf3c4592a97ae335fe765");
        private static readonly BlueprintUnit Camellia = BlueprintTools.GetBlueprint<BlueprintUnit>("397b090721c41044ea3220445300e1b8");
        private static readonly BlueprintCue ThatsNotVeryNiceCue = BlueprintTools.GetBlueprint<BlueprintCue>("3bd9a4263d8064b49a9d1eec365807b9");

        public static void Add() {
            // Prompt (Irabeth, at Gray Garrison encounter with Minagho)
            /* \"{g|Minagho}Minagho{/g}? The one who...\" {n}The half-orc is too well-bred to spit on the floor, but the name sounds like a slur on her tongue.{/n}
             * \"Be careful, she's one of the deadliest creatures in the whole demon horde. She was once responsible for a massacre in {g|Kenabres}Kenabres{/g}...
             * She must be back to finish what she started!\"
             */
            // Answer
            var IsekaiDialogueMinaghoSeelahReply = ThingsNotHandledByTTTCore.CreateCue("IsekaiDialogueMinaghoSeelahReply", bp => {
                bp.SetText(IsekaiContext, "{n}Seelah smiles and gives you a thumbs up!{/n}");
                bp.Speaker = new DialogSpeaker {
                    m_Blueprint = Seelah.ToReference<BlueprintUnitReference>(),
                    MoveCamera = true
                };
                bp.Continue = new CueSelection {
                    Cues = new List<BlueprintCueBaseReference>() { ThatsNotVeryNiceCue.ToReference<BlueprintCueBaseReference>() },
                    Strategy = Strategy.First
                };
            });
            var IsekaiDialogueMinaghoCamelliaReply = ThingsNotHandledByTTTCore.CreateCue("IsekaiDialogueMinaghoCamelliaReply", bp => {
                bp.SetText(IsekaiContext, "...");
                bp.Speaker = new DialogSpeaker {
                    m_Blueprint = Camellia.ToReference<BlueprintUnitReference>(),
                    MoveCamera = true
                };
                bp.Continue = new CueSelection {
                    Cues = new List<BlueprintCueBaseReference>() { IsekaiDialogueMinaghoSeelahReply.ToReference<BlueprintCueBaseReference>() },
                    Strategy = Strategy.First
                };
            });
            var IsekaiDialogueMinaghoIrabethReply = ThingsNotHandledByTTTCore.CreateCue("IsekaiDialogueMinaghoIrabethReply", bp => {
                bp.SetText(IsekaiContext, "...");
                bp.Speaker = new DialogSpeaker {
                    m_Blueprint = IrabethTirabladeGG.ToReference<BlueprintUnitReference>(),
                    MoveCamera = true
                };
                bp.Continue = new CueSelection {
                    Cues = new List<BlueprintCueBaseReference>() { IsekaiDialogueMinaghoCamelliaReply.ToReference<BlueprintCueBaseReference>() },
                    Strategy = Strategy.First
                };
                bp.TurnSpeaker = false;
            });
            var IsekaiDialogueMinagho = ThingsNotHandledByTTTCore.CreateAnswer("IsekaiDialogueMinagho", bp => {
                bp.SetText(IsekaiContext, "(Isekai Protagonist) \"Minagho? More like Minag-hoe!\"");
                bp.NextCue = new CueSelection {
                    Cues = new List<BlueprintCueBaseReference>() { IsekaiDialogueMinaghoIrabethReply.ToReference<BlueprintCueBaseReference>() },
                    Strategy = Strategy.First
                };
                bp.ShowConditions = ActionFlow.IfSingle<PlayerSignificantClassIs>(c => {
                    c.Not = false;
                    c.CheckGroup = false;
                    c.m_CharacterClass = IsekaiProtagonistClass.GetReference();
                });
            });

            // Add Answer to answers list
            var AnswersList_0009 = BlueprintTools.GetBlueprint<BlueprintAnswersList>("5acd8001d9f7d2443bd57fb1291a03e4");
            AnswersList_0009.Answers.Insert(0, IsekaiDialogueMinagho.ToReference<BlueprintAnswerBaseReference>());
        }
    }
}