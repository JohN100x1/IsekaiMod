using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.Designers.EventConditionActionSystem.Conditions;
using Kingmaker.Designers.EventConditionActionSystem.Evaluators;
using Kingmaker.DialogSystem;
using Kingmaker.DialogSystem.Blueprints;
using Kingmaker.EntitySystem.Stats;
using System.Collections.Generic;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Dialogue {
    internal class IsekaiAneviaIrabethHarem {
        public static void Add() {
            AddAneviaDialogue1();
            AddIrabethDialogue1();
            AddAneviaDialogue2();
        }

        private static void AddAneviaDialogue1() {
            var AnswersList_0003 = BlueprintTools.GetBlueprint<BlueprintAnswersList>("33960c7f7af40cd43b7f801a76c87a0b");

            // Prompt (Anevia, at Defender's Heart Act 1)
            /* It is good to see you. What can I do for you? Would you like to renew your forces with excellent fighters?
             */
            // Answer
            var IsekaiDialogueAneviaReply2 = TTCoreExtensions.CreateCue("IsekaiDialogueAneviaReply2", bp => {
                bp.SetText(IsekaiContext, "\"Also, for no particular reason, would you be interested in a spare of coffin I have lying around?\"");
                bp.Answers = AnswersList_0003.Answers;
            });
            var IsekaiDialogueAneviaReply = TTCoreExtensions.CreateCue("IsekaiDialogueAneviaReply", bp => {
                bp.SetText(IsekaiContext, "\"Sure thing, only if you can convince Irabeth to join.\"");
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
                bp.ShowOnce = true;
            });

            // Add Answer to answers list
            AnswersList_0003.Answers.Insert(0, IsekaiDialogueAnevia.ToReference<BlueprintAnswerBaseReference>());
        }

        private static void AddIrabethDialogue1() {

            var AnswersList_0009 = BlueprintTools.GetBlueprint<BlueprintAnswersList>("871af36f2ab2b1f40b5de77976c54276");
            var dialogueAneviaRef = BlueprintTools.GetModBlueprintReference<BlueprintAnswerReference>(IsekaiContext, "IsekaiDialogueAnevia");

            // Prompt (Irabeth, at Defender's Heart Act 1)
            /* {n}Irabeth rubs her red and tired eyes.{/n} \"Any success? How is the city?\"
             */
            // Answer
            var IsekaiDialogueIrabethReplySuccess = TTCoreExtensions.CreateCue("IsekaiDialogueIrabethReplySuccess", bp => {
                bp.SetText(IsekaiContext, "\"Fine. I'll join your harem after the crusades against the demons is over.\"");
                bp.Answers = AnswersList_0009.Answers;
            });
            var IsekaiDialogueIrabethReplyFail = TTCoreExtensions.CreateCue("IsekaiDialogueIrabethReplyFail", bp => {
                bp.SetText(IsekaiContext, "\"I don't think so.\"");
                bp.Answers = AnswersList_0009.Answers;
            });
            var IsekaiDialogueIrabethCheck = TTCoreExtensions.CreateCheck("IsekaiDialogueIrabethCheck", bp => {
                bp.Type = StatType.CheckBluff;
                bp.DC = 36;
                bp.m_Success = IsekaiDialogueIrabethReplySuccess.ToReference<BlueprintCueBaseReference>();
                bp.m_Fail = IsekaiDialogueIrabethReplyFail.ToReference<BlueprintCueBaseReference>();
                bp.Experience = DialogExperience.LargeExperience;
            });
            var IsekaiDialogueIrabethReply2 = TTCoreExtensions.CreateCue("IsekaiDialogueIrabethReply2", bp => {
                bp.SetText(IsekaiContext, "\"That's what I thought.\"");
                bp.Answers = AnswersList_0009.Answers;
            });
            var IsekaiDialogueIrabethAnswer1 = TTCoreExtensions.CreateAnswer("IsekaiDialogueIrabethAnswer1", bp => {
                bp.SetText(IsekaiContext, "\"It's true.\"");
                bp.NextCue = new CueSelection() {
                    Cues = new List<BlueprintCueBaseReference>() { IsekaiDialogueIrabethCheck.ToReference<BlueprintCueBaseReference>() },
                    Strategy = Strategy.First
                };
            });
            var IsekaiDialogueIrabethAnswer2 = TTCoreExtensions.CreateAnswer("IsekaiDialogueIrabethAnswer2", bp => {
                bp.SetText(IsekaiContext, "\"Nevermind. It was a joke.\"");
                bp.NextCue = new CueSelection() {
                    Cues = new List<BlueprintCueBaseReference>() { IsekaiDialogueIrabethReply2.ToReference<BlueprintCueBaseReference>() },
                    Strategy = Strategy.First
                };
            });
            var IsekaiDialogueIrabethReply = TTCoreExtensions.CreateCue("IsekaiDialogueIrabethReply", bp => {
                bp.SetText(IsekaiContext, "\"Ridiculous! I don't know what sorcery is this, but Anevia would never agree to this.\"");
                bp.Answers = new List<BlueprintAnswerBaseReference> {
                    IsekaiDialogueIrabethAnswer1.ToReference<BlueprintAnswerBaseReference>(),
                    IsekaiDialogueIrabethAnswer2.ToReference<BlueprintAnswerBaseReference>()
                };
            });
            var IsekaiDialogueIrabeth = TTCoreExtensions.CreateAnswer("IsekaiDialogueIrabeth", bp => {
                bp.SetText(IsekaiContext, "(Isekai Protagonist) \"Do you want to join my harem? Anevia is also joining.\"");
                bp.NextCue = new CueSelection() {
                    Cues = new List<BlueprintCueBaseReference>() { IsekaiDialogueIrabethReply.ToReference<BlueprintCueBaseReference>() },
                    Strategy = Strategy.First
                };
                bp.AddShowCondition<AnswerSelected>(c => {
                    c.Not = false;
                    c.m_Answer = dialogueAneviaRef;
                });
                bp.ShowOnce = true;
            });

            // Add Answer to answers list
            AnswersList_0009.Answers.Insert(0, IsekaiDialogueIrabeth.ToReference<BlueprintAnswerBaseReference>());
        }

        private static void AddAneviaDialogue2() {
            var IrabethConfidenceRef = BlueprintTools.GetBlueprintReference<BlueprintUnlockableFlagReference>("bad10fc91d11a1d439633cc9131d6e35");
            var dialogueIrabethRef = BlueprintTools.GetModBlueprintReference<BlueprintCueBaseReference>(IsekaiContext, "IsekaiDialogueIrabethReplySuccess");
            var AnswersList_0003 = BlueprintTools.GetBlueprint<BlueprintAnswersList>("33960c7f7af40cd43b7f801a76c87a0b");

            // Prompt (Anevia, at Defender's Heart Act 1)
            /* It is good to see you. What can I do for you? Would you like to renew your forces with excellent fighters?
             */
            // Answer
            var IsekaiDialogueAneviaReply3 = TTCoreExtensions.CreateCue("IsekaiDialogueAneviaReply3", bp => {
                bp.SetText(IsekaiContext, "{n}Anevia is astonished.{/n} \"That was completely unexpected. "
                    + "I guess I'll discuss with Irabeth about our glorious future in your harem.\"");
                bp.OnStop = ActionFlow.DoSingle<IncrementFlagValue>(c => {
                    c.m_Flag = IrabethConfidenceRef;
                    c.Value = new IntConstant() { Value = 1 };
                    c.UnlockIfNot = true;
                });
                bp.Answers = AnswersList_0003.Answers;
            });
            var IsekaiDialogueAnevia2 = TTCoreExtensions.CreateAnswer("IsekaiDialogueAnevia2", bp => {
                bp.SetText(IsekaiContext, "(Isekai Protagonist) \"I've convinced Irabeth to join the harem.\"");
                bp.NextCue = new CueSelection() {
                    Cues = new List<BlueprintCueBaseReference>() { IsekaiDialogueAneviaReply3.ToReference<BlueprintCueBaseReference>() },
                    Strategy = Strategy.First
                };
                bp.AddShowCondition<CueSeen>(c => {
                    c.Not = false;
                    c.m_Cue = dialogueIrabethRef;
                });
                bp.ShowOnce = true;
            });

            // Add Answer to answers list
            AnswersList_0003.Answers.Insert(0, IsekaiDialogueAnevia2.ToReference<BlueprintAnswerBaseReference>());
        }
    }
}