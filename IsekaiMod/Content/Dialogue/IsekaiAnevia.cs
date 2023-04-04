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

    internal class IsekaiAnevia {

        // Next Cue and Etude
        private static readonly BlueprintAnswersList AnswersList_0003 = BlueprintTools.GetBlueprint<BlueprintAnswersList>("33960c7f7af40cd43b7f801a76c87a0b");

        public static void Add() {
            // Prompt (Anevia, at Defender's Heart Act 1)
            /* It is good to see you. What can I do for you? Would you like to renew your forces with excellent fighters?
             */
            // Answer
            var IsekaiDialogueAneviaReply2 = TTCoreExtensions.CreateCue("IsekaiDialogueAneviaReply2", bp => {
                bp.SetText(IsekaiContext, "\"Also, for no particular reason, would you be interested in a spare of coffin I have lying around?\"");
                bp.Speaker = new DialogSpeaker {
                    m_Blueprint = null,
                    MoveCamera = true
                };
                bp.Answers = AnswersList_0003.Answers;
            });
            var IsekaiDialogueAneviaReply = TTCoreExtensions.CreateCue("IsekaiDialogueAneviaReply", bp => {
                bp.SetText(IsekaiContext, "Sure thing, only if you can convince Irabeth to join.");
                bp.Speaker = new DialogSpeaker {
                    m_Blueprint = null,
                    MoveCamera = true
                };
                bp.Continue = new CueSelection {
                    Cues = new List<BlueprintCueBaseReference>() { IsekaiDialogueAneviaReply2.ToReference<BlueprintCueBaseReference>() },
                    Strategy = Strategy.First
                };
            });
            var IsekaiDialogueAnevia = TTCoreExtensions.CreateAnswer("IsekaiDialogueAnevia", bp => {
                bp.SetText(IsekaiContext, "(Isekai Protagonist) \"Do you want to join my harem?\"");
                bp.NextCue = new CueSelection() {
                    Cues = new List<BlueprintCueBaseReference>() { IsekaiDialogueAneviaReply.ToReference<BlueprintCueBaseReference>() },
                    Strategy = Strategy.First
                };
                bp.ShowConditions = ActionFlow.IfAll(
                    new PlayerSignificantClassIs {
                        Not = false,
                        CheckGroup = false,
                        m_CharacterClass = IsekaiProtagonistClass.GetReference()
                    },
                    new CueSeen {
                        Not = true,
                        m_Cue = IsekaiDialogueAneviaReply.ToReference<BlueprintCueBaseReference>()
                    });
            });

            // Add Answer to answers list
            AnswersList_0003.Answers.Insert(0, IsekaiDialogueAnevia.ToReference<BlueprintAnswerBaseReference>());
        }
    }
}